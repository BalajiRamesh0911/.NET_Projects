using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    class Program
    {
        // Define the Book class, which represents a book in the library
        class Book
        {
            public string Title { get; set; } // The title of the book
            public bool IsCheckedOut { get; set; } = false; // Indicates whether the book is checked out

            // Constructor to initialize a book with a title
            public Book(string title)
            {
                Title = title;
            }
        }

        // List to store books in the library
        // This simulates a simple database of books available in the library
        static List<Book> libraryBooks = new List<Book>
        {
            new Book("C# Fundamentals"),
            new Book("Introduction to .NET"),
            new Book("ASP.NET Core Essentials"),
            new Book("Entity Framework Core Guide"),
        };

        // Dictionary to track borrowed books per user
        // The key is the user's name, and the value is a list of books they have borrowed
        static Dictionary<string, List<Book>> borrowedBooks = new Dictionary<string, List<Book>>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Library Management System\n");
            string userName;

            // Prompt the user to enter their name
            Console.Write("Enter your name: ");
            userName = Console.ReadLine();

            // Initialize the user's borrowed books record if it doesn't already exist
            if (!borrowedBooks.ContainsKey(userName))
            {
                borrowedBooks[userName] = new List<Book>();
            }

            // Main loop for the program menu
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Search for a Book");
                Console.WriteLine("2. Borrow a Book");
                Console.WriteLine("3. Check-in a Book");
                Console.WriteLine("4. Exit");

                // Prompt the user to select an option
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Call the method to search for a book
                        SearchForBook();
                        break;
                    case "2":
                        // Call the method to borrow a book
                        BorrowBook(userName);
                        break;
                    case "3":
                        // Call the method to check in a book
                        CheckInBook(userName);
                        break;
                    case "4":
                        // Exit the program
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        // Handle invalid menu choices
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Method to search for a book by its title
        static void SearchForBook()
        {
            Console.Write("Enter the title of the book to search: ");
            string searchTitle = Console.ReadLine();

            // Find the book in the library's collection
            Book foundBook = libraryBooks.Find(b => b.Title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase));

            if (foundBook != null)
            {
                // Book is available
                Console.WriteLine($"The book '{foundBook.Title}' is available.");
            }
            else
            {
                // Book is not found
                Console.WriteLine($"The book '{searchTitle}' is not in the collection.");
            }
        }

        // Method to borrow a book
        static void BorrowBook(string userName)
        {
            // Check if the user has reached the borrowing limit
            if (borrowedBooks[userName].Count >= 3)
            {
                Console.WriteLine("You have reached the borrowing limit of 3 books.");
                return;
            }

            Console.Write("Enter the title of the book to borrow: ");
            string borrowTitle = Console.ReadLine();

            // Find the book in the library's collection
            Book foundBook = libraryBooks.Find(b => b.Title.Equals(borrowTitle, StringComparison.OrdinalIgnoreCase));

            if (foundBook != null && !foundBook.IsCheckedOut)
            {
                // Book is available to borrow
                foundBook.IsCheckedOut = true;
                borrowedBooks[userName].Add(foundBook);
                Console.WriteLine($"You have successfully borrowed '{foundBook.Title}'.");
            }
            else if (foundBook != null && foundBook.IsCheckedOut)
            {
                // Book is already checked out
                Console.WriteLine($"The book '{foundBook.Title}' is already checked out.");
            }
            else
            {
                // Book is not found in the collection
                Console.WriteLine($"The book '{borrowTitle}' is not in the collection.");
            }
        }

        // Method to check in a borrowed book
        static void CheckInBook(string userName)
        {
            Console.Write("Enter the title of the book to check in: ");
            string returnTitle = Console.ReadLine();

            // Find the book in the user's borrowed books
            Book foundBook = borrowedBooks[userName].Find(b => b.Title.Equals(returnTitle, StringComparison.OrdinalIgnoreCase));

            if (foundBook != null)
            {
                // Book is checked in successfully
                foundBook.IsCheckedOut = false;
                borrowedBooks[userName].Remove(foundBook);
                Console.WriteLine($"You have successfully checked in '{foundBook.Title}'.");
            }
            else
            {
                // Book is not found in the user's borrowed list
                Console.WriteLine($"You do not have the book '{returnTitle}' checked out.");
            }
        }
    }
}
