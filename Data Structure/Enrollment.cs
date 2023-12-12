using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class Enrollment
    {
        // Properties
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public double Cost { get; set; }
        public List<Enrollment> Enrollments { get; set; }

        // Constructor with all arguments
        public Enrollment(string courseCode, string courseName, double cost, List<Enrollment> enrollments)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            Cost = cost;
            Enrollments = enrollments;
        }

        // Constructor with no arguments
        public Enrollment() : this("N/A", "N/A", 0, new List<Enrollment>())
        {
        }

        // ToString method
        public override string ToString()
        {
            string enrollmentInfo = string.Join(", ", Enrollments);
            return $"Course: Code: {CourseCode}, Name: {CourseName}, Cost: {Cost:C}, Enrollments: {enrollmentInfo}";
        }
    }

 /*   public class Program
    {
        static void Main()
        {
            // Using constructors with all arguments and no arguments
            Enrollment enrollment1 = new Enrollment("CS101", "Introduction to Programming", 500.00, new List<Enrollment>());
            Enrollment enrollment2 = new Enrollment("CS102", "Data Structures", 600.00, new List<Enrollment>());

            List<Enrollment> enrollments = new List<Enrollment> { enrollment1, enrollment2 };

            Enrollment course1 = new Enrollment("2023-01-15", "A", 1, enrollments);
            Enrollment course2 = new Enrollment("2023-02-20", "B", 2, new List<Enrollment>());

            // Displaying information using ToString method
            Console.WriteLine("Course 1 Information:");
            Console.WriteLine(course1.ToString());
            Console.WriteLine();

            Console.WriteLine("Course 2 Information:");
            Console.WriteLine(course2.ToString());
        }
    }*/
}
