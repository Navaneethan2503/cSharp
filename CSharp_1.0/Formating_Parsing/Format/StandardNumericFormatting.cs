using System;
using System.Globalization;
/**
Standard numeric format strings:
--------------------------------
Standard numeric format strings are used to format common numeric types. 
A standard numeric format string takes the form 
    
    [format specifier][precision specifier], 

where:
    Format specifier is a single alphabetic character that specifies the type of number format, for example, currency or percent. Any numeric format string that contains more than one alphabetic character, including white space, is interpreted as a custom numeric format string.
    Precision specifier is an optional integer that affects the number of digits in the resulting string. In .NET 7 and later versions, the maximum precision value is 999,999,999. In .NET 6, the maximum precision value is Int32.MaxValue. In previous .NET versions, the precision can range from 0 to 99. The precision specifier controls the number of digits in the string representation of a number. It does not round the number itself. To perform a rounding operation, use the Math.Ceiling, Math.Floor, or Math.Round method.
    When precision specifier controls the number of fractional digits in the result string, the result string reflects a number that is rounded to a representable result nearest to the infinitely precise result.

Standard numeric format strings are supported by:
1. Some overloads of the ToString method of all numeric types.
2. The TryFormat method of all numeric types
3. The .NET composite formatting feature, which is used by some Write and WriteLine methods of the Console and StreamWriter classes, the String.Format method, and the StringBuilder.AppendFormat method. The composite format feature allows you to include the string representation of multiple data items in a single string, to specify field width, and to align numbers in a field.
4. Interpolated strings in C# and Visual Basic, which provide a simplified syntax when compared to composite format strings.

Format specifier	Name	Description	Examples:
--------------------------------------------------
"B" or "b"	 Binary	        Result: A binary string.
"C" or "c"	Currency	    Result: A currency value.
"D" or "d"	Decimal	        Result: Integer digits with optional negative sign.
"E" or "e"	Exponential (scientific)	Result: Exponential notation.
"F" or "f"	Fixed-point	    Result: Integral and decimal digits with optional negative sign.
"N" or "n"	Number	        Result: Integral and decimal digits, group separators, and a decimal separator with optional negative sign.
"P" or "p"	Percent	        Result: Number multiplied by 100 and displayed with a percent symbol.
"R" or "r"	Round-trip	    Result: A string that can round-trip to an identical number.
"X" or "x"	Hexadecimal	    Result: A hexadecimal string.
Any other single character	Unknown specifier	Result: Throws a FormatException at run time.
**/
namespace FormattableString{
    class StandardFormatting{
        public static void Main(){
            Console.WriteLine("Standard Formatting : Numeric, Date Time, Time Frame.");
            Console.WriteLine($"Binary of 42 is : {42:b}");
            Console.WriteLine($"Binary of 42 with 15 pad is : {42:b15}");

            //Currency
            int amount = 10000;
            Console.WriteLine($"Currency : {amount:c}");
            Console.WriteLine($"Currency : {amount:c5}");

            //digit
            int digit = 1232;
            Console.WriteLine($"Digit : {digit:D}");
            Console.WriteLine($"Digit : {digit:D10}");

            double expon = 12345.6789;
            Console.WriteLine(expon.ToString("E", CultureInfo.InvariantCulture));
            // Displays 1.234568E+004

            Console.WriteLine(expon.ToString("E10", CultureInfo.InvariantCulture));
            // Displays 1.2345678900E+004


            int integerNumber;
            integerNumber = 17843;
            Console.WriteLine(integerNumber.ToString("F",
                            CultureInfo.InvariantCulture));
            // Displays 17843.00
            Console.WriteLine(integerNumber.ToString("F3",
                  CultureInfo.InvariantCulture));
            // Displays 17843.000      

            double number;

            number = 12345.6789;
            Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture));
            // Displays  12345.6789
            Console.WriteLine(number.ToString("G",
                            CultureInfo.CreateSpecificCulture("fr-FR")));
            // Displays 12345,6789

            Console.WriteLine(number.ToString("G7", CultureInfo.InvariantCulture));
            // Displays 12345.68

            number = .0000023;
            Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture));
            // Displays 2.3E-06
            Console.WriteLine(number.ToString("G",
                            CultureInfo.CreateSpecificCulture("fr-FR")));
            // Displays 2,3E-06

            //Number
            int intValue = 123456789;
            Console.WriteLine("Number :"+intValue.ToString("N1", CultureInfo.InvariantCulture));

            //Percent
            number = .2468013;
            Console.WriteLine("Percent :"+number.ToString("P", CultureInfo.InvariantCulture));
            // Displays 24.68 %
            Console.WriteLine("Percent :"+number.ToString("P1", CultureInfo.InvariantCulture));
            // Displays 24.7 %

            //Round Trip
            Console.WriteLine("Attempting to round-trip a Double with 'R':");
            double initialValue = 0.6822871999174;
            string valueString = initialValue.ToString("R",
                                                    CultureInfo.InvariantCulture);
            double roundTripped = double.Parse(valueString,
                                            CultureInfo.InvariantCulture);
            Console.WriteLine($"{initialValue:R} = {roundTripped:R}: {initialValue.Equals(roundTripped)}\n");

            Console.WriteLine("Attempting to round-trip a Double with 'G17':");
            string valueString17 = initialValue.ToString("G17",
                                                        CultureInfo.InvariantCulture);
            double roundTripped17 = double.Parse(valueString17,
                                                CultureInfo.InvariantCulture);
            Console.WriteLine($"{initialValue:R} = {roundTripped17:R}: {initialValue.Equals(roundTripped17)}\n");
            // If compiled to an application that targets anycpu or x64 and run on an x64 system,
            // the example displays the following output:
            //       Attempting to round-trip a Double with 'R':
            //       .NET Framework:
            //       0.6822871999174 = 0.68228719991740006: False
            //       .NET:
            //       0.6822871999174 = 0.6822871999174: True
            //
            //       Attempting to round-trip a Double with 'G17':
            //       0.6822871999174 = 0.6822871999174: True

            //Hexadecimal
            int value;
            value = 0x2045e;
            Console.WriteLine(value.ToString("x"));
            // Displays 2045e
            Console.WriteLine(value.ToString("X"));
            // Displays 2045E
            Console.WriteLine(value.ToString("X8"));
            // Displays 0002045E

            value = 123456789;
            Console.WriteLine(value.ToString("X"));
            // Displays 75BCD15
            Console.WriteLine(value.ToString("X2"));
            // Displays 75BCD15
        }
    }
}