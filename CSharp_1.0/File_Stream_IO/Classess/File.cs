/**
File Class:
-----------
Provides static methods for the creation, copying, deletion, moving, and opening of a single file, and aids in the creation of FileStream objects.

Remarks:
----------
Use the File class for typical operations such as copying, moving, renaming, creating, opening, deleting, and appending to a single file at a time. You can also use the File class to get and set file attributes or DateTime information related to the creation, access, and writing of a file. If you want to perform operations on multiple files, see Directory.GetFiles or DirectoryInfo.GetFiles.
Many of the File methods return other I/O types when you create or open files. You can use these other types to further manipulate a file. For more information, see specific File members such as OpenText, CreateText, or Create.
Because all File methods are static, if you want to perform only one action, it might be more efficient to use a File method than a corresponding FileInfo instance method. All File methods require the path to the file that you are manipulating.
The static methods of the File class perform security checks on all methods. If you are going to reuse an object several times, consider using the corresponding instance method of FileInfo instead, because the security check won't always be necessary.
By default, full read/write access to new files is granted to all users.
In members that accept a path as an input string, that path must be well-formed or an exception is raised. For example, if a path is fully qualified but begins with a space, the path is not trimmed in methods of the class. Therefore, the path is malformed and an exception is raised. Similarly, a path or a combination of paths cannot be fully qualified twice. For example, "c:\temp c:\windows" also raises an exception in most cases. Ensure that your paths are well-formed when using methods that accept a path string.
In members that accept a path, the path can refer to a file or just a directory. The specified path can also refer to a relative path or a Universal Naming Convention (UNC) path for a server and share name. For example, all the following are acceptable paths:
    "c:\\\MyDir\\\MyFile.txt" in C#, or "c:\MyDir\MyFile.txt" in Visual Basic.
    "c:\\\MyDir" in C#, or "c:\MyDir" in Visual Basic.
    "MyDir\\\MySubdir" in C#, or "MyDir\MySubDir" in Visual Basic.
    "\\\\\\\MyServer\\\MyShare" in C#, or "\\\MyServer\MyShare" in Visual Basic.

Methods:
----------
AppendAllBytes(String, Byte[])	- Appends the specified byte array to the end of the file at the given path.
                                    If the file doesn't exist, this method creates a new file.

AppendAllBytes(String, ReadOnlySpan<Byte>)	- Appends the specified byte array to the end of the file at the given path.
If the file doesn't exist, this method creates a new file.
AppendAllBytesAsync(String, Byte[], CancellationToken)	- Asynchronously appends the specified byte array to the end of the file at the given path.
If the file doesn't exist, this method creates a new file. If the operation is canceled, the task will return in a canceled state. 
AppendAllBytesAsync(String, ReadOnlyMemory<Byte>, CancellationToken)	- Asynchronously appends the specified byte array to the end of the file at the given path.
If the file doesn't exist, this method creates a new file. If the operation is canceled, the task will return in a canceled state.
AppendAllLines(String, IEnumerable<String>, Encoding)	- Appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
AppendAllLines(String, IEnumerable<String>)	- Appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
AppendAllLinesAsync(String, IEnumerable<String>, CancellationToken)	- Asynchronously appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
AppendAllLinesAsync(String, IEnumerable<String>, Encoding, CancellationToken)	- Asynchronously appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
AppendAllText(String, ReadOnlySpan<Char>, Encoding)	- Appends the specified string to the file, creating the file if it does not already exist.
AppendAllText(String, ReadOnlySpan<Char>)	- Appends the specified string to the file, creating the file if it does not already exist.
AppendAllText(String, String, Encoding)	- Appends the specified string to the file using the specified encoding, creating the file if it does not already exist.
AppendAllText(String, String)	- Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
AppendAllTextAsync(String, ReadOnlyMemory<Char>, CancellationToken)	- Asynchronously opens a file or creates a file if it does not already exist, appends the specified string to the file, and then closes the file.
AppendAllTextAsync(String, ReadOnlyMemory<Char>, Encoding, CancellationToken)	- Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the file using the specified encoding, and then closes the file.
AppendAllTextAsync(String, String, CancellationToken)	- Asynchronously opens a file or creates a file if it does not already exist, appends the specified string to the file, and then closes the file.
AppendAllTextAsync(String, String, Encoding, CancellationToken)	- Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the file using the specified encoding, and then closes the file.
AppendText(String)	- Creates a StreamWriter that appends UTF-8 encoded text to an existing file, or to a new file if the specified file does not exist.
    public static void AppendAllText(string path, string? contents);
    public static System.IO.StreamWriter AppendText(string path);

Copy(String, String, Boolean)	- Copies an existing file to a new file. Overwriting a file of the same name is allowed.
Copy(String, String)	- Copies an existing file to a new file. Overwriting a file of the same name is not allowed.

Create(String, Int32, FileOptions)	- Creates or overwrites a file in the specified path, specifying a buffer size and options that describe how to create or overwrite the file.
Create(String, Int32)	- Creates, or truncates and overwrites, a file in the specified path, specifying a buffer size.
Create(String)	- Creates, or truncates and overwrites, a file in the specified path.
    public static System.IO.FileStream Create(string path, int bufferSize);
    public static System.IO.FileStream Create(string path);

CreateSymbolicLink(String, String)	- Creates a file symbolic link identified by path that points to pathToTarget.
CreateText(String)	- Creates or opens a file for writing UTF-8 encoded text. If the file already exists, its contents are replaced.
    public static System.IO.StreamWriter CreateText(string path);

Decrypt(String)	- Decrypts a file that was encrypted by the current account using the Encrypt(String) method.
Delete(String)	- Deletes the specified file.
Encrypt(String)	- Encrypts a file so that only the account used to encrypt the file can decrypt it.
Exists(String)	- Determines whether the specified file exists
    
    public static bool Exists(string? path);

GetAttributes(SafeFileHandle)	- Gets the specified FileAttributes of the file or directory associated with fileHandle.
GetAttributes(String)	- Gets the FileAttributes of the file on the path.
GetCreationTime(SafeFileHandle)	- Returns the creation time of the specified file or directory.
GetCreationTime(String)	- Returns the creation date and time of the specified file or directory.
GetCreationTimeUtc(SafeFileHandle)	- Returns the creation date and time, in Coordinated Universal Time (UTC), of the specified file or directory.
GetCreationTimeUtc(String)	- Returns the creation date and time, in Coordinated Universal Time (UTC), of the specified file or directory.
GetLastAccessTime(SafeFileHandle)	- Returns the last access date and time of the specified file or directory.
GetLastAccessTime(String)	- Returns the date and time the specified file or directory was last accessed.
GetLastAccessTimeUtc(SafeFileHandle)	- Returns the last access date and time, in Coordinated Universal Time (UTC), of the specified file or directory.
GetLastAccessTimeUtc(String)	- Returns the date and time, in Coordinated Universal Time (UTC), that the specified file or directory was last accessed.
GetLastWriteTime(SafeFileHandle)	- Returns the last write date and time of the specified file or directory.
GetLastWriteTime(String)	- Returns the date and time the specified file or directory was last written to.
GetLastWriteTimeUtc(SafeFileHandle)	- Returns the last write date and time, in Coordinated Universal Time (UTC), of the specified file or directory.
GetLastWriteTimeUtc(String)	- Returns the date and time, in Coordinated Universal Time (UTC), that the specified file or directory was last written to.
GetUnixFileMode(SafeFileHandle)	- Gets the UnixFileMode of the specified file handle.
GetUnixFileMode(String)	- Gets the UnixFileMode of the file on the path.
    
Move(String, String, Boolean)	- Moves a specified file to a new location, providing the options to specify a new file name and to replace the destination file if it already exists.
Move(String, String)	- Moves a specified file to a new location, providing the option to specify a new file name.
    public static void Move(string sourceFileName, string destFileName, bool overwrite);
    public static void Move(string sourceFileName, string destFileName);

Open(String, FileMode, FileAccess, FileShare)	- Opens a FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.
Open(String, FileMode, FileAccess)	- Opens a FileStream on the specified path, with the specified mode and access with no sharing.
Open(String, FileMode)	- Opens a FileStream on the specified path with read/write access with no sharing.
Open(String, FileStreamOptions)	- Initializes a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, the access other FileStreams can have to the same file, the buffer size, additional file options and the allocation size.
    public static System.IO.FileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
    public static System.IO.FileStream Open(string path, System.IO.FileMode mode);

OpenHandle(String, FileMode, FileAccess, FileShare, FileOptions, Int64)	- Initializes a new instance of the SafeFileHandle class with the specified path, creation mode, read/write and sharing permission, the access other SafeFileHandles can have to the same file, additional file options and the allocation size.
OpenRead(String)	- Opens an existing file for reading.
    public static System.IO.FileStream OpenRead(string path);
OpenText(String)	- Opens an existing UTF-8 encoded text file for reading.
    public static System.IO.StreamReader OpenText(string path);

OpenWrite(String)	- Opens an existing file or creates a new file for writing.
    
    public static System.IO.FileStream OpenWrite(string path);

ReadAllBytes(String)	- Opens a binary file, reads the contents of the file into a byte array, and then closes the file.
ReadAllBytesAsync(String, CancellationToken)	- Asynchronously opens a binary file, reads the contents of the file into a byte array, and then closes the file.
ReadAllLines(String, Encoding)	- Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
ReadAllLines(String)	- Opens a text file, reads all lines of the file, and then closes the file.
ReadAllLinesAsync(String, CancellationToken)	- Asynchronously opens a text file, reads all lines of the file, and then closes the file.
ReadAllLinesAsync(String, Encoding, CancellationToken)	- Asynchronously opens a text file, reads all lines of the file with the specified encoding, and then closes the file.
ReadAllText(String, Encoding)	- Opens a file, reads all text in the file with the specified encoding, and then closes the file.
ReadAllText(String)	- Opens a text file, reads all the text in the file, and then closes the file.
ReadAllTextAsync(String, CancellationToken)	- Asynchronously opens a text file, reads all the text in the file, and then closes the file.
ReadAllTextAsync(String, Encoding, CancellationToken)	- Asynchronously opens a text file, reads all text in the file with the specified encoding, and then closes the file.
ReadLines(String, Encoding)	- Read the lines of a file that has a specified encoding.
ReadLines(String)	- Reads the lines of a file.
ReadLinesAsync(String, CancellationToken)	- Asynchronously reads the lines of a file.
ReadLinesAsync(String, Encoding, CancellationToken)	- Asynchronously reads the lines of a file that has a specified encoding.

Replace(String, String, String, Boolean)	- Replaces the contents of a specified file with the contents of another file, deleting the original file and creating a backup of the replaced file, and optionally ignores merge errors.
Replace(String, String, String)	- Replaces the contents of a specified file with the contents of another file, deleting the original file and creating a backup of the replaced file.
        public static void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName);

ResolveLinkTarget(String, Boolean)	- Gets the target of the specified file link.
SetAttributes(SafeFileHandle, FileAttributes)	- Sets the specified FileAttributes of the file or directory associated with fileHandle.
SetAttributes(String, FileAttributes)	- Sets the specified FileAttributes of the file on the specified path.
SetCreationTime(SafeFileHandle, DateTime)	- Sets the date and time the file or directory was created.
SetCreationTime(String, DateTime)	- Sets the date and time the file was created.
SetCreationTimeUtc(SafeFileHandle, DateTime)	- Sets the date and time, in Coordinated Universal Time (UTC), that the file or directory was created.
SetCreationTimeUtc(String, DateTime)	- Sets the date and time, in Coordinated Universal Time (UTC), that the file was created.
SetLastAccessTime(SafeFileHandle, DateTime)	- Sets the date and time the specified file or directory was last accessed.
SetLastAccessTime(String, DateTime)	- Sets the date and time the specified file was last accessed.-
SetLastAccessTimeUtc(SafeFileHandle, DateTime)	- Sets the date and time, in Coordinated Universal Time (UTC), that the specified file or directory was last accessed.
SetLastAccessTimeUtc(String, DateTime)	- Sets the date and time, in Coordinated Universal Time (UTC), that the specified file was last accessed.
SetLastWriteTime(SafeFileHandle, DateTime)	- Sets the date and time that the specified file or directory was last written to.
SetLastWriteTime(String, DateTime)	- sets the date and time that the specified file was last written to.
SetLastWriteTimeUtc(SafeFileHandle, DateTime)	- Sets the date and time, in Coordinated Universal Time (UTC), that the specified file or directory was last written to.
SetLastWriteTimeUtc(String, DateTime)	- Sets the date and time, in Coordinated Universal Time (UTC), that the specified file was last written to.
SetUnixFileMode(SafeFileHandle, UnixFileMode)	- Sets the specified UnixFileMode of the specified file handle.
SetUnixFileMode(String, UnixFileMode)	- Sets the specified UnixFileMode of the file on the specified path.
WriteAllBytes(String, Byte[])	- Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is truncated and overwritten.
WriteAllBytes(String, ReadOnlySpan<Byte>)	 - Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is truncated and overwritten.
WriteAllBytesAsync(String, Byte[], CancellationToken)	- Asynchronously creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is truncated and overwritten.
WriteAllBytesAsync(String, ReadOnlyMemory<Byte>, CancellationToken)	- Asynchronously creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is truncated and overwritten.
WriteAllLines(String, IEnumerable<String>, Encoding)	- Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.
WriteAllLines(String, IEnumerable<String>)	- Creates a new file, writes a collection of strings to the file, and then closes the file.
WriteAllLines(String, String[], Encoding)	- Creates a new file, writes the specified string array to the file by using the specified encoding, and then closes the file.
WriteAllLines(String, String[])	- Creates a new file, write the specified string array to the file, and then closes the file. 
WriteAllLinesAsync(String, IEnumerable<String>, CancellationToken)	- Asynchronously creates a new file, writes the specified lines to the file, and then closes the file.
WriteAllLinesAsync(String, IEnumerable<String>, Encoding, CancellationToken)	- Asynchronously creates a new file, write the specified lines to the file by using the specified encoding, and then closes the file.
WriteAllText(String, ReadOnlySpan<Char>, Encoding)	- Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file.
If the target file already exists, it is truncated and overwritten.
WriteAllText(String, ReadOnlySpan<Char>)	- Creates a new file, writes the specified string to the file, and then closes the file.
If the target file already exists, it is truncated and overwritten.
WriteAllText(String, String, Encoding)	- Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is truncated and overwritten.
WriteAllText(String, String)	- Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is truncated and overwritten.
WriteAllTextAsync(String, ReadOnlyMemory<Char>, CancellationToken)	- Asynchronously creates a new file, writes the specified string to the file, and then closes the file.
If the target file already exists, it is truncated and overwritten.
WriteAllTextAsync(String, ReadOnlyMemory<Char>, Encoding, CancellationToken)	- Asynchronously creates a new file, writes the specified string to the file using the specified encoding, and then closes the file.
If the target file already exists, it is truncated and overwritten.
WriteAllTextAsync(String, String, CancellationToken)	- Asynchronously creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is truncated and overwritten.
WriteAllTextAsync(String, String, Encoding, CancellationToken)	- Asynchronously creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is truncated and overwritten.
    public static void WriteAllLines(string path, string[] contents);
    public static void WriteAllLines(string path, string[] contents, System.Text.Encoding encoding);


**/
using System;
using System.IO;
using System.Text;

