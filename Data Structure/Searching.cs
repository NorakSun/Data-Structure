using Data_Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data_Structure.Searching;

namespace Data_Structure
{
    internal class Searching
    {

        public interface IComparator<T>
        {
            int CompareTo(T other);
        }

        public class Student : IComparator<Student>
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public int CompareTo(Student other)
            {
                // Compare based on the student ID
                return Id.CompareTo(other.Id);
            }
        }

        public class Course : IComparator<Course>
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }

            public int CompareTo(Course other)
            {
                // Compare based on the course ID
                return CourseId.CompareTo(other.CourseId);
            }
        }

        public static class Utility
        {
            public static T BinarySearch<T>(List<T> sortedList, T target) where T : IComparator<T>
            {
                int low = 0;
                int high = sortedList.Count - 1;

                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    int comparisonResult = sortedList[mid].CompareTo(target);

                    if (comparisonResult == 0)
                    {
                        return sortedList[mid]; // Objects are equal
                    }
                    else if (comparisonResult < 0)
                    {
                        low = mid + 1; // Target is greater
                    }
                    else
                    {
                        high = mid - 1; // Target is less than
                    }
                }

                return default(T); // Not found
            }

            public static T SequentialSearch<T>(List<T> unsortedList, T target) where T : IComparator<T>
            {
                foreach (var item in unsortedList)
                {
                    if (item.CompareTo(target) == 0)
                    {
                        return item; // Objects are equal
                    }
                }

                return default(T); // Not found
            }
        }


 /*       class Program
        {
            static void Main()
            {
                List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice" },
            new Student { Id = 2, Name = "Bob" },
            new Student { Id = 3, Name = "Charlie" }
        };

                List<Course> courses = new List<Course>
        {
            new Course { CourseId = 101, CourseName = "Math" },
            new Course { CourseId = 102, CourseName = "Physics" },
            new Course { CourseId = 103, CourseName = "Chemistry" }
        };

                Student targetStudent = new Student { Id = 2, Name = "Bob" };
                Course targetCourse = new Course { CourseId = 102, CourseName = "Physics" };

                Student foundStudent = Utility.BinarySearch(students, targetStudent);
                Course foundCourse = Utility.SequentialSearch(courses, targetCourse);

                Console.WriteLine("Binary Search - Student: " + (foundStudent != null ? foundStudent.Name : "Not found"));
                Console.WriteLine("Sequential Search - Course: " + (foundCourse != null ? foundCourse.CourseName : "Not found"));
            }
        }*/

    }
}