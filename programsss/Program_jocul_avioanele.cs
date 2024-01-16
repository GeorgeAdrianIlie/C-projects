using System;

namespace MyJuniorProject
{
    class Program
    {
        static void Main()
        {
            // Read the battle field with first player plane
            const int width = 10;
            string[][] table = new string[width][];
            int rowId = 10;
            int[] rowIds = new int[width];
            for (int i = 0; i < width; i++)
            {
                // Creating the table for play of the first player with the plane model
                string line = Console.ReadLine();
                table[i] = line.Split(" ");

                // ID number of the line array, identifier of row
                rowIds[i] = rowId;
                rowId--;
            }

            // Letter of the column array, identifier of the column
            const int height = 10;
            char[] columnsName = new char[height];
            int columnId = 0;
            for (char letter = 'a'; letter <= 'j'; letter++)
            {
                columnsName[columnId] = letter;
                columnId++;
            }

            const int hits = 15;
            int[] verticalCoordinates = new int[hits];
            char[] horizontalCoordinates = new char[hits];
            for (int i = 0; i < hits; i++)
            {
                string target = Console.ReadLine();
                string[] shot = target.Split(" ");
                int rowNumber = Convert.ToInt32(shot[0]);
                char columnName = Convert.ToChar(shot[1]);
                verticalCoordinates[i] = rowNumber;
                horizontalCoordinates[i] = columnName;
            }

            // Read hits of the planes
            int countHit = 0;
            for (int i = 0; i < hits; i++)
            {
                int v = Array.IndexOf(rowIds, verticalCoordinates[i]);
                int h = Array.IndexOf(columnsName, horizontalCoordinates[i]);
                string shot = table[v][h];
                if (shot == "X")
                {
                    countHit++;
                }
            }

            const int plane = 8;
            if (countHit == plane)
            {
                Console.WriteLine("doborat");
            }
            else
            {
                Console.WriteLine(countHit);
            }
        }
    }
}