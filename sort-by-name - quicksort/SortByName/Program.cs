using System;

namespace SortByName
{
    struct Student
    {
        public string Name;
        public double Grade;

        public Student(string name, double grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }

    class Program
    {
        static void Main()
        {
            Student[] students = ReadStudents();
            QuickSort(students, 0, students.Length - 1);
            Print(students);
            Console.Read();
        }

        static void QuickSort(Student[] students, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            Print(students);
            int pivotIndex = Partition(students, start, end);
            QuickSort(students, start, pivotIndex - 1);
            QuickSort(students, pivotIndex + 1, end);
        }

        static int Partition(Student[] students, int left, int right)
        {
            int i = left;
            int pivot = students[right];
            int temp;

            for (int j = left; j <= right; j++)
            {
                if (Comparation(students, j, pivot))
                {
                    temp = students[i];
                    students[i] = students[j];
                    students[j] = temp;
                    i++;
                }
            }

            temp = students[right];
            students[right] = students[i];
            students[i] = temp;
            return i;
        }

        static bool Comparation(Student[] students, int j, int pivot)
        {
            int letterIndex = 0;
            while (students[j].Name[letterIndex] == students[pivot].Name[letterIndex])
            {
                letterIndex++;
            }

            while (students[j].Name[letterIndex] < students[pivot].Name[letterIndex])
            {
                return true;
            }

            return false;
        }

        static void Print(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(string.Format("{0}: {1:F2}", students[i].Name, students[i].Grade));
            }
        }

        static Student[] ReadStudents()
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
