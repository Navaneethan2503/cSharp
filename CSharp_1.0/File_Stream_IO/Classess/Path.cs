/**
Path Class:
------------
Performs operations on String instances that contain file or directory path information. These operations are performed in a cross-platform manner.

    public static class Path

Remarks:
--------
A path is a string that provides the location of a file or directory. A path does not necessarily point to a location on disk; for example, a path might map to a location in memory or on a device. The exact format of a path is determined by the current platform. For example, on some systems, a path can start with a drive or volume letter, while this element is not present in other systems. On some systems, file paths can contain extensions, which indicate the type of information stored in the file. The format of a file name extension is platform-dependent; for example, some systems limit extensions to three characters (such as FAT16 commonly used on smaller flash storage and older versions of ISO 9660 used on optical media), and others do not. The current platform also determines the set of characters used to separate the elements of a path, and the set of characters that cannot be used when specifying paths. Because of these differences, the fields of the Path class as well as the exact behavior of some members of the Path class are platform-dependent.
A path can contain absolute or relative location information. Absolute paths fully specify a location: the file or directory can be uniquely identified regardless of the current location. Relative paths specify a partial location: the current location is used as the starting point when locating a file specified with a relative path. To determine the current directory, call Directory.GetCurrentDirectory
.NET Core 1.1 and later versions and .NET Framework 4.6.2 and later versions also support access to file system objects that are device names, such as "\?\C:\".
For more information on file path formats on Windows, see File path formats on Windows systems.
Most members of the Path class do not interact with the file system and do not verify the existence of the file specified by a path string. Path class members that modify a path string, such as ChangeExtension, have no effect on names of files in the file system.
Some Path members do validate the contents of a specified path string, and throw an ArgumentException if the string contains characters that are not valid in path strings, as defined in the characters returned from the GetInvalidPathChars method. For example, on Windows-based desktop platforms, invalid path characters might include quote ("), less than (<), greater than (>), pipe (|), backspace (\b), null (\0), and Unicode characters 16 through 18 and 20 through 25. This validation behavior varies between .NET versions:
On .NET Framework and .NET Core versions older than 2.1: All Path members that take a path as an argument throw an ArgumentException if they detect invalid path characters.
On .NET Core 2.1 and later versions: GetFullPath is the only member that throws an ArgumentException if the string contains invalid path characters.
The members of the Path class enable you to quickly and easily perform common operations such as determining whether a file name extension is part of a path, and combining two strings into one path name.
All members of the Path class are static and can therefore be called without having an instance of a path.

In members that accept a path as an input string, that path must be well-formed or an exception is raised. For example, if a path is fully qualified but begins with a space, the path is not trimmed in methods of the class. Therefore, the path is malformed and an exception is raised. Similarly, a path or a combination of paths cannot be fully qualified twice. For example, "c:\temp c:\windows" also raises an exception in most cases. Ensure that your paths are well-formed when using methods that accept a path string.

In members that accept a path, the path can refer to a file or just a directory. The specified path can also refer to a relative path or a Universal Naming Convention (UNC) path for a server and share name. For example, all the following are acceptable paths:

"c:\MyDir\MyFile.txt" in C#, or "c:\MyDir\MyFile.txt" in Visual Basic.

"c:\MyDir" in C#, or "c:\MyDir" in Visual Basic.

"MyDir\MySubdir" in C#, or "MyDir\MySubDir" in Visual Basic.

"\\MyServer\MyShare" in C#, or "\MyServer\MyShare" in Visual Basic.

Because all these operations are performed on strings, it is impossible to verify that the results are valid in all scenarios. For example, the GetExtension method parses a string that you pass to it and returns the extension from that string. However, this does not mean that a file with that extension exists on the disk.


Fields:
--------
AltDirectorySeparatorChar	- Provides a platform-specific alternate character used to separate directory levels in a path string that reflects a hierarchical file system organization.
DirectorySeparatorChar	- Provides a platform-specific character used to separate directory levels in a path string that reflects a hierarchical file system organization.
PathSeparator	- A platform-specific separator character used to separate path strings in environment variables.
VolumeSeparatorChar	 - Provides a platform

Methods:
---------
ChangeExtension(String, String)	- Changes the extension of a path string.
Combine(ReadOnlySpan<String>)	- Combines a span of strings into a path.
Combine(String, String, String, String)	- Combines four strings into a path.
Combine(String, String, String)	- Combines three strings into a path.
Combine(String, String)	- Combines two strings into a path.
Combine(String[])	- Combines an array of strings into a path.
EndsInDirectorySeparator(ReadOnlySpan<Char>)	- Returns a value that indicates whether the path, specified as a read-only span, ends in a directory separator.
EndsInDirectorySeparator(String)	- Returns a value that indicates whether the specified path ends in a directory separator.
Exists(String)	- Determines whether the specified file or directory exists.
    public static bool Exists(string? path);

GetDirectoryName(ReadOnlySpan<Char>)	- Returns the directory information for the specified path represented by a character span.
GetDirectoryName(String)	- Returns the directory information for the specified path.
    public static string? GetDirectoryName(string? path);

GetExtension(ReadOnlySpan<Char>)	- Returns the extension of a file path that is represented by a read-only character span.
GetExtension(String)	- Returns the extension (including the period ".") of the specified path string.
GetFileName(ReadOnlySpan<Char>)	- Returns the file name and extension of a file path that is represented by a read-only character span.
GetFileName(String)	- Returns the file name and extension of the specified path string.
GetFileNameWithoutExtension(ReadOnlySpan<Char>)	- Returns the file name without the extension of a file path that is represented by a read-only character span.
GetFileNameWithoutExtension(String)	- Returns the file name of the specified path string without the extension.
GetFullPath(String, String)	- Returns an absolute path from a relative path and a fully qualified base path.
GetFullPath(String)	- Returns the absolute path for the specified path string.
GetInvalidFileNameChars()	- Gets an array containing the characters that are not allowed in file names.
GetInvalidPathChars()	- Gets an array containing the characters that are not allowed in path names.
GetPathRoot(ReadOnlySpan<Char>)	 - ets the root directory information from the path contained in the specified character span.
GetPathRoot(String)	- Gets the root directory information from the path contained in the specified string.
GetRandomFileName()	- Returns a random folder name or file name.
GetRelativePath(String, String)	- Returns a relative path from one path to another.

GetTempFileName()	- Creates a uniquely named, zero-byte temporary file on disk and returns the full path of that file.
GetTempPath()	- Returns the path of the current user's temporary folder.
HasExtension(ReadOnlySpan<Char>)	- Determines whether the path represented by the specified character span includes a file name extension.
HasExtension(String)	- Determines whether a path includes a file name extension.

IsPathFullyQualified(ReadOnlySpan<Char>)	- Returns a value that indicates whether the file path represented by the specified character span is fixed to a specific drive or UNC path.
IsPathFullyQualified(String)	- Returns a value that indicates whether the specified file path is fixed to a specific drive or UNC path.
IsPathRooted(ReadOnlySpan<Char>)	- Returns a value that indicates whether the specified character span that represents a file path contains a root.
IsPathRooted(String)	- Returns a value indicating whether the specified path string contains a root.
Join(ReadOnlySpan<Char>, ReadOnlySpan<Char>, ReadOnlySpan<Char>, ReadOnlySpan<Char>)	- Concatenates four path components into a single path.
Join(ReadOnlySpan<Char>, ReadOnlySpan<Char>, ReadOnlySpan<Char>)	- Concatenates three path components into a single path.
Join(ReadOnlySpan<Char>, ReadOnlySpan<Char>)	- Concatenates two path components into a single path.
Join(ReadOnlySpan<String>)	- Concatenates a span of paths into a single path.
Join(String, String, String, String)	- Concatenates four paths into a single path.
Join(String, String, String)	- Concatenates three paths into a single path.
Join(String, String)	- Concatenates two paths into a single path.
Join(String[])	- Concatenates an array of paths into a single path.
TrimEndingDirectorySeparator(ReadOnlySpan<Char>)	- Trims one trailing directory separator beyond the root of the specified path.
TrimEndingDirectorySeparator(String)	- Trims one trailing directory separator beyond the root of the specified path.
TryJoin(ReadOnlySpan<Char>, ReadOnlySpan<Char>, ReadOnlySpan<Char>, Span<Char>, Int32)	- Attempts to concatenate three path components to a single preallocated character span, and returns a value that indicates whether the operation succeeded.
TryJoin(ReadOnlySpan<Char>, ReadOnlySpan<Char>, Span<Char>, Int32)	- Attempts to concatenate two path components to a single preallocated character span, and returns a value that indicates whether the operation succeeded.


**/
using System;
using System.IO;

