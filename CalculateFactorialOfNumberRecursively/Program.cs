using System;

namespace CalculateFactorialOfNumberRecursively
{
    public class Program
    {
        public static int GetFactorialOfNumber(int number)
        {
            return number <= 1 ? 1 : number * GetFactorialOfNumber(number - 1);
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input);
            Console.WriteLine(GetFactorialOfNumber(number));
        }
    }
}