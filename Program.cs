using System;
using System.Collections.Generic;

// Defined an abstract class to represent a student
abstract class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
        Grade = 0;
    }

    public void SetGrade(double grade)
    {
        Grade = grade;
    }

    public abstract void DisplayInfo();
}

// Defined a derived class for a specific type of student
class ScienceStudent : Student
{
    public string FieldOfStudy { get; set; }

    public ScienceStudent(string name, int age, string fieldOfStudy) : base(name, age)
    {
        FieldOfStudy = fieldOfStudy;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Grade: {Grade}, Field of Study: {FieldOfStudy}");
    }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Update student's grade");
            Console.WriteLine("3. Display all students");
            Console.WriteLine("4. Calculate average grade");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    UpdateGrade();
                    break;
                case "3":
                    DisplayAllStudents();
                    break;
                case "4":
                    CalculateAverageGrade();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }



// functions
    static void AddStudent()
    {
        Console.WriteLine("Enter student name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter student age:");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter field of study (for Science Student):");
        string fieldOfStudy = Console.ReadLine();

        students.Add(new ScienceStudent(name, age, fieldOfStudy));
        Console.WriteLine("Student added successfully.");
    }

    static void UpdateGrade()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students added yet.");
            return;
        }

        Console.WriteLine("Enter student name:");
        string name = Console.ReadLine();

        Student student = students.Find(s => s.Name == name);
        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine("Enter new grade:");
        double grade = Convert.ToDouble(Console.ReadLine());

        student.SetGrade(grade);
        Console.WriteLine("Grade updated successfully.");
    }

    static void DisplayAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students added yet.");
            return;
        }

        Console.WriteLine("All Students:");
        foreach (var student in students)
        {
            student.DisplayInfo();
        }
    }

    static void CalculateAverageGrade()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students added yet.");
            return;
        }

        double totalGrade = 0;
        foreach (var student in students)
        {
            totalGrade += student.Grade;
        }

        double averageGrade = totalGrade / students.Count;
        Console.WriteLine($"Average Grade: {averageGrade}");
    }
}
