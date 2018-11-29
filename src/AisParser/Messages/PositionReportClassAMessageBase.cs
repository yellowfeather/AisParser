namespace AisParser.Messages
{
    public abstract class PositionReportClassAMessageBase : AisMessage
    {
        public uint Repeat { get; set; }
        public uint Mmsi { get; set; }
        public NavigationStatus NavigationStatus { get; set; }
        public int? RateOfTurn { get; set; }
        public double SpeedOverGround { get; set; }
        public PositionAccuracy PositionAccuracy { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double CourseOverGround { get; set; }
        public uint? TrueHeading { get; set; }
        public uint Timestamp { get; set; }
        public ManeuverIndicator ManeuverIndicator { get; set; }
        public uint Spare { get; set; }
        public Raim Raim { get; set; }
        public uint RadioStatus { get; set; }

        protected PositionReportClassAMessageBase(AisMessageType messageType)
            : base(messageType)
        {
        }

        public static T Create<T>(Payload payload) where T : PositionReportClassAMessageBase, new()
        {
            return new T
            {
                Repeat = payload.ReadUInt(6, 2),
                Mmsi = payload.ReadUInt(8, 30),
                NavigationStatus = payload.ReadEnum<NavigationStatus>(38, 4),
                RateOfTurn = payload.ReadRateOfTurn(42, 8),
                SpeedOverGround = payload.ReadSpeedOverGround(50, 10),
                PositionAccuracy = payload.ReadEnum<PositionAccuracy>(60, 1),
                Longitude = payload.ReadLongitude(61, 28),
                Latitude = payload.ReadLatitude(89, 27),
                CourseOverGround = payload.ReadCourseOverGround(116, 12),
                TrueHeading = payload.ReadTrueHeading(128, 9),
                Timestamp = payload.ReadUInt(137, 6),
                ManeuverIndicator = payload.ReadEnum<ManeuverIndicator>(143, 2),
                Spare = payload.ReadUInt(145, 3),
                Raim = payload.ReadEnum<Raim>(148, 1),
                RadioStatus = payload.ReadUInt(149, 19)
            };
        }
    }
}