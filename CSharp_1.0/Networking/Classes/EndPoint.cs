/**
EndPoint Class:
--------------
Identifies a network address. This is an abstract class.

public abstract class EndPoint

Constructors:
--------------
EndPoint()	- Initializes a new instance of the EndPoint class.

Properties:
----------
AddressFamily	- Gets the address family to which the endpoint belongs.

Methods:
---------
Create(SocketAddress)	- Creates an EndPoint instance from a SocketAddress instance.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Serialize()	- Serializes endpoint information into a SocketAddress instance.
ToString()	- Returns a string that represents the current object.(Inherited from Object)

**/