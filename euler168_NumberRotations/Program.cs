using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euler168_NumberRotations
{
    //https://www.hackerrank.com/contests/projecteuler/challenges/euler168
    //Number Rotations
    class Program
    {
        static void Main(string[] args)
        {
            int m = Convert.ToInt32(Console.ReadLine());

            double lowerBound = 10;
            double upperBound = Math.Pow(10, m);

            string last5digits = GetLast5DigitsOfSumOfIntegers(lowerBound, upperBound);

            Console.WriteLine(last5digits);

            Console.ReadLine();
        }

        private static string GetLast5DigitsOfSumOfIntegers(double lowerBound, double upperBound)
        {
            double currentNumber = lowerBound;
            double sum = 0;
            while (currentNumber <= upperBound)
            {
                string str_currentNumber = currentNumber.ToString();
                if (str_currentNumber[0] >= str_currentNumber[1])
                {
                    double tmp_rotatedNumber = RightRotateNumber(currentNumber);
                    if (tmp_rotatedNumber % currentNumber == 0)
                        sum += currentNumber;
                }
                currentNumber++;
            }

            string result = sum.ToString();
            return result.Length > 5 ? result.Substring(result.Length - 5) : result;
        }

        private static double RightRotateNumber(double currentNumber)
        {
            string str_currentNumber = currentNumber.ToString();
            char firstChar = str_currentNumber[0];
            str_currentNumber = str_currentNumber.Substring(1) + firstChar;
            return Double.Parse(str_currentNumber);
        }
    }
}
