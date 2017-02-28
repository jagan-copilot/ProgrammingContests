using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breaking_best_and_worst_records
{
    class Program
    {
        //https://www.hackerrank.com/contests/university-codesprint-2/challenges/breaking-best-and-worst-records
        static void Main(string[] args)
        {

            long n = Convert.ToInt64(Console.ReadLine());
            string[] score_temp = Console.ReadLine().Split(' ');
            long[] score = Array.ConvertAll(score_temp, Int64.Parse);

            long NumberOfRecordsForMost;
            long NumberOfRecordsForLeast;

            GetNumberOfRecords(score, out NumberOfRecordsForMost, out NumberOfRecordsForLeast);

            Console.WriteLine("{0} {1}", NumberOfRecordsForMost, NumberOfRecordsForLeast);

            Console.ReadLine();

        }

        private static void GetNumberOfRecords(long[] score, out long numberOfRecordsForMost, out long numberOfRecordsForLeast)
        {
            numberOfRecordsForMost = 0;
            numberOfRecordsForLeast = 0;
            long initialRecordMost = score[0];
            long initialRecordLeast = score[0];

            for (long i = 0; i < score.Length; i++)
            {
                if(score[i] > initialRecordMost)
                {
                    numberOfRecordsForMost++;
                    initialRecordMost = score[i];
                }
                else if(score[i] < initialRecordLeast)
                {
                    numberOfRecordsForLeast++;
                    initialRecordLeast = score[i];
                }
            }
        }
    }
}
