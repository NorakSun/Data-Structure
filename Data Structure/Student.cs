using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{

    public class Students : Person, IComparable<Student>
    {
        // Constants
        public const string DefaultStudentID = "N/A";
        public const string DefaultProgram = "N/A";
        public const string DefaultDateRegistered = "N/A";
        private string defaultStudentID;
        private string defaultProgram;
        private string defaultDateRegistered;

        // Properties
        public string StudentID { get; set; }
        public string Program { get; set; }
        public string DateRegistered { get; set; }

        // Constructor with all arguments
        public Students(string studentID, string program, string dateRegistered, string v, string v1)
        {
            StudentID = studentID;
            Program = program;
            DateRegistered = dateRegistered;
        }

        // Constructor with no arguments (using default values)
        public Students() : this(DefaultStudentID, DefaultProgram, DefaultDateRegistered)
        {
        }

        public Students(string defaultStudentID, string defaultProgram, string defaultDateRegistered)
        {
            this.defaultStudentID = defaultStudentID;
            this.defaultProgram = defaultProgram;
            this.defaultDateRegistered = defaultDateRegistered;
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
        public override int GetHashCode()
        {
            // Use a combination of the hash codes of relevant properties
            return HashCode.Combine(StudentID, Program, DateRegistered);
        }

        // Override Equals for proper equality comparison
        public override bool Equals(object obj)
        {
            if (obj is Students other)
            {
                // Compare relevant properties for equality
                return this.StudentID == other.StudentID &&
                       this.Program == other.Program &&
                       this.DateRegistered == other.DateRegistered;
            }

            return false;
        }
        // Override == and != operators
        public static bool operator ==(Students student1, Students student2)
        {
            // Check for null on either side
            if (ReferenceEquals(student1, null) && ReferenceEquals(student2, null))
                return true;
            if (ReferenceEquals(student1, null) || ReferenceEquals(student2, null))
                return false;

            return student1.Equals(student2);
        }

        public static bool operator !=(Students student1, Students student2)
        {
            return !(student1 == student2);
        }

        public class Enrollment
        {
            // Properties
            public string Date { get; set; }
            public string Grade { get; set; }
            public int Semester { get; set; }
            public List<Course> Courses { get; set; }

            // Constructor with all arguments
            public Enrollment(string date, string grade, int semester, List<Course> courses)
            {
                Date = date;
                Grade = grade;
                Semester = semester;
                Courses = courses;
            }


            // Constructor with no arguments
            public Enrollment() : this("N/A", "N/A", 0, new List<Course>())
            {
            }


            // ToString method
            public override string ToString()
            {
                string courseInfo = string.Join(", " + "\n",Courses.Select(course => course.ToString()));
                return $"Enrollment: Date: {Date}, Grade: {Grade}, Semester: {Semester}," + "\n" +
                       $"Courses: {courseInfo}";

            }
        }

        public class Course
        {
            // Properties
            public string CourseCode { get; set; }
            public string CourseName { get; set; }
            public decimal Cost { get; set; }

            // Constructor with all arguments
            public Course(string courseCode, string courseName, decimal cost)
            {
                CourseCode = courseCode;
                CourseName = courseName;
                Cost = cost;
            }

            // Constructor with no arguments
            public Course() : this("N/A", "N/A", 0.00m)
            {
            }

            // Override ToString method for better representation
            public override string ToString()
            {
                return $"Code: {CourseCode}, Name: {CourseName}, Cost: {Cost}";
            }
        }



   /*     public class Test
        {
            static void Main()
            {
                // Create a list of courses
                List<Course> courses = new List<Course>
        {
            new Course("CS101", "Introduction to Programming", 300.00m),
            new Course("CS102", "Data Structures", 400.00m),
        };

                // Create two students with the same information
                Students student1 = new Students("S12345", "Computer Science", "2023-01-15", "John", "Doe");
                Students student2 = new Students("S12345", "Computer Science", "2023-01-15", "Jane", "Smith");

                // Displaying information using ToString method
                Console.WriteLine("Student 1 Information:");
                Console.WriteLine(student1.ToString());
                Console.WriteLine();

                Console.WriteLine("Student 2 Information:");
                Console.WriteLine(student2.ToString());
                Console.WriteLine();

                // Testing ==
                Console.WriteLine($"Using ==: {student1 == student2}");

                // Testing !=
                Console.WriteLine($"Using !=: {student1 != student2}");

                // Testing GetHashCode method
                Console.WriteLine("\nTesting GetHashCode Method:");
                int hashCode1 = student1.GetHashCode();
                int hashCode2 = student2.GetHashCode();

                Console.WriteLine($"HashCode for Student 1: {hashCode1}");
                Console.WriteLine($"HashCode for Student 2: {hashCode2}");

                // Testing equality using the Equals method
                Console.WriteLine("\nTesting Equality:");
                bool areEqual = student1.Equals(student2);
                Console.WriteLine($"Are Student 1 and Student 2 equal? {areEqual}");

                // Modify one student's information
                student2.Program = "Mathematics";

                // Display updated information
                Console.WriteLine("\nUpdated Student 2 Information:");
                Console.WriteLine(student2.ToString());

                // Test equality after modification
                Console.WriteLine("\nTesting Equality after Modification:");
                areEqual = student1.Equals(student2);
                Console.WriteLine($"Are Student 1 and updated Student 2 equal? {areEqual}");

                // Create an enrollment with the list of courses
                Enrollment enrollment = new Enrollment("2023-01-15", "A", 1, courses);

                // Displaying information using ToString method
                Console.WriteLine("\nEnrollment Information:");
                Console.WriteLine(enrollment.ToString());
            }
        }*/
    }
}


