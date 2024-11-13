using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourFusion.BL
{
    public class User
    {
        private string UserID;
        private string UserPassword;
        private string Name;
        private string EmailAddress;
        private string ContactNo;
        private string Cnic;
        private string Type; 
        
        public string UserID1 { get => UserID; set => UserID = value; }
        public string UserPassword1 { get => UserPassword; set => UserPassword = value; }
        public string EmailAddress1 { get => EmailAddress; set => EmailAddress = value; }
        public string ContactNo1 { get => ContactNo; set => ContactNo = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Cnic1 { get => Cnic; set => Cnic = value; }
        public string Type1 { get => Type; set => Type = value; }

        public User(string UserID, string UserPassword, string Name, string EmailAddress, string ContactNo, string Cnic, string Type)
        {
            this.Cnic = Cnic;
            this.EmailAddress = EmailAddress;
            this.ContactNo = ContactNo;
            this.Name = Name;
            this.UserPassword = UserPassword;
            this.UserID = UserID;
            this.Type = Type;
        }
        public User(string UserID, string UserPassword)
        {
            this.UserPassword = UserPassword;
            this.UserID = UserID;
        }
        public int CheckRole()
        {
            if (this.Type1 == "Manager")
            {
                return 1;
            }
            else if (this.Type1 == "Employee")
            {
                return 2;
            }
            else if (this.Type1 == "Rider")
            {
                return 3;
            }
            return 0;
        }

    }
}
