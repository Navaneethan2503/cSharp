/**
PingOptions  Class:
--------------------
Used to control how Ping data packets are transmitted.

public class PingOptions

Constructors:
-------------
PingOptions()	- Initializes a new instance of the PingOptions class.
PingOptions(Int32, Boolean)	- Initializes a new instance of the PingOptions class and sets the Time to Live and fragmentation values.

Properties:
----------
DontFragment	- Gets or sets a Boolean value that controls fragmentation of the data sent to the remote host.
Ttl	- Gets or sets the number of routing nodes that can forward the Ping data before it is discarded.

**/