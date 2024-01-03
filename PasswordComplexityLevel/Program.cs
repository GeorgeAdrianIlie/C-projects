using System;

namespace PasswordComplexityLevel
{
    enum PasswordComplexityLevel
    {
        High,
        Medium,
        Low
    }

    struct PasswordComplexity
    {
        public int MinLowercaseChars;
        public int MinUpercaseChars;
        public int MinDigits;
        public int MinSymbols;
        public bool CanContainSimilarChars;
        public bool CanContainAmbiguousChars;
    }

    class Program
    {
        static void Main()
        {
            string password = Console.ReadLine();
            Console.WriteLine(GetPasswordComplexityLevel(password));
            Console.Read();
        }

        static PasswordComplexityLevel GetPasswordComplexityLevel(string password)
        {
            // TO DO: remove the line below and implement this function
            throw new NotImplementedException();
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
    }
}
