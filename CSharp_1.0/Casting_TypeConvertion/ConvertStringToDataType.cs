using System;
/**
You convert a string to a number by calling the Parse or TryParse method found on numeric types (int, long, double, and so on), or by using methods in the System.Convert class.

It's slightly more efficient and straightforward to call a TryParse method (for example, int.TryParse("11", out number)) or Parse method (for example, var number = int.Parse("11")). Using a Convert method is more useful for general objects that implement IConvertible.

You use Parse or TryParse methods on the numeric type you expect the string contains, such as the System.Int32 type. The Convert.ToInt32 method uses Parse internally. The Parse method returns the converted number; the TryParse method returns a boolean value that indicates whether the conversion succeeded, and returns the converted number in an out parameter. If the string isn't in a valid format, Parse throws an exception, but TryParse returns false. When calling a Parse method, you should always use exception handling to catch a FormatException when the parse operation fails.

Call Parse or TryParse methods:
-------------------------------
The Parse and TryParse methods ignore white space at the beginning and at the end of the string, but all other characters must be characters that form the appropriate numeric type (int, long, ulong, float, decimal, and so on). Any white space within the string that forms the number causes an error. For example, you can use decimal.TryParse to parse "10", "10.3", or " 10 ", but you can't use this method to parse 10 from "10X", "1 0" (note the embedded space), "10 .3" (note the embedded space), "10e1" (float.TryParse works here), and so on. 
A string whose value is null or String.Empty fails to parse successfully. You can check for a null or empty string before attempting to parse it by calling the String.IsNullOrEmpty method.

Convert Class:
-----------------
Converts a base data type to another base data type.
    public static class Convert


Fields:
------
DBNull - A constant that represents a database column that is absent of data; that is, database null.

Call Convert methods:
------------------------
The following table lists some of the methods from the Convert class that you can use to convert a string to a number.

Numeric type	Method
decimal	ToDecimal(String)
float	ToSingle(String)
double	ToDouble(String)
short	ToInt16(String)
int	ToInt32(String)
long	ToInt64(String)
ushort	ToUInt16(String)
uint	ToUInt32(String)
ulong	ToUInt64(String)


ChangeType(Object, Type) - Returns an object of the specified type and whose value is equivalent to the specified object.
    public static object? ChangeType(object? value, Type conversionType);
FromBase64String(String) - Converts the specified string, which encodes binary data as base-64 digits, to an equivalent 8-bit unsigned integer array.
    public static byte[] FromBase64String(string s);
FromHexString(String)- converts the specified string, which encodes binary data as hex characters, to an equivalent 8-bit unsigned integer array.
ToBase64String(Byte[])	- Converts an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits.
ToBase64CharArray(Byte[], Int32, Int32, Char[], Int32)	- Converts a subset of an 8-bit unsigned integer array to an equivalent subset of a Unicode character array encoded with base-64 digits. Parameters specify the subsets as offsets in the input and output arrays, and the number of elements in the input array to convert.

ToHexString(Byte[])	- Converts an array of 8-bit unsigned integers to its equivalent string representation that is encoded with uppercase hex characters
    public static string ToHexString(byte[] inArray);
    
**/
namespace CastingTypeConvertion{
    class ConvertStringToDataType{
        public static void Main(){
            Console.WriteLine("Convert String representation of numbers to specified numeric data types.");
            string input = String.Empty;
            try
            {
                int result1 = Int32.Parse(input);
                Console.WriteLine(result1);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            // Output: Unable to parse ''

            try
            {
                int numVal1 = Int32.Parse("-105");
                Console.WriteLine(numVal1);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            // Output: -105

            if (Int32.TryParse("-105", out int j))
            {
                Console.WriteLine(j);
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
            }
            // Output: -105

            try
            {
                int m = Int32.Parse("abc");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            // Output: Input string was not in a correct format.

            const string inputString = "abc";
            if (Int32.TryParse(inputString, out int numValue))
            {
                Console.WriteLine(numValue);
            }
            else
            {
                Console.WriteLine($"Int32.TryParse could not parse '{inputString}' to an int.");
            }
            // Output: Int32.TryParse could not parse 'abc' to an int.

            //Convert Class:
            int numVal = -1;
            bool repeat = true;

            while (repeat)
            {
                Console.Write("Enter a number between −2,147,483,648 and +2,147,483,647 (inclusive): ");

                string? input1 = "3454";

                // ToInt32 can throw FormatException or OverflowException.
                try
                {
                    numVal = Convert.ToInt32(input1);
                    if (numVal < Int32.MaxValue)
                    {
                        Console.WriteLine($"The new value is {++numVal}");
                    }
                    else
                    {
                        Console.WriteLine("numVal cannot be incremented beyond its current value");
                    }
            }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number cannot fit in an Int32.");
                }

                Console.Write("Go again? Y/N: ");
                string? go = "879879";
                repeat = false;
            }

            //Converts the value of the specified 8-bit signed integer to an equivalent Boolean value.
            sbyte[] numbers = { SByte.MinValue, -1, 0, 10, 100, SByte.MaxValue };
            bool result;

            foreach (sbyte number in numbers)
            {
                result = Convert.ToBoolean(number);
                Console.WriteLine("{0,-5}  -->  {1}", number, result);
            }

            Double d = -2.345;
            int i = (int)Convert.ChangeType(d, typeof(int));

            Console.WriteLine("The double value {0} when converted to an int becomes {1}", d, i);
            
            // Define a byte array.
            byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            Console.WriteLine("The byte array: ");
            Console.WriteLine("   {0}\n", BitConverter.ToString(bytes));

            // Convert the array to a base 64 string.
            string s = Convert.ToBase64String(bytes);
            Console.WriteLine("The base 64 string:\n   {0}\n", s);

            // Restore the byte array.
            byte[] newBytes = Convert.FromBase64String(s);
            Console.WriteLine("The restored byte array: ");
            Console.WriteLine("   {0}\n", BitConverter.ToString(newBytes));
        }
    }
}