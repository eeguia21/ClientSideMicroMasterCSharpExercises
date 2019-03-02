using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackWORep
{
    class Program
    {
        static void Main(string[] args)
        {
            int W = 11;
            int[] V = new int[4] { 30, 14, 16, 9 };
            int[] Weights = new int[4] { 6, 3, 4, 2 };
            Random objR = new Random();
            Knapsack objKWORep = new Knapsack();

            //for (int i = 0; i < V.Length; i++)
            //{
            //    V[i] = objR.Next(1, 10);
            //    Weights[i] = objR.Next(1, 10);
            //}

            Console.WriteLine(objKWORep.ComputeKnapsackWORep(W, V, Weights));
            Console.ReadLine();
        }
    }

    public class Knapsack
    {

        public int ComputeKnapsackWORep(int W, int [] Values, int [] Weights)
        {
            int val = 0;
            int[,] values = new int[W, Values.Length];
            bool[] qty;

            for (int i = 1; i < Values.Length; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    values[j, i] = values[j, i - 1];
                    if (Weights[i - 1] <= j)
                    {
                        val = values[j - Weights[i - 1], i - 1] + Values[i - 1];
                        if (values[j, i] < val)
                            values[j, i] = val;
                    }
                }
            }

            qty = ComputeQTYItems(values, Values.Length);

            for (int z = 0; z < qty.Length; z++)
                Console.WriteLine(qty[z]);

            return values[W - 1, Values.Length - 1];
        }

        public bool[] ComputeQTYItems(int [,] valuesF, int l)
        {
            bool[] qtyItems = new bool[l];



            return qtyItems;
        }
    }
}
