using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class AidToNavigationReportMessage : AisMessage
    {
        [Key(3)]
        public NavigationalAidType NavigationalAidType { get; set; }
        [Key(4)]
        public string Name { get; set; }
        [Key(5)]
        public PositionAccuracy PositionAccuracy { get; set; }
        [Key(6)]
        public double Longitude { get; set; }
        [Key(7)]
        public double Latitude { get; set; }
        [Key(8)]
        public uint DimensionToBow { get; set; }
        [Key(9)]
        public uint DimensionToStern { get; set; }
        [Key(10)]
        public uint DimensionToPort { get; set; }
        [Key(11)]
        public uint DimensionToStarboard { get; set; }
        [Key(12)]
        public PositionFixType PositionFixType { get; set; }
        [Key(13)]
        public uint Timestamp { get; set; }
        [Key(14)]
        public bool OffPosition { get; set; }
        [Key(15)]
        public uint RegionalReserved { get; set; }
        [Key(16)]
        public Raim Raim { get; set; }
        [Key(17)]
        public bool VirtualAid { get; set; }
        [Key(18)]
        public bool Assigned { get; set; }
        [Key(19)]
        public uint Spare { get; set; }
        [Key(20)]
        public string NameExtension { get; set; }

        public AidToNavigationReportMessage()
            : base(AisMessageType.AidToNavigationReport)
        {
        }

        public AidToNavigationReportMessage(Payload payload)
            : base(AisMessageType.AidToNavigationReport, payload)
        {
            NavigationalAidType = payload.ReadEnum<NavigationalAidType>(38, 5);
            Name = payload.ReadString(43, 120);
            PositionAccuracy = payload.ReadEnum<PositionAccuracy>(163, 1);
            Longitude = payload.ReadLongitude(164, 28);
            Latitude = payload.ReadLatitude(192, 27);
            DimensionToBow = payload.ReadUInt(219, 9);
            DimensionToStern = payload.ReadUInt(228, 9);
            DimensionToPort = payload.ReadUInt(237, 6);
            DimensionToStarboard = payload.ReadUInt(243, 6);
            PositionFixType = payload.ReadEnum<PositionFixType>(249, 4);
            Timestamp = payload.ReadUInt(253, 6);
            OffPosition = payload.ReadBoolean(259, 1);
            RegionalReserved = payload.ReadUInt(260, 8);
            Raim = payload.ReadEnum<Raim>(268, 1);
            VirtualAid = payload.ReadBoolean(269, 1);
            Assigned = payload.ReadBoolean(270, 1);
            Spare = payload.ReadUInt(271, 1);
            NameExtension = payload.ReadString(272, 88);
        }
    }
}