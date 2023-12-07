using System;

namespace DataStructure
{
    public class student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + StudentId.GetHashCode();
            hash = hash * 23 + EnrollmentDate.GetHashCode();
            return hash;
        }
    }

    /*   class Program
       {
           static void Main()
           {
               // Creating student objects
               Student student1 = new Student { StudentID = 1, Name = "John Doe", EnrollmentDate = DateTime.Parse("2022/01/15") };
               Student student2 = new Student { StudentID = 2, Name = "Jane Doe", EnrollmentDate = DateTime.Parse("2022/02/20") };

               // Hash codes
               int hash1 = student1.GetHashCode();
               int hash2 = student2.GetHashCode();

               // Displaying hash codes
               Console.WriteLine($"Hash code for {student1.Name}: {hash1}");
               Console.WriteLine($"Hash code for {student2.Name}: {hash2}");
           }
       }*/

}
