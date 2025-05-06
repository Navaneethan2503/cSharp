using System;
/**
Provides a mechanism for retrieving an object to control formatting.

public interface IFormatProvider

Remarks:
---------
The IFormatProvider interface supplies an object that provides formatting information for formatting and parsing operations. Formatting operations convert the value of a type to the string representation of that value. Typical formatting methods are the ToString methods of a type, as well as Format. Parsing operations convert the string representation of a value to a type with that value. Typical parsing methods are Parse and TryParse.

The IFormatProvider interface consists of a single method, IFormatProvider.GetFormat. GetFormat is a callback method: The parsing or formatting method calls it and passes it a Type object that represents the type of object that the formatting or parsing method expects will provide formatting information. The GetFormat method is responsible for returning an object of that type.

IFormatProvider implementations are often used implicitly by formatting and parsing methods. For example, the DateTime.ToString(String) method implicitly uses an IFormatProvider implementation that represents the system's current culture. IFormatProvider implementations can also be specified explicitly by methods that have a parameter of type IFormatProvider, such as Int32.Parse(String, IFormatProvider) and String.Format(IFormatProvider, String, Object[]).

The .NET Framework includes the following three predefined IFormatProvider implementations to provide culture-specific information that is used in formatting or parsing numeric and date and time values:

The NumberFormatInfo class, which provides information that is used to format numbers, such as the currency, thousands separator, and decimal separator symbols for a particular culture. For information about the predefined format strings recognized by a NumberFormatInfo object and used in numeric formatting operations, see Standard Numeric Format Strings and Custom Numeric Format Strings.

The DateTimeFormatInfo class, which provides information that is used to format dates and times, such as the date and time separator symbols for a particular culture or the order and format of a date's year, month, and day components. For information about the predefined format strings recognized by a DateTimeFormatInfo object and used in numeric formatting operations, see Standard Date and Time Format Strings and Custom Date and Time Format Strings.

The CultureInfo class, which represents a particular culture. Its GetFormat method returns a culture-specific NumberFormatInfo or DateTimeFormatInfo object, depending on whether the CultureInfo object is used in a formatting or parsing operation that involves numbers or dates and times.

The .NET Framework also supports custom formatting. This typically involves the creation of a formatting class that implements both IFormatProvider and ICustomFormatter. An instance of this class is then passed as a parameter to a method that performs a custom formatting operation, such as String.Format(IFormatProvider, String, Object[]) The example provides an illustration of such a custom implementation that formats a number as a 12-digit account number.

Methods:
--------
GetFormat(Type)	- Returns an object that provides formatting services for the specified type.
    public object? GetFormat(Type? formatType);

    formatType: The type of format object you want (e.g., typeof(NumberFormatInfo) or typeof(DateTimeFormatInfo)).
    Returns: An object that provides formatting services for the specified type, or null if the provider cannot supply that type.

    When you pass an IFormatProvider to a method like ToString, Parse, or String.Format, the method internally calls GetFormat to retrieve the appropriate formatting object.


**/
namespace FormatInterfaces{
    class IFormatProviderClass{
        public static void Main(){
            Console.WriteLine("IFormat Providers.");

        }
    }
}

