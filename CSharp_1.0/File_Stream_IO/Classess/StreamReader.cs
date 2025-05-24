/**
StreamReader Class:
-------------------
Implements a TextReader that reads characters from a byte stream in a particular encoding.

public class StreamReader : System.IO.TextReader


Remarks:
-------------
StreamReader is designed for character input in a particular encoding, whereas the Stream class is designed for byte input and output. Use StreamReader for reading lines of information from a standard text file.
This type implements the IDisposable interface. When you have finished using the type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its Dispose method in a try/catch block. To dispose of it indirectly, use a language construct such as using (in C#) or Using (in Visual Basic).

StreamReader defaults to UTF-8 encoding unless specified otherwise, instead of defaulting to the ANSI code page for the current system. UTF-8 handles Unicode characters correctly and provides consistent results on localized versions of the operating system. If you get the current character encoding using the CurrentEncoding property, the value is not reliable until after the first Read method, since encoding auto detection is not done until the first call to a Read method.

By default, a StreamReader is not thread safe. See TextReader.Synchronized for a thread-safe wrapper.

The Read(Char[], Int32, Int32) and Write(Char[], Int32, Int32) method overloads read and write the number of characters specified by the count parameter. These are to be distinguished from BufferedStream.Read and BufferedStream.Write, which read and write the number of bytes specified by the count parameter. Use the BufferedStream methods only for reading and writing an integral number of byte array elements.


Constructors:
---------------
StreamReader(Stream, Boolean) - Initializes a new instance of the StreamReader class for the specified stream, with the specified byte order mark detection option.
StreamReader(Stream, Encoding, Boolean, Int32, Boolean)	- Initializes a new instance of the StreamReader class for the specified stream based on the specified character encoding, byte order mark detection option, and buffer size, and optionally leaves the stream open.
StreamReader(Stream, Encoding, Boolean, Int32)	- Initializes a new instance of the StreamReader class for the specified stream, with the specified character encoding, byte order mark detection option, and buffer size.
StreamReader(Stream, Encoding, Boolean)	- Initializes a new instance of the StreamReader class for the specified stream, with the specified character encoding and byte order mark detection option.
StreamReader(Stream, Encoding)	- Initializes a new instance of the StreamReader class for the specified stream, with the specified character encoding.
StreamReader(Stream)	- Initializes a new instance of the StreamReader class for the specified stream.
StreamReader(String, Boolean)	- Initializes a new instance of the StreamReader class for the specified file name, with the specified byte order mark detection option.
StreamReader(String, Encoding, Boolean, FileStreamOptions)	- Initializes a new instance of the StreamReader class for the specified file path, with the specified character encoding, byte order mark detection option, and configured with the specified FileStreamOptions object.
StreamReader(String, Encoding, Boolean, Int32)- Initializes a new instance of the StreamReader class for the specified file name, with the specified character encoding, byte order mark detection option, and buffer size.
StreamReader(String, Encoding, Boolean)	- Initializes a new instance of the StreamReader class for the specified file name, with the specified character encoding and byte order mark detection option.
StreamReader(String, Encoding)	- Initializes a new instance of the StreamReader class for the specified file name, with the specified character encoding.
StreamReader(String, FileStreamOptions)	- Initializes a new instance of the StreamReader class for the specified file path, using the default encoding, enabling detection of byte order marks at the beginning of the file, and configured with the specified FileStreamOptions object.
StreamReader(String)	- Initializes a new instance of the StreamReader class for the specified file name.

    public StreamReader(string path, System.Text.Encoding encoding);
    public StreamReader(System.IO.Stream stream);
    public StreamReader(System.IO.Stream stream, System.Text.Encoding? encoding = default, bool detectEncodingFromByteOrderMarks = true, int bufferSize = -1, bool leaveOpen = false);
    public StreamReader(string path, System.Text.Encoding encoding, bool detectEncodingFromByteOrderMarks, System.IO.FileStreamOptions options);


Fields:
-------
Null	- A StreamReader object around an empty stream.

Properties:
-----------
BaseStream	- Returns the underlying stream.
    public virtual System.IO.Stream BaseStream { get; }
CurrentEncoding	- Gets the current character encoding that the current StreamReader object is using.
EndOfStream	- Gets a value that indicates whether the current stream position is at the end of the stream.

Methods: AllDerived from TextReader Class 
-------

**/

using System;
using System.IO;

namespace FileStreamIONamespace{
    class StreamReaderClass
    {
        public static void Main()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}