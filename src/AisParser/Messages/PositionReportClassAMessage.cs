namespace AisParser.Messages
{
    public class PositionReportClassAMessage : PositionReportClassAMessageBase
    {
        public PositionReportClassAMessage()
            : base(AisMessageType.PositionReportClassA)
        {
        }

        public PositionReportClassAMessage(Payload payload)
            : base(AisMessageType.PositionReportClassA, payload)
        {
        }
    }
}