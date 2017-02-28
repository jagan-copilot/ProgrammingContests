using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerrank_in_a_string
{
    class Program
    {
        //https://www.hackerrank.com/contests/rookierank-2/challenges/hackerrank-in-a-string
        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            string[] s = new string[q];
            for (int a0 = 0; a0 < q; a0++)
            {
                s[a0] = Console.ReadLine();
            }

            bool[] result = AreStringsHackerRank(s,q);

            PrintResults(result);

            Console.ReadLine();
        }

        private static void PrintResults(bool[] result)
        {
            foreach (var b in result)
            {
                Console.WriteLine(b ? "YES" : "NO");
            }
        }

        private static bool[] AreStringsHackerRank(string[] s, int q)
        {
            bool[] results = new bool[q];

            for (int currentStringIndex = 0; currentStringIndex < s.Length; currentStringIndex++)
            {
                string currentstring = s[currentStringIndex];

                results[currentStringIndex] = IsStringHackerRank(currentstring);
            }
            return results;
        }

        private static bool IsStringHackerRank(string currentstring)
        {
            bool result = false;
            char[] hackerRank = "hackerrank".ToCharArray();
            int indexOfhackerRank = 0;

            for (int i = 0; i < currentstring.Length && indexOfhackerRank < hackerRank.Length; i++)
            {
                if (currentstring[i] == hackerRank[indexOfhackerRank])
                {
                    indexOfhackerRank++;
                }
            }

            if (indexOfhackerRank == hackerRank.Length) result = true;

            return result;
        }
    }
}
