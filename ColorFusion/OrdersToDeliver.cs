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
    public partial class OrdersToDeliver : Form
    {
        public OrdersToDeliver()
        {
            InitializeComponent();
        }

        private void OrdersToDeliver_Load(object sender, EventArgs e)
        {

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

        private void Map1_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        public void DataBind()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = AllOrdersDL.AllOrders1;
            guna2DataGridView1.Refresh();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Shop s = (Shop)guna2DataGridView1.CurrentRow.DataBoundItem;
            if (guna2DataGridView1.Columns["DONE"].Index == e.ColumnIndex)
            {
                AllOrdersDL.SetStatus(s);
                AllOrdersDL.WriteDataInFile();
                DataBind();
            }
        }
    }
}
