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
    public partial class Fuel : Form
    {
        public Fuel()
        {
            InitializeComponent();
        }

        private void cmdArea_Click(object sender, EventArgs e)
        {
            Area form = new Area();
            form.Show();
            this.Close();
        }

        private void cmdTakeOrders_Click(object sender, EventArgs e)
        {
            TakeOrder form = new TakeOrder();
            form.Show();
            this.Close();
        }

        private void cmdOrdersToDeliver_Click(object sender, EventArgs e)
        {
            OrdersToDeliver form = new OrdersToDeliver();
            form.Show();
            this.Close();
        }

        private void cmdDeliveredOrders_Click(object sender, EventArgs e)
        {
            AllDeliveredOrdersOfRider form = new AllDeliveredOrdersOfRider();
            form.Show();
            this.Close();
        }

        private void Fuel_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        private void cmdAddEmployee_Click(object sender, EventArgs e)
        {
            AddFuelInfo form = new AddFuelInfo();
            form.Show();
            this.Close();
        }

        public void dataBind()
        {
            EmployeesGV.AutoGenerateColumns = true;
            Rider R = UserDL.GetCurrentRider("Ali123");
            EmployeesGV.DataSource = R.FuelInfoList1;
        }

        private void EmployeesGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
