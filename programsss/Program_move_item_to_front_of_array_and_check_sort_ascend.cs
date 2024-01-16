using System;

namespace myJuniorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = ReadValuesList();
            int[] positionsToMove = ReadPositions();

            for (int i = 0; i < positionsToMove.Length; i++)
                MoveFirst(values, positionsToMove[i]);

            PrintValuesList(values);
            Console.WriteLine(CheckIfSortedAscending(values));
            Console.Read();
        }

        static bool CheckIfSortedAscending(int[] values)
        {
            bool status = false;
            int count = 0;
            for (int i = 0; i < values.Length-1; i++){ 
                if (values[i] <= values[i + 1]) {
                    count++;
                }
                else {
                    count--;
                }
            }
            int comparations = values.Length-1;
            if(count < comparations){
                status = false;
            }else{
                status = true;
            }

            return status;
        }

        static void MoveFirst(int[] values, int index)
        {
            if (index == 1)
            {
                int aux = values[index - 1];
                values[0] = values[index];
                values[index] = aux;
            }
            else
            {
                int aux = values[index];
                for (int i = index; i > 0; i--)
                {
                    values[i] = values[i - 1];
                }
                values[0] = aux;
            }
        }

        static int[] ReadPositions()
        {
            int positionsNumber = Convert.ToInt32(Console.ReadLine());
            int[] positions = new int[positionsNumber];

            for (int i = 0; i < positionsNumber; i++)
                positions[i] = Convert.ToInt32(Console.ReadLine());

            return positions;
        }

        static int[] ReadValuesList()
        {
            string[] inputValues = Console.ReadLine().Split(' ');
            int[] values = new int[inputValues.Length];

            for (int i = 0; i < values.Length; i++)
                values[i] = Convert.ToInt32(inputValues[i]);

            return values;
        }

        static void PrintValuesList(int[] valuesList)
        {
            for (int i = 0; i < valuesList.Length; i++)
                Console.Write(valuesList[i] + " ");
            Console.Write('\n');
        }
    }
}