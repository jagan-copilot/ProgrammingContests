using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimum_absolute_difference_in_an_array
{
    class Program
    {
        //https://www.hackerrank.com/contests/rookierank-2/challenges/minimum-absolute-difference-in-an-array
        static void Main(string[] args)
        {
            long n = Convert.ToInt64(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            long[] a = Array.ConvertAll(a_temp, Int64.Parse);

            long minAbsoluteDifference = GetMinimumAbsoluteDifference(a,n);

            Console.WriteLine(minAbsoluteDifference);

            Console.Read();
        }

        private static long GetMinimumAbsoluteDifference(long[] a, long n)
        {
            long minAbsoluteDifference = long.MaxValue;
            long tmp_Difference = 0;
            for (long i = 0; i < a.Length-1; i++)
            {
                for (long j = i+1; j < a.Length; j++)
                {
                    tmp_Difference = Math.Abs(a[i] - a[j]);
                    if (minAbsoluteDifference > tmp_Difference)
                        minAbsoluteDifference = tmp_Difference;
                }
            }
            return minAbsoluteDifference;
        }
    }
}
