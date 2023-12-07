using System;
using System.Collections.Generic;


namespace DataStructure
{
    public interface IComparator<T>
    {
        int CompareTo(T other);
    }

    public class Student : IComparator<Student>
    {
        public string StudentID { get; set; }
        public string Program { get; set; }
        public string DateRegistered { get; set; }

        public int CompareTo(Student other)
        {
            // Compare based on the student ID
            return StudentID.CompareTo(other.StudentID);
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

    internal class Searching
    {
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
                    new Student { StudentID = "1", Program = "Computer Science", DateRegistered = "2022-01-01" },
                    new Student { StudentID = "2", Program = "Mathematics", DateRegistered = "2022-02-01" },
                    new Student { StudentID = "3", Program = "Physics", DateRegistered = "2022-03-01" }
                };

                List<Course> courses = new List<Course>
                {
                    new Course { CourseId = 101, CourseName = "Math" },
                    new Course { CourseId = 102, CourseName = "Physics" },
                    new Course { CourseId = 103, CourseName = "Chemistry" }
                };

                Student targetStudent = new Student { StudentID = "2", Program = "Mathematics", DateRegistered = "2022-02-01" };
                Course targetCourse = new Course { CourseId = 102, CourseName = "Physics" };

                Student foundStudent = Utility.BinarySearch(students, targetStudent);
                Course foundCourse = Utility.SequentialSearch(courses, targetCourse);

                Console.WriteLine("Binary Search - StudentID: " + (foundStudent != null ? foundStudent.StudentID : "Not found"));
                Console.WriteLine("Sequential Search - Course: " + (foundCourse != null ? foundCourse.CourseName : "Not found"));
            }
        }*/
    }
}
