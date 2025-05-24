/**
FileSystemInfo Class:
---------------------
Provides the base class for both FileInfo and DirectoryInfo objects.

public abstract class FileSystemInfo : MarshalByRefObject, System.Runtime.Serialization.ISerializable

Remarks:
----------
The FileSystemInfo class contains methods that are common to file and directory manipulation. A FileSystemInfo object can represent either a file or a directory, thus serving as the basis for FileInfo or DirectoryInfo objects. Use this base class when parsing a lot of files and directories.

A derived class can inherit from FileSystemInfo only if the derived class has the AllAccess permission from the FileIOPermissionAccess enumeration.

In members that accept a path, the path can refer to a file or just a directory. The specified path can also refer to a relative path or a Universal Naming Convention (UNC) path for a server and share name. For example, all the following are acceptable paths:
    "c:\MyDir\MyFile.txt" in C#, or "c:\MyDir\MyFile.txt" in Visual Basic.
    "c:\MyDir" in C#, or "c:\MyDir" in Visual Basic.
    "MyDir\MySubdir" in C#, or "MyDir\MySubDir" in Visual Basic.
    "\\MyServer\MyShare" in C#, or "\MyServer\MyShare" in Visual Basic.


Constructors:
----------------
FileSystemInfo()	- Initializes a new instance of the FileSystemInfo class.

Fields:
-------
FullPath - Represents the fully qualified path of the directory or file.
OriginalPath - The path originally specified by the user, whether relative or absolute.

Properties:
-----------
Attributes	- Gets or sets the attributes for the current file or directory.
CreationTime- Gets or sets the creation time of the current file or directory.
CreationTimeUtc	- Gets or sets the creation time, in coordinated universal time (UTC), of the current file or directory.
Exists	- Gets a value indicating whether the file or directory exists.
Extension	- Gets the extension part of the file name, including the leading dot . even if it is the entire file name, or an empty string if no extension is present.
FullName	- Gets the full path of the directory or file.
LastAccessTime	- Gets or sets the time the current file or directory was last accessed.
LastAccessTimeUtc	- Gets or sets the time, in coordinated universal time (UTC), that the current file or directory was last accessed.
LastWriteTime	- Gets or sets the time when the current file or directory was last written to.
LastWriteTimeUtc	- Gets or sets the time, in coordinated universal time (UTC), when the current file or directory was last written to.
LinkTarget	- Gets the target path of the link located in FullName, or null if this FileSystemInfo instance doesn't represent a link.
Name	- For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property gets the name of the directory.
UnixFileMode	- Gets or sets the Unix file mode for the current file or directory.

Methods:
---------
CreateAsSymbolicLink(String)	- Creates a symbolic link located in FullName that points to the specified pathToTarget.
Delete()	- Deletes a file or directory.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
MemberwiseClone(Boolean)	- Creates a shallow copy of the current MarshalByRefObject object.(Inherited from MarshalByRefObject)
Refresh()	- Refreshes the state of the object.
ResolveLinkTarget(Boolean)	- Gets the target of the specified link.
ToString()	- Returns the original path. Use the FullName or Name properties for the full path or file/directory name.


**/
using System;

namespace FileStreamIONamespace{
    class FileSystemInfoClass{
        public static void Main(){
            Console.WriteLine("FileSystemInfoClass");
        }
    }
}