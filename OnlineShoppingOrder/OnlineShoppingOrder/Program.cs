using System;

class Program
{
    static void Main(string[] args)
    {
        Product productManager = new Product(0, "", 0, 0);
        Customer customerManager = new Customer(0, "", "");

        while (true)
        {
            Console.WriteLine("\n===== Online Shopping System =====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Product");
            Console.WriteLine("3. Register Customer");
            Console.WriteLine("4. View Customer");
            Console.WriteLine("5. Place Order");
            Console.WriteLine("6. View Order");
            Console.WriteLine("7. Cancel Order");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Product ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        decimal price = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        if (price <= 0)
                        {
                            throw new Exception("Price must be greater than 0.");
                        }
                        if (quantity < 0)
                        {
                            throw new Exception("Quantity cannot be negative.");
                        }
                        Product newProduct =new Product(id, name, price, quantity);
                        productManager.AddProduct(newProduct);
                        Console.WriteLine("Product added successfully.");
                        break;
                    case 2:
                        productManager.ViewProduct();
                        break;
                    case 3:
                        Console.Write("Enter Customer ID: ");
                        int customerId =Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Customer Name: ");
                        string customerName = Console.ReadLine();
                        Console.Write("Enter Mobile Number: ");
                        string mobile = Console.ReadLine();
                        if (mobile.Length != 10)
                        {
                            throw new Exception("Mobile number must contain 10 digits.");
                        }
                        Customer newCustomer = new Customer(customerId,customerName,mobile);
                        customerManager.RegisterCustomer(newCustomer);
                        Console.WriteLine("Customer registered successfully.");
                        break;
                    case 4:
                        customerManager.ViewCustomer();
                        break;
                    case 5:
                        Console.Write("Enter Customer ID: ");
                        int orderCustomerId =Convert.ToInt32(Console.ReadLine());
                        Customer selectedCustomer =customerManager.FindCustomer(orderCustomerId);
                        Console.Write("Enter Product ID: ");
                        int orderProductId =Convert.ToInt32(Console.ReadLine());
                        Product selectedProduct =productManager.FindProduct(orderProductId);
                        Console.Write("Enter Quantity: ");
                        int orderQuantity =Convert.ToInt32(Console.ReadLine());
                        selectedCustomer.PlaceOrder(selectedProduct,orderQuantity);
                        break;
                    case 6:
                        Console.Write("Enter Customer ID: ");
                        int viewCustomerId =Convert.ToInt32(Console.ReadLine());
                        Customer viewCustomer =customerManager.FindCustomer(viewCustomerId);
                        viewCustomer.ViewOrder();
                        break;
                    case 7:
                        Console.Write("Enter Customer ID: ");
                        int cancelCustomerId =Convert.ToInt32(Console.ReadLine());
                        Customer cancelCustomer =customerManager.FindCustomer(cancelCustomerId);
                        cancelCustomer.ViewOrder();
                        Console.Write("Enter order number to cancel: ");
                        int orderNumber =Convert.ToInt32(Console.ReadLine());
                        cancelCustomer.CancelOrder(orderNumber);
                        break;
                    case 8:
                        Console.WriteLine("Thank you!");
                        return;
                    default:
                        throw new Exception("Invalid menu choice.");
                }
            }
            catch (Product.ProductException ex)
            {
                Console.WriteLine("Product Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Operation completed.");
            }
        }
    }
}