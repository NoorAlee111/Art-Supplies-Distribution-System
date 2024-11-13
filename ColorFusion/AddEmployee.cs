using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColourFusion.BL;
using ColourFusion.DL;

namespace ColorFusion
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void ClearDataFromForm()
        {
            txtName.Text = "";
            txtPassword.Text = "";
            txtUserId.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtCnic.Text = "";
            //txtType.Text = "";
            txtSShift.Text = "";
            txtEShift.Text = "";
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void cmdAddEmployee_Click(object sender, EventArgs e)
        {
            string UserId = txtUserId.Text;
            string UserPassword = txtPassword.Text;
            string EmailAddress = txtEmail.Text;
            string ContactNo = txtContact.Text;
            string Name = txtName.Text;
            string Cnic = txtCnic.Text;
            int ShiftStart = Convert.ToInt32(txtSShift.Text);
            int EndShift = Convert.ToInt32(txtEShift.Text);
            string Type = "Employee";
            bool flag = false;

            foreach (User u in UserDL.UsersList1)
            {
                if (u.Type1 == "Employee" && UserId == u.UserID1)
                {
                    MessageBox.Show("This UserID Already Exists");
                    flag = true;
                }
            }

            if (flag == false)
            {
                Employee emp = new Employee(UserId, UserPassword, Name, EmailAddress, ContactNo, Cnic, Type, ShiftStart, EndShift);
                UserDL.UsersList1.AddLast(emp);
                UserDL.EmployeesList1.Add(emp);
                UserDL.WriteEmployeeInFile();
                MessageBox.Show("Employee Added Successfully");
            }
            ClearDataFromForm();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
