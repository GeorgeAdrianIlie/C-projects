using System;

namespace PascalTriangleSolution
{
    public class Program
    {
        public static void PrintTrianle(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    Console.Write(Paskal(row, col) + " ");
                }

                Console.WriteLine("\n");
            }
        }

        static long Paskal(int row, int col)
        {
            if (row >= 0 && (col == 0 || col == row))
            {
                return 1;
            }

            return Paskal(row - 1, col) + Paskal(row - 1, col - 1);
        }

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            PrintTrianle(rows);
        }
    }
}