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
    public partial class TakeOrder : Form
    {
        public TakeOrder()
        {
            InitializeComponent();
        }

        private void cmdTakeOrder_Click(object sender, EventArgs e)
        {
            BookOrder form = new BookOrder();
            form.Show();
        }

        private void cmdArea_Click(object sender, EventArgs e)
        {
            Area form = new Area();
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

        private void cmdFuel_Click(object sender, EventArgs e)
        {
            FuelConsumption form = new FuelConsumption();
            form.Show();
            this.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TakeOrder_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        public void DataBind()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = AllOrdersDL.AllOrders1;
            guna2DataGridView1.Columns[7].Visible = false;
            guna2DataGridView1.Refresh();
        }
    }
}
