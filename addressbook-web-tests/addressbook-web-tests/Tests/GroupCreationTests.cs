using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.CreateGroup(group);

            Assert.AreEqual(oldGroups.Count + 1, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            appManager.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.CreateGroup(group);

            Assert.AreEqual(oldGroups.Count + 1, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            appManager.Auth.Logout();
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.CreateGroup(group);

            Assert.AreEqual(oldGroups.Count + 1, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            appManager.Auth.Logout();
        }
    }
}
