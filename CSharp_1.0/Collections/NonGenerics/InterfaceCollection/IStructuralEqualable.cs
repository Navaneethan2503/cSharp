using System;
using System.Collections;
using System.Collections.Generic;

/**
The IStructuralEquatable interface in C# is part of the System.Collections namespace and is used to provide a mechanism for comparing objects for structural equality. This interface is particularly useful for comparing collections or composite objects where the comparison is based on the structure and contents of the objects rather than their reference or identity.

Structural equality means that two objects are equal because they have equal values. It differs from reference equality, which indicates that two object references are equal because they reference the same physical object. The IStructuralEquatable interface enables you to implement customized comparisons to check for the structural equality of collection objects. That is, you can create your own definition of structural equality and specify that this definition be used with a collection type that accepts the IStructuralEquatable interface. The interface has two members: Equals, which tests for equality by using a specified IEqualityComparer implementation, and GetHashCode, which returns identical hash codes for objects that are equal.

Methods:
---------
Equals(Object, IEqualityComparer)	- Determines whether an object is structurally equal to the current instance.
    public bool Equals(object? other, System.Collections.IEqualityComparer comparer);

GetHashCode(IEqualityComparer)	- Returns a hash code for the current instance.
    public int GetHashCode(System.Collections.IEqualityComparer comparer);


Key Differences:
---------------
Purpose:
IEqualityComparer: Used for equality comparison of individual objects.
IStructuralEquatable: Used for structural equality comparison of composite objects.

Methods:
IEqualityComparer: Equals(object x, object y) and GetHashCode(object obj)
IStructuralEquatable: Equals(object other, IEqualityComparer comparer) and GetHashCode(IEqualityComparer comparer)

Usage Context:
IEqualityComparer: Used in hash-based collections to check for equality and generate hash codes.
IStructuralEquatable: Used in composite objects like tuples and arrays to compare their structure and contents.

Return Values:
Both interfaces return a boolean for equality checks and an integer for hash codes.

**/
namespace IStructuralEqualableNamespace{

    public class NanComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            if (x is float)
                return (float) x == (float) y;
            else if (x is double)
                return (double) x == (double) y;
            else
                return EqualityComparer<object>.Default.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return EqualityComparer<object>.Default.GetHashCode(obj);
        }
    }

    class IStructuralEqualableClass{
        public static void Main(){
            Console.WriteLine("IStructural Equalable ....");
            var t1 = Tuple.Create(12.3, Double.NaN, 16.4);
            var t2 = Tuple.Create(12.3, Double.NaN, 16.4);

            // Call default Equals method.
            Console.WriteLine(t1.Equals(t2));

            IStructuralEquatable equ = t1;
            // Call IStructuralEquatable.Equals using default comparer.
            Console.WriteLine(equ.Equals(t2, EqualityComparer<object>.Default));

            // Call IStructuralEquatable.Equals using
            // StructuralComparisons.StructuralEqualityComparer.
            Console.WriteLine(equ.Equals(t2,
                                StructuralComparisons.StructuralEqualityComparer));

            // Call IStructuralEquatable.Equals using custom comparer.
            Console.WriteLine(equ.Equals(t2, new NanComparer()));
        }
    }
}