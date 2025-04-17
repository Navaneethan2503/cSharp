using System;
using System.Globalization;

/**
Defines a mechanism for parsing a string to a value.
    public interface IParsable<TSelf> where TSelf : IParsable<TSelf>

Methods:
----------
Parse(String, IFormatProvider)	- Parses a string into a value.
    public static abstract TSelf Parse(string s, IFormatProvider? provider);

TryParse(String, IFormatProvider, TSelf)	- Tries to parse a string into a value.
    public static abstract bool TryParse(string? s, IFormatProvider? provider, out TSelf result);


Purpose
The purpose of the IParsable<T> interface is to provide a standardized way to parse instances of a type from a string representation. Implementing this interface allows a type to be converted from a string in a type-safe manner.

Usage
To implement the IParsable<T> interface, a type must provide an implementation for the Parse method. This method should return an instance of the type that is parsed from the specified string


**/
namespace IParsableNamespace{
    public class Person : IParsable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public static Person Parse(string s, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("Input string is null or empty");

            var parts = s.Split(',');
            if (parts.Length != 2)
                throw new FormatException("Input string is not in the correct format");

            string name = parts[0].Trim();
            if (!int.TryParse(parts[1].Trim(), NumberStyles.Integer, provider, out int age))
                throw new FormatException("Age is not in the correct format");

            return new Person(name, age);
        }

        public static bool TryParse(string? s, IFormatProvider? provider, out Person result){
            result = Parse(s,provider);
            return true;
        }

        public override string ToString()
        {
            return $"{Name}, Age: {Age}";
        }
    }
    class IParsableClass{
        public static void Main(){
            string input = "Alice, 30";
            IFormatProvider provider = CultureInfo.InvariantCulture;

            Person person = Person.Parse(input, provider);

            Console.WriteLine($"Parsed Person: {person}");
        }
    }
}






