using System;

namespace myJuniorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] valuesList = ReadValuesList();

            string line = Console.ReadLine();

            while (line != "x")
            {
                string[] lineItems = line.Split(' ');
                int index = Convert.ToInt32(lineItems[0]);
                int value = Convert.ToInt32(lineItems[1]);
                UpdateValue(valuesList, index, value);
                line = Console.ReadLine();
            }

            PrintValuesList(valuesList);
            Console.Read();
        }

        static void UpdateValue(int[] valuesList, int index, int value)
        {
            valuesList[index] = value;
        }

        static void PrintValuesList(int[] valuesList)
        {
            for (int i = 0; i < valuesList.Length; i++)
                Console.Write(valuesList[i] + " ");
        }

        static int[] ReadValuesList()
        {
            string[] inputValues = Console.ReadLine().Split(' ');
            int[] values = new int[inputValues.Length];

            for (int i = 0; i < values.Length; i++)
                values[i] = Convert.ToInt32(inputValues[i]);

            return values;
        }
    }
}