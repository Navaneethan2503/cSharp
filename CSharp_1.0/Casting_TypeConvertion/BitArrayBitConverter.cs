using System;
/**
A byte array is a fundamental data structure in computing that represents a sequence of bytes. It is used for various purposes, including data storage, data transmission, and low-level data manipulation. Let's explore why we need byte arrays, what they mean, and what they point to.

Why We Need Byte Arrays
Data Storage
Byte arrays are used to store binary data in memory. This is essential for handling various types of data, such as images, files, and network packets, which are often represented in binary form.

Data Transmission
When transmitting data over a network or between different components of a system, data is often sent as a sequence of bytes. Byte arrays facilitate this process by providing a way to package and unpack data for transmission.

Low-Level Data Manipulation
Byte arrays allow for direct manipulation of binary data. This is useful in scenarios where you need to perform bitwise operations, work with hardware interfaces, or handle data formats that require precise control over individual bytes.

Interoperability
Byte arrays provide a common format for data exchange between different programming languages, systems, and platforms. This ensures that data can be consistently interpreted and processed across different environments.

What Byte Arrays Mean
A byte array is simply an array of bytes, where each byte is an 8-bit unit of data. The array can represent any type of binary data, including text, images, audio, and more. The meaning of the data in the byte array depends on the context in which it is used.

Example: Byte Array Representation
Consider a byte array that represents the ASCII string "Hello":


Each byte in the array corresponds to the ASCII value of a character in the string "Hello":

72 -> 'H'
101 -> 'e'
108 -> 'l'
108 -> 'l'
111 -> 'o'
What Byte Arrays Point To
In memory, a byte array points to a contiguous block of memory where the bytes are stored. The starting address of this block is the address of the first byte in the array. The array provides a way to access and manipulate this block of memory.

Example: Memory Representation
Consider the byte array byteArray from the previous example:

Memory Address:  0x00  0x01  0x02  0x03  0x04
Value:           72    101   108   108   111
The byte array points to the starting address 0x00, and each subsequent byte is stored in the next memory address.
------------------------------------------------------------------------------------------------------------------------------------------------------------------

each element in BitArray Representation of ASCII Value for : String , char

each element in BitArray Representation of Binary form : numeric , floating point, boolean (true - 1, false - 0)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------


Bit Representation:

This example shows you how to use the BitConverter class to convert an array of bytes to an int and back to an array of bytes. You may have to convert from bytes to a built-in data type after you read bytes off the network, for example. In addition to the ToInt32(Byte[], Int32) method in the example, the following table lists methods in the BitConverter class that convert bytes (from an array of bytes) to other built-in types.

BitConverter Class:
---------------------
Converts base data types to an array of bytes, and an array of bytes to base data types.
The BitConverter class in C# is a powerful utility for converting base data types to an array of bytes and vice versa. This is particularly useful for low-level programming tasks, such as network communication, file I/O, and binary data manipulation.

    public static class BitConverter

The BitConverter class helps manipulate value types in their fundamental form, as a series of bytes. A byte is defined as an 8-bit unsigned integer. The BitConverter class includes static methods to convert each of the primitive types to and from an array of bytes,

Binary Representation:
------------------------
The binary representation order refers to the arrangement of bits within a binary number, where each bit represents a power of 2. 

Bit Value : 16, 8,    4,   2,   1
Position  : 4 , 3,    2,   1,   0
power     :2^4, 2^3, 2^2, 2^1, 2^0

Endianness:
-------------
The BitConverter class uses the endianness of the system architecture. Endianness refers to the order of bytes in a binary representation of a number. 
There are two types:
    Little-endian: The least significant byte is stored first.
    Big-endian: The most significant byte is stored first.
You can check the endianness of the system using the BitConverter.IsLittleEndian property.

If systems sending and receiving data can have different endianness and the data to be transmitted consists of signed integers, call the IPAddress.HostToNetworkOrder method to convert the data to network byte order and the IPAddress.NetworkToHostOrder method to convert it to the order required by the recipient.

Memory Order: 0x78 0x56 0x34 0x12
Byte Positions:
LSB: 0x78
Next Byte: 0x56
Next Byte: 0x34
MSB: 0x12

Little-endian: 0x78 0x34 0x34 0x12
Big-endian: 0x12 0x34 0x34 0x78

-------------------------------------------------------------------------------------------------------------
Binary Representation:
------------------------
Each data type has a specific binary representation:
    Boolean: Represented by a single byte (0 or 1).
    Character: Represented by two bytes (Unicode).
    Integer: Represented by two, four, or eight bytes (depending on the size).
    Floating-point: Represented by four or eight bytes (IEEE 754 standard).

Consider the byte array { 0x39, 0x30, 0x00, 0x00 } representing the integer 12345 in little-endian format:
0x39 -> 00111001
0x30 -> 00110000
0x00 -> 00000000
0x00 -> 00000000

Hexadecimal Representation
In hexadecimal:

0x39 means:
3 in the tens place (which is 
3×16=48 
3×16=48)
9 in the ones place (which is 
9 ×1=9
9×1=9)
So, 0x39 in hexadecimal is equivalent to 
48+9=57
48+9=57 in decimal.
-------------------------------------------------------------------------------------------------------

Fields:
--------
IsLittleEndian	- Indicates the byte order ("endianness") in which data is stored in this computer architecture.
        Different computer architectures store data using different byte orders. "Big-endian" means the most significant byte is on the left end of a word. "Little-endian" means the most significant byte is on the right end of a word.
        public static readonly bool IsLittleEndian;


Methods:
----------
Methods for Converting Byte Arrays:
-----------------------------------
The BitConverter class in C# provides methods to convert byte arrays to various data types such as bool, char, int, etc. These methods interpret the byte array according to the data type's binary representation and convert it back to the respective type.

ToBoolean(Byte[], Int32) - Returns a Boolean value converted from the byte at a specified position in a byte array.
ToBoolean(ReadOnlySpan<Byte>)- Converts a read-only byte span to a Boolean value.
ToChar(Byte[], Int32)	- Returns a Unicode character converted from two bytes at a specified position in a byte array.
ToChar(ReadOnlySpan<Byte>)	- Converts a read-only byte span into a character.
ToDouble(Byte[], Int32)	- Returns a double-precision floating point number converted from eight bytes at a specified position in a byte array.
ToDouble(ReadOnlySpan<Byte>)	- Converts a read-only byte span into a double-precision floating-point value.
ToHalf(Byte[], Int32)	- Returns a half-precision floating point number converted from two bytes at a specified position in a byte array.
ToHalf(ReadOnlySpan<Byte>)	- Converts a read-only byte span into a half-precision floating-point value.
ToInt128(Byte[], Int32)	- Returns a 128-bit signed integer converted from sixteen bytes at a specified position in a byte array.
ToInt128(ReadOnlySpan<Byte>)	- Converts a read-only byte span into a 128-bit signed integer.
ToInt16(Byte[], Int32)	- Returns a 16-bit signed integer converted from two bytes at a specified position in a byte array.
ToInt16(ReadOnlySpan<Byte>)	- Converts a read-only byte span into a 16-bit signed integer.
ToInt32(Byte[], Int32)	- Returns a 32-bit signed integer converted from four bytes at a specified position in a byte array.
ToInt32(ReadOnlySpan<Byte>)	- Converts a read-only byte span into a 32-bit signed integer.
ToInt64(Byte[], Int32)	- Returns a 64-bit signed integer converted from eight bytes at a specified position in a byte array.
ToInt64(ReadOnlySpan<Byte>)	- Converts a read-only byte span into a 64-bit signed integer.
ToSingle(Byte[], Int32)	- Returns a single-precision floating point number converted from four bytes at a specified position in a byte array.
ToSingle(ReadOnlySpan<Byte>)	- Converts a read-only byte span into a single-precision floating-point value.
ToString(Byte[], Int32, Int32)	- Converts the numeric value of each element of a specified subarray of bytes to its equivalent hexadecimal string representation.
ToString(Byte[], Int32)	- Converts the numeric value of each element of a specified subarray of bytes to its equivalent hexadecimal string representation.
ToString(Byte[])	- Converts the numeric value of each element of a specified array of bytes to its equivalent hexadecimal string representation.
ToUInt128(Byte[], Int32)	- Returns a 128-bit unsigned integer converted from four bytes at a specified position in a byte array.
ToUInt128(ReadOnlySpan<Byte>)	- Converts a read-only byte span into a 128-bit unsigned integer.
ToUInt16(Byte[], Int32)	- Returns a 16-bit unsigned integer converted from two bytes at a specified position in a byte array.
ToUInt16(ReadOnlySpan<Byte>)	- Converts a read-only byte-span into a 16-bit unsigned integer.
ToUInt32(Byte[], Int32)	- Returns a 32-bit unsigned integer converted from four bytes at a specified position in a byte array.
ToUInt32(ReadOnlySpan<Byte>)	- Converts a read-only byte span into a 32-bit unsigned integer.
ToUInt64(Byte[], Int32)	- Returns a 64-bit unsigned integer converted from eight bytes at a specified position in a byte array.
ToUInt64(ReadOnlySpan<Byte>)	- Converts bytes into an unsigned long.


//The BitConverter.GetBytes method in C# is used to convert various data types into their binary representation as a byte array
GetBytes(Boolean) - Returns the specified Boolean value as a byte array.
GetBytes(Char)	- Returns the specified Unicode character value as an array of bytes.
GetBytes(Double) - Returns the specified double-precision floating-point value as an array of bytes.
GetBytes(Half)	- Returns the specified half-precision floating-point value as an array of bytes.
GetBytes(Int128) - Returns the specified 128-bit signed integer value as an array of bytes.
GetBytes(Int16)	- Returns the specified 16-bit signed integer value as an array of bytes.
GetBytes(Int32)	- Returns the specified 32-bit signed integer value as an array of bytes.
GetBytes(Int64)	- Returns the specified 64-bit signed integer value as an array of bytes.
GetBytes(Single)	- Returns the specified single-precision floating point value as an array of bytes.
GetBytes(UInt128)	- Returns the specified 128-bit unsigned integer value as an array of bytes.
GetBytes(UInt16)	 -Returns the specified 16-bit unsigned integer value as an array of bytes.
GetBytes(UInt32)	 Returns the specified 32-bit unsigned integer value as an array of bytes.
GetBytes(UInt64)	- Returns the specified 64-bit unsigned integer value as an array of bytes.


Conveting floating points to integrals method:
-----------------------------------------------
DoubleToInt64Bits(Double) - Converts the specified double-precision floating point number to a 64-bit signed integer.
DoubleToUInt64Bits(Double) -Converts the specified double-precision floating point number to a 64-bit unsigned integer.
    The binary representation of a double-precision floating-point number follows the IEEE 754 standard, which includes:
    Sign bit: 1 bit
    Exponent: 11 bits
    Mantissa (fraction): 52 bits
    When you use DoubleToInt64Bits, the method reinterprets these 64 bits as a long.

HalfToInt16Bits(Half) - Converts a half-precision floating-point value into a 16-bit integer.
HalfToUInt16Bits(Half)	- Converts the specified half-precision floating point number to a 16-bit unsigned integer.
Int16BitsToHalf(Int16)	- Reinterprets the specified 16-bit signed integer value as a half-precision floating-point value.
Int32BitsToSingle(Int32)	- Reinterprets the specified 32-bit integer as a single-precision floating-point value.
Int64BitsToDouble(Int64)	- Reinterprets the specified 64-bit signed integer to a double-precision floating point number.
SingleToInt32Bits(Single)	- Converts a single-precision floating-point value into an integer.
SingleToUInt32Bits(Single)	- Converts the specified single-precision floating point number to a 32-bit unsigned integer.
UInt16BitsToHalf(UInt16) - Converts the specified 16-bit unsigned integer to a half-precision floating point number.
UInt32BitsToSingle(UInt32)	- Converts the specified 32-bit unsigned integer to a single-precision floating point number.
UInt64BitsToDouble(UInt64)	- Converts the specified 64-bit unsigned integer to a double-precision floating point number.

TryWriteBytes:
----------------
The BitConverter.TryWriteBytes method in C# is used to convert a value to its binary representation and write it to a specified span of bytes. 
This method is useful for efficiently writing binary data to a buffer without allocating additional arrays.

TryWriteBytes(Span<Byte>, Boolean) - Converts a Boolean into a span of bytes.
TryWriteBytes(Span<Byte>, Char)	- Converts a character into a span of bytes.
TryWriteBytes(Span<Byte>, Double)	- Converts a double-precision floating-point value into a span of bytes.
TryWriteBytes(Span<Byte>, Half)	- Converts a half-precision floating-point value into a span of bytes.
TryWriteBytes(Span<Byte>, Int128)	- Converts a 128-bit signed integer into a span of bytes.
TryWriteBytes(Span<Byte>, Int16) - Converts a 16-bit signed integer into a span of bytes.
TryWriteBytes(Span<Byte>, Int32) - Converts a 32-bit signed integer into a span of bytes.
TryWriteBytes(Span<Byte>, Int64) - Converts a 64-bit signed integer into a span of bytes.
TryWriteBytes(Span<Byte>, Single)	- Converts a single-precision floating-point value into a span of bytes.
TryWriteBytes(Span<Byte>, UInt128)	- Converts a 128-bit unsigned integer into a span of bytes.
TryWriteBytes(Span<Byte>, UInt16)	- Converts an unsigned 16-bit integer into a span of bytes.
TryWriteBytes(Span<Byte>, UInt32)	- Converts a 32-bit unsigned integer into a span of bytes.
TryWriteBytes(Span<Byte>, UInt64)	- Converts an unsigned 64-bit integer into a span of bytes.

**/
namespace CastingTypeConvertion{
    class BitArrayBitConverterClass{
        public static void Main(){
            Console.WriteLine("Bit Converter");
            Console.WriteLine("IsLittleEndian :"+ BitConverter.IsLittleEndian);

            //Data type to Bit Array
            byte[] b = BitConverter.GetBytes(true);
            Console.WriteLine(string.Join(',',b));
            b = BitConverter.GetBytes(false);
            Console.WriteLine(string.Join(',',b));
            b = BitConverter.GetBytes((int)12345);
            Console.WriteLine(string.Join(',',b));
            b = BitConverter.GetBytes((short)10);
            Console.WriteLine(string.Join(',',b));
            b = BitConverter.GetBytes('c');
            Console.WriteLine(string.Join(',',b));

            Console.WriteLine("--------------------------------------------------------");

            //BitArray to datatype
            Console.WriteLine("Convert BitArray to specified type.");
            byte[] a = [1, 4, 0 ,2,1];
            Console.WriteLine(BitConverter.ToBoolean(a,0));//converting the byte to bool at index 0.//false
            Console.WriteLine(BitConverter.ToBoolean(a,2));//true
            Console.WriteLine(BitConverter.ToBoolean(a,1));//true
            
            //The ToChar method converts a byte array to a char value. It interprets the first two bytes of the array as a Unicode character.
            a = [65,0];
            Console.WriteLine(BitConverter.ToChar(a,0));// 'A' - Convert to Unicode Char from byte value representing ASCII value.
            a = [66,1];
            Console.WriteLine(BitConverter.ToChar(a,0));//'ł'
            a = [67,0];
            Console.WriteLine(BitConverter.ToChar(a,0));//'C'

            //The ToInt16 method converts a byte array to a 16-bit signed integer (short). It interprets the first two bytes of the array.
            a = [39,30,0,0];
            Console.WriteLine("Byte[] to int32 :"+ BitConverter.ToInt32(a,0));

            //The ToInt16 method converts a byte array to a 16-bit signed integer (short). It interprets the first two bytes of the array.
            a = [39,30];
            Console.WriteLine("Byte[] to int16 :"+ BitConverter.ToInt16(a,0));

            //The ToInt64 method converts a byte array to a 64-bit signed integer (long). It interprets the first eight bytes of the array.
            a = [0x39, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 ];
            Console.WriteLine("Byte[] to int64 :"+ BitConverter.ToInt64(a,0));

            //The ToSingle method converts a byte array to a single-precision floating-point number (float). It interprets the first four bytes of the array according to the IEEE 754 standard.
            a = BitConverter.GetBytes(12345.678f);
            Console.WriteLine("Byte[] to single :"+ BitConverter.ToSingle(a,0));

            //The ToDouble method converts a byte array to a double-precision floating-point number (double). It interprets the first eight bytes of the array according to the IEEE 754 standard.
            a = BitConverter.GetBytes(12345.6789);
            Console.WriteLine("Byte[] to double :"+ BitConverter.ToDouble(a,0));

            //ToString
            a = [
            255, 255, 255,   0,   0,  20,   0,  33,   0,   0,
              0,   1,   0,   0,   0, 100, 167, 179, 182, 224,
             13,   0, 202, 154,  59,   0, 143,  91,   0, 170,
            170, 170, 170, 170, 170,   0,   0, 232, 137,   4,
             35, 199, 138, 255, 232, 244, 255, 252, 205, 255,
            255, 129 ];
            Console.WriteLine("Byte[] to string :"+ BitConverter.ToString(a));

            Console.WriteLine("-----------------------------------------------------------------");
            //The DoubleToInt64Bits method converts the binary representation of a double to a long. 
            //This conversion does not change the actual bits but reinterprets them as a 64-bit signed integer
            Console.WriteLine("Convert Double to Long :"+ BitConverter.DoubleToInt64Bits(454.334343444));


            Console.WriteLine("WriteBytes Methods :");
            // Span<byte> copyHere = new byte[4];
            // if(BitConverter.TryWriteBytes(copyHere,(int)12345)){
            //     Console.WriteLine(string.Join(',', copyHere));
            // }
        }
    }
}