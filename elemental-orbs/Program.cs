using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_hell
{
    class Program
    {
        //https://www.hackerrank.com/contests/codeagon/challenges/elemental-orbs
        static void Main(string[] args)
        {
            // number of queries to perform
            int q = Convert.ToInt32(Console.ReadLine());
            string[] tmp_depencies = new string[q];

            string[] sequenceOfInstallationsForEachQuery = new string[q];

            for (int i = 0; i < q; i++)
            {

                string[] tmp_firstLine = Console.ReadLine().Split(' ');

                // number of total programs
                int n = Convert.ToInt32(tmp_firstLine[0]);

                // number of installations to be performed.
                int m = Convert.ToInt32(tmp_firstLine[0]);

                Dictionary<int, List<int>> depencies = InitializeDependencies(n);

                int[] programsToInstall = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

                sequenceOfInstallationsForEachQuery[i] = GetInstallationsSequence(depencies, programsToInstall);
            }

            for (int i = 0; i < q; i++)
            {
                Console.WriteLine(sequenceOfInstallationsForEachQuery[i].Split(' ').Count());
                Console.WriteLine(sequenceOfInstallationsForEachQuery[i]);
            }

            Console.ReadLine();
        }

        private static string GetInstallationsSequence(Dictionary<int, List<int>> depencies, int[] programsToInstall)
        {
            List<int> sequenceOfInstallations = new List<int>();

            for (int i = 0; i < programsToInstall.Length; i++)
            {
                List<int> dependenciesToInstallForProgram = new List<int>();
                GetInstallationSequence_internal(depencies, programsToInstall[i] - 1, dependenciesToInstallForProgram);
                dependenciesToInstallForProgram.Add(programsToInstall[i] - 1);
                AddDependencySequenceLexicographically(sequenceOfInstallations, dependenciesToInstallForProgram);
            }

            return string.Join(" ", sequenceOfInstallations.Select(i => i + 1).ToList<int>());
        }

        private static void AddDependencySequenceLexicographically(List<int> sequenceOfInstallations, List<int> dependenciesToInstallForProgram)
        {
            int dependencyIndex = -1;

            if (sequenceOfInstallations.Count == 0)
            { sequenceOfInstallations.AddRange(dependenciesToInstallForProgram); }
            else
            {
                foreach (var item in dependenciesToInstallForProgram)
                {
                    if (sequenceOfInstallations.Contains(item))
                    {
                        dependencyIndex = sequenceOfInstallations.IndexOf(item);
                        continue;
                    }
                    else
                    {
                        int currentIndex = dependencyIndex + 1;
                        while (currentIndex <= sequenceOfInstallations.Count() - 1 
                            && sequenceOfInstallations[currentIndex] < item)
                            currentIndex++;
                        sequenceOfInstallations.Insert(currentIndex, item);
                        dependencyIndex = currentIndex;
                    }
                }
            }
        }

        private static void GetInstallationSequence_internal(Dictionary<int, List<int>> depencies, int v, List<int> dependenciesToInstallForProgram)
        {

            int currentProgram = v;

            if (depencies[currentProgram].Count != 0)
            {
                depencies[currentProgram].Sort();
                depencies[currentProgram].ForEach(d =>
                {
                    GetInstallationSequence_internal(depencies, d - 1, dependenciesToInstallForProgram);

                    // install the dependency if it is not installed yet.
                    if (!dependenciesToInstallForProgram.Contains(d - 1))
                        dependenciesToInstallForProgram.Add(d - 1);
                });
            }

        }

        private static Dictionary<int, List<int>> InitializeDependencies(int n)
        {
            Dictionary<int, List<int>> dependencies = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                string[] tmp_dependency = Console.ReadLine().Split(' ');
                int numberOfdepencies = Convert.ToInt32(tmp_dependency[0]);

                List<int> dependenciesForthisProgram = new List<int>();
                // add depency for each item
                while (numberOfdepencies > 0)
                {
                    dependenciesForthisProgram.Add(Convert.ToInt32(tmp_dependency[numberOfdepencies]));
                    numberOfdepencies--;
                }

                dependencies[i] = dependenciesForthisProgram;
            }

            return dependencies;
        }
    }
}
