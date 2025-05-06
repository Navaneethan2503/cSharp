using System;
using System.Globalization;

/**
Formatting is the process of converting an instance of a class or structure, or an enumeration value, to a string representation. The purpose is to display the resulting string to users or to deserialize it later to restore the original data type.

The basic mechanism for formatting is the default implementation of the Object.ToString method, which is discussed in the Default Formatting Using the ToString Method section later in this topic. However, .NET provides several ways to modify and extend its default formatting support. These include the following:
Overriding the Object.ToString method to define a custom string representation of an object's value. For more information, see the Override the ToString Method section later in this topic.

Implementing the IFormattable interface to support both string conversion with the Convert class and composite formatting. For more information, see the IFormattable Interface section.

Using composite formatting to embed the string representation of a value in a larger string. For more information, see the Composite Formatting section.

Using string interpolation, a more readable syntax to embed the string representation of a value in a larger string. For more information, see String interpolation.

Implementing ICustomFormatter and IFormatProvider to provide a complete custom formatting solution. For more information, see the Custom Formatting with ICustomFormatter section.

Default formatting using the ToString method:
--------------------------------------------
Every type that is derived from System.Object automatically inherits a parameterless ToString method, which returns the name of the type by default. The following example illustrates the default ToString method. It defines a class named Automobile that has no implementation. When the class is instantiated and its ToString method is called, it displays its type name. Note that the ToString method is not explicitly called in the example. The Console.WriteLine(Object) method implicitly calls the ToString method of the object passed to it as an argument.

Because all types other than interfaces are derived from Object, this functionality is automatically provided to your custom classes or structures. However, the functionality offered by the default ToString method, is limited: Although it identifies the type, it fails to provide any information about an instance of the type. To provide a string representation of an object that provides information about that object, you must override the ToString method.

Override the ToString method:
------------------------------
Displaying the name of a type is often of limited use and does not allow consumers of your types to differentiate one instance from another. However, you can override the ToString method to provide a more useful representation of an object's value.
Type	ToString override
Boolean	Returns either Boolean.TrueString or Boolean.FalseString.
Byte	Calls Byte.ToString("G", NumberFormatInfo.CurrentInfo) to format the Byte value for the current culture.
Char	Returns the character as a string.
DateTime	Calls DateTime.ToString("G", DatetimeFormatInfo.CurrentInfo) to format the date and time value for the current culture.
Decimal	Calls Decimal.ToString("G", NumberFormatInfo.CurrentInfo) to format the Decimal value for the current culture.
Double	Calls Double.ToString("G", NumberFormatInfo.CurrentInfo) to format the Double value for the current culture.
Int16	Calls Int16.ToString("G", NumberFormatInfo.CurrentInfo) to format the Int16 value for the current culture.
Int32	Calls Int32.ToString("G", NumberFormatInfo.CurrentInfo) to format the Int32 value for the current culture.
Int64	Calls Int64.ToString("G", NumberFormatInfo.CurrentInfo) to format the Int64 value for the current culture.
SByte	Calls SByte.ToString("G", NumberFormatInfo.CurrentInfo) to format the SByte value for the current culture.
Single	Calls Single.ToString("G", NumberFormatInfo.CurrentInfo) to format the Single value for the current culture.
UInt16	Calls UInt16.ToString("G", NumberFormatInfo.CurrentInfo) to format the UInt16 value for the current culture.
UInt32	Calls UInt32.ToString("G", NumberFormatInfo.CurrentInfo) to format the UInt32 value for the current culture.
UInt64	Calls UInt64.ToString("G", NumberFormatInfo.CurrentInfo) to format the UInt64 value for the current culture.

The ToString method and format strings:
---------------------------------------
Relying on the default ToString method or overriding ToString is appropriate when an object has a single string representation. However, the value of an object often has multiple representations. For example, a temperature can be expressed in degrees Fahrenheit, degrees Celsius, or kelvins. Similarly, the integer value 10 can be represented in numerous ways, including 10, 10.0, 1.0e01, or $10.00.

To enable a single value to have multiple string representations, .NET uses format strings. A format string is a string that contains one or more predefined format specifiers, which are single characters or groups of characters that define how the ToString method should format its output. The format string is then passed as a parameter to the object's ToString method and determines how the string representation of that object's value should appear.

All numeric types, date and time types, and enumeration types in .NET support a predefined set of format specifiers. You can also use format strings to define multiple string representations of your application-defined data types.

========================================================================================================================================================================================================

Standard format strings:
-----------------------
A standard format string contains a single format specifier, which is an alphabetic character that defines the string representation of the object to which it is applied, along with an optional precision specifier that affects how many digits are displayed in the result string. If the precision specifier is omitted or is not supported, a standard format specifier is equivalent to a standard format string.

.NET defines a set of standard format specifiers for all numeric types, all date and time types, and all enumeration types. For example, each of these categories supports a "G" standard format specifier, which defines a general string representation of a value of that type.

Standard format strings for enumeration types directly control the string representation of a value. The format strings passed to an enumeration value's ToString method determine whether the value is displayed using its string name (the "G" and "F" format specifiers), its underlying integral value (the "D" format specifier), or its hexadecimal value (the "X" format specifier). 

Standard format strings for numeric types usually define a result string whose precise appearance is controlled by one or more property values. For example, the "C" format specifier formats a number as a currency value. When you call the ToString method with the "C" format specifier as the only parameter, the following property values from the current culture's NumberFormatInfo object are used to define the string representation of the numeric value:

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

In addition, numeric format strings may include a precision specifier. The meaning of this specifier depends on the format string with which it is used, but it typically indicates either the total number of digits or the number of fractional digits that should appear in the result string. For example, the following example uses the "X4" standard numeric string and a precision specifier to create a string value that has four hexadecimal digits.

====================================================================================================================================================================================================

Custom format strings:
---------------------
In addition to the standard format strings, .NET defines custom format strings for both numeric values and date and time values. A custom format string consists of one or more custom format specifiers that define the string representation of a value. For example, the custom date and time format string "yyyy/mm/dd hh:mm:ss.ffff t zzz" converts a date to its string representation in the form "2008/11/15 07:45:00.0000 P -08:00" for the en-US culture. Similarly, the custom format string "0000" converts the integer value 12 to "0012". For a complete list of custom format strings, see Custom Date and Time Format Strings and Custom Numeric Format Strings.

Format strings and .NET types
All numeric types (that is, the Byte, Decimal, Double, Int16, Int32, Int64, SByte, Single, UInt16, UInt32, UInt64, and BigInteger types), as well as the DateTime, DateTimeOffset, TimeSpan, Guid, and all enumeration types, support formatting with format strings. For information on the specific format strings supported by each type, see the following topics:

Title	Definition
Standard Numeric Format Strings	Describes standard format strings that create commonly used string representations of numeric values.
Custom Numeric Format Strings	Describes custom format strings that create application-specific formats for numeric values.
Standard Date and Time Format Strings	Describes standard format strings that create commonly used string representations of DateTime and DateTimeOffset values.
Custom Date and Time Format Strings	Describes custom format strings that create application-specific formats for DateTime and DateTimeOffset values.
Standard TimeSpan Format Strings	Describes standard format strings that create commonly used string representations of time intervals.
Custom TimeSpan Format Strings	Describes custom format strings that create application-specific formats for time intervals.
Enumeration Format Strings	Describes standard format strings that are used to create string representations of enumeration values.
Guid.ToString(String)	Describes standard format strings for Guid values.

============================================================================================================================================

Culture-sensitive formatting with format providers:
------------------------------------------------------
Although format specifiers let you customize the formatting of objects, producing a meaningful string representation of objects often requires additional formatting information. For example, formatting a number as a currency value by using either the "C" standard format string or a custom format string such as "$ #,#.00" requires, at a minimum, information about the correct currency symbol, group separator, and decimal separator to be available to include in the formatted string. In .NET, this additional formatting information is made available through the IFormatProvider interface, which is provided as a parameter to one or more overloads of the ToString method of numeric types and date and time types. IFormatProvider implementations are used in .NET to support culture-specific formatting.

.NET provides three classes that implement IFormatProvider:

DateTimeFormatInfo, a class that provides formatting information for date and time values for a specific culture. Its IFormatProvider.GetFormat implementation returns an instance of itself.

NumberFormatInfo, a class that provides numeric formatting information for a specific culture. Its IFormatProvider.GetFormat implementation returns an instance of itself.

CultureInfo. Its IFormatProvider.GetFormat implementation can return either a NumberFormatInfo object to provide numeric formatting information or a DateTimeFormatInfo object to provide formatting information for date and time values.

You can also implement your own format provider to replace any one of these classes. However, your implementation's GetFormat method must return an object of the type listed in the previous table if it has to provide formatting information to the ToString method.

Culture-sensitive formatting of numeric values:
-------------------------------------------------
By default, the formatting of numeric values is culture-sensitive. If you do not specify a culture when you call a formatting method, the formatting conventions of the current culture are used. This is illustrated in the following example, which changes the current culture four times and then calls the Decimal.ToString(String) method. In each case, the result string reflects the formatting conventions of the current culture. This is because the ToString and ToString(String) methods wrap calls to each numeric type's ToString(String, IFormatProvider) method.

You can also format a numeric value for a specific culture by calling a ToString overload that has a provider parameter and passing it either of the following:

    A CultureInfo object that represents the culture whose formatting conventions are to be used. Its CultureInfo.GetFormat method returns the value of the CultureInfo.NumberFormat property, which is the NumberFormatInfo object that provides culture-specific formatting information for numeric values.
    A NumberFormatInfo object that defines the culture-specific formatting conventions to be used. Its GetFormat method returns an instance of itself.

Culture-sensitive formatting of date and time values:
-----------------------------------------------------
By default, the formatting of date and time values is culture-sensitive. If you do not specify a culture when you call a formatting method, the formatting conventions of the current culture are used. This is illustrated in the following example, which changes the current culture four times and then calls the DateTime.ToString(String) method. In each case, the result string reflects the formatting conventions of the current culture. This is because the DateTime.ToString(), DateTime.ToString(String), DateTimeOffset.ToString(), and DateTimeOffset.ToString(String) methods wrap calls to the DateTime.ToString(String, IFormatProvider) and DateTimeOffset.ToString(String, IFormatProvider) methods.

You can also format a date and time value for a specific culture by calling a DateTime.ToString or DateTimeOffset.ToString overload that has a provider parameter and passing it either of the following:

A CultureInfo object that represents the culture whose formatting conventions are to be used. Its CultureInfo.GetFormat method returns the value of the CultureInfo.DateTimeFormat property, which is the DateTimeFormatInfo object that provides culture-specific formatting information for date and time values.

A DateTimeFormatInfo object that defines the culture-specific formatting conventions to be used. Its GetFormat method returns an instance of itself.

Composite formatting:
----------------------
Some methods, such as String.Format and StringBuilder.AppendFormat, support composite formatting. A composite format string is a kind of template that returns a single string that incorporates the string representation of zero, one, or more objects. Each object is represented in the composite format string by an indexed format item. The index of the format item corresponds to the position of the object that it represents in the method's parameter list. Indexes are zero-based.


**/
namespace StringFormating{
    public class Temperature
    {
    private decimal m_Temp;

