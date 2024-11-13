using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourFusion.BL
{
    public class Product
    {
        private int ProductId;
        private string Name;
        private string Color;
        private int Liters;
        private string Type;
        private int Quantity;
        private int Threshold;
        private string Supplier;
        private string Id;
        private int Price;
        private int SoldCount;

        public int Price1 { get => Price; set => Price = value; }
        public int ProductId1 { get => ProductId; set => ProductId = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Color1 { get => Color; set => Color = value; }
        public int Liters1 { get => Liters; set => Liters = value; }
        public string Type1 { get => Type; set => Type = value; }
        public int Quantity1 { get => Quantity; set => Quantity = value; }
        public int Threshold1 { get => Threshold; set => Threshold = value; }
        public string Supplier1 { get => Supplier; set => Supplier = value; }
        public string Id1 { get => Id; set => Id = value; }
        public int SoldCount1 { get => SoldCount; set => SoldCount = value; }

        public Product(int ProductId, string Name, string Color, int Liters, string Type, int Quantity, int Threshold, string Supplier, string Id, int Price)
        {
            this.ProductId = ProductId;
            this.Name = Name;
            this.Color = Color;
            this.Liters = Liters;
            this.Type = Type;
            this.Quantity = Quantity;
            this.Threshold = Threshold;
            this.Supplier = Supplier;
            this.Id = Id;
            this.Price1 = Price;
        }

        public Product(int ProductId, string Name, string Color, int Liters, string Type, int Quantity, int Threshold, string Supplier, int Price, int SoldCount)
        {
            this.ProductId = ProductId;
            this.Name = Name;
            this.Color = Color;
            this.Liters = Liters;
            this.Type = Type;
            this.Quantity = Quantity;
            this.Threshold = Threshold;
            this.Supplier = Supplier;
            this.Price1 = Price;
            this.SoldCount = SoldCount;
        }
    }
}
