using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //prepare
            appManager.Auth.Logout();
            //action
            AccountData account = new AccountData("admin", "secret");
            appManager.Auth.Login(account);
            //verification
            Assert.IsTrue(appManager.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            //prepare
            appManager.Auth.Logout();
            //action
            AccountData account = new AccountData("admin", "123456");
            appManager.Auth.Login(account);
            //verification
            Assert.IsFalse(appManager.Auth.IsLoggedIn(account));
        }
    }
}
