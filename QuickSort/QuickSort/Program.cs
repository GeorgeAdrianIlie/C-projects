using System;

namespace QuickSort
{
    public struct Student
    {
        public string Name;
        public double Grade;

        public Student(string name, double grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Student[] students = ReadStudents();
            QuickSort(students, 0, students.Length - 1);
            Print(students);
            Console.Read();
        }

        public static void QuickSort(Student[] students, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivotIndex = Partition(students, start, end);
            QuickSort(students, start, pivotIndex - 1);
            QuickSort(students, pivotIndex + 1, end);
        }

        public static int Partition(Student[] students, int left, int right)
        {
            int i = left;
            int pivotPosition = right;

            for (int j = left; j <= right; j++)
            {
                if (Comparation(students, j, pivotPosition))
                {
                    (students[i], students[j]) = (students[j], students[i]);
                    i++;
                }
            }

            (students[i], students[right]) = (students[right], students[i]);
            return i;
        }

        public static bool Comparation(Student[] students, int j, int pivot)
        {
            int letterIndex = 0;
            string reper1 = students[j].Name;
            string reper2 = students[pivot].Name;
            while (students[j].Name[letterIndex] == students[pivot].Name[letterIndex])
            {
                if (letterIndex < reper1.Length - 1 && letterIndex < reper2.Length - 1)
                {
                    letterIndex++;
                }
                else
                {
                    return false;
                }
            }

            return students[j].Name[letterIndex] < students[pivot].Name[letterIndex];
        }

        public static void Print(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(string.Format("{0}: {1:F2}", students[i].Name, students[i].Grade));
            }
        }

        public static Student[] ReadStudents()
        {
            int studentsNumber = Convert.ToInt32(Console.ReadLine());
            Student[] result = new Student[studentsNumber];

            for (int i = 0; i < studentsNumber; i++)
            {
                string[] studentData = Console.ReadLine().Split(':');
                result[i] = new Student(studentData[0], Convert.ToDouble(studentData[1]));
            }

            return result;
        }
    }
}