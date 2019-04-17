namespace AisParser.Messages
{
    public class StaticDataReportMessageInfo : AisMessage
    {
        public uint PartNumber { get; }

        public StaticDataReportMessageInfo(Payload payload)
            : base(AisMessageType.StaticDataReport, payload)
        {
            PartNumber = payload.ReadUInt(38, 2);
        }
    }
}