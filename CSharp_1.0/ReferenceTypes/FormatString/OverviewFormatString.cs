using System;
using System.Globalization;
/**

**/

namespace StringType{

    class Automobiles{
        //No implementation
    }

    class Temparature{
        decimal temp;

        public Temparature(decimal t){
            this.temp = t;
        }

        public override string ToString()
        {
            return this.temp.ToString("N1")+"°C";
    }
    }
    public class FormatString{
        public static void Main(){
            Console.WriteLine("Format String");
            //Default formatting using the ToString method
            Automobiles car = new Automobiles();
            Console.WriteLine(car);//Every type that is derived from System.Object automatically inherits a parameterless ToString method, which returns the name of the type by default. 
            // The following example illustrates the default ToString method. It defines a class named Automobile that has no implementation. When the class is instantiated and its ToString method is called, it displays its type name. Note that the ToString method is not explicitly called in the example. 
            // The Console.WriteLine(Object) method implicitly calls the ToString method of the object passed to it as an argument.

            Temparature temp1 = new Temparature(27.0m);
            Console.WriteLine(temp1.ToString());

            //Standard Format string
            //A standard format string contains a single format specifier, which is an alphabetic character that defines the string representation of the object to which it is applied, along with an optional precision specifier that affects how many digits are displayed in the result string. 
            //If the precision specifier is omitted or is not supported, a standard format specifier is equivalent to a standard format string.
            /**
               The CurrencySymbol property, which specifies the current culture's currency symbol.

                The CurrencyNegativePattern or CurrencyPositivePattern property, which returns an integer that determines the following:

                The placement of the currency symbol.

                Whether negative values are indicated by a leading negative sign, a trailing negative sign, or parentheses.

                Whether a space appears between the numeric value and the currency symbol.

                The CurrencyDecimalDigits property, which defines the number of fractional digits in the result string.

                The CurrencyDecimalSeparator property, which defines the decimal separator symbol in the result string.

                The CurrencyGroupSeparator property, which defines the group separator symbol.

                The CurrencyGroupSizes property, which defines the number of digits in each group to the left of the decimal.

                The NegativeSign property, which determines the negative sign used in the result string if parentheses are not used to indicate negative values.
            **/
            DayOfWeek thisDay = DayOfWeek.Monday;
            string[] formatStrings = { "G", "F", "D", "X" };

            foreach (string formatString in formatStrings)
                Console.WriteLine(thisDay.ToString(formatString));

            //numeric format strings may include a precision specifier. The meaning of this specifier depends on the format string with which it is used, but it typically indicates either the total number of digits or the number of fractional digits that should appear in the result string. 
            // For example, the following example uses the "X4" standard numeric string and a precision specifier to create a string value that has four hexadecimal digits.
            byte[] byteValues = { 12, 163, 255 };
            foreach (byte byteValue in byteValues)
                Console.WriteLine(byteValue.ToString("X4"));

            //Standard format strings for date and time values are aliases for custom format strings stored by a particular DateTimeFormatInfo property.
            DateTime date1 = new DateTime(2009, 6, 30);
            Console.WriteLine("D Format Specifier:     {0:D}", date1);
            string longPattern = CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern;
            Console.WriteLine("'{0}' custom format string:     {1}",
                              longPattern, date1.ToString(longPattern));
                    
            //You can also use standard format strings to define the string representation of an application-defined object that is produced by the object's ToString(String) method. 

            //Custom format strings
            //In addition to the standard format strings, .NET defines custom format strings for both numeric values and date and time values. A custom format string consists of one or more custom format specifiers that define the string representation of a value. 
            // For example, the custom date and time format string "yyyy/mm/dd hh:mm:ss.ffff t zzz" converts a date to its string representation in the form "2008/11/15 07:45:00.0000 P -08:00" for the en-US culture. 
            // Similarly, the custom format string "0000" converts the integer value 12 to "0012".

        }
    }
}