using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mlp
{
    class Program
    {
        //https://www.hackerrank.com/contests/101hack45/challenges/mlp
        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);

            int numberOfEdges = InitializeLayers(n, k);
            if (numberOfEdges != -1)
                numberOfEdges += AppendVerticesToLayers(n - k, k - 2);
            Console.WriteLine(numberOfEdges);

            Console.ReadLine();
        }

        private static int AppendVerticesToLayers(int v, int k)
        {
            if (v == 0) return 0;
            else if (v <= k)
            {
                return v + 1;
            }
            else
            {
                v = v - k;
                return (k + 1) + AppendVerticesToLayers(v, k);
            }
        }

        private static int InitializeLayers(int n, int k)
        {
            if (n < k) return -1;
            if (n == k && k == 2) return 1;
            if (n > k && k == 2) return -1;
            else return k - 1;
        }
    }
}
