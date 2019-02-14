using AisParser.Messages;

namespace AisParser
{
    public class AisMessageFactory
    {
        public AisMessage Create(Payload payload)
        {
            switch (payload.MessageType)
            {
                case AisMessageType.PositionReportClassA:
                    return PositionReportClassAMessage.Create(payload);
                case AisMessageType.PositionReportClassAAssignedSchedule:
                    return PositionReportClassAAssignedScheduleMessage.Create(payload);
                case AisMessageType.PositionReportClassAResponseToInterrogation:
                    return PositionReportClassAResponseToInterrogationMessage.Create(payload);
                case AisMessageType.BaseStationReport:
                    return BaseStationReportMessage.Create(payload);
                case AisMessageType.StaticAndVoyageRelatedData:
                    return StaticAndVoyageRelatedDataMessage.Create(payload);
                //case AisMessageType.BinaryAddressedMessage:
                //case AisMessageType.BinaryAcknowledge:
                //case AisMessageType.BinaryBroadcastMessage:
                //case AisMessageType.StandardSarAircraftPositionReport:
                //case AisMessageType.UtcAndDateInquiry:
                //case AisMessageType.UtcAndDateResponse:
                //case AisMessageType.AddressedSafetyRelatedMessage:
                //case AisMessageType.SafetyRelatedAcknowledgement:
                //case AisMessageType.SafetyRelatedBroadcastMessage:
                //case AisMessageType.Interrogation:
                //case AisMessageType.AssignmentModeCommand:
                //case AisMessageType.DgnssBinaryBroadcastMessage:
                case AisMessageType.StandardClassBCsPositionReport:
                    return StandardClassBCsPositionReportMessage.Create(payload);
                //case AisMessageType.ExtendedClassBEquipmentPositionReport:
                case AisMessageType.DataLinkManagement:
                    return DataLinkManagementMessage.Create(payload);
                case AisMessageType.AidToNavigationReport:
                    return AidToNavigationReportMessage.Create(payload);
                //case AisMessageType.ChannelManagement:
                //case AisMessageType.GroupAssignmentCommand:
                case AisMessageType.StaticDataReport:
                    return StaticDataReportMessage.Create(payload);
                //case AisMessageType.SingleSlotBinaryMessage:
                //case AisMessageType.MultipleSlotBinaryMessageWithCommunicationsState:
                //case AisMessageType.PositionReportForLongRangeApplications:
                default:
                    throw new AisMessageException($"Unrecognised message type: {payload.MessageType}");
            }
        }
    }
}