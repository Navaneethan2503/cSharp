using System;
/**
The IEquatable<T> interface in C# is used to define a generalized method for determining equality of instances of a type. This interface is particularly useful for types that need to be compared for equality in collections, such as lists, dictionaries, and other data structures.
    public interface IEquatable<T>

Purpose
The purpose of the IEquatable<T> interface is to provide a strongly-typed method for checking equality between instances of a type. Implementing this interface allows a type to be compared for equality in a type-safe manner, which can improve performance and reduce errors compared to using the Object.Equals method.

This interface is implemented by types whose values can be equated (for example, the numeric and string classes). A value type or class implements the Equals method to create a type-specific method suitable for determining equality of instances.

The IEquatable<T> interface is used by generic collection objects such as Dictionary<TKey,TValue>, List<T>, and LinkedList<T> when testing for equality in such methods as Contains, IndexOf, LastIndexOf, and Remove. It should be implemented for any object that might be stored in a generic collection.

The IEquatable<T> interface is used by generic collection objects such as Dictionary<TKey,TValue>, List<T>, and LinkedList<T> when testing for equality in such methods as Contains, IndexOf, LastIndexOf, and Remove. It should be implemented for any object that might be stored in a generic collection.

For more information about implementing the IEquatable<T> interface, see remarks on the IEquatable<T>.Equals method.

Notes to Implementers
Replace the type parameter of the IEquatable<T> interface with the type that is implementing this interface.

If you implement IEquatable<T>, you should also override the base class implementations of Equals(Object) and GetHashCode() so that their behavior is consistent with that of the Equals(T) method. If you do override Equals(Object), your overridden implementation is also called in calls to the static Equals(System.Object, System.Object) method on your class. In addition, you should overload the op_Equality and op_Inequality operators. This ensures that all tests for equality return consistent results.

For a value type, you should always implement IEquatable<T> and override Equals(Object) for better performance. Equals(Object) boxes value types and relies on reflection to compare two values for equality. Both your implementation of Equals(T) and your override of Equals(Object) should return consistent results.

If you implement IEquatable<T>, you should also implement IComparable<T> if instances of your type can be ordered or sorted. If your type implements IComparable<T>, you almost always also implement IEquatable<T>.

Note that there are some designs where a type supports an order relation, but equality may be distinct from an ordering relation. Consider a Person class where you sort alphabetically. Two people with the same name sort the same, but are not the same person.

Methods:
----------
Equals(T) - Indicates whether the current object is equal to another object of the same type.

**/
namespace IEqualableNamespace{
    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public bool Equals(Person other)
        {
            if (other == null)
                return false;

            return Name == other.Name && Age == other.Age;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is Person person)
                return Equals(person);

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }

        public override string ToString()
        {
            return $"{Name}, Age: {Age}";
        }
    }

    class IEqualableClass{
        public static void Main(){
            Console.WriteLine("IEqualable");
            Person person1 = new Person("Alice", 30);
            Person person2 = new Person("Alice", 30);
            Person person3 = new Person("Bob", 25);

            Console.WriteLine($"person1 equals person2: {person1.Equals(person2)}"); // True
            Console.WriteLine($"person1 equals person3: {person1.Equals(person3)}"); // False
        }
    }
}

