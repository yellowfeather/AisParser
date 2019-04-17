namespace AisParser.Messages
{
    public abstract class StaticDataReportMessage : AisMessage
    {
        public uint PartNumber { get; set; }

        protected StaticDataReportMessage()
            : base(AisMessageType.StaticDataReport)
        {
        }

        protected StaticDataReportMessage(StaticDataReportMessageInfo info)
            : base(AisMessageType.StaticDataReport)
        {
            Repeat = info.Repeat;
            Mmsi = info.Mmsi;
            PartNumber = info.PartNumber;
        }
    }
}