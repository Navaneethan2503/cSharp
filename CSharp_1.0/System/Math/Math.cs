using System;
/**
Math class is part of the System namespace and provides a wide range of static methods for performing mathematical operations.

Provides constants and static methods for trigonometric, logarithmic, and other common mathematical functions.

Why Math Class instead individual Data Type:
--------------------------------------------
1. Centralized Mathematical Functions
2. Consistency Across Data Types
3. Static Methods
4. Advanced Mathematical Operations
5. Performance Optimization
6. Cross-Type Operations

Fields:
----------
E - Represents the natural logarithmic base, specified by the constant, e.
    public const double E = 2.7182818284590451;

PI	- Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π.
    public const double PI = 3.1415926535897931;

Tau	- Represents the number of radians in one turn, specified by the constant, τ.
    public const double Tau = 6.2831853071795862;

Methods:
--------

Math.Abs Method:
-----------------
public static int Abs(int value)
{
    if (value < 0)
    {
        value = -value;
        if (value < 0)
        {
            ThrowNegateTwosCompOverflow();
        }
    }
    return value;
}
public static double Abs(double value)
{
    const ulong mask = 0x7FFFFFFFFFFFFFFF;
    ulong raw = BitConverter.DoubleToUInt64Bits(value);

    return BitConverter.UInt64BitsToDouble(raw & mask);
}

Abs(Decimal) - Returns the absolute value of a Decimal number.
    public static decimal Abs(decimal value);
    A decimal number, x, such that 0 ≤ x ≤ Decimal.MaxValue.
    The absolute value of a Decimal is its numeric value without its sign. For example, the absolute value of both 1.2 and -1.2 is 1.2.

Abs(Double)	- Returns the absolute value of a double-precision floating-point number.
    public static double Abs(double value);
    The absolute value of a Double is its numeric value without its sign. For example, the absolute value of both 1.2e03 and -1.2e03 is 1.2e03.
    If value is equal to NegativeInfinity or PositiveInfinity, the return value is PositiveInfinity. If value is equal to NaN, the return value is NaN.

Abs(Int16)	- Returns the absolute value of a 16-bit signed integer.
    The absolute value of an Int16 is its numeric value without its sign. For example, the absolute value of both 123 and -123 is 123.
    
Abs(Int32)	- Returns the absolute value of a 32-bit signed integer.
    public static int Abs(int value);

Abs(Int64)	- Returns the absolute value of a 64-bit signed integer.
Abs(IntPtr)	- Returns the absolute value of a native signed integer.
Abs(SByte)	- Returns the absolute value of an 8-bit signed integer.
Abs(Single)	- Returns the absolute value of a single-precision floating-point number.

----------------------------------------
Math.BigMul Method:
-------------------
BigMul(UInt64, UInt64, UInt64)	- Produces the full product of two unsigned 64-bit numbers.
    [System.CLSCompliant(false)]
    public static ulong BigMul(ulong a, ulong b, out ulong low);

BigMul(Int64, Int64, Int64)	- Produces the full product of two 64-bit numbers.
    [System.CLSCompliant(false)]
    public static ulong BigMul(ulong a, ulong b, out ulong low);

BigMul(UInt64, UInt64)	- Produces the full product of two unsigned 64-bit numbers.
BigMul(Int32, Int32)	- Produces the full product of two 32-bit numbers.
    public static long BigMul(int a, int b);

BigMul(Int64, Int64)	- Produces the full product of two 64-bit numbers.
    public static Int128 BigMul(long a, long b);

BigMul(UInt32, UInt32)	- Produces the full product of two unsigned 32-bit numbers.


----------------------------------------
Math.BitDecrement(Double) Method:
----------------------------------
These methods are used to perform bit-level operations on floating-point numbers, 
specifically to find the next representable floating-point value that is slightly smaller or larger than a given value.
BitDecrement(Double) - Returns the largest value that compares less than a specified value.
    public static double BitDecrement(double x);
    NegativeInfinity if x equals NegativeInfinity.
    NaN if x equals NaN.

BitIncrement(Double) - Returns the smallest value that compares greater than a specified value.
    public static double BitIncrement(double x);
    PositiveInfinity if x equals PositiveInfinity.
    NaN if x equals NaN.

----------------------------------------------------------------------------------------
Math.CopySign(Double, Double) Method:
-------------------------------------
CopySign(Double, Double) - Returns a value with the magnitude of x and the sign of y.
    public static double CopySign(double x, double y);

----------------------------------------------------------------------------------------
Math.DivRem Method:
-------------------
Calculates the quotient of two numbers and also returns the remainder in an output parameter.
    long Quotient = a / b;
    remainder = a - (div * b);

DivRem(Int64, Int64, Int64)	- Calculates the quotient of two 64-bit signed integers and also returns the remainder in an output parameter.
    public static long DivRem(long a, long b, out long result);

DivRem(Int32, Int32, Int32)	- Calculates the quotient of two 32-bit signed integers and also returns the remainder in an output parameter.
    public static int DivRem(int a, int b, out int result);

DivRem(UIntPtr, UIntPtr)	- Produces the quotient and the remainder of two unsigned native-size numbers.
DivRem(UInt64, UInt64)	- Produces the quotient and the remainder of two unsigned 64-bit numbers.
DivRem(UInt32, UInt32)	- Produces the quotient and the remainder of two unsigned 32-bit numbers.
DivRem(UInt16, UInt16)	- Produces the quotient and the remainder of two unsigned 16-bit numbers.
DivRem(SByte, SByte)	- Produces the quotient and the remainder of two signed 8-bit numbers.
DivRem(Int64, Int64)	- Produces the quotient and the remainder of two signed 64-bit numbers.
    public static(long Quotient, long Remainder) DivRem(long left, long right);

DivRem(Int32, Int32)	- Produces the quotient and the remainder of two signed 32-bit numbers.
    public static(int Quotient, int Remainder) DivRem(int left, int right);

DivRem(Int16, Int16)	- Produces the quotient and the remainder of two signed 16-bit numbers.
DivRem(Byte, Byte)	- Produces the quotient and the remainder of two unsigned 8-bit numbers.
DivRem(IntPtr, IntPtr)	- Produces the quotient and the remainder of two signed native-size numbers.

------------------------------------------------------------
Math.Ceiling Method:
----------------------
Returns the smallest integral value(non-floating point) greater than or equal to the specified number.
The behavior of this method follows IEEE Standard 754, section 4. This kind of rounding is sometimes called rounding toward positive infinity.
The smallest integral value that is greater than or equal to a. If a is equal to NaN, NegativeInfinity, or PositiveInfinity, that value is returned. Note that this method returns a Double instead of an integral type.
integral values means non floating point.
    Ex: 1.5 = 2, 3.2 = 4, 5.7 = 6 

Imagine a number line. The Math.Ceiling method moves to the nearest integer to the right of the specified value.
first right most integer is smallest than second right most integer.

Ceiling(Decimal) - Returns the smallest integral value that is greater than or equal to the specified decimal number.
    public static decimal Ceiling(decimal d);

Ceiling(Double)	- Returns the smallest integral value that is greater than or equal to the specified double-precision floating-point number.
    public static double Ceiling(double a);


---------------------------------------------------------------------------
Math.Clamp Method:
--------------------
The Math.Clamp method in C# is used to restrict a value to be within a specified range. 
This method ensures that the value does not exceed the given minimum and maximum bounds. 
If the value is less than the minimum, it returns the minimum; if the value is greater than the maximum, it returns the maximum; otherwise, it returns the value itself.

returns value if min ≤ value ≤ max.
        min if value < min.
        max if max < value.

Clamped value of 10 between 5 and 15 is 10
Clamped value of -3.5 between 0.0 and 10.0 is 0.0
Clamped value of 20.5 between 10.0 and 15.0 is 15.0

Clamp(Single, Single, Single) - Returns value clamped to the inclusive range of min and max.
    public static float Clamp(float value, float min, float max);

Clamp(UIntPtr, UIntPtr, UIntPtr)	- Returns value clamped to the inclusive range of min and max.
    public static UIntPtr Clamp(UIntPtr value, UIntPtr min, UIntPtr max);

Clamp(UInt64, UInt64, UInt64)	- Returns value clamped to the inclusive range of min and max.
Clamp(UInt32, UInt32, UInt32)	- Returns value clamped to the inclusive range of min and max.
Clamp(UInt16, UInt16, UInt16)	- Returns value clamped to the inclusive range of min and max.
Clamp(SByte, SByte, SByte)	- Returns value clamped to the inclusive range of min and max.
Clamp(Int32, Int32, Int32)	- Returns value clamped to the inclusive range of min and max.
    public static int Clamp(int value, int min, int max);

Clamp(Int64, Int64, Int64)	- Returns value clamped to the inclusive range of min and max.
    public static long Clamp(long value, long min, long max);

Clamp(Int16, Int16, Int16)	- Returns value clamped to the inclusive range of min and max.
Clamp(Double, Double, Double)	- Returns value clamped to the inclusive range of min and max.
Clamp(Decimal, Decimal, Decimal)	- Returns value clamped to the inclusive range of min and max.
Clamp(Byte, Byte, Byte)	- Returns value clamped to the inclusive range of min and max.
Clamp(IntPtr, IntPtr, IntPtr)	- Returns value clamped to the inclusive range of min and max.

-------------------------------------------------------------------------------------------
Math.Floor Method:
------------------
Returns the largest integral value (non floating point ) less than or equal to the specified number.
The behavior of this method follows IEEE Standard 754, section 4. This kind of rounding is sometimes called rounding toward negative infinity. In other words, if d is positive, any fractional component is truncated. 
If d is negative, the presence of any fractional component causes it to be rounded to the smaller integer. The operation of this method differs from the Ceiling method, which supports rounding toward positive infinity.
    Ex:
    4.1 = 4, 3.0 = 3, 2.5 = 2, 3.8 = 3

Imagine a number line. The Math.Floor method moves to the nearest integer to the left of the specified value.
since first left most integer is largest than second left most integer.

Floor(Decimal)	- Returns the largest integral value less than or equal to the specified decimal number.
    public static decimal Floor(decimal d);

Floor(Double)	- Returns the largest integral value less than or equal to the specified double-precision floating-point number.
    public static double Floor(double d);

--------------------------------------------------------------------------------------------------------------
Math.IEEERemainder(Double, Double) Method:
---------------------------------------------
Returns the remainder resulting from the division of a specified number by another specified number.
The IEEERemainder method is not the same as the remainder operator. Although both return the remainder after division, the formulas they use are different. The formula for the IEEERemainder method is:
IEEERemainder = dividend - (divisor * Math.Round(dividend / divisor))

public static double IEEERemainder(double x, double y);

A number equal to x - (y Q), where Q is the quotient of x / y rounded to the nearest integer (if x / y falls halfway between two integers, the even integer is returned).
If x - (y Q) is zero, the value +0 is returned if x is positive, or -0 if x is negative.
If y = 0, NaN is returned.

---------------------------------------------------------
Math.ILogB(Double) Method
-------------------------
ILogB(Double)	- Returns the base 2 integer logarithm of a specified number.
    public static int ILogB(double x);

Math.ILogB(Double) method in C# is used to compute the integer logarithm (base 2) of a specified double-precision floating-point number. 
provides a way to determine the exponent of the largest power of 2 that is less than or equal to the specified value.

Return Value
The method returns an integer representing the exponent of the largest power of 2 that is less than or equal to the specified value. If the value is zero, negative infinity, or NaN, the method returns int.MinValue.

ILogB of 16.0 is 4
ILogB of 0.125 is -3
ILogB of 1024.0 is 10
ILogB of -8.0 is 3
ILogB of 0.0 is -2147483648
ILogB of NaN is -2147483648

Positive Values: For positive values, Math.ILogB returns the exponent of the largest power of 2 that is less than or equal to the value.
Negative Values: For negative values, Math.ILogB returns the exponent of the largest power of 2 that is less than or equal to the absolute value.

------------------------------------------------------------------------------------------

Math.Log Method:
------------------

Log(Double, Double)	- Returns the logarithm of a specified number in a specified base.
    public static double Log(double a, double newBase);

Log(Double)	- Returns the natural (base e) logarithm of a specified number.
    public static double Log(double d);

Log10(Double)	- Returns the base 10 logarithm of a specified number.
Log2(Double)	- Returns the base 2 logarithm of a specified number.

What is Logarithmic?
A logarithm is the inverse operation to exponentiation. It means that the logarithm of a number is the exponent to which another fixed number, the base, must be raised to produce that number. In simpler terms, if you have a number 
x and you want to find the power 
y to which a base 
b must be raised to get 
x, you use the logarithm function.
Mathematically, this is expressed as:
y=logb(x)
y=logb​(x)
which means:
y=xb

Return Value:
-------------
The method returns the logarithm of the specified number. If the base is not specified, it returns the natural logarithm (base e). 
If the base is specified, it returns the logarithm of the number with respect to that base.

----------------------------------------------------------------------------------------------------
Math.Max Method:
----------------

Max(UInt64, UInt64)	- Returns the larger of two 64-bit unsigned integers.
    public static ulong Max(ulong val1, ulong val2);

Max(UInt32, UInt32)	- Returns the larger of two 32-bit unsigned integers.
    public static uint Max(uint val1, uint val2);

Max(UInt16, UInt16)	- Returns the larger of two 16-bit unsigned integers.
Max(Single, Single)	- Returns the larger of two single-precision floating-point numbers.
Max(SByte, SByte)	- Returns the larger of two 8-bit signed integers.
Max(IntPtr, IntPtr)	- Returns the larger of two native signed integers.
Max(UIntPtr, UIntPtr)	- Returns the larger of two native unsigned integers.
Max(Int32, Int32)	- Returns the larger of two 32-bit signed integers.
    public static int Max(int val1, int val2);

Max(Int16, Int16)	- Returns the larger of two 16-bit signed integers.
    public static short Max(short val1, short val2);

Max(Double, Double)	- Returns the larger of two double-precision floating-point numbers.
Max(Decimal, Decimal)	- Returns the larger of two decimal numbers.
Max(Byte, Byte)	- Returns the larger of two 8-bit unsigned integers.
Max(Int64, Int64)	- Returns the larger of two 64-bit signed integers.

-------------------------------------------------------------------------------------
Math.MaxMagnitude(Double, Double) Method:
-----------------------------------------
Returns the larger magnitude(Absulate value) of two double-precision floating-point numbers.
    public static double MaxMagnitude(double x, double y);
    
The method returns the number with the larger magnitude (absolute value). If both numbers have the same magnitude, it returns the first number.

Parameter x or y, whichever has the larger magnitude. If x, or y, or both x and y are equal to NaN, NaN is returned.
            double ax = Abs(x);
            double ay = Abs(y);
            if ((ax > ay) || double.IsNaN(ax))
            {
                return x;
            }

-------------------------------------------------------------------------------------------
Math.Min Method:
-----------------
Min(UInt32, UInt32)	- Returns the smaller of two 32-bit unsigned integers.
    public static uint Min(uint val1, uint val2);

Min(UInt16, UInt16)	- Returns the smaller of two 16-bit unsigned integers.
Min(Single, Single)	- Returns the smaller of two single-precision floating-point numbers.
    public static float Min(float val1, float val2);
    
Min(SByte, SByte)	- Returns the smaller of two 8-bit signed integers.
Min(IntPtr, IntPtr)	- Returns the smaller of two native signed integers.
Min(Double, Double)	- Returns the smaller of two double-precision floating-point numbers.
    public static double Min(double val1, double val2);

Min(Int32, Int32)	- Returns the smaller of two 32-bit signed integers.
    public static int Min(int val1, int val2);

Min(Int16, Int16)	- Returns the smaller of two 16-bit signed integers.
Min(Decimal, Decimal)	- Returns the smaller of two decimal numbers.
Min(Byte, Byte)	- Returns the smaller of two 8-bit unsigned integers.
Min(UInt64, UInt64)	- Returns the smaller of two 64-bit unsigned integers.
Min(Int64, Int64)	- Returns the smaller of two 64-bit signed integers.
Min(UIntPtr, UIntPtr)	- Returns the smaller of two native unsigned integers.

val1 < val2 ? val1 : val2;

---------------------------------------------------------------------------
Math.MinMagnitude(Double, Double) Method:
----------------------------------------
Returns the smaller magnitude of two double-precision floating-point numbers.
    public static double MinMagnitude(double x, double y);

Parameter x or y, whichever has the smaller magnitude. If x, or y, or both x and y are equal to NaN, NaN is returned.

---------------------------------------------------------------------------------
Math.Pow(Double, Double) Method:
--------------------------------
Returns a specified number raised to the specified power.
    public static double Pow(double x, double y);

x	y	Return value
Any value except NaN	±0	1
NaN	±0	1 (NaN on .NET Framework)*
NaN	Any value except 0	NaN*
±0	< 0 and an odd integer	NegativeInfinity or PositiveInfinity
±0	NegativeInfinity	PositiveInfinity
±0	PositiveInfinity	+0
±0	> 0 and an odd integer	±0
-1	NegativeInfinity or PositiveInfinity	1
+1	Any value except NaN	1
+1	NaN	1 (NaN on .NET Framework)*
Any value except 1	NaN	NaN*
-1 < x < 1	PositiveInfinity	+0
< -1 or > 1	PositiveInfinity	PositiveInfinity
-1 < x < 1	NegativeInfinity	PositiveInfinity
< -1 or > 1	NegativeInfinity	+0
PositiveInfinity	< 0	+0
PositiveInfinity	> 0	PositiveInfinity
NegativeInfinity	< 0 and finite and odd integer	-0
NegativeInfinity	> 0 and finite and odd integer	NegativeInfinity
NegativeInfinity	< 0 and finite and not an odd integer	+0
NegativeInfinity	> 0 and finite and not an odd integer	PositiveInfinity
±0	< 0 and finite and not an odd integer	PositiveInfinity
±0	> 0 and finite and not an odd integer	+0
< 0 but not NegativeInfinity	Finite non-integer	NaN

----------------------------------------------------------------------------------------------------------------------
Math.ReciprocalEstimate(Double) Method:
--------------------------------------
The method returns an approximate reciprocal of the specified number. The reciprocal of a number x is 1/x .
Returns an estimate of the reciprocal of a specified number.

    public static double ReciprocalEstimate(double d);

-------------------------------------------------------------------------------------------
Math.ReciprocalSqrtEstimate(Double) Method:
---------------------------------------------
Returns an estimate of the reciprocal square root of a specified number.
    public static double ReciprocalSqrtEstimate(double d);

1.0 / Sqrt(d).

-----------------------------------------------------------------
Math.Round Method:
------------------
Math.Round method in C# is used to round a double-precision floating-point number or a decimal number to the nearest integer or to a specified number of decimal places. 

Round with specified rounding mode::
-------------------------------------
Round(Double, Int32, MidpointRounding)	- Rounds a double-precision floating-point value to a specified number of fractional digits using the specified rounding convention.
Round(Decimal, Int32, MidpointRounding)	- Rounds a decimal value to a specified number of fractional digits using the specified rounding convention.
    public static decimal Round(decimal d, int decimals, MidpointRounding mode);

Round(Double, MidpointRounding)	- Rounds a double-precision floating-point value to an integer using the specified rounding convention.
Round(Decimal, MidpointRounding)	- Rounds a decimal value an integer using the specified rounding convention.
    public static decimal Round(decimal d, MidpointRounding mode);

Round to specified number of decimal places::
---------------------------------------------
Round(Double, Int32)	- Rounds a double-precision floating-point value to a specified number of fractional digits, and rounds midpoint values to the nearest even number.
    public static double Round(double value, int digits);

Round(Decimal, Int32)	- Rounds a decimal value to a specified number of fractional digits, and rounds midpoint values to the nearest even number.

Round to nearest integer:
-------------------------
Round(Double)	- Rounds a double-precision floating-point value to the nearest integral value, and rounds midpoint values to the nearest even number.
    public static double Round(double a);
Round(Decimal)	- Rounds a decimal value to the nearest integral value, and rounds midpoint values to the nearest even number.

Consider the number 
a = 2.5
The fractional part is 0.5.
The two nearest integers are 2 and 3.
Since 2 is even and 3 is odd, 
a is rounded to 2.

Now consider a = 3.5:
The fractional part is 0.5.
The two nearest integers are 3 and 4.
Since 4 is even and 3 is odd, 
a is rounded to 4.

public enum MidpointRounding:
------------------------------
Name	Value	Description
ToEven	0	The strategy of rounding to the nearest number, and when a number is halfway between two others, it's rounded toward the nearest even number.

AwayFromZero	1	The strategy of rounding to the nearest number, and when a number is halfway between two others, it's rounded toward the nearest number that's away from zero.

ToZero	2	The strategy of directed rounding toward zero, with the result closest to and no greater in magnitude than the infinitely precise result.

ToNegativeInfinity	3	The strategy of downwards-directed rounding, with the result closest to and no greater than the infinitely precise result.

ToPositiveInfinity	4	The strategy of upwards-directed rounding, with the result closest to and no less than the infinitely precise result.

-------------------------------------------------------------------------------------
Math.Sign Method:
-------------------
returns an integer that indicates the sign of a number.

public static int Sign(int value);
public static int Sign(decimal value);

The method returns an integer that indicates the sign of the specified number:

-1: If the number is negative.
0: If the number is zero.
1: If the number is positive.

------------------------------------------------------------------------------------
Math.Truncate Method:
--------------------
Calculates the integral part of a number.

Truncate(Decimal)	- Calculates the integral part of a specified decimal number.
    public static decimal Truncate(decimal d);

Truncate(Double)	- Calculates the integral part of a specified double-precision floating-point number.
    public static double Truncate(double d);

The integral part of d; that is, the number that remains after any fractional digits have been discarded.
----------------------------------------------------------------------------------------------
Math.ScaleB(Double, Int32) Method:
---------------------------------
Returns x * 2^n computed efficiently.

    public static double ScaleB(double x, int n);

------------------------------------------------------------------------------------------------------
Math.Sqrt(Double) Method:
------------------------
Returns the square root of a specified number.
    public static double Sqrt(double d);

d parameter	Return value
Zero or positive	The positive square root of d.
Negative	NaN
Equals NaN	NaN
Equals PositiveInfinity	PositiveInfinity

------------------------------------------------------------------------------------------------------------
Math.Cbrt(Double) Method:
-------------------------
Returns the cube root of a specified number.

public static double Cbrt(double d);

The cube root of d.
-or-
NaN if d equals NaN.

------------------------------------------------------------------------------------------------------------
Math.Exp(Double) Method:
------------------------
Returns e raised to the specified power.
The number e raised to the power d. If d equals NaN or PositiveInfinity, that value is returned. If d equals NegativeInfinity, 0 is returned.

    public static double Exp(double d);

The Math.Exp(Double) method in C# is used to calculate the exponential function of a specified double-precision floating-point number. This method is part of the System namespace and returns the value of 
e raised to the power of the specified number, where 
e is the base of natural logarithms, approximately equal to 2.71828.

--------------------------------------------------------------------------------------------
Math.FusedMultiplyAdd(Double, Double, Double) Method:
-----------------------------------------------------
Returns (x * y) + z, rounded as one ternary operation.

public static double FusedMultiplyAdd(double x, double y, double z);

This computes (x * y) as if to infinite precision, adds z to that result as if to infinite precision, and finally rounds to the nearest representable value.

This differs from the non-fused sequence, which would compute (x * y) as if to infinite precision, round the result to the nearest representable value, add z to the rounded result as if to infinite precision, and finally round to the nearest representable value.


Trignomentry:
-----------------

Acos(Double)	- Returns the angle whose cosine is the specified number.
Acosh(Double)	- Returns the angle whose hyperbolic cosine is the specified number.
Asin(Double)	- Returns the angle whose sine is the specified number.
Asinh(Double)	- Returns the angle whose hyperbolic sine is the specified number.
Atan(Double)	- Returns the angle whose tangent is the specified number.
Atan2(Double, Double)	- Returns the angle whose tangent is the quotient of two specified numbers.
Atanh(Double)	- Returns the angle whose hyperbolic tangent is the specified number.
Cos(Double)	- Returns the cosine of the specified angle.
Cosh(Double)	- Returns the hyperbolic cosine of the specified angle.
Sin(Double)	- Returns the sine of the specified angle.
SinCos(Double)	- Returns the sine and cosine of the specified angle.
Sinh(Double)	- Returns the hyperbolic sine of the specified angle.
Tan(Double)	- Returns the tangent of the specified angle.
Tanh(Double)	- Returns the hyperbolic tangent of the specified angle.


**/
namespace MathNamespace{
    class MathClass{
        public static void Main(){
            Console.WriteLine("Math Class.");
            //Const Properties
            Console.WriteLine(nameof(Math.E)+ " - "+ Math.E);
            Console.WriteLine(nameof(Math.PI)+ " - "+ Math.PI);
            Console.WriteLine(nameof(Math.Tau)+ " - "+ Math.Tau);

            //Abs Methods:
            Console.WriteLine(nameof(Math.Abs)+" - "+ Math.Abs(-10));
            Console.WriteLine(nameof(Math.Abs)+" - "+ Math.Abs(10000));
            Console.WriteLine(nameof(Math.Abs)+" - "+ Math.Abs(-5455.453434343434));

            //BigMul Methods:
            Console.WriteLine(nameof(Math.BigMul) + " - "+ Math.BigMul(long.MaxValue, long.MaxValue));//BigMul - 85070591730234615847396907784232501249

            //BitDecrement
            //returns the next smallest representable double-precision floating-point number that is less than the specified value. 
            Console.WriteLine(nameof(Math.BitDecrement) + " - " +Math.BitDecrement(2.1005));//2.1004999999999994
            Console.WriteLine(nameof(Math.BitDecrement) + " - " +Math.BitDecrement(1.5));//1.4999999999999998

            //BitIncrement
            //returns the next largest representable double-precision floating-point number that is greater than the specified value.
            Console.WriteLine(nameof(Math.BitIncrement) + " - " + Math.BitIncrement(2.1005));//2.1005000000000003
            Console.WriteLine(nameof(Math.BitIncrement) + " - " + Math.BitIncrement(1.5));//1.5000000000000002

            //CopySign
            Console.WriteLine(nameof(Math.CopySign) + " - " + Math.CopySign(89.033,-3234.4));//-89.033
            Console.WriteLine(nameof(Math.CopySign) + " - " + Math.CopySign(-89.033,3234.4));//89.033

            //DivRem
            int rem;
            Console.WriteLine(nameof(Math.DivRem)+ "- "+ Math.DivRem(5,2,out rem)+ ", Rem :"+ rem);//DivRem- 2, Rem :1
            Console.WriteLine(nameof(Math.DivRem)+ "- "+ Math.DivRem(544,3));//DivRem- (181, 1)

            //Ceiling
            Console.WriteLine(nameof(Math.Ceiling)+" - "+Math.Ceiling(3.49));//4 -> smallest integral value greater than specified value
            Console.WriteLine(nameof(Math.Ceiling)+" - "+Math.Ceiling(5.1));//6
            Console.WriteLine(nameof(Math.Ceiling)+" - "+Math.Ceiling(3.79));//4
            Console.WriteLine(nameof(Math.Ceiling)+" - "+Math.Ceiling(3.0));//3
            Console.WriteLine(nameof(Math.Ceiling)+" - "+Math.Ceiling(-3.4));//-3
            //Math.Ceiling: Returns the smallest integer greater than or equal to the specified value. It rounds up.

            //Clamp
            Console.WriteLine(nameof(Math.Clamp)+" - "+ Math.Clamp(5,1,10));//5
            Console.WriteLine(nameof(Math.Clamp)+" - "+ Math.Clamp(12,1,10));//10
            Console.WriteLine(nameof(Math.Clamp)+" - "+ Math.Clamp(-6,1,10));//1
            Console.WriteLine(nameof(Math.Clamp)+" - "+ Math.Clamp(0,1,10));//1
            Console.WriteLine(nameof(Math.Clamp)+" - "+ Math.Clamp(1,1,10));//1

            //Floor
            Console.WriteLine(nameof(Math.Ceiling)+" - "+Math.Floor(3.49));//4 -> largest integral value less than specified value
            Console.WriteLine(nameof(Math.Ceiling)+" - "+Math.Floor(5.1));//6
            Console.WriteLine(nameof(Math.Ceiling)+" - "+Math.Floor(3.79));//4
            Console.WriteLine(nameof(Math.Ceiling)+" - "+Math.Floor(3.0));//3
            Console.WriteLine(nameof(Math.Ceiling)+" - "+Math.Floor(-3.4));//-4
            //Math.Floor: Returns the largest integer less than or equal to the specified value. It rounds down.
            
            //IEEERemainder
            Console.WriteLine(nameof(Math.IEEERemainder)+" - "+Math.IEEERemainder(14.5,6.12));// 2.26

            //ILogB
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(0.022));//-6
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(1.0));//0
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(2.0));//1
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(2.45));//1
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(3.0));//1
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(-3.0));//1
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(3.90));//1
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(4.0));//2
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(8.0));//3
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(9.0));//3
            Console.WriteLine(nameof(Math.ILogB)+ " - "+Math.ILogB(16.0));//4
            //returns largest position of binary representation : 16 in 4, 8 in 3, 4 in 2, 2 in 1, 1 in 0

            //Log -Natural Logarithm (base e)
            Console.WriteLine(nameof(Math.Log)+" - "+Math.Log(-1.0));//NaN
            Console.WriteLine(nameof(Math.Log)+" - "+Math.Log(0.0));//-∞
            Console.WriteLine(nameof(Math.Log)+" - "+Math.Log(1.0));//0
            Console.WriteLine(nameof(Math.Log)+" - "+Math.Log(2.0));//0.6931471805599453
            Console.WriteLine(nameof(Math.Log)+" - "+Math.Log(3.0));//1.0986122886681098
            Console.WriteLine(nameof(Math.Log)+" - "+Math.Log(4.0));//1.3862943611198906

            //Log - Specified Base 
            Console.WriteLine(nameof(Math.Log)+" - "+Math.Log(100.0,2));//6.643856189774725
            Console.WriteLine(nameof(Math.Log)+" - "+Math.Log(100.0,10));//2
            //log is gives the exponent of power to base of specified value.

            //Max
            Console.WriteLine(nameof(Math.Max)+" - "+Math.Max(10,3));//10
            Console.WriteLine(nameof(Math.Max)+" - "+Math.Max(12.22,33.10));//33.1
            Console.WriteLine(nameof(Math.Max)+" - "+Math.Max(44.22342,44.22343));//44.22343
            Console.WriteLine(nameof(Math.Max)+" - "+Math.Max(-44.22342,-44.22343));//-44.22342

            //MaxMagnitude
            Console.WriteLine(nameof(Math.MaxMagnitude)  + " - "+ Math.MaxMagnitude(-5.2,543.2));//543.2
            Console.WriteLine(nameof(Math.MaxMagnitude)  + " - "+ Math.MaxMagnitude(14.0909,-56.87));//-56.87

            //Min
            Console.WriteLine(nameof(Math.Min)+" - "+Math.Min(2,2));//2
            Console.WriteLine(nameof(Math.Min)+" - "+Math.Min(2.4,2.9));//2.4
            Console.WriteLine(nameof(Math.Min)+" - "+Math.Min(9,2));//2
            Console.WriteLine(nameof(Math.Min)+" - "+Math.Min(2,-2));//-2

            //Min Magnitude
            Console.WriteLine(nameof(Math.MinMagnitude)  + " - "+ Math.MinMagnitude(-5.2,543.2));//-5.2
            Console.WriteLine(nameof(Math.MinMagnitude)  + " - "+ Math.MinMagnitude(14.0909,-56.87));//14.0909

            //Power
            Console.WriteLine(nameof(Math.Pow)+" - "+Math.Pow(0,1));//0
            Console.WriteLine(nameof(Math.Pow)+" - "+Math.Pow(1,0));//1
            Console.WriteLine(nameof(Math.Pow)+" - "+Math.Pow(1,1));//1
            Console.WriteLine(nameof(Math.Pow)+" - "+Math.Pow(2,1));//2
            Console.WriteLine(nameof(Math.Pow)+" - "+Math.Pow(2,2));//4
            Console.WriteLine(nameof(Math.Pow)+" - "+Math.Pow(3,0));//1

            //ReciprocalEstimate
            Console.WriteLine(nameof(Math.ReciprocalEstimate)+" - "+Math.ReciprocalEstimate(2));//0.5
            Console.WriteLine(nameof(Math.ReciprocalEstimate)+" - "+Math.ReciprocalEstimate(10));//0.1

            //ReciprocalSqrtEstimate
            Console.WriteLine(nameof(Math.ReciprocalSqrtEstimate)+" - "+Math.ReciprocalSqrtEstimate(2));//0.7071067811865475
            Console.WriteLine(nameof(Math.ReciprocalSqrtEstimate)+" - "+Math.ReciprocalSqrtEstimate(10));//0.31622776601683794

            //Round
            Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.1));//2
            Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.5));//2 - HAlf way rounded or bankers round
            //The two nearest integers are 2 and 3.
            //Since 2 is even and 3 is odd, 
            Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.7));//3
            Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(3.5));//4 - HAlf way rounded or bankers round
            //The two nearest integers are 3 and 4.
            //Since 4 is even and 3 is odd, 

            //Round - spefified index position
            Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.143434,2));//2.14
            Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.434344,4));//2.4343
            Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.145434,2));//2.15
            Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.436384,4));//2.4364

            //Rounhd - MidPointRounding Mode\
            // Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.143434,MidpointRounding.ToZero));
            // Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.434344,MidPointRounding.ToEven));
            // Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.145434,MidPointRounding.AwayFromZero));
            // Console.WriteLine(nameof(Math.Round)+" - "+Math.Round(2.436384,MidPointRounding.PositiveInfinity));

            //Sign
            Console.WriteLine(nameof(Math.Sign)+" - "+Math.Sign(-1.0));//-1
            Console.WriteLine(nameof(Math.Sign)+" - "+Math.Sign(6));//1
            Console.WriteLine(nameof(Math.Sign)+" - "+Math.Sign(0));//0

            //Truncate
            Console.WriteLine(nameof(Math.Truncate)+" - "+Math.Truncate(32.233));//32
            Console.WriteLine(nameof(Math.Truncate)+" - "+Math.Truncate(32.533));//32
            Console.WriteLine(nameof(Math.Truncate)+" - "+Math.Truncate(32.733));//32
            Console.WriteLine(nameof(Math.Truncate)+" - "+Math.Truncate(-32.233));//-32

            //Sqrt
            Console.WriteLine(nameof(Math.Sqrt)+" - "+Math.Sqrt(2));//1.4142135623730951

            //Cqrt
            Console.WriteLine(nameof(Math.Cbrt)+" - "+Math.Cbrt(2));//1.259921049894873

            //exponent
            Console.WriteLine(nameof(Math.Exp)+" - "+Math.Exp(1));//2.718281828459045
            Console.WriteLine(nameof(Math.Exp)+" - "+Math.Exp(2));//7.38905609893065
        }
    }
}

