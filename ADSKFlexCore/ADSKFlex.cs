using System.Collections.Generic;

namespace ADSKFlexCore
{
    public class ADSKFlex
    {
        public List<AutoCadOption> Options = new List<AutoCadOption>();

        public ADSKFlex(List<AutoCadOption> options)
        {
            Options = options;
        }

        public override string ToString()
        {
            var resultado = new System.Text.StringBuilder();
            Options.ForEach(option => resultado.AppendLine(option.ToString()));
            
            return resultado.ToString().TrimEnd();
        }        
    }
}

