using System;

namespace ADSKFlexCore
{
    public class TimeoutAllOption : AutoCadOption
    {
        public int Timeout { get; private set; }

        public TimeoutAllOption(string line) : base (line)
        {
            try
            {
                Timeout = Convert.ToInt32(Attributes[1]);
            }
            catch (Exception ex)
            {
                throw new InvalidAutoCadOption(line, ex.InnerException);
            }
        }

        public override string ToString()
        {
            return $"{OptionName()} {Timeout}";
        }            
    }
}

