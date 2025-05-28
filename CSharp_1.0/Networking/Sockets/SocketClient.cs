/**
Use Sockets to send and receive data over TCP:
-----------------------------------------------
Before you can use a socket to communicate with remote devices, the socket must be initialized with protocol and network address information. The constructor for the Socket class has parameters that specify the address family, socket type, and protocol type that the socket uses to make connections. When connecting a client socket to a server socket, the client will use an IPEndPoint object to specify the network address of the server.

Create an IP endpoint:
----------------------
When working with System.Net.Sockets, you represent a network endpoint as an IPEndPoint object. The IPEndPoint is constructed with an IPAddress and its corresponding port number. Before you can initiate a conversation through a Socket, you create a data pipe between your app and the remote destination.

TCP/IP uses a network address and a service port number to uniquely identify a service. The network address identifies a specific network destination; the port number identifies the specific service on that device to connect to. The combination of network address and service port is called an endpoint, which is represented in the .NET by the EndPoint class. A descendant of EndPoint is defined for each supported address family; for the IP address family, the class is IPEndPoint.

The Dns class provides domain-name services to apps that use TCP/IP internet services. The GetHostEntryAsync method queries a DNS server to map a user-friendly domain name (such as "host.contoso.com") to a numeric Internet address (such as 192.168.1.1). GetHostEntryAsync returns a Task<IPHostEntry> that when awaited contains a list of addresses and aliases for the requested name. In most cases, you can use the first address returned in the AddressList array. The following code gets an IPAddress containing the IP address for the server host.contoso.com.

The Internet Assigned Numbers Authority (IANA) defines port numbers for common services. For more information, see IANA: Service Name and Transport Protocol Port Number Registry). Other services can have registered port numbers in the range 1,024 to 65,535. The following code combines the IP address for host.contoso.com with a port number to create a remote endpoint for a connection.

IPEndPoint ipEndPoint = new(ipAddress, 11_000);
After determining the address of the remote device and choosing a port to use for the connection, the app can establish a connection with the remote device.



**/
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text;

namespace Networking{
    class SendReceiveSocketClass{
        public static async Task Main(){
            Console.WriteLine("Use Sockets to send and receive data over TCP");

            var hostName = Dns.GetHostName();
            IPHostEntry localhost = await Dns.GetHostEntryAsync(hostName);
            // This is the IP address of the local machine
            IPAddress localIpAddress = localhost.AddressList[0];
            Console.WriteLine(string.Join(',',localIpAddress.GetAddressBytes()));

            // IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync("host.contoso.com");
            // IPAddress ipAddress = ipHostInfo.AddressList[0];

            IPEndPoint ipEndPoint = new(localIpAddress, 11_000);

            Socket client = new(
                ipEndPoint.AddressFamily, 
                SocketType.Stream, 
                ProtocolType.Tcp);

            await client.ConnectAsync(ipEndPoint);
            while (true)
            {
                // Send message.
                var message = "Hi friends 👋!<|EOM|>";
                var messageBytes = Encoding.UTF8.GetBytes(message);
                _ = await client.SendAsync(messageBytes, SocketFlags.None);
                Console.WriteLine($"Socket client sent message: \"{message}\"");

                // Receive ack.
                var buffer = new byte[1_024];
                var received = await client.ReceiveAsync(buffer, SocketFlags.None);
                var response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response == "<|ACK|>")
                {
                    Console.WriteLine(
                        $"Socket client received acknowledgment: \"{response}\"");
                    break;
                }
                // Sample output:
                //     Socket client sent message: "Hi friends 👋!<|EOM|>"
                //     Socket client received acknowledgment: "<|ACK|>"
            }

            client.Shutdown(SocketShutdown.Both);
        }
    }
}