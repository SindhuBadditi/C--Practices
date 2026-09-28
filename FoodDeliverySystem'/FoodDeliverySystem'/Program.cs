using System;

class Customer
{
    public string CustId { get; set; }
    public string Cname { get; set; }
    public long Mobile { get; set; }

    public Customer(string cname, long mobile)
    { 
        Cname = cname;
        Mobile = mobile;
        CustId=cname.Substring(0, 2)+ Mobile.ToString().Substring(0,2);
    }
}

abstract class Order
{
    public string OrderId { get; set; }
    public decimal OrderAmt { get; set; }
    public Customer C { get; set; }
    public string Product { get; set; }

    public Order(string product, decimal orderAmt, Customer c)
    {
        Product = product;
        OrderAmt = orderAmt;
        C = c;

        OrderId = Product.Substring(0, 2) +
                  C.Mobile.ToString().Substring(C.Mobile.ToString().Length - 2);
    }

    public abstract void Bill();

    public void PrintSummary()
    {
        Console.WriteLine($"Order ID: {OrderId}");
        Console.WriteLine($"Product: {Product}");
        Console.WriteLine($"Customer: {C.Cname}");
    }
}

class RestaurantOrder : Order
{
    private decimal deliveryCharges = 70;

    public RestaurantOrder(string product, decimal orderAmt, Customer c)
        : base(product, orderAmt, c)
    {
    }

    public override void Bill()
    {
        decimal total = OrderAmt + deliveryCharges;

        Console.WriteLine("\n--- RESTAURANT BILL ---");
        Console.WriteLine($"Product: {Product}");
        Console.WriteLine($"Order ID: {OrderId}");
        Console.WriteLine($"Order Amount: {OrderAmt}");
        Console.WriteLine($"Delivery Charges: {deliveryCharges}");
        Console.WriteLine($"Total Amount: {total}");
        Console.WriteLine($"Customer Name: {C.Cname}");
        Console.WriteLine($"Customer ID: {C.CustId}");
        Console.WriteLine($"Mobile: {C.Mobile}");
    }
    public new void PrintSummary()
    {
        Console.WriteLine("\n--- RESTAURANT ORDER ---");
        Console.WriteLine($"Order ID: {OrderId}");
        Console.WriteLine($"Product: {Product}");
        Console.WriteLine($"Customer: {C.Cname}");
        Console.WriteLine($"Delivery Charges: {deliveryCharges}");
    }
}

class GroceryOrder : Order
{
    private decimal deliveryCharges = 40;

    public GroceryOrder(string product, decimal orderAmt, Customer c)
        : base(product, orderAmt, c)
    {
    }

    public override void Bill()
    {
        decimal total = OrderAmt + deliveryCharges;

        Console.WriteLine("\n--- GROCERY BILL ---");
        Console.WriteLine($"Product: {Product}");
        Console.WriteLine($"Order ID: {OrderId}");
        Console.WriteLine($"Order Amount: {OrderAmt}");
        Console.WriteLine($"Delivery Charges: {deliveryCharges}");
        Console.WriteLine($"Total Amount: {total}");
        Console.WriteLine($"Customer Name: {C.Cname}");
        Console.WriteLine($"Customer ID: {C.CustId}");
        Console.WriteLine($"Mobile: {C.Mobile}");
    }
}

class Program
{
    static void Main()
    { 
        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Mobile Number: ");
        long mobile = long.Parse(Console.ReadLine());

        Customer customer = new Customer( name, mobile);

        Console.WriteLine("\n1. Restaurant Order");
        Console.WriteLine("2. Grocery Order");

        Console.Write("Choose Order Type: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter Product: ");
        string product = Console.ReadLine();

        Console.Write("Enter Order Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        if (choice == 1)
        {
            RestaurantOrder restaurant = new RestaurantOrder(product, amount, customer);
            restaurant.Bill();

            Console.WriteLine("\n--- SUMMARY ---");
            restaurant.PrintSummary();
        }
        else
        {
            GroceryOrder grocery = new GroceryOrder(product, amount, customer);
            grocery.Bill();

            Console.WriteLine("\n--- SUMMARY ---");
            grocery.PrintSummary();
        }

        
    }
}