/**
Network Availability, Statistics:
---------------------------------
The System.Net.NetworkInformation namespace enables you to gather information about network events, changes, statistics, and properties.

System.Net.NetworkInformation.NetworkChange class to determine whether the network address or availability has changed. Additionally, you'll see about the network statistics and properties on an interface or protocol basis. 

System.Net.NetworkInformation.Ping class to determine whether a remote host is reachable.


NetworkChange Class:
-------------------
Allows applications to receive notification when the Internet Protocol (IP) address of a network interface, also called a network card or adapter, changes.

    public class NetworkChange

Remarks:
----------
The NetworkChange class provides address change notification by raising NetworkAddressChanged events. An interface address can change for many reasons, such as a disconnected network cable, moving out of range of a wireless Local Area Network, or hardware failure.

To receive notification, you must identify your application's event handlers, which are one or more methods that perform your application-specific tasks each time the event is raised. To have a NetworkChange object call your event-handling methods when a NetworkAddressChanged event occurs, you must associate the methods with a NetworkAddressChangedEventHandler delegate, and add this delegate to the event.

Events
NetworkAddressChanged	- Occurs when the IP address of a network interface changes.
    [System.Runtime.Versioning.UnsupportedOSPlatform("illumos")]
    [System.Runtime.Versioning.UnsupportedOSPlatform("solaris")]
    public static event System.Net.NetworkInformation.NetworkAddressChangedEventHandler? NetworkAddressChanged;

NetworkAvailabilityChanged	- Occurs when the availability of the network changes.
    [System.Runtime.Versioning.UnsupportedOSPlatform("illumos")]
    [System.Runtime.Versioning.UnsupportedOSPlatform("solaris")]
    public static event System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler? NetworkAvailabilityChanged;

**/
using System;
using System.Net.NetworkInformation;
using System.Linq;

namespace Networking{
    class NetworkAvailability{
        static void OnNetworkAvailabilityChanged(
            object? sender, NetworkAvailabilityEventArgs networkAvailability){
                if(networkAvailability.IsAvailable){
                    Console.WriteLine("Network is available.");
                }
                else{
                    Console.WriteLine("Network Disconnected / Not Available.");
                }
            }

        static void OnNetworkAddressChanged(
            object? sender, EventArgs args)
        {
            foreach ((string name, OperationalStatus status) in
                NetworkInterface.GetAllNetworkInterfaces()
                    .Select(networkInterface =>
                        (networkInterface.Name, networkInterface.OperationalStatus)))
            {
                Console.WriteLine(
                    $"{name} is {status}");
            }
        }
            

        public static void Main(){
            Console.WriteLine("Network Availability");
            //Network Changes Event:
            NetworkChange.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;
            
            Console.WriteLine(
                "Listening changes in network availability. Press any key to continue.");
            Console.ReadLine();

            NetworkChange.NetworkAvailabilityChanged -= OnNetworkAvailabilityChanged;

            NetworkChange.NetworkAddressChanged += OnNetworkAddressChanged;
            Console.WriteLine(
                "Listening for address changes. Press any key to continue.");
            Console.ReadLine();


            NetworkChange.NetworkAddressChanged -= OnNetworkAddressChanged;
        }
    }
}