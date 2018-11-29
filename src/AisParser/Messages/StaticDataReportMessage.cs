namespace AisParser.Messages
{
    public abstract class StaticDataReportMessage : AisMessage
    {
        public uint Repeat { get; set; }
        public uint Mmsi { get; set; }
        public uint PartNumber { get; set; }

        protected StaticDataReportMessage()
            : base(AisMessageType.StaticDataReport)
        {
        }

        public static StaticDataReportMessage Create(Payload payload)
        {
            var repeat = payload.ReadUInt(6, 2);
            var mmsi = payload.ReadUInt(8, 30);
            var partNumber = payload.ReadUInt(38, 2);
            if (partNumber == 0)
            {
                return new StaticDataReportPartAMessage
                {
                    Repeat = repeat,
                    Mmsi = mmsi,
                    PartNumber = partNumber,
                    ShipName = payload.ReadString(40, 120),
                    Spare = payload.ReadUInt(160, 8)
                };
            }

            return new StaticDataReportPartBMessage
            {
                Repeat = repeat,
                Mmsi = mmsi,
                PartNumber = partNumber,
                ShipType = payload.ReadEnum<ShipType>(40, 8),
                VendorId = payload.ReadString(48, 18),
                UnitModelCode = payload.ReadUInt(66, 4),
                SerialNumber = payload.ReadUInt(70, 20),
                CallSign = payload.ReadString(90, 42),

                // TODO: handle MMSI auxiliary craft
                //MothershipMmsi = payload.ReadUInt(132, 30),

                DimensionToBow = payload.ReadUInt(132, 9),
                DimensionToStern = payload.ReadUInt(141, 9),
                DimensionToPort = payload.ReadUInt(150, 6),
                DimensionToStarboard = payload.ReadUInt(156, 6),
                Spare = payload.ReadUInt(162, 6)
            };
        }
    }
}