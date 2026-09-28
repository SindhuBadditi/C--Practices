using System.Collections;


class Customer
{
    /*Add customers to the waiting queue.
    Serve the customer who has been waiting the longest.
    Display the next customer without removing them.
    Check whether a particular customer is waiting.
    Display the number of customers currently waiting.
    Display all customers in the queue.*/
    static void Main(String[] args)
    {
        Queue<string> customers = new Queue<string>();
        while (true) 
        { 
            Console.WriteLine("\n1. Add Customer to Waiting Queue"); 
            Console.WriteLine("2. Serve Customer"); 
            Console.WriteLine("3. Display Next Customer"); 
            Console.WriteLine("4. Check Whether Customer Is Waiting"); 
            Console.WriteLine("5. Display Number of Customers Waiting");
            Console.WriteLine("6. Display All Customers in Queue"); 
            Console.WriteLine("7. Clear All Customers"); 
            Console.WriteLine("8. Exit"); 
            Console.Write("Enter your choice: "); 
            int choice = Convert.ToInt32(Console.ReadLine()); 
            switch (choice) 
            { 
                case 1: 
                    { 
                        Console.WriteLine("\nAdding customer to waiting queue"); 
                        Console.Write("Enter customer name: "); 
                        string name = Console.ReadLine(); 
                        customers.Enqueue(name); 
                        Console.WriteLine("Customer added to waiting queue successfully."); 
                        break; 
                    } 
                case 2: 
                    { 
                        Console.WriteLine("\nServing customer"); 
                        if (customers.Count > 0) 
                        { 
                            string customer = customers.Dequeue(); 
                            Console.WriteLine("Serving customer: " + customer);
                        } 
                        else 
                        { 
                            Console.WriteLine("No customers are waiting."); 
                        } 
                        break; 
                    } 
                case 3: 
                    { 
                        Console.WriteLine("\nDisplaying next customer"); 
                        if (customers.Count > 0) 
                        { 
                            string customer = customers.Peek(); 
                            Console.WriteLine("Next customer: " + customer); 
                        } 
                        else 
                        { 
                            Console.WriteLine("No customers are waiting."); 
                        } 
                        break; 
                    } 
                case 4:
                    { 
                        Console.WriteLine("\nChecking whether customer is waiting"); 
                        Console.Write("Enter customer name: "); 
                        string name = Console.ReadLine();
                        bool result = customers.Contains(name); 
                        if (result) 
                        { 
                            Console.WriteLine("Yes. " + name + " is waiting."); 
                        } 
                        else 
                        { 
                            Console.WriteLine("No. " + name + " is not waiting."); 
                        } 
                        break; 
                    } 
                case 5: 
                    {
                        Console.WriteLine("\nNumber of customers currently waiting: " + customers.Count);
                        break; 
                    } 
                case 6: 
                    { 
                        Console.WriteLine("\nDisplaying all customers in the queue");
                        if (customers.Count > 0) 
                        { 
                            IEnumerator<string> enumerator = customers.GetEnumerator(); 
                            Console.Write("Customers waiting: "); 
                            while (enumerator.MoveNext()) 
                            {
                                Console.Write(enumerator.Current + " ");
                            } 
                            Console.WriteLine(); 
                        } 
                        else 
                        { 
                            Console.WriteLine("No customers are waiting."); 
                        } 
                        break; 
                    } 
                case 7: 
                    { 
                        Console.WriteLine("\nClearing all customers"); 
                        customers.Clear(); 
                        Console.WriteLine("All customers have been removed from the queue.");
                        break; 
                    } 
                case 8: 
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