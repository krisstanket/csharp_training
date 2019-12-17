using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager appManager;

        [SetUp]
        public void SetupTest()
        {
            appManager = new ApplicationManager();
            appManager.Navigator.OpenHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.Stop();
        }
    }
}
