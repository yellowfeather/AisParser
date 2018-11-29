namespace AisParser.Messages
{
    public class PositionReportClassAAssignedScheduleMessage : PositionReportClassAMessageBase
    {
        public PositionReportClassAAssignedScheduleMessage()
            : base(AisMessageType.PositionReportClassAAssignedSchedule)
        {
        }

        public static PositionReportClassAAssignedScheduleMessage Create(Payload payload)
        {
            return Create<PositionReportClassAAssignedScheduleMessage>(payload);
        }
    }
}