namespace FileStreamIONamespace{
    class PathClass{
        public static void Main(){
            Console.WriteLine("Path Class");
            Console.WriteLine("Path.AltDirectorySeparatorChar={0}",
                Path.AltDirectorySeparatorChar);
            Console.WriteLine("Path.DirectorySeparatorChar={0}",
                Path.DirectorySeparatorChar);
            Console.WriteLine("Path.PathSeparator={0}",
                Path.PathSeparator);
            Console.WriteLine("Path.VolumeSeparatorChar={0}",
                Path.VolumeSeparatorChar);

            Console.Write("Path.GetInvalidPathChars()=");
            foreach (char c in Path.GetInvalidPathChars())
                Console.Write(c);
            Console.WriteLine();

            string path1 = @"d:\archives\";
            string path2 = "2001";
            string path3 = "media";
            string path4 = "images";
            string combinedPath = Path.Combine(path1, path2, path3, path4);
            Console.WriteLine("Combined Path : "+combinedPath);

            string file1Path = @"C:\Navaneethan\FileStreamPractice";
            Console.WriteLine("Check IsExist :"+Path.Exists(file1Path));
            Console.WriteLine("Directory Name :"+ Path.GetDirectoryName(file1Path));
            Console.WriteLine("Create Temp File and Return Path : "+ Path.GetTempFileName());

            Console.WriteLine("Full Path IS : "+Path.GetFullPath(@"\Navaneethan\FileStreamPractice"));
        }
    }
}