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
    public partial class Re_Order : Form
    {
        public Re_Order()
        {
            InitializeComponent();
        }

        private void cmdAllRiders_Click(object sender, EventArgs e)
        {
            AllRiders form = new AllRiders();
            form.Show();
            this.Close();
        }

        private void cmdAssignedAreas_Click(object sender, EventArgs e)
        {
            AssignedAreas form = new AssignedAreas();
            form.Show();
            this.Close();
        }

        private void cmdAllOrders_Click(object sender, EventArgs e)
        {
            AllOrders form = new AllOrders();
            form.Show();
            this.Close();
        }

        private void cmdAssignOrders_Click(object sender, EventArgs e)
        {
            AssignOrders form = new AssignOrders();
            form.Show();
            this.Close();
        }

        private void cmdAssignRoute_Click(object sender, EventArgs e)
        {
            AssignRoute form = new AssignRoute();
            form.Show();
            this.Close();
        }

        private void cmdDeliveries_Click(object sender, EventArgs e)
        {
            Deliveries form = new Deliveries();
            form.Show();
            this.Close();
        }

        private void cmdProducts_Click(object sender, EventArgs e)
        {
            Products form = new Products();
            form.Show();
            this.Close();
        }

        private void cmdStorage_Click(object sender, EventArgs e)
        {
            Storage form = new Storage();
            form.Show();
            this.Close();
        }
    }
}
