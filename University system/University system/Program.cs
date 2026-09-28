using System.Xml.Linq;

namespace universitySystem
{
    class university
    {
        static void Main(String [] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Person");
                Console.WriteLine("2. Student");
                Console.WriteLine("3. Professor");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice=int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Person
                        Console.Write("Enter person name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter person age: ");
                        int age = int.Parse(Console.ReadLine());

                        Person p = new Person(name, age);
                        p.displayPersonInfo();
                        break;


                    case 2:
                        // Student
                        Console.Write("Enter student name: ");
                        name = Console.ReadLine();

                        Console.Write("Enter student age: ");
                        age = int.Parse(Console.ReadLine());

                        Console.Write("Enter course: ");
                        string course = Console.ReadLine();

                        Console.Write("Enter roll number: ");
                        int rno = int.Parse(Console.ReadLine());

                        Student student = new Student(name, age, course, rno);
                        student.displayPersonInfo();
                        break;


                    case 3:
                        // Professor
                        Console.Write("Enter professor name: ");
                        name = Console.ReadLine();

                        Console.Write("Enter professor age: ");
                        age = int.Parse(Console.ReadLine());

                        Console.Write("Enter subject: ");
                        string subject = Console.ReadLine();

                        Console.Write("Enter salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());

                        Professor professor =
                            new Professor(name, age, subject, salary);

                        professor.displayPersonInfo();
                        break;


                    case 4:
                        Console.WriteLine("Program ended.");
                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine("Invalid choice. Please choose 1-4.");
                        break;
                }
            }

        }

    }
    class Person
    {
        protected internal string name;
        private protected int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void displayPersonInfo()
        {
            Console.WriteLine($"Person Name: {name}");
            Console.WriteLine($"Person age: {age}");
        }
    }
    class Student : Person
    {
        private string course;
        private int rollNumber;
        public Student(string name, int age, string course, int rollNumber) : base(name, age)
        {
            this.course = course;
            this.rollNumber = rollNumber;
        }
        public void displayPersonInfo()
        {
            Console.WriteLine($"Person Name: {name}");
            Console.WriteLine($"Person age: {age}");
            Console.WriteLine($"Course: {course}");
            Console.WriteLine($"rollNumber: {rollNumber}");
        }
    }
    class Professor:Person
    {
        private string subject;
        private decimal salary;
        public Professor(string name, int age, string subject, decimal salary) : base(name, age)
        {
            this.subject = subject;
            this.salary = salary;
        }
        public void displayPersonInfo()
        {
            Console.WriteLine($"Person Name: {name}");
            Console.WriteLine($"Person age: {age}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"rollNumber: {salary}");
        }
    }
}