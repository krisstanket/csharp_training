using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("newgroup");
            newData.Header = null;
            newData.Footer = null;
            appManager.Groups.CheckGroupAmount().
                Modify(1, newData);
        }
    }
}
