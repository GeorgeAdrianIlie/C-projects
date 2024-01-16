using System;
using System.Collections.Generic;

namespace DominoSolution
{
    public static class Program
    {
        public static List<string> CreateDominoSolution(int xorSeries, List<string> pairsList)
        {
            if (xorSeries == 1)
            {
                return pairsList;
            }

            List<string> temporary = CreateDominoSolution(xorSeries - 1, pairsList);
            List<string> final = new List<string>();

            foreach (var text in temporary)
            {
                string tempChain = text;
                for (int i = 0; i < pairsList.Count; i++)
                {
                    string previous = text[^3..];
                    string current = pairsList[i];
                    const string space = " ";
                    if (Fits(previous, current) && NotUsed(tempChain, current))
                    {
                        string newChain = string.Empty;
                        newChain += tempChain + space + current;
                        final.Add(newChain);
                    }
                }
            }

            return final;
        }

        private static List<string> ReadAllDominoPieces(int numberOfDominoPairs)
        {
            List<string> list = new ();
            for (int i = 0; i < numberOfDominoPairs; i++)
            {
                list.Add(Console.ReadLine());
            }

            return list;
        }

        static void Main()
        {
            int numberOfDominoPairs = int.Parse(Console.ReadLine());
            List<string> pairsList = ReadAllDominoPieces(numberOfDominoPairs);
            int xorSeries = int.Parse(Console.ReadLine());
            List<string> solutions = CreateDominoSolution(xorSeries, pairsList);

            if (solutions.Count == 0)
            {
                Console.WriteLine("N/A");
            }
            else
            {
                foreach (string list in CreateDominoSolution(xorSeries, pairsList))
                {
                    Console.WriteLine(list);
                }
            }
        }

        private static bool Fits(string previous, string current)
        {
            const int firstInt = 0;
            const int lastInt = 2;

            return current[firstInt] == previous[lastInt];
        }

        private static bool NotUsed(string text, string current)
        {
            return !text.Contains(current);
        }
    }
}