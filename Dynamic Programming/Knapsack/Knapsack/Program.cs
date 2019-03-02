using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            int W = 11;
            int[] V = new int[4] {30, 14, 16, 9};
            int[] Weights = new int[4] {6, 3, 4, 2};
            Random objR = new Random();
            Knapsack objK = new Knapsack();

            //for (int i = 0; i < V.Length; i++)
            //{
            //    V[i] = objR.Next(1, 10);
            //    Weights[i] = objR.Next(1, 10);
            //}

            Console.WriteLine(objK.ComputeDPKnapsack(W, V, Weights));
            Console.ReadLine();
        }
    }

    public class Knapsack
    {
        public int ComputeDPKnapsack(int W, int [] V, int [] Weights)
        {
            int[] values = new int[W];
            int val = 0;

            for (int i = 0; i < values.Length; i++)
                values[i] = 0;

            for (int k = 1; k < W; k++)
            {
                values[k] = 0;
                for (int l = 0; l < V.Length; l++)
                {
                    if (Weights[l] <= k)
                    {
                        val = values[k - Weights[l]] + V[l];
                        if (val > values[k])
                            values[k] = val;
                    }                   
                }
            }
            return values[W - 1];
        }
    }
}
