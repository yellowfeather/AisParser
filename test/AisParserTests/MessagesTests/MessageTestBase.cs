using AisParser;

namespace AisParserTests.MessagesTests
{
    public class MessageTestBase
    {
        protected readonly Parser Parser;

        public MessageTestBase()
        {
            var decoder = new PayloadDecoder();
            var messageFactory = new AisMessageFactory();
            Parser = new Parser(decoder, messageFactory);
        }
    }
}