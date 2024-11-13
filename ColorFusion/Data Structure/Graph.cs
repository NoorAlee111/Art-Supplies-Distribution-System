using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColourFusion.BL;
using ColourFusion.DL;


namespace ColorFusion.Data_Structure
{
    public class Graph
    {
        private static double[,] RidersGraph = new double[,] { { 0, 0, 0, 0, 0 },
                                                        { 0, 0, 0, 0, 0 },
                                                        { 0, 0, 0, 0, 0 },
                                                        { 0, 0, 0, 0, 0 },
                                                        { 0, 0, 0, 0, 0 } };

        public static double[,] RidersGraph1 { get => RidersGraph; set => RidersGraph = value; }

        public Graph(List<List<double>> DistancesList)
        {
            for(int i = 0; i < DistancesList.Count(); i++)
            {
                for (int j = 0; j < DistancesList[i].Count(); j++)
                {
                    
                    if (i == j)
                    {
                        RidersGraph[i, j] = 0;
                    }
                    else
                    {
                        RidersGraph[i, j] = DistancesList[i][j];
                        RidersGraph[j, i] = DistancesList[i][j];
                    }
                }
            }
        }

        public static void PrintGraph()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    MessageBox.Show("graph");
                    MessageBox.Show(Convert.ToString(RidersGraph[i, j]));
                }
            }
        }
    }
}
