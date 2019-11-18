using MessagePack;
namespace AisParser.Messages
{
    [MessagePackObject]
    public class StaticDataReportPartBMessage : StaticDataReportMessage
    {
        [Key(4)]
        public ShipType ShipType { get; set; }
        [Key(5)]
        public string VendorId { get; set; }
        [Key(6)]
        public uint UnitModelCode { get; set; }
        [Key(7)]
        public uint SerialNumber { get; set; }
        [Key(8)]
        public string CallSign { get; set; }
        [Key(9)]
        public uint DimensionToBow { get; set; }
        [Key(10)]
        public uint DimensionToStern { get; set; }
        [Key(11)]
        public uint DimensionToPort { get; set; }
        [Key(12)]
        public uint DimensionToStarboard { get; set; }
        [Key(13)]
        public uint MothershipMmsi { get; set; }
        [Key(14)]
        public uint Spare { get; set; }

        public StaticDataReportPartBMessage()
            : base(1)
        {
        }

        public StaticDataReportPartBMessage(StaticDataReportMessage message, Payload payload)
            : base(message)
        {
            ShipType = payload.ReadEnum<ShipType>(40, 8);
            VendorId = payload.ReadString(48, 18);
            UnitModelCode = payload.ReadUInt(66, 4);
            SerialNumber = payload.ReadUInt(70, 20);
            CallSign = payload.ReadString(90, 42);

            // TODO: handle MMSI auxiliary craft
            //MothershipMmsi = payload.ReadUInt(132, 30);

            DimensionToBow = payload.ReadUInt(132, 9);
            DimensionToStern = payload.ReadUInt(141, 9);
            DimensionToPort = payload.ReadUInt(150, 6);
            DimensionToStarboard = payload.ReadUInt(156, 6);
            Spare = payload.ReadUInt(162, 6);
        }
    }
}