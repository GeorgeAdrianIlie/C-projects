using System;

namespace PasswordEvaluation
{
    public struct PasswordComplexity
    {
        public int MinLowercaseChars;
        public int MinUpercaseChars;
        public int MinDigits;
        public int MinSymbols;
        public bool MayContainSimilarChars;
        public bool MayContainAmbiguesChars;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            PasswordComplexity passwordComplexity = SetMinimumRequirements();
            string toTest = Console.ReadLine();
            Console.WriteLine(EvaluatePasswordMinimumRequirements(passwordComplexity, toTest));
        }

        public static PasswordComplexity SetMinimumRequirements()
        {
            int highComplexityMinLowercaseChars = Convert.ToInt32(Console.ReadLine());
            int highComplexityMinUppercaseChars = Convert.ToInt32(Console.ReadLine());
            int highComplexityMinDigits = Convert.ToInt32(Console.ReadLine());
            int highComplexityMinSymbols = Convert.ToInt32(Console.ReadLine());
            bool canContainSimilarChars = bool.Parse(Console.ReadLine());
            bool canContainAmbiguousChars = bool.Parse(Console.ReadLine());

            return new PasswordComplexity
            {
                MinLowercaseChars = highComplexityMinLowercaseChars,
                MinUpercaseChars = highComplexityMinUppercaseChars,
                MinDigits = highComplexityMinDigits,
                MinSymbols = highComplexityMinSymbols,
                MayContainSimilarChars = canContainSimilarChars,
                MayContainAmbiguesChars = canContainAmbiguousChars
            };
        }

        public static bool EvaluatePasswordMinimumRequirements(PasswordComplexity passwordComplexity, string toTest)
        {
            bool status = false;
            if (HasMinimumSmallLetters(passwordComplexity.MinLowercaseChars, toTest)
                && HasMinimumBigLetters(passwordComplexity.MinUpercaseChars, toTest)
                && HasMinimumIntegers(passwordComplexity.MinDigits, toTest)
                && HasMinimumSimbols(passwordComplexity.MinSymbols, toTest))
            {
                status = true;
                if (MayContainSimilarChars(passwordComplexity.MayContainSimilarChars, toTest).Equals(false)
                    || MayContainAmbiguesChars(passwordComplexity.MayContainAmbiguesChars, toTest).Equals(false))
                {
                    status = false;
                    return status;
                }

                return status;
            }

            return status;
        }

        public static bool HasMinimumSmallLetters(int minLowercaseChars, string passwordToTest)
        {
            int count = 0;
            for (int i = 0; i < passwordToTest.Length; i++)
            {
                if (passwordToTest[i] >= 'a' && passwordToTest[i] <= 'z')
                {
                    count++;
                }
            }

            return count >= minLowercaseChars;
        }

        public static bool HasMinimumBigLetters(int minUpercaseChars, string passwordToTest)
        {
            int count = 0;
            for (int i = 0; i < passwordToTest.Length; i++)
            {
                if (passwordToTest[i] >= 'A' && passwordToTest[i] <= 'Z')
                {
                    count++;
                }
            }

            return count >= minUpercaseChars;
        }

        public static bool HasMinimumIntegers(int minDigits, string passwordToTest)
        {
            int count = 0;
            for (int i = 0; i < passwordToTest.Length; i++)
            {
                if (passwordToTest[i] >= '0' && passwordToTest[i] <= '9')
                {
                    count++;
                }
            }

            return count >= minDigits;
        }

        public static bool HasMinimumSimbols(int minSymbols, string passwordToTest)
        {
            int count = 0;
            const string specialChar = "!\"#$%&'()*+`-./:;<=>?@[\\]^_{|}~";
            for (int i = 0; i < specialChar.Length; i++)
            {
                if (passwordToTest.Contains(specialChar[i]))
                {
                    count++;
                }
            }

            return count >= minSymbols;
        }

        public static bool MayContainSimilarChars(bool mayContainSimilarChars, string passwordToTest)
        {
            const string specialChar = "l1Io0O";
            for (int i = 0; i < specialChar.Length; i++)
            {
                if (passwordToTest.Contains(specialChar[i]) && mayContainSimilarChars.Equals(true))
                {
                    return true;
                }

                if (passwordToTest.Contains(specialChar[i]) && mayContainSimilarChars.Equals(false))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool MayContainAmbiguesChars(bool mayContainAmbiguesChars, string passwordToTest)
        {
            const string ambiguesChars = "{}[]()/\\'\"~,;.<>";
            for (int i = 0; i < ambiguesChars.Length; i++)
            {
                if (passwordToTest.Contains(ambiguesChars[i]) && mayContainAmbiguesChars.Equals(true))
                {
                    return true;
                }

                if (passwordToTest.Contains(ambiguesChars[i]) && mayContainAmbiguesChars.Equals(false))
                {
                    return false;
                }
            }

            return true;
        }
    }
}