using System;
using System.Collections.Generic;

namespace MyJuniorProject
{
    class Program
    {
        static void Main()
        {
            string phrase = Console.ReadLine();
            string[] phraseWords = phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int dictionaryLenght = Convert.ToInt32(Console.ReadLine());
            string[] dictionary = new string[dictionaryLenght];
            bool validWord = false;
            int validWords = 0;
            for (int w = 0; w < dictionary.Length; w++)
            {
                dictionary[w] = Console.ReadLine();
            }

            for (int i = 0; i < phraseWords.Length; i++)
            {
                string lookUp = phraseWords[i];
                if (IsValidWord(lookUp, dictionary))
                {
                    validWord = true;
                    validWords++;
                }
                else if (!IsValidWord(lookUp, dictionary) && phraseWords[i].Length != 1)
                {
                    validWord = false;
                    string[] suggestions = GetWordCorrectionSuggestions(lookUp, dictionary);
                    if (suggestions.Length == 0)
                    {
                        Console.WriteLine(string.Format("{0}: (nu sunt sugestii)", phraseWords[i]));
                    }
                    else if (suggestions.Length > 0)
                    {
                        Console.WriteLine(string.Format("{0}: {1}", phraseWords[i], string.Join(" ", suggestions)));
                    }
                }
            }

            Console.WriteLine(validWord && validWords == phraseWords.Length ? "Text corect!" : "");
        }

        static bool IsValidWord(string lookUp, string[] dictionary)
        {
            for (int j = 0; j < dictionary.Length; j++)
            {
                if (string.Compare(lookUp, dictionary[j], true) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static bool SubstitutedLetters(string lookUp, string[] dictionary, ref int w)
        {
            int count = 0;
            bool validation = false;
            for (int l = 1; l < Math.Min(lookUp.Length, dictionary[w].Length); l++)
            {
                if (lookUp[l] == dictionary[w][l - 1] && dictionary[w][l] == lookUp[l - 1])
                {
                    count++;
                }
            }

            if (count == 1)
            {
                validation = true;
            }

            return validation;
        }

        static int CountSimilarities(string lookUp, string[] dictionary, ref int w)
        {
            int countSimilarities = 0;
            for (int l = 0; l < lookUp.Length; l++)
            {
                for (int lit = l; lit < dictionary[w].Length; lit++)
                {
                    if (string.Equals(lookUp[l], dictionary[w][lit]) && !SubstitutedLetters(lookUp, dictionary, ref w))
                    {
                        countSimilarities++;
                        break;
                    }
                }
            }

            return countSimilarities;
        }

        static string[] GetWordCorrectionSuggestions(string lookUp, string[] dictionary)
        {
            string[] suggestions = new string[0];
            for (int w = 0; w < dictionary.Length; w++)
            {
                if (lookUp.Length == dictionary[w].Length)
                {
                    int diference = Math.Abs(string.Compare(lookUp, dictionary[w]));
                    if ((diference == 1 && CountSimilarities(lookUp, dictionary, ref w) == lookUp.Length - 1) || SubstitutedLetters(lookUp, dictionary, ref w))
                    {
                        List<string> list = new List<string>(suggestions);
                        list.Add(dictionary[w]);
                        suggestions = list.ToArray();
                    }
                }
                else if ((lookUp.Length == dictionary[w].Length - 1 && CountSimilarities(lookUp, dictionary, ref w) == lookUp.Length) ||
                (lookUp.Length == dictionary[w].Length + 1 && CountSimilarities(lookUp, dictionary, ref w) == lookUp.Length - 1))
                {
                    List<string> list = new List<string>(suggestions);
                    list.Add(dictionary[w]);
                    suggestions = list.ToArray();
                }
            }

            return suggestions;
        }
    }
}