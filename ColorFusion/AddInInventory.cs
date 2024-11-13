using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColourFusion.BL;
using ColourFusion.DL;
using ColorFusion.DL;
using System.Windows.Forms;

namespace ColorFusion
{
    public partial class AddInInventory : Form
    {
        public AddInInventory()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductID.Text!="" && txtName.Text != "" && txtBrand.Text != "" && txtColor.Text != "" && txtLiters.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "" && txtThreshold.Text != "" && txtType.Text != "")
                {
                    Product p = new Product(int.Parse(txtProductID.Text), txtName.Text.ToString(), txtColor.Text.ToString(), int.Parse(txtLiters.Text), txtType.Text.ToString(), int.Parse(txtQuantity.Text), int.Parse(txtThreshold.Text), txtBrand.Text.ToString(),int.Parse(txtPrice.Text), 0);
                    InventoryDL.AddProduct(p);
                    InventoryDL.ProductsList1.Add(p);
                    InventoryDL.WriteDatainFile();
                    MessageBox.Show("Product is added");
                }

                else
                {
                    MessageBox.Show("Fill all required information....");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void AddInInventory_Load(object sender, EventArgs e)
        {

        }
    }
}
