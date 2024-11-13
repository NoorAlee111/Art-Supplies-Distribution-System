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
    public partial class EditProduct : Form
    {

        private Product previous;
        public EditProduct(Product previous)
        {
            InitializeComponent();
            this.previous = previous;
        }
        void EditProductfunc(int id, int quantity)
        {
            foreach (Product pr in InventoryDL.ProductsList1)
            {
                if (pr.ProductId1 == id)
                {
                    pr.Quantity1= quantity;
                }
            }
        }
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            InventoryDL.ReOrderProduct(int.Parse(txtProductID.Text), int.Parse(txtQuantity.Text));
            EditProductfunc(int.Parse(txtProductID.Text), int.Parse(txtQuantity.Text));
            InventoryDL.WriteDatainFile();
            MessageBox.Show("Edited....");
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            txtName.Text = previous.Name1;
            txtBrand.Text = previous.Supplier1.ToString();
            txtColor.Text = previous.Color1.ToString();
            txtType.Text = previous.Type1.ToString();
            txtLiters.Text = previous.Liters1.ToString();
            txtPrice.Text = previous.Price1.ToString();
            txtQuantity.Text = previous.Quantity1.ToString();
            txtThreshold.Text = previous.Threshold1.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
