using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] numbers = new int [10];
            Random objR = new Random();
            SelectionSort objSS = new SelectionSort();

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = objR.Next(1, 15);

            for (int i = 0; i < numbers.Length; i++)
                Console.WriteLine(objSS.ComputeSelectionSort(numbers)[i]);

            Console.ReadLine();
        }
    }

    public class SelectionSort
    {
        public int [] ComputeSelectionSort(int [] numbers)
        {
            int minIndex = 0;
            int aux = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                minIndex = i;
                for (int j = i+1; j < numbers.Length; j++)
                    if (numbers[minIndex] > numbers[j])
                        minIndex = j;
                aux = numbers[i];
                numbers[i] = numbers[minIndex];
                numbers[minIndex] = aux;
            }

            return numbers;
        }
    }
}
