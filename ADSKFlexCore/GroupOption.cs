using System;
using System.Linq;
using System.Collections.Generic;

namespace ADSKFlexCore
{
    public class GroupOption : AutoCadOption
    {
        public string GroupName { get; private set; }
        public List<string> Members = new List<string>();

        public GroupOption(string line) : base (line)
        {
            try
            {
                GroupName = Attributes[1];
                Members = Attributes.Skip(2)
                                    .Take(Attributes.Count)
                                    .ToList();                
            }
            catch (Exception ex)
            {
                throw new InvalidAutoCadOption(line, ex.InnerException);
            }
        }

        public override string ToString()
        {
            return $"{OptionName()} {GroupName} {String.Join(' ', Members)}";
        }              
    }
}

