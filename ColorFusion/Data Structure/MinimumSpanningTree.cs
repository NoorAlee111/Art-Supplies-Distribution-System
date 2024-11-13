using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorFusion.Data_Structure
{
    class MinimumSpanningTree
    {
        static int NoOfNodes = 5;
        private static double[,] MSTGraph = new double[,]  { { 0, 0, 0, 0, 0 },
                                                             { 0, 0, 0, 0, 0 },
                                                             { 0, 0, 0, 0, 0 },
                                                             { 0, 0, 0, 0, 0 },
                                                             { 0, 0, 0, 0, 0 } };

        public static double[,] MSTGraph1 { get => MSTGraph; set => MSTGraph = value; }

        public static int MinKey(double[] Key, bool[] MSTCheck)
        {
            double Min = double.MaxValue;
            int MinIndex = -1;
            for (int v = 0; v < NoOfNodes; v++)
                if (MSTCheck[v] == false && Key[v] < Min)
                {
                    Min = Key[v];
                    MinIndex = v;
                }
            return MinIndex;
        }

        public static void MST(double[,] Graph)
        {
            int[] Parent = new int[NoOfNodes];
            double[] Key = new double[NoOfNodes];
            bool[] MSTCheck = new bool[NoOfNodes];
            Key[0] = 0;
            Parent[0] = -1;

            for (int i = 0; i < NoOfNodes; i++)
            {
                Key[i] = int.MaxValue;
                MSTCheck[i] = false;
            }
            
            for (int count = 0; count < NoOfNodes - 1; count++)
            {
                int a = MinKey(Key, MSTCheck);
                MSTCheck[a] = true;

                for (int b = 0; b < NoOfNodes; b++)
                    if (Graph[a, b] != 0 && MSTCheck[b] == false && Graph[a, b] < Key[b])
                    {
                        Parent[b] = a;
                        Key[b] = Graph[a, b];
                    }
            }

            UpdateMST(Parent, Graph);
        }

        public static void UpdateMST(int[] Parent, double[,] Graph)
        {
            for (int i = 1; i < NoOfNodes; i++)
            {
                MSTGraph[Parent[i], i] = Graph[i, Parent[i]];
            }
        }

        public static void PrintMST()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    MessageBox.Show(Convert.ToString(MSTGraph[i, j]));
                }
            }
        }

        /*public static List<double> GetMSTAsList()
        {

        }*/

    }
}
