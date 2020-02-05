using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("newfirstname", "newlastname");
            appManager.Contacts.CheckContactNumber();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContact = oldContacts[0];
            appManager.Contacts.Modify(oldContact, contact);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = contact.FirstName;
            oldContacts[0].LastName = contact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
