using System;
using System.Numerics;
/**
Defines support for logarithmic functions.

public interface ILogarithmicFunctions<TSelf> : IEquatable<TSelf>, IParsable<TSelf>, ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>, System.Numerics.IAdditionOperators<TSelf,TSelf,TSelf>, 
System.Numerics.IAdditiveIdentity<TSelf,TSelf>, System.Numerics.IDecrementOperators<TSelf>, System.Numerics.IDivisionOperators<TSelf,TSelf,TSelf>, System.Numerics.IEqualityOperators<TSelf,TSelf,bool>, System.Numerics.IFloatingPointConstants<TSelf>, System.Numerics.IIncrementOperators<TSelf>, System.Numerics.IMultiplicativeIdentity<TSelf,TSelf>, System.Numerics.IMultiplyOperators<TSelf,TSelf,TSelf>, System.Numerics.INumberBase<TSelf>, System.Numerics.ISubtractionOperators<TSelf,TSelf,TSelf>, System.Numerics.IUnaryNegationOperators<TSelf,TSelf>, System.Numerics.IUnaryPlusOperators<TSelf,TSelf> where TSelf : ILogarithmicFunctions<TSelf>

Methods:
--------
Equals(T)	- Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
Log(TSelf, TSelf)	- Computes the logarithm of a value in the specified base.
    public static abstract TSelf Log(TSelf x, TSelf newBase);
    The base-newBase logarithm of x.

Log(TSelf)	- Computes the natural (base-E logarithm of a value.
    public static abstract TSelf Log(TSelf x);

Log10(TSelf)	- Computes the base-10 logarithm of a value.
    public static abstract TSelf Log10(TSelf x);

Log10P1(TSelf)	- Computes the base-10 logarithm of a value plus one.
    public static virtual TSelf Log10P1(TSelf x);
    log10(x + 1)

Log2(TSelf)	- Computes the base-2 logarithm of a value.
    public static abstract TSelf Log2(TSelf x);

Log2P1(TSelf)	 - Computes the base-2 logarithm of a value plus one.
    public static virtual TSelf Log2P1(TSelf x);
    log2(x + 1)

LogP1(TSelf)	- Computes the natural (base-E) logarithm of a value plus one.
    public static virtual TSelf LogP1(TSelf x);
    loge(x + 1)
    
ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)



**/
namespace NumericsInterfaces{
    class ILogarithmicFunctionsClass{
        public static void Main(){
            Console.WriteLine("ILogarithmicFunctions");
        }
    }
}