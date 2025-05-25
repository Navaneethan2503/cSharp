/**

IsolatedStorage Class
______________________
Represents the abstract base class from which all isolated storage implementations must derive.

    public abstract class IsolatedStorage : MarshalByRefObject

Constructors:
------------------
IsolatedStorage()	- Initializes a new instance of the IsolatedStorage class.

Properties:
-----------
ApplicationIdentity	- Gets an application identity that scopes isolated storage.
AssemblyIdentity	- Gets an assembly identity used to scope isolated storage.
AvailableFreeSpace	- When overridden in a derived class, gets the available free space for isolated storage, in bytes.
DomainIdentity	- Gets a domain identity that scopes isolated storage.
Quota	- When overridden in a derived class, gets a value that represents the maximum amount of space available for isolated storage.
Scope	- Gets an IsolatedStorageScope enumeration value specifying the scope used to isolate the store.
SeparatorExternal	- Gets a backslash character that can be used in a directory string. When overridden in a derived class, another character might be returned.
SeparatorInternal	- Gets a period character that can be used in a directory string. When overridden in a derived class, another character might be returned.
UsedSize	- When overridden in a derived class, gets a value that represents the amount of the space used for isolated storage.

Methods:
--------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
IncreaseQuotaTo(Int64)	- When overridden in a derived class, prompts a user to approve a larger quota size, in bytes, for isolated storage.
InitStore(IsolatedStorageScope, Type, Type)	- Initializes a new IsolatedStorage object.
InitStore(IsolatedStorageScope, Type)	- Initializes a new IsolatedStorage object.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
MemberwiseClone(Boolean)	- Creates a shallow copy of the current MarshalByRefObject object.(Inherited from MarshalByRefObject)
Remove()	- When overridden in a derived class, removes the individual isolated store and all contained data.
ToString()	- Returns a string that represents the current object.(Inherited from Object)




**/
