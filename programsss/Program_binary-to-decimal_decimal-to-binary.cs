using System;

namespace MyJuniorProject
{
    class Program
    {
        const int Bin = 2;

        static void Main()
        {
            bool conversionType = int.TryParse(Console.ReadLine(), out int type);
            string input = Console.ReadLine();

            if (type == Bin)
            {
                char[] figures = input.ToCharArray();
                decimal[] numbers = new decimal[figures.Length];
                ConvertToNumbers(figures, numbers, input);

                if (CheckValidity(numbers))
                {
                    ConvertToDecimal(numbers);
                }
            }
            else if (type == 1)
            {
                bool status = int.TryParse(input, out int n);

                if (n < 0 || !status)
                {
                    Console.Write("Programul converteste doar numere intregi pozitive.");
                }
                else
                {
                    ConvertToBinary(n);
                }
            }
            else if (conversionType && (type < 1 || type > Bin))
            {
                Console.WriteLine("Operatie invalida.");
            }
        }

        static void ConvertToDecimal(decimal[] numbers)
        {
            decimal decimals = 0;
            Array.Reverse(numbers);
            for (int j = numbers.Length - 1; j > -1; j--)
            {
                decimals += numbers[j] * (decimal)Math.Pow(Bin, j);
            }

            Console.Write(decimals);
        }

        static void ConvertToBinary(int n)
        {
            string a = "";
            while (n > 0)
            {
                a += n % Bin;
                n /= Bin;
            }

            string binary = "";
            for (int k = a.Length - 1; k > -1; k--)
            {
                binary += a[k];
            }

            Console.Write(binary);
        }

        static void ConvertToNumbers(char[] figures, decimal[] numbers, string input)
        {
            for (int g = 0; g < input.Length; g++)
                {
                    numbers[g] = decimal.Parse(figures[g].ToString());
                }
        }

        static bool CheckValidity(decimal[] numbers)
        {
            int checkValid = 0;
            bool valid = false;
            for (int e = 0; e < numbers.Length; e++)
            {
                if (numbers[e] == 0 || numbers[e] == 1)
                {
                    checkValid++;
                }
            }

            if (checkValid == numbers.Length)
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Nu s-a introdus un numar binar valid (format doar din 0 si 1).");
            }

            return valid;
        }
    }
}