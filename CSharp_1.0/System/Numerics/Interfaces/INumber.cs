using System;
using System.Numerics;
/**
Defines a number type.

public interface INumber<TSelf> : IComparable, IComparable<TSelf>, IEquatable<TSelf>, IParsable<TSelf>, ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>, System.Numerics.IAdditionOperators<TSelf,TSelf,TSelf>, 
System.Numerics.IAdditiveIdentity<TSelf,TSelf>, System.Numerics.IComparisonOperators<TSelf,TSelf,bool>, System.Numerics.IDecrementOperators<TSelf>, System.Numerics.IDivisionOperators<TSelf,TSelf,TSelf>, 
System.Numerics.IEqualityOperators<TSelf,TSelf,bool>, System.Numerics.IIncrementOperators<TSelf>, System.Numerics.IModulusOperators<TSelf,TSelf,TSelf>, System.Numerics.IMultiplicativeIdentity<TSelf,TSelf>, 
System.Numerics.IMultiplyOperators<TSelf,TSelf,TSelf>, System.Numerics.INumberBase<TSelf>, System.Numerics.ISubtractionOperators<TSelf,TSelf,TSelf>, System.Numerics.IUnaryNegationOperators<TSelf,TSelf>, 
System.Numerics.IUnaryPlusOperators<TSelf,TSelf> where TSelf : INumber<TSelf>

Methods:
--------
Clamp(TSelf, TSelf, TSelf) - Clamps a value to an inclusive minimum and maximum value.
    public static virtual TSelf Clamp(TSelf value, TSelf min, TSelf max);
    The result of clamping value to the inclusive range of min and max.

CompareTo(Object) - Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.(Inherited from IComparable)

CompareTo(T) - Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.(Inherited from IComparable<T>)
    
CopySign(TSelf, TSelf)	- Copies the sign of a value to the sign of another value.
    public static virtual TSelf CopySign(TSelf value, TSelf sign);

Equals(T)	- Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
Max(TSelf, TSelf) - Compares two values to compute which is greater.
MaxNumber(TSelf, TSelf)	 - Compares two values to compute which is greater and returning the other value if an input is NaN.
    public static virtual TSelf MaxNumber(TSelf x, TSelf y);
    For IFloatingPoint<TSelf> this method matches the IEEE 754:2019 maximumNumber function. This requires NaN inputs to not be propagated back to the caller and for -0.0 to be treated as less than +0.0.

Min(TSelf, TSelf)	- Compares two values to compute which is lesser.
    public static virtual TSelf Min(TSelf x, TSelf y);

MinNumber(TSelf, TSelf)	- Compares two values to compute which is lesser and returning the other value if an input is NaN.
    public static virtual TSelf MinNumber(TSelf x, TSelf y);

Sign(TSelf)	- Computes the sign of a value.
    public static virtual int Sign(TSelf value);

ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)



**/
namespace INumberInterface{
    class INumberClass {
        public static void Main(){
            Console.WriteLine("INumber Interface.");
        }
    }
}