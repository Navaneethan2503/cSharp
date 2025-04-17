using System;
using System.Numerics;
/**
Defines an integer type that is represented in a base-2 format.

public interface IBinaryInteger<TSelf> : IComparable<TSelf>, IEquatable<TSelf>, IParsable<TSelf>, ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>, 
System.Numerics.IAdditionOperators<TSelf,TSelf,TSelf>, System.Numerics.IAdditiveIdentity<TSelf,TSelf>, System.Numerics.IBinaryNumber<TSelf>, System.Numerics.IBitwiseOperators<TSelf,TSelf,TSelf>, 
System.Numerics.IComparisonOperators<TSelf,TSelf,bool>, System.Numerics.IDecrementOperators<TSelf>, System.Numerics.IDivisionOperators<TSelf,TSelf,TSelf>, System.Numerics.IEqualityOperators<TSelf,TSelf,bool>,
 System.Numerics.IIncrementOperators<TSelf>, System.Numerics.IModulusOperators<TSelf,TSelf,TSelf>, System.Numerics.IMultiplicativeIdentity<TSelf,TSelf>, System.Numerics.IMultiplyOperators<TSelf,TSelf,TSelf>, 
 System.Numerics.INumber<TSelf>, System.Numerics.INumberBase<TSelf>, System.Numerics.IShiftOperators<TSelf,int,TSelf>, System.Numerics.ISubtractionOperators<TSelf,TSelf,TSelf>, System.Numerics.IUnaryNegationOperators<TSelf,TSelf>, System.Numerics.IUnaryPlusOperators<TSelf,TSelf> where TSelf : IBinaryInteger<TSelf>

Methods:
--------
CompareTo(Object)	- Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.(Inherited from IComparable)
CompareTo(T)	- Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.(Inherited from IComparable<T>)
DivRem(TSelf, TSelf) - Computes the quotient and remainder of two values.
    public static virtual(TSelf Quotient, TSelf Remainder) DivRem(TSelf left, TSelf right);

Equals(T)	- Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
GetByteCount()	- Gets the number of bytes that will be written as part of TryWriteLittleEndian(Span<Byte>, Int32).
    public int GetByteCount();

GetShortestBitLength()	- Gets the length, in bits, of the shortest two's complement representation of the current value.
    public int GetShortestBitLength();

LeadingZeroCount(TSelf)	- Computes the number of leading zero bits in a value.
    public static virtual TSelf LeadingZeroCount(TSelf value);

PopCount(TSelf)	- Computes the number of bits that are set in a value.
    public static abstract TSelf PopCount(TSelf value);

ReadBigEndian(Byte[], Boolean)	- Reads a two's complement number from a given array, in big-endian format, and converts it to an instance of the current type.
    public static virtual TSelf ReadBigEndian(byte[] source, bool isUnsigned);

ReadBigEndian(Byte[], Int32, Boolean)	- Reads a two's complement number from a given array, in big-endian format, and converts it to an instance of the current type.
ReadBigEndian(ReadOnlySpan<Byte>, Boolean)	- Reads a two's complement number from a given span, in big-endian format, and converts it to an instance of the current type.
ReadLittleEndian(Byte[], Boolean)	- Reads a two's complement number from a given array, in little-endian format, and converts it to an instance of the current type.
    public static virtual TSelf ReadLittleEndian(byte[] source, bool isUnsigned);

ReadLittleEndian(Byte[], Int32, Boolean)	- Reads a two's complement number from a given array, in little-endian format, and converts it to an instance of the current type.
ReadLittleEndian(ReadOnlySpan<Byte>, Boolean)	- Reads a two's complement number from a given span, in little-endian format, and converts it to an instance of the current type.
RotateLeft(TSelf, Int32)	 - Rotates a value left by a given amount.
    public static virtual TSelf RotateLeft(TSelf value, int rotateAmount);

RotateRight(TSelf, Int32)	- Rotates a value right by a given amount.
    public static virtual TSelf RotateRight(TSelf value, int rotateAmount);

ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
TrailingZeroCount(TSelf) - Computes the number of trailing zero bits in a value.
    public static virtual TSelf RotateRight(TSelf value, int rotateAmount);
    
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)
TryReadBigEndian(ReadOnlySpan<Byte>, Boolean, TSelf)	- Tries to read a two's complement number from a span, in big-endian format, and convert it to an instance of the current type.
TryReadLittleEndian(ReadOnlySpan<Byte>, Boolean, TSelf)	- Tries to read a two's complement number from a span, in little-endian format, and convert it to an instance of the current type.
TryWriteBigEndian(Span<Byte>, Int32)	- Tries to write the current value, in big-endian format, to a given span.
TryWriteLittleEndian(Span<Byte>, Int32)	- Tries to write the current value, in little-endian format, to a given span.
WriteBigEndian(Byte[], Int32)	- Writes the current value, in big-endian format, to a given array.
WriteBigEndian(Byte[])	- Writes the current value, in big-endian format, to a given array.
WriteBigEndian(Span<Byte>)	- Writes the current value, in big-endian format, to a given span.
WriteLittleEndian(Byte[], Int32)	- Writes the current value, in little-endian format, to a specified array starting at a specified index.
WriteLittleEndian(Byte[])	- Writes the current value, in little-endian format, to a given array.
WriteLittleEndian(Span<Byte>)	- Writes the current value, in little-endian format, to a given span.



**/
namespace NumericsInterfaces{
    class IBinaryIntegerClass{
        public static void Main(){
            Console.WriteLine("IBinary Integers");
        }
    }
}