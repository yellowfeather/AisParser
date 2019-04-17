namespace AisParser.Messages
{
    public class StaticAndVoyageRelatedDataMessage : AisMessage
    {
        public uint AisVersion { get; set; }
        public uint ImoNumber { get; set; }
        public string CallSign { get; set; }
        public string ShipName { get; set; }
        public ShipType ShipType { get; set; }
        public uint DimensionToBow { get; set; }
        public uint DimensionToStern { get; set; }
        public uint DimensionToPort { get; set; }
        public uint DimensionToStarboard { get; set; }
        public PositionFixType PositionFixType { get; set; }
        public uint EtaMonth { get; set; }
        public uint EtaDay { get; set; }
        public uint EtaHour { get; set; }
        public uint EtaMinute { get; set; }
        public double Draught { get; set; }
        public string Destination { get; set; }
        public bool DataTerminalReady { get; set; }
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
