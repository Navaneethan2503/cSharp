using System;
using System.Numerics;
/**
Methods:
-------
Acosh(TSelf) - Computes the hyperbolic arc-cosine of a value.
    public static abstract TSelf Acosh(TSelf x);
    
Asinh(TSelf) - Computes the hyperbolic arc-sine of a value.
Atanh(TSelf)	- Computes the hyperbolic arc-tangent of a value.
Cosh(TSelf)	- Computes the hyperbolic cosine of a value.
Equals(T)	- Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
Sinh(TSelf)	- Computes the hyperbolic sine of a value.
Tanh(TSelf)	- Computes the hyperbolic tangent of a value.
ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)


**/
namespace NumericsInterfaces{
    class IHyperbolicFunctionsClass{
        public static void Main(){
            Console.WriteLine("IHyperbolicFunctions");
        }
    }
}