using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_to_origin
{
    class Program
    {
        //https://www.hackerrank.com/contests/codeagon/challenges/back-to-origin
        static void Main(string[] args)
        {
            string[] tokens_xTreasure = Console.ReadLine().Split(' ');
            long xTreasure = Convert.ToInt64(tokens_xTreasure[0]);
            long yTreasure = Convert.ToInt64(tokens_xTreasure[1]);

            int n = Convert.ToInt32(Console.ReadLine());

            long[][] direction = new long[n][];

            for (int direction_i = 0; direction_i < n; direction_i++)
            {
                string[] direction_temp = Console.ReadLine().Split(' ');
                direction[direction_i] = Array.ConvertAll(direction_temp, Int64.Parse);
            }

            long xTravelled =0, yTravelled=0;

            for (int i = 0; i < direction.Length; i++)
            {
                xTravelled += direction[i][0];
                yTravelled += direction[i][1];
            }

            long xHome = xTreasure - xTravelled;
            long yHome = yTreasure - yTravelled;

            Console.WriteLine(xHome + " " + yHome);

            Console.ReadLine();
        }
    }
}
