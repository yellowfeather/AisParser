namespace AisParser.Messages
{
    public class StaticDataReportPartAMessage : StaticDataReportMessage
    {
        public string ShipName { get; set; }
        public uint Spare { get; set; }

        public StaticDataReportPartAMessage()
            : base(0)
        {
        }

        public StaticDataReportPartAMessage(StaticDataReportMessage message, Payload payload)
            : base(message)
        {
            ShipName = payload.ReadString(40, 120);
        }
    }
}