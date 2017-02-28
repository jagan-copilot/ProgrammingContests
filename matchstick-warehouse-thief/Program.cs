using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matchstick_warehouse_thief
{
    class Program
    {
        //https://www.hackerrank.com/contests/codeagon/challenges/matchstick-warehouse-thief
        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            long n = Convert.ToInt64(tokens_n[0]);
            long c = Convert.ToInt64(tokens_n[1]);

            long[][] crate = new long[c][];
            for (long crate_i = 0; crate_i < c; crate_i++)
            {
                string[] crate_temp = Console.ReadLine().Split(' ');
                crate[crate_i] = Array.ConvertAll(crate_temp, Int64.Parse);
            }

            Console.WriteLine(GetMaximumMatchSticks(crate, n, c));
            Console.ReadLine();
        }

        private static long GetMaximumMatchSticks(long[][] crate, long n, long c)
        {
            long maxCrateIndex = -1;
            long matchSticks = 0;

            while (n > 0)
            {
                maxCrateIndex = GetMaximumMatchSticksCrate(crate);

                if (maxCrateIndex == -1) break;
                long numberOfBoxesInCrate = crate[maxCrateIndex][0];
                if (n >= numberOfBoxesInCrate)
                {
                    n = n - numberOfBoxesInCrate;
                    crate[maxCrateIndex][0] = 0;
                }
                else
                {
                    numberOfBoxesInCrate = n;
                    n = 0;
                }


                matchSticks += numberOfBoxesInCrate * crate[maxCrateIndex][1];

            }

            return matchSticks;
        }

        private static long GetMaximumMatchSticksCrate(long[][] crate)
        {
            long tmpMax = long.MinValue;
            long tmpMaxIndex = -1;
            for (long i = 0; i < crate.GetLength(0); i++)
            {
                if (tmpMax < crate[i][1] && crate[i][0] != 0)
                {
                    tmpMax = crate[i][1];
                    tmpMaxIndex = i;
                }
            }

            return tmpMaxIndex;
        }
    }
}
