using System;
using System.Text;
/**
Encoding Class:
---------------
Represents a character encoding.
    public abstract class Encoding : ICloneable

Constructors:
--------------
Encoding()	- Initializes a new instance of the Encoding class.
Encoding(Int32, EncoderFallback, DecoderFallback)	- Initializes a new instance of the Encoding class that corresponds to the specified code page with the specified encoder and decoder fallback strategies.
    protected Encoding(int codePage, System.Text.EncoderFallback? encoderFallback, System.Text.DecoderFallback? decoderFallback);

Encoding(Int32)	- Initializes a new instance of the Encoding class that corresponds to the specified code page.
    protected Encoding(int codePage);

Properties:
-----------
ASCII	- Gets an encoding for the ASCII (7-bit) character set.
    public static System.Text.Encoding ASCII { get; }

BigEndianUnicode	- Gets an encoding for the UTF-16 format that uses the big endian byte order.
BodyName	- When overridden in a derived class, gets a name for the current encoding that can be used with mail agent body tags.
CodePage	- When overridden in a derived class, gets the code page identifier of the current Encoding.
DecoderFallback	- Gets or sets the DecoderFallback object for the current Encoding object.
Default	- Gets the default encoding for this .NET implementation.
EncoderFallback	- Gets or sets the EncoderFallback object for the current Encoding object.
EncodingName	- When overridden in a derived class, gets the human-readable description of the current encoding.
HeaderName	- When overridden in a derived class, gets a name for the current encoding that can be used with mail agent header tags.
IsBrowserDisplay	- When overridden in a derived class, gets a value indicating whether the current encoding can be used by browser clients for displaying content.
IsBrowserSave	- When overridden in a derived class, gets a value indicating whether the current encoding can be used by browser clients for saving content.
IsMailNewsDisplay	- When overridden in a derived class, gets a value indicating whether the current encoding can be used by mail and news clients for displaying content.
IsMailNewsSave	- When overridden in a derived class, gets a value indicating whether the current encoding can be used by mail and news clients for saving content.
IsReadOnly	- When overridden in a derived class, gets a value indicating whether the current encoding is read-only.
IsSingleByte	- When overridden in a derived class, gets a value indicating whether the current encoding uses single-byte code points.
Latin1	- Gets an encoding for the Latin1 character set (ISO-8859-1).
Preamble	- When overridden in a derived class, returns a span containing the sequence of bytes that specifies the encoding used.
Unicode	- Gets an encoding for the UTF-16 format using the little endian byte order.
UTF32	- Gets an encoding for the UTF-32 format using the little endian byte order.
UTF8	- Gets an encoding for the UTF-8 format.
WebName	- When overridden in a derived class, gets the name registered with the Internet Assigned Numbers Authority (IANA) for the current encoding.
WindowsCodePage	- When overridden in a derived class, gets the Windows operating system code page that most closely corresponds to the current encoding.

Methods:
--------
Clone()	- When overridden in a derived class, creates a shallow copy of the current Encoding object.
Convert(Encoding, Encoding, Byte[], Int32, Int32)	- Converts a range of bytes in a byte array from one encoding to another.
Convert(Encoding, Encoding, Byte[])	- Converts an entire byte array from one encoding to another.
CreateTranscodingStream(Stream, Encoding, Encoding, Boolean)	- Creates a Stream that serves to transcode data between an inner Encoding and an outer Encoding, similar to Convert(Encoding, Encoding, Byte[]).
Equals(Object)	- Determines whether the specified Object is equal to the current instance.
GetByteCount(Char[], Int32, Int32)	- When overridden in a derived class, calculates the number of bytes produced by encoding a set of characters from the specified character array.
GetByteCount(Char[])	- When overridden in a derived class, calculates the number of bytes produced by encoding all the characters in the specified character array.
GetByteCount(Char*, Int32)	- When overridden in a derived class, calculates the number of bytes produced by encoding a set of characters starting at the specified character pointer.
GetByteCount(ReadOnlySpan<Char>)	- When overridden in a derived class, calculates the number of bytes produced by encoding the characters in the specified character span.
GetByteCount(String, Int32, Int32)	- When overridden in a derived class, calculates the number of bytes produced by encoding a set of characters from the specified string.
GetByteCount(String)	- When overridden in a derived class, calculates the number of bytes produced by encoding the characters in the specified string.
    public virtual int GetByteCount(ReadOnlySpan<char> chars);

GetBytes(Char[], Int32, Int32, Byte[], Int32)	- When overridden in a derived class, encodes a set of characters from the specified character array into the specified byte array.
GetBytes(Char[], Int32, Int32)	- When overridden in a derived class, encodes a set of characters from the specified character array into a sequence of bytes.
GetBytes(Char[])	- When overridden in a derived class, encodes all the characters in the specified character array into a sequence of bytes.
GetBytes(Char*, Int32, Byte*, Int32)	- When overridden in a derived class, encodes a set of characters starting at the specified character pointer into a sequence of bytes that are stored starting at the specified byte pointer.
GetBytes(ReadOnlySpan<Char>, Span<Byte>)	- When overridden in a derived class, encodes into a span of bytes a set of characters from the specified read-only span.
GetBytes(String, Int32, Int32, Byte[], Int32)	- When overridden in a derived class, encodes a set of characters from the specified string into the specified byte array.
GetBytes(String, Int32, Int32)	- When overridden in a derived class, encodes into an array of bytes the number of characters specified by count in the specified string, starting from the specified index.
GetBytes(String)	- When overridden in a derived class, encodes all the characters in the specified string into a sequence of bytes.
    public virtual byte[] GetBytes(char[] chars);

GetCharCount(Byte[], Int32, Int32)	- When overridden in a derived class, calculates the number of characters produced by decoding a sequence of bytes from the specified byte array.
GetCharCount(Byte[])	- When overridden in a derived class, calculates the number of characters produced by decoding all the bytes in the specified byte array.
GetCharCount(Byte*, Int32)	- When overridden in a derived class, calculates the number of characters produced by decoding a sequence of bytes starting at the specified byte pointer.
GetCharCount(ReadOnlySpan<Byte>)	- When overridden in a derived class, calculates the number of characters produced by decoding the provided read-only byte span.
    public abstract int GetCharCount(byte[] bytes, int index, int count);

GetChars(Byte[], Int32, Int32, Char[], Int32)	- When overridden in a derived class, decodes a sequence of bytes from the specified byte array into the specified character array.
GetChars(Byte[], Int32, Int32)	- When overridden in a derived class, decodes a sequence of bytes from the specified byte array into a set of characters.
GetChars(Byte[])	- When overridden in a derived class, decodes all the bytes in the specified byte array into a set of characters.
GetChars(Byte*, Int32, Char*, Int32)	- When overridden in a derived class, decodes a sequence of bytes starting at the specified byte pointer into a set of characters that are stored starting at the specified character pointer.
GetChars(ReadOnlySpan<Byte>, Span<Char>)	- When overridden in a derived class, decodes all the bytes in the specified read-only byte span into a character span.
    public virtual char[] GetChars(byte[] bytes);

GetDecoder()	- When overridden in a derived class, obtains a decoder that converts an encoded sequence of bytes into a sequence of characters.
    public virtual System.Text.Decoder GetDecoder();

GetEncoder()	- When overridden in a derived class, obtains an encoder that converts a sequence of Unicode characters into an encoded sequence of bytes.
    public virtual System.Text.Encoder GetEncoder();

GetEncoding(Int32, EncoderFallback, DecoderFallback)	- Returns the encoding associated with the specified code page identifier. Parameters specify an error handler for characters that cannot be encoded and byte sequences that cannot be decoded.
GetEncoding(Int32)	- Returns the encoding associated with the specified code page identifier.
GetEncoding(String, EncoderFallback, DecoderFallback)	- Returns the encoding associated with the specified code page name. Parameters specify an error handler for characters that cannot be encoded and byte sequences that cannot be decoded.
GetEncoding(String)	- Returns the encoding associated with the specified code page name.
GetEncodings()	- Returns an array that contains all encodings.
    public static System.Text.Encoding GetEncoding(string name, System.Text.EncoderFallback encoderFallback, System.Text.DecoderFallback decoderFallback);

GetHashCode()	- Returns the hash code for the current instance.
GetMaxByteCount(Int32)	- When overridden in a derived class, calculates the maximum number of bytes produced by encoding the specified number of characters.
GetMaxCharCount(Int32)	- When overridden in a derived class, calculates the maximum number of characters produced by decoding the specified number of bytes.
GetPreamble()	- When overridden in a derived class, returns a sequence of bytes that specifies the encoding used.
GetString(Byte[], Int32, Int32)	- When overridden in a derived class, decodes a sequence of bytes from the specified byte array into a string.
GetString(Byte[])	- When overridden in a derived class, decodes all the bytes in the specified byte array into a string.
GetString(Byte*, Int32)	- When overridden in a derived class, decodes a specified number of bytes starting at a specified address into a string.
GetString(ReadOnlySpan<Byte>)	- When overridden in a derived class, decodes all the bytes in the specified byte span into a string.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
IsAlwaysNormalized()	- Gets a value indicating whether the current encoding is always normalized, using the default normalization form.
IsAlwaysNormalized(NormalizationForm)	- When overridden in a derived class, gets a value indicating whether the current encoding is always normalized, using the specified normalization form.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
RegisterProvider(EncodingProvider)	- Registers an encoding provider.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryGetBytes(ReadOnlySpan<Char>, Span<Byte>, Int32)	- Encodes into a span of bytes a set of characters from the specified read-only span if the destination is large enough.
TryGetChars(ReadOnlySpan<Byte>, Span<Char>, Int32)	- Decodes into a span of chars a set of bytes from the specified read-only span if the destination is large enough.




**/
namespace StringBuilderText{
    class EncodingClass{
        public static void Main(){
            Console.WriteLine("Encoding Class.");
        }
    }
}