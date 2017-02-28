using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migratory_birds
{
    class Program
    {
        //https://www.hackerrank.com/contests/rookierank-2/challenges/migratory-birds
        static void Main(string[] args)
        {
            // number of types
            long n = Convert.ToInt64(Console.ReadLine());

            // birds type array
            string[] types_temp = Console.ReadLine().Split(' ');
            long[] types = Array.ConvertAll(types_temp, Int64.Parse);

            long[] typesOccurances = GetOccurancesOfBirdTypes(types, n);

            PrintMaximumOccuranceBirdType(typesOccurances);
            Console.ReadLine();
        }

        private static void PrintMaximumOccuranceBirdType(long[] typesOccurances)
        {
            long tmp_MaxOccurance = -1;
            long tmp_type = 0;

            for (int i = 0; i < typesOccurances.Length; i++)
            {
                if (tmp_MaxOccurance < typesOccurances[i])
                {
                    tmp_MaxOccurance = typesOccurances[i];
                    tmp_type = i;
                }
            }
            Console.WriteLine(tmp_type);
        }

        private static long[] GetOccurancesOfBirdTypes(long[] types, long n)
        {
            long[] typesOccurances = new long[n];

            for (long i = 0; i < n; i++)
            {
                typesOccurances[i] = 0;
            }

            foreach (var item in types)
            {
                typesOccurances[item]++;
            }
            return typesOccurances;
        }
    }
}
