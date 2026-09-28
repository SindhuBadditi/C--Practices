using System.Collections;

    /* Allow the user to add student marks.
    Each student should have a student name and marks.
    Display all students and their marks in the order they were added.
    Allow the user to search for a student by name.
    Allow the user to update a student's marks.
    Allow the user to remove a student.
    Display the total number of students currently stored.
    Provide a menu-driven console application.*/

class Student
{
    public string StudentName { get; set; }
    public int Marks { get; set; }

    public Student(string name, int marks)
    {
        StudentName = name;
        Marks = marks;
    }

    static void Main(String[] args)
    {
        ArrayList students = new ArrayList();

        while (true)
        {
            Console.WriteLine("\n===== Student Marks Management =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Update Student Marks");
            Console.WriteLine("4. Remove Student");
            Console.WriteLine("5. Display All Students");
            Console.WriteLine("6. Display Total Students");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nAdd Student");

                    Console.Write("Enter student name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter marks: ");
                    int marks = Convert.ToInt32(Console.ReadLine());

                    Student student = new Student(name, marks);

                    students.Add(student);

                    Console.WriteLine("Student added successfully.");
                    break;

                case 2:
                    Console.WriteLine("\nSearch Student");
                    Console.Write("Enter student name: ");
                    string searchName = Console.ReadLine();
                    bool found = false;
                    foreach (Student item in students)
                    {
                        if (item.StudentName == searchName)
                        {
                            Console.WriteLine($"Student Name: {item.StudentName}, Marks: {item.Marks}");
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;
                case 3:
                    Console.WriteLine("\nUpdate Student Marks");
                    Console.Write("Enter student name: ");
                    string updateName = Console.ReadLine();
                    bool updated = false;
                    foreach (Student item in students)
                    {
                        if (item.StudentName == updateName)
                        {
                            Console.Write("Enter new marks: ");
                            int newMarks = Convert.ToInt32(Console.ReadLine());
                            item.Marks = newMarks;
                            Console.WriteLine("Marks updated successfully.");
                            updated = true;
                            break;
                        }
                    }
                    if (!updated)
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;
                case 4:
                    Console.WriteLine("\nRemove Student");
                    Console.Write("Enter student name: ");
                    string removeName = Console.ReadLine();

                    bool isfound = false;

                    for (int i = 0; i < students.Count; i++)
                    {
                        Student item = (Student)students[i];

                        if (item.StudentName == removeName)
                        {
                            students.RemoveAt(i);
                            Console.WriteLine("Student removed successfully.");
                            isfound = true;
                            break;
                        }
                    }

                    if (!isfound)
                    {
                        Console.WriteLine("Student not found.");
                    }

                    break;
                case 5:
                    Console.WriteLine("\nDisplay All Students");
                    foreach (Student item in students)
                    {
                        Console.WriteLine($"Student Name: {item.StudentName}, Marks: {item.Marks}");
                    }
                    break;
                case 6:
                    Console.WriteLine("\nTotal Students: " + students.Count);
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