using System;
using System.Globalization;
/**
All numeric types have two static parsing methods, Parse and TryParse, that you can use to convert the string representation of a number into a numeric type. These methods enable you to parse strings that were produced by using the format strings documented in Standard Numeric Format Strings and Custom Numeric Format Strings. By default, the Parse and TryParse methods can successfully convert strings that contain integral decimal digits only to integer values. They can successfully convert strings that contain integral and fractional decimal digits, group separators, and a decimal separator to floating-point values. The Parse method throws an exception if the operation fails, whereas the TryParse method returns false.

Parsing and format providers
Typically, the string representations of numeric values differ by culture. Elements of numeric strings, such as currency symbols, group (or thousands) separators, and decimal separators, all vary by culture. Parsing methods either implicitly or explicitly use a format provider that recognizes these culture-specific variations. If no format provider is specified in a call to the Parse or TryParse method, the format provider associated with the current culture (the NumberFormatInfo object returned by the NumberFormatInfo.CurrentInfo property) is used.

A format provider is represented by an IFormatProvider implementation. This interface has a single member, the GetFormat method, whose single parameter is a Type object that represents the type to be formatted. This method returns the object that provides formatting information. .NET supports the following two IFormatProvider implementations for parsing numeric strings:

A CultureInfo object whose CultureInfo.GetFormat method returns a NumberFormatInfo object that provides culture-specific formatting information.

A NumberFormatInfo object whose NumberFormatInfo.GetFormat method returns itself.

Parsing and NumberStyles Values
The style elements (such as white space, group separators, and decimal separator) that the parse operation can handle are defined by a NumberStyles enumeration value. By default, strings that represent integer values are parsed by using the NumberStyles.Integer value, which permits only numeric digits, leading and trailing white space, and a leading sign. Strings that represent floating-point values are parsed using a combination of the NumberStyles.Float and NumberStyles.AllowThousands values; this composite style permits decimal digits along with leading and trailing white space, a leading sign, a decimal separator, a group separator, and an exponent. By calling an overload of the Parse or TryParse method that includes a parameter of type NumberStyles and setting one or more NumberStyles flags, you can control the style elements that can be present in the string for the parse operation to succeed.

**/
namespace ParsableString{
    class NumericParsing{
        public static void Main(){
            Console.WriteLine("Numeric Parsing .");
            string[] values = { "1,304.16", "$1,456.78", "1,094", "152",
                          "123,45 €", "1 304,16", "Ae9f" };
            double number;
            CultureInfo culture = null;

            foreach (string value in values) {
                try {
                    culture = CultureInfo.CreateSpecificCulture("en-US");
                    number = Double.Parse(value, culture);
                    Console.WriteLine($"{culture.Name}: {value} --> {number}");
                }
                catch (FormatException) {
                    Console.WriteLine($"{culture.Name}: Unable to parse '{value}'.");
                    culture = CultureInfo.CreateSpecificCulture("fr-FR");
                    try {
                    number = Double.Parse(value, culture);
                    Console.WriteLine($"{culture.Name}: {value} --> {number}");
                    }
                    catch (FormatException) {
                    Console.WriteLine($"{culture.Name}: Unable to parse '{value}'.");
                    }
                }
                Console.WriteLine();
            }

            int a = int.Parse("    43   ");
            Console.WriteLine(a);

            string value1 = "1,304";
            int number1;
            IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
            if (Int32.TryParse(value1, out number1))
                Console.WriteLine($"{value1} --> {number1}");
            else
                Console.WriteLine($"Unable to convert '{value1}'");

            if (Int32.TryParse(value1, NumberStyles.Integer | NumberStyles.AllowThousands,
                                provider, out number1))
                Console.WriteLine($"{value1} --> {number1}");
            else
                Console.WriteLine($"Unable to convert '{value1}'");

        }
    }
}