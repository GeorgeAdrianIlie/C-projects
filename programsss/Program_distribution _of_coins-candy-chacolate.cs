using System;

namespace MyJuniorProject
{
    class Program
    {
        static void Main()
        {
            int studentsIndex = Convert.ToInt32(Console.ReadLine());
            string[] studentsArray = new string[studentsIndex];
            for (int i = 0; i < studentsIndex; i++)
            {
                studentsArray[i] = Console.ReadLine();
            }

            int[] studentsGrades = new int[studentsIndex];
            for (int i = 0; i < studentsIndex; i++)
            {
                studentsGrades[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[] rewards = new int[studentsIndex];
            for (int i = 0; i < studentsIndex; i++)
            {
                rewards[i] = 1;
            }

            for (int i = 0; i < studentsIndex - 1; i++)
            {
                if (studentsGrades[i] < studentsGrades[i + 1])
                {
                rewards[i + 1] = rewards[i] + 1;
                }
            }

            for (int i = studentsIndex - 1; i > 0; i--)
            {
                if (studentsGrades[i] < studentsGrades[i - 1])
                {
                rewards[i - 1] = rewards[i] + 1;
                }
            }

            for (int i = 0; i < studentsIndex; i++)
            {
                Console.WriteLine("{0} {1}", studentsArray[i], rewards[i]);
            }
        }
    }
}