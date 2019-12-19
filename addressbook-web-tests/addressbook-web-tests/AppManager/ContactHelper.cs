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
        public ContactHelper (ApplicationManager manager) 
            : base(manager)
        {
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
            SelectContact(v);
            InitContactModification(v);
            FillContactForm(contact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
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
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();
            return this;
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

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.CssSelector($"a[href=\"edit.php?id={index}")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
