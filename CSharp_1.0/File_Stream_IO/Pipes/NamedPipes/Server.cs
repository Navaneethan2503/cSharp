using System;
using System.IO;
using System.IO.Pipes;

namespace NamedPipes{
    class PipeServer
    {
        public static void Main()
        {
            using (var pipeServer = new NamedPipeServerStream("mypipe", PipeDirection.InOut))
            {
                Console.WriteLine("Waiting for client connection...");
                pipeServer.WaitForConnection();

                using (var reader = new StreamReader(pipeServer))
                using (var writer = new StreamWriter(pipeServer) { AutoFlush = true })
                {
                    string message = reader.ReadLine();
                    Console.WriteLine("Received from client: " + message);
                    writer.WriteLine("Hello from server!");
                }
            }
        }
    }
}
