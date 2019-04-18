namespace AisParser.Messages
{
    public class PositionReportForLongRangeApplicationsMessage : AisMessage
    {
        public PositionAccuracy PositionAccuracy { get; set; }
        public Raim Raim { get; set; }
        public NavigationStatus NavigationStatus { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double SpeedOverGround { get; set; }
        public double CourseOverGround { get; set; }
        public GnssPositionStatus GnssPositionStatus { get; set; }
        public uint Spare { get; set; }

        public PositionReportForLongRangeApplicationsMessage()
            : base(AisMessageType.PositionReportForLongRangeApplications)
        {
        }

        public PositionReportForLongRangeApplicationsMessage(Payload payload)
            : base(AisMessageType.PositionReportForLongRangeApplications, payload)
        {
            PositionAccuracy = payload.ReadEnum<PositionAccuracy>(38, 1);
            Raim = payload.ReadEnum<Raim>(39, 1);
            NavigationStatus = payload.ReadEnum<NavigationStatus>(40, 4);
            Longitude = payload.ReadDouble(44, 18) / 600;
            Latitude = payload.ReadDouble(62, 17) / 600;
            SpeedOverGround = payload.ReadUInt(79, 6);
            CourseOverGround = payload.ReadUInt(85, 9);
            GnssPositionStatus = payload.ReadEnum<GnssPositionStatus>(94, 1);
            Spare = payload.ReadUInt(95, 1);
        }
    }
}