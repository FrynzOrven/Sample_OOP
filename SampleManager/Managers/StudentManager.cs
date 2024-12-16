using System;
using System.Collections.Generic;
using System.Linq;
namespace StudentManager
{
    // Student class represents a student with properties like ID, Name, Age, and Course
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }

        // Constructor to initialize student properties
        public Student(int id, string name, int age, string course)
        {
            Id = id;
            Name = name;
            Age = age;
            Course = course;
        }
    }

    // StudentManager class handles operations on the student list like adding, updating, deleting, and retrieving students
    public class StudentManager
    {
        // Private list to store students
        private readonly List<Student> _studentList = new List<Student>();

        // Method to get all students
        public IEnumerable<Student> GetAllStudents()
        {
            return _studentList;
        }

        // Method to get a student by their ID
        public Student GetStudentById(int id)
        {
            return _studentList.FirstOrDefault(s => s.Id == id);
        }

        // Method to add a student to the list
        public void AddStudent(Student newStudent)
        {
            // Automatically set the ID for new students
            newStudent.Id = _studentList.Any() ? _studentList.Max(s => s.Id) + 1 : 1;
            _studentList.Add(newStudent);
            Console.WriteLine($"Student {newStudent.Name} added.");
        }

        // Method to update an existing student's details
        public void UpdateStudent(int id, Student updatedStudent)
        {
            var existingStudent = _studentList.FirstOrDefault(s => s.Id == id);
            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Age = updatedStudent.Age;
                existingStudent.Course = updatedStudent.Course;
                Console.WriteLine($"Student {id} updated.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        // Method to delete a student by their ID
        public void DeleteStudent(int id)
        {
            var student = _studentList.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _studentList.Remove(student);
                Console.WriteLine($"Student {id} deleted.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }

    // Program class to test the StudentManager functionality
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of StudentManager
            StudentManager manager = new StudentManager();

            // Create new students
            Student student1 = new Student(0, "John Doe", 20, "Computer Science");
            Student student2 = new Student(0, "Jane Smith", 22, "Mathematics");

            // Add students to the list
            manager.AddStudent(student1);
            manager.AddStudent(student2);

            // Display all students
            Console.WriteLine("All Students:");
            foreach (var student in manager.GetAllStudents())
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
            }

            // Update a student's information
            student1.Name = "Johnathan Doe";
            manager.UpdateStudent(1, student1);

            // Display updated students
            Console.WriteLine("\nUpdated Students:");
            foreach (var student in manager.GetAllStudents())
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
            }

            // Delete a student
            manager.DeleteStudent(1);

            // Display students after deletion
            Console.WriteLine("\nStudents after deletion:");
            foreach (var student in manager.GetAllStudents())
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
            }
        }
    }
}
