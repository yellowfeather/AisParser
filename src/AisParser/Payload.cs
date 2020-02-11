using System;

namespace AisParser
{
    public class Payload
    {
        public Payload()
        {
            MessageType = AisMessageType.PositionReportClassA;
        }

        public Payload(string rawValue)
        {
            RawValue = rawValue;
            MessageType = ReadEnum<AisMessageType>(0, 6);
        }

        public string RawValue { get; }

        public AisMessageType MessageType { get; }

        public T ReadEnum<T>(int startIndex, int length) where T : Enum
        {
            var bitValue = Substring(startIndex, length);
            var value = Convert.ToUInt32(bitValue, 2);
            return (T) Enum.ToObject(typeof(T), value);
        }

        public AisMessageType? ReadNullableMessageType(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            var value = Convert.ToInt32(bitValue, 2);
            if (Enum.IsDefined(typeof(AisMessageType), value))
                return (AisMessageType) Enum.ToObject(typeof(AisMessageType), value);
            return null;
        }

        public uint ReadUInt(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            return Convert.ToUInt32(bitValue, 2);
        }

        public uint? ReadNullableUInt(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            if (string.IsNullOrWhiteSpace(bitValue))
                return null;

            return Convert.ToUInt32(bitValue, 2);
        }

        public uint? ReadMmsi(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            if (string.IsNullOrWhiteSpace(bitValue))
                return null;

            var value = Convert.ToUInt32(bitValue, 2);
            if (value == 0)
                return null;
            return value;
        }

        public int ReadInt(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            var result = Convert.ToInt32(bitValue.Substring(1), 2);
            if (bitValue.StartsWith("1"))
                result = (int) (result - Math.Pow(2, bitValue.Length - 1));

            return result;
        }

        public double ReadUnsignedDouble(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            return Convert.ToUInt32(bitValue, 2);
        }

        public double ReadDouble(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            var result = (double) Convert.ToInt64(bitValue, 2);

            if (bitValue.StartsWith("1"))
                result = result - Math.Pow(2, bitValue.Length);

            return result;
        }

        public int? ReadRateOfTurn(int startIndex, int length)
        {
            var rateOfTurn = ReadInt(startIndex, length);
            return rateOfTurn == -128 ? null : new int?(rateOfTurn);
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

        public string ReadString(int startIndex, int length)
        {
            var data = Substring(startIndex, length);

            var value = string.Empty;
            for (var i = 0; i < data.Length / 6; i++)
            {
                var b = Convert.ToByte(data.Substring(i * 6, 6), 2);

                if (b < 32) //convert to 6-bit ASCII - control chars to uppercase latins
                    b = (byte)(b + 64);

                if (b != 64)
                    value = value + (char)b;
            }

            return value.Trim();
        }

        public double ReadDraught(int startIndex, int length)
        {
            return ReadUnsignedDouble(startIndex, length) / 10;
        }

        public bool ReadDataTerminalReady(int startIndex, int length)
        {
            var value = ReadUInt(startIndex, length);
            return value == 0;
        }

        public bool ReadBoolean(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            return Convert.ToInt32(bitValue) == 1;
        }

        private string Substring(int startIndex, int length)
        {
            if (startIndex > RawValue.Length)
                return "0";

            return startIndex + length > RawValue.Length
                ? RawValue.Substring(startIndex)
                : RawValue.Substring(startIndex, length);
        }
    }
}