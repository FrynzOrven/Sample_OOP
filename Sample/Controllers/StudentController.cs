using System;
using System.Collections.Generic;

namespace YourNamespace // Make sure this matches the namespace in Program.cs
{
    // Student class
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        // Constructor to initialize Student object
        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
    // Controller class to manage students
    public class StudentController
    {
        private List<Student> students = new List<Student>();

        // Method to add a student
        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Student {student.Name} added.");
        }

        // Method to display all students
        public void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students to display.");
            }
            else
            {
                Console.WriteLine("Displaying all students:");
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}");
                }
            }
        }
    }
}
