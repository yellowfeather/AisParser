namespace AisParser
{
    public class AisParserException : AisException
    {
        public string Sentence { get; set; }

        public AisParserException(string message, string sentence)
            : base(message)
        {
            Sentence = sentence;
        }
    }
}