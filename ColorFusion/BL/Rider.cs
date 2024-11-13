using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ColourFusion.DL;
using ColourFusion.BL;


namespace ColourFusion.BL
{
    public class Rider : User
    {
        //add location attribute
        private string VehicleName;
        private string VehicleColor;
        private string NumberPlate;
        private string ID;
        private LinkedList<Fuel> FuelInfoList = new LinkedList<Fuel>();
        private List<PointLatLng> Points = new List<PointLatLng>();

        public string VehicleName1 { get => VehicleName; set => VehicleName = value; }
        public string VehicleColor1 { get => VehicleColor; set => VehicleColor = value; }
        public string NumberPlate1 { get => NumberPlate; set => NumberPlate = value; }
        public string ID1 { get => ID; set => ID = value; }
        internal LinkedList<Fuel> FuelInfoList1 { get => FuelInfoList; set => FuelInfoList = value; }
        public List<PointLatLng> Points1 { get => Points; set => Points = value; }

        public Rider(string UserID, string UserPassword, string Name, string EmailAddress, string ContactNo, string Cnic, string Type, string VehicleName, string VehicleColor, string NumberPlate, string ID, Fuel Fuel) : base(UserID, UserPassword, Name, EmailAddress, ContactNo, Cnic, Type)
        {
            this.VehicleName = VehicleName;
            this.VehicleColor = VehicleColor;
            this.NumberPlate = NumberPlate;
            this.ID = ID;
            FuelInfoList1.AddLast(Fuel);
        }

        public Rider(string UserID, string UserPassword, string Name, string EmailAddress, string ContactNo, string Cnic, string Type, string VehicleName, string VehicleColor, string NumberPlate, string ID) : base(UserID, UserPassword, Name, EmailAddress, ContactNo, Cnic, Type)
        {
            this.VehicleName = VehicleName;
            this.VehicleColor = VehicleColor;
            this.NumberPlate = NumberPlate;
            this.ID = ID;
            //FuelInfoList1 = null;
        }

        public void AddFuelInfo(Fuel Fuel)
        {
            FuelInfoList1.AddLast(Fuel);
        }

        public void AddShopPointers(PointLatLng p)
        {
            Points.Add(p);
        }
    }
}
