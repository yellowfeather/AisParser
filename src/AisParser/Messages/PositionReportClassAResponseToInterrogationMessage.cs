namespace AisParser.Messages
{
    public class PositionReportClassAResponseToInterrogationMessage : PositionReportClassAMessageBase
    {
        public PositionReportClassAResponseToInterrogationMessage()
            : base(AisMessageType.PositionReportClassAResponseToInterrogation)
        {
        }

        public PositionReportClassAResponseToInterrogationMessage(Payload payload)
            : base(AisMessageType.PositionReportClassAResponseToInterrogation, payload)
        {
        }
    }
}