using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{

    public class Students : IComparable<Student>
    {
        // Constants
        public const string DefaultStudentID = "N/A";
        public const string DefaultProgram = "N/A";
        public const string DefaultDateRegistered = "N/A";

        // Properties
        public string StudentID { get; set; }
        public string Program { get; set; }
        public string DateRegistered { get; set; }

        // Constructor with all arguments
        public Students(string studentID, string program, string dateRegistered)
        {
            StudentID = studentID;
            Program = program;
            DateRegistered = dateRegistered;
        }

        // Constructor with no arguments (using default values)
        public Students() : this(DefaultStudentID, DefaultProgram, DefaultDateRegistered)
        {
        }

        // ToString method
        public override string ToString()
        {
            return $"Student: StudentID: {StudentID}, Program: {Program}, Date Registered: {DateRegistered}";
        }

        // Implementation of IComparable interface
        public int CompareTo(Student other)
        {
            if (other == null)
                return 1;

            // Compare StudentID for ordering
            return string.Compare(this.StudentID, other.StudentID, StringComparison.Ordinal);
        }
    }

  /*  class Program
    {
        static void Main()
        {
            // Using constructors with all arguments and no arguments
            Student student1 = new Student("S12345", "Computer Science", "2023-01-15");
            Student student2 = new Student();

            // Displaying information using ToString method
            Console.WriteLine("Student 1 Information:");
            Console.WriteLine(student1.ToString());
            Console.WriteLine();

            Console.WriteLine("Student 2 Information:");
            Console.WriteLine(student2.ToString());

            // Checking equality using the Equals method
            Console.WriteLine("\nChecking Equality:");
            bool areEqual = student1.Equals(student2);
            Console.WriteLine($"Are Student 1 and Student 2 equal? {areEqual}");
        }
    }*/


}
