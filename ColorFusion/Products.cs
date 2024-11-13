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
    
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e) 
        {
                 DataBind();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Product p = (Product)ProductsGV.CurrentRow.DataBoundItem;
            if (ProductsGV.Columns["DELETE"].Index == e.ColumnIndex)
            {
                InventoryDL.DeleteProduct(p);
                DeleteProduct(InventoryDL.ProductsList1, p);
                InventoryDL.WriteDatainFile();
                DataBind();
            }
            else if (ProductsGV.Columns["EDIT"].Index == e.ColumnIndex)
            {
                EditProduct myform = new EditProduct(p);
                myform.ShowDialog();

                DataBind();
            }

        }
        void DeleteProduct(List<Product> ProductsList1,Product p)
        {
            foreach(Product pr in ProductsList1)
            {
                if(pr.ProductId1==p.ProductId1)
                {
                    ProductsList1.Remove(pr);
                    break;
                }
            }
        }
        public void DataBind()
        {
            ProductsGV.DataSource = null;
            ProductsGV.DataSource = InventoryDL.ProductsList1;
            ProductsGV.Refresh();
        }

        private void cmdAddProduct_Click(object sender, EventArgs e)
        {
            AddInInventory form = new AddInInventory();
            form.Show();
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

        private void cmdStorage_Click(object sender, EventArgs e)
        {
            Storage form = new Storage();
            form.Show();
            this.Close();
        }

        private void cmdReorder_Click(object sender, EventArgs e)
        {
            Re_Order form = new Re_Order();
            form.Show();
            this.Close();
        }
    }
}
