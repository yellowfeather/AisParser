namespace AisParser.Messages
{
    public class PositionReportClassAResponseToInterrogationMessage : PositionReportClassAMessageBase
    {
        public PositionReportClassAResponseToInterrogationMessage()
            : base(AisMessageType.PositionReportClassAResponseToInterrogation)
        {
        }

        public static PositionReportClassAResponseToInterrogationMessage Create(Payload payload)
        {
            return Create<PositionReportClassAResponseToInterrogationMessage>(payload);
        }
    }
}