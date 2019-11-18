using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class UtcAndDateResponseMessage : AisMessage
    {
        [Key(3)]
        public uint Year { get; set; }
        [Key(4)]
        public uint Month { get; set; }
        [Key(5)]
        public uint Day { get; set; }
        [Key(6)]
        public uint Hour { get; set; }
        [Key(7)]
        public uint Minute { get; set; }
        [Key(8)]
        public uint Second { get; set; }
        [Key(9)]
        public PositionAccuracy PositionAccuracy { get; set; }
        [Key(10)]
        public double Longitude { get; set; }
        [Key(11)]
        public double Latitude { get; set; }
        [Key(12)]
        public PositionFixType PositionFixType { get; set; }
        [Key(13)]
        public uint Spare { get; set; }
        [Key(14)]
        public Raim Raim { get; set; }
        [Key(15)]
        public uint RadioStatus { get; set; }

        public UtcAndDateResponseMessage()
            : base(AisMessageType.UtcAndDateResponse)
        {
        }

        public UtcAndDateResponseMessage(Payload payload)
            : base(AisMessageType.UtcAndDateResponse, payload)
        {
            Year = payload.ReadUInt(38, 14);
            Month = payload.ReadUInt(52, 4);
            Day = payload.ReadUInt(56, 5);
            Hour = payload.ReadUInt(61, 5);
            Minute = payload.ReadUInt(66, 6);
            Second = payload.ReadNullableUInt(72, 6) ?? 0;
            PositionAccuracy = payload.ReadEnum<PositionAccuracy>(78, 1);
            Longitude = payload.ReadLongitude(79, 28);
            Latitude = payload.ReadLatitude(107, 27);
            PositionFixType = payload.ReadEnum<PositionFixType>(134, 4);
            Spare = payload.ReadUInt(138, 10);
            Raim = payload.ReadEnum<Raim>(148, 1);
            RadioStatus = payload.ReadUInt(149, 19);
        }
    }
}