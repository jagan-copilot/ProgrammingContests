using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_chosen_one
{
    class Program
    {

        //https://www.hackerrank.com/contests/101hack45/challenges/the-chosen-one
        static void Main(string[] args)
        {
            long n = Convert.ToInt64(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            long[] a = Array.ConvertAll(a_temp, Int64.Parse);

            long divisor = GetSmallestInteger(a, -1);

            long dividentsCount = GetCountOfDividents(a, divisor);

            if (dividentsCount == n - 1)
                Console.WriteLine(divisor);
            else
                divisor = GetSmallestInteger(a, divisor);

            dividentsCount = GetCountOfDividents(a, divisor);

            if (dividentsCount == n - 1)
                Console.WriteLine(divisor);
            else
                Console.WriteLine("-1");

            Console.ReadLine();

        }

        private static long GetCountOfDividents(long[] a, long divisor)
        {
            long count = 0;
            foreach (var item in a)
            {
                if (item % divisor == 0)
                    count++;
            }
            return count;
        }

        private static long GetSmallestInteger(long[] a, long v)
        {
            long tmp = long.MaxValue;

            foreach (var item in a)
            {
                if (item < tmp && item != v)
                    tmp = item;
            }

            return tmp;
        }
    }
}
