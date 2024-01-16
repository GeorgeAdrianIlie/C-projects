using System;

namespace myJuniorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //citeste I rand
            string input = Console.ReadLine();
            //transforma in numar
            int orchardsNumber = Convert.ToInt32(input);
            int[,] orchardsTrees = new int[orchardsNumber, 3];

            for (int i = 0; i < orchardsNumber; i++)
            {
                string line = Console.ReadLine();
                string[] treesNumbers = line.Split(' ');
                for (int j = 0; j < 3; j++)
                    orchardsTrees[i, j] = Convert.ToInt32(treesNumbers[j]);
            }

            int[] totalTreesPerOrchard = new int[orchardsNumber];
            for (int i = 0; i < orchardsNumber; i++)
            {
                totalTreesPerOrchard[i] = 0;
                for (int j = 0; j < 3; j++)
                    totalTreesPerOrchard[i] += orchardsTrees[i, j];
            }

            // orchardsTotalTrees / rows
            int[] orchardsTotalTrees = new int[orchardsNumber];
            for (int i = 0; i < orchardsNumber; i++)
            {
                orchardsTotalTrees[i] = 0;
                for (int j = 0; j < 3; j++)
                    orchardsTotalTrees[i] += orchardsTrees[i, j];
            }

            for (int i = 0; i < orchardsNumber; i++)
            {
                int orchardsIndex = i;
                Console.WriteLine(string.Format("Livada {0}: {1}", orchardsIndex + 1, orchardsTotalTrees[i]));
            }

            // treesPerType / columns 
            int[] treesPerType = new int[3];
            for (int j = 0; j < 3; j++)
            {
                treesPerType[j] = 0;
                for (int i = 0; i < orchardsNumber; i++)
                    treesPerType[j] += orchardsTrees[i, j];
            }

            Console.WriteLine(string.Format("Meri: {0}", treesPerType[0]));   
            Console.WriteLine(string.Format("Peri: {0}", treesPerType[1]));
            Console.WriteLine(string.Format("Ciresi: {0}", treesPerType[2]));

        }
    }
}