class Employee
{
  /*  1. Mark Employee Attendance
2. Check Employee Attendance
3. Remove Employee Attendance
4. Display All Employees
5. Display Total Employees
6. Remove Employees Based on Condition
7. Clear Attendance
8.Exit*/
  static void Main(String[] args)
  {
        HashSet<String> employees = new HashSet<String>();
        while (true)
        {
            Console.WriteLine("\n===== Employee Attendance System =====");
            Console.WriteLine("1. Mark Employee Attendance");
            Console.WriteLine("2. Check Employee Attendance");
            Console.WriteLine("3. Remove Employee Attendance");
            Console.WriteLine("4. Display All Employees");
            Console.WriteLine("5. Display count of Employees");
            Console.WriteLine("6. Remove Employees Based on Condition");
            Console.WriteLine("7. Clear Attendance");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:Console.WriteLine("\nMarking Attendance");
                    Console.Write("Enter employee name: ");
                    string name = Console.ReadLine();

                    bool added = employees.Add(name);

                    if (added)
                    {
                        Console.WriteLine("Employee attendance marked successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Employee already marked present.");
                    }

                    break;

                case 2:Console.WriteLine("\nCheck Employee Attendance");
                    Console.Write("Enter a name to verify the attendance:");
                    string empName=Console.ReadLine();
                    if (employees.Contains(empName))
                    {
                        Console.WriteLine($"{empName} marked as present.");
                    }
                    else
                    {
                        Console.WriteLine($"{empName} marked as absent");
                    }
                    break;

                case 3:Console.WriteLine("\nRemove Attendance");
                    Console.Write("Enter employee name to remove: ");
                    string item = Console.ReadLine();

                    bool removed = employees.Remove(item);

                    if (removed)
                    {
                        Console.WriteLine($"{item} attendance removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"{item} not found.");
                    }
                    break;

                case 4:Console.WriteLine("\nDisplay all employees");
                    IEnumerator<string> enumerator = employees.GetEnumerator();
                    Console.Write("Employee presentees data: ");
                    while (enumerator.MoveNext())
                    {
                        Console.Write(enumerator.Current+" ");
                    }
                    Console.WriteLine();
                    break;

                case 5:Console.WriteLine("\nCount of employees");
                    Console.WriteLine("Total Employees: " + employees.Count);
                    break;

                case 6:Console.WriteLine("\nRemove based on condition");
                    Console.Write("Enter an employee name keyword:");
                    String keyword=Console.ReadLine();
                    int removedCount = employees.RemoveWhere(name => name.Contains(keyword));
                    if (removedCount > 0)
                    {
                        Console.WriteLine(removedCount + " employee(s) removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No employees found with that name.");
                    }
                    break;

                case 7:Console.WriteLine("\nClear Attendance");
                    employees.Clear();

                    if (employees.Count == 0)
                    {
                        Console.WriteLine("All employee attendance has been cleared successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Attendance could not be cleared.");
                    }


                    break;

                case 8:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

    }
}