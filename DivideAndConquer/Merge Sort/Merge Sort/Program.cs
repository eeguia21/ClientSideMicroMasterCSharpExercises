using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Random objR = new Random();
            MergeSort objMS = new MergeSort();

            for (int i = 0; i < 10; i++)
                numbers.Add(objR.Next(1, 15));

            for (int i = 0; i < 10; i++)
                Console.WriteLine(objMS.ComputeMergeSort(numbers)[i]);

            Console.ReadLine();
        }
    }

    public class MergeSort
    {
        public List<int> ComputeMergeSort(List<int> numbers)
        {
            int indMed = 0;
            int midLimit = 0;
            List<int> firstHalf = new List<int>();
            List<int> secondHalf = new List<int>();

            if (numbers.Count <= 1)
                return numbers;
            indMed = numbers.Count / 2;
            if ((double)(numbers.Count) % 2 != 0)
                midLimit = indMed + 1;
            else
                midLimit = indMed;
            for (int i = 0; i < midLimit; i++)
            {
                firstHalf.Add(numbers[i]);
                if (!((double)(numbers.Count) % 2 != 0 && i == midLimit - 1))
                    secondHalf.Add(numbers[i + midLimit]);
            }
            firstHalf = ComputeMergeSort(firstHalf);
            secondHalf = ComputeMergeSort(secondHalf);
            return Merge(firstHalf, secondHalf);
        }

        public List<int> Merge(List<int> firstHalf, List<int> secondHalf)
        {
            List<int> result = new List<int>();

            while (firstHalf.Count > 0 || secondHalf.Count > 0)
            {
                if (firstHalf.Count > 0 && secondHalf.Count > 0)
                {
                    if (firstHalf.First() <= secondHalf.First())
                    {
                        result.Add(firstHalf.First());
                        firstHalf.Remove(firstHalf.First());
                    }
                    else
                    {
                        result.Add(secondHalf.First());
                        secondHalf.Remove(secondHalf.First());
                    }
                }
                else if (firstHalf.Count > 0)
                {
                    result.Add(firstHalf.First());
                    firstHalf.Remove(firstHalf.First());
                }
                else if (secondHalf.Count > 0)
                {
                    result.Add(secondHalf.First());
                    secondHalf.Remove(secondHalf.First());
                }
            }
            return result;
        }
    }
}
