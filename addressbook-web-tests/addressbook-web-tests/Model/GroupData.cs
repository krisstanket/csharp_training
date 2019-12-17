using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class GroupData
    {
        private string groupName;
        private string header = "";
        private string footer = "";

        public GroupData (string groupName)
        {
            this.groupName = groupName;
        }

        public string Name
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }
    }
}
