using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace permutation_equation
{
    class Program
    {
        //https://www.hackerrank.com/contests/101hack45/challenges/permutation-equation
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] permutations = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            PrintPermutationEquation(permutations);

            Console.ReadLine();
        }

        private static void PrintPermutationEquation(int[] permutations)
        {
            for (int i = 0; i < permutations.Length; i++)
            {
                int indexOfx = Array.IndexOf(permutations, i + 1);
                indexOfx = Array.IndexOf(permutations, indexOfx + 1);
                Console.WriteLine(indexOfx + 1);
            }

        }
    }
}
