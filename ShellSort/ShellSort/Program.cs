﻿using System;

namespace ShellSort
{
    class Program
    {
        static void Main()
        {
            int[] numbers = ReadNumbers();
            ShellSort(numbers, numbers.Length);
            Print(numbers);
            Console.Read();
        }

        static void ShellSort(int[] numbers, int length)
        {
            int i;
            int j;
            int temp;
            int inc = 3;
            const int even = 2;

            while (inc > 0)
            {
                for (i = 0; i < length; i++)
                {
                    j = i;
                    temp = numbers[i];
                    while ((j >= inc) && (numbers[j - inc] > temp))
                    {
                        numbers[j] = numbers[j - inc];
                        j -= inc;
                    }

                    numbers[j] = temp;
                }

                if (inc / even != 0)
                {
                    inc /= even;
                }
                else if (inc == 1)
                {
                    inc = 0;
                }
                else
                {
                    inc = 1;
                }
            }
        }

        static void Print(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.Write("\n");
        }

        static int[] ReadNumbers()
        {
            string[] numbers = Console.ReadLine().Split();
            int[] result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = Convert.ToInt32(numbers[i]);
            }

            return result;
        }
    }
}