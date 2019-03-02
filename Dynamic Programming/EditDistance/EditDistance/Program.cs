using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Editing";
            string str2 = "Distance";
            int result = 0;
            EditDistance objCED = new EditDistance();

            char [] string1 = str1.ToUpper().ToArray();
            char [] string2 = str2.ToUpper().ToArray();

            result = objCED.ComputeEditDistance(string1, string2);

            Console.WriteLine(result);

            Console.ReadLine();

        }
    }

    public class EditDistance
    {

        List<char> lstword1 = new List<char>();
        List<char> lstword2 = new List<char>();

        public int ComputeEditDistance(char[] s1, char[] s2)
        {
            int[,] matrix = new int[s1.Length + 1, s2.Length + 1];
            int insertion = 0;
            int deletion = 0;
            int match = 0;
            int mismatch = 0;
            List<List<char>> lst = new List<List<char>>();

            for (int i = 0; i < s1.Length + 1; i++)
                matrix[i, 0] = i;

            for (int j = 0; j < s2.Length + 1; j++)
                matrix[0, j] = j;

            for (int m = 1; m <= s2.Length; m++)
            {
                for (int n = 1; n <= s1.Length; n++)
                {
                    insertion = matrix[n-1, m] + 1;
                    deletion = matrix[n, m - 1] + 1;
                    match = matrix[n - 1, m - 1];
                    mismatch = matrix[n - 1, m - 1] + 1;
                    if (s1[n-1] == s2[m-1])
                        matrix[n, m] = Math.Min(insertion, Math.Min(deletion, match));
                    else
                        matrix[n, m] = Math.Min(insertion, Math.Min(deletion, mismatch));
                }
            }

            for (int x = 0; x < s1.Length + 1; x++)
            {
                for (int y = 0; y < s2.Length + 1; y++)
                    Console.Write(matrix[x, y]);
                Console.WriteLine("");
            }

            ComputeOutputAlignment(s1.Length, s2.Length, matrix, s1, s2);

            for (int o = 0; o <= s1.Length; o++)
                Console.Write(lstword1[o]);

            Console.WriteLine("");

            for (int p = 0; p <= s2.Length; p++)
                Console.Write(lstword2[p]);

            Console.WriteLine("");

            return matrix[s1.Length, s2.Length];
        }

        public int ComputeOutputAlignment(int i, int j, int[,] matrix, char[] s1, char[] s2)
        {
            if (i == 0 && j == 0)
                return 1;
            if (i > 0 && matrix[i, j] == matrix[i - 1, j] + 1)
            {
                ComputeOutputAlignment(i - 1, j, matrix, s1, s2);
                lstword1.Add(s1[i - 1]);
                lstword2.Add('-');
            }
            else if (j > 0 && matrix[i, j] == matrix[i, j - 1] + 1)
            {
                ComputeOutputAlignment(i, j - 1, matrix, s1, s2);
                lstword1.Add('-');
                lstword2.Add(s2[j - 1]);
            }
            else if (i > 0 && j > 0 && matrix[i, j] == matrix[i - 1, j - 1] + 1)
            {
                ComputeOutputAlignment(i - 1, j - 1, matrix, s1, s2);
                lstword1.Add(s1[i - 1]);
                lstword2.Add(s2[j - 1]);
            }
            else if (i > 0 && j > 0 && matrix[i, j] == matrix[i - 1, j - 1])
            {
                ComputeOutputAlignment(i - 1, j - 1, matrix, s1, s2);
                lstword1.Add(s1[i - 1]);
                lstword2.Add(s2[j - 1]);
            }
            return 1;
        }
    }
}
