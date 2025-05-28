/**
PhysicalAddressClass Class:
-----------------------------
Provides the Media Access Control (MAC) address for a network interface (adapter).

public class PhysicalAddress

Constructors:
-------------
PhysicalAddress(Byte[])	- Initializes a new instance of the PhysicalAddress class.
    public PhysicalAddress(byte[] address);

Fields:
--------
None	- Returns a new PhysicalAddress instance with a zero length address. This field is read-only.

Methods:
---------
Equals(Object)	- Compares two PhysicalAddress instances.
GetAddressBytes()	- Returns the address of the current instance.
    public byte[] GetAddressBytes();
GetHashCode()	- Returns the hash value of a physical address.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Parse(ReadOnlySpan<Char>)	- Parses the specified span and stores its contents as the address bytes of the PhysicalAddress returned by this method.
Parse(String)	- Parses the specified String and stores its contents as the address bytes of the PhysicalAddress returned by this method.
ToString()	- Returns the String representation of the address of this instance.
TryParse(ReadOnlySpan<Char>, PhysicalAddress)	- Tries to convert the span representation of a hardware address to a PhysicalAddress instance. A return value indicates whether the conversion succeeded.
TryParse(String, PhysicalAddress)	- Tries to convert the string representation of a hardware address to a PhysicalAddress instance. A return value indicates whether the conversion succeeded.

**/
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Networking{
    class PhysicalAddressClass{
        public static void ShowNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Interface information for {0}.{1}     ",
                    computerProperties.HostName, computerProperties.DomainName);
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return;
            }

            Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties(); //  .GetIPInterfaceProperties();
                Console.WriteLine();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.Write("  Physical address ........................ : ");
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                for (int i = 0; i < bytes.Length; i++)
                {
                    // Display the physical address in hexadecimal.
                    Console.Write("{0}", bytes[i].ToString("X2"));
                    // Insert a hyphen after each byte, unless we're at the end of the address.
                    if (i != bytes.Length - 1)
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void Main(){
            Console.WriteLine("PhysicalAddress Class");
            ShowNetworkInterfaces();
        }
    }
}