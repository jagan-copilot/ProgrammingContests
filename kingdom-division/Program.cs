using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kingdom_division
{
    class Program
    {
        //https://www.hackerrank.com/contests/world-codesprint-9/challenges/kingdom-division
        static void Main(string[] args)
        {
            // number of cities
            int n = Convert.ToInt32(Console.ReadLine());

            Dictionary<int, Tuple<int, List<int>>> kingdom = InitializeCitiesKingdom(n);

            InitializeConnectedCitiesCount(kingdom);

            Console.WriteLine(GetNumberOfWaysOfDivision(kingdom));

            Console.ReadLine();

        }

        private static int GetNumberOfWaysOfDivision(Dictionary<int, Tuple<int, List<int>>> kingdom)
        {
            // connected cities count is not 1 and not even number
            int oddNumberOfConnectedCities = kingdom.Values
                .Where(c => c.Item1 != 1 && c.Item1 >= 2).Count();

            // equal probability of division between two siblings

            return oddNumberOfConnectedCities * 2;
        }

        private static void InitializeConnectedCitiesCount(Dictionary<int, Tuple<int, List<int>>> kingdom)
        {
            GetConnectedCitiesCount(kingdom, kingdom.Keys.FirstOrDefault());
        }

        private static int GetConnectedCitiesCount(Dictionary<int, Tuple<int, List<int>>> kingdom, int currentCity)
        {
            // if no connected cities for current city set number of cities as 1
            if (kingdom[currentCity].Item2.Count == 0)
            {
                kingdom[currentCity] = new Tuple<int, List<int>>(1, kingdom[currentCity].Item2);
                return 1;
            }

            else
            {
                int numberOfCities = 1;
                // repeat for each city
                kingdom[currentCity].Item2.ForEach(c =>
                {
                    numberOfCities += GetConnectedCitiesCount(kingdom, c);
                });
                kingdom[currentCity] = new Tuple<int, List<int>>(numberOfCities, kingdom[currentCity].Item2);
                return numberOfCities;
            }
        }

        private static Dictionary<int, Tuple<int, List<int>>> InitializeCitiesKingdom(int n)
        {
            Dictionary<int, Tuple<int, List<int>>> kingdom = new Dictionary<int, Tuple<int, List<int>>>();

            for (int i = 0; i < n; i++)
            {
                kingdom.Add(i + 1, new Tuple<int, List<int>>(1, new List<int>()));
            }

            for (int a0 = 0; a0 < n - 1; a0++)
            {
                string[] tokens_u = Console.ReadLine().Split(' ');
                int u = Convert.ToInt32(tokens_u[0]);
                int v = Convert.ToInt32(tokens_u[1]);

                // kingdom already has city u, add road to city v, 
                // otherwise add it as a new city

                List<int> connectedCities = kingdom[u].Item2;
                connectedCities.Add(v);

                if (kingdom.Keys.Contains(u))
                    kingdom[u] = new Tuple<int, List<int>>(1, connectedCities);
            }

            return kingdom;
        }
    }
}
