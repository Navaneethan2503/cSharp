using System;
using System.Globalization;

/**
You can create a custom numeric format string, which consists of one or more custom numeric specifiers, to define how to format numeric data. A custom numeric format string is any format string that is not a standard numeric format string.

Custom numeric format strings are supported by some overloads of the ToString method of all numeric types. For example, you can supply a numeric format string to the ToString(String) and ToString(String, IFormatProvider) methods of the Int32 type. 
Custom numeric format strings are also supported by the .NET composite formatting feature, which is used by some Write and WriteLine methods of the Console and StreamWriter classes, 
the String.Format method, and the StringBuilder.AppendFormat method. String interpolation feature also supports custom numeric format strings.

Format specifier	Name Description	 Examples
"0"	                Zero placeholder	 Replaces the zero with the corresponding digit if one is present; otherwise, zero appears in the result string.
"#"	                Digit placeholder	 Replaces the "#" symbol with the corresponding digit if one is present; otherwise, no digit appears in the result string.
"."	                Decimal point	     Determines the location of the decimal separator in the result string.
","	                Group separator and  Serves as both a group separator and a number scaling specifier. As a group separator, it inserts a localized group separator character between each group. As a number scaling specifier, it divides a number by 1000 for each comma specified.
                    number scaling	

"%"              	Percentage placeholder	Multiplies a number by 100 and inserts a localized percentage symbol in the result string.
"‰"	                Per mille placeholder	Multiplies a number by 1000 and inserts a localized per mille symbol in the result string.
"E0"
"E+0"
"E-0"
"e0"
"e+0"
"e-0"	Exponential notation	If followed by at least one 0 (zero), formats the result using exponential notation. The case of "E" or "e" indicates the case of the exponent symbol in the result string. The number of zeros following the "E" or "e" character determines the minimum number of digits in the exponent. A plus sign (+) indicates that a sign character always precedes the exponent. A minus sign (-) indicates that a sign character precedes only negative exponents.
"\"	    Escape character	   Causes the next character to be interpreted as a literal rather than as a custom format specifier.
'string'
"string"	Literal string delimiter	Indicates that the enclosed characters should be copied to the result string unchanged.
;	Section separator	                Defines sections with separate format strings for positive, negative, and zero numbers.
Other	All other characters	The character is copied to the result string unchanged.

**/
namespace FormattableString{
    class CustomNumericFormattingClass{
        public static void Main(){
            Console.WriteLine("Custom Numeric Formatting.");

            //he "0" custom specifier
            //The "0" custom format specifier serves as a zero-placeholder symbol. If the value that is being formatted has a digit in the position where the zero appears in the format string, that digit is copied to the result string; otherwise, a zero appears in the result string. The position of the leftmost zero before the decimal point and the rightmost zero after the decimal point determines the range of digits that are always present in the result string.
            //The "00" specifier causes the value to be rounded to the nearest digit preceding the decimal, where rounding away from zero is always used.

            double value;

            value = 123;
            Console.WriteLine(value.ToString("00000"));
            Console.WriteLine(String.Format("{0:00000}", value));
            // Displays 00123

            value = 1.2;
            Console.WriteLine(value.ToString("0.00", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                            "{0:0.00}", value));
            // Displays 1.20

            Console.WriteLine(value.ToString("00.00", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:00.00}", value));
            // Displays 01.20

            CultureInfo daDK = CultureInfo.CreateSpecificCulture("da-DK");
            Console.WriteLine(value.ToString("00.00", daDK));
            Console.WriteLine(String.Format(daDK, "{0:00.00}", value));
            // Displays 01,20

            value = .56;
            Console.WriteLine(value.ToString("0.0", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:0.0}", value));
            // Displays 0.6

            value = 1234567890;
            Console.WriteLine(value.ToString("0,0", CultureInfo.InvariantCulture));	
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:0,0}", value));	
            // Displays 1,234,567,890

            CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
            Console.WriteLine(value.ToString("0,0", elGR));	
            Console.WriteLine(String.Format(elGR, "{0:0,0}", value));	
            // Displays 1.234.567.890

            value = 1234567890.123456;
            Console.WriteLine(value.ToString("0,0.0", CultureInfo.InvariantCulture));	
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:0,0.0}", value));	
            // Displays 1,234,567,890.1

            value = 1234.567890;
            Console.WriteLine(value.ToString("0,0.00", CultureInfo.InvariantCulture));	
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:0,0.00}", value));	
            // Displays 1,234.57


