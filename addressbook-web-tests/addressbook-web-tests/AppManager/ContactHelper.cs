using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        private string baseURL;
        public ContactHelper (ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }
        
        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData contact)
        {
            CheckContactNumber();
            SelectContact(v);
            InitContactModification(GetContactIdByIndex(v));
            FillContactForm(contact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            CheckContactNumber();
            SelectContact(p);
            ClickRemoveContactButton();
            SubmitContactRemovalAlert();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public void ReturnToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.FindElement(By.LinkText("home page")).Click();
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();
            return this;
        }

        public int GetContactIdByIndex(int index)
        {
            var contact = driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]"));
            var idContact = contact.GetAttribute("id");
            return Convert.ToInt32(idContact);
        }

        public ContactHelper ClickRemoveContactButton()
        {
            driver.FindElement(By.CssSelector("input[onclick=\"DeleteSel()\"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactRemovalAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper InitContactModification(int id)
        {
            driver.FindElement(By.CssSelector($"a[href=\"edit.php?id={id}\"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public int GetContactsNumber()
        {
            var contactsNumber = driver.FindElement(By.Id("search_count"));
            return Convert.ToInt32(contactsNumber.Text);
        }
               
        public void CheckContactNumber()
        {
            if (GetContactsNumber() == 0)
            {
                ContactData contact = new ContactData("name", "lastName");
                Create(contact);
            }
        }
    }
}
