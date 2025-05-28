/**
TcpStatistics Class:
--------------------
Provides Transmission Control Protocol (TCP) statistical data.
    public abstract class TcpStatistics

Remarks
Instances of this class are returned by the GetTcpIPv4Statistics and GetTcpIPv6Statistics methods, to give applications access to TCP traffic information.

Constructors:
---------------
TcpStatistics()	- Initializes a new instance of the TcpStatistics class.

Properties:
------------
ConnectionsAccepted	- Gets the number of accepted Transmission Control Protocol (TCP) connection requests.
ConnectionsInitiated	- Gets the number of Transmission Control Protocol (TCP) connection requests made by clients.
CumulativeConnections	- Specifies the total number of Transmission Control Protocol (TCP) connections established.
CurrentConnections	- Gets the number of current Transmission Control Protocol (TCP) connections.
ErrorsReceived	- Gets the number of Transmission Control Protocol (TCP) errors received.
FailedConnectionAttempts	- Gets the number of failed Transmission Control Protocol (TCP) connection attempts.
MaximumConnections	- Gets the maximum number of supported Transmission Control Protocol (TCP) connections.
MaximumTransmissionTimeout	- Gets the maximum retransmission time-out value for Transmission Control Protocol (TCP) segments.
MinimumTransmissionTimeout	- Gets the minimum retransmission time-out value for Transmission Control Protocol (TCP) segments.
ResetConnections	- Gets the number of RST packets received by Transmission Control Protocol (TCP) connections.
ResetsSent	- Gets the number of Transmission Control Protocol (TCP) segments sent with the reset flag set.
SegmentsReceived	- Gets the number of Transmission Control Protocol (TCP) segments received.
SegmentsResent	- Gets the number of Transmission Control Protocol (TCP) segments re-sent.
SegmentsSent	- Gets the number of Transmission Control Protocol (TCP) segments sent.

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
    class TcpStatisticsClass{
        public static void Main(){
            Console.WriteLine("TcpStatistics Class");
        }
    }
}