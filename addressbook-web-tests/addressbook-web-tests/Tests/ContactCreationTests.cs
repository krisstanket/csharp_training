using System;
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

            appManager.Contacts.Create(contact);
            appManager.Auth.Logout();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            appManager.Contacts.Create(contact);
            appManager.Auth.Logout();
        }
    }
}

