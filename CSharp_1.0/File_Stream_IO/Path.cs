/**
Members of many of the types in the System.IO namespace include a path parameter that lets you specify an absolute or relative path to a file system resource. This path is then passed to Windows file system APIs. 

Traditional DOS paths:
---------------------
A standard DOS path can consist of three components:
    A volume or drive letter followed by the volume separator (:).
    A directory name. The directory separator character separates subdirectories within the nested directory hierarchy.
    An optional filename. The directory separator character separates the file path and the filename.

If all three components are present, the path is absolute. If no volume or drive letter is specified and the directory name begins with the directory separator character, the path is relative from the root of the current drive. Otherwise, the path is relative to the current directory. 
The following table shows some possible directory and file paths.

Path	Description
C:\Documents\Newsletters\Summer2018.pdf	An absolute file path from the root of drive C:.
\Program Files\Custom Utilities\StringFinder.exe	A relative path from the root of the current drive.
2018\January.xlsx	A relative path to a file in a subdirectory of the current directory.
..\Publications\TravelBrochure.pdf	A relative path to a file in a directory starting from the current directory.
C:\Projects\apilibrary\apilibrary.sln	An absolute path to a file from the root of drive C:.
C:Projects\apilibrary\apilibrary.sln	A relative path from the current directory of the C: drive.

Note the difference between the last two paths. Both specify the optional volume specifier (C: in both cases), but the first begins with the root of the specified volume, whereas the second does not. As result, the first is an absolute path from the root directory of drive C:, whereas the second is a relative path from the current directory of drive C:. Use of the second form when the first is intended is a common source of bugs that involve Windows file paths.

You can determine whether a file path is fully qualified (that is, if the path is independent of the current directory and does not change when the current directory changes) by calling the Path.IsPathFullyQualified method. Note that such a path can include relative directory segments (. and ..) and still be fully qualified if the resolved path always points to the same location.

UNC paths:
------------
Universal naming convention (UNC) paths, which are used to access network resources, have the following format:

A server or host name, which is prefaced by \\. The server name can be a NetBIOS machine name or an IP/FQDN address (IPv4 as well as v6 are supported).
A share name, which is separated from the host name by \. Together, the server and share name make up the volume.
A directory name. The directory separator character separates subdirectories within the nested directory hierarchy.
An optional filename. The directory separator character separates the file path and the filename.

DOS device paths:
-----------------
The Windows operating system has a unified object model that points to all resources, including files. These object paths are accessible from the console window and are exposed to the Win32 layer through a special folder of symbolic links that legacy DOS and UNC paths are mapped to. This special folder is accessed via the DOS device path syntax, which is one of:

\\.\C:\Test\Foo.txt \\?\C:\Test\Foo.txt

In addition to identifying a drive by its drive letter, you can identify a volume by using its volume GUID. This takes the form:

\\.\Volume{b75e2c83-0000-0000-0000-602f00000000}\Test\Foo.txt \\?\Volume{b75e2c83-0000-0000-0000-602f00000000}\Test\Foo.txt


Path normalization:
--------------------
Almost all paths passed to Windows APIs are normalized. During normalization, Windows performs the following steps:

    Identifies the path.
    Applies the current directory to partially qualified (relative) paths.
    Canonicalizes component and directory separators.
    Evaluates relative directory components (. for the current directory and .. for the parent directory).
    Trims certain characters.
    This normalization happens implicitly, but you can do it explicitly by calling the Path.GetFullPath method, which wraps a call to the GetFullPathName() function. You can also call the Windows GetFullPathName() function directly using P/Invoke.


**/
using System;
using System.IO;

namespace FileStreamIONamespace{
    class FileStreamIOPath{
        public static void Main(){
            Console.WriteLine("File and Stream IO Path.");
        }
    }
}