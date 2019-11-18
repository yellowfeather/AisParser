using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class StandardClassBCsPositionReportMessage : AisMessage
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
        public bool IsCsUnit { get; set; }
        [Key(13)]
        public bool HasDisplay { get; set; }
        [Key(14)]
        public bool HasDscCapability { get; set; }
        [Key(15)]
        public bool Band { get; set; }
        [Key(16)]
        public bool CanAcceptMessage22 { get; set; }
        [Key(17)]
        public bool Assigned { get; set; }
        [Key(18)]
        public Raim Raim { get; set; }
        [Key(19)]
        public uint RadioStatus { get; set; }

        public StandardClassBCsPositionReportMessage()
            : base(AisMessageType.StandardClassBCsPositionReport)
        {
        }

        public StandardClassBCsPositionReportMessage(Payload payload)
            : base(AisMessageType.StandardClassBCsPositionReport, payload)
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
            IsCsUnit = payload.ReadBoolean(141, 1);
            HasDisplay = payload.ReadBoolean(142, 1);
            HasDscCapability = payload.ReadBoolean(143, 1);
            Band = payload.ReadBoolean(144, 1);
            CanAcceptMessage22 = payload.ReadBoolean(145, 1);
            Assigned = payload.ReadBoolean(146, 1);
            Raim = payload.ReadEnum<Raim>(147, 1);
            RadioStatus = payload.ReadUInt(148, 20);
        }
    }
}