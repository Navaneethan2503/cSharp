using System;
using System.Collections;
/**
Defines a generalized type-specific comparison method that a value type or class implements to order or sort its instances.
    public interface IComparable

This interface is implemented by types whose values can be ordered or sorted. It requires that implementing types define a single method, CompareTo(Object), that indicates whether the position of the current instance in the sort order is before, after, or the same as a second object of the same type. The instance's IComparable implementation is called automatically by methods such as Array.Sort and ArrayList.Sort.

Value	Meaning
Less than zero	The current instance precedes the object specified by the CompareTo method in the sort order.
Zero	This current instance occurs in the same position in the sort order as the object specified by the CompareTo method.
Greater than zero	This current instance follows the object specified by the CompareTo method in the sort order.

The implementation of the CompareTo(Object) method must return an Int32 that has one of three values, as shown in the following table.

All numeric types (such as Int32 and Double) implement IComparable, as do String, Char, and DateTime. Custom types should also provide their own implementation of IComparable to enable object instances to be ordered or sorted.

Methods:
----------
CompareTo(Object) - Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    public int CompareTo(T? other);
    
Key Differences:
-------------------
Type Safety:
IComparable: Not type-safe, requires casting.
IComparable<T>: Type-safe, no casting required.

Parameter Type:
IComparable: Takes an object as a parameter.
IComparable<T>: Takes a parameter of type T.

Usage:
IComparable: Suitable for non-generic collections or when comparing objects of different types.
IComparable<T>: Suitable for generic collections and ensures type safety.

Implementation Complexity:
IComparable: Requires type checking and casting within the CompareTo method.
IComparable<T>: No need for type checking and casting within the CompareTo method.


**/
namespace IComparableInterface{
    public class Temperature : IComparable
    {
        // The temperature value
        protected double temperatureF;

        public int CompareTo(object obj) {
            if (obj == null) return 1;

            Temperature otherTemperature = obj as Temperature;
            if (otherTemperature != null)
                return this.temperatureF.CompareTo(otherTemperature.temperatureF);
            else
            throw new ArgumentException("Object is not a Temperature");
        }

        public double Fahrenheit
        {
            get
            {
                return this.temperatureF;
            }
            set 
            {
                this.temperatureF = value;
            }
        }

        public double Celsius
        {
            get
            {
                return (this.temperatureF - 32) * (5.0/9);
            }
            set
            {
                this.temperatureF = (value * 9.0/5) + 32;
            }
        }
    }

    class IComparableClass{
        public static void Main(){
            Console.WriteLine("IComparable Interface");
            ArrayList temperatures = new ArrayList();
            // Initialize random number generator.
            Random rnd = new Random();

            // Generate 10 temperatures between 0 and 100 randomly.
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                int degrees = rnd.Next(0, 100);
                Temperature temp = new Temperature();
                temp.Fahrenheit = degrees;
                temperatures.Add(temp);
            }

            // Sort ArrayList.
            temperatures.Sort();

            foreach (Temperature temp in temperatures)
                Console.WriteLine(temp.Fahrenheit);
        }
    }
}
// The example displays the following output to the console (individual
// values may vary because they are randomly generated):
//       2
//       7
//       16
//       17
//       31
//       37
//       58
//       66
//       72
//       95