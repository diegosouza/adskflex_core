using ADSKFlexCore;
using System.Collections.Generic;
using Xunit;

namespace ADSKFlexCoreTests
{
    public class ReserveOptionTest
    {
        [Fact]
        public void TestConstructorWithValidAttributes()
        {
            var line = "RESERVE 1 12345ABC_2018_0F GROUP group_name";
            var actual = new ReserveOption(line);

            Assert.IsType<ReserveOption>(actual);
        }

        [Fact]
        public void TestConstructorWithoutAttributes()
        {
            var line = "RESERVE";

            Assert.Throws<InvalidAutoCadOption>(
                () => new ReserveOption(line)
            );
        }

        [Fact]
        public void TestNumberOfReservesAttribute()
        {
            var numberOfReserves = 1;
            var line = $"RESERVE {numberOfReserves} 12345ABC_2018_0F GROUP group_name";

            var actual = new ReserveOption(line);

            Assert.Equal(numberOfReserves, actual.NumberOfReserves);
        }

        [Fact]
        public void TestLicenseAttribute()
        {
            var license = "12345ABC_2018_0F";
            var line = $"RESERVE 1 {license} GROUP group_name";

            var actual = new ReserveOption(line);

            Assert.Equal(license, actual.License);
        }

        [Fact]
        public void TestGroupAttribute()
        {
            var group = "group_name";
            var line = $"RESERVE 1 12345ABC_2018_0F GROUP {group}";

            var actual = new ReserveOption(line);

            Assert.Equal(group, actual.Group);
        }

        [Fact]
        public void TestToString()
        {
            var line = "RESERVE 1 12345ABC_2018_0F GROUP group_name";
            var actual = new ReserveOption(line);

            Assert.Equal(line, actual.ToString());
        }
    }
}
