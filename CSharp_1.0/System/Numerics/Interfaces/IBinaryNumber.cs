using System;
/**
Defines a number that is represented in a base-2 format.

    public interface IBinaryNumber<TSelf> : IComparable<TSelf>, IEquatable<TSelf>, IParsable<TSelf>, ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>, 
    System.Numerics.IAdditionOperators<TSelf,TSelf,TSelf>, System.Numerics.IAdditiveIdentity<TSelf,TSelf>, System.Numerics.IBitwiseOperators<TSelf,TSelf,TSelf>, 
    System.Numerics.IComparisonOperators<TSelf,TSelf,bool>, System.Numerics.IDecrementOperators<TSelf>, System.Numerics.IDivisionOperators<TSelf,TSelf,TSelf>, 
    System.Numerics.IEqualityOperators<TSelf,TSelf,bool>, System.Numerics.IIncrementOperators<TSelf>, System.Numerics.IModulusOperators<TSelf,TSelf,TSelf>, System.Numerics.IMultiplicativeIdentity<TSelf,TSelf>, 
    System.Numerics.IMultiplyOperators<TSelf,TSelf,TSelf>, System.Numerics.INumber<TSelf>, System.Numerics.INumberBase<TSelf>, System.Numerics.ISubtractionOperators<TSelf,TSelf,TSelf>, System.Numerics.IUnaryNegationOperators<TSelf,TSelf>, 
    System.Numerics.IUnaryPlusOperators<TSelf,TSelf> where TSelf : IBinaryNumber<TSelf>

Properties:
-----------
AllBitsSet	- Gets an instance of the binary type in which all bits are set.
    public static virtual TSelf AllBitsSet { get; }

Methods:
-------
CompareTo(Object)	- Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.(Inherited from IComparable)
CompareTo(T)	- Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.(Inherited from IComparable<T>)
Equals(T) - Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
IsPow2(TSelf)	- Determines if a value is a power of two.
    public static abstract bool IsPow2(TSelf value);

Log2(TSelf)	- Computes the log2 of a value.
    public static abstract TSelf Log2(TSelf value);
    
ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)



**/
namespace NumericsInterfaces{
    class IBinaryNumber{
        public static void Main(){
            Console.WriteLine("IBinary Number.");
        }
    }
}