using System;
using System.Collections.Generic;

/// <summary>
/// Represents a task with a description and completion status.
/// </summary>
public class TaskItem
{
    public string Description { get; set; } // Stores the task description
    public bool IsCompleted { get; set; }  // Indicates whether the task is completed or not

    /// <summary>
    /// Initializes a new task with the given description and sets it as pending (not completed).
    /// </summary>
    /// <param name="description">The description of the task.</param>
    public TaskItem(string description)
    {
        Description = description;
        IsCompleted = false;
    }
}

public class TaskManager
{
    // A dynamic list to store tasks, allowing unlimited entries
    private static List<TaskItem> tasks = new List<TaskItem>();

    /// <summary>
    /// Main entry point of the application. Displays a menu and processes user input.
    /// </summary>
    public static void Main()
    {
        string option;
        
        // Program runs in a loop until the user chooses to quit
        do
        {
            Console.WriteLine("Choose an option: (1) Add Task, (2) Mark Task as Complete, (3) Display Tasks, (4) Quit");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    EnterTask(); // Calls method to add a task
                    break;
                case "2":
                    MarkCompleted(); // Calls method to mark a task as completed
                    break;
                case "3":
                    DisplayTasks(); // Calls method to display all tasks
                    break;
                case "4":
                    Console.WriteLine("Exiting Task Manager...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter 1, 2, 3, or 4.");
                    break;
            }

        } while (option != "4"); // Loop continues until user chooses option 4 (Quit)
    }

    /// <summary>
    /// Prompts the user to enter a new task description and adds it to the task list if it's valid.
    /// </summary>
    public static void EnterTask()
    {
        Console.Write("Enter your task: ");
        string newTask = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newTask)) // Ensures the task description is not empty
        {
            tasks.Add(new TaskItem(newTask)); // Adds the new task to the list
            Console.WriteLine("Task added successfully.");
        }
        else
        {
            Console.WriteLine("Task description cannot be empty.");
        }
    }

    /// <summary>
    /// Allows the user to select and mark a task as completed.
    /// </summary>
    public static void MarkCompleted()
    {
        if (tasks.Count == 0) // Checks if there are tasks available
        {
            Console.WriteLine("No tasks available to mark as completed.");
            return;
        }

        Console.WriteLine("Enter the task number to mark as completed:");
        DisplayTasks(); // Displays the task list before selection

        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].IsCompleted = true; // Marks the selected task as completed
            Console.WriteLine("Task marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid task number. Please try again.");
        }
    }

    /// <summary>
    /// Displays all tasks along with their current status (Pending or Completed).
    /// </summary>
    public static void DisplayTasks()
    {
        if (tasks.Count == 0) // Checks if there are tasks to display
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine("Your Tasks:");
        for (int i = 0; i < tasks.Count; i++) // Loops through and displays all tasks
        {
            string status = tasks[i].IsCompleted ? "[Completed]" : "[Pending]"; // Determines task status
            Console.WriteLine($"{i + 1}. {tasks[i].Description} {status}");
        }
    }
}
