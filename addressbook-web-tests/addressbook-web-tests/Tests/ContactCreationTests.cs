using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("firstname", "lastname");

            List<ContactData> oldContacts = appManager.Contacts.GetContactsList();
            appManager.Contacts.Create(contact);
            List<ContactData> newContacts = appManager.Contacts.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            appManager.Auth.Logout();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = appManager.Contacts.GetContactsList();
            appManager.Contacts.Create(contact);
            List<ContactData> newContacts = appManager.Contacts.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            appManager.Auth.Logout();
        }
    }
}

