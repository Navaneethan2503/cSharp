/**
IPAddressInformation Class:
----------------------------

public abstract class IPAddressInformation

Remarks:
-----------
You do not create instances of this class; instances are returned by methods in the IPInterfaceProperties class.

Constructors:
----------------
IPAddressInformation()	- Initializes a new instance of the IPAddressInformation class.

Properties:
-----------
Address	- Gets the Internet Protocol (IP) address.
IsDnsEligible	- Gets a Boolean value that indicates whether the Internet Protocol (IP) address is valid to appear in a Domain Name System (DNS) server database.
IsTransient	 - Gets a Boolean value that indicates whether the Internet Protocol (IP) address is transient (a cluster address).

Methods:
--------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Returns a string that represents the current object.(Inherited from Object)


**/
using System;

namespace Networking{
    class IPAddressInformationClass{
        public static void Main(){
            Console.WriteLine("IPAddressInformation Class");
        }
    }
}