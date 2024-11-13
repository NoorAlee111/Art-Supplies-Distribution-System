using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourFusion.BL
{
    public class Manager : User
    {
        private string Position;

        public string Position1 { get => Position; set => Position = value; }

        public Manager(string UserID, string UserPassword, string Name, string EmailAddress, string ContactNo, string Cnic, string Type, string Position1) : base(UserID, UserPassword, Name, EmailAddress, ContactNo, Cnic, Type)
        {
            this.Position1 = Position1;
        }
    }
}
