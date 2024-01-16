using System;

namespace myJuniorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialTime = Convert.ToInt32(Console.ReadLine());

            int remainingTime = initialTime;
            while (remainingTime > 0)
            {
                Console.Write(remainingTime + " ");

                if (remainingTime > 30)
                {
                    Decrement(ref remainingTime, 10);
                    continue;
                }


                if (remainingTime > 10)
                {
                    Decrement(ref remainingTime, 5);
                    continue;
                }

                Decrement(ref remainingTime);
            }

            Console.Write("0\n");
            Console.Read();
        }

        static void Decrement(ref int baseValue, int step = 1)
        {
            ref int newTime = ref baseValue;
            ref int newStep = ref step;
            newTime = newTime - newStep;
        }
    }
}