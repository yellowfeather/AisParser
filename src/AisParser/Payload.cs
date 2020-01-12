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

        public string RawValue; // { get; }

        public AisMessageType MessageType; // { get; }

        public T ReadEnum<T>(int startIndex, int length) where T : Enum
        {
            var bitValue = Substring(startIndex, length);
            var value = Convert.ToUInt32(bitValue, 2);
            return (T) Enum.ToObject(typeof(T), value);
        }

        public void WriteEnum<T>(T var, int length) where T : Enum
        {
            WriteUInt(Convert.ToUInt32(var), length);
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
        public void WriteUInt(uint var, int length)
        {
            RawValue += Convert.ToString(var, 2).PadLeft(length, '0');
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
        public void WriteMmsi(uint var, int length)
        {
            WriteUInt(var,length);
        }
        
        public int ReadInt(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            var result = Convert.ToInt32(bitValue.Substring(1), 2);
            if (bitValue.StartsWith("1"))
                result = (int) (result - Math.Pow(2, bitValue.Length));

            return result;
        }
        public void WriteInt(int var, int length)
        {
            RawValue += Convert.ToString(var, 2).PadLeft(length, '0');
        }

        public double ReadUnsignedDouble(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            return Convert.ToUInt32(bitValue, 2);
        }
        public void WriteUnsignedDouble(double var, int length)
        {
            RawValue += Convert.ToString((UInt32)var, 2).PadLeft(length, '0');
        }

        public double ReadDouble(int startIndex, int length)
        {
            var bitValue = Substring(startIndex, length);
            var result = (double) Convert.ToInt64(bitValue, 2);

            if (bitValue.StartsWith("1"))
                result = result - Math.Pow(2, bitValue.Length);

            return result;
        }
        public void WriteDouble(double var, int length)
        {
            if (var < 0)
                var = var + Math.Pow(2, length);

            RawValue += Convert.ToString((UInt32)var, 2).PadLeft(length, '0');
        }

        public int? ReadRateOfTurn(int startIndex, int length)
        {
            var rateOfTurn = ReadInt(startIndex, length);
            return rateOfTurn == -256 ? null : new int?(rateOfTurn);
        }
        public void WriteRateOfTurn(int var, int length)
        {
            WriteInt(var, length);
        }

        public uint? ReadTrueHeading(int startIndex, int length)
        {
            var trueHeading = ReadUInt(startIndex, length);
            return trueHeading == 511 ? null : new uint?(trueHeading);
        }
        public void WriteTrueHeading(uint var, int length)
        {
            WriteUInt(var, length);
        }
        public double ReadLongitude(int startIndex, int length)
        {
            return ReadDouble(startIndex, length) / 600000;
        }
        public void WriteLongitude(double var, int length)
        {
            WriteDouble(var * 600000, length);
        }

        public double ReadLatitude(int startIndex, int length)
        {
            return ReadDouble(startIndex, length) / 600000;
        }
        public void WriteLatitude(double var, int length)
        {
            WriteDouble(var * 600000, length);
        }

        public double ReadSpeedOverGround(int startIndex, int length)
        {
            return ReadUnsignedDouble(startIndex, length) / 10;
        }
        public void WriteSpeedOverGround(double var, int length)
        {
            WriteUnsignedDouble(var * 10, length);
        }
        public double ReadCourseOverGround(int startIndex, int length)
        {
            return ReadUnsignedDouble(startIndex, length) / 10;
        }
        public void WriteCourseOverGround(double var, int length)
        {
            WriteUnsignedDouble(var * 10, length);
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
        /*public void WriteString(string var, int length)
        {
            RawValue += Convert.ToString(var, 2).PadLeft(length, '0');
        }*/

        public double ReadDraught(int startIndex, int length)
        {
            return ReadUnsignedDouble(startIndex, length) / 10;
        }
        public void WriteDraught(double var, int length)
        {
            WriteUnsignedDouble(var * 10, length);
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
        public void WriteBoolean(bool var, int length)
        {
            RawValue += var.ToString();
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