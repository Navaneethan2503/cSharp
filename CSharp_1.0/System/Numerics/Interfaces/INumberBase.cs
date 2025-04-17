using System;
using System.Globalization;
using System.Numerics;

/**
Defines the base of other number types.

The INumberBase<TSelf> interface in C# is part of the System.Numerics namespace and is used to define a base interface for numeric types. 
This interface provides a set of methods and properties that are common to all numeric types, allowing for a more consistent and type-safe approach to numeric operations.

Purpose
The purpose of the INumberBase<TSelf> interface is to provide a standardized set of operations for numeric types. 
This interface allows for a consistent approach to implementing numeric operations across different types, such as integers, floating-point numbers, and custom numeric types.

Properties:
----------
One	- Gets the value 1 for the type.
Radix - Gets the radix, or base, for the type.
Zero - Gets the value 0 for the type.

Methods:
---------
Abs(TSelf) - Computes the absolute of a value.
    The absolute value of a number is its non-negative value, regardless of whether the original number is positive or negative.
    parameter - The value for which to get its absolute.
    return - The absolute of value.

CreateChecked<TOther>(TOther)	- Creates an instance of the current type from a value, throwing an overflow exception for any values that fall outside the representable range of the current type.
    public static virtual TSelf CreateChecked<TOther>(TOther value) where TOther : System.Numerics.INumberBase<TOther>;

CreateSaturating<TOther>(TOther)	- Creates an instance of the current type from a value, saturating any values that fall outside the representable range of the current type.
    public static virtual TSelf CreateSaturating<TOther>(TOther value) where TOther : System.Numerics.INumberBase<TOther>;

CreateTruncating<TOther>(TOther)	- Creates an instance of the current type from a value, truncating any values that fall outside the representable range of the current type.
    public static virtual TSelf CreateTruncating<TOther>(TOther value) where TOther : System.Numerics.INumberBase<TOther>;

Equals(T)	- Indicates whether the current object is equal to another object of the same type.(Inherited from IEquatable<T>)
    return true if the current object is equal to the other parameter; otherwise, false.
    public bool Equals(T? other);

IsCanonical(TSelf)	- Determines if a value is in its canonical representation.
    Canonical form refers to a standard or simplest form of a mathematical object, expression, or data structure that is unique and representative of that object. It is a way to ensure consistency and simplify comparisons between objects.
    for different types like number, matric, polynomial, etc have its own form.

    For the Int32 struct in C#, the canonical form refers to the standard representation of an integer value. Since Int32 represents 32-bit signed integers, the canonical form is simply the integer itself without any additional formatting or representation.
    Canonical Form: Any valid 32-bit signed integer value is considered to be in canonical form. This includes all integers from − 2,147,483,648−2,147,483,648 to 2,147,483,6472,147,483,647.Examples: 0, 123, -456, 2147483647, -2147483648
    Non-Canonical Form: There isn't a non-canonical form for Int32 values in the same sense as there might be for floating-point numbers (like NaN or infinity). However, representations that are not directly integers or involve unnecessary formatting can be considered non-canonical.
    Examples:
    Formatted Strings: "00123" (leading zeros are unnecessary for integer representation)
    Different Base Representations: "0x7B" (hexadecimal representation of 123)
    Fractional Values: 123.0 (floating-point representation of an integer)

    public static abstract bool IsCanonical(TSelf value);
    return true if value is in its canonical representation; otherwise, false.

IsComplexNumber(TSelf)	- Determines if a value represents a complex number.
    public static abstract bool IsComplexNumber(TSelf value);
    true if value is a complex number; otherwise, false.
    This function returns false for a complex number a + bi where a or b is zero. In other words, it excludes real numbers and pure imaginary numbers.

IsEvenInteger(TSelf)	- Determines if a value represents an even integral number.
    public static abstract bool IsEvenInteger(TSelf value);
    This method correctly handles floating-point values and so 2.0 will return true while 2.2 will return false.
    A return value of false does not imply that IsOddInteger(TSelf) will return true. A number with a fractional portion, for example, 3.3, is not even or odd.

IsFinite(TSelf)	- Determines if a value is finite.
    public static abstract bool IsFinite(TSelf value);
    A return value of false does not imply that IsInfinity(TSelf) will return true. NaN is not finite or infinite.
    true if value is finite; otherwise, false.

IsImaginaryNumber(TSelf)	- Determines if a value represents a pure imaginary number.
    This function returns false for a complex number a + bi where a is non-zero, as that number is not purely imaginary.
    true if value is a pure imaginary number; otherwise, false.
    public static abstract bool IsImaginaryNumber(TSelf value);

IsInfinity(TSelf)	- Determines if a value is infinite.
    public static abstract bool IsInfinity(TSelf value);
    A return value of false does not imply that IsFinite(TSelf) will return true. NaN is not finite or infinite.

IsInteger(TSelf)	- Determines if a value represents an integral number.
    public static abstract bool IsInteger(TSelf value);
    This method correctly handles floating-point values and so 2.0 and 3.0 will return true while 2.2 and 3.3 will return false.
    true if value is an integer; otherwise, false.

IsNaN(TSelf)	- Determines if a value is NaN.
    public static abstract bool IsNaN(TSelf value);

IsNegative(TSelf)	- Determines if a value represents a negative real number.
    public static abstract bool IsNegative(TSelf value);
    If this type has signed zero, then -0 is also considered negative.
    A return value of false does not imply that IsPositive(TSelf) will return true. A complex number, a + bi for non-zero b, is not positive or negative
    true if value represents negative zero or a negative real number; otherwise, false.

IsNegativeInfinity(TSelf)	- Determines if a value is negative infinity.
    public static abstract bool IsNegativeInfinity(TSelf value);

IsNormal(TSelf)	- Determines if a value is normal.
    public static abstract bool IsNormal(TSelf value);

IsOddInteger(TSelf)	- Determines if a value represents an odd integral number.
    public static abstract bool IsOddInteger(TSelf value);
    This method correctly handles floating-point values and so 3.0 will return true while 3.3 will return false.
    A return value of false does not imply that IsEvenInteger(TSelf) will return true. A number with a fractional portion, for example, 3.3, is not even or odd.
    true if value is an odd integer; otherwise, false.

IsPositive(TSelf)	- Determines if a value represents zero or a positive real number.
    public static abstract bool IsPositive(TSelf value);
    true if value represents (positive) zero or a positive real number; otherwise, false.
    If this type has signed zero, then -0 is not considered positive, but +0 is.
    A return value of false does not imply that IsNegative(TSelf) will return true. A complex number, a + bi for non-zero b, is not positive or negative

IsPositiveInfinity(TSelf)	- Determines if a value is positive infinity.
    public static abstract bool IsPositiveInfinity(TSelf value);
    true if value is positive infinity; otherwise, false.

IsRealNumber(TSelf)	- Determines if a value represents a real number.
    public static abstract bool IsRealNumber(TSelf value);
    This function returns true for a complex number a + bi where b is zero.
    This function checks values against the extended real number line, thus returns true for positive and negative infinity.

IsSubnormal(TSelf)	- Determines if a value is subnormal.
    public static abstract bool IsSubnormal(TSelf value);
    true if value is subnormal; otherwise, false.

IsZero(TSelf)	- Determines if a value is zero.
    public static abstract bool IsZero(TSelf value);
    This function treats both positive and negative zero as zero and so will return true for +0.0 and -0.0.

MaxMagnitude(TSelf, TSelf)	- Compares two values to compute which has the greater magnitude.
    public static abstract TSelf MaxMagnitude(TSelf x, TSelf y);
    For IFloatingPointIeee754<TSelf> this method matches the IEEE 754:2019 maximumMagnitude function. This requires NaN inputs to be propagated back to the caller and for -0.0 to be treated as less than +0.0.
    x if it has a greater magnitude than y; otherwise, y.

MaxMagnitudeNumber(TSelf, TSelf)	- Compares two values to compute which has the greater magnitude and returning the other value if an input is NaN.
    public static abstract TSelf MaxMagnitudeNumber(TSelf x, TSelf y);
    For IFloatingPointIeee754<TSelf> this method matches the IEEE 754:2019 maximumMagnitudeNumber function. This requires NaN inputs to not be propagated back to the caller and for -0.0 to be treated as less than +0.0.
    x if it has a greater magnitude than y; otherwise, y.

MinMagnitude(TSelf, TSelf)	- Compares two values to compute which has the lesser magnitude.
    public static abstract TSelf MinMagnitude(TSelf x, TSelf y);
    For IFloatingPointIeee754<TSelf> this method matches the IEEE 754:2019 minimumMagnitude function. This requires NaN inputs to be propagated back to the caller and for -0.0 to be treated as less than +0.0.
    x if it has a lesser magnitude than y; otherwise, y.

MinMagnitudeNumber(TSelf, TSelf)	- Compares two values to compute which has the lesser magnitude and returning the other value if an input is NaN.
    public static abstract TSelf MinMagnitudeNumber(TSelf x, TSelf y);
    For IFloatingPointIeee754<TSelf> this method matches the IEEE 754:2019 minimumMagnitudeNumber function. This requires NaN inputs to not be propagated back to the caller and for -0.0 to be treated as less than +0.0.
    x if it has a lesser magnitude than y; otherwise, y.

MultiplyAddEstimate(TSelf, TSelf, TSelf)	- Computes an estimate of (left * right) + addend.
    public static virtual TSelf MultiplyAddEstimate(TSelf left, TSelf right, TSelf addend);
    An estimate of (left * right) + addend.

Parse(ReadOnlySpan<Byte>, NumberStyles, IFormatProvider)	- Parses a span of UTF-8 characters into a value.
    public static virtual TSelf Parse(ReadOnlySpan<byte> utf8Text, System.Globalization.NumberStyles style, IFormatProvider? provider);

Parse(ReadOnlySpan<Char>, NumberStyles, IFormatProvider)	- Parses a span of characters into a value.
    public static abstract TSelf Parse(ReadOnlySpan<char> s, System.Globalization.NumberStyles style, IFormatProvider? provider);

Parse(String, NumberStyles, IFormatProvider)- Parses a string into a value.
    public static abstract TSelf Parse(string s, System.Globalization.NumberStyles style, IFormatProvider? provider);

ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.(Inherited from IFormattable)
    public static abstract TSelf Parse(string s, System.Globalization.NumberStyles style, IFormatProvider? provider);

TryConvertFromChecked<TOther>(TOther, TSelf)	- Tries to convert a value to an instance of the the current type, throwing an overflow exception for any values that fall outside the representable range of the current type.
TryConvertFromSaturating<TOther>(TOther, TSelf)	- Tries to convert a value to an instance of the the current type, saturating any values that fall outside the representable range of the current type.
TryConvertFromTruncating<TOther>(TOther, TSelf)	-Tries to convert a value to an instance of the the current type, truncating any values that fall outside the representable range of the current type.
TryConvertToChecked<TOther>(TSelf, TOther)	- Tries to convert an instance of the the current type to another type, throwing an overflow exception for any values that fall outside the representable range of the current type.
TryConvertToSaturating<TOther>(TSelf, TOther)	- Tries to convert an instance of the the current type to another type, saturating any values that fall outside the representable range of the current type.
TryConvertToTruncating<TOther>(TSelf, TOther)	-Tries to convert an instance of the the current type to another type, truncating any values that fall outside the representable range of the current type.
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.(Inherited from IUtf8SpanFormattable)
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance into the provided span of characters.(Inherited from ISpanFormattable)
TryParse(ReadOnlySpan<Byte>, NumberStyles, IFormatProvider, TSelf)	- Tries to parse a span of UTF-8 characters into a value.
    public static abstract bool TryParse(ReadOnlySpan<char> s, System.Globalization.NumberStyles style, IFormatProvider? provider, out TSelf result);

TryParse(ReadOnlySpan<Char>, NumberStyles, IFormatProvider, TSelf)	-Tries to parse a span of characters into a value.
    public static abstract bool TryParse(string? s, System.Globalization.NumberStyles style, IFormatProvider? provider, out TSelf result);

TryParse(String, NumberStyles, IFormatProvider, TSelf)	- Tries to parse a string into a value.
    public static virtual bool TryParse(ReadOnlySpan<byte> utf8Text, System.Globalization.NumberStyles style, IFormatProvider? provider, out TSelf result);


**/
namespace INumberNamespace{

