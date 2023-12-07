using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Enrollment
    {
        // Constants
        public const string DefaultDateEnrolled = "N/A";
        public const string DefaultGrade = "N/A";
        public const string DefaultSemester = "N/A";

        // Properties
        public string DateEnrolled { get; set; }
        public string Grade { get; set; }
        public string Semester { get; set; }

        // Constructor with all arguments
        public Enrollment(string dateEnrolled, string grade, string semester)
        {
            DateEnrolled = dateEnrolled;
            Grade = grade;
            Semester = semester;
        }

        // Constructor with no arguments (using default values)
        public Enrollment() : this(DefaultDateEnrolled, DefaultGrade, DefaultSemester)
        {
        }

        // ToString method
        public override string ToString()
        {
            return $"Enrollment: Date Enrolled: {DateEnrolled}, Grade: {Grade}, Semester: {Semester}";
        }
    }

/*    class Program
    {
        static void Main()
        {
            // Using constructors with all arguments and no arguments
            Enrollment enrollment1 = new Enrollment("2023-01-15", "12", "1");
            Enrollment enrollment2 = new Enrollment();

            // Displaying information using ToString method
            Console.WriteLine("Enrollment 1 Information:");
            Console.WriteLine(enrollment1.ToString());
            Console.WriteLine();

            Console.WriteLine("Enrollment 2 Information:");
            Console.WriteLine(enrollment2.ToString());
        }
    }*/

}
