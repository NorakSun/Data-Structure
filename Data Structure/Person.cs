using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Person  
    {
        // Constants
        public const string DefaultName = "Unknown";
        public const int DefaultAge = 0;

        // Properties
        public string Name { get; set; }
        public int Age { get; set; }

        // Constructor with all arguments
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Constructor with no arguments (using default values)
        public Person() : this(DefaultName, DefaultAge)
        {
        }

        // ToString method
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

/*    class Program
    {
        static void Main()
        {
            // Using constructors with all arguments and no arguments
            Person person1 = new Person("John Doe", 25);
            Person person2 = new Person();

            // Displaying information using ToString method
            Console.WriteLine("Person 1 Information:");
            Console.WriteLine(person1.ToString());
            Console.WriteLine();

            Console.WriteLine("Person 2 Information:");
            Console.WriteLine(person2.ToString());
        }
    }*/

}

