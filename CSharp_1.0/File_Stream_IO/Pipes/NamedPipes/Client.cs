using System;
using System.IO;
using System.IO.Pipes;

namespace NamedPipes{
    class PipeClient
    {
        static void Main()
        {
            using (var pipeClient = new NamedPipeClientStream(".", "mypipe", PipeDirection.InOut))
            {
                pipeClient.Connect();

                using (var writer = new StreamWriter(pipeClient) { AutoFlush = true })
                using (var reader = new StreamReader(pipeClient))
                {
                    writer.WriteLine("Hello from client!");
                    string response = reader.ReadLine();
                    Console.WriteLine("Received from server: " + response);
                }
            }
        }
    }
}
