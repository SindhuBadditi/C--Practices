using System;
using System.Collections;
using System.Collections.Generic;

class OrderManager
{
    // Order numbers
    ArrayList orderNumbers = new ArrayList();
    // Order ID -> Customer Name
    Hashtable customers = new Hashtable();
    // Order ID -> Product Name
    Hashtable products = new Hashtable();
    // Order ID -> Order Amount
    SortedList<int, decimal> orderAmounts =
        new SortedList<int, decimal>();
    // Available order statuses
    List<string> orderStatuses = new List<string>()
    {
        "Placed",
        "Processing",
        "Shipped",
        "Delivered",
        "Cancelled"
    };
    Dictionary<int, string> orderStatus =new Dictionary<int, string>();
    public void CreateOrder(int orderId,string customerName,string productName,decimal amount)
    {
        if (customers.ContainsKey(orderId))
        {
            Console.WriteLine("Order already exists.");
            return;
        }
        orderNumbers.Add(orderId);
        customers.Add(orderId,customerName);
        products.Add(orderId,productName);
        orderAmounts.Add(orderId,amount);
        orderStatus.Add(orderId,"Placed");
        Console.WriteLine("Order created successfully.");
    }
    public void DisplayAllOrders()
    {
        if (orderNumbers.Count == 0)
        {
            Console.WriteLine("No orders available.");
            return;
        }
        Console.WriteLine("\n===== All Orders =====");
        foreach (int orderId in orderNumbers)
        {
            Console.WriteLine($"Order ID: {orderId}");
            Console.WriteLine($"Customer: {customers[orderId]}");
            Console.WriteLine($"Product: {products[orderId]}");
            Console.WriteLine($"Amount: {orderAmounts[orderId]}");
            Console.WriteLine($"Status: {orderStatus[orderId]}");
            Console.WriteLine();
        }
        Console.WriteLine($"Total Orders: {orderNumbers.Count}");
    }
    public void SearchOrder(int orderId)
    {
        if (customers.ContainsKey(orderId))
        {
            Console.WriteLine("\n===== Order Found =====");
            Console.WriteLine($"Order ID: {orderId}");
            Console.WriteLine($"Customer: {customers[orderId]}");
            Console.WriteLine($"Product: {products[orderId]}");
            Console.WriteLine($"Amount: {orderAmounts[orderId]}");
            Console.WriteLine($"Status: {orderStatus[orderId]}");
        }
        else
        {
            Console.WriteLine("Order not found.");
        }
    }
    public void DisplaySortedOrders()
    {
        if (orderAmounts.Count == 0)
        {
            Console.WriteLine("No orders available.");
            return;
        }
        Console.WriteLine("\n===== Orders Sorted by ID =====");
        foreach (KeyValuePair<int, decimal> order in orderAmounts)
        {
            int orderId = order.Key;
            decimal amount = order.Value;
            Console.WriteLine($"Order ID: {orderId}");
            Console.WriteLine($"Customer: {customers[orderId]}");
            Console.WriteLine($"Product: {products[orderId]}");
            Console.WriteLine($"Amount: {amount}");
            Console.WriteLine($"Status: {orderStatus[orderId]}");
            Console.WriteLine();
        }
    }
    public void CheckOrderStatus(int orderId)
    {
        if (orderStatus.ContainsKey(orderId))
        {
            Console.WriteLine($"Order ID: {orderId}");
            Console.WriteLine($"Current Status: " +$"{orderStatus[orderId]}");
        }
        else
        {
            Console.WriteLine("Order not found.");
        }
    }
    public void UpdateOrderStatus(int orderId,string newStatus)
    {
        if (!orderStatus.ContainsKey(orderId))
        {
            Console.WriteLine("Order not found.");
            return;
        }
        if (!orderStatuses.Contains(newStatus))
        {
            Console.WriteLine("Invalid status.");
            return;
        }
        orderStatus[orderId] = newStatus;
        Console.WriteLine("Order status updated successfully.");
    }
    public void RemoveOrder(int orderId)
    {
        if (!customers.ContainsKey(orderId))
        {
            Console.WriteLine("Order not found.");
            return;
        }
        orderNumbers.Remove(orderId);
        customers.Remove(orderId);
        products.Remove(orderId);
        orderAmounts.Remove(orderId);
        orderStatus.Remove(orderId);
        Console.WriteLine("Order removed successfully.");
    }
    public void DisplayStatuses()
    {
        Console.WriteLine("\n===== Available Statuses =====");
        foreach (string status in orderStatuses)
        {
            Console.WriteLine(status);
        }
    }
}


class Program
{
    static void Main()
    {
        OrderManager manager =new OrderManager();
        while (true)
        {
            Console.WriteLine("\n===== Order Tracking System =====");
            Console.WriteLine("1. Create Order");
            Console.WriteLine("2. Display All Orders");
            Console.WriteLine("3. Search Order");
            Console.WriteLine("4. Display Orders Sorted by ID");
            Console.WriteLine("5. Check Order Status");
            Console.WriteLine("6. Update Order Status");
            Console.WriteLine("7. Remove Order");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            int choice =Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Order ID: ");
                    int orderId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Customer Name: ");
                    string customerName =Console.ReadLine();
                    Console.Write("Enter Product Name: ");
                    string productName =Console.ReadLine();
                    Console.Write("Enter Order Amount: ");
                    decimal amount =Convert.ToDecimal(Console.ReadLine());
                    manager.CreateOrder(orderId,customerName,productName,amount);
                    break;
                case 2:
                    manager.DisplayAllOrders();
                    break;
                case 3:
                    Console.Write("Enter Order ID to search: ");
                    int searchId =Convert.ToInt32(Console.ReadLine());
                    manager.SearchOrder(searchId);
                    break;
                case 4:
                    manager.DisplaySortedOrders();
                    break;
                case 5:
                    Console.Write("Enter Order ID: ");
                    int statusId =Convert.ToInt32(Console.ReadLine());
                    manager.CheckOrderStatus(statusId);
                    break;
                case 6:
                    Console.Write("Enter Order ID: ");
                    int updateId =Convert.ToInt32(Console.ReadLine());
                    manager.DisplayStatuses();
                    Console.Write("Enter New Status: ");
                    string newStatus =Console.ReadLine();
                    manager.UpdateOrderStatus(updateId,newStatus);
                    break;
                case 7:
                    Console.Write("Enter Order ID to remove: ");
                    int removeId =Convert.ToInt32(Console.ReadLine());
                    manager.RemoveOrder(removeId);
                    break;
                case 8:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}