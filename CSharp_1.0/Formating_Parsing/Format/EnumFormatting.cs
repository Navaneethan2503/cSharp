using System;
/**
You can use the Enum.ToString method to create a new string object that represents the numeric, hexadecimal, or string value of an enumeration member. This method takes one of the enumeration formatting strings to specify the value that you want returned.

The following sections list the enumeration formatting strings and the values they return. These format specifiers aren't case-sensitive.

G or g
Displays the enumeration entry as a string value, if possible, and otherwise displays the integer value of the current instance. If the enumeration is defined with the FlagsAttribute set, the string values of each valid entry are concatenated together, separated by commas. If the Flags attribute isn't set, an invalid value is displayed as a numeric entry. 

F or f
Displays the enumeration entry as a string value, if possible. If the value can be displayed as a summation of the entries in the enumeration (even if the Flags attribute isn't present), the string values of each valid entry are concatenated together, separated by commas. If the value can't be determined by the enumeration entries, then the value is formatted as the integer value.

D or d
Displays the enumeration entry as an integer value in the shortest representation possible.

X or x
Displays the enumeration entry as a hexadecimal value. The value is represented with leading zeros as necessary, to ensure that the result string has two characters for each byte in the enumeration type's underlying numeric type. The following example illustrates the X format specifier.


**/
namespace FormattableString{
    class EnumFormattingClass{
        public enum Color { Red = 1, Blue = 2, Green = 3 };
        public static void Main(){
            Console.WriteLine("Enum Formatting .");
            Color myColor = Color.Green;
            Console.WriteLine($"The value of myColor is {myColor.ToString("G")}.");
            Console.WriteLine($"The value of myColor is {myColor.ToString("F")}.");
            Console.WriteLine($"The value of myColor is {myColor.ToString("D")}.");
            Console.WriteLine($"The value of myColor is 0x{myColor.ToString("X")}.");
            // The example displays the following output to the console:
            //       The value of myColor is Green.
            //       The value of myColor is Green.
            //       The value of myColor is 3.
            //       The value of myColor is 0x00000003.
        }
    }
}