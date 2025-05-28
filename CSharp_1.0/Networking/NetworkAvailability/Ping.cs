/**

Determine if a remote host is reachable:
-----------------------------------------
You can use the Ping class to determine whether a remote host is up, on the network, and reachable.


**/
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Networking{
    class PingClass{
        public static void Main(){
            Console.WriteLine("Ping Class");
            Ping ping = new();

            string hostName = "google.com";
            PingReply reply = ping.Send(hostName);
            Console.WriteLine($"Ping status for ({hostName}): {reply.Status}");
            if (reply is { Status: IPStatus.Success })
            {
                Console.WriteLine($"Address: {reply.Address}");
                Console.WriteLine($"Roundtrip time: {reply.RoundtripTime}");
                Console.WriteLine($"Time to live: {reply.Options?.Ttl}");
                Console.WriteLine();
            }
        }
    }
}