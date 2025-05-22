/**
File and Stream IO:
---------------------
File and stream I/O (input/output) refers to the transfer of data either to or from a storage medium. In .NET, the System.IO namespaces contain types that enable reading and writing, both synchronously and asynchronously, on data streams and files. 
These namespaces also contain types that perform compression and decompression on files, and types that enable communication through pipes and serial ports.

A file is an ordered and named collection of bytes that has persistent storage. When you work with files, you work with directory paths, disk storage, and file and directory names. In contrast, a stream is a sequence of bytes that you can use to read from and write to a backing store, which can be one of several storage mediums (for example, disks or memory). 
Just as there are several backing stores other than disks, there are several kinds of streams other than file streams, such as network, memory, and pipe streams.

Files and directories:
-----------------------
You can use the types in the System.IO namespace to interact with files and directories. For example, you can get and set properties for files and directories, and retrieve collections of files and directories based on search criteria.
Here are some commonly used file and directory classes:
    1.File - provides static methods for creating, copying, deleting, moving, and opening files, and helps create a FileStream object.
    2.FileInfo - provides instance methods for creating, copying, deleting, moving, and opening files, and helps create a FileStream object.
    3.Directory - provides static methods for creating, moving, and enumerating through directories and subdirectories.
    4.DirectoryInfo - provides instance methods for creating, moving, and enumerating through directories and subdirectories.
    5.Path - provides methods and properties for processing directory strings in a cross-platform manner.
You should always provide robust exception handling when calling filesystem methods. For more information, see Handling I/O errors.



**/
using System;
using System.IO;

namespace FileStreamIONamespace{
    class FileStreamIO{
        public static void Main(){
            Console.WriteLine("File and Stream IO.");
        }
    }
}