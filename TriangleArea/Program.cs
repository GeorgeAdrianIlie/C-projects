using System;

namespace TriangleArea
{
    struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    struct Triangle
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

    class Program
    {
        static void Main()
        {
            double area = CalculateArea(new Triangle(ReadPoint(), ReadPoint(), ReadPoint()));
            Console.WriteLine(area);
            Console.Read();
        }

        static double CalculateArea(Triangle triangle)
        {
            return Math.Abs((Point A.X * (Point B.Y - Point C.Y) + Point B.X * (Point C.Y - Point A.Y) + Point C.X * (Point A.Y - Point B.Y)) / 2.0);
        }

        static Point ReadPoint()
        {
            string[] point = Console.ReadLine().Split(' ');
            return new Point(Convert.ToDouble(point[0]), Convert.ToDouble(point[1]));
        }
    }
}
