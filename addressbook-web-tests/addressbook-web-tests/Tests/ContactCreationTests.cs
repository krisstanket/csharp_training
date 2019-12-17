using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            appManager.Contacts
                .InitContactCreation()
                .FillContactForm(new ContactData("firstname", "lastname"))
                .SubmitContactCreation()
                .ReturnToHomePage();
            appManager.Auth.Logout();
        }
    }
}

