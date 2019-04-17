using AisParser;

namespace AisParserTests.MessagesTests
{
    public abstract class MessageTestBase
    {
        protected readonly Parser Parser;

        protected MessageTestBase()
        {
            Parser = new Parser();
        }
    }
}