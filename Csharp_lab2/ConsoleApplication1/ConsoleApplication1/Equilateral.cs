//Дочірний клас від Triangle, який реалізує рівностороній трикутник

using System;

namespace ConsoleApplication1
{
    public class Equilateral : Triangle
    {
        public Equilateral(double a) : base(a)
        {
            if (IsCorrect(a))
            {
                this.a = a;
                b = a;
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
            perimetr = 3 * a;
            squere = Math.Pow(a, 2) * Math.Sqrt(3) / 4;
        }
        public override void ToString()
        {
            Console.WriteLine("Equilateral: sides = " + a +" angle = 60 perimetr = "+ perimetr + " square = "+ squere);
        }
    }
}
