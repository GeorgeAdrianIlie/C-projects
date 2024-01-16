using System;

namespace PasswordSecurityLevel
{
    public enum PasswordComplexityLevel
    {
        High,
        Medium,
        Low
    }

    public struct PasswordComplexity
    {
        public int MinLowercaseChars;
        public int MinUpercaseChars;
        public int MinDigits;
        public int MinSymbols;
        public bool CanContainSimilarChars;
        public bool CanContainAmbiguousChars;
    }

    public class Program
    {
        public static PasswordComplexityLevel GetPasswordComplexityLevel(string password)
        {
            bool high = EvaluatePasswordMinimumRequirements(GetHighPasswordComplexity(), password);
            bool medium = EvaluatePasswordMinimumRequirements(GetMediumPasswordComplexity(), password);

            if (high)
            {
                return PasswordComplexityLevel.High;
            }

            if (medium)
            {
                return PasswordComplexityLevel.Medium;
            }

            return PasswordComplexityLevel.Low;
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
                if (MayContainSimilarChars(passwordComplexity.CanContainSimilarChars, toTest).Equals(false)
                    || MayContainAmbiguesChars(passwordComplexity.CanContainAmbiguousChars, toTest).Equals(false))
                {
                    status = false;
                    return status;
                }

                return status;
            }

            return status;
        }

        static void Main()
        {
            string password = Console.ReadLine();
            Console.WriteLine(GetPasswordComplexityLevel(password));
            Console.Read();
        }

        static PasswordComplexity GetHighPasswordComplexity()
        {
            const int HighComplexityMinLowercaseChars = 5;
            const int HighComplexityMinUppercaseChars = 2;
            const int HighComplexityMinDigits = 2;
            const int HighComplexityMinSymbols = 2;

            return new PasswordComplexity
            {
                MinLowercaseChars = HighComplexityMinLowercaseChars,
                MinUpercaseChars = HighComplexityMinUppercaseChars,
                MinDigits = HighComplexityMinDigits,
                MinSymbols = HighComplexityMinSymbols,
                CanContainSimilarChars = true,
                CanContainAmbiguousChars = true
            };
        }

        static PasswordComplexity GetMediumPasswordComplexity()
        {
            const int MediumComplexityMinLowercaseChars = 3;
            const int MediumComplexityMinUpercaseChars = 1;
            const int MediumComplexityMinDigits = 1;
            const int MediumComplexityMinSymbols = 1;

            return new PasswordComplexity
            {
                MinLowercaseChars = MediumComplexityMinLowercaseChars,
                MinUpercaseChars = MediumComplexityMinUpercaseChars,
                MinDigits = MediumComplexityMinDigits,
                MinSymbols = MediumComplexityMinSymbols,
                CanContainSimilarChars = true,
                CanContainAmbiguousChars = true
            };
        }

        static bool HasMinimumSmallLetters(int minLowercaseChars, string passwordToTest)
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

        static bool HasMinimumBigLetters(int minUpercaseChars, string passwordToTest)
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

        static bool HasMinimumSimbols(int minSymbols, string passwordToTest)
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

        static bool MayContainSimilarChars(bool canContainSimilarChars, string passwordToTest)
        {
            const string specialChar = "l1Io0O";
            for (int i = 0; i < specialChar.Length; i++)
            {
                if (passwordToTest.Contains(specialChar[i]) && canContainSimilarChars.Equals(true))
                {
                    return true;
                }

                if (passwordToTest.Contains(specialChar[i]) && canContainSimilarChars.Equals(false))
                {
                    return false;
                }
            }

            return true;
        }

        static bool MayContainAmbiguesChars(bool canContainAmbiguesChars, string passwordToTest)
        {
            const string ambiguesChars = "{}[]()/\\'\"~,;.<>";
            for (int i = 0; i < ambiguesChars.Length; i++)
            {
                if (passwordToTest.Contains(ambiguesChars[i]) && canContainAmbiguesChars.Equals(true))
                {
                    return true;
                }

                if (passwordToTest.Contains(ambiguesChars[i]) && canContainAmbiguesChars.Equals(false))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
