using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = appManager.Contacts.GetContactsInformationFromTable(0);
            ContactData fromForm = appManager.Contacts.GetContactsInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestPropertyContactInformation()
        {
            ContactData fromForm = appManager.Contacts.GetContactsInformationFromEditForm(0);
            appManager.Navigator.OpenHomePage();
            appManager.Contacts.OpenContactPropertyPage(
                appManager.Contacts.GetContactIdByIndex(0));
            ContactData fromProperty = appManager.Contacts.GetContactsInformationFromPropertyPage();

            Assert.AreEqual(fromProperty.AllContactData, fromForm.AllContactData);
        }
    }
}
