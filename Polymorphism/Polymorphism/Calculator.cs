using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main()
        {
            Calculator calculator = new Calculator();

            Console.WriteLine(calculator.Add(10, 20));

            Console.WriteLine(calculator.Add(10, 20, 30));

            Console.WriteLine(calculator.Add(10.5, 20.5));
        }
    }
}
