namespace AisParser.Messages
{
    public class StaticDataReportPartAMessage : StaticDataReportMessage
    {
        public string ShipName { get; set; }
        public uint Spare { get; set; }

        public StaticDataReportPartAMessage(StaticDataReportMessageInfo info, Payload payload)
            : base(info)
        {
            ShipName = payload.ReadString(40, 120);
            Spare = payload.ReadUInt(160, 8);
        }
    }
}