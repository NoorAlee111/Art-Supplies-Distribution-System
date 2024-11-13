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

namespace ColorFusion
{
    public partial class ViewRiders : Form
    {
        public ViewRiders()
        {
            InitializeComponent();
        }

        private void ViewRiders_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        public void dataBind()
        {
            RidersGV.AutoGenerateColumns = true;
            RidersGV.DataSource = UserDL.RidersList1;
        }

        private void cmdAddRider_Click(object sender, EventArgs e)
        {
            AddRider form = new AddRider();
            form.Show();
        }

        private void RidersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Rider r = (Rider)RidersGV.CurrentRow.DataBoundItem;
            if (RidersGV.Columns["Edit"].Index == e.ColumnIndex)
            {
                EditRider form = new EditRider(r);
                form.ShowDialog();
                //UserDL.WriteInFile();
                dataBind();
            }
            else if (RidersGV.Columns["Delete"].Index == e.ColumnIndex)
            {
                UserDL.DeleteUserFromList(r);
                //UserDL.WriteInFile();
                dataBind();
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

        private void cmdSuppliersReport_Click(object sender, EventArgs e)
        {
            SuppliersReport form = new SuppliersReport();
            form.Show();
            this.Close();
        }
    }
}
