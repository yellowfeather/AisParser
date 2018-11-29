using System;

namespace AisParser
{
    public class AisException : Exception
    {
        public AisException(string message)
            : base(message)
        {
        }
    }
}