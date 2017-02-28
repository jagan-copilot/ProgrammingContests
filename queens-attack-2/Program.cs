using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queens_attack_2
{
    class Program
    {
        //https://www.hackerrank.com/contests/world-codesprint-9/challenges/queens-attack-2
        static void Main(string[] args)
        {
            string[] tmp_firstLine = Console.ReadLine().Split(' ');

            // length of board
            long n = Convert.ToInt64(tmp_firstLine[0]);

            // number of obstacles
            long k = Convert.ToInt64(tmp_firstLine[1]);

            long[] queenPosition = Array.ConvertAll(Console.ReadLine().Split(' '), Int64.Parse);
            queenPosition[0] = n - queenPosition[0] + 1;

            HashSet<long> obstacles = new HashSet<long>();

            //bool[,] obstacles = new bool[n, n];

            InitializeObstacles(obstacles, k, n);

            Console.WriteLine(GetNumberOfPossibleAttacks(queenPosition, obstacles, n, k));

            Console.ReadLine();
        }

        private static void InitializeObstacles(HashSet<long> obstacles, long k, long n)
        {
            for (long i = 0; i < k; i++)
            {
                long[] positions = Array.ConvertAll(Console.ReadLine().Split(' '), Int64.Parse);
                obstacles.Add((n - positions[0]) * n + positions[1] - 1);
                //obstacles[n - positions[0], positions[1] - 1] = true;
            }
        }

        private static long GetNumberOfPossibleAttacks(long[] queenPosition, HashSet<long> obstacles, long n, long k)
        {
            long countOfAttacks = 0;

            // right moves
            countOfAttacks += GetRowMoveAttacks(queenPosition, obstacles, n, k);
            countOfAttacks += GetColumnMoveAttacks(queenPosition, obstacles, n, k);
            countOfAttacks += GetDiagonal1MoveAttacks(queenPosition, obstacles, n, k);
            countOfAttacks += GetDiagonal2MoveAttacks(queenPosition, obstacles, n, k);

            return countOfAttacks;
        }

        private static long GetRowMoveAttacks(long[] queenPosition, HashSet<long> obstacles, long n, long k)
        {
            long rq = queenPosition[0] - 1;
            long cq = queenPosition[1] - 1;

            long countOfAttacks = 0;
            // Count right side moves if queen is not in first column
            if (cq > 0)
            {
                for (long i = cq - 1; i >= 0; i--)
                {
                    //if (!obstacles[rq, i]) countOfAttacks++;
                    if (!obstacles.Contains(rq * n + i)) countOfAttacks++;
                    else break;
                }
            }

            // Count right side moves if queen is not in first column
            if (cq < n)
            {
                for (long i = cq + 1; i <= n - 1; i++)
                {
                    //if (!obstacles[rq, i]) countOfAttacks++;
                    if (!obstacles.Contains(rq * n + i)) countOfAttacks++;
                    else break;
                }
            }

            return countOfAttacks;

        }

        private static long GetColumnMoveAttacks(long[] queenPosition, HashSet<long> obstacles, long n, long k)
        {
            long rq = queenPosition[0] - 1;
            long cq = queenPosition[1] - 1;

            long countOfAttacks = 0;
            // Count top moves if queen is not in row column
            if (rq < n - 1)
            {
                for (long j = rq + 1; j <= n - 1; j++)
                {
                    //if (!obstacles[j, cq]) countOfAttacks++;
                    if (!obstacles.Contains(j * n + cq)) countOfAttacks++;
                    else break;
                }
            }

            // Count right side moves if queen is not in first column
            if (rq > 0)
            {
                for (long j = rq - 1; j >= 0; j--)
                {
                    //if (!obstacles[j, cq]) countOfAttacks++;
                    if (!obstacles.Contains(j * n + cq)) countOfAttacks++;
                    else break;
                }
            }

            return countOfAttacks;

        }

        private static long GetDiagonal1MoveAttacks(long[] queenPosition, HashSet<long> obstacles, long n, long k)
        {
            long rq = queenPosition[0] - 1;
            long cq = queenPosition[1] - 1;

            long countOfAttacks = 0;
            // Count top left moves if queen is not in top first position
            if (rq < n - 1 && cq > 0)
            {
                long i = rq + 1;
                long j = cq - 1;
                while (i <= n - 1 && j >= 0)
                {
                    //if (!obstacles[i, j]) countOfAttacks++;
                    if (!obstacles.Contains(i * n + j)) countOfAttacks++;
                    else break;
                    i++;
                    j--;
                }
            }

            // Count right side moves if queen is not in first column
            if (rq > 0 && cq < n - 1)
            {
                long i = rq - 1;
                long j = cq + 1;
                while (i >= 0 && j <= n - 1)
                {
                    //if (!obstacles[i, j]) countOfAttacks++;
                    if (!obstacles.Contains(i * n + j)) countOfAttacks++;
                    else break;
                    i--;
                    j++;
                }
            }

            return countOfAttacks;

        }

        private static long GetDiagonal2MoveAttacks(long[] queenPosition, HashSet<long> obstacles, long n, long k)
        {
            long rq = queenPosition[0] - 1;
            long cq = queenPosition[1] - 1;

            long countOfAttacks = 0;
            // Count top left moves if queen is not in top first position
            if (rq < n - 1 && cq < n - 1)
            {
                long i = rq + 1;
                long j = cq + 1;
                while (i <= n - 1 && j <= n - 1)
                {
                    //if (!obstacles[i, j]) countOfAttacks++;
                    if (!obstacles.Contains(i * n + j)) countOfAttacks++;
                    else break;
                    i++;
                    j++;
                }
            }

            // Count right side moves if queen is not in first column
            if (rq > 0 && cq > 0)
            {
                long i = rq - 1;
                long j = cq - 1;
                while (i >= 0 && j >= 0)
                {
                    //if (!obstacles[i, j]) countOfAttacks++;
                    if (!obstacles.Contains(i * n + j)) countOfAttacks++;
                    else break;
                    i--;
                    j--;
                }
            }

            return countOfAttacks;

        }
    }
}
