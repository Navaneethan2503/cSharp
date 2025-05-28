/**
UdpStatistics Class:
---------------------
Provides User Datagram Protocol (UDP) statistical data.
    public abstract class UdpStatistics

Constructors:
---------------
UdpStatistics()	- Initializes a new instance of the UdpStatistics class.

Properties:
-------------
DatagramsReceived	- Gets the number of User Datagram Protocol (UDP) datagrams that were received.
DatagramsSent	- Gets the number of User Datagram Protocol (UDP) datagrams that were sent.
IncomingDatagramsDiscarded	- Gets the number of User Datagram Protocol (UDP) datagrams that were received and discarded because of port errors.
IncomingDatagramsWithErrors	- Gets the number of User Datagram Protocol (UDP) datagrams that were received and discarded because of errors other than bad port information.
UdpListeners	- Gets the number of local endpoints that are listening for User Datagram Protocol (UDP) datagrams.

Methods:
---------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Returns a string that represents the current object.(Inherited from Object)

**/
using System;

namespace Networking{
    class UdpStatisticsClass{
        public static void Main(){
            Console.WriteLine("UdpStatistics Class");
        }
    }
}