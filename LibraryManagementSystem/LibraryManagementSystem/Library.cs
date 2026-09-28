using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace LibraryManagementSystem
{
    internal class Library
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();
        // Member ID → (Book ID → Quantity)
        private Dictionary<string, Dictionary<string, int>> borrowingRecords = new Dictionary<string, Dictionary<string, int>>();

        public void AddBook()
        {
            Console.Write("Book ID: ");
            string bid = Console.ReadLine();

            foreach (Book book in books)
            {
                if (book.BookId == bid)
                {
                    Console.WriteLine("Book ID already exists.");
                    return;
                }
            }

            Console.Write("Book Name: ");
            string bname = Console.ReadLine();

            Console.Write("Author Name: ");
            string aname = Console.ReadLine();

            Console.Write("Available Copies: ");
            int copies = int.Parse(Console.ReadLine());

            if (copies <= 0)
            {
                Console.WriteLine("Copies must be greater than zero.");
                return;
            }

            Book b = new Book(bid, bname, aname, copies);
            books.Add(b);

            Console.WriteLine("Book added successfully.");
        }

        public void AddMember()
        {
            Console.Write("Member ID: ");
            string mid = Console.ReadLine();

            foreach (Member member in members)
            {
                if (member.MemberId == mid)
                {
                    Console.WriteLine("Member ID already exists.");
                    return;
                }
            }

            Console.Write("Member Name: ");
            string mname = Console.ReadLine();

            Console.Write("Mobile Number: ");
            long mobile = long.Parse(Console.ReadLine());

            Member m = new Member(mid, mname, mobile);
            members.Add(m);

            Console.WriteLine("Member registered successfully.");
        }

        public void ViewAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (Book book in books)
            {
                Console.WriteLine("--------------------");
                book.DisplayBookDetails();
                Console.WriteLine("--------------------");
            }
        }

        public void SearchBook()
        {
            Console.Write("Enter Book ID: ");
            string id = Console.ReadLine();

            foreach (Book book in books)
            {
                if (book.BookId == id)
                {
                    book.DisplayBookDetails();
                    return;
                }
            }

            Console.WriteLine("Book not found.");
        }

        public void SearchMember()
        {
            Console.Write("Enter Member ID: ");
            string id = Console.ReadLine();

            foreach (Member member in members)
            {
                if (member.MemberId == id)
                {
                    member.DisplayMemberDetails();
                    return;
                }
            }

            Console.WriteLine("Member not found.");
        }

        public void BorrowBook()
        {
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();

            bool memberFound = false;

            foreach (Member member in members)
            {
                if (member.MemberId == memberId)
                {
                    memberFound = true;
                    break;
                }
            }

            if (!memberFound)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.Write("Enter Book ID: ");
            string bookId = Console.ReadLine();

            Book selectedBook = null;

            foreach (Book book in books)
            {
                if (book.BookId == bookId)
                {
                    selectedBook = book;
                    break;
                }
            }

            if (selectedBook == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.Write("Enter number of copies: ");
            int quantity = int.Parse(Console.ReadLine());

            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                return;
            }

            if (quantity > selectedBook.availableCopies)
            {
                Console.WriteLine("Requested quantity is not available.");
                return;
            }

            // Reduce available book copies
            selectedBook.availableCopies -= quantity;

            // Create a borrowing record for the member if it doesn't exist
            if (!borrowingRecords.ContainsKey(memberId))
            {
                borrowingRecords[memberId] = new Dictionary<string, int>();
            }

            // Add or update the book quantity
            if (borrowingRecords[memberId].ContainsKey(bookId))
            {
                borrowingRecords[memberId][bookId] += quantity;
            }
            else
            {
                borrowingRecords[memberId][bookId] = quantity;
            }

            Console.WriteLine("Book borrowed successfully.");
        }

        public void ReturnBook()
        {
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();

            if (!borrowingRecords.ContainsKey(memberId))
            {
                Console.WriteLine("No borrowing record found for this member.");
                return;
            }

            Console.Write("Enter Book ID: ");
            string bookId = Console.ReadLine();

            if (!borrowingRecords[memberId].ContainsKey(bookId))
            {
                Console.WriteLine("This member has not borrowed this book.");
                return;
            }

            Console.Write("Enter number of copies to return: ");
            int quantity = int.Parse(Console.ReadLine());

            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                return;
            }

            int borrowedQuantity = borrowingRecords[memberId][bookId];

            if (quantity > borrowedQuantity)
            {
                Console.WriteLine("Cannot return more copies than borrowed.");
                return;
            }

            foreach (Book book in books)
            {
                if (book.BookId == bookId)
                {
                    book.availableCopies += quantity;
                    break;
                }
            }

            borrowingRecords[memberId][bookId] -= quantity;

            if (borrowingRecords[memberId][bookId] == 0)
            {
                borrowingRecords[memberId].Remove(bookId);
            }

            if (borrowingRecords[memberId].Count == 0)
            {
                borrowingRecords.Remove(memberId);
            }

            Console.WriteLine("Book returned successfully.");
        }

        public void ViewBorrowedBooks()
        {
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();

            if (!borrowingRecords.ContainsKey(memberId))
            {
                Console.WriteLine("No books currently borrowed by this member.");
                return;
            }

            Console.WriteLine("Borrowed Books:");

            foreach (KeyValuePair<string, int> item in borrowingRecords[memberId])
            {
                string bookId = item.Key;
                int quantity = item.Value;

                foreach (Book book in books)
                {
                    if (book.BookId == bookId)
                    {
                        Console.WriteLine("--------------------");
                        Console.WriteLine($"Book ID: {book.BookId}");
                        Console.WriteLine($"Book Name: {book.BookName}");
                        Console.WriteLine($"Author: {book.AuthorName}");
                        Console.WriteLine($"Quantity Borrowed: {quantity}");
                        Console.WriteLine("--------------------");
                        break;
                    }
                }
            }
        }

        public void ViewAllMembers()
        {
            if (members.Count == 0)
            {
                Console.WriteLine("No members registered.");
                return;
            }

            foreach (Member member in members)
            {
                Console.WriteLine("--------------------");
                member.DisplayMemberDetails();
                Console.WriteLine("--------------------");
            }
        }

        public int GetTotalBooks()
        {
            return books.Count;
        }

        public int GetTotalMembers()
        {
            return members.Count;
        }
    }
}
