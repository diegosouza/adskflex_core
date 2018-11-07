using System;

namespace ADSKFlexCore
{
    public class ReserveOption : AutoCadOption
    {
        public int NumberOfReserves { get; private set; }
        public string License { get; private set; }
        public string Group { get; private set; }

        public ReserveOption(string line) : base(line)
        {
            try
            {
                NumberOfReserves = Convert.ToInt32(Attributes[1]);
                License = Attributes[2];
                Group = Attributes[4];                
            }
            catch (Exception ex)
            {
                throw new InvalidAutoCadOption(line, ex.InnerException);
            }
        }

        public override string ToString()
        {
            return $"{OptionName()} {NumberOfReserves} {License} GROUP {Group}";
        }        
    }            
}

