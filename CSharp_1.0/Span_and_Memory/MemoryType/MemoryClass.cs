using System;
/**
Represents a contiguous region of memory.

public readonly struct Memory<T> : IEquatable<Memory<T>>

Remarks
Like Span<T>, Memory<T> represents a contiguous region of memory. Unlike Span<T>, however, Memory<T> is not a ref struct. This means that Memory<T> can be placed on the managed heap, whereas Span<T> cannot. As a result, the Memory<T> structure does not have the same restrictions as a Span<T> instance. In particular:

It can be used as a field in a class.

It can be used across await and yield boundaries.

In addition to Memory<T>, you can use System.ReadOnlyMemory<T> to represent immutable or read-only memory.

Constructors:
---------------
Memory<T>(T[], Int32, Int32) - Creates a new Memory<T> object that includes a specified number of elements of an array beginning at a specified index.
Memory<T>(T[])	- Creates a new Memory<T> object over the entirety of a specified array.

Properties:
-----------
Empty - Returns an empty Memory<T> object.
IsEmpty	- Indicates whether the current instance is empty.
Length	- Gets the number of items in the current instance.
Span - Returns a span from the current instance.

Methods:
------------
CopyTo(Memory<T>) - Copies the contents of a Memory<T> object into a destination Memory<T> object.
Equals(Memory<T>)	- Determines whether the specified Memory<T> object is equal to the current object.
Equals(Object)	- Determines whether the specified object is equal to the current object.
GetHashCode()	- Returns the hash code for this instance.
Pin()	- Creates a handle for the Memory<T> object.
Slice(Int32, Int32)	- Forms a slice out of the current memory starting at a specified index for a specified length.
Slice(Int32)	- Forms a slice out of the current memory that begins at a specified index.
ToArray()	- Copies the contents from the memory into a new array.
ToString()	- Returns the string representation of this Memory<T> object.
TryCopyTo(Memory<T>)	- Copies the contents of the memory into a destination Memory<T> instance.

Operators :
------------
Implicit(ArraySegment<T> to Memory<T>)	- Defines an implicit conversion of an ArraySegment<T> object to a Memory<T> object.
Implicit(Memory<T> to ReadOnlyMemory<T>)	- Defines an implicit conversion of a Memory<T> object to a ReadOnlyMemory<T> object.
Implicit(T[] to Memory<T>)	- Defines an implicit conversion of an array to a Memory<T> object.

---------------------========================================================================--------------------------
ReadOnlyMemory<T>:
-----------------
Represents a contiguous region of memory, similar to ReadOnlySpan<T>. Unlike ReadOnlySpan<T>, it is not a byref-like type.

public readonly struct ReadOnlyMemory<T> : IEquatable<ReadOnlyMemory<T>>

Constructors:
-------------
ReadOnlyMemory<T>(T[], Int32, Int32) - Creates a new memory region over the portion of the target array beginning at a specified position and including a specified number of elements.
ReadOnlyMemory<T>(T[])	- Creates a new memory region over the entirety of the target array.



**/
namespace MemoryNamespace{
    class MemoryClass2{
        public static void Main(){
            Console.WriteLine("Memory Class");
            int[] a = [1,2,3,4,5,5];
            Memory<int> aMemory = a;
            for(int i = 0; i<aMemory.Length;i++){
                Console.Write(aMemory.Span[i]+",");
            }
        }
    }
}