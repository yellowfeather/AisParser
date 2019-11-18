using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class PositionReportForLongRangeApplicationsMessage : AisMessage
    {
        [Key(3)]
        public PositionAccuracy PositionAccuracy { get; set; }
        [Key(4)]
        public Raim Raim { get; set; }
        [Key(5)]
        public NavigationStatus NavigationStatus { get; set; }
        [Key(6)]
        public double Longitude { get; set; }
        [Key(7)]
        public double Latitude { get; set; }
        [Key(8)]
        public double SpeedOverGround { get; set; }
        [Key(9)]
        public double CourseOverGround { get; set; }
        [Key(10)]
        public GnssPositionStatus GnssPositionStatus { get; set; }
        [Key(11)]
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