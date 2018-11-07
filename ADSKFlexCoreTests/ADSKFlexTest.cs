using ADSKFlexCore;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace ADSKFlexCoreTests
{
    public class ADSKFlexTest
    {
        [Fact]
        public void TestOptionsAttribute()
        {
            var options = new List<AutoCadOption>(
                new AutoCadOption[] {
                    new TimeoutAllOption("TIMEOUTALL 1800"),
                    new GroupCaseInsensitiveOption("GROUPCASEINSENSITIVE ON"),
                }
            );

            var actual = new ADSKFlex(options);

            Assert.Equal(options, actual.Options);
        }

        [Fact]
        public void TestToString()
        {
            var lineBreak = System.Environment.NewLine;
            var fileContent = $@"TIMEOUTALL 1800{lineBreak}GROUPCASEINSENSITIVE ON{lineBreak}GROUP group1 user1{lineBreak}GROUP group2 user2 user22 user222{lineBreak}RESERVE 2 12345ABC_2018_0F GROUP group2";

            var lines = AutoCadFile.GetLines(fileContent);
            var options = AutoCadFile.GetOptions(lines);

            var actual = new ADSKFlex(options);

            Assert.Equal(fileContent, actual.ToString());
        }
    }
}