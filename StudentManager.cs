using System;
using System.Collections.Generic;
using System.Linq;

public class StudentManager
{
    // List to store all students
    private List<Student> students = new List<Student>();

    // Adds a new student to the students list
    public void AddStudent(Student student)
    {
        students.Add(student); // Add student to list
        Console.WriteLine($"Added student: {student.Name}"); // Confirm addition
    }

    // Removes a student by their ID
    public void RemoveStudent(string studentId)
    {
        // Remove any student(s) whose ID matches the given ID
        students.RemoveAll(student => student.StudentId == studentId);
        Console.WriteLine($"Removed student with ID: {studentId}"); // Confirm removal
    }

    // Adds a new subject to a student based on their ID
    public void AddSubjectToStudent(string studentId, string subject)
    {
        // Find student by ID
        var student = GetStudentById(studentId);
        if (student == null) // Check if student exists
        {
            Console.WriteLine($"Student with ID {studentId} not found.");
            return;
        }

        // If subject doesn't exist for the student, add it
        if (!student.GradesBySubject.ContainsKey(subject))
        {
            student.GradesBySubject[subject] = new List<int>(); // Initialize subject's grade list
            Console.WriteLine($"Added subject {subject} for {student.Name}");
        }
    }

    // Adds a grade to a specific subject for a student
    public void AddGradeToStudentSubject(string studentId, string subject, int grade)
    {
        // Find student by ID
        var student = GetStudentById(studentId);
        if (student == null) // Check if student exists
        {
            Console.WriteLine($"Student with ID {studentId} not found.");
            return;
        }

        // Check if subject exists, then add grade to subject
        if (student.GradesBySubject.ContainsKey(subject))
        {
            student.GradesBySubject[subject].Add(grade); // Add grade to subject
            Console.WriteLine($"Added grade {grade} for {student.Name} in {subject}");
        }
        else
        {
            Console.WriteLine($"Subject {subject} not found for {student.Name}"); // If subject doesn't exist
        }
    }

    // Calculates the average grade for a student across all subjects
    public double CalculateAverageGrade(string studentId)
    {
        // Find student by ID
        var student = GetStudentById(studentId);
        if (student == null) // Check if student exists
        {
            Console.WriteLine($"Student with ID {studentId} not found.");
            return 0; // Return 0 if student is not found
        }

        // Collect all grades from each subject and calculate the average
        var allGrades = student.GradesBySubject.Values.SelectMany(grades => grades);
        return allGrades.Any() ? allGrades.Average() : 0; // Return average or 0 if no grades
    }

    // Helper method to find a student by ID
    private Student GetStudentById(string studentId)
    {
        // Returns the first student found with the matching ID, or null if not found
        return students.FirstOrDefault(student => student.StudentId == studentId);
    }
}
