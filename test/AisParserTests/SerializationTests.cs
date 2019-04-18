using AisParser;
using Shouldly;
using Xunit;

namespace AisParserTests
{
    public class SerializationTests
    {
        [Fact]
        public void Should_serialize_PositionReportClassAMessage()
        {
            const string aisSentence = "!AIVDM,1,1,,B,13GmFd002pwrel@LpMu8L6qn8Vp0,0*56";
            var aisMessage = Serialize(aisSentence);
            aisMessage.MessageType.ShouldBe(AisMessageType.PositionReportClassA);
        }

        [Fact]
        public void Should_serialize_PositionReportClassAAssignedScheduleMessage()
        {
            const string aisSentence = "!AIVDM,1,1,,B,25Mw@DP000qR9bFA:6KI0AV@00S3,0*0A";
            var aisMessage = Serialize(aisSentence);
            aisMessage.MessageType.ShouldBe(AisMessageType.PositionReportClassAAssignedSchedule);
        }

        [Fact]
        public void Should_serialize_PositionReportClassAResponseToInterrogationMessage()
        {
            const string aisSentence = "!AIVDM,1,1,,B,35MC>W@01EIAn5VA4l`N2;>0015@,0*01";
            var aisMessage = Serialize(aisSentence);
            aisMessage.MessageType.ShouldBe(AisMessageType.PositionReportClassAResponseToInterrogation);
        }

        [Fact]
        public void Should_serialize_BaseStationReportMessage()
        {
            const string aisSentence = "!AIVDM,1,1,,A,402MN7iv:HFssOrrk4M4EVw02L1T,0*29";
            var aisMessage = Serialize(aisSentence);
            aisMessage.MessageType.ShouldBe(AisMessageType.BaseStationReport);
        }

        [Fact]
        public void Should_serialize_StaticAndVoyageRelatedDataMessage()
        {
            const string aisSentence1 = "!AIVDM,2,1,1,B,53P<GC`000038D5c>01LThi=E10iV2222222220m1P834v2@044kmE20CD53,0*25";
            const string aisSentence2 = "!AIVDM,2,2,1,B,k`888000000,2*25";
            var parser = new Parser();
            parser.Parse(aisSentence1).ShouldBeNull();
            var aisMessage = parser.Parse(aisSentence2);
            var json = AisMessageJsonConvert.Serialize(aisMessage);
            var deserializedAisMessage = AisMessageJsonConvert.Deserialize(json);

            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.StaticAndVoyageRelatedData);
        }

        [Fact]
        public void Should_serialize_StandardClassBCsPositionReportMessage()
        {
            const string aisSentence = "!AIVDM,1,1,,B,B5NLCa000>fdwc63f?aBKwPUoP06,0*15";
            var aisMessage = Serialize(aisSentence);
            aisMessage.MessageType.ShouldBe(AisMessageType.StandardClassBCsPositionReport);
        }

        [Fact]
        public void Should_serialize_AidToNavigationReportMessage()
        {
            const string aisSentence = "!AIVDM,1,1,,B,ENk`sR9`92ah97PR9h0W1T@1@@@=MTpS<7GFP00003vP000,2*4B";
            var aisMessage = Serialize(aisSentence);
            aisMessage.MessageType.ShouldBe(AisMessageType.AidToNavigationReport);
        }

        [Fact]
        public void Should_serialize_DataLinkManagementMessage()
        {
            const string aisSentence = "!AIVDM,1,1,,B,D03OK@QclNfp00N007pf9H80v9H,2*33";
            var aisMessage = Serialize(aisSentence);
            aisMessage.MessageType.ShouldBe(AisMessageType.DataLinkManagement);
        }

        [Fact]
        public void Should_serialize_StaticDataReportPartAMessage()
        {
            const string aisSentence = "!AIVDM,1,1,,B,H5NLCa0JuJ0U8tr0l4T@Dp00000,2*1C";
            var aisMessage = Serialize(aisSentence);
            aisMessage.MessageType.ShouldBe(AisMessageType.StaticDataReport);
        }

        [Fact]
        public void Should_serialize_StaticDataReportPartBMessage()
        {
            const string aisSentence = "!AIVDM,1,1,,B,H5NLCa4NCD=6mTDG46mnji000000,0*36";
            var aisMessage = Serialize(aisSentence);
            aisMessage.MessageType.ShouldBe(AisMessageType.StaticDataReport);
        }

        private static AisMessage Serialize(string aisSentence)
        {
            var parser = new Parser();
            var aisMessage = parser.Parse(aisSentence);
            var json = AisMessageJsonConvert.Serialize(aisMessage);
            var deserializedAisMessage = AisMessageJsonConvert.Deserialize(json);
            return deserializedAisMessage;
        }
    }
}