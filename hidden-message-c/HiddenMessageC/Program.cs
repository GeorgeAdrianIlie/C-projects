using System;

namespace HiddenMessageC
{
    class Program
    {
        static void Main(string[] args)
        {
            string encodedPinNumber = Console.ReadLine();
            string startPostionString = Console.ReadLine();
            int step = Convert.ToInt32(Console.ReadLine());

            string pin = "";
            int startPostion = startPostionString[0] - 'a';
            pin += encodedPinNumber[startPostion] + encodedPinNumber[startPostion + step];
            pin += encodedPinNumber[startPostion + 2 * step] + encodedPinNumber[startPostion + 3 * step];

            Console.WriteLine(pin);
            Console.Read();
        }
    }
}
