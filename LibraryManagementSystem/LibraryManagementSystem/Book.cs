using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    internal class Book
    {
        public string BookId { get; set; }
        public string BookName {  get; set; }
        public string AuthorName { get; set; }
        public int availableCopies {  get; set; }
        public Book(string BookId, string BookName, string AuthorName, int availableCopies)
        {
            this.BookId = BookId;
            this.BookName = BookName;
            this.AuthorName = AuthorName;
            this.availableCopies = availableCopies;
        }
        public void DisplayBookDetails()
        {
            Console.WriteLine("Book Id: " + BookId);
            Console.WriteLine("Book Name: "+BookName); 
            Console.WriteLine("Author Name: "+AuthorName);
            Console.WriteLine("Available Copies:" + availableCopies);
        }
    }
}
