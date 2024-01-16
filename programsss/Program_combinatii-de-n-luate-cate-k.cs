using System;

namespace myJuniorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int factn;
            int factk;
            int factnk;
            int n = Convert.ToInt32(Console.ReadLine());
            int k = Convert.ToInt32(Console.ReadLine());
            int nk = n-k;
            factn = n;
            factk = k;
            factnk = factn - factk;
            for(int i = 1; i < n; i++)
            {
                factn = factn * i;
            }
            for(int i = 1; i < k; i++)
            {
                factk = factk * i;
            }
            for(int i = 1; i < nk; i++)
            {
                factnk = factnk * i;
            }
            int nCk = factn / (factk * factnk);
            
            Console.WriteLine(nCk);
        }
    }
}