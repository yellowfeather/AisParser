using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace AisParser
{
    public class Parser
    {
        private readonly PayloadDecoder _payloadDecoder;
        private readonly AisMessageFactory _messageFactory;
        private readonly PayloadEncoder _payloadEncoder;
        private readonly IDictionary<int, string> _fragments = new ConcurrentDictionary<int, string>();

        public Parser()
            : this(new PayloadDecoder(), new AisMessageFactory(), new PayloadEncoder())
        {
            
        }

        public Parser(PayloadDecoder payloadDecoder, AisMessageFactory messageFactory, PayloadEncoder payloadEncoder)
        {
            _payloadDecoder = payloadDecoder;
            _messageFactory = messageFactory;
            _payloadEncoder = payloadEncoder;
        }

        public AisMessage Parse(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                throw new ArgumentNullException(nameof(sentence));

            if (sentence[0] != '!')
                throw new AisParserException("Invalid sentence: sentence must start with !", sentence);

            var checksumIndex = sentence.IndexOf('*');
            if (checksumIndex == -1)
                throw new AisParserException("Invalid sentence: unable to find checksum", sentence);

            var checksum = ExtractChecksum(sentence, checksumIndex);

            var sentenceWithoutChecksum = sentence.Substring(0, checksumIndex);
            var calculatedChecksum = CalculateChecksum(sentenceWithoutChecksum);

            if (checksum != calculatedChecksum)
                throw new AisParserException($"Invalid sentence: checksum failure. Checksum: {checksum}, calculated: {calculatedChecksum}", sentence);

            var sentenceParts = sentenceWithoutChecksum.Split(',');
            var packetHeader = sentenceParts[0];
            if (!ValidPacketHeader(packetHeader))
                throw new AisParserException($"Unrecognised message: packet header {packetHeader}", sentence);

            // var radioChannelCode = sentenceParts[4];
            var encodedPayload = sentenceParts[5];

            if (string.IsNullOrWhiteSpace(encodedPayload))
                return null;

            var payload = DecodePayload(encodedPayload, sentenceParts);
            return payload == null ? null : _messageFactory.Create(payload);
        }

        public string Parse<T>(T aisMessage) where T : AisMessage
        {
            string sentence = "";

            // Example: !AIVDM,1,1,,A,B6CdCm0t3`tba35f@V9faHi7kP06,0*58
            //Field 1: Sentence Type
            //Field 2: Count Of Fragments
            //Field 3: Fragment Number
            //Field 4: Sequential Messages ID for multi-sentence messages (blank for none)
            //Field 5: Radio Channel Code (A or B)
            //Field 6: Payload
            //Field 7: 6 bit Boundary Padding (Zero seems to always be OK)?


            string sentenceType = "AIVDM";
            int countOfFragments = 1;
            int fragmentNumber = 1;
            int sequentialMessageId = 0;
            string radioChannel = "A";
            int boundaryPadding = 0;

            var payload = _messageFactory.Encode<T>(aisMessage);
            var payloadEncoded = _payloadEncoder.EncodeSixBitAis(payload);

            //Build the full sentence
            sentence += "!";
            sentence += sentenceType;
            sentence += ",";
            sentence += countOfFragments.ToString("0");
            sentence += ",";
            sentence += fragmentNumber.ToString("0");
            sentence += ",";
            if(sequentialMessageId != 0) sentence += sequentialMessageId.ToString("0");
            sentence += ",";
            sentence += radioChannel;
            sentence += ",";
            sentence += payloadEncoded;
            sentence += ",";
            sentence += boundaryPadding.ToString("0");

            var calculatedChecksum = CalculateChecksum(sentence);
            sentence += "*" + calculatedChecksum.ToString("00");

            return sentence;
        }

        private Payload DecodePayload(string encodedPayload, string[] sentenceParts)
        {
            var numFragments = Convert.ToInt32(sentenceParts[1]);
            var numFillBits = Convert.ToInt32(sentenceParts[6]);

            if (numFragments == 1)
            {
                var decoded = _payloadDecoder.Decode(encodedPayload, numFillBits);
                return decoded;
            }

            var fragmentNumber = Convert.ToInt32(sentenceParts[2]);
            var messageId = Convert.ToInt32(sentenceParts[3]);

            if (fragmentNumber == 1)
            {
                _fragments[messageId] = encodedPayload;
                return null;
            }

            if (fragmentNumber < numFragments)
            {
                _fragments[messageId] += encodedPayload;
                return null;
            }

            var fragment = _fragments[messageId];
            encodedPayload = fragment + encodedPayload;

            return _payloadDecoder.Decode(encodedPayload, numFillBits);
        }

        public int ExtractChecksum(string sentence, int checksumIndex)
        {
            var checksum = sentence.Substring(checksumIndex + 1);
            return Convert.ToInt32(checksum, 16);
        }

        public int CalculateChecksum(string sentence)
        {
            var data = sentence.Substring(1);

            var checksum = 0;
            foreach (var ch in data)
            {
                checksum ^= (byte)ch;
            }
            return Convert.ToInt32(checksum.ToString("X"), 16);
        }

        private bool ValidPacketHeader(string packetHeader)
        {
            return packetHeader == "!AIVDM" || packetHeader == "!AIVDO";
        }

        public string DecodePayload(string encodedPayload, int numFillBits)
        {
            var payload = new StringBuilder();
            foreach (var ch in encodedPayload)
            {
                var b = (byte)ch - 48;
                if (b > 40)
                {
                    b -= 8;
                }

                var paddedBits = Convert.ToString(b, 2).PadLeft(6, '0');
                payload.Append(paddedBits);
            }

            var remainder = (payload.Length + numFillBits) % 6;
            if (remainder != 0)
            {
                numFillBits += 6 - remainder;
            }

            if (numFillBits > 0)
            {
                payload.Append(new string('0', numFillBits));
            }

            return payload.ToString();
        }
    }
}
