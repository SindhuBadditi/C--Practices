using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<string> java = new HashSet<string>();
        HashSet<string> python = new HashSet<string>();

        while (true)
        {
            Console.WriteLine("1.  Add Student to Java Course");
            Console.WriteLine("2.  Add Student to Python Course");
            Console.WriteLine("3.  Display All Java Students");
            Console.WriteLine("4.  Display All Python Students");
            Console.WriteLine("5.  Display Students Enrolled in Either Java or Python");
            Console.WriteLine("6.  Display Students Enrolled in Both Java and Python");
            Console.WriteLine("7.  Display Students in Java but Not in Python");
            Console.WriteLine("8.  Display Students Enrolled in Exactly One Course");
            Console.WriteLine("9.  Check Whether Every Java Student Is Also in Python");
            Console.WriteLine("10. Check Whether Every Python Student Is Also in Java");
            Console.WriteLine("11. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("\nRegistering students for Java");
                        Console.Write("Enter student name for Java Course: ");
                        string name = Console.ReadLine();

                        bool added = java.Add(name);

                        if (added)
                        {
                            Console.WriteLine("Student added to Java Course successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Student already exists in Java Course.");
                        }
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("\nRegistering students for Python");
                        Console.Write("Enter student name for Python Course: ");
                        string name = Console.ReadLine();

                        bool added = python.Add(name);

                        if (added)
                        {
                            Console.WriteLine("Student added to Python Course successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Student already exists in  Python Course.");
                        }
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("\nDisplay java people");
                        IEnumerator<string> enumerator = java.GetEnumerator();
                        Console.Write("Java course registered students: ");
                        while (enumerator.MoveNext())
                        {
                            Console.Write(enumerator.Current+" ");
                        }
                        Console.WriteLine();
                        break;
                    }

                case 4:
                    {
                        Console.WriteLine("\nDisplay python people");
                        IEnumerator<string> enumerator = python.GetEnumerator();
                        Console.Write("Python course registered students: ");
                        while (enumerator.MoveNext())
                        {
                            Console.Write(enumerator.Current + " ");
                        }
                        Console.WriteLine();
                        break;
                    }

                case 5:
                    {
                        Console.Write("\nStudents registered for courses: ");
                        HashSet<string> result = new HashSet<string>(java);
                        result.UnionWith(python);
                        IEnumerator<string> enumerator = result.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Console.Write(enumerator.Current+" ");
                        }
                        Console.WriteLine() ;
                        break;
                    }

                case 6:
                    {
                        Console.Write("\nStudents registered for both courses: ");
                        HashSet<string> result = new HashSet<string>(java);
                        result.IntersectWith(python);
                        IEnumerator<string> enumerator = result.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Console.Write(enumerator.Current + " ");
                        }
                        Console.WriteLine();
                        break;
                    }

                case 7:
                    {
                        HashSet<string> result = new HashSet<string>(java);
                        result.ExceptWith(python);
                        Console.Write("Students in Java but not in Python:");
                        IEnumerator<string> enumerator = result.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Console.Write(enumerator.Current+" ");
                        }
                        Console.WriteLine();
                        break;
                    }

                case 8:
                    {
                        HashSet<string> result = new HashSet<string>(java);
                        result.SymmetricExceptWith(python);
                        Console.WriteLine("Students in exactly one course:");
                        IEnumerator<string> enumerator = result.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Console.WriteLine(enumerator.Current);
                        }

                        break;
                    }

                case 9:
                    {
                        Console.WriteLine("Checking whether every student in JAVA is also present in PYTHON...");

                        bool result = java.IsSubsetOf(python);

                        if (result)
                        {
                            Console.WriteLine("Yes. Every student in java is also present in python.");
                            Console.WriteLine("Java is a subset of python.");
                        }
                        else
                        {
                            Console.WriteLine("No. Every student in java is not present in python.");
                            Console.WriteLine("java is not a subset of python.");
                        }

                        break;
                    }

                case 10:
                    {
                        Console.WriteLine("Checking whether every student in python is also present in java...");
                        bool result = java.IsSupersetOf(python);
                        if (result)
                        {
                            Console.WriteLine("Yes. Every student in python is also present in java.");
                            Console.WriteLine("Java is a superset of Python.");
                        }
                        else
                        {
                            Console.WriteLine("No. Every student in python is not present in java.");
                            Console.WriteLine("Java is not a superset of Python.");
                        }
                        break;
                    }

                case 11:
                    {
                        Console.WriteLine("Exiting...");
                        return;
                    }

                default:
                    {
                        Console.WriteLine("Invalid choice.");
                        break;
                    }
            }
        }
    }
}