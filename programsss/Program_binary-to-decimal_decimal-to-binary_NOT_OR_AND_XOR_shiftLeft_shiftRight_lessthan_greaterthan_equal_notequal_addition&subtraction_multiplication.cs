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
        const int Addition = 13;
        const int Subtraction = 14;
        const int Multiplication = 15;
        const int Margin = 16;

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
            else if (conversionTypeValue >= Oposite && conversionTypeValue <= Xor)
            {
                LogicalOperands(conversionTypeValue, firstReadStringNumber, secondReadStringNumber);
            }
            else if (conversionTypeValue == ShiftLeft || conversionTypeValue == ShiftRight)
            {
                ConvertShift(conversionTypeValue, firstReadStringNumber, secondReadStringNumber);
            }
            else if (conversionTypeValue >= LessThan && conversionTypeValue <= NotEqual)
            {
                ComparisonOperands(conversionType, conversionTypeValue, firstReadStringNumber, secondReadStringNumber);
            }
            else if (conversionTypeValue >= Addition && conversionTypeValue < Margin)
            {
                FirstAndSecondDegreeOperations(conversionType, conversionTypeValue, firstReadStringNumber, secondReadStringNumber);
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
                if (conversionTypeValue == Oposite)
                {
                    resultedOutput = ExecuteOposite(firstReadStringNumber);
                }
                else if (conversionTypeValue == Or)
                {
                    resultedOutput = ExecuteOr(firstReadStringNumber, secondReadStringNumber);
                }
                else if (conversionTypeValue == And)
                {
                    resultedOutput = ExecuteAnd(firstReadStringNumber, secondReadStringNumber);
                }
                else if (conversionTypeValue == Xor)
                {
                    resultedOutput = ExecuteXor(firstReadStringNumber, secondReadStringNumber);
                }
            }

            Console.WriteLine(resultedOutput);
        }

        static string ExecuteOposite(string first)
        {
            string resultedOutput = "";
            int lenght = first.Length;
            for (int i = 0; i < lenght; i++)
            {
                resultedOutput += first[i] == '0' ? "1" : "0";
            }

            CheckEmpty(ref resultedOutput);

            return resultedOutput;
        }

        static string ExecuteOr(string firstReadStringNumber, string secondReadStringNumber)
        {
            string resultedOutput = "";
            if (CheckValidity(firstReadStringNumber) && CheckValidity(secondReadStringNumber))
            {
                AddPadingLeft(ref firstReadStringNumber, ref secondReadStringNumber);
                int lenght = firstReadStringNumber.Length;
                for (int i = 0; i < lenght; i++)
                {
                    resultedOutput += firstReadStringNumber[i] == '0' && secondReadStringNumber[i] == '0' ? "0" : "1";
                }
            }

            return resultedOutput;
        }

        static string ExecuteAnd(string firstReadStringNumber, string secondReadStringNumber)
        {
            string resultedOutput = "";
            if (CheckValidity(firstReadStringNumber) && CheckValidity(secondReadStringNumber))
            {
                AddPadingLeft(ref firstReadStringNumber, ref secondReadStringNumber);
                int lenght = firstReadStringNumber.Length;
                for (int i = 0; i < lenght; i++)
                {
                    resultedOutput += firstReadStringNumber[i] == '1' && secondReadStringNumber[i] == '1' ? "1" : "0";
                }

                CheckEmpty(ref resultedOutput);
            }

            return resultedOutput;
        }

        static string ExecuteXor(string firstReadStringNumber, string secondReadStringNumber)
        {
            string resultedOutput = "";
            if (CheckValidity(firstReadStringNumber) && CheckValidity(secondReadStringNumber))
            {
                AddPadingLeft(ref firstReadStringNumber, ref secondReadStringNumber);
                int lenght = firstReadStringNumber.Length;
                for (int i = 0; i < lenght; i++)
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

                CheckEmpty(ref resultedOutput);
            }

            return resultedOutput;
        }

        static void ConvertShift(int conversionTypeValue, string firstReadStringNumber, string secondReadStringNumber)
        {
            string resultedOutput = string.Empty;
            bool testInteger = int.TryParse(secondReadStringNumber, out int secondReadIntNumber);
            if (testInteger && conversionTypeValue == ShiftLeft)
            {
                resultedOutput = ConvertShiftLeft(firstReadStringNumber, secondReadIntNumber);
            }
            else if (testInteger && conversionTypeValue == ShiftRight)
            {
                resultedOutput = ConvertShiftRight(firstReadStringNumber, secondReadStringNumber);
            }

            Console.WriteLine(resultedOutput);
        }

        static string ConvertShiftLeft(string firstReadStringNumber, int secondReadIntNumber)
        {
            string resultedOutput = string.Empty;
            resultedOutput += firstReadStringNumber;
            int indexReference = firstReadStringNumber.Length + secondReadIntNumber;
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

            return resultedOutput;
        }

        static string ConvertShiftRight(string firstReadStringNumber, string secondReadStringNumber)
        {
            string resultedOutput = string.Empty;
            bool testInteger = int.TryParse(secondReadStringNumber, out int secondReadIntNumber);
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

            return resultedOutput;
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

        static void FirstAndSecondDegreeOperations(bool conversionType, int conversionTypeValue, string firstReadStringNumber, string secondReadStringNumber)
        {
            string result = string.Empty;
            if (conversionType && conversionTypeValue == Addition)
            {
                result = AdditionOperation(firstReadStringNumber, secondReadStringNumber);
            }
            else if (conversionType && conversionTypeValue == Subtraction)
            {
                result = SubtractionOperation(firstReadStringNumber, secondReadStringNumber);
            }
            else if (conversionType && conversionTypeValue == Multiplication)
            {
                result = MultiplicationOperation(firstReadStringNumber, secondReadStringNumber);
            }

            Console.WriteLine(result);
        }

        static string AdditionOperation(string first, string second)
        {
            string result = string.Empty;
            char inMind = '0';
            int sum = 0;
            AddPadingLeft(ref first, ref second);
            if (CheckValidity(first) && CheckValidity(second))
            {
                for (int i = first.Length - 1; i >= 0; i--)
                {
                    const int caseOne = 144;
                    const int caseTwo = 145;
                    const int caseThree = 146;
                    const int caseFour = 147;
                    sum = sum + inMind + first[i] + second[i];
                    if (sum == caseOne)
                    {
                        result += '0';
                        inMind = '0';
                        sum = 0;
                    }
                    else if (sum == caseTwo)
                    {
                        result += '1';
                        inMind = '0';
                        sum = 0;
                    }
                    else if (sum == caseThree)
                    {
                        result += '0';
                        inMind = '1';
                        sum = 0;
                    }
                    else if (sum == caseFour)
                    {
                        result += '1';
                        inMind = '1';
                        sum = 0;
                    }

                    if (inMind == '1' && i == 0)
                    {
                        result += '1';
                    }
                }

                result = ReverseString(result);
                CheckEmpty(ref result);
            }

            return result;
        }

        static string SubtractionOperation(string first, string second)
        {
            string result = string.Empty;
            AddPadingLeft(ref first, ref second);
            if (LessThanComparation(first, second))
            {
                string swap = second;
                second = first;
                first = swap;
            }

            first = ReverseString(first);
            second = ReverseString(second);
            if (CheckValidity(first) && CheckValidity(second))
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] == '0' && second[i] == '1')
                    {
                        result += '1';
                        Barrow(ref first, i);
                    }
                    else if (first[i] == '1' && second[i] == '0')
                    {
                        result += '1';
                    }
                    else
                    {
                        result += '0';
                    }
                }

                result = ReverseString(result);
                CheckEmpty(ref result);
            }

            return result;
        }

        static void Barrow(ref string first, int i)
        {
            char[] firstArr = first.ToCharArray();
            while (firstArr[i] != '1')
            {
                firstArr[i] = '1';
                i++;
            }

            if (firstArr[i] == '1')
            {
                firstArr[i] = '0';
            }

            first = new string(firstArr);
        }

        static string MultiplicationOperation(string first, string second)
        {
            string result = string.Empty;
            const string newMultied = "0";
            string multiplicationRowResult;
            AddPadingLeft(ref first, ref second);
            int realDigitIndex = 0;
            if (CheckValidity(first) && CheckValidity(second))
            {
                for (int i = second.Length - 1; i >= 0; i--)
                {
                    if (second[i] == '1')
                    {
                        multiplicationRowResult = ConvertShiftLeft(first, realDigitIndex);
                        realDigitIndex++;
                        result = AdditionOperation(result, multiplicationRowResult);
                    }
                    else if (second[i] == '0')
                    {
                        result = AdditionOperation(result, newMultied);
                        realDigitIndex++;
                    }
                }

                CheckEmpty(ref result);
            }

            return result;
        }

        static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
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