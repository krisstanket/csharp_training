using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class DeletingContactFromGroupTest : AuthTestBase
    {
        [Test]
        public void TestDeletingContactFromGroup()
        {
            appManager.Groups.CheckGroupAmount();
            appManager.Contacts.CheckContactNumber();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count == 0)
            {
                var contactForAdding = ContactData.GetAll()[0];
                appManager.Contacts.AddContactToGroup(contactForAdding, group);
                oldList.Add(contactForAdding);
            }

            ContactData contact = ContactData.GetAll().Intersect(oldList).First();
            appManager.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
