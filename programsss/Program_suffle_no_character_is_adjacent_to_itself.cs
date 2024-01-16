using System;

namespace MyJuniorProject
{
    class Program
    {
        static void Main()
         {
            string phraseToWorkWith = Console.ReadLine();
            char[] phrase = phraseToWorkWith.ToCharArray();

            CheckIfOne(phrase);

            for (int i = 1; i < phrase.Length; i++)
            {
                char current = phrase[i];
                char previus = phrase[i - 1];

                if (current == previus && i != (phrase.Length - 1))
                {
                    ReplaceTheNextDiferentItem(phrase, ref i);
                }
                else if (current == previus && i == (phrase.Length - 1))
                {
                    if (phrase[i] != phrase[0])
                    {
                        MoveTheLastInTheFirstPosition(phrase);
                        string phraseString = new (phrase);
                        Console.WriteLine(phraseString);
                    }
                    else if (phrase[i] == phrase[0])
                    {
                        Console.WriteLine(phrase[i]);
                    }
                }
                else if (current != previus && i == (phrase.Length - 1))
                {
                    string phraseString = new (phrase);
                    Console.WriteLine(phraseString);
                }
            }
        }

        static void CheckIfOne(char[] phrase)
        {
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase.Length == 1)
                {
                    Console.WriteLine(phrase[0]);
                }
            }
        }

        static void ReplaceTheNextDiferentItem(char[] phrase, ref int i)
        {
            for (int j = i + 1; j < phrase.Length; j++)
            {
                if (phrase[i] != phrase[j])
                {
                    var temp = phrase[i];
                    phrase[i] = phrase[j];
                    phrase[j] = temp;
                    break;
                }
            }
        }

        static void MoveTheLastInTheFirstPosition(char[] phrase)
        {
            char[] test = new char[phrase.Length];
            Array.Copy(phrase, phrase.Length - 1, test, 0, 1);
            Array.Copy(phrase, 0, test, 1, phrase.Length - 1);
            test.CopyTo(phrase, 0);
        }
    }
}