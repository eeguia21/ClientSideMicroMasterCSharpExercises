//Binary Search
//Edgar Eguía Calcáneo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = 9;
            decimal [] numbers = new decimal[10];
            decimal[] numbersSorted = new decimal[10];
            Random objR = new Random();
            BinarySearch objBS = new BinarySearch();

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = objR.Next(1, 15);

            numbersSorted = numbers.ToArray().OrderBy(x => x).ToArray();
            
            Console.WriteLine(objBS.ComputeBinarySearch(key, numbersSorted, 0, numbersSorted.Length-1));
            Console.WriteLine(objBS.ComputeBinarySearchIterative(key, numbersSorted, 0, numbersSorted.Length - 1));
            Console.ReadLine();
        }
    }

    public class BinarySearch
    {
        public int ComputeBinarySearch(int k, decimal[] numbersSorted, int low, int high)
        {
            int index = 0;

            if (high < low)
                return low - 1;
            index = low + ((high - low) / 2);
            if (k == numbersSorted[index])
                return index;
            else if (k < numbersSorted[index])
                return ComputeBinarySearch(k, numbersSorted, low, index - 1);
            else
                return ComputeBinarySearch(k, numbersSorted, index + 1, high);
        }

        public int ComputeBinarySearchIterative(int k, decimal[] numbersSorted, int low, int high)
        {
            int index = 0;

            while (low <= high)
            {
                index = low + ((high - low) / 2);
                if (k == numbersSorted[index])
                    return index;
                else if (k < numbersSorted[index])
                    high = index - 1;
                else
                    low = index + 1;
            }
            return low - 1;
        }
    }
}
