/**

IPGlobalStatistics Class:
-------------------------
Provides Internet Protocol (IP) statistical data.

public abstract class IPGlobalStatistics

Constructors:
-------------
IPGlobalStatistics() - Initializes a new instance of the IPGlobalStatistics class.

Properties:
----------
DefaultTtl	- Gets the default time-to-live (TTL) value for Internet Protocol (IP) packets.
    [System.Runtime.Versioning.UnsupportedOSPlatform("android")]
    public abstract int DefaultTtl { get; }

ForwardingEnabled	- Gets a Boolean value that specifies whether Internet Protocol (IP) packet forwarding is enabled.
NumberOfInterfaces	- Gets the number of network interfaces.
NumberOfIPAddresses	- Gets the number of Internet Protocol (IP) addresses assigned to the local computer.
NumberOfRoutes	- Gets the number of routes in the Internet Protocol (IP) routing table.
OutputPacketRequests	- Gets the number of outbound Internet Protocol (IP) packets.
OutputPacketRoutingDiscards	- Gets the number of routes that have been discarded from the routing table.
OutputPacketsDiscarded	- Gets the number of transmitted Internet Protocol (IP) packets that have been discarded.
OutputPacketsWithNoRoute	- Gets the number of Internet Protocol (IP) packets for which the local computer could not determine a route to the destination address.
PacketFragmentFailures	- Gets the number of Internet Protocol (IP) packets that could not be fragmented.
PacketReassembliesRequired	 - Gets the number of Internet Protocol (IP) packets that required reassembly.
PacketReassemblyFailures	- Gets the number of Internet Protocol (IP) packets that were not successfully reassembled.
PacketReassemblyTimeout	- Gets the maximum amount of time within which all fragments of an Internet Protocol (IP) packet must arrive.
PacketsFragmented	 - Gets the number of Internet Protocol (IP) packets fragmented.
PacketsReassembled	- Gets the number of Internet Protocol (IP) packets reassembled.
ReceivedPackets	- Gets the number of Internet Protocol (IP) packets received.
ReceivedPacketsDelivered	- Gets the number of Internet Protocol (IP) packets delivered.
ReceivedPacketsDiscarded	- Gets the number of Internet Protocol (IP) packets that have been received and discarded.
ReceivedPacketsForwarded	- Gets the number of Internet Protocol (IP) packets forwarded.
ReceivedPacketsWithAddressErrors	- Gets the number of Internet Protocol (IP) packets with address errors that were received.
ReceivedPacketsWithHeadersErrors	- Gets the number of Internet Protocol (IP) packets with header errors that were received.
ReceivedPacketsWithUnknownProtocol	- Gets the number of Internet Protocol (IP) packets received on the local machine with an unknown protocol in the header.

Methods:
---------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Returns a string that represents the current object.(Inherited from Object)


**/
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Networking{
    class IPGlobalStatisticsClass{
        public static void Main(){
            Console.WriteLine("IPGlobalStatistics Class");
            static void ShowIPStatistics(NetworkInterfaceComponent version)
            {
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                IPGlobalStatistics ipstat = null;
                switch (version)
                {
                    case NetworkInterfaceComponent.IPv4:
                        ipstat = properties.GetIPv4GlobalStatistics();
                    Console.WriteLine("{0}IPv4 Statistics ",Environment.NewLine);
                        break;
                    case NetworkInterfaceComponent.IPv6:
                        ipstat = properties.GetIPv6GlobalStatistics();
                        Console.WriteLine("{0}IPv6 Statistics ",Environment.NewLine);
                        break;
                    default:
                        throw new ArgumentException("version");
                    //    break;
                }
                Console.WriteLine("  Forwarding enabled ...................... : {0}",
                    ipstat.ForwardingEnabled);
                Console.WriteLine("  Interfaces .............................. : {0}",
                    ipstat.NumberOfInterfaces);
                Console.WriteLine("  IP addresses ............................ : {0}",
                    ipstat.NumberOfIPAddresses);
                Console.WriteLine("  Routes .................................. : {0}",
                    ipstat.NumberOfRoutes);
                Console.WriteLine("  Default TTL ............................. : {0}",
                    ipstat.DefaultTtl);
                Console.WriteLine("");
                Console.WriteLine("  Inbound Packet Data:");
                Console.WriteLine("      Received ............................ : {0}",
                    ipstat.ReceivedPackets);
                Console.WriteLine("      Forwarded ........................... : {0}",
                    ipstat.ReceivedPacketsForwarded);
                Console.WriteLine("      Delivered ........................... : {0}",
                    ipstat.ReceivedPacketsDelivered);
                Console.WriteLine("      Discarded ........................... : {0}",
                    ipstat.ReceivedPacketsDiscarded);
                Console.WriteLine("      Header Errors ....................... : {0}",
                    ipstat.ReceivedPacketsWithHeadersErrors);
                Console.WriteLine("      Address Errors ...................... : {0}",
                    ipstat.ReceivedPacketsWithAddressErrors);
                Console.WriteLine("      Unknown Protocol Errors ............. : {0}",
                    ipstat.ReceivedPacketsWithUnknownProtocol);
                Console.WriteLine("");
                Console.WriteLine("  Outbound Packet Data:");
                Console.WriteLine("      Requested ........................... : {0}",
                    ipstat.OutputPacketRequests);
                Console.WriteLine("      Discarded ........................... : {0}",
                    ipstat.OutputPacketsDiscarded);
                Console.WriteLine("      No Routing Discards ................. : {0}",
                    ipstat.OutputPacketsWithNoRoute);
                Console.WriteLine("      Routing Entry Discards .............. : {0}",
                    ipstat.OutputPacketRoutingDiscards);
                Console.WriteLine("");
                Console.WriteLine("  Reassembly Data:");
                Console.WriteLine("      Reassembly Timeout .................. : {0}",
                    ipstat.PacketReassemblyTimeout);
                Console.WriteLine("      Reassemblies Required ............... : {0}",
                    ipstat.PacketReassembliesRequired);
                Console.WriteLine("      Packets Reassembled ................. : {0}",
                    ipstat.PacketsReassembled);
                Console.WriteLine("      Packets Fragmented .................. : {0}",
                    ipstat.PacketsFragmented);
                Console.WriteLine("      Fragment Failures ................... : {0}",
                    ipstat.PacketFragmentFailures);
                Console.WriteLine("");
            }

            ShowIPStatistics(NetworkInterfaceComponent.IPv4);

        }
    }
}