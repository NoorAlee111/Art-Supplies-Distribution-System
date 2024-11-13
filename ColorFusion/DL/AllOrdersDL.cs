using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.IO;
using ColourFusion.BL;
using ColourFusion.DL;

namespace ColorFusion.DL
{
    public class AllOrdersDL
    {
        private static LinkedList<Shop> AllOrdersList = new LinkedList<Shop>();

        private static List<Shop> AllOrders = new List<Shop>();

        private static List<Shop> DeliveredOrders = new List<Shop>();

        public static LinkedList<Shop> AllOrdersList1 { get => AllOrdersList; set => AllOrdersList = value; }
        public static List<Shop> AllOrders1 { get => AllOrders; set => AllOrders = value; }
        public static List<Shop> DeliveredOrders1 { get => DeliveredOrders; set => DeliveredOrders = value; }

        public static void AddOrderInList(Shop Order)
        {
            AllOrdersList.AddLast(Order);
        }

        public static void DeleteOrderInList(Shop Order)
        {
            AllOrdersList.Remove(Order);
        }

        public static void SetStatus(Shop s)
        {
            foreach(Shop x in AllOrdersList)
            {
                if (x.OrderID1 == s.OrderID1)
                {
                    x.Status1 = true;
                }
            }

            foreach (Shop x in AllOrders)
            {
                if (x.OrderID1 == s.OrderID1)
                {
                    x.Status1 = true;
                }
            }
        }

        public static bool ReadDataFromFile()
        {
            double lat = Convert.ToDouble(31.4678);
            double lng = Convert.ToDouble(74.2666);
            PointLatLng MainPointer = new PointLatLng(lat, lng);
            Rider R = UserDL.GetCurrentRider("Ali123");
            R.Points1.Add(MainPointer);
            bool flag = false;
            var lines = File.ReadAllLines("OrdersData.csv");
            foreach (var line in lines)
            {
                var values = line.Split(',');
                double Lat = Convert.ToDouble(values[9]);
                double Lng = Convert.ToDouble(values[10]);
                PointLatLng ShopPointer = new PointLatLng(Lat, Lng);
                Rider r = UserDL.GetCurrentRider("Ali123");
                r.Points1.Add(ShopPointer);

                List<Product> ProductsList = new List<Product>();
                if (values[7] == values[19])
                {
                    Product p = new Product(Convert.ToInt32(values[11]), values[12], values[13], Convert.ToInt32(values[14]), values[15], Convert.ToInt32(values[16]), Convert.ToInt32(values[17]), values[18], values[19], Convert.ToInt32(values[20]));
                    ProductsList.Add(p);
                }
                Shop s = new Shop(values[0], values[1], Convert.ToInt32(values[2]), Convert.ToInt32(values[3]), Convert.ToBoolean(values[4]), Convert.ToInt32(values[5]), values[6], values[7], values[8], ShopPointer, ProductsList);
                AllOrdersList.AddLast(s);
                AllOrders.Add(s);
                if (Convert.ToBoolean(values[4]) == true)
                {
                    DeliveredOrders1.Add(s);
                }
                flag = true;
            }
            if (flag == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void WriteDataInFile()
        {
            StreamWriter file = new StreamWriter("OrdersData.csv");
            foreach (Shop c in AllOrdersList)
            {
                foreach (Product p in c.ProductsList1)
                {
                    file.WriteLine(c.ShopName1 + "," + c.OrderID1 + "," + c.PickUpDate1 + "," + c.DeliveredDate1 + "," + c.Status1 + "," + c.OrderCount1 + "," + c.RiderID1 + "," + c.Id1 + "," + c.Address1 + "," + c.ShopPointer1.Lat + "," + c.ShopPointer1.Lng + "," + p.ProductId1 + "," + p.Name1 + "," + p.Color1 + "," + p.Liters1 + "," + p.Type1 + "," + p.Quantity1 + "," + p.Threshold1 + "," + p.Supplier1 + "," + p.Id1 + "," + p.Price1);
                }
            }
            file.Flush();
            file.Close();

        }
    }
}
