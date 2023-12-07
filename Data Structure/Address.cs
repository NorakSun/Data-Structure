using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

 /*   class Program
    {
        static void Main()
        {
            // Using constructors with all arguments and no arguments
            Address address1 = new Address("123", "Main St", "Cityville", "12345", "State1");
            Address address2 = new Address();

            // Displaying information using ToString method
            Console.WriteLine("Address 1 Information:");
            Console.WriteLine(address1.ToString());
            Console.WriteLine();

            Console.WriteLine("Address 2 Information:");
            Console.WriteLine(address2.ToString());
        }
    }*/

}

