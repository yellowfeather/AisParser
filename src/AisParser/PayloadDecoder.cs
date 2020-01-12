using System;
using System.Text;

namespace AisParser
{
    public class PayloadDecoder
    {
        public Payload Decode(string encodedPayload, int numFillBits)
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

            return new Payload(payload.ToString());
        }

    }
}
