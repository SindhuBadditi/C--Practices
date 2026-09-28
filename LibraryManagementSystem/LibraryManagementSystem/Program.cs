using LibraryManagementSystem;

class Program
{

    static void Main()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\n===== Library Management System =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Member");
            Console.WriteLine("3. View All Books");
            Console.WriteLine("4. Search Book");
            Console.WriteLine("5. Search Member");
            Console.WriteLine("6. Borrow Book");
            Console.WriteLine("7. Return Book");
            Console.WriteLine("8. View Borrowed Books");
            Console.WriteLine("9. View All Members");
            Console.WriteLine("10. Total Books");
            Console.WriteLine("11. Total Members");
            Console.WriteLine("12. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    library.AddBook();
                    break;

                case 2:
                    library.AddMember();
                    break;

                case 3:
                    library.ViewAllBooks();
                    break;

                case 4:
                    library.SearchBook();
                    break;

                case 5:
                    library.SearchMember();
                    break;

                case 6:
                    library.BorrowBook();
                    break;

                case 7:
                    library.ReturnBook();
                    break;

                case 8:
                    library.ViewBorrowedBooks();
                    break;

                case 9:
                    library.ViewAllMembers();
                    break;

                case 10:
                    Console.WriteLine($"Total Books: {library.GetTotalBooks()}");
                    break;

                case 11:
                    Console.WriteLine($"Total Members: {library.GetTotalMembers()}");
                    break;

                case 12:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}