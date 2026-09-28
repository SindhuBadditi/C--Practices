using System;
class OnlineShopping
{
    /*    Maintain a collection of available product names.
    Maintain product ID → product name mapping.
    Ensure a customer's selected product categories don't contain duplicates.
    Maintain customers waiting for order processing.
    Maintain recently viewed products where the latest product should be accessed first.
    Provide options to add, remove, search, display and count items where appropriate.*/
    static void Main(String[] args)
    {
        List<String> products = new List<string>();
        Dictionary<int,String> productDetails = new Dictionary<int,String>();
        HashSet<string> categories = new HashSet<string>();
        Queue<string> customers = new Queue<string>();
        Stack<string> recentProducts = new Stack<string>();

        while (true)
        {
            Console.WriteLine("\n1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Search Product");
            Console.WriteLine("4. Display Products");
            Console.WriteLine("5. Add Product ID");
            Console.WriteLine("6. Remove Product ID");
            Console.WriteLine("7. Search Product ID");
            Console.WriteLine("8. Display Product IDs");
            Console.WriteLine("9. Add Category");
            Console.WriteLine("10. Remove Category");
            Console.WriteLine("11. Search Category");
            Console.WriteLine("12. Display Categories");
            Console.WriteLine("13. Add Customer");
            Console.WriteLine("14. Process Customer");
            Console.WriteLine("15. Display Customers");
            Console.WriteLine("16. Add Recent Product");
            Console.WriteLine("17. Remove Recent Product");
            Console.WriteLine("18. Display Recent Products");
            Console.WriteLine("19. Clear All");
            Console.WriteLine("20. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Enter product: ");
                        products.Add(Console.ReadLine());
                        break;
                    }

                case 2:
                    {
                        Console.Write("Enter product: ");
                        products.Remove(Console.ReadLine());
                        break;
                    }

                case 3:
                    {
                        Console.Write("Enter product: ");
                        Console.WriteLine(products.Contains(Console.ReadLine()));
                        break;
                    }

                case 4:
                    {
                        IEnumerator<string> e = products.GetEnumerator();
                        while (e.MoveNext())
                            Console.WriteLine(e.Current);
                        break;
                    }

                case 5:
                    {
                        Console.Write("Enter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter product name: ");
                        productDetails.Add(id, Console.ReadLine());
                        break;
                    }

                case 6:
                    {
                        Console.Write("Enter ID: ");
                        productDetails.Remove(Convert.ToInt32(Console.ReadLine()));
                        break;
                    }

                case 7:
                    {
                        Console.Write("Enter ID: ");
                        Console.WriteLine(productDetails.ContainsKey(
                            Convert.ToInt32(Console.ReadLine())));
                        break;
                    }

                case 8:
                    {
                        foreach (var item in productDetails)
                            Console.WriteLine(item.Key + " : " + item.Value);
                        break;
                    }

                case 9:
                    {
                        Console.Write("Enter category: ");
                        categories.Add(Console.ReadLine());
                        break;
                    }

                case 10:
                    {
                        Console.Write("Enter category: ");
                        categories.Remove(Console.ReadLine());
                        break;
                    }

                case 11:
                    {
                        Console.Write("Enter category: ");
                        Console.WriteLine(categories.Contains(Console.ReadLine()));
                        break;
                    }

                case 12:
                    {
                        IEnumerator<string> e = categories.GetEnumerator();
                        while (e.MoveNext())
                            Console.WriteLine(e.Current);
                        break;
                    }

                case 13:
                    {
                        Console.Write("Enter customer: ");
                        customers.Enqueue(Console.ReadLine());
                        break;
                    }

                case 14:
                    {
                        if (customers.Count > 0)
                            Console.WriteLine("Processed: " + customers.Dequeue());
                        break;
                    }

                case 15:
                    {
                        IEnumerator<string> e = customers.GetEnumerator();
                        while (e.MoveNext())
                            Console.WriteLine(e.Current);
                        break;
                    }

                case 16:
                    {
                        Console.Write("Enter product: ");
                        recentProducts.Push(Console.ReadLine());
                        break;
                    }

                case 17:
                    {
                        if (recentProducts.Count > 0)
                            Console.WriteLine("Removed: " + recentProducts.Pop());
                        break;
                    }

                case 18:
                    {
                        IEnumerator<string> e = recentProducts.GetEnumerator();
                        while (e.MoveNext())
                            Console.WriteLine(e.Current);
                        break;
                    }

                case 19:
                    {
                        products.Clear();
                        productDetails.Clear();
                        categories.Clear();
                        customers.Clear();
                        recentProducts.Clear();
                        Console.WriteLine("All collections cleared.");
                        break;
                    }

                case 20:
                    {
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