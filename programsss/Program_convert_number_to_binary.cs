using System;

namespace MyJuniorProject
{
    class Program
    {
        static void Main()
        {
            string a = "";
            string line = Console.ReadLine();
            bool status = int.TryParse(line, out int n);

            if (n < 0 || !status)
            {
                Console.Write("Programul converteste doar numere intregi pozitive.");
            }
            else
            {
                const int bin = 2;
                while (n > 0)
                {
                    a += n % bin;
                    n /= bin;
                }

                string binary = "";
                for (int k = a.Length - 1; k > -1; k--)
                {
                    binary += a[k];
                }

                Console.Write(binary);
            }
        }
    }
}