//Клас реалізує колекцію обєктів та події

using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Picture
    {
        public delegate void MethodContainer1(); 
        public delegate void MethodContainer2(); 
        public delegate void MethodContainer3(); 
        public event MethodContainer1 eventAdd;
        public event MethodContainer2 eventRemove;
        public event MethodContainer3 eventChange;

        List<Triangle> figures = new List<Triangle>();

        public Picture() {}

        public Picture(Triangle triangle)
        {
            figures.Add(triangle);
            eventAdd();
        }

        public void ShowInfo()
        {
            foreach (Triangle figure in figures)
            {
                figure.ToString();
            }
        }

        public void AddTriangle(Triangle triangle)
        {
            figures.Add(triangle);
            eventAdd();
        }
        
        public void Remove(int index)
        {
            if (index <= figures.Count)
            {
                figures.RemoveAt(index);
                eventRemove();
            }
            else
            {
                throw new MyIndexOutOfRangeException();
            }
        }

        public void ChangeTriangle(int index, double a, double b, double angle)
        {
            int iter = 0;
            foreach (Triangle element in figures)
            {
                if (iter == index)
                {
                    element.A = a;
                    element.B = b;
                    element.Angle = angle;
                    element.Calculate();
                    break;
                }
            }

            eventChange();
        }

        public double SumSquere()
        {
            double result = 0;
            foreach (Triangle figure in figures)
            {
                result += figure.Squere();
            }
            return result;
        }

        public List<Triangle> DeepCopy()
        {
            List<Triangle> copy = new List<Triangle>();
            double temp_a, temp_b, temp_angle;
            foreach (Triangle element in figures)
            {
                temp_a = element.A;
                temp_b = element.B;
                temp_angle = element.Angle;
                if(element is Equilateral)
                    copy.Add(new Equilateral(temp_a, temp_b, temp_angle));
                else if(element is Isosceles)
                    copy.Add(new Isosceles(temp_a, temp_b, temp_angle));
                else
                    copy.Add(new Right(temp_a, temp_b, temp_angle));
            }
            return copy;
        }
    }
    class MessageAddTriangle 
    {
        public void Message()
        {
            Console.WriteLine("Add element to list!"); 
        }                                                        
    }
    class MessageRemove
    {
        public void Message()
        {
            Console.WriteLine("Remove element from list!"); 
        }                                                        
    }
    class MessageChangeTriangle
    {
        public void Message()
        {
            Console.WriteLine("Change element of list!"); 
        }        
    }
}