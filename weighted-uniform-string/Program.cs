using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weighted_uniform_string
{
    class Program
    {
        //https://www.hackerrank.com/contests/world-codesprlong-9/challenges/weighted-uniform-string
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            long n = Convert.ToInt64(Console.ReadLine());

            long[] x = InitializeQueries(n);

            bool[] queryResults = new bool[n];

            // process each query and check if these are subset of uniform string weights

            queryResults = CheckIFQuerySubsetOfWeights(s, x);

            PrintResults(queryResults);

            Console.ReadLine();
        }

        private static bool[] CheckIFQuerySubsetOfWeights(string s, long[] q)
        {
            bool[] results = new bool[q.Length];

            Dictionary<char, long> table = InitializeWeights();

            HashSet<long> uniformStringWeights = InitializeUniformStringWeights(s, table);

            for (long i = 0; i < q.Length; i++)
            {
                results[i] = (uniformStringWeights.Contains(q[i]));
            }
            return results;
        }

        private static HashSet<long> InitializeUniformStringWeights(string s, Dictionary<char, long> table)
        {
            Dictionary<string, long> uniformStringMaxWeights = new Dictionary<string, long>();
            HashSet<long> variableWeights = new HashSet<long>();
            char previousChar = '\0';
            foreach (var c in s)
            {
                if (uniformStringMaxWeights.ContainsKey(c.ToString()))
                {
                    if (previousChar == c)
                    {
                        long weight = Convert.ToInt64(uniformStringMaxWeights[c.ToString()]) + Convert.ToInt64(table[c]);
                        uniformStringMaxWeights[c.ToString()] = weight;
                        variableWeights.Add(weight);
                    }

                }
                else
                {
                    long weight = Convert.ToInt64(table[c]);
                    uniformStringMaxWeights.Add(c.ToString(), weight);
                    variableWeights.Add(weight);
                }
                previousChar = c;
            }

            return variableWeights;
        }

        private static Dictionary<char, long> InitializeWeights()
        {
            Dictionary<char, long> table = new Dictionary<char, long>();
            for (char c = 'a'; c < 'z'; c++)
            {
                table.Add(c, c - 'a' + 1);
            }
            return table;

        }

        private static void PrintResults(bool[] queryResults)
        {
            foreach (var item in queryResults)
            {
                Console.WriteLine(item ? "Yes" : "No");
            }
        }

        private static long[] InitializeQueries(long n)
        {
            long[] queries = new long[n];
            for (long i = 0; i < n; i++)
            {
                queries[i] = Convert.ToInt64(Console.ReadLine());
            }

            return queries;
        }
    }
}
