using System;

namespace myJuniorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            // string text = "Mapaipi mupultepe cupuvipintepe.";
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
            return "aeiouAEIOU".IndexOf(c) != -1;
        }
        
    }
}