using System;


namespace DoublePoint{
    /**
    Size: 8 bytes (64 bits)
    Precision: Approximately 15-17 significant digits
    Range: ±5.0 × 10^−324 to ±1.7 × 10^308
    Suffix: d or D (optional, as double is the default type for floating-point literals)
    Default Value: 0.0
    Characteristics:
        Double-Precision: The double type is known as double-precision floating-point. It uses 1 bit for the sign, 11 bits for the exponent, and 52 bits for the fraction (mantissa).
        Higher Precision: Compared to float, double offers higher precision and a wider range, making it suitable for scientific calculations and applications requiring high accuracy.
        Default Floating-Point Type: In C#, floating-point literals are treated as double by default unless explicitly specified as float.

    double doubleValue = 3.141592653589793;
    double positiveInfinity = double.PositiveInfinity;
    double negativeInfinity = double.NegativeInfinity;
    double notANumber = double.NaN;

    Structure of double:
        A double is divided into three parts:
            Sign Bit (1 bit): Indicates whether the number is positive (0) or negative (1).
            Exponent (11 bits): Determines the scale or range of the number. It is stored in a "biased" form, meaning a fixed value (1023 for double) is added to the actual exponent to get the stored exponent.
            Mantissa (52 bits): Also known as the significand or fraction, it represents the precision bits of the number.

    Example Breakdown:
        Let's take the number 123.456 as an example and see how it would be represented in a double:

        Convert to Binary:

        The binary representation of 123.456 is approximately 1111011.0111001100110011001100110011001100110011001100110011.
        Normalize:

        Normalize the binary number to the form 1.xxxxx... × 2^n.
        For 123.456, it becomes 1.1110110111001100110011001100110011001100110011001100110011 × 2^6.
        Sign Bit:

        Since 123.456 is positive, the sign bit is 0.
        Exponent:

        The actual exponent is 6.
        Add the bias (1023) to the exponent: 6 + 1023 = 1029.
        The binary representation of 1029 is 10000000101.
        Mantissa:

        The mantissa is the fractional part after normalization: 1110110111001100110011001100110011001100110011001100110011.
    **/
    public class DoublePoint{
        public static void Main(){
            System.Console.WriteLine("Double Point");

            System.Console.WriteLine("Max:"+double.MaxValue);
            Console.WriteLine("Min:"+ double.MinValue);
            double a = 399.3223;
            System.Console.WriteLine(""+a.GetHashCode());
            Console.WriteLine(double.Abs(-24424.44344332));

            System.Console.WriteLine(double.Cbrt(3.3));
            System.Console.WriteLine(double.IsEvenInteger(a));

            double b = 3443324.432343443;
            System.Console.WriteLine(double.Ceiling(b));
            System.Console.WriteLine(double.Truncate(b));
            System.Console.WriteLine("Floor :"+double.Floor(a));
            Console.WriteLine("Round :"+ double.Round(b));
            System.Console.WriteLine(double.Equals(a,b));

            Console.WriteLine("IsInteger :"+double.IsInteger(b));

        }
    }
}