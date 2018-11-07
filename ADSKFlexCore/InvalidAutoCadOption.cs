using System;

namespace ADSKFlexCore
{
    public class InvalidAutoCadOption : Exception
    {
        public InvalidAutoCadOption(string message, Exception innerException) : base(message, innerException) {}
        public InvalidAutoCadOption(string message) : base(message) {}
    }
}

