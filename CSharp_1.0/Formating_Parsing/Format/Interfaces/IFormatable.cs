using System;
using System.Globalization;
/**

Provides functionality to format the value of an object into a string representation.

    public interface IFormattable

This interface is particularly useful when you want to control how an object is converted to a string, especially when different formats are required.
Purpose: The IFormattable interface allows an object to define multiple ways to format itself. This is useful for objects that need to be represented in different formats, such as dates, times, numbers, and custom objects.
Usage: Implementing the IFormattable interface involves defining the ToString method to handle different format strings and format providers.
    Format Strings: The format string specifies the desired format. Common format strings include:
    "G": General format.
    "C": Custom format for Celsius.
    "F": Custom format for Fahrenheit. "`: Custom format for Kelvin.
    Format Providers: The IFormatProvider parameter allows you to specify culture-specific formatting information. This is useful for formatting numbers, dates, and times according to different cultural conventions.

The IFormattable interface converts an object to its string representation based on a format string and a format provider.

A format string typically defines the general appearance of an object. For example, the .NET Framework supports the following:
1. Standard format strings for formatting enumeration values
2. Standard and custom format strings for formatting numeric values 
3. Standard and custom format strings for formatting date and time values
4. Standard and custom format strings for formatting time intervals 


You can also define your own format strings to support formatting of your application-defined types.

A format provider returns a formatting object that typically defines the symbols used in converting an object to its string representation.
The .NET Framework defines three format providers:
1. The System.Globalization.CultureInfo class, which returns either a NumberFormatInfo object for formatting numeric values, or a DateTimeFormatInfo object for formatting date and time values.
2. The System.Globalization.NumberFormatInfo class, which returns an instance of itself for formatting numeric values.
3. The System.Globalization.DateTimeFormatInfo class, which returns an instance of itself for formatting date and time values.
In addition, you can define your own custom format providers to supply culture-specific, profession-specific, or industry-specific information used in formatting.

The IFormattable interface defines a single method, ToString, that supplies formatting services for the implementing type. The ToString method can be called directly. In addition, it is called automatically by the Convert.ToString(Object) and Convert.ToString(Object, IFormatProvider) methods, and by methods that use the composite formatting feature in the .NET Framework. Such methods include Console.WriteLine(String, Object), String.Format, and StringBuilder.AppendFormat(String, Object), among others. The ToString method is called for each format item in the method's format string.

The IFormattable interface is implemented by the base data types.

Classes that require more control over the formatting of strings than ToString() provides should implement IFormattable.

A class that implements IFormattable must support the "G" (general) format specifier. Besides the "G" specifier, the class can define the list of format specifiers that it supports. In addition, the class must be prepared to handle a format specifier that is null.

Methods:
----------
ToString(String, IFormatProvider)	- Formats the value of the current instance using the specified format.

Why were we override the ToString method from the Object class to provide a custom string representation of your object. However, the IFormattable interface offers additional benefits that make it useful in certain scenarios::
-------------------------------------------------------------------------------------------------------------------

Key Differences and Benefits of IFormattable:
----------------------------------------------
Multiple Formatting Options:
---------------------------
ToString Override: When you override the ToString method, you typically provide a single, default string representation of your object.
IFormattable Interface: Allows you to define multiple string representations based on different format strings. This is particularly useful when you need to support various formats (e.g., different date formats, numeric formats, etc.).

Culture-Specific Formatting:
------------------------------
ToString Override: The default ToString method does not inherently support culture-specific formatting.
IFormattable Interface: The ToString method in IFormattable takes an IFormatProvider parameter, which allows you to provide culture-specific formatting. This is essential for applications that need to display data in different cultural contexts.

Integration with Formatting Methods:
-----------------------------------
ToString Override: The overridden ToString method is called explicitly when you want to convert an object to a string.
IFormattable Interface: Objects implementing IFormattable are automatically used by methods like String.Format, Console.WriteLine, and StringBuilder.AppendFormat to provide custom formatting. This integration makes it easier to format objects consistently across your application.


**/
namespace FormatInterfaces{


    public class Temperature : IFormattable
    {
    private decimal temp;

    public Temperature(decimal temperature)
    {
        if (temperature < -273.15m)
            throw new ArgumentOutOfRangeException(String.Format("{0} is less than absolute zero.",
                                                temperature));
        this.temp = temperature;
    }

    public decimal Celsius
    {
        get { return temp; }
    }

    public decimal Fahrenheit
    {
        get { return temp * 9 / 5 + 32; }
    }

    public decimal Kelvin
    {
        get { return temp + 273.15m; }
    }

    public override string ToString()
    {
        return this.ToString("G", CultureInfo.CurrentCulture);
    }

    public string ToString(string format)
    {
        return this.ToString(format, CultureInfo.CurrentCulture);
    }

    public string ToString(string format, IFormatProvider provider)
    {
        if (String.IsNullOrEmpty(format)) format = "G";
        if (provider == null) provider = CultureInfo.CurrentCulture;

        switch (format.ToUpperInvariant())
        {
            case "G":
            case "C":
                return temp.ToString("F2", provider) + " °C";
            case "F":
                return Fahrenheit.ToString("F2", provider) + " °F";
            case "K":
                return Kelvin.ToString("F2", provider) + " K";
            default:
                throw new FormatException(String.Format("The {0} format string is not supported.", format));
        }
    }
    }

    class IFormattableClass{
        public static void Main(){
            Console.WriteLine("IFormattable Interfaces.");
            // Use composite formatting with format string in the format item.
            Temperature temp1 = new Temperature(0);
            Console.WriteLine("{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)\n", temp1);

            // Use composite formatting with a format provider.
            temp1 = new Temperature(-40);
            Console.WriteLine(String.Format(CultureInfo.CurrentCulture, "{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)", temp1));
            Console.WriteLine(String.Format(new CultureInfo("fr-FR"), "{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)\n", temp1));

            // Call ToString method with format string.
            temp1 = new Temperature(32);
            Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)\n",
                                temp1.ToString("C"), temp1.ToString("K"), temp1.ToString("F"));

            // Call ToString with format string and format provider
            temp1 = new Temperature(100)      ;
            NumberFormatInfo current = NumberFormatInfo.CurrentInfo;
            CultureInfo nl = new CultureInfo("nl-NL");
            Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)",
                                temp1.ToString("C", current), temp1.ToString("K", current), temp1.ToString("F", current));
            Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)",
                                temp1.ToString("C", nl), temp1.ToString("K", nl), temp1.ToString("F", nl));

            Console.WriteLine($"Tempature is : {temp1}");

        }
    }
}