/**
🌐 What is HttpClient?
HttpClient is a class in the System.Net.Http namespace used to:

Send HTTP requests (GET, POST, PUT, DELETE, etc.)
Receive HTTP responses from a resource identified by a URI
It supports both synchronous and asynchronous operations, with a strong emphasis on async/await for non-blocking I/O.

🧠 Key Features
Feature	Description
Async Support	Fully supports async/await for non-blocking calls
Headers	Easily set custom headers like Authorization, User-Agent, etc.
Timeouts	Configurable via client.Timeout
BaseAddress	Set a base URI to simplify relative requests
DefaultRequestHeaders	Set headers that apply to all requests

⚠️ Best Practices
Reuse HttpClient: Don’t create a new instance per request. Use a singleton or IHttpClientFactory in ASP.NET Core.
Dispose Properly: If not reusing, wrap in using or dispose manually.
Handle Exceptions: Catch HttpRequestException, TaskCanceledException, etc.
Use HttpClientFactory: In ASP.NET Core, prefer IHttpClientFactory for better performance and resilience.

🧪 Advanced Features
SendAsync: For full control over the request.
CancellationToken: Cancel long-running requests.
HttpMessageHandler: Customize request pipeline (e.g., logging, retry policies).
Polly Integration: Add retry, circuit breaker, and timeout policies.

Feature / Aspect	Socket (System.Net.Sockets)	WebSocket (System.Net.WebSockets)	HttpClient (System.Net.Http)
Level	Low-level	Mid-level	High-level
Protocol	TCP / UDP	TCP (via HTTP upgrade)	HTTP / HTTPS
Communication Type	Full-duplex	Full-duplex	Request-response
Connection	Manual setup	Starts with HTTP, then upgrades	Stateless (new connection per request unless reused)
Message Framing	Manual	Automatic	Automatic
Use Case	Custom protocols, games, IoT	Real-time apps (chat, live updates)	REST APIs, web services
Browser Support	No	Yes	Yes (indirectly via HTTP)
Ease of Use	Complex	Moderate	Easy
Persistent Connection	Yes (TCP)	Yes	No (unless using HttpClient reuse)
Built-in in .NET	Yes	Yes	Yes

HTTP request methods:
------------------------
1.idempotent
2.cacheable
3.safe method


Use HTTP/3 with HttpClient:
--------------------------
HTTP/3 is the third and recently standardized major version of HTTP. HTTP/3 uses the same semantics as HTTP/1.1 and HTTP/2: the same request methods, status codes, and message fields apply to all versions. The differences are in the underlying transport. Both HTTP/1.1 and HTTP/2 use TCP as their transport. HTTP/3 uses a transport technology developed alongside HTTP/3 called QUIC.

HTTP/3 and QUIC both have several benefits compared to HTTP/1.1 and HTTP/2:

Faster response time for the first request. QUIC and HTTP/3 negotiate the connection in fewer round trips between the client and the server. The first request reaches the server faster.
Improved experience when there's connection packet loss. HTTP/2 multiplexes multiple requests via one TCP connection. Packet loss on the connection affects all requests. This problem is called "head-of-line blocking". Because QUIC provides native multiplexing, lost packets only affect the requests where data has been lost.
Supports transitioning between networks. This feature is useful for mobile devices where it's common to switch between WIFI and cellular networks as a mobile device changes location. Currently, HTTP/1.1 and HTTP/2 connections fail with an error when switching networks. An app or web browser must retry any failed HTTP requests. HTTP/3 allows the app or web browser to seamlessly continue when a network changes. HttpClient and Kestrel don't support network transitions in .NET 7. It may be available in a future release.

HttpClient settings:
-------------------------
The HTTP version can be configured by setting HttpRequestMessage.Version to 3.0. However, because not all routers, firewalls, and proxies properly support HTTP/3, it's recommend configuring HTTP/3 together with HTTP/1.1 and HTTP/2. In HttpClient, this can be done by specifying:

HttpRequestMessage.Version to 1.1.
HttpRequestMessage.VersionPolicy to HttpVersionPolicy.RequestVersionOrHigher.

using var client = new HttpClient
{
    DefaultRequestVersion =  HttpVersion.Version30,
    DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
};
<ItemGroup>
    <RuntimeHostConfigurationOption Value="true"
        Include="System.Net.SocketsHttpHandler.Http3Support" />
</ItemGroup>



What is rate limiting?:
---------------------------
Rate limiting is the concept of limiting how much a resource can be accessed. For example, you may know that a database your app accesses can safely handle 1,000 requests per minute, but it may not handle much more than that. You can put a rate limiter in your app that only allows 1,000 requests every minute and rejects any more requests before they can access the database. Thus, rate limiting your database and allowing your app to handle a safe number of requests. This is a common pattern in distributed systems, where you may have multiple instances of an app running, and you want to ensure that they don't all try to access the database at the same time. There are multiple different rate-limiting algorithms to control the flow of requests.


**/
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Networking{
    class HTTPClientClass{
        static readonly HttpClient client = new HttpClient();
        public static async Task Main()
        {
            
            HttpResponseMessage response = await client.GetAsync("https://api.restful-api.dev/objects");
             response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);

            Console.WriteLine(responseBody);
        }

    }
}