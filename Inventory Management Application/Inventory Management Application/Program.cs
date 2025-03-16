using System;
using System.Collections.Generic;

// Represents a product in the inventory
class Product
{
    public string Name { get; set; } // Name of the product
    public decimal Price { get; set; } // Price of the product
    public int StockQuantity { get; set; } // Available stock quantity

    // Constructor to initialize product details
    public Product(string name, decimal price, int stockQuantity)
    {
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    // Method to display product details
    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price:C}, Stock: {StockQuantity}");
    }
}

// Manages the inventory system
class Inventory
{
    private List<Product> products = new List<Product>(); // List to store products

    // Method to add a new product to the inventory
    public void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine() ?? string.Empty;

        decimal price;
        while (true)
        {
            Console.Write("Enter product price: ");
            if (decimal.TryParse(Console.ReadLine(), out price))
                break;
            else
                Console.WriteLine("Invalid input! Please enter a valid decimal number.");
        }

        int stock;
        while (true)
        {
            Console.Write("Enter stock quantity: ");
            if (int.TryParse(Console.ReadLine(), out stock))
                break;
            else
                Console.WriteLine("Invalid input! Please enter a valid integer.");
        }

        // Check if the name is null or empty
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Product name cannot be empty!");
            return;
        }

        // Create a new product and add it to the list
        products.Add(new Product(name, price, stock));
        Console.WriteLine("Product added successfully!\n");
    }

    // Method to update stock quantity of a product
    public void UpdateStock()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine() ?? string.Empty;
        
        // Find the product in the list
        var product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (product != null)
        {
            int quantity;
            while (true)
            {
                Console.Write("Enter quantity to add or subtract: ");
                if (int.TryParse(Console.ReadLine(), out quantity))
                    break;
                else
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
            }
            
            // Update stock quantity
            product.StockQuantity += quantity;
            Console.WriteLine("Stock updated successfully!\n");
        }
        else
        {
            Console.WriteLine("Product not found!\n");
        }
    }

    // Method to display all products in inventory
    public void ViewProducts()
    {
        Console.WriteLine("\nCurrent Inventory:");
        
        // Iterate over the list and display each product
        foreach (var product in products)
        {
            product.Display();
        }
        Console.WriteLine();
    }

    // Method to remove a product from inventory
    public void RemoveProduct()
    {
        Console.Write("Enter product name to remove: ");
        string name = Console.ReadLine() ?? string.Empty;
       
        // Find the product in the list
        var product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (product != null)
        {
            products.Remove(product); // Remove the product from the list
            Console.WriteLine("Product removed successfully!\n");
        }
        else
        {
            Console.WriteLine("Product not found!\n");
        }
    }
}

// Main program execution
class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory(); // Create an inventory instance
        
        while (true) // Infinite loop to keep the program running until user exits
        {
            // Display menu options
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Stock");
            Console.WriteLine("3. View Products");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            
            int choice;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                    break;
                else
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
            }

            // Execute the corresponding action based on user input
            switch (choice)
            {
                case 1:
                    inventory.AddProduct();
                    break;
                case 2:
                    inventory.UpdateStock();
                    break;
                case 3:
                    inventory.ViewProducts();
                    break;
                case 4:
                    inventory.RemoveProduct();
                    break;
                case 5:
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice! Try again.\n");
                    break;
            }
        }
    }
}
