/**
🌐 What is a WebSocket?
WebSocket is a protocol that provides:

Full-duplex communication (both client and server can send messages independently)
Persistent connection (unlike HTTP, which is request-response based)
Low latency (ideal for real-time apps like chat, games, live dashboards)
It starts as an HTTP request and then upgrades to a WebSocket connection.

🧰 WebSocket Support in C#
C# supports WebSockets through:

ASP.NET Core (for server-side)
System.Net.WebSockets (for both client and server)

🧠 Use Cases for WebSockets
Chat applications
Live sports scores
Multiplayer games
Stock tickers
Collaborative tools (e.g., Google Docs-style editing)

🔌 Socket (TCP/UDP)
✅ What it is:
A low-level API for network communication.
Works with TCP (connection-oriented) or UDP (connectionless).
Sends and receives raw bytes.
Requires you to handle protocols, message framing, and connection management manually.
🧠 Use Cases:
Custom protocols (e.g., game servers, IoT devices).
High-performance networking where you control every detail.
Systems where HTTP/WebSocket overhead is unnecessary.

🌐 WebSocket
✅ What it is:
A high-level protocol built on top of TCP.
Starts as an HTTP request, then upgrades to a persistent, full-duplex connection.
Sends and receives text or binary messages.
Handles framing, ping/pong, reconnection, and message boundaries for you.
🧠 Use Cases:
Real-time web apps (chat, live notifications).
Multiplayer games in browsers.
Collaborative tools (e.g., Google Docs-style editing).

🔍 Key Differences
Feature	Socket (TCP/UDP)	WebSocket
Level	Low-level	High-level
Protocol	TCP or UDP	Built on TCP
Connection	Manual setup	Starts with HTTP, then upgrades
Message Framing	Manual	Automatic
Full-Duplex	Yes	Yes
Browser Support	No	Yes
Ease of Use	Complex	Easier for real-time apps

Set up HTTP version and policy:
-------------------------------
By default, ClientWebSocket uses HTTP/1.1 to send an opening handshake and allows downgrade. In .NET 7 web sockets over HTTP/2 are available. It can be changed before calling ConnectAsync:
using SocketsHttpHandler handler = new();
using ClientWebSocket ws = new();

ws.Options.HttpVersion = HttpVersion.Version20;
ws.Options.HttpVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;

await ws.ConnectAsync(uri, new HttpMessageInvoker(handler), cancellationToken);

Incompatible options:
------------------------
ClientWebSocket has properties System.Net.WebSockets.ClientWebSocketOptions that the user can set up before the connection is established. However, when HttpMessageInvoker is provided, it also has these properties. To avoid ambiguity, in that case, properties should be set on HttpMessageInvoker, and ClientWebSocketOptions should have default values. Otherwise, if ClientWebSocketOptions are changed, overload of ConnectAsync will throw an ArgumentException.

Keep-Alive strategies
On .NET 8 and earlier, the only available Keep-Alive strategy is Unsolicited PONG. This strategy is enough to keep the underlying TCP connection from idling out. However, in a case when a remote host becomes unresponsive (for example, a remote server crashes), the only way to detect such situations with Unsolicited PONG is to depend on the TCP timeout.

.NET 9 introduced the long-desired PING/PONG Keep-Alive strategy, complementing the existing KeepAliveInterval setting with the new KeepAliveTimeout setting. Starting with .NET 9, the Keep-Alive strategy is selected as follows:

Keep-Alive is OFF, if
KeepAliveInterval is TimeSpan.Zero or Timeout.InfiniteTimeSpan
Unsolicited PONG, if
KeepAliveInterval is a positive finite TimeSpan, -AND-
KeepAliveTimeout is TimeSpan.Zero or Timeout.InfiniteTimeSpan
PING/PONG, if
KeepAliveInterval is a positive finite TimeSpan, -AND-
KeepAliveTimeout is a positive finite TimeSpan
The default KeepAliveTimeout value is Timeout.InfiniteTimeSpan, so the default Keep-Alive behavior remains consistent between .NET versions.

If you use ClientWebSocket, the default ClientWebSocketOptions.KeepAliveInterval value is WebSocket.DefaultKeepAliveInterval (typically 30 seconds). That means, ClientWebSocket has the Keep-Alive ON by default, with Unsolicited PONG as the default strategy.

If you want to switch to the PING/PONG strategy, overriding ClientWebSocketOptions.KeepAliveTimeout is enough:

C#

Copy
var ws = new ClientWebSocket();
ws.Options.KeepAliveTimeout = TimeSpan.FromSeconds(20);
await ws.ConnectAsync(uri, cts.Token);
For a basic WebSocket, the Keep-Alive is OFF by default. If you want to use the PING/PONG strategy, both WebSocketCreationOptions.KeepAliveInterval and WebSocketCreationOptions.KeepAliveTimeout need to be set:

C#

Copy
var options = new WebSocketCreationOptions()
{
    KeepAliveInterval = WebSocket.DefaultKeepAliveInterval,
    KeepAliveTimeout = TimeSpan.FromSeconds(20)
};
var ws = WebSocket.CreateFromStream(stream, options);
If the Unsolicited PONG strategy is used, PONG frames are used as a unidirectional heartbeat. They sent regularly with KeepAliveInterval intervals, regardless whether the remote endpoint is communicating or not.

In case the PING/PONG strategy is active, a PING frame is sent after KeepAliveInterval time passed since the last communication from the remote endpoint. Each PING frame contains an integer token to pair with the expected PONG response. If no PONG response arrived after KeepAliveTimeout elapsed, the remote endpoint is deemed unresponsive, and the WebSocket connection is automatically aborted.

✅ Can You Create a Server Using WebSockets?:
----------------------------------------------
Yes, you can absolutely create a server using WebSockets in C#. In fact, WebSockets are designed for server-client communication where the server maintains a persistent, bidirectional connection with clients.

🔹 Example Use Case:
A chat server that pushes messages to all connected clients.
A real-time dashboard that streams updates from the server.

**/
using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace Networking{
    class WebSocketClass{
        public static async Task Main(){
            Console.WriteLine("WebSockets Class.");
            ClientWebSocket ws = new ClientWebSocket();
            ws.Options.KeepAliveInterval = TimeSpan.FromSeconds(10);
            ws.Options.KeepAliveTimeout = TimeSpan.FromSeconds(10);
            await ws.ConnectAsync(new Uri("ws://localhost:100"), CancellationToken.None);
            Console.WriteLine("WebSocket Client Connected .");
            var bytes = new byte[1024];
            var result = await ws.ReceiveAsync(bytes, default);
            string res = Encoding.UTF8.GetString(bytes, 0, result.Count);

            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closed", default);
            Console.WriteLine(res);

        }
    }
}