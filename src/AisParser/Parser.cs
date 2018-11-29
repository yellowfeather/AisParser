using System;
using System.Collections.Generic;
using System.Text;

namespace AisParser
{
    public class Parser
    {
        private readonly PayloadDecoder _payloadDecoder;
        private readonly AisMessageFactory _messageFactory;
        private IDictionary<int, string> _fragments = new Dictionary<int, string>();

        public Parser(PayloadDecoder payloadDecoder, AisMessageFactory messageFactory)
        {
            _payloadDecoder = payloadDecoder;
            _messageFactory = messageFactory;
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

            var numFragments = Convert.ToInt32(sentenceParts[1]);
            var radioChannelCode = sentenceParts[4];
            var encodedPayload = sentenceParts[5];

            if (numFragments > 1)
            {
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
            }

            var numFillBits = Convert.ToInt32(sentenceParts[6]);
            var payload = _payloadDecoder.Decode(encodedPayload, numFillBits);
            return _messageFactory.Create(payload);
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
