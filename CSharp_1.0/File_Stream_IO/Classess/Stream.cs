/**
Stream Class:
---------------
Provides a generic view of a sequence of bytes. This is an abstract class.
    

    public abstract class Stream : MarshalByRefObject, IAsyncDisposable, IDisposable

Remarks
Stream is the abstract base class of all streams. A stream is an abstraction of a sequence of bytes, such as a file, an input/output device, an inter-process communication pipe, or a TCP/IP socket. The Stream class and its derived classes provide a generic view of these different types of input and output, and isolate the programmer from the specific details of the operating system and the underlying devices.

Streams involve three fundamental operations:

You can read from streams. Reading is the transfer of data from a stream into a data structure, such as an array of bytes.

You can write to streams. Writing is the transfer of data from a data structure into a stream.

Streams can support seeking. Seeking refers to querying and modifying the current position within a stream. Seek capability depends on the kind of backing store a stream has. For example, network streams have no unified concept of a current position, and therefore typically do not support seeking.

Some of the more commonly used streams that inherit from Stream are FileStream, and MemoryStream.

Depending on the underlying data source or repository, streams might support only some of these capabilities. You can query a stream for its capabilities by using the CanRead, CanWrite, and CanSeek properties of the Stream class.

The Read and Write methods read and write data in a variety of formats. For streams that support seeking, use the Seek and SetLength methods and the Position and Length properties to query and modify the current position and length of a stream.

This type implements the IDisposable interface. When you have finished using the type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its Dispose method in a try/catch block. To dispose of it indirectly, use a language construct such as using (in C#) or Using (in Visual Basic). For more information, see the "Using an Object that Implements IDisposable" section in the IDisposable interface topic.

Disposing a Stream object flushes any buffered data, and essentially calls the Flush method for you. Dispose also releases operating system resources such as file handles, network connections, or memory used for any internal buffering. The BufferedStream class provides the capability of wrapping a buffered stream around another stream in order to improve read and write performance.

Starting with the .NET Framework 4.5, the Stream class includes async methods to simplify asynchronous operations. An async method contains Async in its name, such as ReadAsync, WriteAsync, CopyToAsync, and FlushAsync. These methods enable you to perform resource-intensive I/O operations without blocking the main thread. This performance consideration is particularly important in a Windows 8.x Store app or desktop app where a time-consuming stream operation can block the UI thread and make your app appear as if it is not working. The async methods are used in conjunction with the async and await keywords in Visual Basic and C#.

When used in a Windows 8.x Store app, Stream includes two extension methods: AsInputStream and AsOutputStream. These methods convert a Stream object to a stream in the Windows Runtime. You can also convert a stream in the Windows Runtime to a Stream object by using the AsStreamForRead and AsStreamForWrite methods. For more information, see How to: Convert Between .NET Framework Streams and Windows Runtime Streams

Some stream implementations perform local buffering of the underlying data to improve performance. For such streams, you can use the Flush or FlushAsync method to clear any internal buffers and ensure that all data has been written to the underlying data source or repository.

If you need a stream with no backing store (also known as a bit bucket), use the Null field to retrieve an instance of a stream that is designed for this purpose.

Constructors:
-------------
Stream()	- Initializes a new instance of the Stream class.

Fields:
-------
Null	- A Stream with no backing store.
    public static readonly System.IO.Stream Null;

Properties:
-----------
CanRead	- When overridden in a derived class, gets a value indicating whether the current stream supports reading.
CanSeek	- When overridden in a derived class, gets a value indicating whether the current stream supports seeking.
CanTimeout	- Gets a value that determines whether the current stream can time out.
CanWrite	- When overridden in a derived class, gets a value indicating whether the current stream supports writing.
Length	- When overridden in a derived class, gets the length in bytes of the stream.
Position	- When overridden in a derived class, gets or sets the position within the current stream.
ReadTimeout	- Gets or sets a value, in milliseconds, that determines how long the stream will attempt to read before timing out.
WriteTimeout	- Gets or sets a value, in milliseconds, that determines how long the stream will attempt to write before timing out.

Methods:
-----------
BeginRead(Byte[], Int32, Int32, AsyncCallback, Object)	- Begins an asynchronous read operation. (Consider using ReadAsync(Byte[], Int32, Int32) instead.)
BeginWrite(Byte[], Int32, Int32, AsyncCallback, Object)	- Begins an asynchronous write operation. (Consider using WriteAsync(Byte[], Int32, Int32) instead.)
Close()	- Closes the current stream and releases any resources (such as sockets and file handles) associated with the current stream. Instead of calling this method, ensure that the stream is properly disposed.
CopyTo(Stream, Int32)	- Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.
CopyTo(Stream)	- Reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.
CopyToAsync(Stream, CancellationToken)	- Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified cancellation token. Both streams positions are advanced by the number of bytes copied.
CopyToAsync(Stream, Int32, CancellationToken)	- Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token. Both streams positions are advanced by the number of bytes copied.
CopyToAsync(Stream, Int32)	- Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.
CopyToAsync(Stream)	- Asynchronously reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.
Dispose()	- Releases all resources used by the Stream.
Dispose(Boolean)	- Releases the unmanaged resources used by the Stream and optionally releases the managed resources.
DisposeAsync()	- Asynchronously releases the unmanaged resources used by the Stream.
    public void Dispose();
    
EndRead(IAsyncResult)	-Waits for the pending asynchronous read to complete. (Consider using ReadAsync(Byte[], Int32, Int32) instead.)
EndWrite(IAsyncResult)	- Ends an asynchronous write operation. (Consider using WriteAsync(Byte[], Int32, Int32) instead.)
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Flush()	- When overridden in a derived class, clears all buffers for this stream and causes any buffered data to be written to the underlying device.
    public abstract void Flush();
     Use this method to move any information from an underlying buffer to its destination, clear the buffer, or both. Depending upon the state of the object, you might have to modify the current position within the stream

FlushAsync()	- Asynchronously clears all buffers for this stream and causes any buffered data to be written to the underlying device.
FlushAsync(CancellationToken)	- Asynchronously clears all buffers for this stream, causes any buffered data to be written to the underlying device, and monitors cancellation requests.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
MemberwiseClone(Boolean)	- Creates a shallow copy of the current MarshalByRefObject object.(Inherited from MarshalByRefObject)
Read(Byte[], Int32, Int32)	- When overridden in a derived class, reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
Read(Span<Byte>)	- When overridden in a derived class, reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
    public virtual int Read(Span<byte> buffer);

ReadAsync(Byte[], Int32, Int32, CancellationToken)	- Asynchronously reads a sequence of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.
ReadAsync(Byte[], Int32, Int32)	- Asynchronously reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
ReadAsync(Memory<Byte>, CancellationToken)	- Asynchronously reads a sequence of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.
ReadAtLeast(Span<Byte>, Int32, Boolean)	- Reads at least a minimum number of bytes from the current stream and advances the position within the stream by the number of bytes read.
ReadAtLeastAsync(Memory<Byte>, Int32, Boolean, CancellationToken)	- Asynchronously reads at least a minimum number of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.
ReadByte()	- Reads a byte from the stream and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
    public virtual int ReadByte();

ReadExactly(Byte[], Int32, Int32)	- Reads count number of bytes from the current stream and advances the position within the stream.
ReadExactly(Span<Byte>)	- Reads bytes from the current stream and advances the position within the stream until the buffer is filled.
ReadExactlyAsync(Byte[], Int32, Int32, CancellationToken)	- Asynchronously reads count number of bytes from the current stream, advances the position within the stream, and monitors cancellation requests.
ReadExactlyAsync(Memory<Byte>, CancellationToken)	- Asynchronously reads bytes from the current stream, advances the position within the stream until the buffer is filled, and monitors cancellation requests.
Seek(Int64, SeekOrigin)	- When overridden in a derived class, sets the position within the current stream.
    public abstract long Seek(long offset, System.IO.SeekOrigin origin);

SetLength(Int64)	- When overridden in a derived class, sets the length of the current stream.
Synchronized(Stream)	- Creates a thread-safe (synchronized) wrapper around the specified Stream object.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
ValidateBufferArguments(Byte[], Int32, Int32)	- Validates arguments provided to reading and writing methods on Stream.
ValidateCopyToArguments(Stream, Int32)	- Validates arguments provided to the CopyTo(Stream, Int32) or CopyToAsync(Stream, Int32, CancellationToken) methods.
Write(Byte[], Int32, Int32)	- When overridden in a derived class, writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
Write(ReadOnlySpan<Byte>)	- When overridden in a derived class, writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
WriteAsync(Byte[], Int32, Int32, CancellationToken)	- Asynchronously writes a sequence of bytes to the current stream, advances the current position within this stream by the number of bytes written, and monitors cancellation requests.
WriteAsync(Byte[], Int32, Int32)	- Asynchronously writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
WriteAsync(ReadOnlyMemory<Byte>, CancellationToken)	- Asynchronously writes a sequence of bytes to the current stream, advances the current position within this stream by the number of bytes written, and monitors cancellation requests.
WriteByte(Byte)	- Writes a byte to the current position in the stream and advances the position within the stream by one byte.
    public virtual void WriteByte(byte value);

**/
using System;

namespace FileStreamIONamespace{
    class StreamClass{
        public static void Main(){
            Console.WriteLine("Abstract Stream Class.");
        }
    }
}