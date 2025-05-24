/**
FileStream Class:
--------------------------

Provides a Stream for a file, supporting both synchronous and asynchronous read and write operations.
    public class FileStream : System.IO.Stream

Constructors:
-------------
FileStream(SafeFileHandle, FileAccess, Int32, Boolean)	- Initializes a new instance of the FileStream class for the specified file handle, with the specified read/write permission, buffer size, and synchronous or asynchronous state.
FileStream(SafeFileHandle, FileAccess, Int32)	- Initializes a new instance of the FileStream class for the specified file handle, with the specified read/write permission, and buffer size.
FileStream(SafeFileHandle, FileAccess)	- Initializes a new instance of the FileStream class for the specified file handle, with the specified read/write permission.
FileStream(String, FileMode, FileAccess, FileShare, Int32, Boolean)	- Initializes a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, buffer size, and synchronous or asynchronous state.
FileStream(String, FileMode, FileAccess, FileShare, Int32, FileOptions)	- Initializes a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, the access other FileStreams can have to the same file, the buffer size, and additional file options.
FileStream(String, FileMode, FileAccess, FileShare, Int32)	- Initializes a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, and buffer size.
FileStream(String, FileMode, FileAccess, FileShare)	- Initializes a new instance of the FileStream class with the specified path, creation mode, read/write permission, and sharing permission.
FileStream(String, FileMode, FileAccess)	- Initializes a new instance of the FileStream class with the specified path, creation mode, and read/write permission.
FileStream(String, FileMode)	- Initializes a new instance of the FileStream class with the specified path and creation mode.
FileStream(String, FileStreamOptions)	- Initializes a new instance of the FileStream class with the specified path, creation mode, read/write and sharing permission, buffer size, additional file options, preallocation size, and the access other FileStreams can have to the same file.
    public FileStream(string path, System.IO.FileMode mode);
    public FileStream(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, int bufferSize);


Properties:(All Properties from stream Class)
---------------
IsAsync	- Gets a value that indicates whether the FileStream was opened asynchronously or synchronously.
Length	- Gets the length in bytes of the stream.
Name	- Gets the absolute path of the file opened in the FileStream.

Method:
-------
Finalize()	- Ensures that resources are freed and other cleanup operations are performed when the garbage collector reclaims the FileStream.
Lock(Int64, Int64)	- Prevents other processes from reading from or writing to the FileStream.

Extension Methods:
------------------
GetAccessControl(FileStream)	- Returns the security information of a file.
SetAccessControl(FileStream, FileSecurity)	- Changes the security attributes of an existing file.
CopyToAsync(Stream, PipeWriter, CancellationToken)	- Asynchronously reads the bytes from the Stream and writes them to the specified PipeWriter, using a cancellation token.
ConfigureAwait(IAsyncDisposable, Boolean)	- Configures how awaits on the tasks returned from an async disposable will be performed.

**/
using System;
using System.IO;

namespace FileStreamIONamespace{
    class FileStreamClass{
        public static void Main(){
            Console.WriteLine("File Stream Class");
            string path = @"C:\Navaneethan\FileStreamPractice\file1.txt";
            byte[] data;
            if(File.Exists(path)){
                FileStream fs = new FileStream(path,FileMode.Open);
                Console.WriteLine(fs.Name);
                Console.WriteLine("CanRead :"+ fs.CanRead);
                data = new byte[fs.Length];
                int toRead = (int)fs.Length;
                int numRead = 0;
                while(toRead > 0){
                    int n = fs.Read(data,numRead,toRead);
                    if(n == 0) break;
                    numRead += n;
                    toRead -= n;
                }
                numRead = data.Length;
                for(int i = 0; i<data.Length; i++){
                    Console.Write(data[i]+',');
                }
                fs.Close();

                using(FileStream fsWrite = new FileStream(path,FileMode.Open,FileAccess.Write)){
                    fsWrite.Write(data,0,numRead);
                }
            }

            


            
        }
    }
}