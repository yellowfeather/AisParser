namespace AisParser.Messages
{
    public class BaseStationReportMessage : AisMessage
    {
        public uint Repeat { get; set; }
        public uint Mmsi { get; set; }
        public uint Year { get; set; }
        public uint Month { get; set; }
        public uint Day { get; set; }
        public uint Hour { get; set; }
        public uint Minute { get; set; }
        public uint Second { get; set; }
        public PositionAccuracy PositionAccuracy { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public PositionFixType PositionFixType { get; set; }
        public uint Spare { get; set; }
        public Raim Raim { get; set; }
        public uint RadioStatus { get; set; }

        public BaseStationReportMessage()
            : base(AisMessageType.BaseStationReport)
        {
        }

        public static BaseStationReportMessage Create(Payload payload)
        {
            return new BaseStationReportMessage
            {
                Repeat = payload.ReadUInt(6, 2),
                Mmsi = payload.ReadUInt(8, 30),
                Year = payload.ReadUInt(38, 14),
                Month = payload.ReadUInt(52, 4),
                Day = payload.ReadUInt(56, 5),
                Hour = payload.ReadUInt(61, 5),
                Minute = payload.ReadUInt(66, 6),
                Second = payload.ReadUInt(72, 6),
                PositionAccuracy = payload.ReadEnum<PositionAccuracy>(78, 1),
                Longitude = payload.ReadLongitude(79, 28),
                Latitude = payload.ReadLatitude(107, 27),
                PositionFixType = payload.ReadEnum<PositionFixType>(134, 4),
                Spare = payload.ReadUInt(138, 10),
                Raim = payload.ReadEnum<Raim>(148, 1),
                RadioStatus = payload.ReadUInt(149, 19)
            };
        }
    }
}