using System;
using System.Collections.Generic;

/*
Allow the user to add product categories.
A category should be stored only once.
Display all categories in sorted order.
Allow the user to check whether a category exists.
Allow the user to remove a category.
Display the total number of unique categories.
Provide a menu-driven console application.
*/

class ProductCategory
{
    static void Main(String[] args)
    {
        SortedSet<string> categories = new SortedSet<string>();
        while (true)
        {
            Console.WriteLine("\n===== Product Category Management =====");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Search Category");
            Console.WriteLine("3. Remove Category");
            Console.WriteLine("4. Display All Categories");
            Console.WriteLine("5. Display Total Categories");
            Console.WriteLine("6. Clear Categories");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nAdd Category");
                    Console.Write("Enter category name: ");
                    string category = Console.ReadLine();
                    bool added = categories.Add(category);
                    if (added)
                    {
                        Console.WriteLine("Category added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Category already exists.");
                    }
                    break;
                case 2:
                    Console.WriteLine("\nSearch Category");
                    Console.Write("Enter category name: ");
                    string searchCategory = Console.ReadLine();
                    if (categories.Contains(searchCategory))
                    {
                        Console.WriteLine($"{searchCategory} found.");
                    }
                    else
                    {
                        Console.WriteLine($"{searchCategory} not found.");
                    }
                    break;
                case 3:
                    Console.WriteLine("\nRemove Category");
                    Console.Write("Enter category name: ");
                    string removeCategory = Console.ReadLine();
                    bool removed = categories.Remove(removeCategory);
                    if (removed)
                    {
                        Console.WriteLine($"{removeCategory} removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"{removeCategory} not found.");
                    }
                    break;
                case 4:
                    Console.WriteLine("\nDisplay All Categories");
                    foreach (string item in categories)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 5:
                    Console.WriteLine("\nTotal Categories: " + categories.Count);
                    break;
                case 6:
                    Console.WriteLine("\nClear Categories");
                    categories.Clear();
                    Console.WriteLine("All categories have been removed.");
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