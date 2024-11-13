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
    public partial class RetailersPurchases : Form
    {
        int count = 0;
        List<string> RetailersName = new List<string>();

        public RetailersPurchases()
        {
            InitializeComponent();
        }

        public void TraverseList()
        {
            RetailersName = AllOrdersDL.AllOrders1.Select(x => x.ShopName1).Distinct().ToList();
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            TraverseList();
            MessageBox.Show(RetailersName.Count.ToString());

            foreach (string s in RetailersName)
            {
                count = 0;
                foreach (Shop s1 in AllOrdersDL.AllOrders1)
                {
                    if (s1.ShopName1 == s)
                    {
                        count++;
                    }
                }
                retailersChart.Series["Retailers"].Points.AddXY(s, count);
            }
        }

        private void cmdEmployeeInfo_Click(object sender, EventArgs e)
        {
            ViewEmployees form = new ViewEmployees();
            form.Show();
            this.Close();
        }

        private void cmdShiftChange_Click(object sender, EventArgs e)
        {
            ShiftChange form = new ShiftChange();
            form.Show();
            this.Close();
        }

        private void cmdRidersInfo_Click(object sender, EventArgs e)
        {
            ViewRiders form = new ViewRiders();
            form.Show();
            this.Close();
        }

        private void cmdReorder_Click(object sender, EventArgs e)
        {
            Re_order_Requests form = new Re_order_Requests();
            form.Show();
            this.Close();
        }

        private void cmdSoldProducts_Click(object sender, EventArgs e)
        {
            Sales form = new Sales();
            form.Show();
            this.Close();
        }

        private void cmdEmployeesPerformance_Click(object sender, EventArgs e)
        {
            EmployeePerformance form = new EmployeePerformance();
            form.Show();
            this.Close();
        }

        private void cmdRidersPerformance_Click(object sender, EventArgs e)
        {
            RiderPerformance form = new RiderPerformance();
            form.Show();
            this.Close();
        }

        private void cmdFuelReport_Click(object sender, EventArgs e)
        {
            FuelConsumption form = new FuelConsumption();
            form.Show();
            this.Close();
        }

        private void cmdSuppliersReport_Click(object sender, EventArgs e)
        {
            SuppliersReport form = new SuppliersReport();
            form.Show();
            this.Close();
        }

        private void RetailersPurchases_Load(object sender, EventArgs e)
        {

        }
    }
}
