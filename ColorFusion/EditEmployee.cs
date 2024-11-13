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
    public partial class EditEmployee : Form
    {
        private Employee Previous;

        public EditEmployee(Employee Previous)
        {
            InitializeComponent();
            this.Previous = Previous;
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
            txtEShift.Text = "";
            txtSShift.Text = "";
        }

        private void cmdEditEmployee_Click(object sender, EventArgs e)
        {
            string UserId = txtUserId.Text;
            string UserPassword = txtPassword.Text;
            string EmailAddress = txtEmail.Text;
            string ContactNo = txtContact.Text;
            string Name = txtName.Text;
            string Cnic = txtCnic.Text;
            int StartShift = Convert.ToInt32(txtSShift.Text);
            int EndShift = Convert.ToInt32(txtEShift.Text);
            string Type = "Employee";

            Employee Updated = new Employee(UserId, UserPassword, Name, EmailAddress, ContactNo, Cnic, Type, StartShift, EndShift);
            UserDL.EditEmployee(Previous, Updated);
            UserDL.WriteEmployeeInFile();
            MessageBox.Show("Employee Edited Successfully");
            ClearDataFromForm();
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {
            txtUserId.Text = Previous.UserID1;
            txtPassword.Text = Previous.UserPassword1;
            txtEmail.Text = Previous.EmailAddress1;
            txtContact.Text = Previous.ContactNo1;
            txtName.Text = Previous.ContactNo1;
            txtCnic.Text = Previous.Cnic1;
            txtSShift.Text = (Previous.StartShift1).ToString();
            txtEShift.Text = (Previous.EndShift1).ToString();
            //string Type = "Employee";
        }
    }
}
