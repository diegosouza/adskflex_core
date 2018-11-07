using ADSKFlexCore;
using Xunit;

namespace ADSKFlexCoreTests
{
    public class GroupCaseInsensitiveOptionTest
    {
        [Fact]
        public void TestConstructorWithOnAttribute()
        {
            var line = "GROUPCASEINSENSITIVE ON";
            var actual = new GroupCaseInsensitiveOption(line);

            Assert.IsType<GroupCaseInsensitiveOption>(actual);
            Assert.Equal("ON", actual.CaseInsensitive);
        }

        [Fact]
        public void TestConstructorWithOffAttribute()
        {
            var line = "GROUPCASEINSENSITIVE OFF";
            var actual = new GroupCaseInsensitiveOption(line);

            Assert.IsType<GroupCaseInsensitiveOption>(actual);
            Assert.Equal("OFF", actual.CaseInsensitive);
        }

        [Fact]
        public void TestConstructorWithInvalidAttribute()
        {
            var line = "GROUPCASEINSENSITIVE THIS_IS_SHOULD_BE_ON_OR_OFF";

            Assert.Throws<InvalidAutoCadOption>(
                () => new GroupCaseInsensitiveOption(line)
            );
        }

         [Fact]
        public void TestConstructorWithoutAttribute()
        {
            var line = "GROUPCASEINSENSITIVE";

            Assert.Throws<InvalidAutoCadOption>(
                () => new GroupCaseInsensitiveOption(line)
            );
        }

        [Fact]       
        public void TestToString()
        {
            var line = "GROUPCASEINSENSITIVE ON";
            var actual = new GroupCaseInsensitiveOption(line);

            Assert.Equal(line, actual.ToString());
        }
    }
}
