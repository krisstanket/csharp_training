using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("newfirstname", "newlastname");
            appManager.Contacts.CheckContactNumber();

            List<ContactData> oldContacts = appManager.Contacts.GetContactsList();
            appManager.Contacts.Modify(0, contact);
            List<ContactData> newContacts = appManager.Contacts.GetContactsList();
            oldContacts[0].FirstName = contact.FirstName;
            oldContacts[0].LastName = contact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
