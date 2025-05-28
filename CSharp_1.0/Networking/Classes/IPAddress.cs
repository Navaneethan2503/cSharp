/**
IPAddress Class:
-----------------
Provides an Internet Protocol (IP) address.
    public class IPAddress : IParsable<System.Net.IPAddress>, ISpanFormattable, ISpanParsable<System.Net.IPAddress>, IUtf8SpanFormattable

Remarks
The IPAddress class contains the address of a computer on an IP network.

Constructors:
-------------
IPAddress(Byte[], Int64)	- Initializes a new instance of the IPAddress class with the address specified as a Byte array and the specified scope identifier.
IPAddress(Byte[])	- Initializes a new instance of the IPAddress class with the address specified as a Byte array.
IPAddress(Int64)	- Initializes a new instance of the IPAddress class with the address specified as an Int64.
IPAddress(ReadOnlySpan<Byte>, Int64)	- Initializes a new instance of the IPAddress class with the address specified as a byte span and the specified scope identifier.
IPAddress(ReadOnlySpan<Byte>)	- Initializes a new instance of the IPAddress class with the address specified as a byte span.
    public IPAddress(byte[] address, long scopeid);
    public IPAddress(long newAddress);

Fields:
-------
Any	- Provides an IP address that indicates that the server must listen for client activity on all network interfaces. This field is read-only.
Broadcast	- Provides the IP broadcast address. This field is read-only.
IPv6Any	- The Bind(EndPoint) method uses the IPv6Any field to indicate that a Socket must listen for client activity on all network interfaces.
IPv6Loopback	- Provides the IP loopback address. This property is read-only.
IPv6None	- Provides an IP address that indicates that no network interface should be used. This property is read-only.
Loopback	- Provides the IP loopback address. This field is read-only.
None	- Provides an IP address that indicates that no network interface should be used. This field is read-only.

Properties:
------------
AddressFamily	- Gets the address family of the IP address.
IsIPv4MappedToIPv6	- Gets whether the IP address is an IPv4-mapped IPv6 address.
IsIPv6LinkLocal	- Gets whether the address is an IPv6 link local address.
IsIPv6Multicast	- Gets whether the address is an IPv6 multicast global address.
IsIPv6SiteLocal	- Gets whether the address is an IPv6 site local address.
IsIPv6Teredo	- Gets whether the address is an IPv6 Teredo address.
IsIPv6UniqueLocal	- Gets whether the address is an IPv6 Unique Local address.
ScopeId	- Gets or sets the IPv6 address scope identifier.


Methods:
--------
Equals(Object)	- Compares two IP addresses.
GetAddressBytes()	- Provides a copy of the IPAddress as an array of bytes in network order.
    public byte[] GetAddressBytes();
    
GetHashCode()	- Returns a hash value for an IP address.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
HostToNetworkOrder(Int16)	- Converts a short value from host byte order to network byte order.
HostToNetworkOrder(Int32)	- Converts an integer value from host byte order to network byte order.
HostToNetworkOrder(Int64)	- Converts a long value from host byte order to network byte order.
IsLoopback(IPAddress)	- Indicates whether the specified IP address is the loopback address.
MapToIPv4()	- Maps the IPAddress object to an IPv4 address.
MapToIPv6()	- Maps the IPAddress object to an IPv6 address.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
NetworkToHostOrder(Int16)	- Converts a short value from network byte order to host byte order.
NetworkToHostOrder(Int32)	- Converts an integer value from network byte order to host byte order.
NetworkToHostOrder(Int64)	- Converts a long value from network byte order to host byte order.
Parse(ReadOnlySpan<Char>)	- Converts an IP address represented as a character span to an IPAddress instance.
Parse(String)	- Converts an IP address string to an IPAddress instance.
ToString()	- Converts an Internet address to its standard notation.
TryFormat(Span<Byte>, Int32)	- Tries to format the current IP address into the provided span.
TryFormat(Span<Char>, Int32)	- Tries to format the current IP address into the provided span.
TryParse(ReadOnlySpan<Char>, IPAddress)	- Tries to parse a span of characters into a value.
TryParse(String, IPAddress)	- Determines whether a string is a valid IP address.
TryWriteBytes(Span<Byte>, Int32)	- Tries to write the current IP address into a span of bytes in network order.


**/
using System;

namespace Networking{
    class IPAddressClass{
        public static void Main(){
            Console.WriteLine("IPAddress Class");
        }
    }
}