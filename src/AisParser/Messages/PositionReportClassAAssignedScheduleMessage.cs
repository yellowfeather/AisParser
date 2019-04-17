namespace AisParser.Messages
{
    public class PositionReportClassAAssignedScheduleMessage : PositionReportClassAMessageBase
    {
        public PositionReportClassAAssignedScheduleMessage()
            : base(AisMessageType.PositionReportClassAAssignedSchedule)
        {
        }

        public PositionReportClassAAssignedScheduleMessage(Payload payload)

            : base(AisMessageType.PositionReportClassAAssignedSchedule, payload)
        {
        }
    }
}