using System;

namespace myJuniorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, i, gcd, lcm;
            x=Convert.ToInt32(Console.ReadLine());
            y=Convert.ToInt32(Console.ReadLine());
            gcd = 0;
            for (i = 1; i <= x && i <= y; ++i) {
                // check if i is a factor of both integers
                if (x % i == 0 && y % i == 0)
                    gcd = i;
            }

            lcm = (x * y) / gcd;

            Console.WriteLine(lcm);
        }
    }
}