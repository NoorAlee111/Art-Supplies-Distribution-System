using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ColourFusion.DL;
using ColourFusion.BL;
using ColorFusion.Data_Structure;



namespace ColorFusion
{
    public partial class AssignedAreas : Form
    {
        public List<List<double>> Nodesdistance;
        Rider Rider1;

        public AssignedAreas()
        {
            InitializeComponent();
            Nodesdistance = new List<List<double>>();
        }

        private void AssignedAreas_Load(object sender, EventArgs e)
        {
            Rider1 = UserDL.GetCurrentRider("Ali123");
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyCSNW7Pt4PQZ7qxeT6rrTAQoBqpcw51KBE&token=88415";
            Map1.DragButton = MouseButtons.Left;
            Map1.MapProvider = GMapProviders.GoogleMap;
            Map1.SetPositionByKeywords("16M Abdul Haque Rd, Trade Centre Commercial Area Phase 2 Johar Town, Lahore, Punjab 54000");
            Map1.CacheLocation = @"cache";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            Map1.Zoom = 18;
            Map1.MinZoom = 2;
            Map1.MaxZoom = 18;
            Map1.ShowCenter = false;
        }

        private void getpointsbtn_Click(object sender, EventArgs e)
        {
            foreach(PointLatLng point in Rider1.Points1)
            {
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red);

                //Creating a overlay to cover map
                GMapOverlay markers = new GMapOverlay("markers");

                //Adding all markers to that overlay
                markers.Markers.Add(marker);
                // Covering map with overlay
                Map1.Overlays.Add(markers);
            }
        }

        private void GetDistancebutton_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < Rider1.Points1.Count(); i++)
            {
                MessageBox.Show(Convert.ToString(Rider1.Points1[i].Lat));
            }*/

            for (int i = 0; i < Rider1.Points1.Count(); i++)
            {
                Nodesdistance.Add(new List<double>());
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    var route = GoogleMapProvider.Instance.GetRoute(Rider1.Points1[i], Rider1.Points1[j], false, false, 14);
                    var r = new GMapRoute(route.Points, "My Route")
                    {
                        Stroke = new Pen(Color.Red, 5)
                    };
                    GMapOverlay routes = new GMapOverlay("routes");
                    routes.Routes.Add(r);
                    Map1.Overlays.Add(routes);
                    System.Threading.Thread.Sleep(300);
                    Nodesdistance[i].Add(route.Distance);
                    MessageBox.Show(route.Distance.ToString());
                }
            }

            Graph RidersGraph = new Graph(Nodesdistance);
            Graph.PrintGraph();
        }

        private void cmdAllRiders_Click(object sender, EventArgs e)
        {
            AllRiders form = new AllRiders();
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

        private void cmdReorder_Click(object sender, EventArgs e)
        {
            Re_Order form = new Re_Order();
            form.Show();
            this.Close();
        }
    }
}
