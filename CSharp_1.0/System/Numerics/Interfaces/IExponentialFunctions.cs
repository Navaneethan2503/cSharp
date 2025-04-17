using System;
using System.Numerics;
/**

Methods:
-------
Equals(T) - Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
Exp(TSelf) - Computes E raised to a given power.
    public static abstract TSelf Exp(TSelf x);

Exp10(TSelf)	- Computes 10 raised to a given power.
    public static abstract TSelf Exp10(TSelf x);
    
Exp10M1(TSelf)	- Computes 10 raised to a given power and subtracts one.
Exp2(TSelf)	- Computes 2 raised to a given power.
    public static abstract TSelf Exp2(TSelf x);

Exp2M1(TSelf)	- Computes 2 raised to a given power and subtracts one.
ExpM1(TSelf)	- Computes E raised to a given power and subtracts one.
ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)



**/
namespace NumericsInterfaces{
    class IExponentialFunctionsClass{
        public static void Main(){
            Console.WriteLine("IExponentialFunctions");
        }
    }
}