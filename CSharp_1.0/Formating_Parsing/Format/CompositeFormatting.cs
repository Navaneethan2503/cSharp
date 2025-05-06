using System;
/**
Composite format string:
-----------------------
A composite format string and object list are used as arguments of methods that support the composite formatting feature. A composite format string consists of zero or more runs of fixed text intermixed with one or more format items. The fixed text is any string that you choose, and each format item corresponds to an object or boxed structure in the list. The string representation of each object replaces the corresponding format item
    string.Format("Name = {0}, hours = {1:hh}", "Fred", DateTime.Now);
    The fixed text is Name =  and , hours = . The format items are {0}, whose index of 0 corresponds to the object name, and {1:hh}, whose index of 1 corresponds to the object DateTime.Now.

Format item syntax:
-------------------
Each format item takes the following form and consists of the following components:

{index[,width][:formatString]}

The matching braces ({ and }) are required.

Index component:
----------------
The mandatory index component, which is also called a parameter specifier, is a number starting from 0 that identifies a corresponding item in the list of objects. That is, the format item whose parameter specifier is 0 formats the first object in the list. The format item whose parameter specifier is 1 formats the second object in the list, and so on.

Width component:
-----------------
The optional width component is a signed integer indicating the preferred formatted field width. If the value of width is less than the length of the formatted string, width is ignored, and the length of the formatted string is used as the field width. The formatted data in the field is right-aligned if width is positive and left-aligned if width is negative. If padding is necessary, white space is used. The comma is required if width is specified.


Format string component:
------------------------
The optional formatString component is a format string that's appropriate for the type of object being formatted. You can specify:

A standard or custom numeric format string if the corresponding object is a numeric value.
A standard or custom date and time format string if the corresponding object is a DateTime object.
An enumeration format string if the corresponding object is an enumeration value.
If formatString isn't specified, the general ("G") format specifier for a numeric, date and time, or enumeration type is used. The colon is required if formatString is specified.

Escaping braces:
------------------
Opening and closing braces are interpreted as starting and ending a format item. To display a literal opening brace or closing brace, you must use an escape sequence. Specify two opening braces ({{) in the fixed text to display one opening brace ({), or two closing braces (}}) to display one closing brace (}).

The following methods support the composite formatting feature:
    String.Format, which returns a formatted result string.
    StringBuilder.AppendFormat, which appends a formatted result string to a StringBuilder object.
    Some overloads of the Console.WriteLine method, which display a formatted result string to the console.
    Some overloads of the TextWriter.WriteLine method, which write the formatted result string to a stream or file. The classes derived from TextWriter, such as StreamWriter and HtmlTextWriter, also share this functionality.
    Debug.WriteLine(String, Object[]), which outputs a formatted message to trace listeners.
    The Trace.TraceError(String, Object[]), Trace.TraceInformation(String, Object[]), and Trace.TraceWarning(String, Object[]) methods, which output formatted messages to trace listeners.
    The TraceSource.TraceInformation(String, Object[]) method, which writes an informational method to trace listeners.


**/
namespace FormattableString{
    class CompositeFormattingClass{
        public static void Main(){
            Console.WriteLine("Composite Formatting .");
            string primes = string.Format("Four prime numbers: {0}, {1}, {2}, {3}",
                              2, 3, 5, 7);
            Console.WriteLine(primes);

            // The example displays the following output:
            //      Four prime numbers: 2, 3, 5, 7

            //Multiple format items can refer to the same element in the list of objects by specifying the same parameter specifier. For example, you can format the same numeric value in hexadecimal, scientific, and number format by specifying a composite format string such as "0x{0:X} {0:E} {0:N}",
            string multiple = string.Format("0x{0:X} {0:E} {0:N}",
                                Int64.MaxValue);
            Console.WriteLine(multiple);

            // The example displays the following output:
            //      0x7FFFFFFFFFFFFFFF 9.223372E+018 9,223,372,036,854,775,807.00


            //Width Component
            string[] names = { "Adam", "Bridgette", "Carla", "Daniel",
                   "Ebenezer", "Francine", "George" };
            decimal[] hours = { 40, 6.667m, 40.39m, 82,
                                40.333m, 80, 16.75m };

            Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours");

            for (int counter = 0; counter < names.Length; counter++)
                Console.WriteLine("{0,-20} {1,5:N1}", names[counter], hours[counter]);

            // The example displays the following output:
            //      Name                 Hours
            //      
            //      Adam                  40.0
            //      Bridgette              6.7
            //      Carla                 40.4
            //      Daniel                82.0
            //      Ebenezer              40.3
            //      Francine              80.0
            //      George                16.8

        }
    }
}