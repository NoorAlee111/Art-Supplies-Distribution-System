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
    public partial class EditRider : Form
    {
        private Rider Previous;

        public EditRider(Rider Previous)
        {
            InitializeComponent();
            this.Previous = Previous;
        }

        private void EditRider_Load(object sender, EventArgs e)
        {
            
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

        private void cmdEdit_Click(object sender, EventArgs e)
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
           
            Rider Updated = new Rider(UserId, UserPassword, Name, EmailAddress, ContactNo, Cnic, Type, Vehicle, VehicleColor, NumberPlate, Id);
            UserDL.EditRider(Previous, Updated);
            UserDL.WriteRiderInFile();
            MessageBox.Show("Rider Edited Successfully");
            
            ClearDataFromForm();
        }
    }
}
