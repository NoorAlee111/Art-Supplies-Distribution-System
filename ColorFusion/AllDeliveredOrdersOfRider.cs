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
using ColorFusion.DL;

namespace ColorFusion
{
    public partial class AllDeliveredOrdersOfRider : Form
    {
        public AllDeliveredOrdersOfRider()
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

        private void cmdFuel_Click(object sender, EventArgs e)
        {
            FuelConsumption form = new FuelConsumption();
            form.Show();
            this.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void DataBind()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = AllOrdersDL.DeliveredOrders1;
            guna2DataGridView1.Refresh();
        }

        private void AllDeliveredOrdersOfRider_Load(object sender, EventArgs e)
        {
            DataBind();
        }
    }
}
