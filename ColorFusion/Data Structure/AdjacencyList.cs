using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColourFusion.BL;
using ColourFusion.DL;

namespace ColorFusion.Data_Structure
{
    class AdjacencyList
    {
        private Shop EndingVertex;
        private double Weight;

        public Shop EndingVertex1 { get => EndingVertex1; set => EndingVertex1 = value; }
        public double Weight1 { get => Weight; set => Weight = value; }

        public AdjacencyList(Shop EndingVertex, double Weight)
        {
            this.EndingVertex = EndingVertex;
            this.Weight = Weight;
        }

        public AdjacencyList(Shop StartingVertex, Shop EndingVertex, double Weight)
        {
            this.EndingVertex = EndingVertex;
            this.Weight = Weight;
        }
    }
}
