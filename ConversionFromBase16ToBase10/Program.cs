using System;

namespace ConversionFromBase16ToBase10
{
    public class Program
    {
        public static double Conversion(string input, int power, int index)
        {
            const int base16 = 16;
            power--;
            index++;
            var temp = input[index] switch
            {
                'A' => 10,
                'B' => 11,
                'C' => 12,
                'D' => 13,
                'E' => 14,
                'F' => 15,
                _ => -48 + (int)input[index],
            };

            if (power == 0)
            {
                return temp * Math.Pow(base16, power);
            }

            return Math.Pow(base16, power) * temp + Conversion(input, power, index);
        }

        static void Main()
        {
            string input = Console.ReadLine();
            int power = input.Length;
            const int index = -1;
            Console.WriteLine(Conversion(input, power, index));
        }
    }
}