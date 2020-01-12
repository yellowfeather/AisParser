using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class StaticAndVoyageRelatedDataMessage : AisMessage
    {
        [Key(3)]
        public uint AisVersion { get; set; }
        [Key(4)]
        public uint ImoNumber { get; set; }
        [Key(5)]
        public string CallSign { get; set; }
        [Key(6)]
        public string ShipName { get; set; }
        [Key(7)]
        public ShipType ShipType { get; set; }
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
        public uint EtaMonth { get; set; }
        [Key(14)]
        public uint EtaDay { get; set; }
        [Key(15)]
        public uint EtaHour { get; set; }
        [Key(16)]
        public uint EtaMinute { get; set; }
        [Key(17)]
        public double Draught { get; set; }
        [Key(18)]
        public string Destination { get; set; }
        [Key(19)]
        public bool DataTerminalReady { get; set; }
        [Key(20)]
        public uint Spare { get; set; }

        public StaticAndVoyageRelatedDataMessage()
            : base(AisMessageType.StaticAndVoyageRelatedData)
        {
        }

        public StaticAndVoyageRelatedDataMessage(Payload payload)
            : base(AisMessageType.StaticAndVoyageRelatedData, payload)
        {
            Repeat = payload.ReadUInt(6, 2);
            Mmsi = payload.ReadUInt(8, 30);
            AisVersion = payload.ReadUInt(38, 2);
            ImoNumber = payload.ReadUInt(40, 30);
            CallSign = payload.ReadString(70, 42);
            ShipName = payload.ReadString(112, 120);
            ShipType = payload.ReadEnum<ShipType>(232, 8);
            DimensionToBow = payload.ReadUInt(240, 9);
            DimensionToStern = payload.ReadUInt(249, 9);
            DimensionToPort = payload.ReadUInt(258, 6);
            DimensionToStarboard = payload.ReadUInt(264, 6);
            PositionFixType = payload.ReadEnum<PositionFixType>(270, 4);
            EtaMonth = payload.ReadUInt(274, 4);
            EtaDay = payload.ReadUInt(278, 5);
            EtaHour = payload.ReadUInt(283, 5);
            EtaMinute = payload.ReadUInt(288, 6);
            Draught = payload.ReadDraught(294, 8);
            Destination = payload.ReadString(302, 120);
            DataTerminalReady = payload.ReadDataTerminalReady(422, 1);
            Spare = payload.ReadUInt(423, 1);
        }
    }
}
