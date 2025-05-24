/**
FileAccess Eum:
-----------------
Defines constants for read, write, or read/write access to a file.

This enumeration supports a bitwise combination of its member values.
[System.Flags]
public enum FileAccess

Fields
Name	Value	Description
Read	1	
Read access to the file. Data can be read from the file. Combine with Write for read/write access.

Write	2	
Write access to the file. Data can be written to the file. Combine with Read for read/write access.

ReadWrite	3	
Read and write access to the file. Data can be written to and read from the file.

**/