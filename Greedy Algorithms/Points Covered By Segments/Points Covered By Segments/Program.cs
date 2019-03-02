using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points_Covered_By_Segments
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] points = new int[10];
            int[] pointsSorted = new int[10];
            Random objR = new Random();
            PointsCoveredBySegments objPCBS = new PointsCoveredBySegments();

            for (int i = 0; i < points.Length; i++)
                points[i] = objR.Next(2, 16);

            pointsSorted = points.ToArray().OrderBy(x => x).ToArray();
            for (int i = 0; i < pointsSorted.Length; i ++)
                Console.WriteLine(objPCBS.GetMinimumNumberOfSegments(pointsSorted)[i]);
            Console.ReadLine();
        }
    }

    public class PointsCoveredBySegments
    {
        public List<int> GetMinimumNumberOfSegments(int [] pointsSorted)
        {
            int left = 0;
            int right = 0;
            List<int> segments = new List<int>();
            
            while (left < pointsSorted.Length)
            {
                segments.Add(pointsSorted[left]);
                segments.Add(pointsSorted[left]+2);
                right = pointsSorted[left] + 2;
                left = left + 1;
                while (left < pointsSorted.Length && (pointsSorted[left]) <= right)
                    left++;
            }

            return segments;
        }
    }
}
