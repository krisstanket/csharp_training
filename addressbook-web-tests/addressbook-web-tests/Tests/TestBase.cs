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
        public void SetupApplicationManager()
        {
            appManager = ApplicationManager.GetInstance();
            appManager.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
