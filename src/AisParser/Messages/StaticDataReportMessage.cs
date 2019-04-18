namespace AisParser.Messages
{
    public class StaticDataReportMessage : AisMessage
    {
        public uint PartNumber { get; }

        protected StaticDataReportMessage()
            : base(AisMessageType.StaticDataReport)
        {
        }

        protected StaticDataReportMessage(uint partNumber)
            : base(AisMessageType.StaticDataReport)
        {
            PartNumber = partNumber;
        }

        protected StaticDataReportMessage(StaticDataReportMessage message)
            : this()
        {
            Repeat = message.Repeat;
            Mmsi = message.Mmsi;
            PartNumber = message.PartNumber;
        }

        private StaticDataReportMessage(Payload payload)
            : base(AisMessageType.StaticDataReport, payload)
        {
            PartNumber = payload.ReadUInt(38, 2);
        }

        public static AisMessage Create(Payload payload)
        {
            var message = new StaticDataReportMessage(payload);
            if (message.PartNumber == 0)
                return new StaticDataReportPartAMessage(message, payload);

            return new StaticDataReportPartBMessage(message, payload);
        }
    }
}