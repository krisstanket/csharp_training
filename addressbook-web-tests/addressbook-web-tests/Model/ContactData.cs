using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allContactData;

        public ContactData()
        {

        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + FirstName + " lastName=" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return LastName.CompareTo(other.LastName);
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }

            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (AddNextString(Email) 
                        + AddNextString(Email2) 
                        + AddNextString(Email3))
                        .Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllContactData
        {
            get
            {
                if (allContactData != null)
                {
                    return allContactData;
                }
                else
                {
                    return $@"{FirstName} {LastName}
{Address}

{PropertyHomePhone(HomePhone)}
{PropertyMobilePhone(MobilePhone)}
{PropertyWorkPhone(WorkPhone)}
{PropertyEmail(Email)}
{PropertyEmail(Email2)}
{PropertyEmail(Email3)}";
                }
            }
            set
            {
                allContactData = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";    

        }

        private string AddNextString(string property)
        {
            if (property == null || property == "")
            {
                return "";
            }
            return property + "\r\n";
        }

        private string PropertyHomePhone(string phone)
        {
            if (phone == null || phone == "")
                {
                    return "";
                }
            return "H: " + phone;
        }

        private string PropertyMobilePhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "M: " + phone;
        }

        private string PropertyWorkPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "W: " + phone;
        }

        private string PropertyEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email;
        }
    }
}
