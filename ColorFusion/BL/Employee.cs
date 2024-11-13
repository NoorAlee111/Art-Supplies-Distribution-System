using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourFusion.BL
{
    public class Employee : User
    {
        private int StartShift;
        private int EndShift;

        public int EndShift1 { get => EndShift; set => EndShift = value; }
        public int StartShift1 { get => StartShift; set => StartShift = value; }

        public Employee(string UserID, string UserPassword, string Name, string EmailAddress, string ContactNo, string Cnic, string Type, int StartShift1, int EndShift1) : base(UserID, UserPassword, Name, EmailAddress, ContactNo, Cnic, Type)
        {
            this.StartShift1 = StartShift1;
            this.EndShift1 = EndShift1;
        }
    }
}
