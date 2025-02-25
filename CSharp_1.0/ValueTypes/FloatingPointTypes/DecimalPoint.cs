using System;

namespace DecimalPoint{
    public class DecimalPoint{
        /**
        Size: 16 bytes (128 bits)
        Precision: 28-29 significant digits
        Range: ±1.0 × 10^−28 to ±7.9 × 10^28
        Suffix: m or M (e.g., 3.14m)
        Default Value: 0.0m
        
        Characteristics:
            High Precision: The decimal type offers higher precision compared to float and double, making it suitable for financial and monetary calculations where exact decimal representation is crucial.
            Fixed-Point Arithmetic: Unlike float and double, which use binary floating-point arithmetic, decimal uses a form of fixed-point arithmetic, which reduces rounding errors in decimal calculations.

        Example Usage:
            decimal decimalValue = 123.456m;
            decimal largeValue = 7.9e28m;
            decimal smallValue = 1.0e-28m;

        Structure of decimal:
            A decimal is divided into three parts:

            Sign Bit (1 bit): Indicates whether the number is positive (0) or negative (1).
            Exponent (7 bits): Determines the scale or range of the number.
            Mantissa (96 bits): Represents the precision bits of the number.

        Example Breakdown:
        Let's take the number 123.456 as an example and see how it would be represented in a decimal:

        Convert to Decimal:

        The decimal representation of 123.456 is straightforward as it is already in decimal form.
        Sign Bit:

        Since 123.456 is positive, the sign bit is 0.
        Exponent:

        The exponent determines the position of the decimal point.
        Mantissa:

        The mantissa is the significant digits of the number.
        Putting It All Together:
        Sign Bit: 0
        Exponent: Adjusted to fit the scale.
        Mantissa: 123456 (with appropriate scaling for the decimal point).
        The decimal type ensures that the number is represented accurately without the rounding errors that can occur with binary floating-point types.

        The suffix for the decimal type in C# is m or M rather than d to avoid confusion with the double type, which uses d or D as its suffix
        

        **/
        public static void Main(){
            System.Console.WriteLine("Decimal Point");
            Console.WriteLine("MAx:"+decimal.MaxValue);
            Console.WriteLine("Min:"+decimal.MinValue);
            System.Console.WriteLine("minus 1 :"+decimal.MinusOne + " , Zero :"+ decimal.Zero + ", one :"+ decimal.One);

            decimal a = 987.98798m;

            System.Console.WriteLine("a = "+ a +" - "+ a.GetType());

            
        }
    }
}