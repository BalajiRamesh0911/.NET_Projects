using System;
using System.Collections.Generic;

// Class describing a grade with a subject and a score //
public class Grade
{
    public string Subject { get; set; } // Subject name //
    public double Score { get; set; }   // Score obtained //

    // Using Constructor to initialize the subject and score //
    public Grade(string subject, double score)
    {
        Subject = subject;
        Score = score;
    }
}

// Class representing a student with a name, ID, and a list of grades //
public class Student
{
    public string Name { get; set; } // Name of the student //
    public int ID { get; set; }      // Unique student ID //
    public List<Grade> Grades { get; set; } // List to store grades //

    // Using Constructor to initialize student name and ID //
    public Student(string name, int id)
    {
        Name = name;
        ID = id;
        Grades = new List<Grade>(); // Initializing the list of grades //
    }

    // Using a Method to add a grade to the student //
    public void AddGrade(Grade grade)
    {
        Grades.Add(grade);
    }

    // Using a Method to calculate the average score of the student //
    public double CalculateAverageScore()
    {
        if (Grades.Count == 0) // Checking for students grades //
            return 0;

        double totalScore = 0;

        // Loops calculate total score //
        foreach (Grade grade in Grades)
        {
            totalScore += grade.Score;
        }
        return totalScore / Grades.Count; // Returning average score //
    }
}

public class Program
{ 
    // List to store student records //
    private static List<Student> students = new List<Student>();

    // Main method: Entry point of the program //
    public static void Main(String[] args)
    {
        while (true) // Infinite loop for the menu //
        {
            Console.Clear(); // Clearing console for a clean menu display

            Console.WriteLine("Student Grade Management System"); // Displaying the menu //    

            Console.WriteLine("1. Add Student");    // Menu options //

            Console.WriteLine("2. Add Grade");      // Menu options //

            Console.WriteLine("3. Display Student Records");    // Menu options //

            Console.WriteLine("4. Exit");   // Menu options //

            Console.Write("Select an option: ");        // Prompting user for input //

            // Validating user input //
            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Invalid option! Must be a number. Press any key to continue...");
                Console.ReadKey();
                continue; // Continue the loop if input is invalid //
            }

            // Using switch case for handling multiple options //
            switch (option)
            {
                case 1:
                    AddStudent(); // Call method to add student //
                    break;
                case 2:
                    AddGrade(); // Call method to add grade //
                    break;
                case 3:
                    DisplayStudentRecords(); // Call method to display records //
                    break;
                case 4:
                    Console.WriteLine("Exiting the application, Thank you. Press any key to exit...");
                    Console.ReadKey();
                    return; // Exit the program //
                default:
                    Console.WriteLine("Invalid option! Must be a number. Press any key to continue...");
                    break;
            }
            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }
    }

    // Using a Method to add a new student //
    private static void AddStudent()
    {
        Console.Write("Enter the student name: ");
        string name = Console.ReadLine(); // Read student name from user //

        Console.Write("Enter Student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) // Validate student ID //
        {
            Console.WriteLine("Invalid ID! Must be a number. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        // Checking if the student ID already exists //
        if (students.Exists(s => s.ID == id))
        {
            Console.WriteLine("Student with the same ID already exists! Press any key to continue...");
            Console.ReadKey();
            return;
        }

        students.Add(new Student(name, id)); // Adding student to the list //
        Console.WriteLine("Student added successfully! Press any key to continue...");
        Console.ReadKey();
    }

    // Using a Method to add a grade to an existing student //
    private static void AddGrade()
    {
        if (students.Count == 0) // Checking if there are any students in the list //
        {
            Console.WriteLine("No students found! Press any key to continue...");
            Console.ReadKey();
            return;
        }

        // Displaying list of students //
        Console.WriteLine("Select a student:");
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {students[i].Name} (ID: {students[i].ID})");
        }

        // Validating user selection //
        if (!int.TryParse(Console.ReadLine(), out int studentIndex) || studentIndex < 1 || studentIndex > students.Count)
        {
            Console.WriteLine("Invalid selection! Must be a Number. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter the subject: ");
        string subject = Console.ReadLine();

        Console.Write("Enter the score: ");
        if (!double.TryParse(Console.ReadLine(), out double score)) // Validating score //
        {
            Console.WriteLine("Invalid score! Must be a Number. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        students[studentIndex - 1].AddGrade(new Grade(subject, score)); // Adding grade to student //
        Console.WriteLine("Grade added successfully! Press any key to continue...");
        Console.ReadKey();
    }

    // Method to display student records //
    private static void DisplayStudentRecords()
    {
        if (students.Count == 0) // Checking if students exist //
        {
            Console.WriteLine("No students found! Press any key to continue...");
            Console.ReadKey();
            return;
        }

        // Loop to display student records //
        foreach (Student student in students)
        {
            Console.WriteLine($"Name: {student.Name}, ID: {student.ID}");
            Console.WriteLine("Grades:");

            if (student.Grades.Count == 0) // Checking if student has grades //
            {
                Console.WriteLine("No Grades Available! Press any key to continue...");
            }
            else
            {
                // Loop to display each grade //
                foreach (Grade grade in student.Grades)
                {
                    Console.WriteLine($"Subject: {grade.Subject}, Score: {grade.Score}");
                }
                Console.WriteLine($"Average Score: {student.CalculateAverageScore():F2}");
            }
            Console.WriteLine(new string('-', 30)); // Separator for readability //
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
