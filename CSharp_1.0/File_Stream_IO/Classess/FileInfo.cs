/**
FileInfo Class:
---------------
Provides properties and instance methods for the creation, copying, deletion, moving, and opening of files, and aids in the creation of FileStream objects. This class cannot be inherited.

    public sealed class FileInfo : System.IO.FileSystemInfo

Remarks
Use the FileInfo class for typical operations such as copying, moving, renaming, creating, opening, deleting, and appending to files.

If you are performing multiple operations on the same file, it can be more efficient to use FileInfo instance methods instead of the corresponding static methods of the File class, because a security check will not always be necessary.

Many of the FileInfo methods return other I/O types when you create or open files. You can use these other types to further manipulate a file. For more information, see specific FileInfo members such as Open, OpenRead, OpenText, CreateText, or Create.

By default, full read/write access to new files is granted to all users.


In members that accept a path as an input string, that path must be well-formed or an exception is raised. For example, if a path is fully qualified but begins with a space, the path is not trimmed in methods of the class. Therefore, the path is malformed and an exception is raised. Similarly, a path or a combination of paths cannot be fully qualified twice. For example, "c:\temp c:\windows" also raises an exception in most cases. Ensure that your paths are well-formed when using methods that accept a path string.

In members that accept a path, the path can refer to a file or just a directory. The specified path can also refer to a relative path or a Universal Naming Convention (UNC) path for a server and share name. For example, all the following are acceptable paths:

"c:\MyDir\MyFile.txt" in C#, or "c:\MyDir\MyFile.txt" in Visual Basic.

"c:\MyDir" in C#, or "c:\MyDir" in Visual Basic.

"MyDir\MySubdir" in C#, or "MyDir\MySubDir" in Visual Basic.

"\\MyServer\MyShare" in C#, or "\MyServer\MyShare" in Visual Basic.

Constructors:
---------------
FileInfo(String)	- Initializes a new instance of the FileInfo class, which acts as a wrapper for a file path.

All Method and Properties are same from derived class.


**/
using System;

namespace FileStreamIONamespace{
    class FileInfoClass{
        public static void Main(){
            Console.WriteLine("FileInfo Class");
        }
    }
}