    public Temperature(decimal temperature)
    {
        this.m_Temp = temperature;
    }

    public decimal Celsius
    {
        get { return this.m_Temp; }
    }

    public decimal Kelvin
    {
        get { return this.m_Temp + 273.15m; }
    }

    public decimal Fahrenheit
    {
        get { return Math.Round(((decimal) (this.m_Temp * 9 / 5 + 32)), 2); }
    }

    public override string ToString()
    {
        return this.ToString("C");
    }

    public string ToString(string format)
    {
        // Handle null or empty string.
        if (String.IsNullOrEmpty(format)) format = "C";
        // Remove spaces and convert to uppercase.
        format = format.Trim().ToUpperInvariant();

        // Convert temperature to Fahrenheit and return string.
        switch (format)
        {
            // Convert temperature to Fahrenheit and return string.
            case "F":
                return this.Fahrenheit.ToString("N2") + " °F";
            // Convert temperature to Kelvin and return string.
            case "K":
                return this.Kelvin.ToString("N2") + " K";
            // return temperature in Celsius.
            case "G":
            case "C":
                return this.Celsius.ToString("N2") + " °C";
            default:
                throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
        }
    }
    }

    class OverviewFormatClass{
        public static void Main(){
            Console.WriteLine("Overview of String Formating.");

            //Defining format specifiers that enable the string representation of an object's value to take multiple forms. For example, the "X" format specifier in the following statement converts an integer to the string representation of a hexadecimal value.
            int integerValue = 60312;
            Console.WriteLine(integerValue.ToString("X"));   // Displays EB98.

            //Using format providers to implement the formatting conventions of a specific culture. For example, the following statement displays a currency value by using the formatting conventions of the en-US culture.
            double cost = 1632.54;
            Console.WriteLine(cost.ToString("C",
                            new System.Globalization.CultureInfo("en-US")));
            // The example displays the following output:
            //       $1,632.54

            DayOfWeek thisDay = DayOfWeek.Monday;
            string[] formatStrings = {"G", "F", "D", "X"};

            foreach (string formatString in formatStrings)
            Console.WriteLine(thisDay.ToString(formatString));
            // The example displays the following output:
            //       Monday
            //       Monday
            //       1
            //       00000001

            byte[] byteValues = { 12, 163, 255 };
            foreach (byte byteValue in byteValues)
            Console.WriteLine(byteValue.ToString("X4"));
            // The example displays the following output:
            //       000C
            //       00A3
            //       00FF

            DateTime date1 = new DateTime(2009, 6, 30);
            Console.WriteLine($"D Format Specifier:     {date1:D}");
            string longPattern = CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern;
            Console.WriteLine($"'{longPattern}' custom format string:     {date1.ToString(longPattern)}");

            Temperature temp1 = new Temperature(0m);
            Console.WriteLine(temp1.ToString());
            Console.WriteLine(temp1.ToString("G"));
            Console.WriteLine(temp1.ToString("C"));
            Console.WriteLine(temp1.ToString("F"));
            Console.WriteLine(temp1.ToString("K"));

            Temperature temp2 = new Temperature(-40m);
            Console.WriteLine(temp2.ToString());
            Console.WriteLine(temp2.ToString("G"));
            Console.WriteLine(temp2.ToString("C"));
            Console.WriteLine(temp2.ToString("F"));
            Console.WriteLine(temp2.ToString("K"));

            Temperature temp3 = new Temperature(16m);
            Console.WriteLine(temp3.ToString());
            Console.WriteLine(temp3.ToString("G"));
            Console.WriteLine(temp3.ToString("C"));
            Console.WriteLine(temp3.ToString("F"));
            Console.WriteLine(temp3.ToString("K"));

            Console.WriteLine(String.Format("The temperature is now {0:F}.", temp3));


            //Custom Format string
            //=======================

            //If a format string consists of a single custom format specifier, the format specifier should be preceded by the percent (%) symbol to avoid confusion with a standard format specifier. The following example uses the "M" custom format specifier to display a one-digit or two-digit number of the month of a particular date.
            date1 = new DateTime(2009, 9, 8);
            Console.WriteLine(date1.ToString("%M"));       // Displays 9

            //Many standard format strings for date and time values are aliases for custom format strings that are defined by properties of the DateTimeFormatInfo object. Custom format strings also offer considerable flexibility in providing application-defined formatting for numeric values or date and time values. You can define your own custom result strings for both numeric values and date and time values by combining multiple custom format specifiers into a single custom format string. The following example defines a custom format string that displays the day of the week in parentheses after the month name, day, and year.
            string customFormat = "MMMM dd, yyyy (dddd)";
            date1 = new DateTime(2009, 8, 28);
            Console.WriteLine(date1.ToString(customFormat));
            // The example displays the following output if run on a system
            // whose language is English:
            //       August 28, 2009 (Friday)

            //Culture Specific Format
            decimal value = 1603.42m;
            Console.WriteLine(value.ToString("C3", new CultureInfo("en-US")));
            Console.WriteLine(value.ToString("C3", new CultureInfo("fr-FR")));
            Console.WriteLine(value.ToString("C3", new CultureInfo("de-DE")));

            //The IFormatProvider interface includes one method, GetFormat(Type), which has a single parameter that specifies the type of object that provides formatting information. If the method can provide an object of that type, it returns it. Otherwise, it returns a null reference (Nothing in Visual Basic).
            // IFormatProvider.GetFormat is a callback method. When you call a ToString method overload that includes an IFormatProvider parameter, it calls the GetFormat method of that IFormatProvider object. The GetFormat method is responsible for returning an object that provides the necessary formatting information, as specified by its formatType parameter, to the ToString method.
            // A number of formatting or string conversion methods include a parameter of type IFormatProvider, but in many cases the value of the parameter is ignored when the method is called. The following table lists some of the formatting methods that use the parameter and the type of the Type object that they pass to the IFormatProvider.GetFormat method.


            string[] cultureNames = { "en-US", "fr-FR", "es-MX", "de-DE" };
            Decimal value1 = 1043.17m;

            foreach (var cultureName in cultureNames) {
                // Change the current culture.
                CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
                Console.WriteLine($"The current culture is {CultureInfo.CurrentCulture.Name}");
                Console.WriteLine(value1.ToString("C2"));
                Console.WriteLine();
            }

            string[] cultureNames1 = { "en-US", "fr-FR", "es-MX", "de-DE" };
            DateTime dateToFormat = new DateTime(2012, 5, 28, 11, 30, 0);

            foreach (var cultureName in cultureNames1) {
                // Change the current culture.
                CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
                Console.WriteLine($"The current culture is {CultureInfo.CurrentCulture.Name}");
                Console.WriteLine(dateToFormat.ToString("F"));
                Console.WriteLine();
            }




        }
    }
}