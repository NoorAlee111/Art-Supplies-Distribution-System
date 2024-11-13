using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColourFusion.BL;
using ColourFusion.DL;

namespace ColorFusion
{
    public partial class AddRider : Form
    {
        public AddRider()
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
            txtFuelID.Text = "";
            txtVehicle.Text = "";
            txtColor.Text = "";
            txtPlate.Text = "";
        }

        private void cmdAddEmployee_Click(object sender, EventArgs e)
        {
            string UserId = txtUserId.Text;
            string UserPassword = txtPassword.Text;
            string EmailAddress = txtEmail.Text;
            string ContactNo = txtContact.Text;
            string Name = txtName.Text;
            string Cnic = txtCnic.Text;
            string Vehicle = txtVehicle.Text;
            string VehicleColor = txtColor.Text;
            string NumberPlate = txtPlate.Text;
            string Type = "Rider";
            string Id = txtFuelID.Text;
            bool flag = false;

            foreach (Rider r in UserDL.UsersList1)
            {
                if (UserId == r.UserID1)
                {
                    MessageBox.Show("This UserID Already Exists");
                    flag = true;
                }
            }

            if (flag == false)
            {
                if (txtCnic.BackColor == Color.Green)
                {
                    if (txtContact.BackColor == Color.Green)
                    {
                        Rider r = new Rider(UserId, UserPassword, Name, EmailAddress, ContactNo, Cnic, Type, Vehicle, VehicleColor, NumberPlate, Id);
                        UserDL.UsersList1.AddLast(r);
                        UserDL.RidersList1.Add(r);
                        UserDL.WriteRiderInFile();
                        MessageBox.Show("Rider Added Successfully");
                    }
                    else if (txtContact.BackColor == Color.Red)
                    {
                        MessageBox.Show("Invalid Ph no...");
                    }

                }
                else if (txtCnic.BackColor == Color.Red)
                {
                    MessageBox.Show("Invalid Cnic no...");
                }
                ClearDataFromForm();
            }
        } 
        private void AddRider_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        

        private void txtCnic_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{11}$");
            if (r.IsMatch(txtContact.Text))
            {
                txtContact.BackColor = Color.Green;
            }
            else
            {
                txtContact.BackColor = Color.Red;
            }
        }

        private void txtContact_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtUserId_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCnic_TextChanged_1(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{13}$");
            if (r.IsMatch(txtCnic.Text))
            {
                txtCnic.BackColor = Color.Green;
            }
            else
            {
                txtCnic.BackColor = Color.Red;
            }
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtVehicle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtPlate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtFuelID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
