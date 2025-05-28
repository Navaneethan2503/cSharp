/**
ClientWebSocket Class:
------------------------
Provides a client for connecting to WebSocket services.

public sealed class ClientWebSocket : System.Net.WebSockets.WebSocket

Remarks
Some of the classes and class elements in the System.Net.WebSockets namespace are supported on Windows 7, Windows Vista SP2, and Windows Server 2008. However, the only public implementations of client and server WebSockets are supported on Windows 8 and Windows Server 2012. The class elements in the System.Net.WebSockets namespace that are supported on Windows 7, Windows Vista SP2, and Windows Server 2008 are abstract class elements. This allows an application developer to inherit and extend these abstract class classes and class elements with an actual implementation of client WebSockets.

Exactly one send and one receive is supported on each ClientWebSocket object in parallel. Issuing multiple sends or multiple receives at the same time (for example, without awaiting, or from multiple threads without synchronization) is not supported and will result in an undefined behavior. Ensure that the previous operation is awaited (or completed) before issuing the next one. You should serialize the access via whatever mechanism works best for you, for example, by using a lock or a semaphore.

Constructors:
-------------
ClientWebSocket()	- Creates an instance of the ClientWebSocket class.

Properties:
------------
CloseStatus	- Gets the reason why the close handshake was initiated on ClientWebSocket instance.
    public override System.Net.WebSockets.WebSocketCloseStatus? CloseStatus { get; }

CloseStatusDescription	- Gets a description of the reason why the ClientWebSocket instance was closed.
HttpResponseHeaders	- Gets (if CollectHttpResponseDetails is set) or sets the upgrade response headers.
HttpStatusCode	- Gets the upgrade response status code if CollectHttpResponseDetails is set.
    public System.Net.HttpStatusCode HttpStatusCode { get; }

Options	- Gets the WebSocket options for the ClientWebSocket instance.
State	- Gets the WebSocket state of the ClientWebSocket instance.
    public override System.Net.WebSockets.WebSocketState State { get; }
    
SubProtocol	- Gets the supported WebSocket sub-protocol for the ClientWebSocket instance.
    public override string? SubProtocol { get; }

Methods:
-------
Abort()	- Aborts the connection and cancels any pending IO operations.
CloseAsync(WebSocketCloseStatus, String, CancellationToken)	- Close the ClientWebSocket instance as an asynchronous operation.
    public override System.Threading.Tasks.Task CloseAsync(System.Net.WebSockets.WebSocketCloseStatus closeStatus, string? statusDescription, System.Threading.CancellationToken cancellationToken);

CloseOutputAsync(WebSocketCloseStatus, String, CancellationToken)	- Close the output for the ClientWebSocket instance as an asynchronous operation.
ConnectAsync(Uri, CancellationToken)	- Connects to a WebSocket server as an asynchronous operation.
ConnectAsync(Uri, HttpMessageInvoker, CancellationToken)	- Connects to a WebSocket server as an asynchronous operation.
    public System.Threading.Tasks.Task ConnectAsync(Uri uri, System.Threading.CancellationToken cancellationToken);
    public System.Threading.Tasks.Task ConnectAsync(Uri uri, System.Net.Http.HttpMessageInvoker? invoker, System.Threading.CancellationToken cancellationToken);

Dispose()	- Releases the unmanaged resources used by the ClientWebSocket instance.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ReceiveAsync(ArraySegment<Byte>, CancellationToken)	- Receives data on ClientWebSocket as an asynchronous operation.
ReceiveAsync(Memory<Byte>, CancellationToken)	- Receives data on ClientWebSocket as an asynchronous operation.
    public override System.Threading.Tasks.Task<System.Net.WebSockets.WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, System.Threading.CancellationToken cancellationToken);

SendAsync(ArraySegment<Byte>, WebSocketMessageType, Boolean, CancellationToken)	- Sends data on ClientWebSocket as an asynchronous operation.
SendAsync(ReadOnlyMemory<Byte>, WebSocketMessageType, Boolean, CancellationToken)	- Sends data on ClientWebSocket from a read-only byte memory range as an asynchronous operation.
SendAsync(ReadOnlyMemory<Byte>, WebSocketMessageType, WebSocketMessageFlags, CancellationToken)	- Sends data on ClientWebSocket from a read-only byte memory range as an asynchronous operation.
    public override System.Threading.Tasks.ValueTask SendAsync(ReadOnlyMemory<byte> buffer, System.Net.WebSockets.WebSocketMessageType messageType, bool endOfMessage, System.Threading.CancellationToken cancellationToken);

ToString()	- Returns a string that represents the current object.(Inherited from Object)

**/