using System;

namespace myJuniorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string CToTest = Console.ReadLine();
            int admited = Convert.ToInt32(Console.ReadLine());
            string C = Console.ReadLine();
            string[] A = new string[admited];
            for(int i=0; i<admited; i++){
                A[i] = C; 
                C = Console.ReadLine();
                }
            Boolean isExist = false;
            for(int j=0; j< admited; j++){
                if(CToTest == A[j]){
                    isExist = true;
                }
            }

            if(isExist){
                Console.WriteLine("True");
            }else{
                Console.WriteLine("False");
            }
            
        }
    }
}