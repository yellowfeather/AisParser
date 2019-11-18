using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class StandardSarAircraftPositionReportMessage : AisMessage
    {
        [Key(3)]
        public uint Altitude { get; set; }
        [Key(4)]
        public uint SpeedOverGround { get; set; }
        [Key(5)]
        public PositionAccuracy PositionAccuracy { get; set; }
        [Key(6)]
        public double Longitude { get; set; }
        [Key(7)]
        public double Latitude { get; set; }
        [Key(8)]
        public double CourseOverGround { get; set; }
        [Key(9)]
        public uint Timestamp { get; set; }
        [Key(10)]
        public uint Reserved { get; set; }
        [Key(11)]
        public bool DataTerminalReady { get; set; }
        [Key(12)]
        public uint Spare { get; set; }
        [Key(13)]
        public bool Assigned { get; set; }
        [Key(14)]
        public Raim Raim { get; set; }
        [Key(15)]
        public uint RadioStatus { get; set; }

        public StandardSarAircraftPositionReportMessage()
            : base(AisMessageType.StandardSarAircraftPositionReport)
        {
        }

        public StandardSarAircraftPositionReportMessage(Payload payload)
            : base(AisMessageType.StandardSarAircraftPositionReport, payload)
        {
            Altitude = payload.ReadUInt(38, 12);
            SpeedOverGround = payload.ReadUInt(50, 10);
            PositionAccuracy = payload.ReadEnum<PositionAccuracy>(60, 1);
            Longitude = payload.ReadLongitude(61, 28);
            Latitude = payload.ReadLatitude(89, 27);
            CourseOverGround = payload.ReadCourseOverGround(116, 12);
            Timestamp = payload.ReadUInt(128, 6);
            Reserved = payload.ReadUInt(134, 8);
            DataTerminalReady = payload.ReadDataTerminalReady(142, 1);
            Spare = payload.ReadUInt(143, 3);
            Assigned = payload.ReadBoolean(146, 1);
            Raim = payload.ReadEnum<Raim>(147, 1);
            RadioStatus = payload.ReadUInt(148, 20);
        }
    }
}