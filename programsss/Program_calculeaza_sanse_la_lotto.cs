using System;

namespace myJuniorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int lotto = Convert.ToInt32(Console.ReadLine());
            int ofX = Convert.ToInt32(Console.ReadLine());
            string line = Console.ReadLine();
            // int lotto = 49;
            // int ofX = 6;
            // string line = "I";
            int category = FindCategory(line);
            double result = CalculateChance(lotto,ofX,category);
            const string format = "0.##########";
            Console.WriteLine(result.ToString(format));
        }

        static int FindCategory(string input)
        {
            int category = 0;
            switch(input)
            {
                case "I":
                    category = 1;
                    break;
                case "II":
                    category = 2;
                    break;
                case "III":
                    category = 3;
                    break;
                default:
                    Console.WriteLine("Wrong category.");
                    break;
            }
            return category;
        }

        static double Factorial(int x)
        {
            double factorial = 1;
            for(double i=2; i<= x; i++){
                factorial = factorial * i;
            }
            // Console.WriteLine(factorial);
            return factorial;
        }

        private static double CalculateChance(int lotto, int ofX,int category){
        double AllCombinations = Factorial(lotto) / Factorial(ofX) / Factorial(lotto - ofX);
        double LostNumbersCombinations = Factorial(lotto - ofX) / Factorial(category - 1) / Factorial(lotto - ofX - category + 1);
        double WinningNumbersCombinations = Factorial(ofX) / Factorial(ofX - category + 1) / Factorial(category - 1);
        double CombinationsWithCategory = LostNumbersCombinations * WinningNumbersCombinations;
        double Probability = CombinationsWithCategory / AllCombinations;
        return Probability;
        }
    }
}