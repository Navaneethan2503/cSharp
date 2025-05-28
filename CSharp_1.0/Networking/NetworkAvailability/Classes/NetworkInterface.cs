/**
NetworkInterface Class:
---------------------------
Provides configuration and statistical information for a network interface.
    public abstract class NetworkInterface

Remarks:
----------
This class encapsulates data for network interfaces, also known as adapters, on the local computer. You do not create instances of this class; the GetAllNetworkInterfaces method returns an array that contains one instance of this class for each network interface on the local computer.

Constructors:
-------------
NetworkInterface()	- Initializes a new instance of the NetworkInterface class.

Properties:
------------
Description	- Gets the description of the interface.
Id	- Gets the identifier of the network adapter.
IPv6LoopbackInterfaceIndex	- Gets the index of the IPv6 loopback interface.
IsReceiveOnly	- Gets a Boolean value that indicates whether the network interface is set to only receive data packets.
LoopbackInterfaceIndex	- Gets the index of the IPv4 loopback interface.
Name	- Gets the name of the network adapter.
NetworkInterfaceType	- Gets the interface type.
OperationalStatus	- Gets the current operational state of the network connection.
Speed	- Gets the speed of the network interface.
SupportsMulticast	- Gets a Boolean value that indicates whether the network interface is enabled to receive multicast packets.

Methods:
----------
GetAllNetworkInterfaces()	- Returns objects that describe the network interfaces on the local computer.
    [System.Runtime.Versioning.UnsupportedOSPlatform("illumos")]
    [System.Runtime.Versioning.UnsupportedOSPlatform("solaris")]
    public static System.Net.NetworkInformation.NetworkInterface[] GetAllNetworkInterfaces();

GetIPProperties()	- Returns an object that describes the configuration of this network interface.
    public virtual System.Net.NetworkInformation.IPInterfaceProperties GetIPProperties();

GetIPStatistics()	- Gets the IP statistics for this NetworkInterface instance.
    [System.Runtime.Versioning.UnsupportedOSPlatform("android")]
    public virtual System.Net.NetworkInformation.IPInterfaceStatistics GetIPStatistics();

GetIPv4Statistics()	- Gets the IPv4 statistics for this NetworkInterface instance.
    [System.Runtime.Versioning.UnsupportedOSPlatform("android")]
    public virtual System.Net.NetworkInformation.IPv4InterfaceStatistics GetIPv4Statistics();

GetIsNetworkAvailable()	- Indicates whether any network connection is available.
GetPhysicalAddress()	- Returns the Media Access Control (MAC) or physical address for this adapter.
    public virtual System.Net.NetworkInformation.PhysicalAddress GetPhysicalAddress();

Supports(NetworkInterfaceComponent)	- Gets a Boolean value that indicates whether the interface supports the specified protocol.
    public virtual bool Supports(System.Net.NetworkInformation.NetworkInterfaceComponent networkInterfaceComponent);
    

**/
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Networking{
    class NetworkInterfaceClass{
        public static void Main(){
            Console.WriteLine("NetworkInterface Class");

            ShowStatistics(NetworkInterfaceComponent.IPv4);
            ShowStatistics(NetworkInterfaceComponent.IPv6);

            static void ShowStatistics(NetworkInterfaceComponent version)
            {
                var properties = IPGlobalProperties.GetIPGlobalProperties();
                var stats = version switch
                {
                    NetworkInterfaceComponent.IPv4 => properties.GetTcpIPv4Statistics(),
                    _ => properties.GetTcpIPv6Statistics()
                };

                Console.WriteLine($"TCP/{version} Statistics");
                Console.WriteLine($"  Minimum Transmission Timeout : {stats.MinimumTransmissionTimeout:#,#}");
                Console.WriteLine($"  Maximum Transmission Timeout : {stats.MaximumTransmissionTimeout:#,#}");
                Console.WriteLine("  Connection Data");
                Console.WriteLine($"      Current :                  {stats.CurrentConnections:#,#}");
                Console.WriteLine($"      Cumulative :               {stats.CumulativeConnections:#,#}");
                Console.WriteLine($"      Initiated  :               {stats.ConnectionsInitiated:#,#}");
                Console.WriteLine($"      Accepted :                 {stats.ConnectionsAccepted:#,#}");
                Console.WriteLine($"      Failed Attempts :          {stats.FailedConnectionAttempts:#,#}");
                Console.WriteLine($"      Reset :                    {stats.ResetConnections:#,#}");
                Console.WriteLine("  Segment Data");
                Console.WriteLine($"      Received :                 {stats.SegmentsReceived:#,#}");
                Console.WriteLine($"      Sent :                     {stats.SegmentsSent:#,#}");
                Console.WriteLine($"      Retransmitted :            {stats.SegmentsResent:#,#}");
                Console.WriteLine();
            }
        }
    }
}