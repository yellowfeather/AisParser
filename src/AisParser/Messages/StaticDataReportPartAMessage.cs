namespace AisParser.Messages
{
    public class StaticDataReportPartAMessage : StaticDataReportMessage
    {
        public string ShipName { get; set; }
        public uint Spare { get; set; }
    }
}