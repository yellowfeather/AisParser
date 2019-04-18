namespace AisParser
{
    public enum AisMessageType
    {
        PositionReportClassA = 1,
        PositionReportClassAAssignedSchedule = 2,
        PositionReportClassAResponseToInterrogation = 3,
        BaseStationReport = 4,
        StaticAndVoyageRelatedData = 5,
        BinaryAddressedMessage = 6,
        BinaryAcknowledge = 7,
        BinaryBroadcastMessage = 8,
        StandardSarAircraftPositionReport = 9,
        UtcAndDateInquiry = 10,
        UtcAndDateResponse = 11,
        AddressedSafetyRelatedMessage = 12,
        SafetyRelatedAcknowledgement = 13,
        SafetyRelatedBroadcastMessage = 14,
        Interrogation = 15,
        AssignmentModeCommand = 16,
        DgnssBinaryBroadcastMessage = 17,
        StandardClassBCsPositionReport = 18,
        ExtendedClassBCsPositionReport = 19,
        DataLinkManagement = 20,
        AidToNavigationReport = 21,
        ChannelManagement = 22,
        GroupAssignmentCommand = 23,
        StaticDataReport = 24,
        SingleSlotBinaryMessage = 25,
        MultipleSlotBinaryMessageWithCommunicationsState = 26,
        PositionReportForLongRangeApplications = 27
    }
}