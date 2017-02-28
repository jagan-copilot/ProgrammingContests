using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_of_the_programmer
{
    //https://www.hackerrank.com/contests/w29/challenges/day-of-the-programmer
    class Program
    {
        static void Main(string[] args)
        {
            int y = Convert.ToInt32(Console.ReadLine());
            string dayOf256 = GetnthDayOfYear(y, 256);
            Console.WriteLine(dayOf256);
            Console.ReadLine();
        }

        private static string GetnthDayOfYear(int y, int n)
        {
            int[] daysInMonth = InitializeDaysInMonth(y);
            int currentMonth = 0;

            for (int i = 0; i < daysInMonth.Length; i++)
            {
                if (n >= daysInMonth[i])
                    n = n - daysInMonth[i];
                else
                {
                    currentMonth = i;
                    break;
                }
            }
            return string.Format("{0}.{1}.{2}", n, GetMonthFormat(currentMonth + 1), y);
        }

        private static string GetMonthFormat(int currentMonth)
        {
            if (currentMonth < 10) return "0" + currentMonth;
            else return "" + currentMonth;
        }

        private static int[] InitializeDaysInMonth(int y)
        {
            int[] daysInMonths = new int[12];

            daysInMonths[0] = 31;
            daysInMonths[1] = GetNumberOfDaysInFebruary(y);
            daysInMonths[2] = 31;
            daysInMonths[3] = 30;
            daysInMonths[4] = 31;
            daysInMonths[5] = 30;
            daysInMonths[6] = 31;
            daysInMonths[7] = 31;
            daysInMonths[8] = 30;
            daysInMonths[9] = 31;
            daysInMonths[10] = 30;
            daysInMonths[11] = 31;
            return daysInMonths;

        }

        private static int GetNumberOfDaysInFebruary(int y)
        {
            // is julian calendar
            if (y >= 1700 && y <= 1917)
            {
                if (y % 4 == 0) return 29;
                else return 28;
            }

            // is Gregorian calendar
            else if (y >= 1919 && y <= 2700)
            {
                if (y % 400 == 0 || (y % 4 == 0 && y % 100 != 0)) return 29;
                else return 28;
            }

            // is year 1918
            else if (y == 1918)
                return (28 - 14); // During transition first day after Jan31st is Feb 14th.

            else
                return 0;
        }
    }
}
