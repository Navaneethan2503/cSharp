using System;
using System.Numerics;
/**
The BigInteger structure, which is a nonprimitive integral type that supports arbitrarily large integers. An integral primitive such as Byte or Int32 includes a MinValue and a MaxValue property, which define the lower bound and upper bound supported by that data type. In contrast, the BigInteger structure has no lower or upper bound, and can contain the value of any integer.

The BigInteger struct in the System.Numerics namespace is a part of the .NET framework that provides support for arbitrary-precision integers. 
Unlike the standard integer types (int, long, etc.), which have fixed sizes and ranges, BigInteger can represent very large or very small numbers without any fixed upper or lower bounds, limited only by the available system memory.

Key Features of BigInteger:
--------------------------
Arbitrary Precision: BigInteger can handle numbers of any size, making it suitable for applications that require very large integers, such as cryptography, scientific computations, and financial calculations.
Mathematical Operations: It supports all standard arithmetic operations (addition, subtraction, multiplication, division), as well as bitwise operations, comparisons, and other mathematical functions.
Integration with .NET: BigInteger integrates seamlessly with other .NET types and libraries, allowing for easy conversion and interoperability.

public readonly struct BigInteger : IComparable<System.Numerics.BigInteger>, IEquatable<System.Numerics.BigInteger>, IParsable<System.Numerics.BigInteger>, ISpanParsable<System.Numerics.BigInteger>, IUtf8SpanParsable<System.Numerics.BigInteger>, System.Numerics.IAdditionOperators<System.Numerics.BigInteger,System.Numerics.BigInteger,System.Numerics.BigInteger>, System.Numerics.IAdditiveIdentity<System.Numerics.BigInteger,
System.Numerics.BigInteger>, System.Numerics.IBinaryInteger<System.Numerics.BigInteger>, System.Numerics.IBinaryNumber<System.Numerics.BigInteger>, System.Numerics.IBitwiseOperators<System.Numerics.BigInteger,System.Numerics.BigInteger,System.Numerics.BigInteger>, System.Numerics.IComparisonOperators<System.Numerics.BigInteger,System.Numerics.BigInteger,bool>, System.Numerics.IDecrementOperators<System.Numerics.BigInteger>, 
System.Numerics.IDivisionOperators<System.Numerics.BigInteger,System.Numerics.BigInteger,System.Numerics.BigInteger>, System.Numerics.IEqualityOperators<System.Numerics.BigInteger,System.Numerics.BigInteger,bool>, System.Numerics.IIncrementOperators<System.Numerics.BigInteger>, System.Numerics.IModulusOperators<System.Numerics.BigInteger,System.Numerics.BigInteger,System.Numerics.BigInteger>, System.Numerics.IMultiplicativeIdentity<System.Numerics.BigInteger,
System.Numerics.BigInteger>, System.Numerics.IMultiplyOperators<System.Numerics.BigInteger,System.Numerics.BigInteger,System.Numerics.BigInteger>, System.Numerics.INumber<System.Numerics.BigInteger>, System.Numerics.INumberBase<System.Numerics.BigInteger>, System.Numerics.IShiftOperators<System.Numerics.BigInteger,int,System.Numerics.BigInteger>, System.Numerics.ISignedNumber<System.Numerics.BigInteger>, System.Numerics.ISubtractionOperators<System.Numerics.BigInteger,
System.Numerics.BigInteger,System.Numerics.BigInteger>, System.Numerics.IUnaryNegationOperators<System.Numerics.BigInteger,System.Numerics.BigInteger>, System.Numerics.IUnaryPlusOperators<System.Numerics.BigInteger,System.Numerics.BigInteger>

Constructors:
------------
BigInteger(byte[]): Initializes a new instance of the BigInteger structure using a byte array.
BigInteger(decimal): Initializes a new instance of the BigInteger structure using a decimal value.
BigInteger(double): Initializes a new instance of the BigInteger structure using a double value.
BigInteger(int): Initializes a new instance of the BigInteger structure using an int value.
BigInteger(long): Initializes a new instance of the BigInteger structure using a long value.
BigInteger(uint): Initializes a new instance of the BigInteger structure using a uint value.
BigInteger(ulong): Initializes a new instance of the BigInteger structure using a ulong value.
BigInteger(string): Initializes a new instance of the BigInteger structure using a string representation of a number.


Properties:
----------
IsEven: Gets a value that indicates whether the current BigInteger value is even.
IsOne: Gets a value that indicates whether the current BigInteger value is one.
IsPowerOfTwo: Gets a value that indicates whether the current BigInteger value is a power of two.
IsZero: Gets a value that indicates whether the current BigInteger value is zero.
Sign: Gets a value that indicates the sign of the current BigInteger value.


Methods:
--------
Arithmetic Operations: Add, Subtract, Multiply, Divide, Remainder, Negate, Abs
Bitwise Operations: And, Or, Xor, Not, LeftShift, RightShift
Comparison Operations: CompareTo, Equals
Conversion Methods: ToByteArray, ToString, Parse, TryParse
Other Methods: GreatestCommonDivisor, ModPow, ModInverse, Pow

**/
namespace NumericsInterfaces{
    class BigIntegerClass{
        public static void Main(){
            Console.WriteLine("BigInteger");
            BigInteger bigInt1 = new BigInteger(12345678901234567890);
            BigInteger bigInt2 = new BigInteger(9876543210987654328);

            BigInteger sum = BigInteger.Add(bigInt1, bigInt2);
            BigInteger difference = BigInteger.Subtract(bigInt1, bigInt2);
            BigInteger product = BigInteger.Multiply(bigInt1, bigInt2);
            BigInteger quotient = BigInteger.Divide(bigInt2, bigInt1);
            BigInteger remainder = BigInteger.Remainder(bigInt2, bigInt1);

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Quotient: {quotient}");
            Console.WriteLine($"Remainder: {remainder}");

            string numberStr = "123456789012345678901234567890";
            BigInteger bigInt = BigInteger.Parse(numberStr);

            byte[] byteArray = bigInt.ToByteArray();
            string hexString = bigInt.ToString("X");

            Console.WriteLine($"BigInteger: {bigInt}");
            Console.WriteLine($"Byte Array: {BitConverter.ToString(byteArray)}");
            Console.WriteLine($"Hex String: {hexString}");
        }
    }
}


