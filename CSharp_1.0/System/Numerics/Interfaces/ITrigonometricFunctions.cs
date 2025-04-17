using System;
using System.Numerics;
/**
Defines support for trigonometric functions.

public interface ITrigonometricFunctions<TSelf> : IEquatable<TSelf>, IParsable<TSelf>, ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>, System.Numerics.IAdditionOperators<TSelf,TSelf,TSelf>, System.Numerics.IAdditiveIdentity<TSelf,TSelf>, System.Numerics.IDecrementOperators<TSelf>, System.Numerics.IDivisionOperators<TSelf,TSelf,TSelf>, System.Numerics.IEqualityOperators<TSelf,TSelf,bool>, System.Numerics.IFloatingPointConstants<TSelf>, System.Numerics.IIncrementOperators<TSelf>, System.Numerics.IMultiplicativeIdentity<TSelf,TSelf>, System.Numerics.IMultiplyOperators<TSelf,TSelf,TSelf>, 
System.Numerics.INumberBase<TSelf>, System.Numerics.ISubtractionOperators<TSelf,TSelf,TSelf>, System.Numerics.IUnaryNegationOperators<TSelf,TSelf>, System.Numerics.IUnaryPlusOperators<TSelf,TSelf> where TSelf : ITrigonometricFunctions<TSelf>

Methods:
----------
Acos(TSelf)	- Computes the arc-cosine of a value.
    public static abstract TSelf Acos(TSelf x);
    This computes arccos(x) in the interval [+0, +π] radians.

AcosPi(TSelf)	- Computes the arc-cosine of a value and divides the result by pi.
    public static abstract TSelf AcosPi(TSelf x);
    This computes arccos(x) / π in the interval [-0.5, +0.5].

Asin(TSelf)	- Computes the arc-sine of a value.
    public static abstract TSelf Asin(TSelf x);
    This computes arcsin(x) in the interval [-π / 2, +π / 2] radians.

AsinPi(TSelf)	- Computes the arc-sine of a value and divides the result by pi.
    public static abstract TSelf AsinPi(TSelf x);
    This computes arcsin(x) / π in the interval [-0.5, +0.5].
    
Atan(TSelf)	- Computes the arc-tangent of a value.
    public static abstract TSelf Atan(TSelf x);
    This computes arctan(x) in the interval [-π / 2, +π / 2] radians.

AtanPi(TSelf)	- Computes the arc-tangent of a value and divides the result by pi.
    public static abstract TSelf AtanPi(TSelf x);
    This computes arctan(x) / π in the interval [-0.5, +0.5].

Cos(TSelf)	- Computes the cosine of a value.
    public static abstract TSelf Cos(TSelf x);

CosPi(TSelf)	- Computes the cosine of a value that has been multipled by pi.
    public static abstract TSelf CosPi(TSelf x);
    This computes cos(x * π).

DegreesToRadians(TSelf)	- Converts a given value from degrees to radians.
    public static virtual TSelf DegreesToRadians(TSelf degrees);
    The value of degrees converted to radians.

Equals(T)	- Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
RadiansToDegrees(TSelf)	- Converts a given value from radians to degrees.
    public static virtual TSelf RadiansToDegrees(TSelf radians);

Sin(TSelf)	- Computes the sine of a value.
    public static abstract TSelf Sin(TSelf x);

SinCos(TSelf)	- Computes the sine and cosine of a value.
    public static abstract(TSelf Sin, TSelf Cos) SinCos(TSelf x);

SinCosPi(TSelf)	- Computes the sine and cosine of a value that has been multiplied by pi.
    public static abstract(TSelf SinPi, TSelf CosPi) SinCosPi(TSelf x);
    This computes (sin(x * π), cos(x * π)).

SinPi(TSelf)	- Computes the sine of a value that has been multiplied by pi.
    public static abstract TSelf SinPi(TSelf x);
    This computes sin(x * π).

Tan(TSelf)	- Computes the tangent of a value.
    public static abstract TSelf Tan(TSelf x);
    This computes tan(x).

TanPi(TSelf)	- Computes the tangent of a value that has been multipled by pi.
    public static abstract TSelf TanPi(TSelf x);
    This computes tan(x * π).
    
ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)



**/
namespace NumericsInterfaces{
    class ITrigonometricFunctionsClass{
        public static void Main(){
            Console.WriteLine("ITrigonometricFunctions");
        }
    }
}