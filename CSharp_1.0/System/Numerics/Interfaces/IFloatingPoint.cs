using System;
using System.Numerics;
/**
Defines a floating-point type.

public interface IFloatingPoint<TSelf> : IComparable<TSelf>, IEquatable<TSelf>, IParsable<TSelf>, ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>, System.Numerics.IAdditionOperators<TSelf,TSelf,TSelf>, System.Numerics.IAdditiveIdentity<TSelf,TSelf>, System.Numerics.IComparisonOperators<TSelf,TSelf,bool>, System.Numerics.IDecrementOperators<TSelf>, System.Numerics.IDivisionOperators<TSelf,TSelf,TSelf>, System.Numerics.IEqualityOperators<TSelf,TSelf,bool>, System.Numerics.IFloatingPointConstants<TSelf>, 
System.Numerics.IIncrementOperators<TSelf>, System.Numerics.IModulusOperators<TSelf,TSelf,TSelf>, System.Numerics.IMultiplicativeIdentity<TSelf,TSelf>, System.Numerics.IMultiplyOperators<TSelf,TSelf,TSelf>, System.Numerics.INumber<TSelf>, System.Numerics.INumberBase<TSelf>, System.Numerics.ISignedNumber<TSelf>, System.Numerics.ISubtractionOperators<TSelf,TSelf,TSelf>, System.Numerics.IUnaryNegationOperators<TSelf,TSelf>, System.Numerics.IUnaryPlusOperators<TSelf,TSelf> where TSelf : IFloatingPoint<TSelf>

Methods:
--------
Ceiling(TSelf) - Computes the ceiling of a value.
    public static virtual TSelf Ceiling(TSelf x);

CompareTo(Object)	- Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.(Inherited from IComparable)
CompareTo(T)	- Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.(Inherited from IComparable<T>)
ConvertToInteger<TInteger>(TSelf)	- Converts a value to a specified integer type using saturation on overflow
    public static virtual TInteger ConvertToInteger<TInteger>(TSelf value) where TInteger : System.Numerics.IBinaryInteger<TInteger>;

ConvertToIntegerNative<TInteger>(TSelf)	 - Converts a value to a specified integer type using platform specific behavior on overflow.
Equals(T)	- Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
Floor(TSelf)	- Computes the floor of a value.
    public static virtual TSelf Floor(TSelf x);

GetExponentByteCount()	- Gets the number of bytes that will be written as part of TryWriteExponentLittleEndian(Span<Byte>, Int32).
    public int GetExponentByteCount();

GetExponentShortestBitLength()	- Gets the length, in bits, of the shortest two's complement representation of the current exponent.
    public int GetExponentByteCount();
    The length, in bits, of the shortest two's complement representation of the current exponent.

GetSignificandBitLength()	- Gets the length, in bits, of the current significand.
    public int GetSignificandBitLength();

GetSignificandByteCount()	- Gets the number of bytes that will be written as part of TryWriteSignificandLittleEndian(Span<Byte>, Int32).
    public int GetSignificandByteCount();

Round(TSelf, Int32, MidpointRounding)	- Rounds a value to a specified number of fractional digits using the specified rounding mode.
Round(TSelf, Int32)	- Rounds a value to a specified number of fractional-digits using the default rounding mode (ToEven).
    public static virtual TSelf Round(TSelf x, MidpointRounding mode);

Round(TSelf, MidpointRounding)	- Rounds a value to the nearest integer using the specified rounding mode.
    public static abstract TSelf Round(TSelf x, int digits, MidpointRounding mode);

Round(TSelf)	- Rounds a value to the nearest integer using the default rounding mode (ToEven).
    public static virtual TSelf Round(TSelf x);

ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
Truncate(TSelf)	- Truncates a value.
    public static virtual TSelf Round(TSelf x, MidpointRounding mode);
    
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)
TryWriteExponentBigEndian(Span<Byte>, Int32)	- Tries to write the current exponent, in big-endian format, to a given span.
TryWriteExponentLittleEndian(Span<Byte>, Int32)	- Tries to write the current exponent, in little-endian format, to a given span.
TryWriteSignificandBigEndian(Span<Byte>, Int32)	- Tries to write the current significand, in big-endian format, to a given span.
TryWriteSignificandLittleEndian(Span<Byte>, Int32)	- Tries to write the current significand, in little-endian format, to a given span.
WriteExponentBigEndian(Byte[], Int32)	- Writes the current exponent, in big-endian format, to a given array.
WriteExponentBigEndian(Byte[])	- Writes the current exponent, in big-endian format, to a given array.
WriteExponentBigEndian(Span<Byte>)	- Writes the current exponent, in big-endian format, to a given span.
WriteExponentLittleEndian(Byte[], Int32)	- Writes the current exponent, in little-endian format, to a given array.
WriteExponentLittleEndian(Byte[])	- Writes the current exponent, in little-endian format, to a given array.
WriteExponentLittleEndian(Span<Byte>)	- Writes the current exponent, in little-endian format, to a given span.
WriteSignificandBigEndian(Byte[], Int32)	- Writes the current significand, in big-endian format, to a given array.
WriteSignificandBigEndian(Byte[])	- Writes the current significand, in big-endian format, to a given array.
WriteSignificandBigEndian(Span<Byte>)	- Writes the current significand, in big-endian format, to a given span.
WriteSignificandLittleEndian(Byte[], Int32)	- Writes the current significand, in little-endian format, to a given array.
WriteSignificandLittleEndian(Byte[])	- Writes the current significand, in little-endian format, to a given array.
WriteSignificandLittleEndian(Span<Byte>)	- Writes the current significand, in little-endian format, to a given span.


**/
namespace NumericsInterfaces{
    class IFloatingPointClass{
        public static void Main(){
            Console.WriteLine("IFloating Point Interface.");
        }
    }
}