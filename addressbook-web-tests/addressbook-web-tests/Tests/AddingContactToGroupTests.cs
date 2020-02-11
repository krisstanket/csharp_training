using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            appManager.Groups.CheckGroupAmount();
            appManager.Contacts.CheckContactNumber();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Equals(ContactData.GetAll()))
            {
                var newContact = new ContactData("name", "lastname");
                appManager.Contacts.Create(newContact);
                oldList.Add(newContact);
            }
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            appManager.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
