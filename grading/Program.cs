using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grading
{
    class Program
    {
        //https://www.hackerrank.com/contests/world-codesprint-9/challenges/grading
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] grades = InitializeGrades(n);

            RoundOfGrades(grades);

            PrintGrades(grades);

            Console.ReadLine();
        }

        private static void PrintGrades(int[] grades)
        {
            foreach (var item in grades)
            {
                Console.WriteLine(item);
            }
        }

        private static void RoundOfGrades(int[] grades)
        {
            for (int i = 0; i < grades.Length; i++)
            {
                int gradeValue = grades[i];
                int nextFiveMultiple = gradeValue + (5 - gradeValue % 5);

                if (gradeValue < 38) continue;
                if(nextFiveMultiple-gradeValue <3)
                {
                    grades[i] = nextFiveMultiple;
                }
            }
        }

        private static int[] InitializeGrades(int n)
        {
            int[] grades = new int[n];

            for (int i = 0; i < n; i++)
            {
                grades[i] = Convert.ToInt32(Console.ReadLine());
            }

            return grades;
        }
    }
}
