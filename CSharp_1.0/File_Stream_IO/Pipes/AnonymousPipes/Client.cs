// File: ChildApp.csproj
// Console App

using System;
using System.IO;
using System.IO.Pipes;

namespace Pipes{
    class ChildApp
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("[Child] No pipe handle received.");
                return;
            }

            string pipeHandle = args[0];
            using (var pipeClient = new AnonymousPipeClientStream(PipeDirection.In, pipeHandle))
            using (StreamReader reader = new StreamReader(pipeClient))
            {
                Console.WriteLine("[Child] Reading from pipe...");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("[Child] Received: " + line);
                }
            }
        }
    }

}
