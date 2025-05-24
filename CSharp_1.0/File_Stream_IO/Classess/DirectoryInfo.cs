/**
 DirectoryInfo Class :
 ---------------------
 Exposes instance methods for creating, moving, and enumerating through directories and subdirectories. This class cannot be inherited.

public sealed class DirectoryInfo : System.IO.FileSystemInfo

Remarks
Use the DirectoryInfo class for typical operations such as copying, moving, renaming, creating, and deleting directories.

If you are going to reuse an object several times, consider using the instance method of DirectoryInfo instead of the corresponding static methods of the Directory class, because a security check will not always be necessary.

 Note

In members that accept a path as an input string, that path must be well-formed or an exception is raised. For example, if a path is fully qualified but begins with a space, the path is not trimmed in methods of the class. Therefore, the path is malformed and an exception is raised. Similarly, a path or a combination of paths cannot be fully qualified twice. For example, "c:\temp c:\windows" also raises an exception in most cases. Ensure that your paths are well-formed when using methods that accept a path string.

In members that accept a path, the path can refer to a file or just a directory. The specified path can also refer to a relative path or a Universal Naming Convention (UNC) path for a server and share name. For example, all the following are acceptable paths:

"c:\MyDir\MyFile.txt" in C#, or "c:\MyDir\MyFile.txt" in Visual Basic.

"c:\MyDir" in C#, or "c:\MyDir" in Visual Basic.

"MyDir\MySubdir" in C#, or "MyDir\MySubDir" in Visual Basic.

"\\MyServer\MyShare" in C#, or "\MyServer\MyShare" in Visual Basic.

Constructors:
--------------
DirectoryInfo(String)	- Initializes a new instance of the DirectoryInfo class on the specified path.

Properties:(All methods from Dervied Class FileSystemInfo)
-------
Parent	- Gets the parent directory of a specified subdirectory.
Root	- Gets the root portion of the directory.


MEthods:
----------
Create()	- Creates a directory.
CreateSubdirectory(String)	- Creates a subdirectory or subdirectories on the specified path. The specified path can be relative to this instance of the DirectoryInfo class.
    public System.IO.DirectoryInfo CreateSubdirectory(string path);

Delete()	- Deletes this DirectoryInfo if it is empty.
    public override void Delete();

Delete(Boolean)	- Deletes this instance of a DirectoryInfo, specifying whether to delete subdirectories and files.
    public void Delete(bool recursive);

EnumerateDirectories()	- Returns an enumerable collection of directory information in the current directory.
EnumerateDirectories(String, EnumerationOptions)	- Returns an enumerable collection of directory information that matches the specified search pattern and enumeration options.
EnumerateDirectories(String, SearchOption)	- Returns an enumerable collection of directory information that matches a specified search pattern and search subdirectory option.
EnumerateDirectories(String)	- Returns an enumerable collection of directory information that matches a specified search pattern.
    public System.Collections.Generic.IEnumerable<System.IO.DirectoryInfo> EnumerateDirectories(); 
    public System.Collections.Generic.IEnumerable<System.IO.DirectoryInfo> EnumerateDirectories(string searchPattern, System.IO.EnumerationOptions enumerationOptions);

EnumerateFiles()	- Returns an enumerable collection of file information in the current directory.
EnumerateFiles(String, EnumerationOptions)	- Returns an enumerable collection of file information that matches the specified search pattern and enumeration options.
EnumerateFiles(String, SearchOption)	- Returns an enumerable collection of file information that matches a specified search pattern and search subdirectory option.
EnumerateFiles(String)	- Returns an enumerable collection of file information that matches a search pattern.
    public System.Collections.Generic.IEnumerable<System.IO.FileInfo> EnumerateFiles(); 
    public System.Collections.Generic.IEnumerable<System.IO.FileInfo> EnumerateFiles(string searchPattern);

EnumerateFileSystemInfos()	- Returns an enumerable collection of file system information in the current directory.
EnumerateFileSystemInfos(String, EnumerationOptions)	- Returns an enumerable collection of file system information that matches the specified search pattern and enumeration options.
EnumerateFileSystemInfos(String, SearchOption)	- Returns an enumerable collection of file system information that matches a specified search pattern and search subdirectory option.
EnumerateFileSystemInfos(String)	- Returns an enumerable collection of file system information that matches a specified search pattern.
    public System.Collections.Generic.IEnumerable<System.IO.FileSystemInfo> EnumerateFileSystemInfos(); 

GetDirectories()	- Returns the subdirectories of the current directory.
GetDirectories(String, EnumerationOptions)	 - Returns an array of directories in the current DirectoryInfo matching the specified search pattern and enumeration options.
GetDirectories(String, SearchOption)	- Returns an array of directories in the current DirectoryInfo matching the given search criteria and using a value to determine whether to search subdirectories.
GetDirectories(String)	- Returns an array of directories in the current DirectoryInfo matching the given search criteria.
    public System.IO.DirectoryInfo[] GetDirectories(); 

GetFiles()	- Returns a file list from the current directory.
GetFiles(String, EnumerationOptions)	- Returns a file list from the current directory matching the specified search pattern and enumeration options.
GetFiles(String, SearchOption)	- Returns a file list from the current directory matching the given search pattern and using a value to determine whether to search subdirectories.
GetFiles(String)	- Returns a file list from the current directory matching the given search pattern.
    public System.IO.FileInfo[] GetFiles(); 
    
GetFileSystemInfos()	- Returns an array of strongly typed FileSystemInfo entries representing all the files and subdirectories in a directory.
GetFileSystemInfos(String, EnumerationOptions)	- Retrieves an array of strongly typed FileSystemInfo objects representing the files and subdirectories that match the specified search pattern and enumeration options.
GetFileSystemInfos(String, SearchOption)	- Retrieves an array of FileSystemInfo objects that represent the files and subdirectories matching the specified search criteria.
GetFileSystemInfos(String)	- Retrieves an array of strongly typed FileSystemInfo objects representing the files and subdirectories that match the specified search criteria.
MoveTo(String)	- Moves a DirectoryInfo instance and its contents to a new path.


Extension Methods:
------------------
Create(DirectoryInfo, DirectorySecurity)	- Creates a new directory, ensuring it is created with the specified directory security. If the directory already exists, nothing is done.
GetAccessControl(DirectoryInfo, AccessControlSections)	- Returns the security information of a directory.
GetAccessControl(DirectoryInfo)	- Returns the security information of a directory.
SetAccessControl(DirectoryInfo, DirectorySecurity)	- Changes the security attributes of an existing directory.

**/
using System;
using System.IO;

