namespace AisParser.Messages
{
    public class PositionReportClassAMessage : PositionReportClassAMessageBase
    {
        public PositionReportClassAMessage()
            : base(AisMessageType.PositionReportClassA)
        {
        }

        public static PositionReportClassAMessage Create(Payload payload)
        {
            return Create<PositionReportClassAMessage>(payload);
        }
    }
}