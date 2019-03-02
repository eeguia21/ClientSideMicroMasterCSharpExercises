using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacingParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[6] {5, 8, 7, 4, 8, 9};
            char[] ops = new char[5] {'-', '+', '*', '-', '+'}; 
            int maxValue = 0;

            PlacingParenthesesDP objPP = new PlacingParenthesesDP();

            maxValue = objPP.ComputeParenthesis(numbers, ops);

            Console.WriteLine(maxValue);
            Console.ReadLine();
        }
    }

    public class PlacingParenthesesDP
    {
        public int ComputeParenthesis(int [] numbers, char [] ops)
        {
            int[,] Max = new int[numbers.Length, numbers.Length];
            int[,] Min = new int[numbers.Length, numbers.Length];
            int j = 0;
            int[] res = new int[2];

            for (int i = 0; i < numbers.Length; i ++)
            {
                Min[i, i] = numbers[i];
                Max[i, i] = numbers[i];
            }

            for (int s = 0; s < numbers.Length - 1; s++)
            {
                for (int i = 0; i < numbers.Length - s - 1; i++)
                {
                    j = i + s + 1;
                    res = ComputeMinMax(i, j, Max, Min, ops);
                    Min[i, j] = res[0];
                    Max[i, j] = res[1];
                }
            }
             return Max[0, numbers.Length - 1];
        }

        public int[] ComputeMinMax(int i, int j, int [,] Max, int [,] Min, char [] ops)
        {
            int min = 10000;
            int max = -10000;
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int[] result = new int[2];

            for (int z = i; z < j; z++)
            {
                if (ops[z] == '+')
                {
                    a = Max[i, z] + Max[z + 1, j];
                    b = Max[i, z] + Min[z + 1, j];
                    c = Min[i, z] + Max[z + 1, j];
                    d = Min[i, z] + Min[z + 1, j];
                }
                else if (ops[z] == '-')
                {
                    a = Max[i, z] - Max[z + 1, j];
                    b = Max[i, z] - Min[z + 1, j];
                    c = Min[i, z] - Max[z + 1, j];
                    d = Min[i, z] - Min[z + 1, j];
                }
                else if (ops[z] == '*')
                {
                    a = Max[i, z] * Max[z + 1, j];
                    b = Max[i, z] * Min[z + 1, j];
                    c = Min[i, z] * Max[z + 1, j];
                    d = Min[i, z] * Min[z + 1, j];
                }
                min = Math.Min(min, Math.Min(a, (Math.Min(b, Math.Min(c, d)))));
                max = Math.Max(max, Math.Max(a, (Math.Max(b, Math.Max(c, d)))));
            }
            result[0] = min;
            result[1] = max;

            return result;
        }
    }
}
