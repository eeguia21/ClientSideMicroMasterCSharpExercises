using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Random objR = new Random();
            QuickSort objQS = new QuickSort();

            for (int i = 0; i < 10; i++)
                numbers.Add(objR.Next(1, 15));

            objQS.ComputeQuickSort(numbers, 0, numbers.Count);

            for (int j = 0; j < numbers.Count; j++)
                Console.WriteLine(numbers[j]);

            Console.ReadLine();
        }
    }

    public class QuickSort
    {
        public int ComputeQuickSort(List<int> numbers, int l, int r)
        {
            List<int> result = new List<int>();
            int pivot;

            if (l >= r)
                return 1;

            pivot = Partition(numbers, l, numbers.Count);
            ComputeQuickSort(numbers, l, pivot-1);
            ComputeQuickSort(numbers, pivot+1, r);

            return 1;
        }

        public int Partition(List<int> numbers, int l, int r)
        {
            int pivot;
            int j;

            pivot = numbers[l];
            j = l;

            for(int i = l+1; i < r; i++)
            {
                if (numbers[i] <= pivot)
                {
                    j = j + 1;
                    swap(numbers, i, j);
                }
            }
            swap(numbers, l, j);
            return j;
        }

        public void swap(List<int> numbers, int i, int j)
        {
            int aux;

            aux = numbers[j];
            numbers[j] = numbers[i];
            numbers[i] = aux;
        }
    }
}
