using System;
using System.Collections.Generic;

class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public Employee(int id, string name, string department, decimal salary)
    {
        EmployeeId = id;
        EmployeeName = name;
        Department = department;
        Salary = salary;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {EmployeeId}");
        Console.WriteLine($"Name: {EmployeeName}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Salary: {Salary}");
        Console.WriteLine("----------------------");
    }
}




class EmployeeManager
{
    List<Employee> employees = new List<Employee>();


    public void AddEmployee(int id, string name, string department, decimal salary)
    {
        foreach (Employee employee in employees)
        {
            if (employee.EmployeeId == id)
            {
                throw new EmployeeException("Employee ID already exists.");
            }
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmployeeException("Employee name cannot be empty.");
        }

        if (salary <= 0)
        {
            throw new EmployeeException("Salary must be greater than zero.");
        }

        Employee newEmployee =
            new Employee(id, name, department, salary);

        employees.Add(newEmployee);

        Console.WriteLine("Employee added successfully.");
    }


    public void ViewEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees available.");
            return;
        }

        foreach (Employee employee in employees)
        {
            employee.Display();
        }
    }


    public void SearchEmployee(int id)
    {
        foreach (Employee employee in employees)
        {
            if (employee.EmployeeId == id)
            {
                employee.Display();
                return;
            }
        }

        throw new EmployeeException("Employee not found.");
    }


    public void UpdateSalary(int id, decimal newSalary)
    {
        if (newSalary <= 0)
        {
            throw new EmployeeException("Salary must be greater than zero.");
        }

        foreach (Employee employee in employees)
        {
            if (employee.EmployeeId == id)
            {
                employee.Salary = newSalary;

                Console.WriteLine("Salary updated successfully.");
                return;
            }
        }

        throw new EmployeeException("Employee not found.");
    }


    public void RemoveEmployee(int id)
    {
        foreach (Employee employee in employees)
        {
            if (employee.EmployeeId == id)
            {
                employees.Remove(employee);

                Console.WriteLine("Employee removed successfully.");
                return;
            }
        }

        throw new EmployeeException("Employee not found.");
    }
}


class Program
{
    static void Main()
    {
        EmployeeManager manager = new EmployeeManager();

        while (true)
        {
            Console.WriteLine("\n===== Employee Salary Management =====");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View Employees");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Update Salary");
            Console.WriteLine("5. Remove Employee");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Employee ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Employee Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Department: ");
                        string department = Console.ReadLine();

                        Console.Write("Enter Salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());

                        manager.AddEmployee(id, name, department, salary);
                        break;


                    case 2:
                        manager.ViewEmployees();
                        break;


                    case 3:
                        Console.Write("Enter Employee ID: ");
                        int searchId = int.Parse(Console.ReadLine());

                        manager.SearchEmployee(searchId);
                        break;


                    case 4:
                        Console.Write("Enter Employee ID: ");
                        int updateId = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Salary: ");
                        decimal newSalary = decimal.Parse(Console.ReadLine());

                        manager.UpdateSalary(updateId, newSalary);
                        break;


                    case 5:
                        Console.Write("Enter Employee ID: ");
                        int removeId = int.Parse(Console.ReadLine());

                        manager.RemoveEmployee(removeId);
                        break;


                    case 6:
                        Console.WriteLine("Program exited.");
                        return;


                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter valid input.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}

class EmployeeException : Exception
{
    public EmployeeException(string message) : base(message)
    {
    }
}
