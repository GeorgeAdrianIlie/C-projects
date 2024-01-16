using System;

namespace FibonacciRecursive
{
    public class Program
    {
        public static int Fibonacci(int n)
        {
            int previous = 0;
            return Fibonacci(n, ref previous);
        }

        public static int Fibonacci(int n, ref int previous)
        {
            const int minorLimit = 2;
            if (n < minorLimit)
            {
                return n;
            }

            int beforePrevious = 0;
            previous = Fibonacci(n - 1, ref beforePrevious);
            return previous + beforePrevious;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool trueNumber = int.TryParse(input, out int n);
            int fibonacciNumberInTheRow = 0;
            if (trueNumber)
            {
                fibonacciNumberInTheRow = Fibonacci(n);
            }

            Console.WriteLine(fibonacciNumberInTheRow);
        }
    }
}