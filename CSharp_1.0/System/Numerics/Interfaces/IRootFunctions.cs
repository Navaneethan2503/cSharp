using System;
using System.Numerics;
/**

Defines support for root functions.

public interface IRootFunctions<TSelf> : IEquatable<TSelf>, IParsable<TSelf>, ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>, 
System.Numerics.IAdditionOperators<TSelf,TSelf,TSelf>, System.Numerics.IAdditiveIdentity<TSelf,TSelf>, System.Numerics.IDecrementOperators<TSelf>, System.Numerics.IDivisionOperators<TSelf,TSelf,TSelf>, System.Numerics.IEqualityOperators<TSelf,TSelf,bool>, 
System.Numerics.IFloatingPointConstants<TSelf>, System.Numerics.IIncrementOperators<TSelf>, System.Numerics.IMultiplicativeIdentity<TSelf,TSelf>, System.Numerics.IMultiplyOperators<TSelf,TSelf,TSelf>, System.Numerics.INumberBase<TSelf>, System.Numerics.ISubtractionOperators<TSelf,TSelf,TSelf>, System.Numerics.IUnaryNegationOperators<TSelf,TSelf>, System.Numerics.IUnaryPlusOperators<TSelf,TSelf> where TSelf : IRootFunctions<TSelf>


Methods:
--------
Cbrt(TSelf)	- Computes the cube-root of a value.
    public static abstract TSelf Cbrt(TSelf x);

Equals(T) - Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
Hypot(TSelf, TSelf)	- Computes the hypotenuse given two values representing the lengths of the shorter sides in a right-angled triangle.
    public static abstract TSelf Hypot(TSelf x, TSelf y);

RootN(TSelf, Int32)	- Computes the n-th root of a value.
    public static abstract TSelf RootN(TSelf x, int n);

Sqrt(TSelf)	- Computes the square-root of a value.
    public static abstract TSelf Sqrt(TSelf x);
    
ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)


**/
namespace NumericsInterfaces{
    class IRootFunctionsClass{
        public static void Main(){
            Console.WriteLine("IRootFunctions");
        }
    }
}