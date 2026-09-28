using System;

class Program
{
    static void Main()
    {
        Console.Title = "Student Application";

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Student Details");
        Console.WriteLine("----------------");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Registration completed!");
        Console.ResetColor();
        ConsoleKeyInfo key=Console.ReadKey();
        Console.WriteLine($"Key:{key}");
        Console.Clear();

    }
}