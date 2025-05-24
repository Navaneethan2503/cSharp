/**
TextReader Class :
------------------
    public abstract class TextReader : MarshalByRefObject, IDisposable

Remarks:
----------
TextReader is the abstract base class of StreamReader and StringReader, which read characters from streams and strings, respectively. Use these derived classes to open a text file for reading a specified range of characters, or to create a reader based on an existing stream.
This type implements the IDisposable interface. When you have finished using any type that derives from this type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its Dispose method in a try/catch block. To dispose of it indirectly, use a language construct such as using (in C#) or Using (in Visual Basic)

Constructors:
------------
TextReader()	- Initializes a new instance of the TextReader class.

Fields:
-------
Null	- Provides a TextReader with no data to read from.

Methods:
-----------
Close()	- Closes the TextReader and releases any system resources associated with the TextReader.
Dispose()	- Releases all resources used by the TextReader object.
Dispose(Boolean)	- Releases the unmanaged resources used by the TextReader and optionally releases the managed resources.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
MemberwiseClone(Boolean)	- Creates a shallow copy of the current MarshalByRefObject object.(Inherited from MarshalByRefObject)
Peek()	- Reads the next character without changing the state of the reader or the character source. Returns the next available character without actually reading it from the reader.
Read()	- Reads the next character from the text reader and advances the character position by one character.
Read(Char[], Int32, Int32)	- Reads a specified maximum number of characters from the current reader and writes the data to a buffer, beginning at the specified index.
Read(Span<Char>)	- Reads the characters from the current reader and writes the data to the specified buffer.
ReadAsync(Char[], Int32, Int32)	- Reads a specified maximum number of characters from the current text reader asynchronously and writes the data to a buffer, beginning at the specified index.
ReadAsync(Memory<Char>, CancellationToken)	- Asynchronously reads the characters from the current stream into a memory block.
ReadBlock(Char[], Int32, Int32)	- Reads a specified maximum number of characters from the current text reader and writes the data to a buffer, beginning at the specified index.
ReadBlock(Span<Char>)	- Reads the characters from the current stream and writes the data to a buffer.
ReadBlockAsync(Char[], Int32, Int32)	- Reads a specified maximum number of characters from the current text reader asynchronously and writes the data to a buffer, beginning at the specified index.
ReadBlockAsync(Memory<Char>, CancellationToken)	- Asynchronously reads the characters from the current stream and writes the data to a buffer.
ReadLine()	- Reads a line of characters from the text reader and returns the data as a string.
    public virtual string? ReadLine();

ReadLineAsync()	- Reads a line of characters asynchronously and returns the data as a string.
ReadLineAsync(CancellationToken)	- Reads a line of characters asynchronously and returns the data as a string.
    
ReadToEnd()	- Reads all characters from the current position to the end of the text reader and returns them as one string.
    public virtual string ReadToEnd();
    
ReadToEndAsync()	- Reads all characters from the current position to the end of the text reader asynchronously and returns them as one string.
ReadToEndAsync(CancellationToken)	- Reads all characters from the current position to the end of the text reader asynchronously and returns them as one string.
Synchronized(TextReader)	- Creates a thread-safe wrapper around the specified TextReader.
ToString()	- Returns a string that represents the current object.(Inherited from Object)



**/