    public struct CustomNumber //: INumberBase<CustomNumber>
    {
        private int _value;

        public CustomNumber(int value)
        {
            _value = value;
        }

        public static CustomNumber Zero => new CustomNumber(0);
        public static CustomNumber One => new CustomNumber(1);

        public static CustomNumber Add(CustomNumber left, CustomNumber right)
        {
            return new CustomNumber(left._value + right._value);
        }

        public static CustomNumber Subtract(CustomNumber left, CustomNumber right)
        {
            return new CustomNumber(left._value - right._value);
        }

        public static CustomNumber Multiply(CustomNumber left, CustomNumber right)
        {
            return new CustomNumber(left._value * right._value);
        }

        public static CustomNumber Divide(CustomNumber left, CustomNumber right)
        {
            if (right._value == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return new CustomNumber(left._value / right._value);
        }

        public static CustomNumber Parse(string s, IFormatProvider provider)
        {
            if (int.TryParse(s, NumberStyles.Integer, provider, out int result))
            {
                return new CustomNumber(result);
            }
            else
            {
                throw new FormatException("Input string is not in the correct format.");
            }
        }

        public static bool TryParse(string s, IFormatProvider provider, out CustomNumber result)
        {
            if (int.TryParse(s, NumberStyles.Integer, provider, out int parsedValue))
            {
                result = new CustomNumber(parsedValue);
                return true;
            }
            else
            {
                result = Zero;
                return false;
            }
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        //public static CustomNumber Abs(CustomNumber value) => new CustomNumber(Math.Abs(value._value));

        
        public static bool IsCanonical(CustomNumber value)
        {
            // Assuming canonical form means the value is not NaN or infinity
            return !double.IsNaN(value._value) && !double.IsInfinity(value._value);
        }

       

        
        

         
    }


    class INumberClass{
        public static void Main(){
            Console.WriteLine("INumber Base.");
            CustomNumber num1 = new CustomNumber(10);
            CustomNumber num2 = new CustomNumber(5);

            CustomNumber sum = CustomNumber.Add(num1, num2);
            CustomNumber difference = CustomNumber.Subtract(num1, num2);
            CustomNumber product = CustomNumber.Multiply(num1, num2);
            CustomNumber quotient = CustomNumber.Divide(num1, num2);

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Quotient: {quotient}");

            string input = "42";
            CustomNumber parsedNumber = CustomNumber.Parse(input, CultureInfo.InvariantCulture);
            Console.WriteLine($"Parsed Number: {parsedNumber}");
        }
    }
}


