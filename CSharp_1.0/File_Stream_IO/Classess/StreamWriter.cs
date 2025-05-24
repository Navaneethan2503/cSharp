/**
StreamWriter Class:
------------------
Implements a TextWriter for writing characters to a stream in a particular encoding.

public class StreamWriter : System.IO.TextWriter

Remarks
StreamWriter is designed for character output in a particular encoding, whereas classes derived from Stream are designed for byte input and output.

This type implements the IDisposable interface. When you have finished using the type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its Dispose method in a try/catch block. To dispose of it indirectly, use a language construct such as using (in C#) or Using (in Visual Basic). For more information, see the "Using an Object that Implements IDisposable" section in the IDisposable interface topic.

StreamWriter defaults to using an instance of UTF8Encoding unless specified otherwise. This instance of UTF8Encoding is constructed without a byte order mark (BOM), so its GetPreamble method returns an empty byte array. The default UTF-8 encoding for this constructor throws an exception on invalid bytes. This behavior is different from the behavior provided by the encoding object in the Encoding.UTF8 property. To specify a BOM and determine whether an exception is thrown on invalid bytes, use a constructor that accepts an encoding object as a parameter, such as StreamWriter(String, Boolean, Encoding) or StreamWriter.

By default, a StreamWriter is not thread safe. See TextWriter.Synchronized for a thread-safe wrapper.

Constructors:
-------------
StreamWriter(Stream, Encoding, Int32, Boolean)	- Initializes a new instance of the StreamWriter class for the specified stream by using the specified encoding and buffer size, and optionally leaves the stream open.
StreamWriter(Stream, Encoding, Int32)	- Initializes a new instance of the StreamWriter class for the specified stream by using the specified encoding and buffer size.
StreamWriter(Stream, Encoding)	- Initializes a new instance of the StreamWriter class for the specified stream by using the specified encoding and the default buffer size.
StreamWriter(Stream)	- Initializes a new instance of the StreamWriter class for the specified stream by using UTF-8 encoding and the default buffer size.
StreamWriter(String, Boolean, Encoding, Int32)	- Initializes a new instance of the StreamWriter class for the specified file on the specified path, using the specified encoding and buffer size. If the file exists, it can be either overwritten or appended to. If the file does not exist, this constructor creates a new file.
StreamWriter(String, Boolean, Encoding)	- Initializes a new instance of the StreamWriter class for the specified file by using the specified encoding and default buffer size. If the file exists, it can be either overwritten or appended to. If the file does not exist, this constructor creates a new file.
StreamWriter(String, Boolean)	- Initializes a new instance of the StreamWriter class for the specified file by using the default encoding and buffer size. If the file exists, it can be either overwritten or appended to. If the file does not exist, this constructor creates a new file.
StreamWriter(String, Encoding, FileStreamOptions)	- Initializes a new instance of the StreamWriter class for the specified file, using the specified encoding, and configured with the specified FileStreamOptions object.
StreamWriter(String, FileStreamOptions)	- Initializes a new instance of the StreamWriter class for the specified file, using the default encoding, and configured with the specified FileStreamOptions object.
StreamWriter(String)	- Initializes a new instance of the StreamWriter class for the specified file by using the default encoding and buffer size.

Fields:
-------
CoreNewLine	- Stores the newline characters used for this TextWriter.(Inherited from TextWriter)
Null	- Provides a StreamWriter with no backing store that can be written to, but not read from.

Properties:
----------
AutoFlush	- Gets or sets a value indicating whether the StreamWriter will flush its buffer to the underlying stream after every call to Write(Char).
BaseStream	- Gets the underlying stream that interfaces with a backing store.
Encoding	- Gets the Encoding in which the output is written.
FormatProvider	- Gets an object that controls formatting.(Inherited from TextWriter)
NewLine	- Gets or sets the line terminator string used by the current TextWriter.(Inherited from TextWriter)

Methods:(all method from dervied class TextWriter )
------------------
**/