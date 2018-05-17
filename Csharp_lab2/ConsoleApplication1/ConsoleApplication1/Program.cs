//Клас реалізує 2 лабораторну роботу і тестує методи класів

using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MessageAddTriangle Handler1 = new MessageAddTriangle();
            MessageChangeTriangle Handler2 = new MessageChangeTriangle();
            MessageRemove Handler3 = new MessageRemove();
            Picture picture = new Picture();
            picture.eventAdd += Handler1.Message;
            picture.eventChange += Handler2.Message;
            picture.eventRemove += Handler3.Message;
            
            picture.AddTriangle(new Equilateral(7));
            picture.AddTriangle(new Isosceles(6, 6, 20));
            picture.AddTriangle(new Right(3, 4, 90));
            picture.AddTriangle(new Equilateral(3));
            picture.AddTriangle(new Equilateral(4));
            picture.ChangeTriangle(0, 2);
            picture.ChangeTriangle(1, 2, 2, 30);
            picture.Remove(4);
            picture.ShowInfo();
            Console.WriteLine("Sum of all squere in list: "+picture.SumSquere());
            Tests(picture);
        }

        public static void Tests(Picture picture)
        {
            Triangle triangle1 = new Right(9, 16, 90);
            if(triangle1.Equals(new Right(9, 16, 90)))
                Console.WriteLine("Method Equals is correct");
            else
                Console.WriteLine("Method Equals is not correct");
            Triangle triangle2 = new Right(9, 16, 90);
            if(triangle1.GetHashCode() == triangle2.GetHashCode())
                Console.WriteLine("Method GetHashCode is correct");
            else
                Console.WriteLine("Method GetHashCode is not correct");
            List<Triangle> copy = new List<Triangle>();
            copy = picture.DeepCopy();
            Console.WriteLine("Test method DeepCopy:");
            foreach (Triangle element in copy)
            {
                element.ToString();
            }
        }
    }
}
