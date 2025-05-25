/**
MemoryMappedViewAccessor Class:
-----------------------------------------------

Represents a randomly accessed view of a memory-mapped file.

    public sealed class MemoryMappedViewAccessor : System.IO.UnmanagedMemoryAccessor


Properties:
--------------
CanRead	- Determines whether the accessor is readable.(Inherited from UnmanagedMemoryAccessor)
CanWrite	- Determines whether the accessory is writable.(Inherited from UnmanagedMemoryAccessor)
Capacity	- Gets the capacity of the accessor.(Inherited from UnmanagedMemoryAccessor)
IsOpen	- Determines whether the accessor is currently open by a process.(Inherited from UnmanagedMemoryAccessor)
PointerOffset	- Gets the number of bytes by which the starting position of this view is offset from the beginning of the memory-mapped file.
SafeMemoryMappedViewHandle	- Gets a handle to the view of a memory-mapped file.


Methods
Dispose()	
Releases all resources used by the UnmanagedMemoryAccessor.

(Inherited from UnmanagedMemoryAccessor)
Dispose(Boolean)	
Releases the unmanaged resources used by the UnmanagedMemoryAccessor and optionally releases the managed resources.

(Inherited from UnmanagedMemoryAccessor)
Equals(Object)	
Determines whether the specified object is equal to the current object.

(Inherited from Object)
Flush()	
Clears all buffers for this view and causes any buffered data to be written to the underlying file.

GetHashCode()	
Serves as the default hash function.

(Inherited from Object)
GetType()	
Gets the Type of the current instance.

(Inherited from Object)
Initialize(SafeBuffer, Int64, Int64, FileAccess)	
Sets the initial values for the accessor.

(Inherited from UnmanagedMemoryAccessor)
MemberwiseClone()	
Creates a shallow copy of the current Object.

(Inherited from Object)
Read<T>(Int64, T)	
Reads a structure of type T from the accessor into a provided reference.

(Inherited from UnmanagedMemoryAccessor)
ReadArray<T>(Int64, T[], Int32, Int32)	
Reads structures of type T from the accessor into an array of type T.

(Inherited from UnmanagedMemoryAccessor)
ReadBoolean(Int64)	
Reads a Boolean value from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadByte(Int64)	
Reads a byte value from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadChar(Int64)	
Reads a character from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadDecimal(Int64)	
Reads a decimal value from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadDouble(Int64)	
Reads a double-precision floating-point value from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadInt16(Int64)	
Reads a 16-bit integer from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadInt32(Int64)	
Reads a 32-bit integer from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadInt64(Int64)	
Reads a 64-bit integer from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadSByte(Int64)	
Reads an 8-bit signed integer from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadSingle(Int64)	
Reads a single-precision floating-point value from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadUInt16(Int64)	
Reads an unsigned 16-bit integer from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadUInt32(Int64)	
Reads an unsigned 32-bit integer from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ReadUInt64(Int64)	
Reads an unsigned 64-bit integer from the accessor.

(Inherited from UnmanagedMemoryAccessor)
ToString()	
Returns a string that represents the current object.

(Inherited from Object)
Write(Int64, Boolean)	
Writes a Boolean value into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, Byte)	
Writes a byte value into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, Char)	
Writes a character into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, Decimal)	
Writes a decimal value into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, Double)	
Writes a Double value into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, Int16)	
Writes a 16-bit integer into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, Int32)	
Writes a 32-bit integer into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, Int64)	
Writes a 64-bit integer into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, SByte)	
Writes an 8-bit integer into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, Single)	
Writes a Single into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, UInt16)	
Writes an unsigned 16-bit integer into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, UInt32)	
Writes an unsigned 32-bit integer into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write(Int64, UInt64)	
Writes an unsigned 64-bit integer into the accessor.

(Inherited from UnmanagedMemoryAccessor)
Write<T>(Int64, T)	
Writes a structure into the accessor.

(Inherited from UnmanagedMemoryAccessor)
WriteArray<T>(Int64, T[], Int32, Int32)	
Writes structures from an array of type T into the accessor.

(Inherited from UnmanagedMemoryAccessor)

**/
