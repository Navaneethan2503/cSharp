/**

IsolatedStorageFile Class:
--------------------------
Represents an isolated storage area containing files and directories.

public sealed class IsolatedStorageFile : System.IO.IsolatedStorage.IsolatedStorage, IDisposable

Remarks:
----------
This object corresponds to a specific isolated storage scope, where files represented by IsolatedStorageFileStream objects exist. Applications can use isolated storage to save data in their own isolated portion of the file system, without having to specify a particular path within the file system. Since isolated stores are scoped to particular assemblies, most other managed code will not be able to access your code's data (highly trusted managed code and administration tools can access stores from other assemblies). Unmanaged code can access any isolated stores.

This type implements the IDisposable interface. When you have finished using the type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its Dispose method in a try/catch block. To dispose of it indirectly, use a language construct such as using (in C#) or Using (in Visual Basic). For more information, see the "Using an Object that Implements IDisposable" section in the IDisposable interface topic.


Properties:
-------------
IsEnabled	- Gets a value that indicates whether isolated storage is enabled.

Methods:
---------
Close()	- Closes a store previously opened with GetStore(IsolatedStorageScope, Type, Type), GetUserStoreForAssembly(), or GetUserStoreForDomain().
CopyFile(String, String, Boolean)	- Copies an existing file to a new file, and optionally overwrites an existing file.
CopyFile(String, String)	- Copies an existing file to a new file.
    public void CopyFile(string sourceFileName, string destinationFileName);
    
CreateDirectory(String)	- Creates a directory in the isolated storage scope.
    public void CreateDirectory(string dir);

CreateFile(String)	- Creates a file in the isolated store.
    public System.IO.IsolatedStorage.IsolatedStorageFileStream CreateFile(string path);

DeleteDirectory(String)	- Deletes a directory in the isolated storage scope.
    public void DeleteDirectory(string dir);

DeleteFile(String)	- Deletes a file in the isolated storage scope.
DirectoryExists(String)	- Determines whether the specified path refers to an existing directory in the isolated store.
Dispose()	- Releases all resources used by the IsolatedStorageFile.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
FileExists(String)	- Determines whether the specified path refers to an existing file in the isolated store.
GetCreationTime(String)	- Returns the creation date and time of a specified file or directory.
GetDirectoryNames()	- Enumerates the directories at the root of an isolated store.
GetDirectoryNames(String)	- Enumerates the directories in an isolated storage scope that match a given search pattern.
GetEnumerator(IsolatedStorageScope)	- Gets the enumerator for the IsolatedStorageFile stores within an isolated storage scope.
GetFileNames()	- Enumerates the file names at the root of an isolated store.
GetFileNames(String)  - Gets the file names that match a search pattern.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetLastAccessTime(String)	- Returns the date and time a specified file or directory was last accessed.
GetLastWriteTime(String)	- Returns the date and time a specified file or directory was last written to.
GetMachineStoreForApplication()	- Obtains machine-scoped isolated storage corresponding to the calling code's application identity.
    public static System.IO.IsolatedStorage.IsolatedStorageFile GetMachineStoreForApplication();

GetMachineStoreForAssembly()	- Obtains machine-scoped isolated storage corresponding to the calling code's assembly identity.
GetMachineStoreForDomain()	- Obtains machine-scoped isolated storage corresponding to the application domain identity and the assembly identity.
    public static System.IO.IsolatedStorage.IsolatedStorageFile GetMachineStoreForDomain();

GetStore(IsolatedStorageScope, Object, Object)	- Obtains the isolated storage corresponding to the given application domain and assembly evidence objects.
    public static System.IO.IsolatedStorage.IsolatedStorageFile GetStore(System.IO.IsolatedStorage.IsolatedStorageScope scope, Type? applicationEvidenceType);

GetStore(IsolatedStorageScope, Object)	- Obtains isolated storage corresponding to the given application identity.
GetStore(IsolatedStorageScope, Type, Type)	 - Obtains isolated storage corresponding to the isolated storage scope given the application domain and assembly evidence types.
GetStore(IsolatedStorageScope, Type)	- Obtains isolated storage corresponding to the isolation scope and the application identity object.
GetType()	- Gets the ype of the current instance.(Inherited from Object)
GetUserStoreForApplication()	 - Obtains user-scoped isolated storage corresponding to the calling code's application identity.
GetUserStoreForAssembly()	- Obtains user-scoped isolated storage corresponding to the calling code's assembly identity.
GetUserStoreForDomain()	- Obtains user-scoped isolated storage corresponding to the application domain identity and assembly identity.
GetUserStoreForSite()	 - Obtains a user-scoped isolated store for use by applications in a virtual host domain.
IncreaseQuotaTo(Int64)	- Enables an application to explicitly request a larger quota size, in bytes.
InitStore(IsolatedStorageScope, Type, Type)	- Initializes a new IsolatedStorage object.(Inherited from IsolatedStorage)
InitStore(IsolatedStorageScope, Type)	- Initializes a new IsolatedStorage object.(Inherited from IsolatedStorage)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
MemberwiseClone(Boolean)	- Creates a shallow copy of the current MarshalByRefObject object.(Inherited from MarshalByRefObject)
MoveDirectory(String, String)	- Moves a specified directory and its contents to a new location.
MoveFile(String, String)	- Moves a specified file to a new location, and optionally lets you specify a new file name.
OpenFile(String, FileMode, FileAccess, FileShare)	- pens a file in the specified mode, with the specified read/write access and sharing permission.
OpenFile(String, FileMode, FileAccess)	- Opens a file in the specified mode with the specified read/write access.
OpenFile(String, FileMode)	- Opens a file in the specified mode.
Remove()	- Removes the isolated storage scope and all its contents.
Remove(IsolatedStorageScope)	- Removes the specified isolated storage scope for all identities.
ToString()	- Returns a string that represents the current object.(Inherited from Object)


**/