/**
SocketType Enum:
----------------
Specifies the type of socket that an instance of the Socket class represents.

    public enum SocketType

Fields:
-------
Name	Value	Description
Unknown	-1	Specifies an unknown Socket type.
Stream	1	Supports reliable, two-way, connection-based byte streams without the duplication of data and without preservation of boundaries. A Socket of this type communicates with a single peer and requires a remote host connection before communication can begin. Stream uses the Transmission Control Protocol (ProtocolType.Tcp) and the AddressFamily.InterNetwork address family.
Dgram	2	Supports datagrams, which are connectionless, unreliable messages of a fixed (typically small) maximum length. Messages might be lost or duplicated and might arrive out of order. A Socket of type Dgram requires no connection prior to sending and receiving data, and can communicate with multiple peers. Dgram uses the Datagram Protocol (ProtocolType.Udp) and the AddressFamily.InterNetwork address family.
Raw	3	Supports access to the underlying transport protocol. Using Raw, you can communicate using protocols like Internet Control Message Protocol (ProtocolType.Icmp) and Internet Group Management Protocol (ProtocolType.Igmp). Your application must provide a complete IP header when sending. Received datagrams return with the IP header and options intact.
Rdm	4	Supports connectionless, message-oriented, reliably delivered messages, and preserves message boundaries in data. Rdm (Reliably Delivered Messages) messages arrive unduplicated and in order. Furthermore, the sender is notified if messages are lost. If you initialize a Socket using Rdm, you do not require a remote host connection before sending and receiving data. With Rdm, you can communicate with multiple peers.
Seqpacket	5	Provides connection-oriented and reliable two-way transfer of ordered byte streams across a network. Seqpacket does not duplicate data, and it preserves boundaries within the data stream. A Socket of type Seqpacket communicates with a single peer and requires a remote host connection before communication can begin.

**/