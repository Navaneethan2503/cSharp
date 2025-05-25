/**

Memory-Mapped Files in C# are a powerful feature that allows you to map the contents of a file directly into memory, enabling fast and efficient file I/O operations. They are especially useful for working with large files, shared memory, or inter-process communication (IPC).

Let’s break it down in a clear and structured way:

🧠 What Is a Memory-Mapped File?
A Memory-Mapped File (MMF) is a mechanism that lets you treat a file (or a portion of it) as if it were part of your program’s memory. This allows you to read from and write to the file using memory operations, which can be much faster than traditional file I/O.

🧰 Why Use Memory-Mapped Files?
⚡ High performance: Accessing memory is faster than disk I/O.
🔁 Shared memory: Multiple processes can access the same memory-mapped file.
🧩 Partial file access: You can map only a portion of a large file.
🔄 Bidirectional communication: Useful for IPC between processes.

🧱 Types of Memory-Mapped Files
Backed by a file on disk:
--------------------------------------
Useful for working with large files.
Created using MemoryMappedFile.CreateFromFile(...).
Backed by system memory (no file):

Used for IPC or temporary data.
-----------------------------
Created using MemoryMappedFile.CreateNew(...).
🔐 Security and Access
You can set access permissions and memory protection.
You can use named memory-mapped files to share between processes.

📦 Use Cases
Large file processing (e.g., logs, databases).
Real-time data sharing between processes.
High-performance applications (e.g., games, simulations).

A memory-mapped file contains the contents of a file in virtual memory. This mapping between a file and memory space enables an application, including multiple processes, to modify the file by reading and writing directly to the memory. You can use managed code to access memory-mapped files in the same way that native Windows functions access memory-mapped files, as described in Managing Memory-Mapped Files.

There are two types of memory-mapped files:

Persisted memory-mapped files:
----------------------------------------------------------------

Persisted files are memory-mapped files that are associated with a source file on a disk. When the last process has finished working with the file, the data is saved to the source file on the disk. These memory-mapped files are suitable for working with extremely large source files.

Non-persisted memory-mapped files:
--------------------------------------------

Non-persisted files are memory-mapped files that are not associated with a file on a disk. When the last process has finished working with the file, the data is lost and the file is reclaimed by garbage collection. These files are suitable for creating shared memory for inter-process communications (IPC).

Processes, Views, and Managing Memory:
--------------------------------------
Memory-mapped files can be shared across multiple processes. Processes can map to the same memory-mapped file by using a common name that is assigned by the process that created the file.

To work with a memory-mapped file, you must create a view of the entire memory-mapped file or a part of it. You can also create multiple views to the same part of the memory-mapped file, thereby creating concurrent memory. For two views to remain concurrent, they have to be created from the same memory-mapped file.

Multiple views may also be necessary if the file is greater than the size of the application's logical memory space available for memory mapping (2 GB on a 32-bit computer).

There are two types of views: stream access view and random access view. Use stream access views for sequential access to a file; this is recommended for non-persisted files and IPC. Random access views are preferred for working with persisted files.

Memory-mapped files are accessed through the operating system's memory manager, so the file is automatically partitioned into a number of pages and accessed as needed. You do not have to handle the memory management yourself.

The following illustration shows how multiple processes can have multiple and overlapping views to the same memory-mapped file at the same time.



**/
using System;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace MemoryMappedFiles{
    class MemoryMappedFilesClass{
        public static void Main(){
            Console.WriteLine("Memory Mapped Files");
            // Create a memory-mapped file of 1 KB
            using (var mmf = MemoryMappedFile.CreateOrOpen("MyMappedFile", 1024))
            {
                // Create a view accessor to write data
                using (var accessor = mmf.CreateViewAccessor())
                {
                    string message = "Hello from memory-mapped file!";
                    byte[] bytes = Encoding.UTF8.GetBytes(message);

                    accessor.WriteArray(0, bytes, 0, bytes.Length);
                    Console.WriteLine("Data written to memory-mapped file.");
                }
                using (var accessor = mmf.CreateViewAccessor())
                {
                    byte[] buffer = new byte[1024];
                    accessor.ReadArray(0, buffer, 0, buffer.Length);

                    string message = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                    Console.WriteLine("Read from memory-mapped file: " + message);
                }
            }

            using (var mmf = MemoryMappedFile.CreateOrOpen("MyMappedFile", 1024))
            {
                using (var accessor = mmf.CreateViewAccessor())
                {
                    byte[] buffer = new byte[1024];
                    accessor.ReadArray(0, buffer, 0, buffer.Length);

                    string message = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                    Console.WriteLine("Read from memory-mapped file: " + message);
                }
            }

        }
    }
}

