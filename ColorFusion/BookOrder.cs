using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Text.RegularExpressions;
using ColourFusion.BL;
using ColourFusion.DL;
using ColorFusion.DL;
using System.Windows.Forms;

namespace ColorFusion
{
    public partial class BookOrder : Form
    {
        private PointLatLng ShopPoint;
        private PointLatLng InventoryPoint= new PointLatLng(31.4678, 74.2666);
        private List<Product> OrderedProducts = new List<Product>();
        
        public BookOrder()
        {
            InitializeComponent();
        }
        
        private void BookOrder_Load(object sender, EventArgs e)
        {
            dataBind();

            GMapProviders.GoogleMap.ApiKey = @"AIzaSyCSNW7Pt4PQZ7qxeT6rrTAQoBqpcw51KBE&token=88415";
            Map1.DragButton = MouseButtons.Left;
            Map1.MapProvider = GMapProviders.GoogleMap;

            Map1.SetPositionByKeywords(" Lahore, Punjab 54000");
            Map1.CacheLocation = @"cache";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            Map1.Zoom = 15;
            Map1.MinZoom = 2;
            Map1.MaxZoom = 18;
            Map1.ShowCenter = false;
        }

        public void dataBind()
        {
            ProductsGV.AutoGenerateColumns = true;
            ProductsGV.DataSource = InventoryDL.ProductsList1;
        }

        private void cmdGoToLocation_Click(object sender, EventArgs e)
        {
            Map1.SetPositionByKeywords(txtDeliveryAddress.Text.ToString());
            //Map1.GetPositionByKeywords("16M Abdul Haque Rd, Trade Centre Commercial Area Phase 2 Johar Town, Lahore, Punjab 54000",out points[0]);
            Map1.MinZoom = 5;
            Map1.MaxZoom = 18;
            Map1.Zoom = 15;
        }

        private void getPoint_Click(object sender, EventArgs e)
        {

        }

        private void Map1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void cmdGetRoute_Click(object sender, EventArgs e)
        {
            if(ShopPoint!=null)
            {
                GMapMarker marker = new GMarkerGoogle(InventoryPoint, GMarkerGoogleType.red);
                GMapOverlay markers = new GMapOverlay("markers");
                markers.Markers.Add(marker);
                Map1.Overlays.Add(markers);
                var route = GoogleMapProvider.Instance.GetRoute(InventoryPoint, ShopPoint, false, false, 14);
                var r = new GMapRoute(route.Points, "My Route")
                {
                    Stroke = new Pen(Color.Red, 5)
                };
                GMapOverlay routes = new GMapOverlay("routes");
                routes.Routes.Add(r);
                Map1.Overlays.Add(routes);
                
            }
           
        }

        private void Map1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                var point = Map1.FromLocalToLatLng(e.X, e.Y);
                double lat = point.Lat;
                double lon = point.Lng;
                //this the the values of latitude in double when you click 
                lblLatitude.Text = lat.ToString();
                //this the the values of longitude in double when you click 
                lblLongitude.Text = lon.ToString();
                Rider u;
                //u = UserDL.GetCurrentRider(Login.CurrentUser.UserID1);
                ShopPoint = new PointLatLng(lat, lon);
                //u.Points1.Add(ShopPoint);

                GMapMarker marker = new GMarkerGoogle(ShopPoint, GMarkerGoogleType.red);
                GMapOverlay markers = new GMapOverlay("markers");
                markers.Markers.Add(marker);
                Map1.Overlays.Add(markers);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cmdConfirmOrder_Click(object sender, EventArgs e)
        {
            if (txtContact.BackColor == Color.Green)
            {
                string ShopName = txtShopName.Text;
                string OrderID = txtOrderID.Text;
                int PickUpDate = Convert.ToInt32(txtPickUpDate.Text);
                int DeliveryDate = Convert.ToInt32(txtDeliveredDate.Text);
                bool Status = false;
                int OrderCount = Convert.ToInt32(txtOrderCount.Text);
                string RiderID = txtRiderID.Text;
                string ID = txtID.Text;
                string Address = txtDeliveryAddress.Text;
                double Lat = Convert.ToDouble(lblLatitude.Text);
                double Lng = Convert.ToDouble(lblLongitude.Text);
                PointLatLng ShopPointer = new PointLatLng(Lat, Lng);
                List<Product> ProductsList = OrderedProducts;
                Shop s = new Shop(ShopName, OrderID, PickUpDate, DeliveryDate, Status, OrderCount, RiderID, ID, Address, ShopPointer, ProductsList);
                AllOrdersDL.AllOrdersList1.AddLast(s);
                AllOrdersDL.AllOrders1.Add(s);
                AllOrdersDL.WriteDataInFile();

                Rider r = UserDL.CheckUser(RiderID);
                r.AddShopPointers(ShopPointer);
                string message = "Your Order has been Confirmed!!!!!!!";
                EmailSending ES = new EmailSending(txtEmail.Text.ToString(), message);
                string msg=ES.EmailSendingfunc();
                MessageBox.Show(msg);
            }
            else if (txtContact.BackColor == Color.Red)
            {
                MessageBox.Show("Invalid Phone Number...");
            }
        }

        private void ProductsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Product p = (Product)ProductsGV.CurrentRow.DataBoundItem;
            if (ProductsGV.Columns["Add"].Index == e.ColumnIndex)
            {
                if (p.Quantity1 > 0)
                {
                    p.Id1 = txtID.Text;
                    OrderedProducts.Add(p);
                    p.SoldCount1++;
                }
                else
                {
                    MessageBox.Show("Product is out of Stock !");
                }
            }
        }

        private void txtShopName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtDeliveryAddress_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPickUpDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }

        }

        private void txtDeliveredDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtOrderCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{11}$");
            if (r.IsMatch(txtContact.Text))
            {
                txtContact.BackColor = Color.Green;
            }
            else
            {
                txtContact.BackColor = Color.Red;
            }
        }
    }
}
