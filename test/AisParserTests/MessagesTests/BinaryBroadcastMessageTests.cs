using AisParser;
using AisParser.Messages;
using Shouldly;
using Xunit;

namespace AisParserTests.MessagesTests
{
    public class BinaryBroadcastMessageTests : MessageTestBase
    {
        [Fact]
        public void Should_parse_message()
        {
            const string sentence1 = "!AIVDM,2,1,6,A,83Ksgb12@@0bJvW?NL8I4dOuvga6>QTBjkQg>:sK6A;>?bGuDkDI7q:626ud,0*6D";
            const string sentence2 = "!AIVDM,2,2,6,A,g@0,2*05";

            Parser.Parse(sentence1).ShouldBeNull();
            var message = Parser.Parse(sentence2) as BinaryBroadcastMessage;
            message.ShouldNotBeNull();
            message.MessageType.ShouldBe(AisMessageType.BinaryBroadcastMessage);
            message.Repeat.ShouldBe(0u);
            message.Mmsi.ShouldBe(230617000u);
            message.DesignatedAreaCode.ShouldBe(265u);
            message.FunctionalId.ShouldBe(1u);
            message.Data.ShouldBe("B)+:\\=90!$R1?7:>$X:FQKKNF<8+-,YD,8>)_5SMQ$_$(XH[62=");
        }
    }
}