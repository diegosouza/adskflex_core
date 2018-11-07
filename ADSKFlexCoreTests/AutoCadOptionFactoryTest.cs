using ADSKFlexCore;
using Xunit;


namespace ADSKFlexCoreTests
{
    public class AutoCadOptionFactoryTest
    {
        [Fact]
        public void TestCreateFromEmptyString()
        {
            Assert.Throws<InvalidAutoCadOption>(
                () => AutoCadOptionFactory.Create("")
            );
        }

        [Fact]
        public void TestCreateFromOnlySpacesString()
        {
            Assert.Throws<InvalidAutoCadOption>(
                () => AutoCadOptionFactory.Create("  ")
            );
        }

        [Fact]
        public void TestCreateTimeoutAllOption()
        {
            var line = "TIMEOUTALL 1800";
            var actual = AutoCadOptionFactory.Create(line);

            Assert.IsType<TimeoutAllOption>(actual);
        }

        [Fact]
        public void TestCreateGroupCaseInsensitiveOption()
        {
            var line = "GROUPCASEINSENSITIVE ON";
            var actual = (GroupCaseInsensitiveOption) AutoCadOptionFactory.Create(line);

            Assert.IsType<GroupCaseInsensitiveOption>(actual);
            Assert.Equal("ON", actual.CaseInsensitive);
        }

        [Fact]
        public void TestCreateGroupOption()
        {
            var line = "GROUP group_name user_name";
            var actual = AutoCadOptionFactory.Create(line);

            Assert.IsType<GroupOption>(actual);
        }

        [Fact]
        public void TestCreateReserveOption()
        {
            var line = "RESERVE 1 12345ABC_2018_0F GROUP group_name";
            var actual = AutoCadOptionFactory.Create(line);

            Assert.IsType<ReserveOption>(actual);
        }
    }
}
