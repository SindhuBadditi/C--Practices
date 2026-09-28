using System;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Please provide name, age and salary.");
            return;
        }

        string name = args[0];
        int age = int.Parse(args[1]);
        decimal salary = decimal.Parse(args[2]);

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Salary: {salary}");
    }
}