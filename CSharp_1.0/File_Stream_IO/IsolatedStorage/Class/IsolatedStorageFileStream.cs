/**
IsolatedStorageFileStream Class
---------------------------------
Exposes a file within isolated storage.
    public class IsolatedStorageFileStream : System.IO.FileStream

Constructors:
--------------
IsolatedStorageFileStream(String, FileMode, FileAccess, FileShare, Int32, IsolatedStorageFile)	-Initializes a new instance of the IsolatedStorageFileStream class giving access to the file designated by path, in the specified mode, with the specified file access, using the file sharing mode specified by share, with the bufferSize specified, and in the context of the IsolatedStorageFile specified by isf.
IsolatedStorageFileStream(String, FileMode, FileAccess, FileShare, Int32)	- Initializes a new instance of the IsolatedStorageFileStream class giving access to the file designated by path, in the specified mode, with the specified file access, using the file sharing mode specified by share, with the bufferSize specified.
IsolatedStorageFileStream(String, FileMode, FileAccess, FileShare, IsolatedStorageFile)	- Initializes a new instance of the IsolatedStorageFileStream class giving access to the file designated by path, in the specified mode, with the specified file access, using the file sharing mode specified by share, and in the context of the IsolatedStorageFile specified by isf.
IsolatedStorageFileStream(String, FileMode, FileAccess, FileShare)	- Initializes a new instance of the IsolatedStorageFileStream class giving access to the file designated by path, in the specified mode, with the specified file access, using the file sharing mode specified by share.
IsolatedStorageFileStream(String, FileMode, FileAccess, IsolatedStorageFile)	- Initializes a new instance of the IsolatedStorageFileStream class giving access to the file designated by path in the specified mode, with the specified file access, and in the context of the IsolatedStorageFile specified by isf.
IsolatedStorageFileStream(String, FileMode, FileAccess)	- Initializes a new instance of the IsolatedStorageFileStream class giving access to the file designated by path, in the specified mode, with the kind of access requested.
IsolatedStorageFileStream(String, FileMode, IsolatedStorageFile)	- Initializes a new instance of the IsolatedStorageFileStream class giving access to the file designated by path, in the specified mode, and in the context of the IsolatedStorageFile specified by isf.
IsolatedStorageFileStream(String, FileMode)	- Initializes a new instance of an IsolatedStorageFileStream object giving access to the file designated by path in the specified mode.

Properties:
----------
CanRead	- Gets a Boolean value indicating whether the file can be read.
CanSeek	- Gets a Boolean value indicating whether seek operations are supported.
CanTimeout	- Gets a value that determines whether the current stream can time out.(Inherited from Stream)
CanWrite - Gets a Boolean value indicating whether you can write to the file.
IsAsync	- Gets a Boolean value indicating whether the IsolatedStorageFileStream object was opened asynchronously or synchronously.
Length	- Gets the length of the IsolatedStorageFileStream object.
Name	- Gets the absolute path of the file opened in the FileStream.(Inherited from FileStream)
Position	- Gets or sets the current position of the current IsolatedStorageFileStream object.
ReadTimeout	- Gets or sets a value, in milliseconds, that determines how long the stream will attempt to read before timing out.(Inherited from Stream)
SafeFileHandle	- Gets a SafeFileHandle object that represents the operating system file handle for the file that the current IsolatedStorageFileStream object encapsulates.
WriteTimeout	- Gets or sets a value, in milliseconds, that determines how long the stream will attempt to write before timing out.(Inherited from Stream)

Methods:
------------
BeginRead(Byte[], Int32, Int32, AsyncCallback, Object)	- Begins an asynchronous read.
BeginWrite(Byte[], Int32, Int32, AsyncCallback, Object)	- Begins an asynchronous write.
CopyTo(Stream, Int32)	- Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.(Inherited from FileStream)
CopyTo(Stream)	- Reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.(Inherited from Stream)
CopyToAsync(Stream, CancellationToken)	- Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified cancellation token. Both streams positions are advanced by the number of bytes copied.(Inherited from Stream)- 
CopyToAsync(Stream, Int32, CancellationToken)	- Asynchronously reads thebytes from the current file stream and writes them to another stream, using a specified buffer size and cancellation token.(Inherited from FileStream)
CopyToAsync(Stream, Int32)	- Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.(Inherited from Stream)
CopyToAsync(Stream)	- Asynchronously reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.(Inherited from Stream)
Dispose()	- Releases all resources used by the Stream.(Inherited from Stream)
Dispose(Boolean)	- Releases the unmanaged resources used by the IsolatedStorageFileStream and optionally releases the managed resources.-
DisposeAsync()	- Asynchronously releases the unmanaged resources used by the IsolatedStorageFileStream.
EndRead(IAsyncResult)	- Ends a pending asynchronous read request.
EndWrite(IAsyncResult)	- Ends an asynchronous write.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Flush()	- Clears buffers for this stream and causes any buffered data to be written to the file.
Flush(Boolean)	- Clears buffers for this stream and causes any buffered data to be written to the file, and also clears all intermediate file buffers.
FlushAsync()	- Asynchronously clears all buffers for this stream and causes any buffered data to be written to the underlying device.(Inherited from Stream)
FlushAsync(CancellationToken)	- Asynchronously clears buffers for this stream and causes any buffered data to be written to the file.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
Lock(Int64, Int64)	- Prevents other processes from reading from or writing to the stream.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
MemberwiseClone(Boolean)	- Creates a shallow copy of the current MarshalByRefObject object.(Inherited from MarshalByRefObject)
Read(Byte[], Int32, Int32)	- Copies bytes from the current buffered IsolatedStorageFileStream object to a byte array.
Read(Span<Byte>)	- Copies bytes from the current buffered IsolatedStorageFileStream object to a byte span.
ReadAsync(Byte[], Int32, Int32, CancellationToken)	- Asynchronously copies bytes from the current buffered IsolatedStorageFileStream object to a byte array.
ReadAsync(Byte[], Int32, Int32)	- Asynchronously reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.(Inherited from Stream) - 
ReadAsync(Memory<Byte>, CancellationToken)	- Asynchronously copies byts from the current buffered IsolatedStorageFileStream object to a byte memory range.
ReadAtLeast(Span<Byte>, Int32, Boolean) - Reads at least a minimum number of bytes from the current stream and advances the position within the stream by the number of bytes read.(Inherited from Stream)
ReadAtLeastAsync(Memory<Byte>, Int32, Boolean, CancellationToken)	- Asynchronously reads at least a minimum number of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.(Inherited from Stream)
ReadByte()	- Reads a single byte from the IsolatedStorageFileStream object in isolated storage.
ReadExactly(Byte[], Int32, Int32)	- Reads count number of bytes from the current stream and advances the position within the stream.(Inherited from Stream)
ReadExactly(Span<Byte>)	- Reads bytes from the current stream and advances the position within the stream until the buffer is filled.(Inherited from Stream)
ReadExactlyAsync(Byte[], Int32, Int32, CancellationToken)	- Asynchronously reads count number of bytes from the current stream, advances the position within the stream, and monitors cancellation requests.(Inherited from Stream)
ReadExactlyAsync(Memory<Byte>, CancellationToken)	- Asynchronously reads bytes from the current stream, advances the position within the stream until the buffer is filled, and monitors cancellation requests.(Inherited from Stream)
Seek(Int64, SeekOrigin)	 -  Sets the current position of this IsolatedStorageFileStream object to the specified value.
SetLength(Int64)	- Sets the length of this IsolatedStorageFileStream object to the specified value.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
Unlock(Int64, Int64)	- Allows other processes to access all or part of a file that was previously locked.
Write(Byte[], Int32, Int32)	 - Writes a block of bytes to the isolated storage file stream object using data read from a buffer consisting of a byte array.
Write(ReadOnlySpan<Byte>)	- Writes a block of bytes to the isolated storage file stream object using data read from a buffer consisting of a read-only byte span.
WriteAsync(Byte[], Int32, Int32, CancellationToken)	- Asynchronously writes a block of bytes to the isolated storage file stream object using data read from a buffer consisting of a byte array.
WriteAsync(Byte[], Int32, Int32)	- Asynchronously writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.(Inherited from Stream)
WriteAsync(ReadOnlyMemory<Byte>, CancellationToken)	- Asynchronously writes a block of bytes to the isolated storage file stream object using data read from a buffer consisting of a read-only byte memory range.
WriteByte(Byte)	- Writes a single byte to the IsolatedStorageFileStream object.
**/