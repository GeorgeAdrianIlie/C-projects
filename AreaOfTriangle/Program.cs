using System;

namespace AreaOfTriangle
{
    public struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public struct Triangle
    {
        public Point A;
        public Point B;
        public Point C;

        public Triangle(Point a, Point b, Point c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }
    }

    public class Program
    {
        public static double CalculateArea(Triangle triangle)
        {
            const double half = 2;

            return Math.Abs((triangle.A.X * (triangle.B.Y - triangle.C.Y) + triangle.B.X * (triangle.C.Y - triangle.A.Y) + triangle.C.X * (triangle.A.Y - triangle.B.Y)) / half);
        }

        public static Point ReadPoint()
        {
            string[] point = Console.ReadLine().Split(' ');
            return new Point(Convert.ToDouble(point[0]), Convert.ToDouble(point[1]));
        }

        public static void Main()
        {
            double area = CalculateArea(new Triangle(ReadPoint(), ReadPoint(), ReadPoint()));
            Console.WriteLine(area);
            Console.Read();
        }
    }
}