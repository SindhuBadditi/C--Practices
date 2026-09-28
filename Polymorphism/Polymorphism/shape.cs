using System;

namespace Polymorphism
{
    class shape
    {
        public virtual void calculateArea()
        {
            Console.WriteLine("Calculate the area of a shape");
        }
    }
    class Rectangle : shape
    {
        float length;
        float width;
        public float Length { get; set; }
        public float Width { get; set; }

        public override void calculateArea()
        {
            Console.WriteLine($"Length: {Length}");
            Console.WriteLine($"Width: {Width}");
            Console.WriteLine($"Area of a rectangle is {Length*Width}");
        }
    }
    class Circle : shape
    {
        float radius;
        const float pi = 3.14f;
        public float Radius { get; set; }
        public override void calculateArea()
        {
            Console.WriteLine($"Radius: {Radius}");
            Console.WriteLine($"Area of a circle is {pi*Radius*Radius}");
        }
    }
    /*class Program
    {
        static void Main()
        {
            shape s = new shape();
            s.calculateArea();

            // Rectangle
            Rectangle rectangle = new Rectangle();

            Console.Write("Enter length of rectangle: ");
            rectangle.Length = float.Parse(Console.ReadLine());

            Console.Write("Enter width of rectangle: ");
            rectangle.Width = float.Parse(Console.ReadLine());

            s = rectangle;
            s.calculateArea();

            // Circle
            Circle circle = new Circle();

            Console.Write("Enter radius of circle: ");
            circle.Radius = float.Parse(Console.ReadLine());

            s = circle;
            s.calculateArea();
        }
    }*/
}