            //The "#" custom specifier

            value = 1.2;
            Console.WriteLine(value.ToString("#.##", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:#.##}", value));
            // Displays 1.2

            value = 123;
            Console.WriteLine(value.ToString("#####"));
            Console.WriteLine(String.Format("{0:#####}", value));
            // Displays 123

            value = 123456;
            Console.WriteLine(value.ToString("[##-##-##]"));
            Console.WriteLine(String.Format("{0:[##-##-##]}", value));
            // Displays [12-34-56]

            value = 1234567890;
            Console.WriteLine(value.ToString("#"));
            Console.WriteLine(String.Format("{0:#}", value));
            // Displays 1234567890

            Console.WriteLine(value.ToString("(###) ###-####"));
            Console.WriteLine(String.Format("{0:(###) ###-####}", value));
            // Displays (123) 456-7890


            // The "," custom specifier
            // The "," character serves as both a group separator and a number scaling specifier.

            // Group separator: If one or more commas are specified between two digit placeholders (0 or #) that format the integral digits of a number, a group separator character is inserted between each number group in the integral part of the output.

            // The NumberGroupSeparator and NumberGroupSizes properties of the current NumberFormatInfo object determine the character used as the number group separator and the size of each number group. For example, if the string "#,#" and the invariant culture are used to format the number 1000, the output is "1,000".

            // Number scaling specifier: If one or more commas are specified immediately to the left of the explicit or implicit decimal point, the number to be formatted is divided by 1000 for each comma. For example, if the string "0,," is used to format the number 100 million, the output is "100".
            value = 1234567890;
            Console.WriteLine(value.ToString("#,#", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:#,#}", value));
            // Displays 1,234,567,890

            Console.WriteLine(value.ToString("#,##0,,", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:#,##0,,}", value));
            // Displays 1,235

            value = .086;
            Console.WriteLine(value.ToString("#0.##%", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:#0.##%}", value));
            // Displays 8.6%

            //E Custom Specifier
            value = 86000;
            Console.WriteLine(value.ToString("0.###E+0", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:0.###E+0}", value));
            // Displays 8.6E+4

            Console.WriteLine(value.ToString("0.###E+000", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:0.###E+000}", value));
            // Displays 8.6E+004

            value = 123;
            Console.WriteLine(value.ToString("\\#\\#\\# ##0 dollars and \\0\\0 cents \\#\\#\\#"));
            Console.WriteLine(String.Format("{0:\\#\\#\\# ##0 dollars and \\0\\0 cents \\#\\#\\#}",
                                            value));
            // Displays ### 123 dollars and 00 cents ###


            double posValue = 1234;
            double negValue = -1234;
            double zeroValue = 0;

            string fmt2 = "##;(##)";
            string fmt3 = "##;(##);**Zero**";

            Console.WriteLine(posValue.ToString(fmt2));
            Console.WriteLine(String.Format("{0:" + fmt2 + "}", posValue));
            // Displays 1234

            Console.WriteLine(negValue.ToString(fmt2));
            Console.WriteLine(String.Format("{0:" + fmt2 + "}", negValue));
            // Displays (1234)

            Console.WriteLine(zeroValue.ToString(fmt3));
            Console.WriteLine(String.Format("{0:" + fmt3 + "}", zeroValue));
            // Displays **Zero**


        }
    }
}