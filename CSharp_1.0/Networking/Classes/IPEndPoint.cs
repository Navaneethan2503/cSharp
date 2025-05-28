/**
IPEndPoint Class:
-----------------
Represents a network endpoint as an IP address and a port number.
    public class IPEndPoint : System.Net.EndPoint

Constructors:
-------------
IPEndPoint(Int64, Int32)	- Initializes a new instance of the IPEndPoint class with the specified address and port number.
IPEndPoint(IPAddress, Int32)	- Initializes a new instance of the IPEndPoint class with the specified address and port number.

Fields:
-------
MaxPort	- Specifies the maximum value that can be assigned to the Port property. The MaxPort value is set to 0x0000FFFF. This field is read-only.
MinPort	- Specifies the minimum value that can be assigned to the Port property. This field is read-only.

Properties:
-------------
Address	- Gets or sets the IP address of the endpoint.
AddressFamily	- Gets the Internet Protocol (IP) address family.
Port	- Gets or sets the port number of the endpoint.

Methods:
---------
Create(SocketAddress)	- Creates an endpoint from a socket address.
Equals(Object)	- Determines whether the specified Object is equal to the current Object.
GetHashCode()	- Returns a hash value for a IPEndPoint instance.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Parse(ReadOnlySpan<Char>)	- Converts an IP network endpoint (address and port) represented as a read-only span to an IPEndPoint instance.
Parse(String)	- Converts an IP network endpoint (address and port) represented as a string to an IPEndPoint instance.
Serialize()	- Serializes endpoint information into a SocketAddress instance.
ToString()	- Returns the IP address and port number of the specified endpoint.
TryParse(ReadOnlySpan<Char>, IPEndPoint)	- Tries to convert an IP network endpoint (address and port) represented as a read-only span to its IPEndPoint equivalent, and returns a value that indicates whether the conversion succeeded.
TryParse(String, IPEndPoint)	- Tries to convert an IP network endpoint (address and port) represented as a string to its IPEndPoint equivalent, and returns a value that indicates whether the conversion succeeded.


**/