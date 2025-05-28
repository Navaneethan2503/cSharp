/**
NetworkInterfaceType Enum:
--------------------------
    Specifies types of network interfaces.

    public enum NetworkInterfaceType

Fields
Name	Value	Description
Unknown	1	
The interface type is not known.

Ethernet	6	
The network interface uses an Ethernet connection. Ethernet is defined in IEEE standard 802.3.

TokenRing	9	
The network interface uses a Token-Ring connection. Token-Ring is defined in IEEE standard 802.5.

Fddi	15	
The network interface uses a Fiber Distributed Data Interface (FDDI) connection. FDDI is a set of standards for data transmission on fiber optic lines in a local area network.

BasicIsdn	20	
The network interface uses a basic rate interface Integrated Services Digital Network (ISDN) connection. ISDN is a set of standards for data transmission over telephone lines.

PrimaryIsdn	21	
The network interface uses a primary rate interface Integrated Services Digital Network (ISDN) connection. ISDN is a set of standards for data transmission over telephone lines.

Ppp	23	
The network interface uses a Point-To-Point protocol (PPP) connection. PPP is a protocol for data transmission using a serial device.

Loopback	24	
The network interface is a loopback adapter. Such interfaces are often used for testing; no traffic is sent over the wire.

Ethernet3Megabit	26	
The network interface uses an Ethernet 3 megabit/second connection. This version of Ethernet is defined in IETF RFC 895.

Slip	28	
The network interface uses a Serial Line Internet Protocol (SLIP) connection. SLIP is defined in IETF RFC 1055.

Atm	37	
The network interface uses asynchronous transfer mode (ATM) for data transmission.

GenericModem	48	
The network interface uses a modem.

FastEthernetT	62	
The network interface uses a Fast Ethernet connection over twisted pair and provides a data rate of 100 megabits per second. This type of connection is also known as 100Base-T.

Isdn	63	
The network interface uses a connection configured for ISDN and the X.25 protocol. X.25 allows computers on public networks to communicate using an intermediary computer.

FastEthernetFx	69	
The network interface uses a Fast Ethernet connection over optical fiber and provides a data rate of 100 megabits per second. This type of connection is also known as 100Base-FX.

Wireless80211	71	
The network interface uses a wireless LAN connection (IEEE 802.11 standard).

AsymmetricDsl	94	
The network interface uses an Asymmetric Digital Subscriber Line (ADSL).

RateAdaptDsl	95	
The network interface uses a Rate Adaptive Digital Subscriber Line (RADSL).

SymmetricDsl	96	
The network interface uses a Symmetric Digital Subscriber Line (SDSL).

VeryHighSpeedDsl	97	
The network interface uses a Very High Data Rate Digital Subscriber Line (VDSL).

IPOverAtm	114	
The network interface uses the Internet Protocol (IP) in combination with asynchronous transfer mode (ATM) for data transmission.

GigabitEthernet	117	
The network interface uses a gigabit Ethernet connection and provides a data rate of 1,000 megabits per second (1 gigabit per second).

Tunnel	131	
The network interface uses a tunnel connection.

MultiRateSymmetricDsl	143	
The network interface uses a Multirate Digital Subscriber Line.

HighPerformanceSerialBus	144	
The network interface uses a High Performance Serial Bus.

Wman	237	
The network interface uses a mobile broadband interface for WiMax devices.

Wwanpp	243	
The network interface uses a mobile broadband interface for GSM-based devices.

Wwanpp2	244	
The network interface uses a mobile broadband interface for CDMA-based devices.


**/