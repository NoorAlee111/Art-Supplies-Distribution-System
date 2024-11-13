using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorFusion
{
    public partial class ManagerAccount : Form
    {
        public ManagerAccount()
        {
            InitializeComponent();
        }

        private void ManagerAccount_Load(object sender, EventArgs e)
        {
            lblUsername.Text = Login.CurrentUser.UserID1;
            lblEmail.Text = Login.CurrentUser.EmailAddress1;
            lblManagerName.Text = Login.CurrentUser.Name1;
            lblManagerContact.Text = Login.CurrentUser.ContactNo1;
        }

        private void cmdLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEmployeeInfo_Click(object sender, EventArgs e)
        {
            ViewEmployees form = new ViewEmployees();
            form.Show();
        }

        private void cmdShiftChange_Click(object sender, EventArgs e)
        {
            ShiftChange form = new ShiftChange();
            form.Show();
        }

        private void cmdRidersInfo_Click(object sender, EventArgs e)
        {
            ViewRiders form = new ViewRiders();
            form.Show();
        }

        private void cmdProducts_Click(object sender, EventArgs e)
        {
            /*Products form = new Products();
            form.Show();*/
        }

        private void cmdStorage_Click(object sender, EventArgs e)
        {
            /*Storage form = new Storage();
            form.Show();*/
        }

        private void cmdReorder_Click(object sender, EventArgs e)
        {
           /* Re_order_Requests form = new Re_order_Requests();
            form.Show();*/
        }

        private void cmdRetailersPurchases_Click(object sender, EventArgs e)
        {
            RetailersPurchases form = new RetailersPurchases();
            form.Show();
        }

        private void cmdSoldProducts_Click(object sender, EventArgs e)
        {
            Sales form = new Sales();
            form.Show();
        }

        private void cmdEmployeesPerformance_Click(object sender, EventArgs e)
        {
            EmployeePerformance form = new EmployeePerformance();
            form.Show();
        }

        private void cmdRidersPerformance_Click(object sender, EventArgs e)
        {
            RiderPerformance form = new RiderPerformance();
            form.Show();
        }

        private void cmdFuelReport_Click(object sender, EventArgs e)
        {
            FuelConsumption form = new FuelConsumption();
            form.Show();
        }

        private void cmdSuppliersReport_Click(object sender, EventArgs e)
        {
            SuppliersReport form = new SuppliersReport();
            form.Show();
        }
    }
}
