//CountSort
//Edgar Eguía Calcáneo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Random objR = new Random();
            CountSort objCS = new CountSort();

            for (int i = 0; i < 10; i++)
                numbers.Add(objR.Next(0, 9));

            for (int i = 0; i < 10; i++)
                Console.WriteLine(objCS.ComputeCountSort(numbers)[i]);

            Console.ReadLine();
        }
    }

    public class CountSort
    {
        public List<int> ComputeCountSort(List<int> numbers)
        {
            List<int> numbersSorted = new List<int>();
            List<int> counts = new List<int>();
            List<int> positions = new List<int>();

            for (int c = 0; c < numbers.Count; c++)
            {
                counts.Add(0);
                positions.Add(0);
                numbersSorted.Add(0);
            }

            for (int i = 0; i < numbers.Count; i++)
                counts[numbers[i]] = counts[numbers[i]] + 1;

            for (int j = 1; j < counts.Count; j++)
                positions[j] = positions[j-1] + counts[j-1];

            for (int k = 0; k < numbers.Count; k++)
            {
                numbersSorted[positions[numbers[k]]] = numbers[k];
                positions[numbers[k]] = positions[numbers[k]] + 1;
            }

            return numbersSorted;
        }
    }
}
