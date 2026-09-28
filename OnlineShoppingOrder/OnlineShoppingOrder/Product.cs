using System;
using System.Collections.Generic;

class Product
{
    static List<Product> prod = new List<Product>();

    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(int id, string name, decimal price, int quantity)
    {
        ProductId = id;
        ProductName = name;
        Price = price;
        Quantity = quantity;
    }

    public void AddProduct(Product product)
    {
        foreach (Product p in prod)
        {
            if (p.ProductId == product.ProductId)
            {
                throw new ProductException("Product ID already exists.");
            }
        }

        prod.Add(product);
    }

    public void ViewProduct()
    {
        if (prod.Count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }

        foreach (Product product in prod)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Product ID: " + product.ProductId);
            Console.WriteLine("Product Name: " + product.ProductName);
            Console.WriteLine("Price: " + product.Price);
            Console.WriteLine("Quantity: " + product.Quantity);
        }
    }

    public Product FindProduct(int id)
    {
        foreach (Product product in prod)
        {
            if (product.ProductId == id)
            {
                return product;
            }
        }

        throw new ProductException("Product Not Found.");
    }

    public class ProductException : ApplicationException
    {
        public ProductException(string message) : base(message)
        {
        }
    }
}