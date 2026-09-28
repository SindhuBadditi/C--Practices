using System;
using System.Collections.Generic;

class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public int TotalLeaveLimit { get; set; }
    public int LeaveTaken { get; set; }

    public Employee(int id, string name, int totalLeaveLimit, int leaveTaken)
    {
        EmployeeId = id;
        EmployeeName = name;
        TotalLeaveLimit = totalLeaveLimit;
        LeaveTaken = leaveTaken;
    }
}

class EmployeeManagement
{
    List<Employee> employees = new List<Employee>();

    static void Main(string[] args)
    {
        EmployeeManagement e = new EmployeeManagement();

        while (true)
        {
            Console.WriteLine("\n1.Add Employee");
            Console.WriteLine("2.View Employee");
            Console.WriteLine("3.Apply Leave");
            Console.WriteLine("4.Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("\nEnter employee id: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter employee name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter total leave limit: ");
                        int totalLeave = int.Parse(Console.ReadLine());

                        Console.Write("Enter leaves already taken: ");
                        int leaveTaken = int.Parse(Console.ReadLine());

                        Employee employee =
                            new Employee(id, name, totalLeave, leaveTaken);

                        e.AddEmployee(employee);

                        break;
                    }

                case 2:
                    {
                        try
                        {
                            Console.WriteLine(
                                "\nView Employee Leave Details");

                            Console.Write("Enter employee id: ");
                            int id = int.Parse(Console.ReadLine());

                            e.ViewEmployee(id);
                        }
                        catch (LeaveException ex)
                        {
                            Console.WriteLine(
                                "Exception-Message: " + ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine(
                                "Employee viewing operation completed.");
                        }

                        break;
                    }

                case 3:
                    {
                        try
                        {
                            Console.WriteLine("\nApplying Leave");

                            Console.Write("Enter employee id: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write(
                                "Enter number of leave days: ");
                            int days = int.Parse(Console.ReadLine());

                            e.ApplyLeave(id, days);
                        }
                        catch (LeaveException ex)
                        {
                            Console.WriteLine(
                                "Exception-Message: " + ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine(
                                "Leave application process completed.");
                        }

                        break;
                    }

                case 4:
                    {
                        Console.WriteLine("Exiting.....");
                        return;
                    }

                default:
                    {
                        Console.WriteLine("Invalid choice!!!!");
                        break;
                    }
            }
        }
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
        Console.WriteLine("Employee added successfully.");
    }

    public void ViewEmployee(int id)
    {
        foreach (Employee employee in employees)
        {
            if (employee.EmployeeId == id)
            {
                Console.WriteLine("\n--- Employee Leave Details ---");
                Console.WriteLine("Employee ID: " + employee.EmployeeId);
                Console.WriteLine("Employee Name: " + employee.EmployeeName);
                Console.WriteLine("Total Leave Limit: " +employee.TotalLeaveLimit);
                Console.WriteLine("Leave Taken: " +employee.LeaveTaken);
                Console.WriteLine("Remaining Leave: " +(employee.TotalLeaveLimit -employee.LeaveTaken));

                return;
            }
        }
        throw new LeaveException("Employee Not Found");
    }

    public void ApplyLeave(int id, int days)
    {
        for (int i = 0; i < employees.Count; i++)
        {
            Employee employee = employees[i];
            if (employee.EmployeeId == id)
            {
                if (days <= 0)
                {
                    throw new LeaveException("Leave days must be greater than 0.");
                }
                else if (days > (employee.TotalLeaveLimit-days))
                {
                    throw new LeaveLimitExceededException("Leave limit exceeded. Only " +employee.TotalLeaveLimit +" leave days are available.");
                }
                else
                {
                    employee.LeaveTaken += days;
                    employee.TotalLeaveLimit -= days;
                    Console.WriteLine("\n--- Leave Details ---");
                    Console.WriteLine("Employee ID: " + employee.EmployeeId);
                    Console.WriteLine("Employee Name: " + employee.EmployeeName);
                    Console.WriteLine("Leave Applied: " + days);
                    Console.WriteLine("Leave Taken: " + employee.LeaveTaken);
                    Console.WriteLine("Remaining Leave: " + (employee.TotalLeaveLimit));
                    Console.WriteLine("Leave approved successfully.");

                    return;
                }
            }
        }
        throw new LeaveException("Employee Not Found");
    }
}

class LeaveException : ApplicationException
{
    public LeaveException(string message) : base(message)
    {
    }
}

class LeaveLimitExceededException : LeaveException
{
    public LeaveLimitExceededException(string message) : base(message)
    {
    }
}