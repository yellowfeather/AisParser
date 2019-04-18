using AisParser;
using AisParser.Messages;
using JsonSubTypes;
using Newtonsoft.Json;

namespace AisParserTests
{
    public static class AisMessageJsonConvert
    {
        private const uint StaticDataReportPartAMessageType = 1000;
        private const uint StaticDataReportPartBMessageType = 1001;

        public static string Serialize(AisMessage aisMessage)
        {
            return JsonConvert.SerializeObject(aisMessage, Settings);
        }

        public static AisMessage Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<AisMessage>(json, Settings);
        }

        private static JsonSerializerSettings Settings
        {
            get
            {
                var settings = new JsonSerializerSettings();

                settings.Converters.Add(JsonSubtypesConverterBuilder
                    .Of(typeof(AisMessage), "JsonMessageType")
                    .RegisterSubtype(typeof(PositionReportClassAMessage), (uint)AisMessageType.PositionReportClassA)
                    .RegisterSubtype(typeof(PositionReportClassAAssignedScheduleMessage), (uint)AisMessageType.PositionReportClassAAssignedSchedule)
                    .RegisterSubtype(typeof(PositionReportClassAResponseToInterrogationMessage), (uint)AisMessageType.PositionReportClassAResponseToInterrogation)
                    .RegisterSubtype(typeof(BaseStationReportMessage), (uint)AisMessageType.BaseStationReport)
                    .RegisterSubtype(typeof(StaticAndVoyageRelatedDataMessage), (uint)AisMessageType.StaticAndVoyageRelatedData)
                    .RegisterSubtype(typeof(StandardClassBCsPositionReportMessage), (uint)AisMessageType.StandardClassBCsPositionReport)
                    //.RegisterSubtype(typeof(ExtendedClassBEquipmentPositionReportMessage), (uint)AisMessageType.ExtendedClassBEquipmentPositionReport)
                    .RegisterSubtype(typeof(DataLinkManagementMessage), (uint)AisMessageType.DataLinkManagement)
                    .RegisterSubtype(typeof(AidToNavigationReportMessage), (uint)AisMessageType.AidToNavigationReport)
                    .RegisterSubtype(typeof(StaticDataReportPartAMessage), StaticDataReportPartAMessageType)
                    .RegisterSubtype(typeof(StaticDataReportPartBMessage), StaticDataReportPartBMessageType)
                    .SerializeDiscriminatorProperty()
                    .Build());

                return settings;
            }
        }
    }
}
