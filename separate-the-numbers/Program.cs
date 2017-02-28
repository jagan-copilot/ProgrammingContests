using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace separate_the_numbers
{
    class Program
    {
        //https://www.hackerrank.com/contests/university-codesprint-2/challenges/separate-the-numbers
        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            string[] s = new string[q];
            for (int a0 = 0; a0 < q; a0++)
            {
                s[a0] = Console.ReadLine();
            }

            foreach (var item in s)
            {
                long firstNumber;
                Console.WriteLine(IsBeautifulString(item, out firstNumber) ? "YES " + firstNumber : "NO");
            }

            Console.ReadLine();
        }

        private static bool IsBeautifulString(string item, out long firstNumber)
        {
            int length = 1;
            do
            {
                firstNumber = long.Parse(item.Substring(0, length));
                string expectedBeautifulString = BuildBeautifulString(firstNumber, item.Length);
                if (item.Equals(expectedBeautifulString) 
                    && !item.Equals(firstNumber.ToString())) return true;
                length++;
            }
            while (length <= item.Length/2);
            return false;
        }

        private static string BuildBeautifulString(long firstNumber, int length)
        {
            StringBuilder builder = new StringBuilder();
            while (builder.Length < length)
            {
                builder.Append(firstNumber);
                firstNumber++;
            }
            return builder.ToString();
        }
    }
}
