using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public abstract class PositionReportClassAMessageBase : AisMessage
    {
        [Key(3)]
        public NavigationStatus NavigationStatus { get; set; }
        [Key(4)]
        public int? RateOfTurn { get; set; }
        [Key(5)]
        public double SpeedOverGround { get; set; }
        [Key(6)]
        public PositionAccuracy PositionAccuracy { get; set; }
        [Key(7)]
        public double Longitude { get; set; }
        [Key(8)]
        public double Latitude { get; set; }
        [Key(9)]
        public double CourseOverGround { get; set; }
        [Key(10)]
        public uint? TrueHeading { get; set; }
        [Key(11)]
        public uint Timestamp { get; set; }
        [Key(12)]
        public ManeuverIndicator ManeuverIndicator { get; set; }
        [Key(13)]
        public uint Spare { get; set; }
        [Key(14)]
        public Raim Raim { get; set; }
        [Key(15)]
        public uint RadioStatus { get; set; }

        protected PositionReportClassAMessageBase(AisMessageType messageType)
            : base(messageType)
        {
        }

        protected PositionReportClassAMessageBase(AisMessageType messageType, Payload payload)
            : base(messageType, payload)
        {
            Repeat = payload.ReadUInt(6, 2);
            Mmsi = payload.ReadUInt(8, 30);
            NavigationStatus = payload.ReadEnum<NavigationStatus>(38, 4);
            RateOfTurn = payload.ReadRateOfTurn(42, 8);
            SpeedOverGround = payload.ReadSpeedOverGround(50, 10);
            PositionAccuracy = payload.ReadEnum<PositionAccuracy>(60, 1);
            Longitude = payload.ReadLongitude(61, 28);
            Latitude = payload.ReadLatitude(89, 27);
            CourseOverGround = payload.ReadCourseOverGround(116, 12);
            TrueHeading = payload.ReadTrueHeading(128, 9);
            Timestamp = payload.ReadUInt(137, 6);
            ManeuverIndicator = payload.ReadEnum<ManeuverIndicator>(143, 2);
            Spare = payload.ReadUInt(145, 3);
            Raim = payload.ReadEnum<Raim>(148, 1);
            RadioStatus = payload.ReadUInt(149, 19);
        }
    }
}