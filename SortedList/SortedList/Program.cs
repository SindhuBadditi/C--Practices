using System;
using System.Collections.Generic;

/*
Allow the user to add employee details.
Each employee should have an employee ID, name, and salary.
Use employee ID as the key.
Display all employees in employee ID sorted order.
Allow the user to search for an employee by employee ID.
Allow the user to update an employee's salary.
Allow the user to remove an employee.
Display the total number of employees currently stored.
Provide a menu-driven console application.
*/

class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public decimal Salary { get; set; }

    public Employee(int id, string name, decimal salary)
    {
        EmployeeId = id;
        EmployeeName = name;
        Salary = salary;
    }

    static void Main(String[] args)
    {
        SortedList<int, Employee> employees = new SortedList<int, Employee>();

        while (true)
        {
            Console.WriteLine("\n===== Employee Salary Management =====");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Search Employee");
            Console.WriteLine("3. Update Employee Salary");
            Console.WriteLine("4. Remove Employee");
            Console.WriteLine("5. Display All Employees");
            Console.WriteLine("6. Display Total Employees");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nAdd Employee");

                    Console.Write("Enter employee ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter employee name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter employee salary: ");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());

                    if (employees.ContainsKey(id))
                    {
                        Console.WriteLine("Employee ID already exists.");
                    }
                    else
                    {
                        Employee employee = new Employee(id, name, salary);

                        employees.Add(id, employee);

                        Console.WriteLine("Employee added successfully.");
                    }

                    break;

                case 2:
                    Console.WriteLine("\nSearch Employee");

                    Console.Write("Enter employee ID: ");
                    int searchId = Convert.ToInt32(Console.ReadLine());

                    if (employees.ContainsKey(searchId))
                    {
                        Employee employee = employees[searchId];

                        Console.WriteLine($"Employee ID: {employee.EmployeeId}");
                        Console.WriteLine($"Employee Name: {employee.EmployeeName}");
                        Console.WriteLine($"Salary: {employee.Salary}");
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }

                    break;

                case 3:
                    Console.WriteLine("\nUpdate Employee Salary");

                    Console.Write("Enter employee ID: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());

                    if (employees.ContainsKey(updateId))
                    {
                        Console.Write("Enter new salary: ");
                        decimal newSalary = Convert.ToDecimal(Console.ReadLine());

                        employees[updateId].Salary = newSalary;

                        Console.WriteLine("Salary updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }

                    break;

                case 4:
                    Console.WriteLine("\nRemove Employee");

                    Console.Write("Enter employee ID: ");
                    int removeId = Convert.ToInt32(Console.ReadLine());

                    bool removed = employees.Remove(removeId);

                    if (removed)
                    {
                        Console.WriteLine("Employee removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }

                    break;

                case 5:
                    Console.WriteLine("\nDisplay All Employees");

                    foreach (KeyValuePair<int, Employee> item in employees)
                    {
                        Employee employee = item.Value;

                        Console.WriteLine(
                            $"Employee ID: {employee.EmployeeId}, " +
                            $"Name: {employee.EmployeeName}, " +
                            $"Salary: {employee.Salary}"
                        );
                    }

                    break;

                case 6:
                    Console.WriteLine("\nTotal Employees: " + employees.Count);
                    break;

                case 7:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}