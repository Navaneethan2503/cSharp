using System;
using System.Collections;
/**
The IEqualityComparer interface in C# is part of the System.Collections namespace for non-generic collections and the System.Collections.Generic namespace for generic collections. It provides a way to define custom equality comparison logic for objects. This interface is particularly useful when you need to compare objects for equality in collections like dictionaries or hash sets.

IEqualityComparer
Purpose: The IEqualityComparer interface is used to define custom equality comparison logic for objects. It is primarily used in collections that need to check for equality, such as dictionaries and hash sets.

Key Differences:
----------------
Purpose:
IEqualityComparer: Used for equality comparison.
IComparer: Used for sorting comparison.

Methods:
IEqualityComparer: Equals and GetHashCode.
IComparer: Compare.

Usage Context:
IEqualityComparer: Used in hash-based collections to check for equality and generate hash codes.
IComparer: Used in sorting algorithms to determine the order of elements.

Return Values:
IEqualityComparer.Equals: Returns true or false to indicate equality.
IComparer.Compare: Returns an integer to indicate relative order (less than zero, zero, greater than zero).

Methods:
-------------
Equals(Object, Object)	- Determines whether the specified objects are equal.
    public bool Equals(object? x, object? y);
    true if the specified objects are equal; otherwise, false.

    Principles of Equals(Object, Object):
    ---------------------------------------
    Reflexivity: An object must be equal to itself.

    For any non-null reference value x, Equals(x, x) should return true.
    Symmetry: If one object is equal to another, then the second object must be equal to the first.

    For any non-null reference values x and y, Equals(x, y) should return true if and only if Equals(y, x) returns true.
    Transitivity: If one object is equal to a second object, and the second object is equal to a third object, then the first object must be equal to the third object.

    For any non-null reference values x, y, and z, if Equals(x, y) returns true and Equals(y, z) returns true, then Equals(x, z) should return true.
    Consistency with GetHashCode(Object)
    Implementations of Equals(Object, Object) must ensure that if two objects are considered equal, they must return the same hash code. This is crucial for collections that use hashing, such as dictionaries and hash sets, to function correctly.

GetHashCode(Object)	- Returns a hash code for the specified object.
    public int GetHashCode(object obj);

**/

namespace IEqualityComparerNamespace{

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    
    public class PersonEqualityComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            if (x == null || y == null)
                return false;

            Person personX = x as Person;
            Person personY = y as Person;

            if (personX == null || personY == null)
                return false;

            return personX.Name == personY.Name && personX.Age == personY.Age;
        }

        public int GetHashCode(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            Person person = obj as Person;
            if (person == null)
                throw new ArgumentException("Object is not of type Person");

            int hashName = person.Name == null ? 0 : person.Name.GetHashCode();
            int hashAge = person.Age.GetHashCode();

            return hashName ^ hashAge;
        }
    }

    class IEqualityComparerClass{
        public static void Main(){
            Console.WriteLine("IEquality Comparer ...");
            
            // Create a Hashtable with the custom equality comparer
                    Hashtable hashtable = new Hashtable(new PersonEqualityComparer());

                    // Add Person objects to the Hashtable
                    hashtable.Add(new Person("Alice", 30), "Developer");
                    hashtable.Add(new Person("Bob", 25), "Designer");

                    // Check if the Hashtable contains a specific Person object
                    Person searchPerson = new Person("Alice", 30);
                    bool contains = hashtable.ContainsKey(searchPerson);
                    Console.WriteLine("Hashtable contains Alice, 30: " + contains);

                    // Iterate through the Hashtable
                    Console.WriteLine("Elements in Hashtable:");
                    foreach (DictionaryEntry entry in hashtable)
                    {
                        Person person = entry.Key as Person;
                        Console.WriteLine($"{person.Name}, {person.Age}: {entry.Value}");
                    }

        }
    }
}