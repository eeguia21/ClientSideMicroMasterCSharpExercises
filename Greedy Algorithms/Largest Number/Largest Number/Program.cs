//ChangeMoney
//Edgar Eguía Calcáneo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int [5];
            Random objR = new Random();
            LargestNumber objLN = new LargestNumber();

            for (int i = 0; i < 5; i++)
                numbers[i] = objR.Next(0, 20);

            Console.WriteLine(objLN.commputeLargestNumber(numbers));
            Console.ReadLine();
        }
    }

    public class LargestNumber
    {
        public int[] commputeLargestNumber(int [] numbers)
        {
            int numAux = 0;
            int i = 0;

            while (i < numbers.Length)
            {
                for (int j = i; j < numbers.Length-1; j++)
                    if (numbers[i] < numbers[j+1])
                    {
                        numAux = numbers[i];
                        numbers[i] = numbers[j + 1];
                        numbers[j + 1] = numAux;
                    }
                i++;
            }
            return numbers;
        }
    }
}
