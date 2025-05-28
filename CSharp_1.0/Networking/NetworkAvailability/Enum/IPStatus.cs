/**
IPStatus Class:
---------------
Reports the status of sending an Internet Control Message Protocol (ICMP) echo message to a computer.
    public enum IPStatus

Fields:
---------
Name	Value	Description
Unknown	-1	
The ICMP echo request failed for an unknown reason.

Success	0	
The ICMP echo request succeeded; an ICMP echo reply was received. When you get this status code, the other PingReply properties contain valid data.

DestinationNetworkUnreachable	11002	
The ICMP echo request failed because the network that contains the destination computer is not reachable.

DestinationHostUnreachable	11003	
The ICMP echo request failed because the destination computer is not reachable.

DestinationProhibited	11004	
The ICMPv6 echo request failed because contact with the destination computer is administratively prohibited. This value applies only to IPv6.

DestinationProtocolUnreachable	11004	
The ICMP echo request failed because the destination computer that is specified in an ICMP echo message is not reachable, because it does not support the packet's protocol. This value applies only to IPv4. This value is described in IETF RFC 1812 as Communication Administratively Prohibited.

DestinationPortUnreachable	11005	
The ICMP echo request failed because the port on the destination computer is not available.

NoResources	11006	
The ICMP echo request failed because of insufficient network resources.

BadOption	11007	
The ICMP echo request failed because it contains an invalid option.

HardwareError	11008	
The ICMP echo request failed because of a hardware error.

PacketTooBig	11009	
The ICMP echo request failed because the packet containing the request is larger than the maximum transmission unit (MTU) of a node (router or gateway) located between the source and destination. The MTU defines the maximum size of a transmittable packet.

TimedOut	11010	
The ICMP echo Reply was not received within the allotted time. The default time allowed for replies is 5 seconds. You can change this value using the Send or SendAsync methods that take a timeout parameter.

BadRoute	11012	
The ICMP echo request failed because there is no valid route between the source and destination computers.

TtlExpired	11013	
The ICMP echo request failed because its Time to Live (TTL) value reached zero, causing the forwarding node (router or gateway) to discard the packet.

TtlReassemblyTimeExceeded	11014	
The ICMP echo request failed because the packet was divided into fragments for transmission and all of the fragments were not received within the time allotted for reassembly. RFC 2460 specifies 60 seconds as the time limit within which all packet fragments must be received.

ParameterProblem	11015	
The ICMP echo request failed because a node (router or gateway) encountered problems while processing the packet header. This is the status if, for example, the header contains invalid field data or an unrecognized option.

SourceQuench	11016	
The ICMP echo request failed because the packet was discarded. This occurs when the source computer's output queue has insufficient storage space, or when packets arrive at the destination too quickly to be processed.

BadDestination	11018	
The ICMP echo request failed because the destination IP address cannot receive ICMP echo requests or should never appear in the destination address field of any IP datagram. For example, calling Send and specifying IP address "000.0.0.0" returns this status.

DestinationUnreachable	11040	
The ICMP echo request failed because the destination computer that is specified in an ICMP echo message is not reachable; the exact cause of problem is unknown.

TimeExceeded	11041	
The ICMP echo request failed because its Time to Live (TTL) value reached zero, causing the forwarding node (router or gateway) to discard the packet.

BadHeader	11042	
The ICMP echo request failed because the header is invalid.

UnrecognizedNextHeader	11043	
The ICMP echo request failed because the Next Header field does not contain a recognized value. The Next Header field indicates the extension header type (if present) or the protocol above the IP layer, for example, TCP or UDP.

IcmpError	11044	
The ICMP echo request failed because of an ICMP protocol error.

DestinationScopeMismatch	11045	
The ICMP echo request failed because the source address and destination address that are specified in an ICMP echo message are not in the same scope. This is typically caused by a router forwarding a packet using an interface that is outside the scope of the source address. Address scopes (link-local, site-local, and global scope) determine where on the network an address is valid.

**/