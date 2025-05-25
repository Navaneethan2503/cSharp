/**

ISolated Storage Scope Enum:
----------------------------


Enumerates the levels of isolated storage scope that are supported by IsolatedStorage.

This enumeration supports a bitwise combination of its member values.

[System.Flags]
public enum IsolatedStorageScope

Fields
Name	Value	Description
None	0	
No isolated storage usage.

User	1	
Isolated storage scoped by user identity.

Domain	2	
Isolated storage scoped to the application domain identity.

Assembly	4	
Isolated storage scoped to the identity of the assembly.

Roaming	8	
The isolated store can be placed in a location on the file system that might roam (if roaming user data is enabled on the underlying operating system).

Machine	16	
Isolated storage scoped to the machine.

Application	32	
Isolated storage scoped to the application.

**/