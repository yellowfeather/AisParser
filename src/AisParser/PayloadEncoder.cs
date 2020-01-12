using System;
using System.Text;

namespace AisParser
{
    public class PayloadEncoder
    {
        public string EncodeSixBitAis(Payload payload)
        {
            //Consume each 6 bits and making them 8 bits, with some value shifts
            var value = payload.RawValue;
            if (String.IsNullOrEmpty(value))
                return value;

            string ret = "";

            for (int i = 0; i < value.Length / 6; ++i)
            {
                var b = value.Substring(6 * i, 6).PadLeft(8, '0');
                var c = (byte)ConvertBitsToChar(b);

                if (c < 40)
                    c += 48;
                else
                    c += 56;

                ret += Convert.ToChar(c);
            }

            return ret;
        }

        private static Char ConvertBitsToChar(String value)
        {
            int result = 0;

            foreach (Char ch in value)
                result = result * 2 + ch - '0';

            return (Char)result;
        }

    }
}
