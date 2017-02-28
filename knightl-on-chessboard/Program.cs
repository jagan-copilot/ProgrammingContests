using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knightl_on_chessboard
{
    class Program
    {
        //https://www.hackerrank.com/contests/rookierank-2/challenges/knightl-on-chessboard
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] numberOfMoves = GetMinimumMoves(n);
            PrintMinimumMoves(numberOfMoves);
            Console.ReadLine();
        }

        private static void PrintMinimumMoves(int[,] numberOfMoves)
        {
            for (int i = 0; i < numberOfMoves.GetLength(0); i++)
            {
                for (int j = 0; j < numberOfMoves.GetLength(1); j++)
                {
                    Console.Write(numberOfMoves[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] GetMinimumMoves(int n)
        {
            int[,] numberOfMoves = new int[n, n];
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    bool[,] isVisited = new bool[n, n];
                    numberOfMoves[i - 1, j - 1] = GetMinimumMovesKnightL(0, 0, i, j, n, isVisited);
                }
            }

            return numberOfMoves;
        }

        private static int GetMinimumMovesKnightL(int initialX, int initialY, int i, int j, int n, bool[,] isVisited)
        {
            if (initialX == n - 1 && initialY == n - 1)
                return 0;

            else if (initialX >= n || initialY >= n)
                return int.MaxValue;

            else if (initialX < 0 || initialY < 0)
                return int.MaxValue;

            else if (isVisited[initialX, initialY]) return int.MaxValue;

            else
            {
                isVisited[initialX, initialY] = true;

                return 1 + Math.Min(
                    Math.Min(
                        GetMinimumMovesKnightL(initialX + i, initialY + j, i, j, n, isVisited),
                        GetMinimumMovesKnightL(initialX + j, initialY + i, i, j, n, isVisited)),
                    Math.Min(
                        GetMinimumMovesKnightL(initialX - i, initialY - j, i, j, n, isVisited),
                        GetMinimumMovesKnightL(initialX - j, initialY - i, i, j, n, isVisited))
                    );
            }
        }
    }
}
