using System;
/**
Standard numeric format strings are used to format common numeric types. 
A standard numeric format string takes the form [format specifier][precision specifier], 
where:
 Format specifier is a single alphabetic character that specifies the type of number format,
 Precision specifier is an optional integer that affects the number of digits in the resulting string.the maximum precision value is 999,999,999. 
 The precision specifier controls the number of digits in the string representation of a number. It does not round the number itself.
 When precision specifier controls the number of fractional digits in the result string, the result string reflects a number that is rounded to a representable result nearest to the infinitely precise result.

Standard numeric format string are supported by : ToString(), TryFormat() and Composite formatting feature used in Write(), WriteLine(), string.Format(), stringBuilder.ApprendFormat()


**/

namespace StringType{
    class StandardFormatString{
        public static void Main(){
            Console.WriteLine("StandardFormatString");

            //B or b - Binary - Result : Binary String  - Supported by: Integral types only (.NET 8+). 
            //Precision specifier: Number of digits in the result string.
            //converts a number to a string of binary digits
            string binaryString = 8.ToString("B");
            binaryString = 8.ToString("b10");
            Console.WriteLine("binary String Representation :"+ binaryString);

            //"C" or "c" - Currency - Result: A currency value.
            // Supported by: All numeric types.
            // Precision specifier: Number of decimal digits.
            // Default precision specifier: Defined by NumberFormatInfo.CurrencyDecimalDigits. 
            //converts a number to a string that represents a currency amount. - result string is affected
            string currencyString = 10.ToString("C");//used default culture to represent the amount.
            currencyString = 34.3.ToString("c5");

        }
    }
}