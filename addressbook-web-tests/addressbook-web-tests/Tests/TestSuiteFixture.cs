using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {

        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager appManager = ApplicationManager.GetInstance();
            appManager.Navigator.OpenHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
