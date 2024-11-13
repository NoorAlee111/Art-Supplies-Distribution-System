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
using ColorFusion.DL;

namespace ColorFusion
{
    public partial class Login : Form
    {
        public static User CurrentUser;

        public Login()
        {
            InitializeComponent();
            if (UserDL.ReadManagersFromFile())
            {
                MessageBox.Show("User Data Loaded Successfully");
            }
            if (UserDL.ReadEmployeesFromFile())
            {
                MessageBox.Show("Employee Data Loaded Successfully");
            }
            if (UserDL.ReadRidersFromFile())
            {
                MessageBox.Show("Riders Data Loaded Successfully");
            }
            if (AllOrdersDL.ReadDataFromFile())
            {
                MessageBox.Show("Orders Data Loaded Successfully");
            }
            if (InventoryDL.ReadDataFromFile())
            {
                MessageBox.Show("Inventory Data Loaded Successfully");
            }
        }

        private void ClearDataFromForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            string UserID = txtUsername.Text;
            string UserPassword = txtPassword.Text;
            User User = new User(UserID, UserPassword);
            User ValidUser = UserDL.CheckUser(User);
            /*if(ValidUser.Type1 == "Manager")
            {
                CurrentUser = UserDL.GetCurrentManager(UserID);
            }
            else if (ValidUser.Type1 == "Employee")
            {
                CurrentUser = UserDL.GetCurrentEmployee(UserID);
            }
            else if (ValidUser.Type1 == "Rider")
            {
                CurrentUser = UserDL.GetCurrentRider(UserID);
            }*/
            CurrentUser = ValidUser;
            //MessageBox.Show(ValidUser.Type1);
            string type = ValidUser.Type1;
            if (ValidUser != null)
            {
                MessageBox.Show("User is Valid");
                if (ValidUser.Type1 == "Manager")
                {
                    ManagerAccount form = new ManagerAccount();
                    form.Show();
                }
                else if (ValidUser.Type1 == "Employee")
                {
                    EmployeeAccount form = new EmployeeAccount();
                    form.Show();
                }
                else if (ValidUser.Type1 == "Rider")
                {
                    RiderAccount form = new RiderAccount();
                    form.Show();
                }
            }
            else
            {
                MessageBox.Show("User is Invalid");

            }
            ClearDataFromForm();
        }
    }
}
