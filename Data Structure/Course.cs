using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{

    public class Courses
    {
        // Constants
        public const string DefaultCourseCode = "N/A";
        public const string DefaultCourseName = "N/A";
        public const decimal DefaultCost = 0.00M;

        // Properties
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public decimal Cost { get; set; }

        // Constructor with all arguments
        public Courses(string courseCode, string courseName, decimal cost)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            Cost = cost;
        }

        // Constructor with no arguments (using default values)
        public Courses() : this(DefaultCourseCode, DefaultCourseName, DefaultCost)
        {
        }

        // ToString method
        public override string ToString()
        {
            return $"Course: {CourseCode} - {CourseName}, Cost: {Cost:C}";
        }
    }

 /*   class Program
    {
        static void Main()
        {
            // Using constructors with all arguments and no arguments
            Course course1 = new Course("CS101", "Introduction to Programming", 500.00M);
            Course course2 = new Course();

            // Displaying information using ToString method
            Console.WriteLine("Course 1 Information:");
            Console.WriteLine(course1.ToString());
            Console.WriteLine();

            Console.WriteLine("Course 2 Information:");
            Console.WriteLine(course2.ToString());
        }
    }*/

}
