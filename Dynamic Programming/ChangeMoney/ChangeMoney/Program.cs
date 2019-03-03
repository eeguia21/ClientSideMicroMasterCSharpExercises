//ChangeMoney
//Edgar Eguía Calcáneo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMoney
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = 10;
            int[] coins = new int[3] {1, 5, 6};
            List<int> result = new List<int>();

            DPChangeMoney objDPChangeMoney = new DPChangeMoney();
            result.AddRange(objDPChangeMoney.ComputeDPChangeMoney(money, coins));

            for (int i = 0; i < 10; i++)
                Console.WriteLine(result[i]);

            Console.ReadLine();
        }
    }

    public class DPChangeMoney
    {
        public List<int> ComputeDPChangeMoney(int money, int [] coins)
        {
            List<int> minNumCoins = new List<int>();
            int numCoins = 0;

            for (int i = 0; i < money; i++)
                minNumCoins.Add(0);

            for (int m = 1; m < money; m++)
            {
                minNumCoins[m] = 1000;
                for (int n = 0; n < coins.Length; n++)
                {
                    if (m >= coins[n])
                    {
                        numCoins = minNumCoins[m - coins[n]] + 1;
                        if (numCoins < minNumCoins[m])
                            minNumCoins[m] = numCoins;
                    }
                }
            }

            return minNumCoins;
        }
    }
}
