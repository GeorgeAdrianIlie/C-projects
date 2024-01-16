using System;

namespace myJuniorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputData = Console.ReadLine();
            char[] letters = inputData.ToCharArray();

            string reversal = String.Empty;
            for (int i = letters.Length - 1; i > -1; i--)
            {
                reversal += letters[i];
            }
            char[] reverse = reversal.ToCharArray();

            int count = 0;
            for(int i=0; i<letters.Length; i++){
                char a = letters[i];
                char b = reverse[i];
                if(a == b)
                count++;
            }
            
            if (inputData == reversal){
                Console.WriteLine(count);
            }else if(inputData != reversal){
                Console.WriteLine(count/2);
            }else{
                Console.WriteLine("Error input OR null");
            }

        }
    }
}