using System;
using System.Linq;
using System.Collections.Generic;

namespace ADSKFlexCore
{
    public static class AutoCadFile
    {
        public static string[] GetLines(string fileContent)
        {
            return fileContent.Split(System.Environment.NewLine,
                                    StringSplitOptions.RemoveEmptyEntries
            );            
        }

        public static List<AutoCadOption> GetOptions(string[] fileLines) => 
            fileLines.Select(fileLine => GetOption(fileLine)).ToList();
        
        public static AutoCadOption GetOption(string fileLine) => 
            AutoCadOptionFactory.Create(fileLine);
    }
}

