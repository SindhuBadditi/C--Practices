using System;
using System.Security.Cryptography.X509Certificates;
namespace EmployeeTracker
{
    class EmployeeExpense
    {
        private string ename;
        private string empId;
        private decimal salary;
        private decimal totalSalary;
        static decimal totalExpenses = 0;
        static int noOfExpenses = 0;
        decimal percentage;
        public EmployeeExpense(string ename, string empId, decimal salary)
        {
            this.ename = ename;
            this.empId = empId;
            this.salary = salary;
            this.totalSalary = salary;
        }
        static void Main(string[] args)
        {
            Console.Title="Employee Expense Tracker";
            Console.Write("Enter Employee Name:");
            string name = Console.ReadLine();
            Console.Write("Enter Employee Id:");
            String id = Console.ReadLine();
            Console.Write("Enter monthly salary:");
            decimal sal = decimal.Parse(Console.ReadLine());
            EmployeeExpense e=new EmployeeExpense(name,id,sal);
            while (true)
            {
                Console.WriteLine("\n----Expense Tracker Menu----");
                Console.WriteLine("1.Add Expense");
                Console.WriteLine("2.View Total Expenses");
                Console.WriteLine("3.Check Remaining Salary");
                Console.WriteLine("4.Check Expense status");
                Console.WriteLine("5.Exit");
                Console.Write("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:Console.Write("Enter expense Category: ");
                        String category= Console.ReadLine();
                        Console.Write("Enter expense amount:");
                        decimal amt=decimal.Parse(Console.ReadLine());
                        e.addExpense(amt);
                        break;
                    case 2:dispalyExpense();
                        break;
                    case 3:e.checkSalary();
                        break;
                    case 4:Console.WriteLine(e.expenseStatus());
                        break;
                    case 5:e.displayDetails();
                        Environment.Exit(0);
                        break;
                    default:Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
        public void addExpense(decimal amt)
        {
            if (amt <= 0 || amt > this.salary)
            {
                Console.WriteLine("Inalid amount to spend the amount in your salary");
            }
            else
            {
                this.salary -= amt;
                totalExpenses += amt;
                noOfExpenses++;
                Console.WriteLine("EXpense added Successfully!!!!");
            }
        }
        public static void dispalyExpense()
        {
            Console.WriteLine($"The total Expense {totalExpenses}");
        }
        public void checkSalary()
        {
            Console.WriteLine($"Your balance is {salary}");
        }
        public string expenseStatus()
        {
            percentage = (totalExpenses / totalSalary) * 100;
            if (percentage < 30)
            {
                return $"Low Spending-{percentage:F1}%";
            }else if(percentage>=30 && percentage < 60)
            {
                return $"Moderate Spending-{percentage:F1}%";
            }else if(percentage>=60 && percentage < 80)
            {
                return $"High Spending-{percentage:F1}%";
            }else
            {
                return $"Critical Spending-{percentage:F1}%";
            }
        }
        public void displayDetails()
        {
            Console.WriteLine($"Employee Name: {ename}");
            Console.WriteLine($"Employee Id: {empId}");
            Console.WriteLine($"Monthly Salary: {totalSalary}");
            Console.WriteLine($"Total Expenses: {totalExpenses}");
            Console.WriteLine($"Remaining Salary: {salary}");
            Console.WriteLine($"Total Number of expenses entered: {noOfExpenses}");
            Console.WriteLine($"Expense percentage: {percentage:F2}%");
            Console.WriteLine($"Final Expense Status: {this.expenseStatus()}");
        }
    }
}