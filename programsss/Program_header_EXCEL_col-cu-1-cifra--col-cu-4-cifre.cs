using System;

namespace MyJuniorProject
{
    class Program
    {
        static void Main()
        {
            // create the array of cellNames
            string[] header = new string[456977];

            // create string array of 1 letter names
            string[] cellNames = { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            // create algorithm of populating the array
            int index = 1;
            string cellName = "";
            const int oneLetterBreak = 26;
            const int twoLettersBreak = 676;
            const int threeLettersBreak = 17576;
            const int fourLettersBreak = 456976;
            while (index < fourLettersBreak)
            {
                int firstLetter;
                int secondLetter;
                int thirdLetter;
                int fourthLetter;
                if (index % oneLetterBreak == 0)
                {
                    firstLetter = index % oneLetterBreak + oneLetterBreak;
                    secondLetter = (index / oneLetterBreak - 1) % oneLetterBreak;
                    thirdLetter = (index / oneLetterBreak / oneLetterBreak - 1) % oneLetterBreak;
                    fourthLetter = (index / oneLetterBreak / oneLetterBreak / oneLetterBreak - 1) % oneLetterBreak;
                }
                else
                {
                    firstLetter = index % oneLetterBreak;
                    secondLetter = index / oneLetterBreak % oneLetterBreak;
                    thirdLetter = index / oneLetterBreak / oneLetterBreak % oneLetterBreak;
                    fourthLetter = index / oneLetterBreak / oneLetterBreak / oneLetterBreak % oneLetterBreak;
                }

                // generate cellName per index
                if (index <= oneLetterBreak + 1)
                {
                    cellName = cellNames[firstLetter];
                }
                else if (index < twoLettersBreak + 1)
                {
                    cellName = cellNames[secondLetter] + cellNames[firstLetter];
                }
                else if (index < threeLettersBreak + 1)
                {
                    cellName = cellNames[thirdLetter] + cellNames[secondLetter] + cellNames[firstLetter];
                }
                else if (index > threeLettersBreak + 1)
                {
                    cellName = cellNames[fourthLetter] + cellNames[thirdLetter] + cellNames[secondLetter] + cellNames[firstLetter];
                }

                header[index] = cellName;
                index++;
            }

            int searchedTerm = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(header[searchedTerm]);
        }
    }
}