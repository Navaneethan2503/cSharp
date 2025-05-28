/**
Socket Class:
---------------
Implements the Berkeley sockets interface.

    public class Socket : IDisposable

Constructors:
-------------
Socket(AddressFamily, SocketType, ProtocolType)	- Initializes a new instance of the Socket class using the specified address family, socket type and protocol.
Socket(SafeSocketHandle)	- Initializes a new instance of the Socket class for the specified socket handle.
Socket(SocketInformation)	- Initializes a new instance of the Socket class using the specified value returned from DuplicateAndClose(Int32).
Socket(SocketType, ProtocolType)	- Initializes a new instance of the Socket class using the specified socket type and protocol. If the operating system supports IPv6, this constructor creates a dual-mode socket; otherwise, it creates an IPv4 socket.

Properties:
-----------
AddressFamily	- Gets the address family of the Socket.
    public System.Net.Sockets.AddressFamily AddressFamily { get; }

Available	- Gets the amount of data that has been received from the network and is available to be read.
    public int Available { get; }

Blocking	- Gets or sets a value that indicates whether the Socket is in blocking mode.
    public bool Blocking { get; set; }

Connected	- Gets a value that indicates whether a Socket is connected to a remote host as of the last Send or Receive operation.
    public bool Connected { get; }

DontFragment	- Gets or sets a value that specifies whether the Socket allows Internet Protocol (IP) datagrams to be fragmented.
    public bool DontFragment { get; set; }

DualMode	- Gets or sets a value that specifies whether the Socket is a dual-mode socket used for both IPv4 and IPv6.
    public bool DualMode { get; set; }

EnableBroadcast	- Gets or sets a Boolean value that specifies whether the Socket can send broadcast packets.
ExclusiveAddressUse	- Gets or sets a value that indicates whether the Socket allows only one process to bind to a port.
Handle	- Gets the operating system handle for the Socket.
    public IntPtr Handle { get; }

IsBound	= Gets a value that indicates whether the Socket is bound to a specific local port.
LingerState	- Gets or sets a value that specifies whether the Socket will delay closing a socket in an attempt to send all pending data.
LocalEndPoint	- Gets the local endpoint.
    public System.Net.EndPoint? LocalEndPoint { get; }

MulticastLoopback	- Gets or sets a value that specifies whether outgoing multicast packets are delivered to the sending application.
NoDelay	- Gets or sets a Boolean value that specifies whether the stream Socket is using the Nagle algorithm.
OSSupportsIPv4	- Indicates whether the underlying operating system and network adaptors support Internet Protocol version 4 (IPv4).
OSSupportsIPv6	- Indicates whether the underlying operating system and network adaptors support Internet Protocol version 6 (IPv6).
OSSupportsUnixDomainSockets	- Indicates whether the underlying operating system support the Unix domain sockets.
ProtocolType	- Gets the protocol type of the Socket.
ReceiveBufferSize	- Gets or sets a value that specifies the size of the receive buffer of the Socket.
ReceiveTimeout	- Gets or sets a value that specifies the amount of time after which a synchronous Receive call will time out.
RemoteEndPoint	- Gets the remote endpoint.
    public System.Net.EndPoint? RemoteEndPoint { get; }

SafeHandle	- Gets a SafeSocketHandle that represents the socket handle that the current Socket object encapsulates.
SendBufferSize	- Gets or sets a value that specifies the size of the send buffer of the Socket.
SendTimeout	- Gets or sets a value that specifies the amount of time after which a synchronous Send call will time out.
SocketType	- Gets the type of the Socket.
Ttl	- Gets or sets a value that specifies the Time To Live (TTL) value of Internet Protocol (IP) packets sent by the Socket.

Methods:
-----------
Accept()	- Creates a new Socket for a newly created connection.
    public System.Net.Sockets.Socket Accept();

AcceptAsync()	- Accepts an incoming connection.
AcceptAsync(CancellationToken)	- Accepts an incoming connection.
AcceptAsync(Socket, CancellationToken)	- Accepts an incoming connection.
AcceptAsync(Socket)	- Accepts an incoming connection.
AcceptAsync(SocketAsyncEventArgs)	- Begins an asynchronous operation to accept an incoming connection attempt.
    public System.Threading.Tasks.Task<System.Net.Sockets.Socket> AcceptAsync();
    public System.Threading.Tasks.ValueTask<System.Net.Sockets.Socket> AcceptAsync(System.Net.Sockets.Socket? acceptSocket, System.Threading.CancellationToken cancellationToken);

BeginAccept(AsyncCallback, Object)	- Begins an asynchronous operation to accept an incoming connection attempt.
BeginAccept(Int32, AsyncCallback, Object)	- Begins an asynchronous operation to accept an incoming connection attempt and receives the first block of data sent by the client application.
BeginAccept(Socket, Int32, AsyncCallback, Object)	- Begins an asynchronous operation to accept an incoming connection attempt from a specified socket and receives the first block of data sent by the client application.
    public IAsyncResult BeginAccept(AsyncCallback? callback, object? state);
    public IAsyncResult BeginAccept(System.Net.Sockets.Socket? acceptSocket, int receiveSize, AsyncCallback? callback, object? state);

BeginConnect(EndPoint, AsyncCallback, Object)	- Begins an asynchronous request for a remote host connection.
BeginConnect(IPAddress, Int32, AsyncCallback, Object)	- Begins an asynchronous request for a remote host connection. The host is specified by an IPAddress and a port number.
BeginConnect(IPAddress[], Int32, AsyncCallback, Object)	- Begins an asynchronous request for a remote host connection. The host is specified by an IPAddress array and a port number.
BeginConnect(String, Int32, AsyncCallback, Object)	- Begins an asynchronous request for a remote host connection. The host is specified by a host name and a port number.
    public IAsyncResult BeginConnect(System.Net.EndPoint remoteEP, AsyncCallback? callback, object? state);
    public IAsyncResult BeginConnect(string host, int port, AsyncCallback? requestCallback, object? state);
    public IAsyncResult BeginConnect(System.Net.IPAddress address, int port, AsyncCallback? requestCallback, object? state);

BeginDisconnect(Boolean, AsyncCallback, Object)	- Begins an asynchronous request to disconnect from a remote endpoint.
    public IAsyncResult BeginDisconnect(bool reuseSocket, AsyncCallback? callback, object? state);

BeginReceive(Byte[], Int32, Int32, SocketFlags, AsyncCallback, Object)	- Begins to asynchronously receive data from a connected Socket.
BeginReceive(Byte[], Int32, Int32, SocketFlags, SocketError, AsyncCallback, Object)	- Begins to asynchronously receive data from a connected Socket.
BeginReceive(IList<ArraySegment<Byte>>, SocketFlags, AsyncCallback, Object)	- Begins to asynchronously receive data from a connected Socket.
BeginReceive(IList<ArraySegment<Byte>>, SocketFlags, SocketError, AsyncCallback, Object)	- Begins to asynchronously receive data from a connected Socket.
    public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags, AsyncCallback? callback, object? state);
    public IAsyncResult? BeginReceive(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags, out System.Net.Sockets.SocketError errorCode, AsyncCallback? callback, object? state);
    public IAsyncResult? BeginReceive(System.Collections.Generic.IList<ArraySegment<byte>> buffers, System.Net.Sockets.SocketFlags socketFlags, out System.Net.Sockets.SocketError errorCode, AsyncCallback? callback, object? state);

BeginReceiveFrom(Byte[], Int32, Int32, SocketFlags, EndPoint, AsyncCallback, Object)	- Begins to asynchronously receive data from a specified network device.
    public IAsyncResult BeginReceiveFrom(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags, ref System.Net.EndPoint remoteEP, AsyncCallback? callback, object? state);

BeginReceiveMessageFrom(Byte[], Int32, Int32, SocketFlags, EndPoint, AsyncCallback, Object)	- Begins to asynchronously receive the specified number of bytes of data into the specified location of the data buffer, using the specified SocketFlags, and stores the endpoint and packet information.
    public IAsyncResult BeginReceiveMessageFrom(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags, ref System.Net.EndPoint remoteEP, AsyncCallback? callback, object? state);

BeginSend(Byte[], Int32, Int32, SocketFlags, AsyncCallback, Object)	- Sends data asynchronously to a connected Socket.
BeginSend(Byte[], Int32, Int32, SocketFlags, SocketError, AsyncCallback, Object)	- Sends data asynchronously to a connected Socket.
BeginSend(IList<ArraySegment<Byte>>, SocketFlags, AsyncCallback, Object)	- Sends data asynchronously to a connected Socket.
BeginSend(IList<ArraySegment<Byte>>, SocketFlags, SocketError, AsyncCallback, Object)	- Sends data asynchronously to a connected Socket.
    public IAsyncResult BeginSend(System.Collections.Generic.IList<ArraySegment<byte>> buffers, System.Net.Sockets.SocketFlags socketFlags, AsyncCallback? callback, object? state);
    public IAsyncResult? BeginSend(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags, out System.Net.Sockets.SocketError errorCode, AsyncCallback? callback, object? state);

BeginSendFile(String, AsyncCallback, Object)	- Sends the file fileName to a connected Socket object using the UseDefaultWorkerThread flag.
    public IAsyncResult BeginSendFile(string? fileName, AsyncCallback? callback, object? state);

BeginSendFile(String, Byte[], Byte[], TransmitFileOptions, AsyncCallback, Object)	- Sends a file and buffers of data asynchronously to a connected Socket object.
    public IAsyncResult BeginSendFile(string? fileName, byte[]? preBuffer, byte[]? postBuffer, System.Net.Sockets.TransmitFileOptions flags, AsyncCallback? callback, object? state);

BeginSendTo(Byte[], Int32, Int32, SocketFlags, EndPoint, AsyncCallback, Object)	- Sends data asynchronously to a specific remote host.
    public IAsyncResult BeginSendTo(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags, System.Net.EndPoint remoteEP, AsyncCallback? callback, object? state);

Bind(EndPoint)	- Associates a Socket with a local endpoint.
        public void Bind(System.Net.EndPoint localEP);
    Remarks
    Use the Bind method if you need to use a specific local endpoint. You must call Bind before you can call the Listen method. You do not need to call Bind before using the Connect method unless you need to use a specific local endpoint. You can use the Bind method on both connectionless and connection-oriented protocols.
    Before calling Bind, you must first create the local IPEndPoint from which you intend to communicate data. If you do not care which local address is assigned, you can create an IPEndPoint using IPAddress.Any as the address parameter, and the underlying service provider will assign the most appropriate network address. This might help simplify your application if you have multiple network interfaces. If you do not care which local port is used, you can create an IPEndPoint using 0 for the port number. In this case, the service provider will assign an available port number between 1024 and 5000.
    If you use the above approach, you can discover what local network address and port number has been assigned by calling the LocalEndPoint. If you are using a connection-oriented protocol, LocalEndPoint will not return the locally assigned network address until after you have made a call to the Connect or EndConnect method. If you are using a connectionless protocol, you will not have access to this information until you have completed a send or receive.
    If a UDP socket wants to receive interface information on received packets, the SetSocketOption method should be explicitly called with the socket option set to PacketInformation immediately after calling the Bind method.

CancelConnectAsync(SocketAsyncEventArgs)	- Cancels an asynchronous request for a remote host connection.
    public static void CancelConnectAsync(System.Net.Sockets.SocketAsyncEventArgs e);

Close()	- Closes the Socket connection and releases all associated resources.
    public void Close();
    The Close method closes the remote host connection and releases all managed and unmanaged resources associated with the Socket. Upon closing, the Connected property is set to false.

Close(Int32)	- Closes the Socket connection and releases all associated resources with a specified timeout to allow queued data to be sent.
    public void Close(int timeout);

Connect(EndPoint)	- Establishes a connection to a remote host.
    public void Connect(System.Net.EndPoint remoteEP);

Connect(IPAddress, Int32)	 - Establishes a connection to a remote host. The host is specified by an IP address and a port number.
    public void Connect(System.Net.IPAddress address, int port);

Connect(IPAddress[], Int32)	- Establishes a connection to a remote host. The host is specified by an array of IP addresses and a port number.
Connect(String, Int32)	- Establishes a connection to a remote host. The host is specified by a host name and a port number.
    public void Connect(string host, int port);

ConnectAsync(EndPoint, CancellationToken)	- Establishes a connection to a remote host.
ConnectAsync(EndPoint)	- Establishes a connection to a remote host.
ConnectAsync(IPAddress, Int32, CancellationToken)	- Establishes a connection to a remote host.
ConnectAsync(IPAddress, Int32)	- Establishes a connection to a remote host.
ConnectAsync(IPAddress[], Int32, CancellationToken)	- Establishes a connection to a remote host.
ConnectAsync(IPAddress[], Int32)	- Establishes a connection to a remote host.
ConnectAsync(SocketAsyncEventArgs)	- Begins an asynchronous request for a connection to a remote host.
ConnectAsync(SocketType, ProtocolType, SocketAsyncEventArgs)	- Begins an asynchronous request for a connection to a remote host.
ConnectAsync(String, Int32, CancellationToken)	- Establishes a connection to a remote host.
ConnectAsync(String, Int32)	- Establishes a connection to a remote host.
    public static bool ConnectAsync(System.Net.Sockets.SocketType socketType, System.Net.Sockets.ProtocolType protocolType, System.Net.Sockets.SocketAsyncEventArgs e);
    public System.Threading.Tasks.Task ConnectAsync(System.Net.EndPoint remoteEP);
    public System.Threading.Tasks.Task ConnectAsync(System.Net.IPAddress address, int port);
    public System.Threading.Tasks.ValueTask ConnectAsync(System.Net.IPAddress address, int port, System.Threading.CancellationToken cancellationToken);

Disconnect(Boolean)	- Closes the socket connection and allows reuse of the socket.
    public void Disconnect(bool reuseSocket);

DisconnectAsync(Boolean, CancellationToken)	- Disconnects a connected socket from the remote host.
    public System.Threading.Tasks.ValueTask DisconnectAsync(bool reuseSocket, System.Threading.CancellationToken cancellationToken = default);

DisconnectAsync(SocketAsyncEventArgs)	- Begins an asynchronous request to disconnect from a remote endpoint.
Dispose()	- Releases all resources used by the current instance of the Socket class.
    public void Dispose();
    
Dispose(Boolean)	 - Releases the unmanaged resources used by the Socket, and optionally disposes of the managed resources.
DuplicateAndClose(Int32)	- Duplicates the socket reference for the target process, and closes the socket for this process.
EndAccept(Byte[], IAsyncResult)	- Asynchronously accepts an incoming connection attempt and creates a new Socket object to handle remote host communication. This method returns a buffer that contains the initial data transferred.
EndAccept(Byte[], Int32, IAsyncResult)	- Asynchronously accepts an incoming connection attempt and creates a new Socket object to handle remote host communication. This method returns a buffer that contains the initial data and the number of bytes transferred.
EndAccept(IAsyncResult)	- Asynchronously accepts an incoming connection attempt and creates a new Socket to handle remote host communication.
    public System.Net.Sockets.Socket EndAccept(out byte[] buffer, IAsyncResult asyncResult);
    public System.Net.Sockets.Socket EndAccept(out byte[] buffer, out int bytesTransferred, IAsyncResult asyncResult);

EndConnect(IAsyncResult)	- Ends a pending asynchronous connection request.
    public void EndConnect(IAsyncResult asyncResult);

EndDisconnect(IAsyncResult)	- Ends a pending asynchronous disconnect request.
    public void EndDisconnect(IAsyncResult asyncResult);

EndReceive(IAsyncResult, SocketError)	- Ends a pending asynchronous read.
EndReceive(IAsyncResult)	- Ends a pending asynchronous read.
    public int EndReceive(IAsyncResult asyncResult, out System.Net.Sockets.SocketError errorCode);

EndReceiveFrom(IAsyncResult, EndPoint)	- Ends a pending asynchronous read from a specific endpoint.
    public int EndReceiveFrom(IAsyncResult asyncResult, ref System.Net.EndPoint endPoint);

EndReceiveMessageFrom(IAsyncResult, SocketFlags, EndPoint, IPPacketInformation)	- Ends a pending asynchronous read from a specific endpoint. This method also reveals more information about the packet than EndReceiveFrom(IAsyncResult, EndPoint).
    public int EndReceiveFrom(IAsyncResult asyncResult, ref System.Net.EndPoint endPoint);

EndSend(IAsyncResult, SocketError)	- Ends a pending asynchronous send.
EndSend(IAsyncResult)	- Ends a pending asynchronous send.
    public int EndSend(IAsyncResult asyncResult, out System.Net.Sockets.SocketError errorCode);

EndSendFile(IAsyncResult)	- Ends a pending asynchronous send of a file.
    public void EndSendFile(IAsyncResult asyncResult);

EndSendTo(IAsyncResult)	- Ends a pending asynchronous send to a specific location.
    public int EndSendTo(IAsyncResult asyncResult);

Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Finalize()	- Frees resources used by the Socket class.
    ~Socket();

GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetRawSocketOption(Int32, Int32, Span<Byte>)	- Gets a socket option value using platform-specific level and name identifiers.
    public int GetRawSocketOption(int optionLevel, int optionName, Span<byte> optionValue);

GetSocketOption(SocketOptionLevel, SocketOptionName, Byte[])	- Returns the specified Socket option setting, represented as a byte array.
GetSocketOption(SocketOptionLevel, SocketOptionName, Int32)	- Returns the value of the specified Socket option in an array.
GetSocketOption(SocketOptionLevel, SocketOptionName)	- Returns the value of a specified Socket option, represented as an object.
    public void GetSocketOption(System.Net.Sockets.SocketOptionLevel optionLevel, System.Net.Sockets.SocketOptionName optionName, byte[] optionValue);
    public object? GetSocketOption(System.Net.Sockets.SocketOptionLevel optionLevel, System.Net.Sockets.SocketOptionName optionName);
    
GetType()	- Gets the Type of the current instance.(Inherited from Object)
IOControl(Int32, Byte[], Byte[])	- Sets low-level operating modes for the Socket using numerical control codes.
IOControl(IOControlCode, Byte[], Byte[])	- Sets low-level operating modes for the Socket using the IOControlCode enumeration to specify control codes.
    public int IOControl(int ioControlCode, byte[]? optionInValue, byte[]? optionOutValue);
    public int IOControl(System.Net.Sockets.IOControlCode ioControlCode, byte[]? optionInValue, byte[]? optionOutValue);

Listen()	- Places a Socket in a listening state.
Listen(Int32)	- Places a Socket in a listening state.
    public void Listen();
    public void Listen(int backlog);

MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Poll(Int32, SelectMode)	- Determines the status of the Socket.
Poll(TimeSpan, SelectMode)	- Determines the status of the Socket.
    public bool Poll(int microSeconds, System.Net.Sockets.SelectMode mode);

Receive(Byte[], Int32, Int32, SocketFlags, SocketError)	- Receives data from a bound Socket into a receive buffer, using the specified SocketFlags.
Receive(Byte[], Int32, Int32, SocketFlags)	- Receives the specified number of bytes from a bound Socket into the specified offset position of the receive buffer, using the specified SocketFlags.
Receive(Byte[], Int32, SocketFlags)	- Receives the specified number of bytes of data from a bound Socket into a receive buffer, using the specified SocketFlags.
Receive(Byte[], SocketFlags)	- Receives data from a bound Socket into a receive buffer, using the specified SocketFlags.
Receive(Byte[])	- Receives data from a bound Socket into a receive buffer.
Receive(IList<ArraySegment<Byte>>, SocketFlags, SocketError)	- Receives data from a bound Socket into the list of receive buffers, using the specified SocketFlags.
Receive(IList<ArraySegment<Byte>>, SocketFlags)	- Receives data from a bound Socket into the list of receive buffers, using the specified SocketFlags.
Receive(IList<ArraySegment<Byte>>)	- Receives data from a bound Socket into the list of receive buffers.
Receive(Span<Byte>, SocketFlags, SocketError)	- Receives data from a bound Socket into a receive buffer, using the specified SocketFlags.
Receive(Span<Byte>, SocketFlags)	 -Receives data from a bound Socket into a receive buffer, using the specified SocketFlags.
Receive(Span<Byte>)	- Receives data from a bound Socket into a receive buffer.
    public int Receive(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags, out System.Net.Sockets.SocketError errorCode);
    public int Receive(byte[] buffer, int size, System.Net.Sockets.SocketFlags socketFlags);
    public int Receive(byte[] buffer);

ReceiveAsync(ArraySegment<Byte>, SocketFlags)	- Receives data from a connected socket.
ReceiveAsync(ArraySegment<Byte>)	- Receives data from a connected socket.
ReceiveAsync(IList<ArraySegment<Byte>>, SocketFlags)	- Receives data from a connected socket.
ReceiveAsync(IList<ArraySegment<Byte>>)	- Receives data from a connected socket.
ReceiveAsync(Memory<Byte>, CancellationToken)	- Receives data from a connected socket.
ReceiveAsync(Memory<Byte>, SocketFlags, CancellationToken)	- Receives data from a connected socket.
ReceiveAsync(SocketAsyncEventArgs)	- Begins an asynchronous request to receive data from a connected Socket object.
    public System.Threading.Tasks.Task<int> ReceiveAsync(ArraySegment<byte> buffer);
    public System.Threading.Tasks.Task<int> ReceiveAsync(System.Collections.Generic.IList<ArraySegment<byte>> buffers);
    public System.Threading.Tasks.ValueTask<int> ReceiveAsync(Memory<byte> buffer, System.Net.Sockets.SocketFlags socketFlags, System.Threading.CancellationToken cancellationToken = default);

ReceiveFrom(Byte[], EndPoint)	- Receives a datagram into the data buffer and stores the endpoint.
ReceiveFrom(Byte[], Int32, Int32, SocketFlags, EndPoint)	- Receives the specified number of bytes of data into the specified location of the data buffer, using the specified SocketFlags, and stores the endpoint.
ReceiveFrom(Byte[], Int32, SocketFlags, EndPoint)	- Receives the specified number of bytes into the data buffer, using the specified SocketFlags, and stores the endpoint.
ReceiveFrom(Byte[], SocketFlags, EndPoint)	- Receives a datagram into the data buffer, using the specified SocketFlags, and stores the endpoint.
ReceiveFrom(Span<Byte>, EndPoint)	- Receives a datagram into the data buffer and stores the endpoint.
ReceiveFrom(Span<Byte>, SocketFlags, EndPoint)	- Receives a datagram into the data buffer, using the specified SocketFlags, and stores the endpoint.
ReceiveFrom(Span<Byte>, SocketFlags, SocketAddress)	- Receives a datagram into the data buffer, using the specified SocketFlags, and stores the endpoint.
    public int ReceiveFrom(byte[] buffer, ref System.Net.EndPoint remoteEP);
    public int ReceiveFrom(byte[] buffer, int size, System.Net.Sockets.SocketFlags socketFlags, ref System.Net.EndPoint remoteEP);

ReceiveFromAsync(ArraySegment<Byte>, EndPoint)	- Receives data and returns the endpoint of the sending host.
ReceiveFromAsync(ArraySegment<Byte>, SocketFlags, EndPoint)	- Receives data and returns the endpoint of the sending host.
ReceiveFromAsync(Memory<Byte>, EndPoint, CancellationToken)	- Receives data and returns the endpoint of the sending host.
ReceiveFromAsync(Memory<Byte>, SocketFlags, EndPoint, CancellationToken)	- Receives data and returns the endpoint of the sending host.
ReceiveFromAsync(Memory<Byte>, SocketFlags, SocketAddress, CancellationToken)	- Receives a datagram into the data buffer, using the specified SocketFlags, and stores the endpoint.
ReceiveFromAsync(SocketAsyncEventArgs)	- Begins to asynchronously receive data from a specified network device.
    public System.Threading.Tasks.Task<System.Net.Sockets.SocketReceiveFromResult> ReceiveFromAsync(ArraySegment<byte> buffer, System.Net.EndPoint remoteEndPoint);
    public System.Threading.Tasks.ValueTask<int> ReceiveFromAsync(Memory<byte> buffer, System.Net.Sockets.SocketFlags socketFlags, System.Net.SocketAddress receivedAddress, System.Threading.CancellationToken cancellationToken = default);

ReceiveMessageFrom(Byte[], Int32, Int32, SocketFlags, EndPoint, IPPacketInformation)	- Receives the specified number of bytes of data into the specified location of the data buffer, using the specified SocketFlags, and stores the endpoint and packet information.
ReceiveMessageFrom(Span<Byte>, SocketFlags, EndPoint, IPPacketInformation)	- Receives the specified number of bytes of data into the specified location of the data buffer, using the specified socketFlags, and stores the endpoint and packet information.
    public int ReceiveMessageFrom(byte[] buffer, int offset, int size, ref System.Net.Sockets.SocketFlags socketFlags, ref System.Net.EndPoint remoteEP, out System.Net.Sockets.IPPacketInformation ipPacketInformation);
    public int ReceiveMessageFrom(Span<byte> buffer, ref System.Net.Sockets.SocketFlags socketFlags, ref System.Net.EndPoint remoteEP, out System.Net.Sockets.IPPacketInformation ipPacketInformation);

ReceiveMessageFromAsync(ArraySegment<Byte>, EndPoint)	- Receives data and returns additional information about the sender of the message.
ReceiveMessageFromAsync(ArraySegment<Byte>, SocketFlags, EndPoint)	- Receives data and returns additional information about the sender of the message.
ReceiveMessageFromAsync(Memory<Byte>, EndPoint, CancellationToken)	- Receives data and returns additional information about the sender of the message.
ReceiveMessageFromAsync(Memory<Byte>, SocketFlags, EndPoint, CancellationToken)	- Receives data and returns additional information about the sender of the message.
ReceiveMessageFromAsync(SocketAsyncEventArgs)	- Begins to asynchronously receive the specified number of bytes of data into the specified location in the data buffer, using the specified SocketFlags, and stores the endpoint and packet information.

Select(IList, IList, IList, Int32)	- Determines the status of one or more sockets.
Select(IList, IList, IList, TimeSpan)	- Determines the status of one or more sockets.
    public static void Select(System.Collections.IList? checkRead, System.Collections.IList? checkWrite, System.Collections.IList? checkError, TimeSpan timeout);

Send(Byte[], Int32, Int32, SocketFlags, SocketError)	-Sends the specified number of bytes of data to a connected Socket, starting at the specified offset, and using the specified SocketFlags.
Send(Byte[], Int32, Int32, SocketFlags)	- Sends the specified number of bytes of data to a connected Socket, starting at the specified offset, and using the specified SocketFlags.
Send(Byte[], Int32, SocketFlags)	- Sends the specified number of bytes of data to a connected Socket, using the specified SocketFlags.
Send(Byte[], SocketFlags)	- Sends data to a connected Socket using the specified SocketFlags.
Send(Byte[])	-  Sends data to a connected Socket.
Send(IList<ArraySegment<Byte>>, SocketFlags, SocketError)	- Sends the set of buffers in the list to a connected Socket, using the specified SocketFlags.
Send(IList<ArraySegment<Byte>>, SocketFlags)	- Sends the set of buffers in the list to a connected Socket, using the specified SocketFlags.
Send(IList<ArraySegment<Byte>>)	- Sends the set of buffers in the list to a connected Socket.
Send(ReadOnlySpan<Byte>, SocketFlags, SocketError)	- Sends data to a connected Socket using the specified SocketFlags.
Send(ReadOnlySpan<Byte>, SocketFlags)	- Sends data to a connected Socket using the specified SocketFlags.
Send(ReadOnlySpan<Byte>)	- Sends data to a connected Socket.
    public int Send(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags, out System.Net.Sockets.SocketError errorCode);
    public int Send(byte[] buffer);

SendAsync(ArraySegment<Byte>, SocketFlags)	- Sends data on a connected socket.
SendAsync(ArraySegment<Byte>)	 - ends data on a connected socket.
SendAsync(IList<ArraySegment<Byte>>, SocketFlags)	- Sends data on a connected socket.
SendAsync(IList<ArraySegment<Byte>>)	- Sends data on a connected socket.
SendAsync(ReadOnlyMemory<Byte>, CancellationToken)	- Sends data on a connected socket.
SendAsync(ReadOnlyMemory<Byte>, SocketFlags, CancellationToken)	- Sends data on a connected socket.
SendAsync(SocketAsyncEventArgs)	- Sends data asynchronously to a connected Socket object.
    public System.Threading.Tasks.Task<int> SendAsync(System.Collections.Generic.IList<ArraySegment<byte>> buffers);
    public System.Threading.Tasks.ValueTask<int> SendAsync(ReadOnlyMemory<byte> buffer, System.Threading.CancellationToken cancellationToken = default);

SendFile(String, Byte[], Byte[], TransmitFileOptions)	- Sends the file fileName and buffers of data to a connected Socket object using the specified TransmitFileOptions value.
SendFile(String, ReadOnlySpan<Byte>, ReadOnlySpan<Byte>, TransmitFileOptions)	- Sends the file fileName and buffers of data to a connected Socket object using the specified TransmitFileOptions value.
SendFile(String)	- Sends the file fileName to a connected Socket object with the UseDefaultWorkerThread transmit flag.
    public void SendFile(string? fileName);
    public void SendFile(string? fileName, ReadOnlySpan<byte> preBuffer, ReadOnlySpan<byte> postBuffer, System.Net.Sockets.TransmitFileOptions flags);

SendFileAsync(String, CancellationToken)	- Sends the file fileName to a connected Socket object.
SendFileAsync(String, ReadOnlyMemory<Byte>, ReadOnlyMemory<Byte>, TransmitFileOptions, Cancellation- Token)	- Sends the file fileName and buffers of data to a connected Socket object using the specified TransmitFileOptions value.
SendPacketsAsync(SocketAsyncEventArgs)	- Sends a collection of files or in memory data buffers asynchronously to a connected Socket object.
    public bool SendPacketsAsync(System.Net.Sockets.SocketAsyncEventArgs e);

SendTo(Byte[], EndPoint)	- Sends data to the specified endpoint.
SendTo(Byte[], Int32, Int32, SocketFlags, EndPoint)	- Sends the specified number of bytes of data to the specified endpoint, starting at the specified location in the buffer, and using the specified SocketFlags.
SendTo(Byte[], Int32, SocketFlags, EndPoint)	- Sends the specified number of bytes of data to the specified endpoint using the specified SocketFlags.
SendTo(Byte[], SocketFlags, EndPoint)	- Sends data to a specific endpoint using the specified SocketFlags.
SendTo(ReadOnlySpan<Byte>, EndPoint)	- Sends data to the specified endpoint.
SendTo(ReadOnlySpan<Byte>, SocketFlags, EndPoint)	- Sends data to a specific endpoint using the specified SocketFlags.
SendTo(ReadOnlySpan<Byte>, SocketFlags, SocketAddress)	- Sends data to a specific endpoint using the specified SocketFlags.
    public int SendTo(byte[] buffer, System.Net.EndPoint remoteEP);
    public int SendTo(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags, System.Net.EndPoint remoteEP);

SendToAsync(ArraySegment<Byte>, EndPoint)	- Sends data to the specified remote host.
SendToAsync(ArraySegment<Byte>, SocketFlags, EndPoint)	- Sends data to the specified remote host.
SendToAsync(ReadOnlyMemory<Byte>, EndPoint, CancellationToken)	- Sends data to the specified remote host.
SendToAsync(ReadOnlyMemory<Byte>, SocketFlags, EndPoint, CancellationToken)	- Sends data to the specified remote host.
SendToAsync(ReadOnlyMemory<Byte>, SocketFlags, SocketAddress, CancellationToken)	- Sends data to a specific endpoint using the specified SocketFlags.
SendToAsync(SocketAsyncEventArgs)	 - ends data asynchronously to a specific remote host.
    public System.Threading.Tasks.Task<int> SendToAsync(ArraySegment<byte> buffer, System.Net.Sockets.SocketFlags socketFlags, System.Net.EndPoint remoteEP);
    public System.Threading.Tasks.ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, System.Net.Sockets.SocketFlags socketFlags, System.Net.SocketAddress socketAddress, System.Threading.CancellationToken cancellationToken = default);

SetIPProtectionLevel(IPProtectionLevel)	- Sets the IP protection level on a socket.
SetRawSocketOption(Int32, Int32, ReadOnlySpan<Byte>)	- Sets a socket option value using platform-specific level and name identifiers.
SetSocketOption(SocketOptionLevel, SocketOptionName, Boolean)	- Sets the specified Socket option to the specified Boolean value.
SetSocketOption(SocketOptionLevel, SocketOptionName, Byte[])	- Sets the specified Socket option to the specified value, represented as a byte array.
SetSocketOption(SocketOptionLevel, SocketOptionName, Int32)	- Sets the specified Socket option to the specified integer value.
SetSocketOption(SocketOptionLevel, SocketOptionName, Object)	- Sets the specified Socket option to the specified value, represented as an object.
Shutdown(SocketShutdown)	- Disables sends and receives on a Socket.
    public void Shutdown(System.Net.Sockets.SocketShutdown how);
    
ToString()	- Returns a string that represents the current object.(Inherited from Object)

**/