namespace FileStreamIONamespace{
    class DirectoryInfoClass{
        public static void Main(){
            Console.WriteLine("DirectoryInfo Class");
            string path = @"C:\Navaneethan\FileStreamPractice\Direct1";
            DirectoryInfo dInfo = new DirectoryInfo(path);
            if(!dInfo.Exists)
                dInfo.Create();

            using(StreamWriter sw = File.CreateText(@"C:\Navaneethan\FileStreamPractice\Direct1\DomainText.txt")){
                sw.WriteLine("Hello From Domain");
            }
            
            DirectoryInfo sub = dInfo.CreateSubdirectory("SubDomain");
            DirectoryInfo sub1 = dInfo.CreateSubdirectory("SubTotalDomain");
            using(StreamWriter sw = File.CreateText(@"C:\Navaneethan\FileStreamPractice\Direct1\SubTotalDomain\SubTotalDomainText.txt")){
                sw.WriteLine("Hello");
            }
            //dInfo.Delete();//If Empty it will delete
            Console.WriteLine("Attributes : "+dInfo.Attributes);//If not Exist -1 returns if exists then nature of its type
            Console.WriteLine("Root : "+dInfo.Root);

            Console.WriteLine("Directory Enumeration : ");
            foreach(var d in dInfo.EnumerateDirectories()){
                Console.WriteLine(d.Name);
            }

            Console.WriteLine("Dicrectory File System :");
            foreach(FileSystemInfo f in dInfo.EnumerateFileSystemInfos()){
                Console.WriteLine("Folder : "+ f.Name);
            }
        }
    }
}