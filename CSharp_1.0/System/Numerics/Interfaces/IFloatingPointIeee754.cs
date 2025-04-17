using System;
using System.Numerics;
/**

Properties:
-----------
Epsilon	- Gets the smallest value such that can be added to 0 that does not result in 0.
    public static abstract TSelf Epsilon { get; }

NaN	- Gets a value that represents NaN.
NegativeInfinity	- Gets a value that represents negative infinity.
NegativeZero	- Gets a value that represents negative zero.
PositiveInfinity	- Gets a value that represents positive infinity.

Methods:
--------
Atan2(TSelf, TSelf)	- Computes the arc-tangent for the quotient of two values.
Atan2Pi(TSelf, TSelf)	- Computes the arc-tangent for the quotient of two values and divides the result by pi.
BitDecrement(TSelf)	- Returns the largest value that compares less than a specified value.
    public static abstract TSelf BitDecrement(TSelf x);
    
BitIncrement(TSelf)	- Returns the smallest value that compares greater than a specified value.
CompareTo(Object)	- Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.(Inherited from IComparable)
CompareTo(T)	- Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.(Inherited from IComparable<T>)
Equals(T)	- Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
FusedMultiplyAdd(TSelf, TSelf, TSelf)	- Computes the fused multiply-add of three values.
GetExponentByteCount()	- Gets the number of bytes that will be written as part of TryWriteExponentLittleEndian(Span<Byte>, Int32).(Inherited from IFloatingPoint<TSelf>)
GetExponentShortestBitLength()	- Gets the length, in bits, of the shortest two's complement representation of the current exponent.(Inherited from IFloatingPoint<TSelf>)
GetSignificandBitLength()	- Gets the length, in bits, of the current significand.(Inherited from IFloatingPoint<TSelf>)
GetSignificandByteCount()	- Gets the number of bytes that will be written as part of TryWriteSignificandLittleEndian(Span<Byte>, Int32).(Inherited from IFloatingPoint<TSelf>)
Ieee754Remainder(TSelf, TSelf)	- Computes the remainder of two values as specified by IEEE 754.
ILogB(TSelf)	 - Computes the integer logarithm of a value.
Lerp(TSelf, TSelf, TSelf)	- Performs a linear interpolation between two values based on the given weight.
ReciprocalEstimate(TSelf)	- Computes an estimate of the reciprocal of a value.
ReciprocalSqrtEstimate(TSelf)	- Computes an estimate of the reciprocal square root of a value.
ScaleB(TSelf, Int32)	- Computes the product of a value and its base-radix raised to the specified power.
ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)
TryWriteExponentBigEndian(Span<Byte>, Int32)	- Tries to write the current exponent, in big-endian format, to a given span.(Inherited from IFloatingPoint<TSelf>)
TryWriteExponentLittleEndian(Span<Byte>, Int32)	- Tries to write the current exponent, in little-endian format, to a given span.(Inherited from IFloatingPoint<TSelf>)
TryWriteSignificandBigEndian(Span<Byte>, Int32)	- Tries to write the current significand, in big-endian format, to a given span.(Inherited from IFloatingPoint<TSelf>)
TryWriteSignificandLittleEndian(Span<Byte>, Int32)	- Tries to write the current significand, in little-endian format, to a given span.(Inherited from IFloatingPoint<TSelf>)
WriteExponentBigEndian(Byte[], Int32)	- Writes the current exponent, in big-endian format, to a given array.(Inherited from IFloatingPoint<TSelf>)
WriteExponentBigEndian(Byte[])	- Writes the current exponent, in big-endian format, to a given array.(Inherited from IFloatingPoint<TSelf>)
WriteExponentBigEndian(Span<Byte>)	- Writes the current exponent, in big-endian format, to a given span.(Inherited from IFloatingPoint<TSelf>)
WriteExponentLittleEndian(Byte[], Int32)	- Writes the current exponent, in little-endian format, to a given array.(Inherited from IFloatingPoint<TSelf>)
WriteExponentLittleEndian(Byte[])	- Writes the current exponent, in little-endian format, to a given array.(Inherited from IFloatingPoint<TSelf>)
WriteExponentLittleEndian(Span<Byte>)	- Writes the current exponent, in little-endian format, to a given span.(Inherited from IFloatingPoint<TSelf>)
WriteSignificandBigEndian(Byte[], Int32)	- Writes the current significand, in big-endian format, to a given array.(Inherited from IFloatingPoint<TSelf>)
WriteSignificandBigEndian(Byte[])	- Writes the current significand, in big-endian format, to a given array.(Inherited from IFloatingPoint<TSelf>)
WriteSignificandBigEndian(Span<Byte>)	- Writes the current significand, in big-endian format, to a given span.(Inherited from IFloatingPoint<TSelf>)
WriteSignificandLittleEndian(Byte[], Int32)	- Writes the current significand, in little-endian format, to a given array.(Inherited from IFloatingPoint<TSelf>)
WriteSignificandLittleEndian(Byte[])	- Writes the current significand, in little-endian format, to a given array.(Inherited from IFloatingPoint<TSelf>)
WriteSignificandLittleEndian(Span<Byte>)	- Writes the current significand, in little-endian format, to a given span.(Inherited from IFloatingPoint<TSelf>)

**/
namespace NumericsInterfaces{
    class IFloatingPointIeee754Class{
        public static void Main(){
            Console.WriteLine("IFloatingPointIeee754");
        }
    }
}