using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class ExtendedClassBCsPositionReportMessage : AisMessage
    {
        [Key(3)]
        public uint Reserved { get; set; }
        [Key(4)]
        public double SpeedOverGround { get; set; }
        [Key(5)]
        public PositionAccuracy PositionAccuracy { get; set; }
        [Key(6)]
        public double Longitude { get; set; }
        [Key(7)]
        public double Latitude { get; set; }
        [Key(8)]
        public double CourseOverGround { get; set; }
        [Key(9)]
        public uint? TrueHeading { get; set; }
        [Key(10)]
        public uint Timestamp { get; set; }
        [Key(11)]
        public uint RegionalReserved { get; set; }
        [Key(12)]
        public string Name { get; set; }
        [Key(13)]
        public ShipType ShipType { get; set; }
        [Key(14)]
        public uint DimensionToBow { get; set; }
        [Key(15)]
        public uint DimensionToStern { get; set; }
        [Key(16)]
        public uint DimensionToPort { get; set; }
        [Key(17)]
        public uint DimensionToStarboard { get; set; }
        [Key(18)]
        public PositionFixType PositionFixType { get; set; }
        [Key(19)]
        public Raim Raim { get; set; }
        [Key(20)]
        public bool DataTerminalReady { get; set; }
        [Key(21)]
        public bool Assigned { get; set; }
        [Key(22)]
        public uint Spare { get; set; }

        public ExtendedClassBCsPositionReportMessage()
            : base(AisMessageType.ExtendedClassBCsPositionReport)
        {
        }

        public ExtendedClassBCsPositionReportMessage(Payload payload)
            : base(AisMessageType.ExtendedClassBCsPositionReport, payload)
        {
            Reserved = payload.ReadUInt(38, 8);
            SpeedOverGround = payload.ReadSpeedOverGround(46, 10);
            PositionAccuracy = payload.ReadEnum<PositionAccuracy>(56, 1);
            Longitude = payload.ReadLongitude(57, 28);
            Latitude = payload.ReadLatitude(85, 27);
            CourseOverGround = payload.ReadCourseOverGround(112, 12);
            TrueHeading = payload.ReadTrueHeading(124, 9);
            Timestamp = payload.ReadUInt(133, 6);
            RegionalReserved = payload.ReadUInt(139, 2);
            Name = payload.ReadString(143, 120);
            ShipType = payload.ReadEnum<ShipType>(263, 8);
            DimensionToBow = payload.ReadUInt(271, 9);
            DimensionToStern = payload.ReadUInt(280, 9);
            DimensionToPort = payload.ReadUInt(289, 6);
            DimensionToStarboard = payload.ReadUInt(295, 6);
            PositionFixType = payload.ReadEnum<PositionFixType>(301, 4);
            Raim = payload.ReadEnum<Raim>(305, 1);
            DataTerminalReady = payload.ReadDataTerminalReady(306, 1);
            Assigned = payload.ReadBoolean(307, 1);
            Spare = payload.ReadUInt(308, 4);
        }
    }
}