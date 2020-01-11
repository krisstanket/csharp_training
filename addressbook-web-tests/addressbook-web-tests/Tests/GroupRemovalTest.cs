using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            appManager.Groups.CheckGroupAmount();

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreEqual(group.Id, toBeRemoved.Id);
            }
        }            
    }
}
