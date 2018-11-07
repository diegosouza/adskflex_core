using ADSKFlexCore;
using Xunit;

namespace ADSKFlexCoreTests
{
    public class TimeoutAllOptionTest
    {
        [Fact]
        public void TestConstructorWithoutTimeout()
        {
            var line = "TIMEOUTALL";

            Assert.Throws<InvalidAutoCadOption>(
                () => new TimeoutAllOption(line)
            );
        }

        [Fact]
        public void TestConstructorWithNoNumericTimeout()
        {
            var line = "TIMEOUTALL ABC";

            Assert.Throws<InvalidAutoCadOption>(
                () => new TimeoutAllOption(line)
            );
        }

        [Fact]
        public void TestToString()
        {
            var line = "TIMEOUTALL 1800";
            var actual = new TimeoutAllOption(line);

            Assert.Equal(line, actual.ToString());
        }
    }
}
