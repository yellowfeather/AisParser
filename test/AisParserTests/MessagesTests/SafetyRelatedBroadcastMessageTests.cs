using AisParser;
using AisParser.Messages;
using Shouldly;
using Xunit;

namespace AisParserTests.MessagesTests
{

    public class SafetyRelatedBroadcastMessageTests : MessageTestBase
    {
        [Fact]
        public void Should_parse_message()
        {
            const string sentence = "!AIVDM,1,1,,A,>>QK2khE0U8:1@E=@0,4*52"; // EPIRB test message

            var message = Parser.Parse(sentence) as SafetyRelatedBroadcastMessage;
            message.ShouldNotBeNull();
            message.MessageType.ShouldBe(AisMessageType.SafetyRelatedBroadcastMessage);
            message.Repeat.ShouldBe(0u);
            message.Mmsi.ShouldBe(974570191u);
            message.Spare.ShouldBe(0u);
            message.SafetyRelatedText.ShouldBe("EPIRB TEST");
        }
    }
}