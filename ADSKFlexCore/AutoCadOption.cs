using System;
using System.Linq;
using System.Collections.Generic;

namespace ADSKFlexCore
{
    public class AutoCadOption
    {
        protected List<string> Attributes = new List<string>();

        public const string TIMEOUTALL = "TIMEOUTALL";
        public const string GROUPCASEINSENSITIVE = "GROUPCASEINSENSITIVE";
        public const string GROUP = "GROUP";
        public const string RESERVE = "RESERVE";


        public static Func<string, string> GetName;
        public static Func<string, List<string>> GetAttributes;


        static AutoCadOption()
        {
            GetName = line => {
                try
                {
                    return line.Split(" ")[0].ToUpper();
                }
                catch (Exception ex)
                {
                    throw new InvalidAutoCadOption(line, ex.InnerException);
                }
            };

            GetAttributes = line => {         
                try
                {
                    string[] words = line.Split(" ");
                    return words.ToList().Skip(1).Take(words.Length).ToList();
                }
                catch (Exception ex)
                {
                    throw new InvalidAutoCadOption(line, ex.InnerException);
                }
            };
        }

        protected AutoCadOption(string line)
        {
            var lineTokens = line.Split(new[] { " " }, StringSplitOptions.None);
            AddAttributes(lineTokens);
        }

        public void AddAttributes(string[] attributes) => Attributes.AddRange(attributes);

        public string OptionName()
        {
            const string CLASS_SUFFIX = "Option";

            var childClass = this.GetType().Name;

            var className = childClass.Split(
                new[] { CLASS_SUFFIX },
                StringSplitOptions.None
            )[0];

            return className.ToUpper();
        }        
    }
}

