    /*Create a Product with product ID, product name, price, and available stock quantity.
    Allow the user to view the product details and current stock.
    Allow the user to enter the quantity they want to purchase.
    Before completing the purchase, check whether the requested quantity is available.
    If the requested quantity is greater than the available stock, the purchase should not be completed and an appropriate exception should be raised.
    Handle the exception using appropriate exception-handling blocks and display a meaningful message to the user.
    If the requested quantity is available, complete the purchase and reduce the stock quantity accordingly.
    Validate invalid purchase quantities such as zero or negative values and handle them appropriately.
    Ensure that the program continues running after an invalid purchase attempt so the user can try again.
    Use a custom exception specifically for the product-out-of-stock situation.
    Include a final cleanup/closing step that executes regardless of whether the purchase succeeds or an exception occurs.*/
using System.Collections;
using System.ComponentModel;
using static System.Reflection.Metadata.BlobBuilder;

struct Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity {  get; set; }
    public Product(int id,string name,decimal price,int quantity)
    {
        ProductId = id;
        ProductName= name; 
        Price = price;
        Quantity = quantity;
    }
}
class Billing
{
    List<Product> prod = new List<Product>();

    static void Main(String[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Billing b=new Billing();
        while (true)
        {
            Console.WriteLine("\n1.Add the product");
            Console.WriteLine("2.View the product");
            Console.WriteLine("3.Buy the product");
            Console.WriteLine("4.Exit");

            Console.Write("Enter your choice:");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Write("\n Enter product id:");
                        int id=int.Parse(Console.ReadLine());
                        Console.Write("Enter product name:");
                        string name=Console.ReadLine();
                        Console.Write("Enter product price:");
                        decimal price=decimal.Parse(Console.ReadLine());
                        Console.Write("Enter product quantity:");
                        int quantity=int.Parse(Console.ReadLine());
                        Product p=new Product(id,name,price,quantity);
                        b.AddProduct(p);
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            Console.WriteLine("\nView Product by name");
                            Console.Write("Enter product name:");
                            string name = Console.ReadLine();
                            b.ViewProduct(name);
                        }catch(ProductException e)
                        {
                            Console.WriteLine("Exception-Message: "+e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Product viewing operation completed.");
                        }
                        break;
                    }
                case 3:
                    {
                        try
                        {
                            Console.WriteLine("\nBuying product");
                            Console.Write("Enter product name:");
                            string name = Console.ReadLine();
                            Console.Write("Enter product quantity:");
                            int quantity = int.Parse(Console.ReadLine());
                            b.BuyProduct(name, quantity);
                        }
                        catch (ProductException e)
                        {
                            Console.WriteLine("Exception-Message: "+e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Thank you. Visit Again 😊🙂");
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Exiting.....");
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice!!!!"); 
                        return;
                    }
            }
        }
    }
    public void AddProduct(Product product)
    {
        prod.Add(product);
    }
    public void ViewProduct(string name)
    {
        foreach (Product product in prod)
        {
            if (product.ProductName.Contains(name))
            {
                Console.WriteLine("Product ID: " + product.ProductId);
                Console.WriteLine("Product Name: " + product.ProductName);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Quantity: " + product.Quantity);
                return;
            }
        }
        throw new ProductException("Product Not Found");
    }
    public void BuyProduct(string name,int quantity)
    {
        for (int i = 0; i < prod.Count; i++)
        {
            if (prod[i].ProductName.Contains(name))
            {
                Product product = prod[i];
                if (quantity <= 0)
                {
                    throw new ProductException("Product quantity must be greater than 0.");
                }
                else if (product.Quantity < quantity)
                {
                    throw new ProductException("Not enough stock");
                }

                else
                {
                    product.Quantity -= quantity;

                    prod[i] = product;
                    Console.WriteLine("---Billing----");
                    Console.WriteLine("Product ID: " + product.ProductId);
                    Console.WriteLine("Product Name: " + product.ProductName);
                    Console.WriteLine("Quantity: " + quantity);
                    Console.WriteLine("Price: " + product.Price*quantity);
                    Console.WriteLine("Product purchased successfully");

                    return;
                }
            }
        }
        throw new ProductException("Product Not Found");
    }
}
class ProductException : ApplicationException
{
    public ProductException(string message):base(message) { }
}