/**
IPInterfaceProperties Class:
---------------------------
Provides information about network interfaces that support Internet Protocol version 4 (IPv4) or Internet Protocol version 6 (IPv6).
    public abstract class IPInterfaceProperties


Remarks:
---------
This class provides access to configuration and address information for network interfaces that support IPv4 or IPv6. You do not create instances of this class; they are returned by the GetIPProperties method.

To access IPv4-specific properties, use the object returned by the GetIPv4Properties method. To access IPv6-specific properties, use the object returned by the GetIPv6Properties method.

Constructors:
--------------
IPInterfaceProperties()	- Initializes a new instance of the IPInterfaceProperties class.

Properties:
-------------
AnycastAddresses	- Gets the anycast IP addresses assigned to this interface.
DhcpServerAddresses	- Gets the addresses of Dynamic Host Configuration Protocol (DHCP) servers for this interface.
DnsAddresses	- Gets the addresses of Domain Name System (DNS) servers for this interface.
DnsSuffix	- Gets the Domain Name System (DNS) suffix associated with this interface.
GatewayAddresses	- Gets the IPv4 network gateway addresses for this interface.
IsDnsEnabled	- Gets a Boolean value that indicates whether NetBt is configured to use DNS name resolution on this interface.
IsDynamicDnsEnabled	- Gets a Boolean value that indicates whether this interface is configured to automatically register its IP address information with the Domain Name System (DNS).
MulticastAddresses	- Gets the multicast addresses assigned to this interface.
UnicastAddresses	- Gets the unicast addresses assigned to this interface.
WinsServersAddresses	- Gets the addresses of Windows Internet Name Service (WINS) servers.

Methods:
---------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetIPv4Properties()	- Provides Internet Protocol version 4 (IPv4) configuration data for this network interface.
    public abstract System.Net.NetworkInformation.IPv4InterfaceProperties GetIPv4Properties();

GetIPv6Properties()	- Provides Internet Protocol version 6 (IPv6) configuration data for this network interface.
    public abstract System.Net.NetworkInformation.IPv6InterfaceProperties GetIPv6Properties();
    
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Returns a string that represents the current object.(Inherited from Object)

**/
using System;

namespace Networking{
    class IPInterfacePropertiesClass{
        public static void Main(){
            Console.WriteLine("IPInterfaceProperties Class");
        }
    }
}