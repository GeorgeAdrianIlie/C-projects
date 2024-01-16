using System;

namespace RecursivelyReplaceWordFromText
{
    public class Program
    {
        public static string SearchAndReplace(string text, string toSearchAndReplace, string toFillIn)
        {
            if (!text.Contains(toSearchAndReplace))
            {
                return text;
            }

            const int startIndex = 0;
            int occurrenceIndex = text.IndexOf(toSearchAndReplace);
            int lastIndex = text.Length - 1;
            int prevOccurranceTextLength = occurrenceIndex;
            int restOfTheTextLength = lastIndex - occurrenceIndex;
            int restStartIndex = occurrenceIndex != lastIndex ? occurrenceIndex + 1 : occurrenceIndex;
            string textPrevOccurrance = occurrenceIndex != startIndex ? text.Substring(startIndex, prevOccurranceTextLength) : "";
            string restOfTheText = occurrenceIndex != lastIndex ? text.Substring(restStartIndex, restOfTheTextLength) : "";
            return textPrevOccurrance + toFillIn + SearchAndReplace(restOfTheText, toSearchAndReplace, toFillIn);
        }

        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string toSearchAndReplace = Console.ReadLine();
            string toFillIn = Console.ReadLine();
            Console.WriteLine(SearchAndReplace(text, toSearchAndReplace, toFillIn));
        }
    }
}