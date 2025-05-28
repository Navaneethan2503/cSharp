/**
HttpContent Class:
------------------
A base class representing an HTTP entity body and content headers.

public abstract class HttpContent : IDisposable



Remarks
There are various HTTP contents that can be used. These include the following.

ByteArrayContent - A content represented by a byte array, also serves as a base class for StringContent and FormUrlEncodedContent.

StringContent - A string-based content, by default serialized as text/plain Content-Type with UTF-8 encoding.

FormUrlEncodedContent - A content with name/value tuples serialized as application/x-www-form-urlencoded Content-Type.

MultipartContent - A content that can serialize multiple different HttpContent objects as multipart/* Content-Type.

JsonContent - A content that serializes objects as application/json Content-Type with UTF-8 encoding by default.

HTTP content class can be derived by a user to provide custom content serialization logic.

Constructors
HttpContent()	
Initializes a new instance of the HttpContent class.

Properties
Headers	
Gets the HTTP content headers as defined in RFC 2616.

Methods
CopyTo(Stream, TransportContext, CancellationToken)	
Serializes the HTTP content into a stream of bytes and copies it to stream.

CopyToAsync(Stream, CancellationToken)	
Serialize the HTTP content into a stream of bytes and copies it to the stream object provided as the stream parameter.

CopyToAsync(Stream, TransportContext, CancellationToken)	
Serialize the HTTP content into a stream of bytes and copies it to the stream object provided as the stream parameter.

CopyToAsync(Stream, TransportContext)	
Serialize the HTTP content into a stream of bytes and copies it to the stream object provided as the stream parameter.

CopyToAsync(Stream)	
Serialize the HTTP content into a stream of bytes and copies it to the stream object provided as the stream parameter.

CreateContentReadStream(CancellationToken)	
Serializes the HTTP content to a memory stream.

CreateContentReadStreamAsync()	
Serialize the HTTP content to a memory stream as an asynchronous operation.

CreateContentReadStreamAsync(CancellationToken)	
Serializes the HTTP content to a memory stream as an asynchronous operation.

Dispose()	
Releases the unmanaged resources and disposes of the managed resources used by the HttpContent.

Dispose(Boolean)	
Releases the unmanaged resources used by the HttpContent and optionally disposes of the managed resources.

Equals(Object)	
Determines whether the specified object is equal to the current object.

(Inherited from Object)
GetHashCode()	
Serves as the default hash function.

(Inherited from Object)
GetType()	
Gets the Type of the current instance.

(Inherited from Object)
LoadIntoBufferAsync()	
Serialize the HTTP content to a memory buffer as an asynchronous operation.

LoadIntoBufferAsync(CancellationToken)	
Serialize the HTTP content to a memory buffer as an asynchronous operation.

LoadIntoBufferAsync(Int64, CancellationToken)	
Serialize the HTTP content to a memory buffer as an asynchronous operation.

LoadIntoBufferAsync(Int64)	
Serialize the HTTP content to a memory buffer as an asynchronous operation.

MemberwiseClone()	
Creates a shallow copy of the current Object.

(Inherited from Object)
ReadAsByteArrayAsync()	
Serialize the HTTP content to a byte array as an asynchronous operation.

ReadAsByteArrayAsync(CancellationToken)	
Serialize the HTTP content to a byte array as an asynchronous operation.

ReadAsStream()	
Serializes the HTTP content and returns a stream that represents the content.

ReadAsStream(CancellationToken)	
Serializes the HTTP content and returns a stream that represents the content.

ReadAsStreamAsync()	
Serialize the HTTP content and return a stream that represents the content as an asynchronous operation.

ReadAsStreamAsync(CancellationToken)	
Serialize the HTTP content and return a stream that represents the content as an asynchronous operation.

ReadAsStringAsync()	
Serialize the HTTP content to a string as an asynchronous operation.

ReadAsStringAsync(CancellationToken)	
Serialize the HTTP content to a string as an asynchronous operation.

SerializeToStream(Stream, TransportContext, CancellationToken)	
When overridden in a derived class, serializes the HTTP content to a stream. Otherwise, throws a NotSupportedException.

SerializeToStreamAsync(Stream, TransportContext, CancellationToken)	
Serialize the HTTP content to a stream as an asynchronous operation.

SerializeToStreamAsync(Stream, TransportContext)	
Serialize the HTTP content to a stream as an asynchronous operation.

ToString()	
Returns a string that represents the current object.

(Inherited from Object)
TryComputeLength(Int64)	
Determines whether the HTTP content has a valid length in bytes.


**/