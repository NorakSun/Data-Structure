using System;

namespace DataStructure
{
    public class Address
    {
        // Constants
        public const string DefaultNumber = "N/A";
        public const string DefaultStreet = "N/A";
        public const string DefaultSuburb = "N/A";
        public const string DefaultPostcode = "N/A";
        public const string DefaultState = "N/A";

        // Properties
        public string Number { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }

        // Constructor with all arguments
        public Address(string number, string street, string suburb, string postcode, string state)
        {
            Number = number;
            Street = street;
            Suburb = suburb;
            Postcode = postcode;
            State = state;
        }

        // Constructor with no arguments (using default values)
        public Address() : this(DefaultNumber, DefaultStreet, DefaultSuburb, DefaultPostcode, DefaultState)
        {
        }

        // ToString method
        public override string ToString()
        {
            return $"Address: {Number} {Street}, {Suburb}, {State} {Postcode}";
        }
    }

    public class Person
    {
        // Constants
        public const string DefaultName = "Unknown";
        public const int DefaultAge = 0;

        // Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Residence { get; set; } // Property of type Address

        // Constructor with all arguments including address
        public Person(string name, int age, Address address)
        {
            Name = name;
            Age = age;
            Residence = address;
        }

        // Constructor with no arguments (using default values)
        public Person() : this(DefaultName, DefaultAge, new Address())
        {
        }

        // ToString method
        public override string ToString()
        {
            string personInfo = $"Name: {Name}, Age: {Age}";
            string addressInfo = Residence != null ? Environment.NewLine + Residence.ToString() : string.Empty;
            return personInfo + addressInfo;
        }
    }

/*    class Program
    {
        static void Main()
        {
            // Using constructors with all arguments and no arguments
            Person person1 = new Person("John Doe", 25, new Address("123", "Main St", "Cityville", "12345", "State1"));
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