namespace FileStreamIONamespace{
    class FileClass{
        public static void Main(){
            Console.WriteLine("File Class");
            string path = @"C:\Navaneethan\FileStreamPractice\file1.txt";
            if(File.Exists(path)){
                FileStream fs = File.Open(path,FileMode.Open,FileAccess.ReadWrite);
                Console.WriteLine("CanWrite :"+fs.CanWrite);
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                fs.Write(info,0,info.Length);
                fs.Close();
            }
            //Open and Read the Written text
            using(FileStream fs = File.Open(path,FileMode.Open,FileAccess.Read)){
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b,0,b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }

            string[] sArray  = ["Second","Word","Add","in","File"];
            File.WriteAllLines(path,sArray);
            File.WriteAllText(path,"third Word");

            //OpenText Method
            using(StreamReader sr = File.OpenText(path)){
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

            Console.WriteLine("GetLastWriteTimeUtc :"+File.GetLastWriteTimeUtc(path));
            Console.WriteLine("GetLastAccessTimeUtc : "+ File.GetLastAccessTimeUtc(path));
            Console.WriteLine("GetCreationTimeUtc : "+ File.GetCreationTimeUtc(path));

            //CreateWrite Mode 
            using(StreamWriter sw = File.CreateText(path)){
                sw.WriteLine("Hellow");
                sw.WriteLine("World !");
                sw.WriteLine("Come Tomowwor");

                sw.WriteLine("Welcome");
            }

            using(FileStream f = File.Create(@"C:\Navaneethan\FileStreamPractice\temp1.txt")){
                Encoding utf8Text = new UTF8Encoding(true);
                string text = "Hello World!";
                byte[] data = utf8Text.GetBytes(text);
                f.Write(data,0,data.Length);
            }

            
        }
    }
}