using System;

namespace CheckAcronimApp
{
    internal class Program
    {
        private static string[] ReadPhrase()
        {
            string input = Console.ReadLine();
            string[] phrase = input.ToLower().Split(" ");

            return phrase;
        }

        private static string ReadWordToCompareTo()
        {
            string word = Console.ReadLine();

            return word;
        }

        static void Main()
        {
            string[] phrase = ReadPhrase();
            string word = ReadWordToCompareTo();
            PrintProgramResult(phrase, word);
        }

        private static void PrintProgramResult(string[] phrase, string word)
        {
            if (CheckAcronim(phrase, word))
            {
                Console.WriteLine("da");
            }
            else
            {
                Console.WriteLine("nu");
            }
        }

        private static bool CheckAcronim(string[] phrase, string word)
        {
            bool result = false;
            int maxIndexOfLetterToChceck = 2;
            List<char> newWordLetters = new List<char>(word.Length);
            for (int j = 0; j <= maxIndexOfLetterToChceck; j++)
            {
                for (int i = 0; i < phrase.Length; i++)
                {
                    newWordLetters.Insert(word.IndexOf(phrase[i][j]), phrase[i][j]);
                }
            }

            string newWord = newWordLetters.ToString();
            if (newWord.Length == word.Length)
            {
                result = true;
            }

            return result;
        }
    }
}