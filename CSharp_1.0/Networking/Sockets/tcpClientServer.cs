/**
To work with Transmission Control Protocol (TCP), you have two options: either use Socket for maximum control and performance, or use the TcpClient and TcpListener helper classes. TcpClient and TcpListener are built on top of the System.Net.Sockets.Socket class and take care of the details of transferring data for ease of use.

The protocol classes use the underlying Socket class to provide simple access to network services without the overhead of maintaining state information or knowing the details of setting up protocol-specific sockets. To use asynchronous Socket methods, you can use the asynchronous methods supplied by the NetworkStream class. To access features of the Socket class not exposed by the protocol classes, you must use the Socket class.

TcpClient and TcpListener represent the network using the NetworkStream class. You use the GetStream method to return the network stream, and then call the stream's NetworkStream.ReadAsync and NetworkStream.WriteAsync methods. The NetworkStream does not own the protocol classes' underlying socket, so closing it does not affect the socket.

Use TcpClient and TcpListener
The TcpClient class requests data from an internet resource using TCP. The methods and properties of TcpClient abstract the details for creating a Socket for requesting and receiving data using TCP. Because the connection to the remote device is represented as a stream, data can be read and written with .NET Framework stream-handling techniques.

The TCP protocol establishes a connection with a remote endpoint and then uses that connection to send and receive data packets. TCP is responsible for ensuring that data packets are sent to the endpoint and assembled in the correct order when they arrive.

Create an IP endpoint
When working with System.Net.Sockets, you represent a network endpoint as an IPEndPoint object. The IPEndPoint is constructed with an IPAddress and its corresponding port number. Before you can initiate a conversation through a Socket, you create a data pipe between your app and the remote destination.

TCP/IP uses a network address and a service port number to uniquely identify a service. The network address identifies a specific network destination; the port number identifies the specific service on that device to connect to. The combination of network address and service port is called an endpoint, which is represented in the .NET by the EndPoint class. A descendant of EndPoint is defined for each supported address family; for the IP address family, the class is IPEndPoint.

The Dns class provides domain-name services to apps that use TCP/IP internet services. The GetHostEntryAsync method queries a DNS server to map a user-friendly domain name (such as "host.contoso.com") to a numeric Internet address (such as 192.168.1.1). GetHostEntryAsync returns a Task<IPHostEntry> that when awaited contains a list of addresses and aliases for the requested name. In most cases, you can use the first address returned in the AddressList array. The following code gets an IPAddress containing the IP address for the server host.contoso.com.

Create a TcpClient:
---------------------
var ipEndPoint = new IPEndPoint(ipAddress, 13);

using TcpClient client = new();
await client.ConnectAsync(ipEndPoint);
await using NetworkStream stream = client.GetStream();

var buffer = new byte[1_024];
int received = await stream.ReadAsync(buffer);

var message = Encoding.UTF8.GetString(buffer, 0, received);
Console.WriteLine($"Message received: \"{message}\"");
// Sample output:
//     Message received: "📅 8/22/2022 9:07:17 AM 🕛"


Create a TcpListener:
--------------------
The TcpListener type is used to monitor a TCP port for incoming requests and then create either a Socket or a TcpClient that manages the connection to the client. The Start method enables listening, and the Stop method disables listening on the port. The AcceptTcpClientAsync method accepts incoming connection requests and creates a TcpClient to handle the request, and the AcceptSocketAsync method accepts incoming connection requests and creates a Socket to handle the request.


var ipEndPoint = new IPEndPoint(IPAddress.Any, 13);
TcpListener listener = new(ipEndPoint);

try
{    
    listener.Start();

    using TcpClient handler = await listener.AcceptTcpClientAsync();
    await using NetworkStream stream = handler.GetStream();

    var message = $"📅 {DateTime.Now} 🕛";
    var dateTimeBytes = Encoding.UTF8.GetBytes(message);
    await stream.WriteAsync(dateTimeBytes);

    Console.WriteLine($"Sent message: \"{message}\"");
    // Sample output:
    //     Sent message: "📅 8/22/2022 9:07:17 AM 🕛"
}
finally
{
    listener.Stop();
}


**/