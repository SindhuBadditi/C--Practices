class Customer
{
    static List<Customer> customers = new List<Customer>();

    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Mobile { get; set; }

    public List<string> Orders { get; set; }

    public Customer(int id, string name, string mobile)
    {
        CustomerId = id;
        CustomerName = name;
        Mobile = mobile;
        Orders = new List<string>();
    }

    public void RegisterCustomer(Customer customer)
    {
        foreach (Customer c in customers)
        {
            if (c.CustomerId == customer.CustomerId)
            {
                throw new Exception("Customer ID already exists.");
            }
        }

        customers.Add(customer);
    }

    public void ViewCustomer()
    {
        if (customers.Count == 0)
        {
            Console.WriteLine("No customers registered.");
            return;
        }

        foreach (Customer customer in customers)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Customer ID: " + customer.CustomerId);
            Console.WriteLine("Customer Name: " + customer.CustomerName);
            Console.WriteLine("Mobile: " + customer.Mobile);
        }
    }

    public Customer FindCustomer(int id)
    {
        foreach (Customer customer in customers)
        {
            if (customer.CustomerId == id)
            {
                return customer;
            }
        }

        throw new Exception("Customer Not Found.");
    }

    public void PlaceOrder(Product product, int quantity)
    {
        if (quantity <= 0)
        {
            throw new Exception("Quantity must be greater than 0.");
        }

        if (product.Quantity < quantity)
        {
            throw new Exception("Insufficient stock.");
        }

        decimal total = product.Price * quantity;

        product.Quantity = product.Quantity - quantity;

        string order ="Product: " + product.ProductName + " | Quantity: " + quantity +" | Total: " + total;

        Orders.Add(order);

        Console.WriteLine("Order placed successfully.");
        Console.WriteLine(order);
    }

    public void ViewOrder()
    {
        if (Orders.Count == 0)
        {
            Console.WriteLine("No orders found.");
            return;
        }

        Console.WriteLine("\n----- Orders -----");

        foreach (string order in Orders)
        {
            Console.WriteLine(order);
        }
    }

    public void CancelOrder(int orderNumber)
    {
        if (Orders.Count == 0)
        {
            throw new Exception("No orders available.");
        }

        if (orderNumber < 1 || orderNumber > Orders.Count)
        {
            throw new Exception("Invalid order number.");
        }

        Orders.RemoveAt(orderNumber - 1);

        Console.WriteLine("Order cancelled successfully.");
    }
}