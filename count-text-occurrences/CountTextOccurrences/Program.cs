using System;

namespace CountTextOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string textToFind = Console.ReadLine();

            int count = 0;

            for (int i = 0; i < text.Length - textToFind.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < textToFind.Length; j++)
                {
                    if (text[i + j] != textToFind[j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
            Console.Read();
        }
    }
}
