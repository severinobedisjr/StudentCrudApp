using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentCrudApp
{
    // 1. Student Model
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    class Program
    {
        // In-memory data store for demonstration
        private static List<Student> students = new List<Student>();
        private static int nextId = 1;

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("       STUDENT MANAGEMENT SYSTEM        ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add New Student (Create)");
                Console.WriteLine("2. View All Students (Read)");
                Console.WriteLine("3. Update Student (Update)");
                Console.WriteLine("4. Delete Student (Delete)");
                Console.WriteLine("5. Exit");
                   Console.WriteLine("3. Update Student (Update)");
                Console.WriteLine("4. Delete Student (Delete)");
                Console.WriteLine("5. Exit");

                Console.Write("Select an option (1-5): ");

                switch (Console.ReadLine())
                {
                    case "1": CreateStudent(); break;
                    case "2": ReadStudents(); break;
                    case "3": UpdateStudent(); break;
                    case "4": DeleteStudent(); break;
                    case "5": running = false; break;
                    default:
                        Console.WriteLine("Invalid option! Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // CREATE: Add a new student record
        static void CreateStudent()
        {
            Console.Clear();
            Console.WriteLine("--- Add New Student ---");
            
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter Course: ");
            string course = Console.ReadLine() ?? "";

            Console.Write("Enter Age: ");
            int.TryParse(Console.ReadLine(), out int age);

            Student newStudent = new Student
            {
                Id = nextId++,
                Name = name,
                Course = course,
                Age = age
            };

            students.Add(newStudent);
            Console.WriteLine("\nStudent created successfully!");
            Console.WriteLine("Press Enter to return to main menu...");
            Console.ReadLine();
        }

        // READ: Display all student records
        static void ReadStudents()
        {
            Console.Clear();
            Console.WriteLine("--- Student List ---");

            if (students.Count == 0)
            {
                Console.WriteLine("No student records found.");
            }
            else
            {
                Console.WriteLine("{0,-5} {1,-50} {2,-50} {3,-5}", "ID", "Name", "Course", "Age");
                Console.WriteLine(new string('-', 50));
                foreach (var s in students)
                {
                    Console.WriteLine("{0,-5} {1,-50} {2,-50} {3,-5}", s.Id, s.Name, s.Course, s.Age);
                }
            }

            Console.WriteLine("\nPress Enter to return to main menu...");
            Console.ReadLine();
        }

        // UPDATE: Modify an existing student record
        static void UpdateStudent()
        {
            Console.Clear();
            Console.WriteLine("--- Update Student ---");
            Console.Write("Enter Student ID to update: ");
            
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var student = students.FirstOrDefault(s => s.Id == id);
                if (student != null)
                {
                    Console.Write($"Enter New Name (Current: {student.Name}): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName)) student.Name = newName;

                    Console.Write($"Enter New Course (Current: {student.Course}): ");
                    string newCourse = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCourse)) student.Course = newCourse;

                    Console.Write($"Enter New Age (Current: {student.Age}): ");
                    string ageInput = Console.ReadLine();
                    if (int.TryParse(ageInput, out int newAge)) student.Age = newAge;

                    Console.WriteLine("\nStudent record updated successfully!");
                }
                else
                {
                    Console.WriteLine("Student ID not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }

            Console.WriteLine("\nPress Enter to return to main menu...");
            Console.ReadLine();
        }

        // DELETE: Remove a student record
        static void DeleteStudent()
        {
            Console.Clear();
            Console.WriteLine("--- Delete Student ---");
            Console.Write("Enter Student ID to delete: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var student = students.FirstOrDefault(s => s.Id == id);
                if (student != null)
                {
                    students.Remove(student);
                    Console.WriteLine($"Student ID {id} removed successfully.");
                }
                else
                {
                    Console.WriteLine("Student ID not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }

            Console.WriteLine("\nPress Enter to return to main menu...");
            Console.ReadLine();
        }
    }
}
