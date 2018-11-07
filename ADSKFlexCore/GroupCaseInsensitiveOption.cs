using System;

namespace ADSKFlexCore
{
    public class GroupCaseInsensitiveOption : AutoCadOption
    {
        private const string ON = "ON";
        private const string OFF = "OFF";

        public String CaseInsensitive { get; private set; }

        public GroupCaseInsensitiveOption(string line) : base(line)
        {
            try
            {
                var value = Attributes[1];
                CaseInsensitive = (value.Equals(ON) || value.Equals(OFF)) ? value : throw new Exception();
            }
            catch (Exception ex)
            {
                throw new InvalidAutoCadOption(line, ex.InnerException);
            }
        }

        public override string ToString()
        {
            return $"{OptionName()} {CaseInsensitive}";
        }             
    }
}

