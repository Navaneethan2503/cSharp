using System;
using System.Numerics;

/**
Defines support for floating-point constants.

public interface IFloatingPointConstants<TSelf> : IEquatable<TSelf>, IParsable<TSelf>, ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>, System.Numerics.IAdditionOperators<TSelf,TSelf,TSelf>, System.Numerics.IAdditiveIdentity<TSelf,TSelf>, System.Numerics.IDecrementOperators<TSelf>, System.Numerics.IDivisionOperators<TSelf,TSelf,TSelf>, System.Numerics.IEqualityOperators<TSelf,TSelf,bool>, System.Numerics.IIncrementOperators<TSelf>, System.Numerics.IMultiplicativeIdentity<TSelf,TSelf>, 
System.Numerics.IMultiplyOperators<TSelf,TSelf,TSelf>, System.Numerics.INumberBase<TSelf>, System.Numerics.ISubtractionOperators<TSelf,TSelf,TSelf>, System.Numerics.IUnaryNegationOperators<TSelf,TSelf>, System.Numerics.IUnaryPlusOperators<TSelf,TSelf> where TSelf : IFloatingPointConstants<TSelf>

Properties:
-----------
E	- Gets the mathematical constant e.
    public static abstract TSelf E { get; }
Pi	- Gets the mathematical constant pi.
    public static abstract TSelf Pi { get; }

Tau	- Gets the mathematical constant tau.
    public static abstract TSelf Tau { get; }
    

**/
namespace NumericsInterfaces{
    class IFloatingPointConstantsClass{
        public static void Main(){
            Console.WriteLine("IFloating Point Constant");
        }
    }
}