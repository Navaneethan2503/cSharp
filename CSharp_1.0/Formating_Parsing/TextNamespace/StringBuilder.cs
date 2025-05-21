
/**
the StringBuilder class is part of the System.Text namespace and is used for manipulating strings in a more efficient way than using regular string concatenation, especially when dealing with large or frequently modified strings.

Why Use StringBuilder?
Strings in C# are immutable, meaning every time you modify a string, a new object is created in memory. This can lead to performance issues when performing many operations. StringBuilder solves this by using a mutable string buffer.

🔸 Key Features
Efficient memory usage for repeated string modifications.
Dynamic resizing of the internal buffer.
Thread-unsafe by default, but can be made thread-safe.

The String object is immutable. Every time you use one of the methods in the System.String class, you create a new string object in memory, which requires a new allocation of space for that new object. In situations where you need to perform repeated modifications to a string, the overhead associated with creating a new String object can be costly.
The System.Text.StringBuilder class can be used when you want to modify a string without creating a new object. For example, using the StringBuilder class can boost performance when concatenating many strings together in a loop.


Importing the System.Text Namespace:
------------------------------------
The StringBuilder class is found in the System.Text namespace. To avoid having to provide a fully qualified type name in your code, you can import the System.Text namespace:

Instantiating a StringBuilder Object:
-------------------------------------
You can create a new instance of the StringBuilder class by initializing your variable with one of the overloaded constructor methods, 

StringBuilder Class
-------------------
Represents a mutable string of characters. This class cannot be inherited.

    public sealed class StringBuilder : System.Runtime.Serialization.ISerializable

Constructors:
-------------
StringBuilder()	- Initializes a new instance of the StringBuilder class.
    public StringBuilder();

StringBuilder(Int32, Int32)	- Initializes a new instance of the StringBuilder class that starts with a specified capacity and can grow to a specified maximum.
    public StringBuilder(int capacity, int maxCapacity);
        Remark:
        --------
        If capacity is zero, the implementation-specific default capacity is used.
        The maxCapacity property defines the maximum number of characters that the current instance can hold. Its value is assigned to the MaxCapacity property. If the number of characters to be stored in the current instance exceeds this maxCapacity value, the StringBuilder object does not allocate additional memory, but instead throws an exception.

StringBuilder(Int32) - Initializes a new instance of the StringBuilder class using the specified capacity.
    public StringBuilder(int capacity);

StringBuilder(String, Int32, Int32, Int32)	- Initializes a new instance of the StringBuilder class from the specified substring and capacity.
    public StringBuilder(string? value, int startIndex, int length, int capacity);

StringBuilder(String, Int32) - Initializes a new instance of the StringBuilder class using the specified string and capacity.
    public StringBuilder(string? value, int capacity);
    
StringBuilder(String)	- Initializes a new instance of the StringBuilder class using the specified string.
    public StringBuilder(string? value);


Properties:
-------------
Capacity- Gets or sets the maximum number of characters that can be contained in the memory allocated by the current instance.
Chars[Int32]	- Gets or sets the character at the specified character position in this instance.
    public char this[int index] { get; set; }
    Using character-based indexing with the Chars[] property can be extremely slow under the following conditions:
    The StringBuilder instance is large (for example, it consists of several tens of thousands of characters).
    The StringBuilder is "chunky." That is, repeated calls to methods such as StringBuilder.Append have automatically expanded the object's StringBuilder.Capacity property and allocated new chunks of memory to it.
    Performance is severely impacted because each character access walks the entire linked list of chunks to find the correct buffer to index into.
    Even for a large "chunky" StringBuilder object, using the Chars[] property for index-based access to one or a small number of characters has a negligible performance impact; typically, it is an O(n) operation. The significant performance impact occurs when iterating the characters in the StringBuilder object, which is an O(n^2) operation.

Length	- Gets or sets the length of the current StringBuilder object.
MaxCapacity	- Gets the maximum capacity of this i


Methods:
----------
Append(Boolean)	- Appends the string representation of a specified Boolean value to this instance.
Append(Byte)	- Appends the string representation of a specified 8-bit unsigned integer to this instance.
Append(Char, Int32)	- Appends a specified number of copies of the string representation of a Unicode character to this instance.
    public System.Text.StringBuilder Append(char value, int repeatCount);
Append(Char)	- Appends the string representation of a specified Char object to this instance.
Append(Char[], Int32, Int32)	- Appends the string representation of a specified subarray of Unicode characters to this instance.
Append(Char[])	- Appends the string representation of the Unicode characters in a specified array to this instance.
Append(Char*, Int32)	- Appends an array of Unicode characters starting at a specified address to this instance.
Append(Decimal)	- Appends the string representation of a specified decimal number to this instance.
Append(Double)	- Appends the string representation of a specified double-precision floating-point number to this instance.
Append(IFormatProvider, StringBuilder+AppendInterpolatedStringHandler)	- Appends the specified interpolated string to this instance using the specified format.
Append(Int16)	- Appends the string representation of a specified 16-bit signed integer to this instance.
Append(Int32)	- Appends the string representation of a specified 32-bit signed integer to this instance.
Append(Int64)	- Appends the string representation of a specified 64-bit signed integer to this instance.
Append(Object)	- Appends the string representation of a specified object to this instance.
Append(ReadOnlyMemory<Char>)	- Appends the string representation of a specified read-only character memory region to this instance.
Append(ReadOnlySpan<Char>)	- Appends the string representation of a specified read-only character span to this instance.
Append(SByte)	- Appends the string representation of a specified 8-bit signed integer to this instance.
Append(Single)	- Appends the string representation of a specified single-precision floating-point number to this instance.
Append(String, Int32, Int32)	- Appends a copy of a specified substring to this instance.
Append(String)	- Appends a copy of the specified string to this instance.
Append(StringBuilder, Int32, Int32)	- Appends a copy of a substring within a specified string builder to this instance.
Append(StringBuilder)	- Appends the string representation of a specified string builder to this instance.
Append(StringBuilder+AppendInterpolatedStringHandler)	- Appends the specified interpolated string to this instance.
Append(UInt16)	-Appends the string representation of a specified 16-bit unsigned integer to this instance.
Append(UInt32)	- Appends the string representation of a specified 32-bit unsigned integer to this instance.
Append(UInt64)	- Appends the string representation of a specified 64-bit unsigned integer to this instance.

AppendFormat(IFormatProvider, CompositeFormat, Object[])-Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of any of the arguments using a specified format provider.
AppendFormat(IFormatProvider, CompositeFormat, ReadOnlySpan<Object>)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of any of the arguments using a specified format provider.
AppendFormat(IFormatProvider, String, Object, Object, Object)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of either of three arguments using a specified format provider.
AppendFormat(IFormatProvider, String, Object, Object)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of either of two arguments using a specified format provider.
AppendFormat(IFormatProvider, String, Object)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of a single argument using a specified format provider.
AppendFormat(IFormatProvider, String, Object[])	-Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of a corresponding argument in a parameter array using a specified format provider.
AppendFormat(IFormatProvider, String, ReadOnlySpan<Object>)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of a corresponding argument in a parameter span using a specified format provider.
AppendFormat(String, Object, Object, Object)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of either of three arguments.
AppendFormat(String, Object, Object)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of either of two arguments.
AppendFormat(String, Object)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of a single argument.
AppendFormat(String, Object[])	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of a corresponding argument in a parameter array.
AppendFormat(String, ReadOnlySpan<Object>)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of a corresponding argument in a parameter span.
AppendFormat<TArg0,TArg1,TArg2>(IFormatProvider, CompositeFormat, TArg0, TArg1, TArg2)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of any of the arguments using a specified format provider.
AppendFormat<TArg0,TArg1>(IFormatProvider, CompositeFormat, TArg0, TArg1)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of any of the arguments using a specified format provider.
AppendFormat<TArg0>(IFormatProvider, CompositeFormat, TArg0)	- Appends the string returned by processing a composite format string, which contains zero or more format items, to this instance. Each format item is replaced by the string representation of any of the arguments using a specified format provider.

AppendJoin(Char, Object[])	- Concatenates the string representations of the elements in the provided array of objects, using the specified char separator between each member, then appends the result to the current instance of the string builder.
AppendJoin(Char, ReadOnlySpan<Object>)	- Concatenates the string representations of the elements in the provided span of objects, using the specified char separator between each member, then appends the result to the current instance of the string builder.
AppendJoin(Char, ReadOnlySpan<String>)	- Concatenates the strings of the provided span, using the specified char separator between each string, then appends the result to the current instance of the string builder.
AppendJoin(Char, String[])	- Concatenates the strings of the provided array, using the specified char separator between each string, then appends the result to the current instance of the string builder.
AppendJoin(String, Object[])	- Concatenates the string representations of the elements in the provided array of objects, using the specified separator between each member, then appends the result to the current instance of the string builder.
AppendJoin(String, ReadOnlySpan<Object>)	- Concatenates the string representations of the elements in the provided span of objects, using the specified separator between each member, then appends the result to the current instance of the string builder.
AppendJoin(String, ReadOnlySpan<String>)	- Concatenates the strings of the provided span, using the specified separator between each string, then appends the result to the current instance of the string builder.
AppendJoin(String, String[])	- Concatenates the strings of the provided array, using the specified separator between each string, then appends the result to the current instance of the string builder.
AppendJoin<T>(Char, IEnumerable<T>)	- Concatenates and appends the members of a collection, using the specified char separator between each member.
AppendJoin<T>(String, IEnumerable<T>)	- Concatenates and appends the members of a collection, using the specified separator between each member.

AppendLine()	- Appends the default line terminator to the end of the current StringBuilder object.
AppendLine(IFormatProvider, StringBuilder+AppendInterpolatedStringHandler)	- Appends the specified interpolated string using the specified format, followed by the default line terminator, to the end of the current StringBuilder object.
AppendLine(String)	- Appends a copy of the specified string followed by the default line terminator to the end of the current StringBuilder object.
AppendLine(StringBuilder+AppendInterpolatedStringHandler)	- Appends the specified interpolated string followed by the default line terminator to the end of the current StringBuilder object.

Clear()	- Removes all characters from the current StringBuilder instance.
    public System.Text.StringBuilder Clear();

CopyTo(Int32, Char[], Int32, Int32)	- Copies the characters from a specified segment of this instance to a specified segment of a destination Char array.
    public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count);

CopyTo(Int32, Span<Char>, Int32) - Copies the characters from a specified segment of this instance to a destination Char span.

EnsureCapacity(Int32)	- Ensures that the capacity of this instance of StringBuilder is at least the specified value.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Equals(ReadOnlySpan<Char>)	- Returns a value indicating whether the characters in this instance are equal to the characters in a specified read-only character span.
Equals(StringBuilder)	- Returns a value indicating whether this instance is equal to a specified object.
    public bool Equals(System.Text.StringBuilder? sb);

GetChunks()	-Returns an object that can be used to iterate through the chunks of characters represented in a ReadOnlyMemory<Char> created from this StringBuilder instance.

GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)

Insert(Int32, Boolean)	- Inserts the string representation of a Boolean value into this instance at the specified character position.
Insert(Int32, Byte)	- Inserts the string representation of a specified 8-bit unsigned integer into this instance at the specified character position.
Insert(Int32, Char)	- Inserts the string representation of a specified Unicode character into this instance at the specified character position.
Insert(Int32, Char[], Int32, Int32)	- Inserts the string representation of a specified subarray of Unicode characters into this instance at the specified character position.
Insert(Int32, Char[])	- Inserts the string representation of a specified array of Unicode characters into this instance at the specified character position.
Insert(Int32, Decimal)	- Inserts the string representation of a decimal number into this instance at the specified character position.
Insert(Int32, Double)	- Inserts the string representation of a double-precision floating-point number into this instance at the specified character position.
Insert(Int32, Int16)	- Inserts the string representation of a specified 16-bit signed integer into this instance at the specified character position.
Insert(Int32, Int32)	- Inserts the string representation of a specified 32-bit signed integer into this instance at the specified character position.
Insert(Int32, Int64)	- Inserts the string representation of a 64-bit signed integer into this instance at the specified character position.
Insert(Int32, Object)	- Inserts the string representation of an object into this instance at the specified character position.
Insert(Int32, ReadOnlySpan<Char>)	- Inserts the sequence of characters into this instance at the specified character position.
Insert(Int32, SByte)	- Inserts the string representation of a specified 8-bit signed integer into this instance at the specified character position.
Insert(Int32, Single)	- Inserts the string representation of a single-precision floating point number into this instance at the specified character position.
Insert(Int32, String, Int32)	- Inserts one or more copies of a specified string into this instance at the specified character position.
Insert(Int32, String)	- Inserts a string into this instance at the specified character position.
Insert(Int32, UInt16)	- Inserts the string representation of a 16-bit unsigned integer into this instance at the specified character position.
Insert(Int32, UInt32)	- Inserts the string representation of a 32-bit unsigned integer into this instance at the specified character position.
Insert(Int32, UInt64)	- Inserts the string representation of a 64-bit unsigned integer into this instance at the specified character position.
    public System.Text.StringBuilder Insert(int index, string? value);

MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)

Remove(Int32, Int32)	- Removes the specified range of characters from this instance.
    public System.Text.StringBuilder Remove(int startIndex, int length);

Replace(Char, Char, Int32, Int32)	- Replaces, within a substring of this instance, all occurrences of a specified character with another specified character.
Replace(Char, Char)	- Replaces all occurrences of a specified character in this instance with another specified character.
    public System.Text.StringBuilder Replace(char oldChar, char newChar);

Replace(ReadOnlySpan<Char>, ReadOnlySpan<Char>, Int32, Int32)	- Replaces all instances of one read-only character span with another in part of this builder.
Replace(ReadOnlySpan<Char>, ReadOnlySpan<Char>)	- Replaces all instances of one read-only character span with another in this builder.
Replace(String, String, Int32, Int32)	- Replaces, within a substring of this instance, all occurrences of a specified string with another specified string.
    public System.Text.StringBuilder Replace(char oldChar, char newChar, int startIndex, int count);

Replace(String, String)	- Replaces all occurrences of a specified string in this instance with another specified string.
    public System.Text.StringBuilder Replace(string oldValue, string? newValue);

ToString()	- Converts the value of this instance to a String.
ToString(Int32, Int32)	- Converts the value of a substring of this instance to a String.
    public string ToString(int startIndex, int length);
    
**/
using System;
using System.Text;
using System.Globalization;

