using System;
using System.Collections;
using System.Collections.Generic;

/**

The IStructuralComparable interface in C# is part of the System.Collections namespace and is used to provide a mechanism for comparing objects structurally. This interface is particularly useful for comparing collections or composite objects where the comparison is based on the structure and contents of the objects rather than their reference or identity.

Key Features of IStructuralComparable
Structural Comparison: Allows for comparison of objects based on their structure and contents.
Custom Comparison Logic: Enables the implementation of custom comparison logic for composite objects.
Integration with Collections: Often used with collections like arrays and tuples to provide structural comparison.

Method:
---------
int CompareTo(object other, IComparer comparer): Compares the current instance with another object using a specified comparer and returns an integer that indicates their relative order.
    Parameters:
    other: The object to compare with the current instance.
    comparer: An IComparer object that provides custom comparison logic.
    Return Values:
    Less than zero: The current instance is less than the other object.
    Zero: The current instance is equal to the other object.
    Greater than zero: The current instance is greater than the other object.

Practical Use Cases
Composite Objects: Use IStructuralComparable to compare composite objects like tuples, arrays, or other collections based on their structure and contents.
Custom Sorting: Implement custom comparison logic for sorting collections of composite objects.
Equality Checks: Perform structural equality checks for complex objects.


Key Differences:
------------------
Purpose:
IStructuralComparable: Used for structural comparison of composite objects.
IComparer: Used for sorting comparison of individual objects.

Methods:
IStructuralComparable: CompareTo(object other, IComparer comparer)
IComparer: Compare(object x, object y)

Usage Context:
IStructuralComparable: Used in composite objects like tuples and arrays to compare their structure and contents.
IComparer: Used in sorting algorithms to determine the order of elements in collections.

Return Values:
Both interfaces return an integer to indicate relative order (less than zero, zero, greater than zero).

**/

namespace IStructuralComparerNamespace{
    
    public class CustomComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentException("Arguments cannot be null");
            }

            int intX = (int)x;
            int intY = (int)y;

            return intX.CompareTo(intY);
        }
    }

    public class PopulationComparer<T1, T2, T3, T4, T5, T6> : IComparer
    {
    private int itemPosition;
    private int multiplier = -1;

    public PopulationComparer(int component) : this(component, true)
    { }

    public PopulationComparer(int component, bool descending)
    {
        if (!descending) multiplier = 1;

        if (component <= 0 || component > 6)
            throw new ArgumentException("The component argument is out of range.");

        itemPosition = component;
    }

    public int Compare(object x, object y)
    {
        var tX = x as Tuple<T1, T2, T3, T4, T5, T6>;
        if (tX == null)
        {
            return 0;
        }
        else
        {
            var tY = y as Tuple<T1, T2, T3, T4, T5, T6>;
            switch (itemPosition)
            {
                case 1:
                return Comparer<T1>.Default.Compare(tX.Item1, tY.Item1) * multiplier;
                case 2:
                return Comparer<T2>.Default.Compare(tX.Item2, tY.Item2) * multiplier;
                case 3:
                return Comparer<T3>.Default.Compare(tX.Item3, tY.Item3) * multiplier;
                case 4:
                return Comparer<T4>.Default.Compare(tX.Item4, tY.Item4) * multiplier;
                case 5:
                return Comparer<T5>.Default.Compare(tX.Item5, tY.Item5) * multiplier;
                case 6:
                return Comparer<T6>.Default.Compare(tX.Item6, tY.Item6) * multiplier;
                default:
                return Comparer<T1>.Default.Compare(tX.Item1, tY.Item1) * multiplier;
            }
        }
    }
    }


    class IStructuralComparerClass{
        public static void Main(){
            Console.WriteLine("IStructural Comparer ...");
                        
            // Create tuples
            var tuple1 = Tuple.Create(1, 2, 3);
            var tuple2 = Tuple.Create(1, 2, 4);

            // Create a custom comparer
            var comparer = new CustomComparer();

            // Compare tuples using IStructuralComparable
            int result = ((IStructuralComparable)tuple1).CompareTo(tuple2, comparer);

            // Display the comparison result
            if (result < 0)
            {
                Console.WriteLine("tuple1 is less than tuple2");
            }
            else if (result == 0)
            {
                Console.WriteLine("tuple1 is equal to tuple2");
            }
            else
            {
                Console.WriteLine("tuple1 is greater than tuple2");
            }
            // Create array of sextuple with population data for three U.S.
            // cities, 1960-2000.
            Tuple<string, int, int, int, int, int>[] cities =
                { Tuple.Create("Los Angeles", 2479015, 2816061, 2966850, 3485398, 3694820),
                    Tuple.Create("New York", 7781984, 7894862, 7071639, 7322564, 8008278),
                    Tuple.Create("Chicago", 3550904, 3366957, 3005072, 2783726, 2896016) };

            // Display array in unsorted order.
            Console.WriteLine("In unsorted order:");
            foreach (var city in cities)
                Console.WriteLine(city.ToString());
            Console.WriteLine();

            Array.Sort(cities, new PopulationComparer<string, int, int, int, int, int>(3));

            // Display array in sorted order.
            Console.WriteLine("Sorted by population in 1970:");
            foreach (var city in cities)
                Console.WriteLine(city.ToString());
            Console.WriteLine();

            Array.Sort(cities, new PopulationComparer<string, int, int, int, int, int>(6));

            // Display array in sorted order.
            Console.WriteLine("Sorted by population in 2000:");
            foreach (var city in cities)
                Console.WriteLine(city.ToString());

        }
    }
}