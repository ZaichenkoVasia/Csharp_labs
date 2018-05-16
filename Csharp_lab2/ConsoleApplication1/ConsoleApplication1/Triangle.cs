//Абстрактий клас трикутника

using System;

namespace ConsoleApplication1
{
    public abstract class Triangle : Object
    {
        protected double a;            //перша сторона
        protected double b;            //друга сторона
        protected double angle;        
        protected double perimetr;
        protected double squere;

        public Triangle(double a, double b, double angle)
        {
        }

        public double A
        {
            get { return a; }
            set
            {
                if (value > 0)
                    a = value;
                else
                    throw new MyException();
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                if (value > 0)
                    b = value;
                else
                    throw new MyException();
            }
        }

        public double Angle
        {
            get { return angle; }
            set
            {
                if (angle > 0 && angle < 180)
                    angle = value;
            }
        }

        public bool IsCorrect(double a, double b, double angle)
        {
            return a > 0 && b > 0 && angle > 0 && angle < 180;
        }

        public abstract void ToString();

        public abstract double Perimetr();

        public abstract double Squere();

        public abstract void Calculate();

        public bool Equals(Triangle triangle)
        {
            return triangle.a == a && triangle.b == b && triangle.angle == angle;
        }

        public static bool operator ==(Triangle triangle1, Triangle triangle2)
        {
            return triangle1.Equals(triangle2);
        }

        public static bool operator !=(Triangle triangle1, Triangle triangle2)
        {
            return !triangle1.Equals(triangle2);
        }

        public override int GetHashCode()
        {
            return (int) a ^ (int) b;
        }
    }
}