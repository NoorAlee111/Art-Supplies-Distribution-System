using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace ColourFusion.BL
{
    public class Fuel
    {
        private int Date;
        private int AmountAdded;
        private int Price;
        private int TotalConsumption;
        private int FuelLeft;
        private int AmountSaved;
        private string Id;

        public int Date1 { get => Date; set => Date = value; }
        public int AmountAdded1 { get => AmountAdded; set => AmountAdded = value; }
        public int Price1 { get => Price; set => Price = value; }
        public int TotalConsumption1 { get => TotalConsumption; set => TotalConsumption = value; }
        public int FuelLeft1 { get => FuelLeft; set => FuelLeft = value; }
        public int AmountSaved1 { get => AmountSaved; set => AmountSaved = value; }
        public string Id1 { get => Id; set => Id = value; }

        public Fuel(int Date, int AmountAdded, int Price, int TotalConsumption, int FuelLeft, int AmountSaved, string Id)
        {
            this.Date = Date;
            this.AmountAdded = AmountAdded;
            this.Price = Price;
            this.TotalConsumption = TotalConsumption;
            this.FuelLeft = FuelLeft;
            this.AmountSaved = AmountSaved;
            this.Id = Id;
        }

    }
}