namespace StringBuilderText{
    class StringBuilderClass{
        public static void Main(){
            Console.WriteLine("String Builder ");

            StringBuilder sb1 = new StringBuilder("Hello World!");
            sb1.Append(" My Dear");
            Console.WriteLine(sb1.ToString());

            // Create a StringBuilder that expects to hold 50 characters.
            // Initialize the StringBuilder with "ABC".
            StringBuilder sb = new StringBuilder("ABC", 50);

            // Append three characters (D, E, and F) to the end of the StringBuilder.
            sb.Append(new char[] { 'D', 'E', 'F' });

            // Append a format string to the end of the StringBuilder.
            sb.AppendFormat("GHI{0}{1}", 'J', 'k');

            // Display the number of characters in the StringBuilder and its string.
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());

            // Insert a string at the beginning of the StringBuilder.
            sb.Insert(0, "Alphabet: ");

            // Replace all lowercase k's with uppercase K's.
            sb.Replace('k', 'K');

            // Display the number of characters in the StringBuilder and its string.
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());

            string initialString = "Initial string for stringbuilder.";
            int startIndex = 0;
            int substringLength = 14;
            int capacity = 255;
            StringBuilder stringBuilder = new StringBuilder(initialString, 
                startIndex, substringLength, capacity);
            Console.WriteLine(stringBuilder);
            Console.WriteLine("Index accessed : "+stringBuilder[1]);

