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
    public partial class Area : Form
    {
        public Area()
        {
            InitializeComponent();
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

        private void cmdFuel_Click(object sender, EventArgs e)
        {
            FuelConsumption form = new FuelConsumption();
            form.Show();
            this.Close();
        }

        private void Area_Load(object sender, EventArgs e)
        {

        }
    }
}
