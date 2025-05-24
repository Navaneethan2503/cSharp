/**
TextWriter Class:
-------------------

Represents a writer that can write a sequential series of characters. This class is abstract.

    
    public abstract class TextWriter : MarshalByRefObject, IAsyncDisposable, IDisposable

Remarks:
--------
TextWriter is the abstract base class of StreamWriter and StringWriter, which write characters to streams and strings, respectively. Use an instance of TextWriter to write an object to a string, write strings to a file, or to serialize XML. You can also use the instance of TextWriter to write text to a custom backing store using the same APIs you would use for a string or a stream, or to add support for text formatting.

All the Write methods of TextWriter having primitive data types as parameters write out the values as strings.

By default, a TextWriter is not thread safe. See TextWriter.Synchronized for a thread-safe wrapper.

This type implements the IDisposable interface. When you have finished using any type that derives from this type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its Dispose method in a try/catch block. To dispose of it indirectly, use a language construct such as using (in C#) or Using (in Visual Basic). 

Constructors:
---------------
TextWriter()	- Initializes a new instance of the TextWriter class.
TextWriter(IFormatProvider)	- Initializes a new instance of the TextWriter class with the specified format provider.

Fields:
---------
CoreNewLine	- Stores the newline characters used for this TextWriter.
Null	- Provides a TextWriter with no backing store that can be written to, but not read from.

Properties:
------------
Encoding	- When overridden in a derived class, returns the character encoding in which the output is written.
FormatProvider	- Gets an object that controls formatting.
NewLine	- Gets or sets the line terminator string used by the current TextWriter.

Methods:
------
Close()	- Closes the current writer and releases any system resources associated with the writer.
CreateBroadcasting(TextWriter[])	- Creates an instance of TextWriter that writes supplied inputs to each of the writers in writers.
Dispose()	- Releases all resources used by the TextWriter object.
Dispose(Boolean)	- Releases the unmanaged resources used by the TextWriter and optionally releases the managed resources.
DisposeAsync()	- Asynchronously releases all resources used by the TextWriter object.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Flush()	- Clears all buffers for the current writer and causes any buffered data to be written to the underlying device.
FlushAsync()	- Asynchronously clears all buffers for the current writer and causes any buffered data to be written to the underlying device.
FlushAsync(CancellationToken)	- Asynchronously clears all buffers for the current writer and causes any buffered data to be written to the underlying device.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
MemberwiseClone(Boolean)	- Creates a shallow copy of the current MarshalByRefObject object.(Inherited from MarshalByRefObject)
Synchronized(TextWriter)	- Creates a thread-safe wrapper around the specified TextWriter.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
Write(Boolean)	- Writes the text representation of a Boolean value to the text stream.
Write(Char)	- Writes a character to the text stream.
Write(Char[], Int32, Int32)	- Writes a subarray of characters to the text stream.
Write(Char[])	- Writes a character array to the text stream.
Write(Decimal)	- Writes the text representation of a decimal value to the text stream.
Write(Double)	- Writes the text representation of an 8-byte floating-point value to the text stream.
Write(Int32)	- Writes the text representation of a 4-byte signed integer to the text stream.
Write(Int64)	- Writes the text representation of an 8-byte signed integer to the text stream.
Write(Object)	- Writes the text representation of an object to the text stream by calling the ToString method on that object.
Write(ReadOnlySpan<Char>)	- Writes a character span to the text stream.
Write(Single)	- Writes the text representation of a 4-byte floating-point value to the text stream.
Write(String, Object, Object, Object)	- Writes a formatted string to the text stream, using the same semantics as the Format(String, Object, Object, Object) method.
Write(String, Object, Object)	- Writes a formatted string to the text stream using the same semantics as the Format(String, Object, Object) method.
Write(String, Object)	- Writes a formatted string to the text stream, using the same semantics as the Format(String, Object) method.
Write(String, Object[])	- Writes a formatted string to the text stream, using the same semantics as the Format(String, Object[]) method.
Write(String, ReadOnlySpan<Object>)	- Writes a formatted string to the text stream, using the same semantics as Format(String, ReadOnlySpan<Object>).
Write(String)	- Writes a string to the text stream.
Write(StringBuilder)	- Writes a string builder to the text stream.
Write(UInt32)	- Writes the text representation of a 4-byte unsigned integer to the text stream.
Write(UInt64)	- Writes the text representation of an 8-byte unsigned integer to the text stream.
WriteAsync(Char)	- Writes a character to the text stream asynchronously.
WriteAsync(Char[], Int32, Int32)	- Writes a subarray of characters to the text stream asynchronously.
WriteAsync(Char[])	- Writes a character array to the text stream asynchronously.
WriteAsync(ReadOnlyMemory<Char>, CancellationToken)	- Asynchronously writes a character memory region to the text stream.
WriteAsync(String)	- Writes a string to the text stream asynchronously.
WriteAsync(StringBuilder, CancellationToken)	- Asynchronously writes a string builder to the text stream.
WriteLine()	- Writes a line terminator to the text stream.
WriteLine(Boolean)	- Writes the text representation of a Boolean value to the text stream, followed by a line terminator.
WriteLine(Char)	- Writes a character to the text stream, followed by a line terminator.
WriteLine(Char[], Int32, Int32)	- Writes a subarray of characters to the text stream, followed by a line terminator.
WriteLine(Char[])	- Writes an array of characters to the text stream, followed by a line terminator.
WriteLine(Decimal)	- Writes the text representation of a decimal value to the text stream, followed by a line terminator.
WriteLine(Double)	- Writes the text representation of a 8-byte floating-point value to the text stream, followed by a line terminator.
WriteLine(Int32)	- Writes the text representation of a 4-byte signed integer to the text stream, followed by a line terminator.
WriteLine(Int64)	- Writes the text representation of an 8-byte signed integer to the text stream, followed by a line terminator.
WriteLine(Object)	- Writes the text representation of an object to the text stream, by calling the ToString method on that object, followed by a line terminator.
WriteLine(ReadOnlySpan<Char>)	- Writes the text representation of a character span to the text stream, followed by a line terminator.
WriteLine(Single)	- Writes the text representation of a 4-byte floating-point value to the text stream, followed by a line terminator.
WriteLine(String, Object, Object, Object)	 - Writes out a formatted string and a new line to the text stream, using the same semantics as Format(String, Object).
WriteLine(String, Object, Object)	- Writes a formatted string and a new line to the text stream, using the same semantics as the Format(String, Object, Object) method.
WriteLine(String, Object)	- Writes a formatted string and a new line to the text stream, using the same semantics as the Format(String, Object) method.
WriteLine(String, Object[])	- Writes out a formatted string and a new line to the text stream, using the same semantics as Format(String, Object).
WriteLine(String, ReadOnlySpan<Object>)	- Writes out a formatted string and a new line to the text stream, using the same semantics as Format(String, ReadOnlySpan<Object>).
WriteLine(String)	- Writes a string to the text stream, followed by a line terminator.
WriteLine(StringBuilder)	- Writes the text representation of a string builder to the text stream, followed by a line terminator.
WriteLine(UInt32)	- Writes the text representation of a 4-byte unsigned integer to the text stream, followed by a line terminator.
WriteLine(UInt64)	- Writes the text representation of an 8-byte unsigned integer to the text stream, followed by a line terminator.
WriteLineAsync()	- Asynchronously writes a line terminator to the text stream.
WriteLineAsync(Char)	- Asynchronously writes a character to the text stream, followed by a line terminator.
WriteLineAsync(Char[], Int32, Int32)	- Asynchronously writes a subarray of characters to the text stream, followed by a line terminator.
WriteLineAsync(Char[])	- Asynchronously writes an array of characters to the text stream, followed by a line terminator.
WriteLineAsync(ReadOnlyMemory<Char>, CancellationToken)	- Asynchronously writes the text representation of a character memory region to the text stream, followed by a line terminator.
WriteLineAsync(String)	- Asynchronously writes a string to the text stream, followed by a line terminator.
WriteLineAsync(StringBuilder, CancellationToken)	- Asynchronously writes the text representation of a string builder to the text stream, followed by a line terminator.


**/