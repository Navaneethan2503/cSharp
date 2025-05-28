/**
PingReply Class:
----------------
Provides information about the status and data resulting from a Send or SendAsync operation.

public class PingReply

Remarks
The Ping class attempts to send an Internet Control Message Protocol (ICMP) echo request to a remote computer and receive information back from the computer via an ICMP echo reply message. The Ping class uses instances of the PingReply class to return information about the operation, such as its status and the time taken to send the request and receive the reply.

The Send methods return instances of the PingReply class directly. The SendAsync methods return a PingReply in the PingCompletedEventHandler method's PingCompletedEventArgs parameter. The PingReply is accessed through the Reply property.

If the value of Status is not Success, you should not use the values returned by the RoundtripTime, Options or Buffer properties. The RoundtripTime property will return zero, the Buffer property will return an empty array, and the Options property will return null.

Properties:
----------
Address	- Gets the address of the host that sends the Internet Control Message Protocol (ICMP) echo reply.
Buffer	- Gets the buffer of data received in an Internet Control Message Protocol (ICMP) echo reply message.
Options	- Gets the options used to transmit the reply to an Internet Control Message Protocol (ICMP) echo request.
RoundtripTime	- Gets the number of milliseconds taken to send an Internet Control Message Protocol (ICMP) echo request and receive the corresponding ICMP echo reply message.
Status	- Gets the status of an attempt to send an Internet Control Message Protocol (ICMP) echo request and receive the corresponding ICMP echo reply message.

**/