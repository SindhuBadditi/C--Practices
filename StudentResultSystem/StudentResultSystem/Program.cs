class result
{
    private string studentName;
    private int rollNumber;
    private int marks;
    public result(string studentName, int rollNumber, int marks)
    { 
            this.studentName = studentName;
        this.rollNumber = rollNumber;
        this.marks = marks;
    }
    public int Marks {  
        get { 
            if(marks>=0 && marks<=100) return marks;
            return -1;
        } 
    } 
    static void Main(String[] args)
    {
        Console.Write("ENter a student name:");
        string name=Console.ReadLine();
        Console.Write("Enter student roll number:");
        int no=int.Parse(Console.ReadLine());
        Console.Write("Enter student marks:");
        int marks=int.Parse(Console.ReadLine());
        result r = new result(name,no,marks);
        if (r.Marks == -1)
        {
            Console.WriteLine("Invalid marks!!valid upto 0 to 100");
        }
        else
        {
            Console.WriteLine(r.getResult(r.Marks));
        }
    }
    string getResult(int marks)
    {
        if (marks >= 40)
        {
            return "Pass";
        }
        else
        {
            return "fail";
        }
    }
}