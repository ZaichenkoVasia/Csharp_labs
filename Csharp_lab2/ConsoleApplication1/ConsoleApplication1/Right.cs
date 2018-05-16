//Дочірний клас від Triangle, який реалізує прямокутний трикутник

using System;

namespace ConsoleApplication1
{
    public class Right : Triangle
    {
        private double c;        //третя сторона
        public Right(double a, double b, double angle) : base(a, b, angle)
        {
            if (IsCorrect(a, b, angle))
            {
                this.a = a;
                this.b = b;
                this.angle = angle;
                c = Math.Sqrt(a * a + b * b);
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
            perimetr =  a + b + c;
            squere = a * b / 2;
        }
        public override void ToString()
        {
            Console.WriteLine("Right: side a = " + a + " side b = " + b + " side c = " + c + " angle = " +angle
                              + " perimetr = "+ perimetr + " square = "+ squere);
        }
    }
}