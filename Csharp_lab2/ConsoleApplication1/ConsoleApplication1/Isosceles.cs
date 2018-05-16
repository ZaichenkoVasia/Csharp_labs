//Дочірний клас від Triangle, який реалізує рівнобедрений трикутник

using System;

namespace ConsoleApplication1
{
    public class Isosceles : Triangle
    {
        private double c;        //третя сторона
        public Isosceles(double a, double b, double angle) : base(a, b, angle)
        {
           
            c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2*a*b*Math.Cos(angle) );
            if ((a == c || b == c || a == b) && IsCorrect(a, b, angle))
            {
                this.a = a;
                this.b = b;
                this.angle = angle;
                Calculate();
            }
            else
            {
                throw new MyException();
            }
        }

        public override double Perimetr()
        { 
            return perimetr;
        }

        public override double Squere()
        { 
            return squere;
        }
        public override void Calculate()
        {
            perimetr = a + b + c;
            squere =  a * b * Math.Sin(angle) / 2;
        }
        public override void ToString()
        {
            Console.WriteLine("Isosceles: side a = " + a + " side b = " + b + " side c = " + c + " angle = " +angle 
                              + " perimetr = " + perimetr + " square = " + squere);
        }
    }
}