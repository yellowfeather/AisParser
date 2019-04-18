using AisParser;
using AisParser.Messages;
using Shouldly;
using Xunit;

namespace AisParserTests.MessagesTests
{
    public class BinaryAddressedMessageTests : MessageTestBase
    {
        [Fact]
        public void Should_parse_message()
        {
            const string sentence = "!AIVDM,1,1,,A,6>h8nIT00000>d`vP000@00,2*53";

            var message = Parser.Parse(sentence) as BinaryAddressedMessage;
            message.ShouldNotBeNull();
            message.MessageType.ShouldBe(AisMessageType.BinaryAddressedMessage);
            message.Repeat.ShouldBe(0u);
            message.Mmsi.ShouldBe(990000742u);
            message.SequenceNumber.ShouldBe(1u);
            message.DestinationMmsi.ShouldBe(0u);
            message.RetransmitFlag.ShouldBeFalse();
            message.DesignatedAreaCode.ShouldBe(235u);
            message.FunctionalId.ShouldBe(10u);
            message.Data.ShouldBe("O(D");
        }
    }
}