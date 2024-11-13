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
    public partial class RiderAccount : Form
    {
        public RiderAccount()
        {
            InitializeComponent();
        }

        private void cmdLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RiderAccount_Load(object sender, EventArgs e)
        {
            lblUsername.Text = Login.CurrentUser.UserID1;
            lblEmail.Text = Login.CurrentUser.EmailAddress1;
            lblEmployeeName.Text = Login.CurrentUser.Name1;
            lblSShift.Text = Login.CurrentUser.ContactNo1;
        }

        private void cmdArea_Click(object sender, EventArgs e)
        {
            Area form = new Area();
            form.Show();
        }

        private void cmdTakeOrders_Click(object sender, EventArgs e)
        {
            TakeOrder form = new TakeOrder();
            form.Show();
        }

        private void cmdOrdersToDeliver_Click(object sender, EventArgs e)
        {
            OrdersToDeliver form = new OrdersToDeliver();
            form.Show();
        }

        private void cmdDeliveredOrders_Click(object sender, EventArgs e)
        {
            AllDeliveredOrdersOfRider form = new AllDeliveredOrdersOfRider();
            form.Show();
        }

        private void cmdFuel_Click(object sender, EventArgs e)
        {
            Fuel form = new Fuel();
            form.Show();
        }
    }
}
