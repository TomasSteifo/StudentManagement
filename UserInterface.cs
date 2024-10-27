using System;

public class UserInterface
{
    private StudentManager manager = new StudentManager();

    // Adds a new student by prompting the user for details
    public void AddStudent()
    {
        Console.WriteLine("Enter student name, ID, and age:");
        var name = Console.ReadLine();
        var id = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());

        var student = new Student(name, id, age);
        manager.AddStudent(student);

        Console.WriteLine($"Student {name} added.");
    }

    // Removes a student using their ID
    public void RemoveStudent()
    {
        Console.WriteLine("Enter student ID to remove:");
        var id = Console.ReadLine();
        manager.RemoveStudent(id);
        Console.WriteLine($"Student with ID {id} removed.");
    }

    // Adds a subject to a student based on their ID
    public void AddSubject()
    {
        Console.WriteLine("Enter student ID and subject to add:");
        var id = Console.ReadLine();
        var subject = Console.ReadLine();

        manager.AddSubjectToStudent(id, subject);
        Console.WriteLine($"Subject {subject} added for student with ID {id}.");
    }

    // Adds a grade to a student's subject
    public void AddGrade()
    {
        Console.WriteLine("Enter student ID, subject, and grade:");
        var id = Console.ReadLine();
        var subject = Console.ReadLine();
        var grade = int.Parse(Console.ReadLine());

        manager.AddGradeToStudentSubject(id, subject, grade);
        Console.WriteLine($"Grade {grade} added for {subject} to student with ID {id}.");
    }

    // Shows the average grade for a student across all subjects
    public void ShowAverageGrade()
    {
        Console.WriteLine("Enter student ID to calculate average grade:");
        var id = Console.ReadLine();
        var avgGrade = manager.CalculateAverageGrade(id);

        if (avgGrade > 0)
            Console.WriteLine($"Average grade for student with ID {id} is {avgGrade:F2}.");
        else
            Console.WriteLine("No grades available or student not found.");
    }

    // Displays a simple menu to navigate the application
    public void Start()
    {
        string command;
        do
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1 - Add Student");
            Console.WriteLine("2 - Remove Student");
            Console.WriteLine("3 - Add Subject to Student");
            Console.WriteLine("4 - Add Grade to Subject");
            Console.WriteLine("5 - Show Average Grade");
            Console.WriteLine("0 - Exit");

            command = Console.ReadLine();
            switch (command)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    RemoveStudent();
                    break;
                case "3":
                    AddSubject();
                    break;
                case "4":
                    AddGrade();
                    break;
                case "5":
                    ShowAverageGrade();
                    break;
                case "0":
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        } while (command != "0");
    }
}
