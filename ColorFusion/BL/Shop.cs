using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace ColourFusion.BL
{
    public class Shop
    {
        private string ShopName;
        private string OrderID;
        private int PickUpDate;
        private int DeliveredDate;
        private bool Status;
        private int OrderCount;
        private string RiderID;
        private string Id;
        private string Address;
        private PointLatLng ShopPointer;
        private List<Product> ProductsList = new List<Product>();

        public string ShopName1 { get => ShopName; set => ShopName = value; }
        public string OrderID1 { get => OrderID; set => OrderID = value; }
        public int PickUpDate1 { get => PickUpDate; set => PickUpDate = value; }
        public int DeliveredDate1 { get => DeliveredDate; set => DeliveredDate = value; }
        public bool Status1 { get => Status; set => Status = value; }
        public int OrderCount1 { get => OrderCount; set => OrderCount = value; }
        public string RiderID1 { get => RiderID; set => RiderID = value; }
        public string Id1 { get => Id; set => Id = value; }
        public string Address1 { get => Address; set => Address = value; }
        public List<Product> ProductsList1 { get => ProductsList; set => ProductsList = value; }
        public PointLatLng ShopPointer1 { get => ShopPointer; set => ShopPointer = value; }

        public Shop(string ShopName, string OrderID, int PickUpDate, int DeliveredDate, bool Status, int OrderCount, string RiderID, string Id, string Address, PointLatLng ShopPointer, List<Product> ProductsList)
        {
            this.ShopName1 = ShopName;
            this.OrderID = OrderID;
            this.PickUpDate = PickUpDate;
            this.DeliveredDate = DeliveredDate;
            this.Status = Status;
            this.OrderCount = OrderCount;
            this.RiderID = RiderID;
            this.Id = Id;
            this.Address = Address;
            this.ShopPointer = ShopPointer;
            this.ProductsList = ProductsList;
        }

        public void AddProduct(Product p)
        {
            ProductsList.Add(p);
        }
    }
}
