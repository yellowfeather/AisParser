using System;

namespace AisParser
{
    public class Payload
    {
        public string RawValue { get; set; }
        public AisMessageType MessageType { get; set; }

        public Payload(string rawValue)
        {
            RawValue = rawValue;
            MessageType = ReadEnum<AisMessageType>(0, 6);
        }

        public T ReadEnum<T>(int startIndex, int length) where T : Enum
        {
            var bitValue = RawValue.Substring(startIndex, length);
            var value = Convert.ToUInt32(bitValue, 2);
            return (T)Enum.ToObject(typeof(T), value);
        }

        public uint ReadUInt(int startIndex, int length)
        {
            var bitValue = RawValue.Substring(startIndex, length);
            return Convert.ToUInt32(bitValue, 2);
        }

        public int ReadInt(int startIndex, int length)
        {
            var bitValue = RawValue.Substring(startIndex, length);
            var result = Convert.ToInt32(bitValue.Substring(1), 2);
            if (bitValue.StartsWith("1"))
                result = (int) (result - Math.Pow(2, bitValue.Length));

            return result;
        }

        public double ReadUnsignedDouble(int startIndex, int length)
        {
            var bitValue = RawValue.Substring(startIndex, length);
            return Convert.ToUInt32(bitValue, 2);
        }

        public double ReadDouble(int startIndex, int length)
        {
            var bitValue = RawValue.Substring(startIndex, length);
            var result = (double)Convert.ToInt64(bitValue, 2);

            if (bitValue.StartsWith("1"))
                result = result - Math.Pow(2, bitValue.Length);

            return result;
        }

        public int? ReadRateOfTurn(int startIndex, int length)
        {
            var rateOfTurn = ReadInt(startIndex, length);
            return rateOfTurn == -256 ? null : new int?(rateOfTurn);
        }

        public uint? ReadTrueHeading(int startIndex, int length)
        {
            var trueHeading = ReadUInt(startIndex, length);
            return trueHeading == 511 ? null : new uint?(trueHeading);
        }

        public double ReadLongitude(int startIndex, int length)
        {
            return ReadDouble(startIndex, length) / 600000;
        }

        public double ReadLatitude(int startIndex, int length)
        {
            return ReadDouble(startIndex, length) / 600000;
        }

        public double ReadSpeedOverGround(int startIndex, int length)
        {
            return ReadUnsignedDouble(startIndex, length) / 10;
        }

        public double ReadCourseOverGround(int startIndex, int length)
        {
            return ReadUnsignedDouble(startIndex, length) / 10;
        }
    }
}
