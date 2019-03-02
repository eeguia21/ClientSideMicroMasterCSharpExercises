using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Total_Waiting_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] times = new int [5];
            Random objR = new Random();
            MinimumTotalWaitingTime objMTWT = new MinimumTotalWaitingTime();

            for (int i = 0; i < times.Length; i++)
                times[i] = objR.Next(1, 10);

            Console.WriteLine(objMTWT.QueuMinimumTotalWaitingTime(times, times.Length));
            Console.ReadLine();
        }
    }

    public class MinimumTotalWaitingTime
    {
        public int QueuMinimumTotalWaitingTime(int [] times, int n)
        {
            int minimumWaitingTime = 0;
            bool[] treated = new bool[n];
            int tmin;
            int index;

            for (int i = 0; i < n; i++)
            {
                tmin = 1000;
                index = 0;
                for (int j = 0; j < n; j++)
                {
                    if (treated[j] == false && times[j] < tmin)
                    {
                        tmin = times[j];
                        index = j;
                    }
                }
                minimumWaitingTime = minimumWaitingTime + ((n - 1 - i) * tmin);
                treated[index] = true;
            }

            return minimumWaitingTime;
        }
    }
}
