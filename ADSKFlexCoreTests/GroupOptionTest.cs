using ADSKFlexCore;
using System.Collections.Generic;
using Xunit;

namespace ADSKFlexCoreTests
{
    public class GroupOptionTest
    {
        [Fact]
        public void TestConstructorWithValidAttributes()
        {
            var line = "GROUP group_name user_name1";
            var actual = new GroupOption(line);

            Assert.IsType<GroupOption>(actual);
        }

        [Fact]
        public void TestConstructorWithoutAttributes()
        {
            var line = "GROUP";

            Assert.Throws<InvalidAutoCadOption>(
                () => new GroupOption(line)
            );
        }

        [Fact]
        public void TestGroupNameAttribute()
        {
            var groupName = "group_name";
            var line = $"GROUP {groupName} user_name1";

            var actual = new GroupOption(line);

            Assert.Equal(groupName, actual.GroupName);
        }

        [Fact]
        public void TestMembersAttributeSingle()
        {
            var member = "user_name1";
            var members = new List<string>(new string[] { member });
            var line = $"GROUP group_name {member}";

            var actual = new GroupOption(line);

            Assert.Equal(members, actual.Members);
        }

        [Fact]
        public void TestMembersAttributeMultiple()
        {
            var member1 = "user_name1";
            var member2 = "user_name2";
            var members = $"{member1} {member2}";
            var line = $"GROUP group_name {members}";
            var membersList = new List<string>(new string[] { member1, member2 });

            var actual = new GroupOption(line);

            Assert.Equal(membersList, actual.Members);
        }

        [Fact]
        public void TestToStringSingleMember()
        {
            var line = "GROUP group_name user_name1";
            var actual = new GroupOption(line);

            Assert.Equal(line, actual.ToString());
        }

        [Fact]
        public void TestToStringMultipleMembers()
        {
            var line = "GROUP group_name user_name1 user_name2";
            var actual = new GroupOption(line);

            Assert.Equal(line, actual.ToString());
        }        
    }
}
