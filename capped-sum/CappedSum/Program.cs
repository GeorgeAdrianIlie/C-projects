using System;

namespace CappedSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumLimit = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            int count = 0;

            while (sum < sumLimit)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                sum += number;
                count++;
            }

            Console.WriteLine(sum + " " + count);
            Console.ReadLine();
        }
    }
}
