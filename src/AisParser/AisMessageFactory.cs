using AisParser.Messages;
using System;

namespace AisParser
{
    public class AisMessageFactory
    {
        public Payload Encode<T>(T message) where T : AisMessage
        {
            Payload payload = new Payload();
            switch (message)
            {
                case PositionReportClassAMessage t1:
                    t1.Encode(payload);
                    break;
                default:
                    return null;
            }
            return payload;
        }

        public AisMessage Create(Payload payload)
        {
            switch (payload.MessageType)
            {
                case 0:
                case AisMessageType.PositionReportClassA:
                    return new PositionReportClassAMessage(payload);
                case AisMessageType.PositionReportClassAAssignedSchedule:
                    return new PositionReportClassAAssignedScheduleMessage(payload);
                case AisMessageType.PositionReportClassAResponseToInterrogation:
                    return new PositionReportClassAResponseToInterrogationMessage(payload);
                case AisMessageType.BaseStationReport:
                    return new BaseStationReportMessage(payload);
                case AisMessageType.StaticAndVoyageRelatedData:
                    return new StaticAndVoyageRelatedDataMessage(payload);
                case AisMessageType.BinaryAddressedMessage:
                    return new BinaryAddressedMessage(payload);
                case AisMessageType.BinaryAcknowledge:
                    return new BinaryAcknowledgeMessage(payload);
                case AisMessageType.BinaryBroadcastMessage:
                    return new BinaryBroadcastMessage(payload);
                case AisMessageType.StandardSarAircraftPositionReport:
                    return new StandardSarAircraftPositionReportMessage(payload);
                case AisMessageType.UtcAndDateInquiry:
                    return new UtcAndDateInquiryMessage(payload);
                case AisMessageType.UtcAndDateResponse:
                    return new UtcAndDateResponseMessage(payload);
                case AisMessageType.AddressedSafetyRelatedMessage:
                    return new AddressedSafetyRelatedMessage(payload);
                case AisMessageType.SafetyRelatedAcknowledgement:
                    return new SafetyRelatedAcknowledgementMessage(payload);
                //case AisMessageType.SafetyRelatedBroadcastMessage:
                case AisMessageType.Interrogation:
                    return new InterrogationMessage(payload);
                //case AisMessageType.AssignmentModeCommand:
                //case AisMessageType.DgnssBinaryBroadcastMessage:
                case AisMessageType.StandardClassBCsPositionReport:
                    return new StandardClassBCsPositionReportMessage(payload);
                case AisMessageType.ExtendedClassBCsPositionReport:
                    return new ExtendedClassBCsPositionReportMessage(payload);
                case AisMessageType.DataLinkManagement:
                    return new DataLinkManagementMessage(payload);
                case AisMessageType.AidToNavigationReport:
                    return new AidToNavigationReportMessage(payload);
                //case AisMessageType.ChannelManagement:
                //case AisMessageType.GroupAssignmentCommand:
                case AisMessageType.StaticDataReport:
                    return StaticDataReportMessage.Create(payload);
                //case AisMessageType.SingleSlotBinaryMessage:
                //case AisMessageType.MultipleSlotBinaryMessageWithCommunicationsState:
                case AisMessageType.PositionReportForLongRangeApplications:
                    return new PositionReportForLongRangeApplicationsMessage(payload);
                //TODO: 30
                //TODO: 31
                //TODO: 32
                //TODO: 40
                //TODO: 47
                //TODO: 51
                //TODO: 57
                default:
                    return null;
                //    throw new AisMessageException($"Unrecognised message type: {payload.MessageType}");
            }
        }
    }
}