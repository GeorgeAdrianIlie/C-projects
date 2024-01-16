using System;

namespace MyJuniorProject
{
    class Program
    {
        const int Bin = 2;
        const int Oposite = 3;
        const int Or = 4;
        const int And = 5;
        const int Xor = 6;
        const int Nine = 9;

        static void Main()
        {
            bool conversionType = int.TryParse(Console.ReadLine(), out int type);
            string input = Console.ReadLine();
            char[] figures = input.ToCharArray();

            if (conversionType && type > 0 && type < Nine)
            {
                if (type == 1)
                {
                    CheckAndConvert(input);
                }
                else if (CheckValidity(figures))
                {
                    CheckBinaryType(type, figures, input);
                }
            }
            else
            {
                Console.WriteLine("Operatie invalida.");
            }
        }

        static void CheckBinaryType(int type, char[] figures, string input)
        {
            if (type == Bin)
            {
                ConvertToDecimal(figures);
            }
            else if (type == Oposite)
            {
                ConvertToOposite(figures);
            }
            else if (type == Or)
            {
                ConvertToOr(input);
            }
            else if (type == And)
            {
                ConvertToAnd(input);
            }
            else if (type == Xor)
            {
                ConvertToXor(input);
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
            string result = "";
            for (int j = 0; j < figures.Length; j++)
            {
                if (figures[j] == '0')
                {
                    result += "1";
                }
                else if (figures[j] == '1')
                {
                    result += "0";
                }
            }

            CheckEmpty(ref result);

            Console.WriteLine(result);
        }

        static void ConvertToOr(string input)
        {
            string orString = Console.ReadLine();
            char[] orFigures = orString.ToCharArray();
            string toCompare = input;
            string result = "";
            if (CheckValidity(orFigures))
            {
                AddPading(ref toCompare, ref orString);

                for (int i = 0; i < toCompare.Length; i++)
                {
                    result += toCompare[i] == '0' && orString[i] == '0' ? "0" : "1";
                }
            }

            Console.WriteLine(result);
        }

        static void ConvertToAnd(string input)
        {
            string andString = Console.ReadLine();
            char[] andFigures = andString.ToCharArray();
            string toAnd = input;
            string result = "";
            if (CheckValidity(andFigures))
            {
                AddPading(ref toAnd, ref andString);

                for (int i = 0; i < toAnd.Length; i++)
                {
                    result += toAnd[i] == '1' && andString[i] == '1' ? "1" : "0";
                }

                CheckEmpty(ref result);
            }

            Console.WriteLine(result);
        }

        static void ConvertToXor(string input)
        {
            string xorString = Console.ReadLine();
            char[] andFigures = xorString.ToCharArray();
            string toXor = input;
            string result = "";
            if (CheckValidity(andFigures))
            {
                AddPading(ref toXor, ref xorString);

                LogicOfXor(toXor, xorString, ref result);

                CheckEmpty(ref result);
            }

            Console.WriteLine(result);
        }

        static void LogicOfXor(string toXor, string xorString, ref string result)
        {
            for (int i = 0; i < toXor.Length; i++)
            {
                if (toXor[i] == '1' && xorString[i] == '1')
                {
                    result += "0";
                }
                else if (toXor[i] == '0' && xorString[i] == '0')
                {
                    result += "0";
                }
                else if (toXor[i] == '1' && xorString[i] == '0')
                {
                    result += "1";
                }
                else if (toXor[i] == '0' && xorString[i] == '1')
                {
                    result += "1";
                }
            }
        }

        static void AddPading(ref string param1, ref string param2)
        {
            if (param1.Length > param2.Length)
            {
                param2 = param2.PadLeft(param1.Length, '0');
            }
            else if (param2.Length > param1.Length)
            {
                param1 = param1.PadLeft(param2.Length, '0');
            }
        }

        static void CheckEmpty(ref string param)
        {
            char[] toTrim = { '0' };
            param = param.TrimStart(toTrim);

            param = param == string.Empty ? "0" : param;
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