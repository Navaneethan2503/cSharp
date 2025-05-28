/**
IPGlobalProperties Class:
--------------------------
Provides information about the network connectivity of the local computer.:

    public abstract class IPGlobalProperties

Remarks:
----------
This class provides configuration and statistical information about the local computer's network interfaces and network connections.

The information provided by this class is similar to that provided by the Internet Protocol Helper API functions. For information about the Internet Protocol Helper, see IP Helper.

Constructors:
--------------
IPGlobalProperties()	- Initializes a new instance of the IPGlobalProperties class.

Properties:
-----------
DhcpScopeName - Gets the Dynamic Host Configuration Protocol (DHCP) scope name.
DomainName	- Gets the domain in which the local computer is registered.
HostName	- Gets the host name for the local computer.
    public abstract string HostName { get; }

IsWinsProxy	- Gets a Boolean value that specifies whether the local computer is acting as a Windows Internet Name Service (WINS) proxy.
NodeType	- Gets the Network Basic Input/Output System (NetBIOS) node type of the local computer.

Methods:
---------
BeginGetUnicastAddresses(AsyncCallback, Object)	- Begins an asynchronous request to retrieve the stable unicast IP address table on the local computer.
EndGetUnicastAddresses(IAsyncResult)	- Ends a pending asynchronous request to retrieve the stable unicast IP address table on the local computer.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetActiveTcpConnections()	- Returns information about the Internet Protocol version 4 (IPv4) and IPv6 Transmission Control Protocol (TCP) connections on the local computer.
GetActiveTcpListeners()	- Returns endpoint information about the Internet Protocol version 4 (IPv4) and IPv6 Transmission Control Protocol (TCP) listeners on the local computer.
GetActiveUdpListeners()	- Returns information about the Internet Protocol version 4 (IPv4) and IPv6 User Datagram Protocol (UDP) listeners on the local computer.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetIcmpV4Statistics()	- Provides Internet Control Message Protocol (ICMP) version 4 statistical data for the local computer.
GetIcmpV6Statistics()	- Provides Internet Control Message Protocol (ICMP) version 6 statistical data for the local computer.
GetIPGlobalProperties()	- Gets an object that provides information about the local computer's network connectivity and traffic statistics.
    [System.Runtime.Versioning.UnsupportedOSPlatform("illumos")]
    [System.Runtime.Versioning.UnsupportedOSPlatform("solaris")]
    public static System.Net.NetworkInformation.IPGlobalProperties GetIPGlobalProperties();

GetIPv4GlobalStatistics()	- Provides Internet Protocol version 4 (IPv4) statistical data for the local computer.
GetIPv6GlobalStatistics()	- Provides Internet Protocol version 6 (IPv6) statistical data for the local computer.
    [System.Runtime.Versioning.UnsupportedOSPlatform("freebsd")]
    [System.Runtime.Versioning.UnsupportedOSPlatform("ios")]
    [System.Runtime.Versioning.UnsupportedOSPlatform("osx")]
    [System.Runtime.Versioning.UnsupportedOSPlatform("tvos")]
    public abstract System.Net.NetworkInformation.IPGlobalStatistics GetIPv6GlobalStatistics();

GetTcpIPv4Statistics()	- Provides Transmission Control Protocol/Internet Protocol version 4 (TCP/IPv4) statistical data for the local computer.
GetTcpIPv6Statistics()	- Provides Transmission Control Protocol/Internet Protocol version 6 (TCP/IPv6) statistical data for the local computer.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
GetUdpIPv4Statistics()	- Provides User Datagram Protocol/Internet Protocol version 4 (UDP/IPv4) statistical data for the local computer.
GetUdpIPv6Statistics()	- Provides User Datagram Protocol/Internet Protocol version 6 (UDP/IPv6) statistical data for the local computer.
GetUnicastAddresses()	- Retrieves the stable unicast IP address table on the local computer.
    public virtual System.Net.NetworkInformation.UnicastIPAddressInformationCollection GetUnicastAddresses();

GetUnicastAddressesAsync()	- Retrieves the stable unicast IP address table on the local computer as an asynchronous operation.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Returns a string that represents the current object.(Inherited from Object)

**/
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Networking{
    class IPGlobalPropertiesClass{
        public static void Main(){
            Console.WriteLine("IPGlobalProperties Class");
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            Console.WriteLine("Computer name: {0}", properties.HostName);
            Console.WriteLine("Domain name:   {0}", properties.DomainName);
            Console.WriteLine("Node type:     {0:f}", properties.NodeType);
            Console.WriteLine("DHCP scope:    {0}", properties.DhcpScopeName);
            Console.WriteLine("WINS proxy?    {0}", properties.IsWinsProxy);
        }
    }
}
