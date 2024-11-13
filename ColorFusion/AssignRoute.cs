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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using ColorFusion.DL;
using GMap.NET.WindowsForms.Markers;
using ColorFusion.Data_Structure;


namespace ColorFusion
{
    public partial class AssignRoute : Form
    {
        double[,] MSTGraph ;
        PointLatLng Start;
        PointLatLng End;
        public AssignRoute()
        {
            InitializeComponent();
        }

        private void AssignRoute_Load(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyCSNW7Pt4PQZ7qxeT6rrTAQoBqpcw51KBE&token=88415";
            Map1.DragButton = MouseButtons.Left;
            Map1.MapProvider = GMapProviders.GoogleMap;
            //Map1.SetPositionByKeywords("16M Abdul Haque Rd, Trade Centre Commercial Area Phase 2 Johar Town, Lahore, Punjab 54000");
            Map1.CacheLocation = @"cache";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            Map1.Zoom = 18;
            Map1.MinZoom = 2;
            Map1.MaxZoom = 18;
            Map1.ShowCenter = false;
        }

        private void cmdCalculatePath_Click(object sender, EventArgs e)
        {
            MinimumSpanningTree.MST(Graph.RidersGraph1);
            MinimumSpanningTree.PrintMST();
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

        private void cmdAssignRoute_Click(object sender, EventArgs e)
        {
            AssignOrders form = new AssignOrders();
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

        PointLatLng GetShopPoint(int i)
        {
            PointLatLng point = new PointLatLng();
            foreach(Shop s in AllOrdersDL.AllOrders1)
            {
                if(s.OrderCount1==i)
                {
                    return s.ShopPointer1;
                }
            }
            return point;
        }

        private void GetRoutebtn_Click(object sender, EventArgs e)
        {
            Map1.Zoom = 14;
            Map1.MinZoom = 5;
            Map1.MaxZoom = 100;
            Map1.SetPositionByKeywords("Lahore, Punjab 54000");
            MSTGraph = MinimumSpanningTree.MSTGraph1;
            for (int i=0;i<5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(MSTGraph[i,j]!=0)
                    {
                        Start = GetShopPoint(i);
                        End = GetShopPoint(j);
                        var route = GoogleMapProvider.Instance.GetRoute(Start, End , false, false, 14);
                        var r = new GMapRoute(route.Points, "My Route")
                        {
                            Stroke = new Pen(Color.Blue, 5)
                        };
                        GMapOverlay routes = new GMapOverlay("routes");
                        routes.Routes.Add(r);
                        Map1.Overlays.Add(routes);
                        System.Threading.Thread.Sleep(300);
                        MessageBox.Show("okay");
                    }
                }

            }
        }
    }
}
