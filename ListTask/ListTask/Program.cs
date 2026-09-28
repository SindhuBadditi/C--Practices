using System;
using System.Xml.Linq;
class Student
{
    /*Allow the user to enter student names.
Store all names in a list.
Display all students.
Search whether a particular student is present.
Remove a student by name.
Remove a student using their position.
Display the total number of students.
Provide an option to clear all students.*/

    static void Main(String[] args)
    {
        List<String> names= new List<String>();
        while (true)
        {
            Console.WriteLine("\n1.Store names in a list.");
            Console.WriteLine("2.store multiple names in a list");
            Console.WriteLine("3.Display all students");
            Console.WriteLine("4.search a name in particular position");
            Console.WriteLine("5.Remove student by name");
            Console.WriteLine("6.remove student by their position");
            Console.WriteLine("7.Display the count of students");
            Console.WriteLine("8.Clear all students data");
            Console.WriteLine("9.Exit");
            Console.Write("\nEnter Choice:");
            int choice=int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    string choose;
                    do
                    {
                        Console.Write("Enter a name:");
                        String name = Console.ReadLine();
                        names.Add(name);
                        Console.Write("do you want to continue storing the names(Y/N):");
                        choose = Console.ReadLine();
                    } while (choose.Substring(0,1).Equals("y",StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine("data stored successfully!!");
                    break;
                case 2:
                    Console.Write("\nEnter multiple names separated by comma:");
                    String input= Console.ReadLine();
                    String[] multipleInputs = input.Split(",");
                    names.AddRange(multipleInputs);
                    Console.WriteLine("inputs are stored successfully!!");
                    break;
                case 3:Console.WriteLine("Printing the data:");
                    IEnumerator<String> enumerator= names.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Console.WriteLine(enumerator.Current);
                    }
                    break;
                case 4: Console.WriteLine("\nSearch a name by the position");
                    Console.Write("ENter a position to search in List:");
                    int position=int.Parse(Console.ReadLine());
                    Console.WriteLine($"{names[position]}");
                    break;
                case 5:Console.WriteLine("\nRemove by a name");
                    Console.Write("ENter a name to remove in the list:");
                    string item= Console.ReadLine();
                    bool status = names.Remove(item);
                    if (status)
                    {
                        Console.WriteLine("Data removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("validate your input because it is not found in a list");
                    }
                    break;
                case 6:Console.WriteLine("\nRemove by their position");
                    Console.Write("ENter position to remove the data:");
                    int index=Convert.ToInt32(Console.ReadLine());
                    if (index >= 0 && index < names.Count) 
                    { 
                        names.RemoveAt(index); 
                        Console.WriteLine("Data removed successfully"); 
                    }
                    else 
                    { 
                        Console.WriteLine("Invalid position. Please enter a valid index."); 
                    }
                    break;
                case 7:Console.WriteLine("\nDisplay the count of items in a list");
                    Console.WriteLine($"The total items in a list {names.Count}");
                    break;
                case 8:Console.WriteLine("Clearing all data");
                    names.Clear();
                    if (names.Count == 0)
                    {
                        Console.WriteLine($"list data cleared.Now List size is {names.Count}");
                    }
                    else
                    {
                        Console.WriteLine("Something interrupted");
                    }
                    break;
                case 9:Console.WriteLine("\nExiting....");
                    return;
                default:Console.WriteLine("\nInvalid Choice...");
                    break;
            }

        }
    }
}