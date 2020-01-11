using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("newgroup");
            newData.Header = null;
            newData.Footer = null;

            appManager.Groups.CheckGroupAmount();

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];
            appManager.Groups.Modify(0, newData);
            Assert.AreEqual(oldGroups.Count, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
