/**
Ping Class:
------------
Allows an application to determine whether a remote computer is accessible over the network.
    public class Ping : System.ComponentModel.Component

Remarks
Applications use the Ping class to detect whether a remote computer is reachable.
Network topology can determine whether Ping can successfully contact a remote host. The presence and configuration of proxies, network address translation (NAT) equipment, or firewalls can prevent Ping from succeeding. A successful Ping indicates only that the remote host can be reached on the network; the presence of higher level services (such as a Web server) on the remote host is not guaranteed.
This class provides functionality similar to the Ping.exe command line tool. The Send and SendAsync methods send an Internet Control Message Protocol (ICMP) echo request message to a remote computer and wait for an ICMP echo reply message from that computer. For a detailed description of ICMP messages, see RFC 792, available at https://www.ietf.org.

The following types are used with the Ping class and are described in detail below.

    Type name	Description
    IPStatus	Defines status codes that describe the outcome of an ICMP echo request message.
    PingOptions	Allows you to configure or retrieve the settings that control how many times the request packet can be forwarded (Ttl), and whether it can be fragmented (DontFragment ).
    PingReply	Contains the results of an ICMP echo request.
    PingException	Thrown if an unrecoverable error occurs.
    PingCompletedEventArgs	Contains the data associated with PingCompleted events, which are raised when a SendAsync call completes or is canceled.
    PingCompletedEventHandler	The delegate that provides the callback method invoked when a SendAsync call completes or is canceled.
    The Send and SendAsync methods return the reply in a PingReply object. The PingReply.Status property returns an IPStatus value to indicate the outcome of the request.

When sending the request, you must specify the remote computer. You can do this by providing a host name string, an IP address in string format, or an IPAddress object.
You can also specify any of the following types of information:
    Data to accompany the request. Specifying buffer allows you to learn the amount of time required for a packet of a particular size to travel to and from the remote host and the maximum transmission unit of the network path. (See the Send or SendAsync overloads that take a buffer parameter.)
    Whether the ICMP Echo packet can be fragmented in transit. (See the DontFragment property and the Send or SendAsync overloads that take an options parameter.)
    How many times routing nodes, such as routers or gateways, can forward the packet before it either reaches the destination computer or is discarded. (See Ttl and the Send or SendAsync overloads that take an options parameter.)
    The time limit within which the reply must be received. (See the Send or SendAsync overloads that take a timeout parameter.
    The Ping class offers both synchronous and asynchronous methods for sending the request. If your application should block while waiting for a reply, use the Send methods; these methods are synchronous. If your application should not block, use the asynchronous SendAsync methods. A call to SendAsync executes in its own thread that is automatically allocated from the thread pool. When the asynchronous operation completes, it raises the PingCompleted event. Applications use a PingCompletedEventHandler delegate to specify the method that is called for PingCompleted events. You must add a PingCompletedEventHandler delegate to the event before calling SendAsync. The delegate's method receives a PingCompletedEventArgs object that contains a PingReply object that describes the result of the SendAsync call.
    You cannot use the same instance of the Ping class to generate multiple simultaneous ICMP Echo requests. Calling Send while a SendAsync call is in progress or calling SendAsync multiple times before all previous calls have completed causes an InvalidOperationException.

Constructors:
------------------
Ping()	- Initializes a new instance of the Ping class.

Properties:
-----------
CanRaiseEvents	- Gets a value indicating whether the component can raise an event.(Inherited from Component)
Container	- Gets the IContainer that contains the Component.(Inherited from Component)
DesignMode	- Gets a value that indicates whether the Component is currently in design mode.(Inherited from Component)
Events	- Gets the list of event handlers that are attached to this Component.(Inherited from Component)
Site	- Gets or sets the ISite of the Component.(Inherited from Component)

Methods:
--------
Dispose()	- Releases all resources used by the Component.(Inherited from Component)
Dispose(Boolean)	- Releases the unmanaged resources used by the Ping object, and optionally disposes of the managed resources.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetService(Type)	- Returns an object that represents a service provided by the Component or by its Container.(Inherited from Component)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
MemberwiseClone(Boolean)	- Creates a shallow copy of the current MarshalByRefObject object.(Inherited from MarshalByRefObject)
OnPingCompleted(PingCompletedEventArgs)	- Raises the PingCompleted event.

Send(IPAddress, Int32, Byte[], PingOptions)	- Attempts to send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the computer that has the specified IPAddress and receive a corresponding ICMP echo reply message from that computer. This overload allows you to specify a time-out value for the operation and control fragmentation and Time-to-Live values for the ICMP echo message packet.
Send(IPAddress, Int32, Byte[])	- Attempts to send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the computer that has the specified IPAddress, and receive a corresponding ICMP echo reply message from that computer. This overload allows you to specify a time-out value for the operation.
Send(IPAddress, Int32)	- Attempts to send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the computer that has the specified IPAddress, and receive a corresponding ICMP echo reply message from that computer. This method allows you to specify a time-out value for the operation.
Send(IPAddress, TimeSpan, Byte[], PingOptions)	 - Attempts to send an Internet Control Message Protocol (ICMP) echo message to the computer that has the specified IPAddress, and to receive a corresponding ICMP echo reply message from that computer.
Send(IPAddress)	- Attempts to send an Internet Control Message Protocol (ICMP) echo message to the computer that has the specified IPAddress, and receive a corresponding ICMP echo reply message from that computer.
Send(String, Int32, Byte[], PingOptions)	- Attempts to send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the specified computer, and receive a corresponding ICMP echo reply message from that computer. This overload allows you to specify a time-out value for the operation and control fragmentation and Time-to-Live values for the ICMP packet.
Send(String, Int32, Byte[])	- Attempts to send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the specified computer, and receive a corresponding ICMP echo reply message from that computer. This overload allows you to specify a time-out value for the operation.
Send(String, Int32)	- Attempts to send an Internet Control Message Protocol (ICMP) echo message to the specified computer, and receive a corresponding ICMP echo reply message from that computer. This method allows you to specify a time-out value for the operation.
Send(String, TimeSpan, Byte[], PingOptions)	- Attempts to send an Internet Control Message Protocol (ICMP) echo message to the specified computer, and to receive a corresponding ICMP echo reply message from that computer.
Send(String)	- Attempts to send an Internet Control Message Protocol (ICMP) echo message to the specified computer, and receive a corresponding ICMP echo reply message from that computer.
    public System.Net.NetworkInformation.PingReply Send(System.Net.IPAddress address);
    public System.Net.NetworkInformation.PingReply Send(string hostNameOrAddress, int timeout, byte[] buffer, System.Net.NetworkInformation.PingOptions? options);
    public System.Net.NetworkInformation.PingReply Send(System.Net.IPAddress address, int timeout);

SendAsync(IPAddress, Int32, Byte[], Object)	- Asynchronously attempts to send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the computer that has the specified IPAddress, and receive a corresponding ICMP echo reply message from that computer. This overload allows you to specify a time-out value for the operation.
SendAsync(IPAddress, Int32, Byte[], PingOptions, Object)	- Asynchronously attempts to send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the computer that has the specified IPAddress, and receive a corresponding ICMP echo reply message from that computer. This overload allows you to specify a time-out value for the operation and control fragmentation and Time-to-Live values for the ICMP echo message packet.
SendAsync(IPAddress, Int32, Object)	- Asynchronously attempts to send an Internet Control Message Protocol (ICMP) echo message to the computer that has the specified IPAddress, and receive a corresponding ICMP echo reply message from that computer. This overload allows you to specify a time-out value for the operation.
SendAsync(IPAddress, Object)	- Asynchronously attempts to send an Internet Control Message Protocol (ICMP) echo message to the computer that has the specified IPAddress, and receive a corresponding ICMP echo reply message from that computer.
SendAsync(String, Int32, Byte[], Object)	 - Asynchronously attempts to send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the specified computer, and receive a corresponding ICMP echo reply message from that computer. This overload allows you to specify a time-out value for the operation.
SendAsync(String, Int32, Byte[], PingOptions, Object)	- Asynchronously attempts to send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the specified computer, and receive a corresponding ICMP echo reply message from that computer. This overload allows you to specify a time-out value for the operation and control fragmentation and Time-to-Live values for the ICMP packet.
SendAsync(String, Int32, Object)	- Asynchronously attempts to send an Internet Control Message Protocol (ICMP) echo message to the specified computer, and receive a corresponding ICMP echo reply message from that computer. This overload allows you to specify a time-out value for the operation.
SendAsync(String, Object)	- Asynchronously attempts to send an Internet Control Message Protocol (ICMP) echo message to the specified computer, and receive a corresponding ICMP echo reply message from that computer.
    public void SendAsync(string hostNameOrAddress, int timeout, object? userToken);
    public void SendAsync(string hostNameOrAddress, int timeout, byte[] buffer, System.Net.NetworkInformation.PingOptions? options, object? userToken);

SendAsyncCancel()	- Cancels all pending asynchronous requests to send an Internet Control Message Protocol (ICMP) echo message and receives a corresponding ICMP echo reply message.
    public void SendAsyncCancel();

SendPingAsync(IPAddress, Int32, Byte[], PingOptions)	- Sends an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the computer that has the specified IPAddress, and receives a corresponding ICMP echo reply message from that computer as an asynchronous operation. This overload allows you to specify a time-out value for the operation, a buffer to use for send and receive, and control fragmentation and Time-to-Live values for the ICMP echo message packet.
SendPingAsync(IPAddress, Int32, Byte[])	- Send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the computer that has the specified IPAddress, and receives a corresponding ICMP echo reply message from that computer as an asynchronous operation. This overload allows you to specify a time-out value for the operation and a buffer to use for send and receive.
SendPingAsync(IPAddress, Int32)	- Send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the computer that has the specified IPAddress, and receives a corresponding ICMP echo reply message from that computer as an asynchronous operation. This overload allows you to specify a time-out value for the operation.
SendPingAsync(IPAddress, TimeSpan, Byte[], PingOptions, CancellationToken)	- Sends an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the computer that has the specified IPAddress, and receives a corresponding ICMP echo reply message from that computer as an asynchronous operation. This overload allows you to specify a time-out value for the operation, a buffer to use for send and receive, control fragmentation and Time-to-Live values, and a CancellationToken for the ICMP echo message packet.
SendPingAsync(IPAddress)	- Send an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the computer that has the specified IPAddress, and receives a corresponding ICMP echo reply message from that computer as an asynchronous operation.
SendPingAsync(String, Int32, Byte[], PingOptions)	- Sends an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the specified computer, and receive a corresponding ICMP echo reply message from that computer as an asynchronous operation. This overload allows you to specify a time-out value for the operation, a buffer to use for send and receive, and control fragmentation and Time-to-Live values for the ICMP echo message packet.
SendPingAsync(String, Int32, Byte[])	- Sends an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the specified computer, and receive a corresponding ICMP echo reply message from that computer as an asynchronous operation. This overload allows you to specify a time-out value for the operation and a buffer to use for send and receive.
SendPingAsync(String, Int32)	- Sends an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the specified computer, and receive a corresponding ICMP echo reply message from that computer as an asynchronous operation. This overload allows you to specify a time-out value for the operation.
SendPingAsync(String, TimeSpan, Byte[], PingOptions, CancellationToken)	- Sends an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the specified computer, and receives a corresponding ICMP echo reply message from that computer as an asynchronous operation. This overload allows you to specify a time-out value for the operation, a buffer to use for send and receive, control fragmentation and Time-to-Live values, and a CancellationToken for the ICMP echo message packet.
SendPingAsync(String)	- Sends an Internet Control Message Protocol (ICMP) echo message with the specified data buffer to the specified computer, and receive a corresponding ICMP echo reply message from that computer as an asynchronous operation.
    public System.Threading.Tasks.Task<System.Net.NetworkInformation.PingReply> SendPingAsync(System.Net.IPAddress address);
    public System.Threading.Tasks.Task<System.Net.NetworkInformation.PingReply> SendPingAsync(System.Net.IPAddress address, TimeSpan timeout, byte[]? buffer = default, System.Net.NetworkInformation.PingOptions? options = default, System.Threading.CancellationToken cancellationToken = default);
    
ToString()	- Returns a String containing the name of the Component, if any. This method should not be overridden.(Inherited from Component)

Events:
---------
Disposed	- Occurs when the component is disposed by a call to the Dispose() method.(Inherited from Component)
PingCompleted	- Occurs when an asynchronous operation to send an Internet Control Message Protocol (ICMP) echo message and receive the corresponding ICMP echo reply message completes or is canceled.


**/