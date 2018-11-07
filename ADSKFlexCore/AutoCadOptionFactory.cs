using System;

namespace ADSKFlexCore
{
    public static class AutoCadOptionFactory
    {
        public static AutoCadOption Create(string fileLine)
        {
            var name = GetOptionName(fileLine);

            switch (name)
            {
                case AutoCadOption.TIMEOUTALL:
                    return new TimeoutAllOption(fileLine);

                case AutoCadOption.GROUPCASEINSENSITIVE:
                    return new GroupCaseInsensitiveOption(fileLine);

                case AutoCadOption.GROUP:
                    return new GroupOption(fileLine);

                case AutoCadOption.RESERVE:
                    return new ReserveOption(fileLine);

                default: throw new InvalidAutoCadOption(fileLine);
            }
        }

        private static string GetOptionName(string line)
        {
            try
            {
                return line.Split(" ")[0].ToUpper();
            }
            catch (Exception ex)
            {
                throw new InvalidAutoCadOption(line, ex.InnerException);
            }
        }
    }
}

