/**
MemoryMappedFile Class:
--------------------------------
Represent Memmory mapped file

    public class MemoryMappedFile : IDisposable


Remarks:
--------
A memory-mapped file maps the contents of a file to an application's logical address space. Memory-mapped files enable programmers to work with extremely large files because memory can be managed concurrently, and they allow complete, random access to a file without the need for seeking. Memory-mapped files can also be shared across multiple processes.

The CreateFromFile methods create a memory-mapped file from a specified path or a FileStream of an existing file on disk. Changes are automatically propagated to disk when the file is unmapped.

The CreateNew methods create a memory-mapped file that is not mapped to an existing file on disk; and are suitable for creating shared memory for interprocess communication (IPC).

A memory-mapped file can be associated with an optional name that allows the memory-mapped file to be shared with other processes.

You can create multiple views of the memory-mapped file, including views of parts of the file. You can map the same part of a file to more than one address to create concurrent memory. For two views to remain concurrent, they have to be created from the same memory-mapped file. Creating two file mappings of the same file with two views does not provide concurrency.

Properties:
-------------
SafeMemoryMappedFileHandle	- Gets the file handle of a memory-mapped file.

Methods:
--------------
CreateFromFile(FileStream, String, Int64, MemoryMappedFileAccess, HandleInheritability, Boolean) - Creates a memory-mapped file from an existing file with the specified access mode, name, inheritability, and capacity.
CreateFromFile(SafeFileHandle, String, Int64, MemoryMappedFileAccess, HandleInheritability, Boolean)	-Creates a memory-mapped file from an existing file using a SafeFileHandle and the specified access mode, name, inheritability, and capacity.
    public static System.IO.MemoryMappedFiles.MemoryMappedFile CreateFromFile(System.IO.FileStream fileStream, string? mapName, long capacity, System.IO.MemoryMappedFiles.MemoryMappedFileAccess access, System.IO.HandleInheritability inheritability, bool leaveOpen);

CreateFromFile(String, FileMode, String, Int64, MemoryMappedFileAccess)	-Creates a memory-mapped file that has the specified access mode, name, capacity, and access type from a file on disk.
CreateFromFile(String, FileMode, String, Int64)	-Creates a memory-mapped file that has the specified access mode, name, and capacity from a file on disk.
CreateFromFile(String, FileMode, String)	-Creates a memory-mapped file that has the specified access mode and name from a file on disk.
CreateFromFile(String, FileMode)	-Creates a memory-mapped file that has the specified access mode from a file on disk.
CreateFromFile(String)	-Creates a memory-mapped file from a file on disk.
    public static System.IO.MemoryMappedFiles.MemoryMappedFile CreateFromFile(string path, System.IO.FileMode mode, string? mapName, long capacity);

CreateNew(String, Int64, MemoryMappedFileAccess, MemoryMappedFileOptions, HandleInheritability)	-Creates a memory-mapped file that has the specified name, capacity, access type, memory allocation options and inheritability.
CreateNew(String, Int64, MemoryMappedFileAccess)	-Creates a memory-mapped file that has the specified capacity and access type in system memory.
CreateNew(String, Int64)	-Creates a memory-mapped file that has the specified capacity in system memory.
CreateOrOpen(String, Int64, MemoryMappedFileAccess, MemoryMappedFileOptions, HandleInheritability)	-Creates a new empty memory mapped file or opens an existing memory mapped file if one exists with the same name. If opening an existing file, the capacity, options, and memory arguments will be ignored.
CreateOrOpen(String, Int64, MemoryMappedFileAccess)	-Creates or opens a memory-mapped file that has the specified name, capacity and access type in system memory.
CreateOrOpen(String, Int64)	-Creates or opens a memory-mapped file that has the specified name and capacity in system memory.
CreateViewAccessor()	-Creates a MemoryMappedViewAccessor that maps to a view of the memory-mapped file.
CreateViewAccessor(Int64, Int64, MemoryMappedFileAccess)	-Creates a MemoryMappedViewAccessor that maps to a view of the memory-mapped file, and that has the specified offset, size, and access restrictions.
CreateViewAccessor(Int64, Int64)	-Creates a MemoryMappedViewAccessor that maps to a view of the memory-mapped file, and that has the specified offset and size.
    public static System.IO.MemoryMappedFiles.MemoryMappedFile CreateNew(string? mapName, long capacity);

CreateViewStream()	-Creates a stream that maps to a view of the memory-mapped file.-
CreateViewStream(Int64, Int64, MemoryMappedFileAccess)	-Creates a stream that maps to a view of the memory-mapped file, and that has the specified offset, size, and access type.
CreateViewStream(Int64, Int64)	-Creates a stream that maps to a view of the memory-mapped file, and that has the specified offset and size.
Dispose()	-Releases all resources used by the MemoryMappedFile.
Dispose(Boolean)	-Releases the unmanaged resources used by the MemoryMappedFile and optionally releases the managed resources.
Equals(Object)	-Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	-Serves as the default hash function.(Inherited from Object)
GetType()-Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	-Creates a shallow copy of the current Object.(Inherited from Object)
OpenExisting(String, MemoryMappedFileRights, HandleInheritability)-Opens an existing memory-mapped file that has the specified name, access rights, and inheritability in system memory.
OpenExisting(String, MemoryMappedFileRights)	-Opens an existing memory-mapped file that has the specified name and access rights in system memory.
OpenExisting(String)	-Opens an existing memory-mapped file that has the specified name in system memory.
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public static System.IO.MemoryMappedFiles.MemoryMappedFile OpenExisting(string mapName, System.IO.MemoryMappedFiles.MemoryMappedFileRights desiredAccessRights, System.IO.HandleInheritability inheritability);

ToString()	-Returns a string that represents the current object.(Inherited from Object)



**/