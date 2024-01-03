using System;

namespace FromGibberish
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(TranslateFromGibberish(text));
            Console.Read();
        }

        private static string TranslateFromGibberish(string text)
        {
            string translatedText = "";
            int i = 0;
            while (i < text.Length)
            {
                translatedText += text[i];
                i = IsVowel(text[i]) ? i + 3 : i + 1;
            }
            return translatedText;
        }

        private static bool IsVowel(char c)
        {
            return "aeioucAEIOU".IndexOf(c) != -1;
        }
    }
}
