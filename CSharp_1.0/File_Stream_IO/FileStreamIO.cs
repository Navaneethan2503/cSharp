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

Streams:
---------
The abstract base class Stream supports reading and writing bytes. All classes that represent streams inherit from the Stream class. The Stream class and its derived classes provide a common view of data sources and repositories, and isolate the programmer from the specific details of the operating system and underlying devices.

Streams involve three fundamental operations:
    Reading - transferring data from a stream into a data structure, such as an array of bytes.
    Writing - transferring data to a stream from a data source.
    Seeking - querying and modifying the current position within a stream.
Depending on the underlying data source or repository, a stream might support only some of these capabilities. For example, the PipeStream class does not support seeking. The CanRead, CanWrite, and CanSeek properties of a stream specify the operations that the stream supports.
Here are some commonly used stream classes:
    FileStream – for reading and writing to a file.
    IsolatedStorageFileStream – for reading and writing to a file in isolated storage.
    MemoryStream – for reading and writing to memory as the backing store.
    BufferedStream – for improving performance of read and write operations.
    NetworkStream – for reading and writing over network sockets.
    PipeStream – for reading and writing over anonymous and named pipes.
    CryptoStream – for linking data streams to cryptographic transformations.

Readers and writers:
--------------------
The System.IO namespace also provides types for reading encoded characters from streams and writing them to streams. Typically, streams are designed for byte input and output. The reader and writer types handle the conversion of the encoded characters to and from bytes so the stream can complete the operation. Each reader and writer class is associated with a stream, which can be retrieved through the class's BaseStream property.

Here are some commonly used reader and writer classes:
    BinaryReader and BinaryWriter – for reading and writing primitive data types as binary values.
    StreamReader and StreamWriter – for reading and writing characters by using an encoding value to convert the characters to and from bytes.
    StringReader and StringWriter – for reading and writing characters to and from strings.
    TextReader and TextWriter – serve as the abstract base classes for other readers and writers that read and write characters and strings, but not binary data.

Asynchronous I/O operations:
------------------------------
Reading or writing a large amount of data can be resource-intensive. You should perform these tasks asynchronously if your application needs to remain responsive to the user. With synchronous I/O operations, the UI thread is blocked until the resource-intensive operation has completed. Use asynchronous I/O operations when developing Windows 8.x Store apps to prevent creating the impression that your app has stopped working.

The asynchronous members contain Async in their names, such as the CopyToAsync, FlushAsync, ReadAsync, and WriteAsync methods. You use these methods with the async and await keywords.


Compression:
------------
Compression refers to the process of reducing the size of a file for storage. Decompression is the process of extracting the contents of a compressed file so they are in a usable format. The System.IO.Compression namespace contains types for compressing and decompressing files and streams.

The following classes are frequently used when compressing and decompressing files and streams:

    ZipArchive – for creating and retrieving entries in the zip archive.
    ZipArchiveEntry – for representing a compressed file.
    ZipFile – for creating, extracting, and opening a compressed package.
    ZipFileExtensions – for creating and extracting entries in a compressed package.
    DeflateStream – for compressing and decompressing streams using the Deflate algorithm.
    GZipStream – for compressing and decompressing streams in gzip data format.


Isolated storage:
-------------------
Isolated storage is a data storage mechanism that provides isolation and safety by defining standardized ways of associating code with saved data. The storage provides a virtual file system that is isolated by user, assembly, and (optionally) domain. Isolated storage is particularly useful when your application does not have permission to access user files. You can save settings or files for your application in a manner that is controlled by the computer's security policy.

Isolated storage is not available for Windows 8.x Store apps; instead, use application data classes in the Windows.Storage namespace. For more information, see Application data.

The following classes are frequently used when implementing isolated storage:
    IsolatedStorage – provides the base class for isolated storage implementations.
    IsolatedStorageFile – provides an isolated storage area that contains files and directories.
    IsolatedStorageFileStream - exposes a file within isolated storage.


I/O and security:
------------------
When you use the classes in the System.IO namespace, you must follow operating system security requirements such as access control lists (ACLs) to control access to files and directories. This requirement is in addition to any FileIOPermission requirements. You can manage ACLs programmatically
Default security policies prevent Internet or intranet applications from accessing files on the user's computer. Therefore, do not use the I/O classes that require a path to a physical file when writing code that will be downloaded over the internet or intranet.


Handle IO Errors:
------------------
In addition to the exceptions that can be thrown in any method call (such as an OutOfMemoryException when a system is stressed or an NullReferenceException due to programmer error), .NET file system methods can throw the following exceptions:

System.IO.IOException, the base class of all System.IO exception types. It is thrown for errors whose return codes from the operating system don't directly map to any other exception type.
System.IO.FileNotFoundException.
System.IO.DirectoryNotFoundException.
DriveNotFoundException.
System.IO.PathTooLongException.
System.OperationCanceledException.
System.UnauthorizedAccessException.
System.ArgumentException, which is thrown for invalid path characters on .NET Framework and on .NET Core 2.0 and previous versions.
System.NotSupportedException, which is thrown for invalid colons in .NET Framework.
System.Security.SecurityException, which is thrown for applications running in limited trust that lack the necessary permissions on .NET Framework only. (Full trust is the default on .NET Framework.)




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