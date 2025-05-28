/**
ProtocolType Enum:
---------------------
Specifies the protocols that the Socket class supports.

    public enum ProtocolType

Fields:
---------
Name	Value	Description
Unknown	-1	Unknown protocol.
IP	0	Internet Protocol.
IPv6HopByHopOptions	0	IPv6 Hop by Hop Options header.
Unspecified	0	Unspecified protocol.
Icmp	1	Internet Control Message Protocol.
Igmp	2	Internet Group Management Protocol.
Ggp	3	Gateway To Gateway Protocol.
IPv4	4	Internet Protocol version 4.
Tcp	6	Transmission Control Protocol.
Pup	12	PARC Universal Packet Protocol.
Udp	17	User Datagram Protocol.
Idp	22	Internet Datagram Protocol.
IPv6	41	Internet Protocol version 6 (IPv6).
IPv6RoutingHeader	43	IPv6 Routing header.
IPv6FragmentHeader	44	IPv6 Fragment header.
IPSecEncapsulatingSecurityPayload	50	IPv6 Encapsulating Security Payload header.
IPSecAuthenticationHeader	51	IPv6 Authentication header. For details, see RFC 2292 section 2.2.1, available at https://www.ietf.org.
IcmpV6	58	Internet Control Message Protocol for IPv6.
IPv6NoNextHeader	59	IPv6 No next header.
IPv6DestinationOptions	60	IPv6 Destination Options header.
ND	77	Net Disk Protocol (unofficial).
Raw	255	Raw IP packet protocol.
Ipx	1000	Internet Packet Exchange Protocol.
Spx	1256	Sequenced Packet Exchange protocol.
SpxII	1257	Sequenced Packet Exchange version 2 protocol.


Remarks:
-------------
The Socket class uses the ProtocolType enumeration to inform the Windows Sockets API of the requested protocol. Low-level driver software for the requested protocol must be present on the computer for the Socket to be created successfully.


**/
