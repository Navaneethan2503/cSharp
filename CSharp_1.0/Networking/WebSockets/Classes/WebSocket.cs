/**
WebSocket CLass:
------------------
The WebSocket class allows applications to send and receive data after the WebSocket upgrade has completed.

public abstract class WebSocket : IDisposable

Remarks
Some of the classes in the System.Net.WebSockets namespace are supported on Windows 7, Windows Vista SP2, and Windows Server 2008. However, the only public implementations of client and server WebSockets are supported on Windows 8 and Windows Server 2012. The classes and class elements in the System.Net.WebSockets namespace that are supported on Windows 7, Windows Vista SP2, and Windows Server 2008 are abstract classes. This allows an application developer to inherit and extend these abstract classes with an actual implementation of client WebSockets.

Exactly one send and one receive is supported on each WebSocket object in parallel. Issuing multiple sends or multiple receives at the same time (for example, without awaiting, or from multiple threads without synchronization) is not supported and will result in an undefined behavior. Ensure that the previous operation is awaited (or completed) before issuing the next one. Serialize the access via whatever mechanism works best for you, for example, by using a lock or a semaphore.

Constructors:
-------------
WebSocket()	- Creates an instance of the WebSocket class.

Properties:
----------
CloseStatus	- Indicates the reason why the remote endpoint initiated the close handshake.
CloseStatusDescription	- Allows the remote endpoint to describe the reason why the connection was closed.
DefaultKeepAliveInterval	- Gets the default WebSocket protocol keep-alive interval.
State	- Returns the current state of the WebSocket connection.
SubProtocol	- Gets the subprotocol that was negotiated during the opening handshake.

Methods:
----------
Abort()	- Aborts the WebSocket connection and cancels any pending IO operations.
CloseAsync(WebSocketCloseStatus, String, CancellationToken)	 - Closes the WebSocket connection as an asynchronous operation using the close handshake defined in the WebSocket protocol specification section 7.
CloseOutputAsync(WebSocketCloseStatus, String, CancellationToken)	- Initiates or completes the close handshake defined in the WebSocket protocol specification section 7.
CreateClientBuffer(Int32, Int32)	- Create client buffers to use with this WebSocket instance.
CreateClientWebSocket(Stream, String, Int32, Int32, TimeSpan, Boolean, ArraySegment<Byte>)	- This API supports the product infrastructure and is not intended to be used directly from your code.
Allows callers to create a client side WebSocket class which will use the WSPC for framing purposes.- 
CreateFromStream(Stream, Boolean, String, TimeSpan) - Creates a new WebSocket object that operates on the specified stream, which represents a web socket connection.
CreateFromStream(Stream, WebSocketCreationOptions)	- Creates a WebSocket that operates on a Stream representing a web socket connection.
CreateServerBuffer(Int32)	- Creates a WebSocket server buffer.
Dispose()	- Used to clean up unmanaged resources for ASP.NET and self-hosted implementations.
Equals(Object)	 - Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
IsStateTerminal(WebSocketState)	- Returns a value that indicates if the state of the WebSocket instance is closed or aborted.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ReceiveAsync(ArraySegment<Byte>, CancellationToken)	- Receives data from the WebSocket connection asynchronously.
ReceiveAsync(Memory<Byte>, CancellationToken)	- Receives data from the WebSocket connection asynchronously.
RegisterPrefixes()	- This API supports the product infrastructure and is not intended to be used directly from your code.

SendAsync(ArraySegment<Byte>, WebSocketMessageType, Boolean, CancellationToken)	- Sends data over the WebSocket connection asynchronously.
SendAsync(ReadOnlyMemory<Byte>, WebSocketMessageType, Boolean, CancellationToken)	- Sends data over the WebSocket connection asynchronously.
SendAsync(ReadOnlyMemory<Byte>, WebSocketMessageType, WebSocketMessageFlags, CancellationToken)	- Sends data over the WebSocket connection asynchronously.
ThrowOnInvalidState(WebSocketState, WebSocketState[])	- Verifies that the connection is in an expected state.
ToString()	- Returns a string that represents the current object.(Inherited from Object)


**/