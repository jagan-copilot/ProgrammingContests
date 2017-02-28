using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_of_two_stacks
{
    class Program
    {
        //https://www.hackerrank.com/contests/university-codesprint-2/challenges/game-of-two-stacks
        static void Main(string[] args)
        {
            long g = Convert.ToInt64(Console.ReadLine());
            long[] scores = new long[g];

            for (long a0 = 0; a0 < g; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                long n = Convert.ToInt64(tokens_n[0]);
                long m = Convert.ToInt64(tokens_n[1]);
                long x = Convert.ToInt64(tokens_n[2]);
                string[] a_temp = Console.ReadLine().Split(' ');
                long[] a = Array.ConvertAll(a_temp, Int64.Parse);
                string[] b_temp = Console.ReadLine().Split(' ');
                long[] b = Array.ConvertAll(b_temp, Int64.Parse);
                // your code goes here

                scores[a0] = Math.Max(Math.Max(GetScoreFromBothStacks(a, b, x), GetScoreFromSingleStack(a,b, x)),
                    GetScoreFromSingleStack(b,a, x));
            }

            foreach (var item in scores)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        private static long GetScoreFromBothStacks(long[] a, long[] b, long x)
        {
            long score = 0;
            long aIndex = 0;
            long bIndex = 0;
            while (aIndex < a.Length && bIndex < b.Length)
            {
                if (a[aIndex] <= b[bIndex])
                {
                    x -= a[aIndex];
                    aIndex++;
                }
                else if (a[aIndex] > b[bIndex])
                {
                    x -= b[bIndex];
                    bIndex++;
                }

                if (x >= 0) score++;
                else break;
            }

            return score;
        }

        private static long GetScoreFromSingleStack(long[] a, long[] b, long x)
        {
            long score = 0;
            long aIndex = 0;
            long bIndex = 0;

            // read from first Stack
            while (aIndex < a.Length)
            {
                x -= a[aIndex];
                aIndex++;

                if (x >= 0) score++;
                else break;
            }

            // read from second Stack
            while (bIndex < b.Length)
            {
                x -= b[bIndex];
                bIndex++;

                if (x >= 0) score++;
                else break;
            }
            return score;
        }
    }
}
