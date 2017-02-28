using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace big_sorting
{
    //https://www.hackerrank.com/contests/w29/challenges/big-sorting
    class Program
    {
        static void Main(string[] args)
        {
            long n = Convert.ToInt64(Console.ReadLine());
            string[] unsorted = new string[n];
            for (long unsorted_i = 0; unsorted_i < n; unsorted_i++)
            {
                unsorted[unsorted_i] = Console.ReadLine();
            }

            BigSorting(unsorted);

            foreach (var item in unsorted)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void BigSorting(string[] unsorted)
        {
            for (long i = 0; i < unsorted.Length; i++)
            {
                for (long j = i + 1; j < unsorted.Length; j++)
                {
                    SwapItemsIfNotAscending(unsorted, i, j);
                }
            }
        }

        private static void SwapItemsIfNotAscending(string[] unsorted, long i, long j)
        {
            if (SwapRequired(unsorted[i], unsorted[j]))
            {
                string tmp = unsorted[i];
                unsorted[i] = unsorted[j];
                unsorted[j] = tmp;
            }
        }

        private static bool SwapRequired(string v1, string v2)
        {
            if (v1.Length > v2.Length) return true; // if left item length is greater than right side item, swap required
            else if (v1.Length < v2.Length) return false; // if left item length is less than right side item, swap not required
            else 
            {
                for (int i = 0; i < v1.Length; i++)
                {
                    if (v1[i] == v2[i]) continue;
                    if (v1[i] > v2[i]) return true;
                    else return false;
                }
                return false;
            }
        }
    }
}
