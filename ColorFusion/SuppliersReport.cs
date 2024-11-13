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
    public partial class SuppliersReport : Form
    {
        int count = 0;
        List<string> SuppliersName = new List<string>();

        public SuppliersReport()
        {
            InitializeComponent();
        }

        public void TraverseList()
        {
            SuppliersName = InventoryDL.ProductsList1.Select(x => x.Supplier1).Distinct().ToList();
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            TraverseList();
            foreach (string p in SuppliersName)
            {
                count = 0;
                foreach (Product p1 in InventoryDL.ProductsList1)
                {
                    if (p == p1.Supplier1)
                    {
                        count++;
                    }
                }
                suppliersChart.Series["Suppliers"].Points.AddXY(p, count);
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

        private void cmdRetailersPurchases_Click(object sender, EventArgs e)
        {
            RetailersPurchases form = new RetailersPurchases();
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
    }
}
