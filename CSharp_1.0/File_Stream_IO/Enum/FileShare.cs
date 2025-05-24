/**
FileShare Enum
------------------------
Contains constants for controlling the kind of access other operations can have to the same file.

This enumeration supports a bitwise combination of its member values.

[System.Flags]
public enum FileShare

Fields
Name	Value	Description
None	0	
Declines sharing of the current file. Any request to open the file (by this process or another process) will fail until the file is closed.

Read	1	
Allows subsequent opening of the file for reading. If this flag is not specified, any request to open the file for reading (by this process or another process) will fail until the file is closed. However, even if this flag is specified, additional permissions might still be needed to access the file.

Write	2	
Allows subsequent opening of the file for writing. If this flag is not specified, any request to open the file for writing (by this process or another process) will fail until the file is closed. However, even if this flag is specified, additional permissions might still be needed to access the file.

ReadWrite	3	
Allows subsequent opening of the file for reading or writing. If this flag is not specified, any request to open the file for reading or writing (by this process or another process) will fail until the file is closed. However, even if this flag is specified, additional permissions might still be needed to access the file.

Delete	4	
Allows subsequent deleting of a file.

Inheritable	16	
Makes the file handle inheritable by child processes. This is not directly supported by Win32.


**/