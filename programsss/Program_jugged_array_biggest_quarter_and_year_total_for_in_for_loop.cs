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
            int storesNumber = Convert.ToInt32(input);
            decimal[,] profits = new decimal[storesNumber, 4];

            for (int i = 0; i < storesNumber; i++)
            {
                string line = Console.ReadLine();
                string[] stringNumbers = line.Split(' ');
                for (int j = 0; j < 4; j++)
                    profits[i, j] = Convert.ToDecimal(stringNumbers[j]);
            }

            decimal[] quartersTotals = new decimal[4];
            for (int j = 0; j < 4; j++)
            {
                quartersTotals[j] = 0;
                for (int i = 0; i < storesNumber; i++)
                    quartersTotals[j] += profits[i, j];
            }

            decimal maxProfitQuarter = quartersTotals[0];
            decimal maxProfitQuarterIndex = 0;

            for (int i = 1; i < 4; i++)
            {
                if (quartersTotals[i] > maxProfitQuarter)
                {
                    maxProfitQuarter = quartersTotals[i];
                    maxProfitQuarterIndex = i;
                }
            }
            Console.WriteLine(string.Format("Trimestrul {0}: {1:F2}", maxProfitQuarterIndex + 1, maxProfitQuarter));   

            decimal[] yearsTotals = new decimal[storesNumber];
            for (int i = 0; i < storesNumber; i++)
            {
                yearsTotals[i] = 0;
                for (int j = 0; j < 4; j++)
                    yearsTotals[i] += profits[i, j];
            }

            decimal maxProfitYear = yearsTotals[0];
            decimal maxProfitYearIndex = 0;

            for (int i = 0; i < storesNumber; i++)
            {
                if (yearsTotals[i] > maxProfitYear)
                {
                    maxProfitYear = yearsTotals[i];
                    maxProfitYearIndex = i;
                }
            }
            Console.WriteLine(string.Format("Magazinul {0}: {1:F2}", maxProfitYearIndex + 1, maxProfitYear));   
           
        }
    }
}