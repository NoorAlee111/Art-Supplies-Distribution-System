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
    public partial class ViewEmployees : Form
    {
        public ViewEmployees()
        {
            InitializeComponent();
        }

        public void dataBind()
        {
            EmployeesGV.AutoGenerateColumns = true;
            EmployeesGV.DataSource = UserDL.EmployeesList1;
        }

        private void ViewEmployees_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        private void EmployeesGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Employee emp = (Employee)EmployeesGV.CurrentRow.DataBoundItem;
            if (EmployeesGV.Columns["Edit"].Index == e.ColumnIndex)
            {
                EditEmployee form = new EditEmployee(emp);
                form.ShowDialog();
                //UserDL.WriteEmployeeInFile();
                dataBind();
            }
            else if (EmployeesGV.Columns["Delete"].Index == e.ColumnIndex)
            {
                UserDL.DeleteUserFromList(emp);
                //UserDL.WriteInFile();
                dataBind();
            }
        }

        private void cmdAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee form = new AddEmployee();
            form.ShowDialog();
            //UserDL.WriteInFile();
            dataBind();
        }

        private void EmployeesGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void cmdSuppliersReport_Click(object sender, EventArgs e)
        {
            SuppliersReport form = new SuppliersReport();
            form.Show();
            this.Close();
        }
    }
}
