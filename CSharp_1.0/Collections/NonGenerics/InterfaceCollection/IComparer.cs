using System;
using System.Collections;
/**
The IComparer interface in non-generic collections is part of the System.Collections namespace in .NET. It provides a way to define a custom comparison for sorting elements in a collection. This interface is used to compare two objects and determine their relative order.

Exposes a method that compares two objects.

This interface is used in conjunction with the Array.Sort and Array.BinarySearch methods. It provides a way to customize the sort order of a collection. See the Compare method for notes on parameters and return value. Its generic equivalent is the System.Collections.Generic.IComparer<T> interface.

The default implementation of this interface is the Comparer class. For the generic version of this interface, see System.Collections.Generic.IComparer<T>.

IComparer
Purpose: The IComparer interface is used to define custom comparison logic for sorting objects. It is primarily used in collections that need to be sorted, such as arrays and lists.

Methods:
-----------
Compare(Object, Object)	- Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
    public int Compare(object? x, object? y);
    A signed integer that indicates the relative values of x and y:
    - If less than 0, x is less than y.
    - If 0, x equals y.
    - If greater than 0, x is greater than y.
**/
namespace IComparerNamespace{

    public class ReverserClass : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(y, x));
        }
    }

    class IComparerClass{
        public static void Main(){
            Console.WriteLine("IComparer Interface ...");
            // Initialize a string array.
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over",
                                "the", "lazy", "dog" };

            // Display the array values.
            Console.WriteLine("The array initially contains the following values:" );
            PrintIndexAndValues(words);

            // Sort the array values using the default comparer.
            Array.Sort(words);
            Console.WriteLine("After sorting with the default comparer:" );
            PrintIndexAndValues(words);

            // Sort the array values using the reverse case-insensitive comparer.
            Array.Sort(words, new ReverserClass());
            Console.WriteLine("After sorting with the reverse case-insensitive comparer:");
            PrintIndexAndValues(words);
        }

         public static void PrintIndexAndValues(IEnumerable list)
        {
            int i = 0;
            foreach (var item in list )
                Console.WriteLine($"   [{i++}]:  {item}");

            Console.WriteLine();
        }
    }
}