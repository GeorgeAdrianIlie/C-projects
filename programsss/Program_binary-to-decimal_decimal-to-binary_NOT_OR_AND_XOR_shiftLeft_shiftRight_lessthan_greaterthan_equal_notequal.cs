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
        const int ShiftLeft = 7;
        const int ShiftRight = 8;
        const int LessThan = 9;
        const int GreaterThan = 10;
        const int Equal = 11;
        const int NotEqual = 12;
        const int Margin = 13;

        static void Main()
        {
            bool conversionType = int.TryParse(Console.ReadLine(), out int conversionTypeValue);
            string firstReadStringNumber = Console.ReadLine();
            char[] figuresOfFirstReadStringNumber = firstReadStringNumber.ToCharArray();
            string secondReadStringNumber = Console.ReadLine();

            if (conversionType && conversionTypeValue > 0 && conversionTypeValue < Margin)
            {
                if (conversionTypeValue == 1)
                {
                    ConvertToBinary(firstReadStringNumber);
                }
                else if (CheckValidity(firstReadStringNumber))
                {
                    CheckBinaryType(conversionType, conversionTypeValue, firstReadStringNumber, figuresOfFirstReadStringNumber, secondReadStringNumber);
                }
            }
            else
            {
                Console.WriteLine("Operatie invalida.");
            }
        }

        static void CheckBinaryType(bool conversionType, int conversionTypeValue, string firstReadStringNumber, char[] figuresOfFirstReadStringNumber, string secondReadStringNumber)
        {
            if (conversionTypeValue == Bin)
            {
                ConvertToDecimal(figuresOfFirstReadStringNumber);
            }
            else if (conversionType && conversionTypeValue >= Oposite && conversionTypeValue <= Xor)
            {
                LogicalOperands(conversionTypeValue, firstReadStringNumber, secondReadStringNumber);
            }
            else if (conversionTypeValue == ShiftLeft || conversionTypeValue == ShiftRight)
            {
                ConvertShift(conversionTypeValue, firstReadStringNumber, secondReadStringNumber);
            }
            else if (conversionType && conversionTypeValue >= LessThan && conversionTypeValue <= NotEqual)
            {
                ComparisonOperands(conversionType, conversionTypeValue, firstReadStringNumber, secondReadStringNumber);
            }
        }

        static void ConvertToBinary(string input)
        {
            bool status = int.TryParse(input, out int n);

            if (n < 0 || !status)
            {
                Console.Write("Programul converteste doar numere intregi pozitive.");
            }
            else
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

        static void LogicalOperands(int conversionTypeValue, string firstReadStringNumber, string secondReadStringNumber)
        {
            string resultedOutput = "";
            if (CheckValidity(firstReadStringNumber) && CheckValidity(secondReadStringNumber))
            {
                AddPadingLeft(ref firstReadStringNumber, ref secondReadStringNumber);
                int lenght = firstReadStringNumber.Length;
                for (int i = 0; i < lenght; i++)
                {
                    if (conversionTypeValue == Oposite)
                    {
                        ExecuteOposite(ref resultedOutput, firstReadStringNumber, i);
                    }
                    else if (conversionTypeValue == Or)
                    {
                        ExecuteOr(ref resultedOutput, firstReadStringNumber, secondReadStringNumber, i);
                    }
                    else if (conversionTypeValue == And)
                    {
                        ExecuteAnd(ref resultedOutput, firstReadStringNumber, secondReadStringNumber, i);
                    }
                    else if (conversionTypeValue == Xor)
                    {
                        ExecuteXor(ref resultedOutput, firstReadStringNumber, secondReadStringNumber, i);
                    }
                }

                if (conversionTypeValue != Or)
                {
                    CheckEmpty(ref resultedOutput);
                }
            }

            Console.WriteLine(resultedOutput);
        }

        static void ExecuteOposite(ref string resultedOutput, string firstReadStringNumber, int i)
        {
            resultedOutput += firstReadStringNumber[i] == '0' ? "1" : "0";
        }

        static void ExecuteOr(ref string resultedOutput, string firstReadStringNumber, string secondReadStringNumber, int i)
        {
            resultedOutput += firstReadStringNumber[i] == '0' && secondReadStringNumber[i] == '0' ? "0" : "1";
        }

        static void ExecuteAnd(ref string resultedOutput, string firstReadStringNumber, string secondReadStringNumber, int i)
        {
            resultedOutput += firstReadStringNumber[i] == '1' && secondReadStringNumber[i] == '1' ? "1" : "0";
        }

        static void ExecuteXor(ref string resultedOutput, string firstReadStringNumber, string secondReadStringNumber, int i)
        {
            if (firstReadStringNumber[i] == '1' && secondReadStringNumber[i] == '1')
            {
                resultedOutput += "0";
            }
            else if (firstReadStringNumber[i] == '0' && secondReadStringNumber[i] == '0')
            {
                resultedOutput += "0";
            }
            else
            {
                resultedOutput += "1";
            }
        }

        static void ConvertShift(int conversionTypeValue, string firstReadStringNumber, string secondReadStringNumber)
        {
            bool testInteger = int.TryParse(secondReadStringNumber, out int secondReadIntNumber);
            int indexReference = firstReadStringNumber.Length + secondReadIntNumber;
            string resultedOutput = "";
            if (testInteger && conversionTypeValue == ShiftLeft)
            {
                ConvertShiftLeft(ref resultedOutput, firstReadStringNumber, indexReference);
            }
            else if (testInteger && conversionTypeValue == ShiftRight)
            {
                ConvertShiftRight(ref resultedOutput, firstReadStringNumber, testInteger, secondReadIntNumber);
            }

            Console.WriteLine(resultedOutput);
        }

        static void ConvertShiftLeft(ref string resultedOutput, string firstReadStringNumber, int indexReference)
        {
            resultedOutput += firstReadStringNumber;
            if (CheckValidity(firstReadStringNumber))
            {
                for (int i = firstReadStringNumber.Length; i < indexReference; i++)
                {
                    resultedOutput += '0';
                }
            }
            else
            {
                resultedOutput = "";
            }
        }

        static void ConvertShiftRight(ref string resultedOutput, string firstReadStringNumber, bool testInteger, int secondReadIntNumber)
        {
            if (secondReadIntNumber < 0)
            {
                Console.WriteLine("Numarul de pozitii trebuie sa fie intreg si pozitiv.");
            }
            else if (secondReadIntNumber >= 0)
            {
                if (testInteger && CheckValidity(firstReadStringNumber) && secondReadIntNumber < firstReadStringNumber.Length)
                {
                    resultedOutput = firstReadStringNumber.Remove(firstReadStringNumber.Length - secondReadIntNumber);
                }
                else if (testInteger && CheckValidity(firstReadStringNumber) && secondReadIntNumber >= firstReadStringNumber.Length)
                {
                    resultedOutput = "0";
                }
            }
        }

        static void ComparisonOperands(bool conversionType, int conversionTypeValue, string firstReadStringNumber, string secondReadStringNumber)
        {
            bool resultedOutput = false;
            AddPadingLeft(ref firstReadStringNumber, ref secondReadStringNumber);
            if (conversionType && conversionTypeValue == LessThan)
            {
                resultedOutput = LessThanComparation(firstReadStringNumber, secondReadStringNumber);
            }
            else if (conversionType && conversionTypeValue == GreaterThan)
            {
                resultedOutput = !LessThanComparation(firstReadStringNumber, secondReadStringNumber);
            }
            else if (conversionType && conversionTypeValue == Equal)
            {
                resultedOutput = EqualThan(ref resultedOutput, firstReadStringNumber, secondReadStringNumber);
            }
            else if (conversionType && conversionTypeValue == NotEqual)
            {
                resultedOutput = NotEqualThan(ref resultedOutput, firstReadStringNumber, secondReadStringNumber);
            }

            Console.WriteLine(resultedOutput);
        }

        static bool EqualThan(ref bool resultedOutput, string firstReadStringNumber, string secondReadStringNumber)
        {
            if (!LessThanComparation(firstReadStringNumber, secondReadStringNumber) && !LessThanComparation(secondReadStringNumber, firstReadStringNumber))
            {
                resultedOutput = true;
            }

            return resultedOutput;
        }

        static bool NotEqualThan(ref bool resultedOutput, string firstReadStringNumber, string secondReadStringNumber)
        {
            if (LessThanComparation(firstReadStringNumber, secondReadStringNumber) || LessThanComparation(secondReadStringNumber, firstReadStringNumber))
            {
                resultedOutput = true;
            }

            return resultedOutput;
        }

        static bool LessThanComparation(string firstReadStringNumber, string secondReadStringNumber)
        {
            bool lessThan = false;
            for (int i = 0; i < firstReadStringNumber.Length; i++)
            {
                if (firstReadStringNumber[i] == '0' && secondReadStringNumber[i] == '1')
                {
                    lessThan = true;
                    break;
                }
                else if (firstReadStringNumber[i] == '1' && secondReadStringNumber[i] == '0')
                {
                    lessThan = false;
                    break;
                }
            }

            return lessThan;
        }

        static bool CheckValidity(string firstReadStringNumber)
        {
            int checkValid = 0;
            bool valid = false;
            for (int e = 0; e < firstReadStringNumber.Length; e++)
            {
                if (firstReadStringNumber[e] == '0' || firstReadStringNumber[e] == '1')
                {
                    checkValid++;
                }
            }

            if (checkValid == firstReadStringNumber.Length)
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Nu s-a introdus un numar binar valid (format doar din 0 si 1).");
            }

            return valid;
        }

        static void AddPadingLeft(ref string param1, ref string param2)
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
    }
}