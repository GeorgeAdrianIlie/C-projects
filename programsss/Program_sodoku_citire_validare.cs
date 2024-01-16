using System;

namespace MyJuniorProject
{
    class Program
    {
        const int SudokuBoardSize = 9;
        const int SudokuBlockSize = 3;
        const string LineCase = "linia";
        const string ColumnCase = "coloana";
        const string BlockCase = "blocul";

        static void Main()
        {
            byte[,] sudokuBoard = new byte[SudokuBoardSize, SudokuBoardSize];
            Console.WriteLine(ReadSudokuBoard(sudokuBoard) && IsValidSudokuBoard(sudokuBoard));
            Console.Read();
        }

        static bool IsValidSudokuBoard(byte[,] sudokuBoard)
        {
            for (int i = 0; i < SudokuBoardSize; i++)
            {
                if (!IsValidSudokuItem(sudokuBoard, LineCase, i) ||
                    !IsValidSudokuItem(sudokuBoard, ColumnCase, i) ||
                    !IsValidSudokuItem(sudokuBoard, BlockCase, i))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsValidSudokuItem(byte[,] sudokuBoard, string itemType, int itemIndex)
        {
            byte[] sudokuValuesCount = new byte[SudokuBoardSize];
            // byte[] arrCurentTypeValues = new byte[SudokuBoardSize];
            for (int i = 0; i < SudokuBoardSize; i++)
            {
                byte sudokuValue = GetSudokuValue(sudokuBoard, itemType, itemIndex, i);
                // arrCurentTypeValues[i] = sudokuValue;
                sudokuValuesCount[sudokuValue - 1]++;
                if (sudokuValuesCount[sudokuValue - 1] > 1)
                {
                    if (itemType == LineCase || itemType == ColumnCase)
                    {
                        Console.WriteLine(string.Format("Elementul {0} apare de mai multe ori pe {1} {2}", sudokuValue, itemType, itemIndex + 1));
                    }
                    else if (itemType == BlockCase)
                    {
                        Console.WriteLine(string.Format("Elementul {0} apare de mai multe ori in {1} {2}", sudokuValue, itemType, itemIndex + 1));
                    }

                    return false;
                }
            }

            return true;
        }

        static byte GetSudokuValue(byte[,] sudokuBoard, string itemType, int itemIndex, int position)
        {
            switch (itemType)
            {
                case LineCase:
                    return sudokuBoard[itemIndex, position];
                case ColumnCase:
                    return sudokuBoard[position, itemIndex];
                case BlockCase:
                    int linia = itemIndex / SudokuBlockSize * SudokuBlockSize + position / SudokuBlockSize;
                    int coloana = itemIndex % SudokuBlockSize * SudokuBlockSize + position % SudokuBlockSize;
                    return sudokuBoard[linia, coloana];
            }

            return 0;
        }

        // static int FindFirstOccurance(byte[] arrCurentTypeValues, int i)
        // {
        //     int firstOccurance = 0;
        //     for (int k = 0; k < SudokuBoardSize; k++)
        //     {
        //         if (arrCurentTypeValues[k] == arrCurentTypeValues[i] && k < i)
        //         {
        //             firstOccurance = k;
        //         }
        //     }

        //     return firstOccurance;
        // }

        static bool ReadSudokuBoard(byte[,] sudokuBoard)
        {
            for (int i = 0; i < SudokuBoardSize; i++)
            {
                string[] lineValues = ReadLineValues();

                if (lineValues.Length < SudokuBoardSize)
                {
                    Console.WriteLine(string.Format("Sunt sub 9 elemente pe linia {0}", i + 1));

                    return false;
                }
                else if (lineValues.Length > SudokuBoardSize)
                {
                    Console.WriteLine(string.Format("Sunt mai mult de 9 elemente pe linia {0}", i + 1));
                    return false;
                }

                for (int j = 0; j < SudokuBoardSize; j++)
                {
                    if (!IsValidSudokuValue(lineValues[j], out int value))
                    {
                        Console.WriteLine(string.Format("Element invalid pe linia {0}: {1}", i + 1, lineValues[j]));

                        return false;
                    }

                    sudokuBoard[i, j] = (byte)value;
                }
            }

            return true;
        }

        static string[] ReadLineValues()
        {
            string line;
            do
            {
                line = Console.ReadLine();
            }
            while (line == "");

            return line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        static bool IsValidSudokuValue(string stringValue, out int value)
        {
            if (!int.TryParse(stringValue, out value))
            {
                return false;
            }

            if (value < 1 || value > SudokuBoardSize)
            {
                return false;
            }

            return true;
        }
    }
}