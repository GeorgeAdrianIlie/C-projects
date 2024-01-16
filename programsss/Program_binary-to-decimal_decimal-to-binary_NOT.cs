using System;

namespace MyJuniorProject
{
    class Program
    {
        const int Bin = 2;
        const int Oposite = 3;

        static void Main()
        {
            bool conversionType = int.TryParse(Console.ReadLine(), out int type);
            string input = Console.ReadLine();

            if (type == 1)
            {
                CheckAndConvert(input);
            }
            else if (type == Bin)
            {
                char[] figures = input.ToCharArray();

                if (CheckValidity(figures))
                {
                    ConvertToDecimal(figures);
                }
            }
            else if (type == Oposite)
            {
                char[] figures = input.ToCharArray();

                if (CheckValidity(figures))
                {
                    ConvertToOposite(figures);
                }
            }
            else if (conversionType && (type < 1 || type > Oposite))
            {
                Console.WriteLine("Operatie invalida.");
            }
        }

        static void CheckAndConvert(string input)
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

        static bool CheckValidity(char[] figures)
        {
            int checkValid = 0;
            bool valid = false;
            for (int e = 0; e < figures.Length; e++)
            {
                if (figures[e] == '0' || figures[e] == '1')
                {
                    checkValid++;
                }
            }

            if (checkValid == figures.Length)
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Nu s-a introdus un numar binar valid (format doar din 0 si 1).");
            }

            return valid;
        }

        static void ConvertToDecimal(char[] figures)
        {
            decimal decimals = 0;
            Array.Reverse(figures);
            for (int j = figures.Length - 1; j > -1; j--)
            {
                decimals += Convert.ToDecimal(figures[j].ToString()) * (decimal)Math.Pow(Bin, j);
            }

            Console.Write(decimals);
        }

        static void ConvertToOposite(char[] figures)
        {
            string decimales = "";
            for (int j = 0; j < figures.Length; j++)
            {
                if (figures[j] == '0')
                {
                    decimales += "1";
                }
                else if (figures[j] == '1')
                {
                    decimales += "0";
                }
            }

            char[] toTrim = { '0' };
            string decimalss = decimales.TrimStart(toTrim);

            if (decimalss == string.Empty)
            {
                decimalss = "0";
            }

            Console.WriteLine(decimalss);
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
    }
}