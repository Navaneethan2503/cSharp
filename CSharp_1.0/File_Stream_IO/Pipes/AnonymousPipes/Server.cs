/**
**/

// File: ParentApp.csproj
// Console App

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
namespace Pipes{
    class AnonymousServerClass{
        public static void Main(){
            Console.WriteLine("Pipes AnonymousPipes");
            
            using (var pipeServer = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
            {
                Console.WriteLine("[Parent] Pipe handle: " + pipeServer.GetClientHandleAsString());

                // Start the child process and pass the pipe handle
                ProcessStartInfo psi = new ProcessStartInfo("ChildApp.exe", pipeServer.GetClientHandleAsString())
                {
                    UseShellExecute = false
                };
                Process child = Process.Start(psi);

                pipeServer.DisposeLocalCopyOfClientHandle();

                using (StreamWriter writer = new StreamWriter(pipeServer))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine("Hello from Parent!");
                    writer.WriteLine("This is a message through anonymous pipe.");
                }

                child.WaitForExit();
            }
        }
        
    }
}

