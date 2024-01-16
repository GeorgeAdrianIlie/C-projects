using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    public class Program
    {
        private static double Calculate(double temporary, string s, double term2)
        {
            switch (s)
            {
                case "+":
                    return temporary + term2;
                case "-":
                    return temporary - term2;
                case "*":
                    return temporary * term2;
                case "/":
                    return temporary / term2;
                default: return temporary;
            }
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputs = input.Split(" ");
            List<string> all = new List<string>(inputs);
            List<double> integers = new ();
            List<string> signs = new ();
            for (int n = 0; n < inputs.Length; n++)
            {
                if (double.TryParse(inputs[n], out double item))
                {
                    integers.Add(item);
                }
                else
                {
                    signs.Add(inputs[n]);
                }
            }

            int real = integers.Count;
            List<string> solution = RecursiveCalculator(all, signs, integers, real);
            Console.WriteLine(solution[0]);
        }

        private static List<string> RecursiveCalculator(List<string> all, List<string> signs, List<double> integers, int real)
        {
            if (real == 1)
            {
                return all;
            }

            List<string> temporary = RecursiveCalculator(all, signs, integers, real - 1);
            List<string> result = new ();

            if (signs.Count == 0)
            {
                return temporary;
            }

            for (int i = 0; i < temporary.Count - 1; i++)
            {
                const int lastchartodelete = 2;
                bool testDoubleT1 = double.TryParse(temporary[i], out double num);
                bool testDoubleT2 = double.TryParse(temporary[i + 1], out double num2);
                if (testDoubleT1 && signs.Contains(temporary[i - 1]) && testDoubleT2)
                {
                    string first = temporary[i];
                    string operation = temporary[i - 1];
                    string next = temporary[i + 1];
                    double temporaryNumber = Calculate(double.Parse(first), operation, double.Parse(next));
                    temporary.Insert(i, temporaryNumber.ToString());
                    temporary.RemoveAt(i + lastchartodelete);
                    temporary.RemoveAt(i + 1);
                    temporary.RemoveAt(i - 1);
                    signs.Remove(operation);
                }
            }

            result.AddRange(temporary);
            return result;
        }
    }
}