            float value = 1034769.47f;
            System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
            sb2.Append('*', 5).Append(value).Append('*', 5);
            Console.WriteLine(sb2);
            // The example displays the following output:
            //       *****1034769.47*****

            //Decimal value = 16.95m;
            CultureInfo enGB = CultureInfo.CreateSpecificCulture("en-GB");
            DateTime dateToday = DateTime.Now;
            sb.AppendFormat(enGB, "Final Price: {0:C2}", value);
            sb.AppendLine();
            sb.AppendFormat(enGB, "Date and Time: {0:d} at {0:t}", dateToday);
            Console.WriteLine(sb.ToString());

            char[] dest = new char[6];
            StringBuilder src = new StringBuilder("abcdefghijklmnopqrstuvwxyz!");
            dest[1] = ')';
            dest[2] = ' ';

            // Copy the source to the destination in 9 pieces, 3 characters per piece.

            Console.WriteLine("\nPiece) Data:");
            for(int ix = 0; ix < 9; ix++)
                {
                dest[0] = ix.ToString()[0];
                src.CopyTo(ix * 3, dest, 3, 3);
                Console.Write("    ");
                Console.WriteLine(dest);
            }

            Console.WriteLine("Get Chucks Methods :");
            foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
            {
                var span = chunk.Span;
                for(int i = 0; i < span.Length; i++)
                {
                    Console.Write(span[i]+",");
                }
            }
            Console.WriteLine();
            

        }
    }
}