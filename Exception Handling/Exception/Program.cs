using System;

class ExceptionDemo
{
    static void Main()
    {
        try
        {
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            if (age < 18)
            {
                throw new Exception("Age must be 18 or above.");
            }

            Console.WriteLine("You are eligible to vote.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Program execution completed.");
        }
    }
}