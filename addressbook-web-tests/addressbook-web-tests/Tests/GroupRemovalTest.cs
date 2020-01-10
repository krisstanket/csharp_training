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
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }            
    }
}
