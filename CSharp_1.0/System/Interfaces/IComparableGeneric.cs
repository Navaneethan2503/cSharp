using System;
using System.Collections.Generic;
/**
Defines a generalized comparison method that a value type or class implements to create a type-specific comparison method for ordering or sorting its instances.
    public interface IComparable<in T>

This interface is implemented by types whose values can be ordered or sorted and provides a strongly typed comparison method for ordering members of a generic collection object. For example, one number can be larger than a second number, and one string can appear in alphabetical order before another. It requires that implementing types define a single method, CompareTo(T), that indicates whether the position of the current instance in the sort order is before, after, or the same as a second object of the same type. Typically, the method is not called directly from developer code. Instead, it is called automatically by methods such as List<T>.Sort() and Add.

Typically, types that provide an IComparable<T> implementation also implement the IEquatable<T> interface. The IEquatable<T> interface defines the Equals method, which determines the equality of instances of the implementing type.

The implementation of the CompareTo(T) method must return an Int32 that has one of three values, as shown in the following table.

Value	Meaning
Less than zero	This object precedes the object specified by the CompareTo method in the sort order.
Zero	This current instance occurs in the same position in the sort order as the object specified by the CompareTo method argument.
Greater than zero	This current instance follows the object specified by the CompareTo method argument in the sort order.
All numeric types (such as Int32 and Double) implement IComparable<T>, as do String, Char, and DateTime. Custom types should also provide their own implementation of IComparable<T> to enable object instances to be ordered or sorted.

Notes to Implementers
Replace the type parameter of the IComparable<T> interface with the type that is implementing this interface.

If you implement IComparable<T>, you should overload the op_GreaterThan, op_GreaterThanOrEqual, op_LessThan, and op_LessThanOrEqual operators to return values that are consistent with CompareTo(T). In addition, you should also implement IEquatable<T>. See the IEquatable<T> article for complete information.

Methods:
-------
CompareTo(T) - Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.

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
namespace IComparableGeneric{
    public class Temperature : IComparable<Temperature>
    {
        // Implement the generic CompareTo method with the Temperature
        // class as the Type parameter.
        //
        public int CompareTo(Temperature other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;

            // The temperature comparison depends on the comparison of
            // the underlying Double values.
            return m_value.CompareTo(other.m_value);
        }

        // Define the is greater than operator.
        public static bool operator >  (Temperature operand1, Temperature operand2)
        {
        return operand1.CompareTo(operand2) > 0;
        }

        // Define the is less than operator.
        public static bool operator <  (Temperature operand1, Temperature operand2)
        {
        return operand1.CompareTo(operand2) < 0;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=  (Temperature operand1, Temperature operand2)
        {
        return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=  (Temperature operand1, Temperature operand2)
        {
        return operand1.CompareTo(operand2) <= 0;
        }

        // The underlying temperature value.
        protected double m_value = 0.0;

        public double Celsius
        {
            get
            {
                return m_value - 273.15;
            }
        }

        public double Kelvin
        {
            get
            {
                return m_value;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException("Temperature cannot be less than absolute zero.");
                }
                else
                {
                    m_value = value;
                }
            }
        }

        public Temperature(double kelvins)
        {
            this.Kelvin = kelvins;
        }
    }

    class IComparableClass{
        public static void Main(){
            Console.WriteLine("IComparable<in T> Controvarient Type parameter.");
            SortedList<Temperature, string> temps =
            new SortedList<Temperature, string>();

            // Add entries to the sorted list, out of order.
            temps.Add(new Temperature(2017.15), "Boiling point of Lead");
            temps.Add(new Temperature(0), "Absolute zero");
            temps.Add(new Temperature(273.15), "Freezing point of water");
            temps.Add(new Temperature(5100.15), "Boiling point of Carbon");
            temps.Add(new Temperature(373.15), "Boiling point of water");
            temps.Add(new Temperature(600.65), "Melting point of Lead");

            foreach( KeyValuePair<Temperature, string> kvp in temps )
            {
                Console.WriteLine("{0} is {1} degrees Celsius.", kvp.Value, kvp.Key.Celsius);
            }
        }
    }
}

/* This example displays the following output:
      Absolute zero is -273.15 degrees Celsius.
      Freezing point of water is 0 degrees Celsius.
      Boiling point of water is 100 degrees Celsius.
      Melting point of Lead is 327.5 degrees Celsius.
      Boiling point of Lead is 1744 degrees Celsius.
      Boiling point of Carbon is 4827 degrees Celsius.
*/