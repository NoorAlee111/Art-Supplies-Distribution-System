using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ColorFusion.DataStructure;
using ColourFusion.BL;

namespace ColorFusion.DL
{
    class InventoryDL
    {
        private static AvlTree ProductsAVL = new AvlTree();

        private static List<Product> ProductsList = new List<Product>();

        public static AvlTree ProductsAVL1 { get => ProductsAVL; set => ProductsAVL = value; }
        public static List<Product> ProductsList1 { get => ProductsList; set => ProductsList = value; }

        public static void AddProduct(Product p)
        {
            ProductsAVL.AddintoAVL(p);
        }

        public static void DeleteProduct(Product p)
        {
            ProductsAVL.Delete(p);
        }

        public static Product FindFroduct(int id)
        {
            Product p;
            p = ProductsAVL.Find(id);
            return p;
        }
       
        public static void ReOrderProduct(int Productid, int Quantity)
        {
            Product p;
            p = ProductsAVL.Find(Productid);
            p.Quantity1 = Quantity;

        }

        public static List<Product> getProductsData()
        {
            List<Product> list = new List<Product>();
            list = ProductsAVL.GetAvlData(list, ProductsAVL.Root1);
            return list;
        }

        public static void WriteDataInFile(Product p)
        {
            StreamWriter file = new StreamWriter("ProductsData.csv");          
            file.WriteLine(p.ProductId1 + "," + p.Name1 + "," + p.Color1 + "," + p.Liters1 + "," + p.Type1 + "," + p.Quantity1 + "," + p.Threshold1 + "," + p.Supplier1 + "," + p.Price1);
            file.Flush();
            file.Close();
        }

        public static void WriteDatainFile()
        {
            StreamWriter file = new StreamWriter("ProductsData.csv");
            foreach (Product p in ProductsList)
            {
                file.WriteLine(p.ProductId1 + "," + p.Name1 + "," + p.Color1 + "," + p.Liters1 + "," + p.Type1 + "," + p.Quantity1 + "," + p.Threshold1 + "," + p.Supplier1 + "," + p.Price1 + "," + p.SoldCount1);
            }
            file.Flush();
            file.Close();
            //ProductsAVL.Write(ProductsAVL.Root1);
        }

        public static bool ReadDataFromFile()
        {
            bool flag = false;
            var lines = File.ReadAllLines("ProductsData.csv");
            foreach (var line in lines)
            {
                var values = line.Split(',');
                Product p = new Product(Convert.ToInt32(values[0]), values[1], values[2], Convert.ToInt32(values[3]), values[4], Convert.ToInt32(values[5]), Convert.ToInt32(values[6]), values[7], Convert.ToInt32(values[8]), Convert.ToInt32(values[9]));
                ProductsAVL.AddintoAVL(p);
                ProductsList.Add(p);
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
    }
}
