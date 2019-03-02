using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximizing_Loot
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal W = 14;
            decimal [] VW = new decimal [6];
            Random objR = new Random();
            MaximizingLoot objML = new MaximizingLoot();

            for (int i = 0; i < VW.Length; i++)
                VW[i] = objR.Next(1, 10);
            
            Console.WriteLine(objML.ComputeMaxValue_Amounts(W, VW));
            Console.ReadLine();
        }
    }

    public class MaximizingLoot
    {
        public decimal ComputeMaxValue_Amounts(decimal W, decimal [] VM)
        {
            decimal totalValue = 0;
            decimal[] amounts = new decimal[VM.Length/2];
            int indBest = 0;
            decimal quantityToTake = 0;

            for (int i = 0; i < VM.Length; i = i+2)
            {
                if (W == 0)
                    return totalValue;
                indBest = IdentifyBestItem(VM);
                quantityToTake = Math.Min(W, VM[indBest + 1]);
                totalValue = totalValue + (quantityToTake * (VM[indBest] / VM[indBest + 1]));
                VM[indBest + 1] = VM[indBest + 1] - quantityToTake;
                amounts[indBest/2] = amounts[indBest/2] + quantityToTake;
                W = W - quantityToTake;
            }

            return totalValue; 
        }

        public int IdentifyBestItem(decimal [] VW)
        {
            int indBestItem = 0;
            decimal maxValuePerWeight = 0;

            for (int i = 0; i < VW.Length; i = i + 2)
            {
                if (VW[i+1] > 0)
                {
                    if ((VW[i]/VW[i+1]) > maxValuePerWeight)
                    {
                        maxValuePerWeight = (VW[i] / VW[i + 1]);
                        indBestItem = i;
                    }
                }
            }
            return indBestItem;
        }
    }
}
