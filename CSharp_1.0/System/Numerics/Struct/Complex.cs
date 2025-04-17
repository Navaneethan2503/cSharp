using System;
using System.Numerics;
/**
The Complex struct in the System.Numerics namespace provides support for complex numbers in .NET. Complex numbers are numbers that have both a real part and an imaginary part, and are typically written in the form 
a+bi a+bi, where a a is the real part and b b is the imaginary part.

Key Features of Complex:
-----------------------
Representation: The Complex struct represents complex numbers with two double-precision floating-point values: one for the real part and one for the imaginary part.
Mathematical Operations: It supports a wide range of mathematical operations, including addition, subtraction, multiplication, division, and complex conjugation.
Properties: It provides properties to access the real and imaginary parts, as well as the magnitude and phase of the complex number.

public readonly struct Complex : IEquatable<System.Numerics.Complex>, IParsable<System.Numerics.Complex>, ISpanParsable<System.Numerics.Complex>, IUtf8SpanParsable<System.Numerics.Complex>, System.Numerics.IAdditionOperators<System.Numerics.Complex,System.Numerics.Complex,System.Numerics.Complex>, System.Numerics.IAdditiveIdentity<System.Numerics.Complex,System.Numerics.Complex>, System.Numerics.IDecrementOperators<System.Numerics.Complex>, 
System.Numerics.IDivisionOperators<System.Numerics.Complex,System.Numerics.Complex,System.Numerics.Complex>, System.Numerics.IEqualityOperators<System.Numerics.Complex,System.Numerics.Complex,bool>, System.Numerics.IIncrementOperators<System.Numerics.Complex>, System.Numerics.IMultiplicativeIdentity<System.Numerics.Complex,System.Numerics.Complex>, System.Numerics.IMultiplyOperators<System.Numerics.Complex,System.Numerics.Complex,System.Numerics.Complex>,
System.Numerics.INumberBase<System.Numerics.Complex>, System.Numerics.ISignedNumber<System.Numerics.Complex>, System.Numerics.ISubtractionOperators<System.Numerics.Complex,System.Numerics.Complex,System.Numerics.Complex>, System.Numerics.IUnaryNegationOperators<System.Numerics.Complex,System.Numerics.Complex>, System.Numerics.IUnaryPlusOperators<System.Numerics.Complex,System.Numerics.Complex>

Methods: It includes methods for common complex number operations, such as calculating the magnitude, phase, conjugate, and various trigonometric functions.

Constructors
Complex(double real, double imaginary): Initializes a new instance of the Complex struct with the specified real and imaginary parts.

Properties
Real: Gets the real part of the complex number.
Imaginary: Gets the imaginary part of the complex number.
Magnitude: Gets the magnitude (absolute value) of the complex number.
Phase: Gets the phase (angle) of the complex number.

Methods
Arithmetic Operations: Add, Subtract, Multiply, Divide
Complex Conjugate: Conjugate
Magnitude and Phase: Abs, Phase
Trigonometric Functions: Sin, Cos, Tan, Sinh, Cosh, Tanh
Exponential and Logarithmic Functions: Exp, Log

**/
namespace NumericsInterfaces{
    class ComplexClass{
        public static void Main(){
            Console.WriteLine("Complex ");
            Complex complex1 = new Complex(3, 4); // 3 + 4i
            Complex complex2 = new Complex(1, 2); // 1 + 2i

            Complex sum = Complex.Add(complex1, complex2); // (3 + 1) + (4 + 2)i = 4 + 6i
            Complex difference = Complex.Subtract(complex1, complex2); // (3 - 1) + (4 - 2)i = 2 + 2i
            Complex product = Complex.Multiply(complex1, complex2); // (3*1 - 4*2) + (3*2 + 4*1)i = -5 + 10i
            Complex quotient = Complex.Divide(complex1, complex2); // ((3*1 + 4*2) / (1^2 + 2^2)) + ((4*1 - 3*2) / (1^2 + 2^2))i = 2.2 + 0.4i

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Quotient: {quotient}");

            Complex complex = new Complex(3, 4); // 3 + 4i

            double magnitude = complex.Magnitude; // sqrt(3^2 + 4^2) = 5
            double phase = complex.Phase; // atan2(4, 3) = 0.927 radians

            Console.WriteLine($"Magnitude: {magnitude}");
            Console.WriteLine($"Phase: {phase}");

        }
    }
}
