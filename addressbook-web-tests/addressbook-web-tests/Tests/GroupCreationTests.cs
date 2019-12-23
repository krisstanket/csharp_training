using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("testgroup");
            group.Header = "header";
            group.Footer = "footer";

            appManager.Groups.CreateGroup(group);
            appManager.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            appManager.Groups.CreateGroup(group);
            appManager.Auth.Logout();
        }
    }
}
