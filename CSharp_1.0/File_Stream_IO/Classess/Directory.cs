/**
Directory Class:
----------------
Exposes static methods for creating, moving, and enumerating through directories and subdirectories. This class cannot be inherited.

    public static class Directory

Remarks
Use the Directory class for typical operations such as copying, moving, renaming, creating, and deleting directories.

To create a directory, use one of the CreateDirectory methods.

To delete a directory, use one of the Delete methods.

To get or set the current directory for an app, use the GetCurrentDirectory or SetCurrentDirectory method.

To manipulate DateTime information related to the creation, access, and writing of a directory, use methods such as SetLastAccessTime and SetCreationTime.

The static methods of the Directory class perform security checks on all methods. If you are going to reuse an object several times, consider using the corresponding instance method of DirectoryInfo instead, because the security check will not always be necessary.

If you are performing only one directory-related action, it might be more efficient to use a static Directory method rather than a corresponding DirectoryInfo instance method. Most Directory methods require the path to the directory that you are manipulating.

 Note

In members that accept a string path parameter, that path must be well-formed or an exception is raised. For example, if a path is fully qualified but begins with a space (" c:\temp"), the path string isn't trimmed, so the path is considered malformed and an exception is raised. In addition, a path or a combination of paths cannot be fully qualified twice. For example, "c:\temp c:\windows" also raises an exception. Ensure that your paths are well-formed when using methods that accept a path string. For more information see Path.

In members that accept a path, the path can refer to a file or a directory. You can use a full path, a relative path, or a Universal Naming Convention (UNC) path for a server and share name. For example, all the following are acceptable paths:

"c:\MyDir" in C#, or "c:\MyDir" in Visual Basic.

"MyDir\MySubdir" in C#, or "MyDir\MySubDir" in Visual Basic.

"\\MyServer\MyShare" in C#, or "\MyServer\MyShare" in Visual Basic.

By default, full read/write access to new directories is granted to all users. However, the app must have the correct security to access existing directories.

To demand permissions for a directory and all its subdirectories, end the path string with the directory separator character. (For example, "C:\Temp\" grants access to C:\Temp\ and all its subdirectories.) To demand permissions only for a specific directory, end the path string with a period. (For example, "C:\Temp\." grants access only to C:\Temp\, not to its subdirectories.)

In members that accept a searchPattern parameter, the search string can be any combination of literal characters and two wildcard characters; * and ?. This parameter does not recognize regular expressions. For more information, see the EnumerateDirectories(String, String) method or any other method that uses the searchPattern parameter.


Methods:
-----------
CreateDirectory(String, UnixFileMode)	- Creates all directories and subdirectories in the specified path with the specified permissions unless they already exist.
    [System.Runtime.Versioning.UnsupportedOSPlatform("windows")]
    public static System.IO.DirectoryInfo CreateDirectory(string path, System.IO.UnixFileMode unixCreateMode);

CreateDirectory(String)	- Creates all directories and subdirectories in the specified path unless they already exist.
    public static System.IO.DirectoryInfo CreateDirectory(string path);
    
CreateSymbolicLink(String, String)	- Creates a directory symbolic link identified by path that points to pathToTarget.

CreateTempSubdirectory(String)	- Creates a uniquely named, empty directory in the current user's temporary directory.
Delete(String, Boolean)	- Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
Delete(String)	- Deletes an empty directory from a specified path.
EnumerateDirectories(String, String, EnumerationOptions)	-Returns an enumerable collection of the directory full names that match a search pattern in a specified path, and optionally searches subdirectories.
EnumerateDirectories(String, String, SearchOption)	- Returns an enumerable collection of directory full names that match a search pattern in a specified path, and optionally searches subdirectories.
EnumerateDirectories(String, String)	- Returns an enumerable collection of directory full names that match a search pattern in a specified path.
EnumerateDirectories(String)	- Returns an enumerable collection of directory full names in a specified path.
EnumerateFiles(String, String, EnumerationOptions)	- Returns an enumerable collection of full file names that match a search pattern and enumeration options in a specified path, and optionally searches subdirectories.
EnumerateFiles(String, String, SearchOption)	- Returns an enumerable collection of full file names that match a search pattern in a specified path, and optionally searches subdirectories.
EnumerateFiles(String, String)	- Returns an enumerable collection of full file names that match a search pattern in a specified path.
EnumerateFiles(String)	- Returns an enumerable collection of full file names in a specified path.
EnumerateFileSystemEntries(String, String, EnumerationOptions)	- Returns an enumerable collection of file names and directory names that match a search pattern and enumeration options in a specified path.
EnumerateFileSystemEntries(String, String, SearchOption)	- Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
EnumerateFileSystemEntries(String, String)	`- Returns an enumerable collection of file names and directory names that match a search pattern in a specified path.
EnumerateFileSystemEntries(String)	- Returns an enumerable collection of file names and directory names in a specified path.
Exists(String)	- Determines whether the given path refers to an existing directory on disk.
GetCreationTime(String)	- Gets the creation date and time of a directory.
GetCreationTimeUtc(String)	- Gets the creation date and time, in Coordinated Universal Time (UTC) format, of a directory.
GetCurrentDirectory()	- Gets the current working directory of the application.
GetDirectories(String, String, EnumerationOptions)	- Returns the names of subdirectories (including their paths) that match the specified search pattern and enumeration options in the specified directory.
GetDirectories(String, String, SearchOption)	- Returns the names of the subdirectories (including their paths) that match the specified search pattern in the specified directory, and optionally searches subdirectories.
GetDirectories(String, String)	- Returns the names of subdirectories (including their paths) that match the specified search pattern in the specified directory.
GetDirectories(String)	- Returns the names of subdirectories (including their paths) in the specified directory.
GetDirectoryRoot(String)	- Returns the volume information, root information, or both for the specified path.
GetFiles(String, String, EnumerationOptions)	- Returns the names of files (including their paths) that match the specified search pattern and enumeration options in the specified directory.
GetFiles(String, String, SearchOption)	- Returns the names of files (including their paths) that match the specified search pattern in the specified directory, using a value to determine whether to search subdirectories.
GetFiles(String, String)	- Returns the names of files (including their paths) that match the specified search pattern in the specified directory.
GetFiles(String)	- Returns the names of files (including their paths) in the specified directory.
GetFileSystemEntries(String, String, EnumerationOptions)	- Returns an array of file names and directory names that match a search pattern and enumeration options in a specified path.
GetFileSystemEntries(String, String, SearchOption)	- Returns an array of all the file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
GetFileSystemEntries(String, String)	- Returns an array of file names and directory names that match a search pattern in a specified path.
GetFileSystemEntries(String)	- Returns the names of all files and subdirectories in a specified path.
GetLastAccessTime(String)	- Returns the date and time the specified file or directory was last accessed.
GetLastAccessTimeUtc(String)	- Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.
GetLastWriteTime(String)	- Returns the date and time the specified file or directory was last written to.
GetLastWriteTimeUtc(String)	- Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last written to.
GetLogicalDrives()	- Retrieves the names of the logical drives on this computer.
GetParent(String)	- Retrieves the parent directory of the specified path, including both absolute and relative paths.
Move(String, String)	- Moves a file or a directory and its contents to a new location.
ResolveLinkTarget(String, Boolean)	- Gets the target of the specified directory link.
SetCreationTime(String, DateTime)	- Sets the creation date and time for the specified file or directory.
SetCreationTimeUtc(String, DateTime)	- Sets the creation date and time, in Coordinated Universal Time (UTC) format, for the specified file or directory.
SetCurrentDirectory(String)	- Sets the application's current working directory to the specified directory.
SetLastAccessTime(String, DateTime)	- Sets the date and time the specified file or directory was last accessed.
SetLastAccessTimeUtc(String, DateTime)	- Sets the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.
SetLastWriteTime(String, DateTime)	- Sets the date and time a directory was last written to.
SetLastWriteTimeUtc(String, DateTime)	- Sets the date and time, in Coordinated Universal Time (UTC) format, that a directory was last written to.


**/
using System;
using System.IO;

namespace FileStreamIONamespace{
    class DirectoryClass{
        public static void Main(){
            Console.WriteLine("Directory Class");
        }
    }
}