using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("testgroup");
            group.Header = "header";
            group.Footer = "footer";
            appManager.Groups
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
            appManager.Auth.Logout();
        } 
    }
}
