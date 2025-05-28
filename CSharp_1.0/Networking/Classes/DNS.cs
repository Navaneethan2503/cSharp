/**
DNS Class:
-----------
Provides simple domain name resolution functionality.

public static class Dns

Remarks:
----------
The Dns class is a static class that retrieves information about a specific host from the Internet Domain Name System (DNS).

The host information from the DNS query is returned in an instance of the IPHostEntry class. If the specified host has more than one entry in the DNS database, IPHostEntry contains multiple IP addresses and aliases.

Methods:
---------
BeginGetHostAddresses(String, AsyncCallback, Object)	- Asynchronously returns the Internet Protocol (IP) addresses for the specified host.
BeginGetHostEntry(IPAddress, AsyncCallback, Object)	 - Asynchronously resolves an IP address to an IPHostEntry instance.
BeginGetHostEntry(String, AsyncCallback, Object)	- Asynchronously resolves a host name or IP address to an IPHostEntry instance.
    public static IAsyncResult BeginGetHostEntry(string hostNameOrAddress, AsyncCallback? requestCallback, object? stateObject);
    public static IAsyncResult BeginGetHostEntry(System.Net.IPAddress address, AsyncCallback? requestCallback, object? stateObject);
    
EndGetHostAddresses(IAsyncResult)	- Ends an asynchronous request for DNS information.
EndGetHostEntry(IAsyncResult)	- Ends an asynchronous request for DNS information.

GetHostAddresses(String, AddressFamily)	- Returns the Internet Protocol (IP) addresses for the specified host.
GetHostAddresses(String)	- Returns the Internet Protocol (IP) addresses for the specified host.
    public static System.Net.IPAddress[] GetHostAddresses(string hostNameOrAddress);
    public static System.Net.IPAddress[] GetHostAddresses(string hostNameOrAddress, System.Net.Sockets.AddressFamily family);

GetHostAddressesAsync(String, AddressFamily, CancellationToken)	- Returns the Internet Protocol (IP) addresses for the specified host as an asynchronous operation.
GetHostAddressesAsync(String, CancellationToken)	- Returns the Internet Protocol (IP) addresses for the specified host as an asynchronous operation.
GetHostAddressesAsync(String)	- Returns the Internet Protocol (IP) addresses for the specified host as an asynchronous operation.

GetHostEntry(IPAddress)	- Resolves an IP address to an IPHostEntry instance.
GetHostEntry(String, AddressFamily)	- Resolves a host name or IP address to an IPHostEntry instance.
GetHostEntry(String)	- Resolves a host name or IP address to an IPHostEntry instance.
    public static System.Net.IPHostEntry GetHostEntry(string hostNameOrAddress);
    public static System.Net.IPHostEntry GetHostEntry(string hostNameOrAddress, System.Net.Sockets.AddressFamily family);

GetHostEntryAsync(IPAddress)	- Resolves an IP address to an IPHostEntry instance as an asynchronous operation.
GetHostEntryAsync(String, AddressFamily, CancellationToken)	- Resolves a host name or IP address to an IPHostEntry instance as an asynchronous operation.
GetHostEntryAsync(String, CancellationToken)	- Resolves a host name or IP address to an IPHostEntry instance as an asynchronous operation.
GetHostEntryAsync(String)	- Resolves a host name or IP address to an IPHostEntry instance as an asynchronous operation.
GetHostName()	- Gets the host name of the local computer.


**/
using System;
using System.Net;


namespace Networking{
    class DNSClass{
        public static void Main(){
            Console.WriteLine("DNS Class");
            Console.WriteLine("Dns HostName : "+Dns.GetHostName());
            IPAddress[] res = Dns.GetHostAddresses("www.leetcode.com");
            foreach(IPAddress add in res){
                Console.WriteLine(string.Join(',',add.GetAddressBytes()));
            }
        }
    }
}