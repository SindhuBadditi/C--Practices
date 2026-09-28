using System.Collections;
using System.Collections.Generic;
class Task
{
  /*  Add employees with unique IDs.
Search an employee using their ID.
Display the employee name if the ID exists.
Display an appropriate message if the ID doesn't exist.
Update an employee's name.
Remove an employee.
Display all employees.
Display the total number of employees.*/
  static void Main(String[] args)
  {
        Dictionary<int,String> employees = new Dictionary<int,String>();
        while (true)
        {
            Console.WriteLine("\n1.Add data");
            Console.WriteLine("2.Searching the data without exception");
            Console.WriteLine("3.Check whether key is existed");
            Console.WriteLine("4.Check whether the value is existed");
            Console.WriteLine("5.update value");
            Console.WriteLine("6.Remove the data");
            Console.WriteLine("7.Display only keys");
            Console.WriteLine("8.Display only values");
            Console.WriteLine("9.Display the data");
            Console.WriteLine("10.display the count of items");
            Console.WriteLine("11.Clear the data");
            Console.WriteLine("12.Exit");

            Console.Write("\nEnter your choice:");
            int choice=int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: 
                    string choose; 
                    do {
                        Console.Write("\nENter employee Id:");
                        int id=int.Parse(Console.ReadLine());
                        Console.Write("Enter employee name:"); 
                        String names = Console.ReadLine(); 
                        employees.Add(id, names);
                        Console.Write("do you want to continue storing the names(Y/N):");
                        choose = Console.ReadLine(); 
                    } while (choose.Substring(0, 1).Equals("y", StringComparison.OrdinalIgnoreCase)); 
                    Console.WriteLine("data stored successfully!!"); 
                    break;
                case 2:Console.WriteLine("searching data....");
                    Console.Write("Enter your employee id to get data:");
                    int id1=int.Parse(Console.ReadLine());
                    bool verify=employees.TryGetValue(id1, out string value);
                    if (verify)
                    {
                        Console.WriteLine("Employee Name: " + value);
                    }
                    else
                    {
                        Console.WriteLine("Employee ID not found.");
                    }

                    break;
                case 3:Console.WriteLine("\nCheck whether Key is existed");
                    Console.Write("Enter employee id to verify the existence:");
                    int key = int.Parse(Console.ReadLine());
                    bool check = employees.ContainsKey(key);
                    if (check) { Console.WriteLine($"{key} is existed in collection"); }
                    else { Console.WriteLine($"{key} is not existed in the collection"); }
                    break;
                case 4:Console.WriteLine("\nCheck whether value is existed");
                    Console.Write("Enter employee name to verify the existence:");
                    string name = Console.ReadLine();
                    bool checking = employees.ContainsValue(name);
                    if (checking) { Console.WriteLine($"{name} is existed in collection"); }
                    else { Console.WriteLine($"{name} is not existed in the collection"); }
                    break;
                case 5:Console.WriteLine("\nUpdate the value");
                    Console.Write("Enter employee id to update the value:");
                    int eid = int.Parse(Console.ReadLine());
                    Console.Write("Enter name to update:");
                    String ename=Console.ReadLine();
                    Console.WriteLine($"Before updating {employees[eid]}");
                    Console.WriteLine($"After updating {employees[eid]=ename}");
                    break;
                case 6:Console.WriteLine("Remove the data");
                    Console.Write("ENter an employee id to remove the data: "); 
                    int item =int.Parse(Console.ReadLine()); 
                    bool status = employees.Remove(item); 
                    if (status) { Console.WriteLine("Data removed successfully"); } 
                    else { Console.WriteLine("validate your input because it is not found in a dictionary"); }
                    break;
                case 7:Console.WriteLine("\nDisplay only keys");
                    Console.Write("employee id's present here, ");
                    foreach (int id in employees.Keys)
                    {
                        Console.Write(id+" ");
                    }
                    Console.WriteLine();
                    break;
                case 8:
                    Console.WriteLine("\nDisplay only values");
                    Console.Write("employee names present here, ");
                    foreach(String values in employees.Values)
                    {
                        Console.Write(values);
                    }
                    Console.WriteLine();
                    break;
                case 9:Console.WriteLine("\nDisplay the data");
                    IEnumerator<KeyValuePair<int,String>> enumerator = employees.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Console.WriteLine($"{enumerator.Current.Key} - {enumerator.Current.Value}");
                    }
                    break;
                case 10:Console.WriteLine("\nDisplay the count of items");
                    Console.WriteLine($"The total count of items in employees is {employees.Count}");
                    break;
                case 11: Console.WriteLine("Clearing all data"); 
                    employees.Clear(); 
                    if (employees.Count == 0) { Console.WriteLine($"Dictionary data cleared.Now Dictionary size is {employees.Count}"); } 
                    else { Console.WriteLine("Something interrupted"); } 
                    break;
                case 12: Console.WriteLine("\nExiting...."); 
                    return;
                default: Console.WriteLine("\nInvalid Choice..."); 
                    break;
            }
        }
  }



}