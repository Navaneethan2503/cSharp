using System;
using System.Buffers;
/**
Contains types used in creating and managing memory buffers, such as those represented by Span<T> and Memory<T>.

Classes:
--------
ArrayBufferWriter<T> - Represents a heap-based, array-backed output sink into which T data can be written.
    Constructors:
    ------------
    ArrayBufferWriter<T>()	-     Creates an instance of an ArrayBufferWriter<T> to which data can be written, with the default initial capacity.
    ArrayBufferWriter<T>(Int32)	-     Creates an instance of an ArrayBufferWriter<T> to which data can be written, with a specified initial capacity.
    
    Properties:
    -----------
    Capacity	-     Gets the total amount of space within the underlying buffer.
    FreeCapacity	-     Gets the amount of available space that can be written to without forcing the underlying buffer to grow.
    WrittenCount	-     Gets the amount of data written to the underlying buffer.
    WrittenMemory	-     Gets a ReadOnlyMemory<T> that contains the data written to the underlying buffer so far.
    WrittenSpan	-     Gets a ReadOnlySpan<T> that contains the data written to the underlying buffer so far.
    
    Methods:
    ---------
    Advance(Int32)	-     Notifies the IBufferWriter<T> that count items were written to the output Span<T>/Memory<T>.
    Clear()	-     Clears the data written to the underlying buffer.
    Equals(Object)	-     Determines whether the specified object is equal to the current object.    (Inherited from Object)
    GetHashCode()	-     Serves as the default hash function.    (Inherited from Object)
    GetMemory(Int32) -     Returns a Memory<T> to write to that is at least the length specified by sizeHint.
    GetSpan(Int32)	-     Returns a Span<T> to write to that is at least a specified length.
    GetType()	-     Gets the Type of the current instance.    (Inherited from Object)
    MemberwiseClone()	-     Creates a shallow copy of the current Object.    (Inherited from Object)
    ResetWrittenCount() -     
    ToString()	-    Returns a string that represents the current object.    (Inherited from Object)

ArrayPool<T>	- Provides a resource pool that enables reusing instances of type T[].
    public abstract class ArrayPool<T>
    Using the ArrayPool<T> class to rent and return buffers (using the Rent and Return methods) can improve performance in situations where arrays are created and destroyed frequently, resulting in significant memory pressure on the garbage collector.

    Constructors:
    -------------
    ArrayPool<T>()	-     Initializes a new instance of the ArrayPool<T> class.

    Properties:
    -----------
    Shared	-     Gets a shared ArrayPool<T> instance.

    Methods:
    ----------
    Create() -     Creates a new instance of the ArrayPool<T> class.
    Create(Int32, Int32)	-     Creates a new instance of the ArrayPool<T> class using the specified configuration.
    Equals(Object)	-     Determines whether the specified object is equal to the current object.    (Inherited from Object)
    GetHashCode()	-     Serves as the default hash function.    (Inherited from Object)
    GetType() -     Gets the Type of the current instance.    (Inherited from Object)
    MemberwiseClone()	-     Creates a shallow copy of the current Object.    (Inherited from Object)
    Rent(Int32)	 -     Retrieves a buffer that is at least the requested length.
        public abstract T[] Rent(int minimumLength);
        This buffer is loaned to the caller and should be returned to the same pool using the Return method, so that it can be reused in subsequent calls to the Rent method. Failure to return a rented buffer is not a fatal error. However, it may lead to decreased application performance, as the pool may need to create a new buffer to replace the lost one.
        The array returned by this method may not be zero-initialized.
        Indicates whether the contents of the buffer should be cleared before reuse. If clearArray is set to true, and if the pool will store the buffer to enable subsequent reuse, the Return(T[], Boolean) method will clear the array of its contents so that a subsequent caller using the Rent(Int32) method will not see the content of the previous caller. If clearArray is set to false or if the pool will release the buffer, the array's contents are left unchanged.

    Return(T[], Boolean)	-     Returns an array to the pool that was previously obtained using the Rent(Int32) method on the same ArrayPool<T> instance.
    ToString()	-     Returns a string that represents the current object.    (Inherited from Object)

BuffersExtensions	- Provides extension methods for ReadOnlySequence<T>.
    public static class BuffersExtensions

    Methods:
    ----------
    CopyTo<T>(ReadOnlySequence<T>, Span<T>)	-     Copies the ReadOnlySequence<T> to the specified Span<T>.
    PositionOf<T>(ReadOnlySequence<T>, T)	-     Returns the position of the first occurrence of value in the ReadOnlySequence<T>.
    ToArray<T>(ReadOnlySequence<T>)	-     Converts the ReadOnlySequence<T> to an array.
    Write<T>(IBufferWriter<T>, ReadOnlySpan<T>) - Writes the contents of value to writer.

MemoryManager<T>	- An abstract base class that is used to replace the implementation of Memory<T>.
    public abstract class MemoryManager<T> : System.Buffers.IMemoryOwner<T>, System.Buffers.IPinnable
    Constructors:
    -------------
    MemoryManager<T>()	-     Initializes a new instance of the MemoryManager<T> class.

    Properties:
    ------------
    Memory	-     Gets the memory block handled by this MemoryManager<T>.

    Methods:
    --------
    CreateMemory(Int32, Int32)	-     Returns a memory buffer consisting of a specified number of elements starting at a specified offset from the memory managed by the current memory manager.
    CreateMemory(Int32)	-     Returns a memory buffer consisting of a specified number of elements from the memory managed by the current memory manager.
    Dispose(Boolean)	-     Releases all resources used by the current memory manager.
    Equals(Object)	-     Determines whether the specified object is equal to the current object.    (Inherited from Object)
    GetHashCode()	-     Serves as the default hash function.    (Inherited from Object)
    GetSpan()	-     Returns a memory span that wraps the underlying memory buffer.
    GetType()	-     Gets the Type of the current instance.    (Inherited from Object)
    MemberwiseClone()	-     Creates a shallow copy of the current Object.    (Inherited from Object)
    Pin(Int32)	-     Returns a handle to the memory that has been pinned and whose address can be taken.
    ToString()	-     Returns a string that represents the current object.    (Inherited from Object)
    TryGetArray(ArraySegment<T>)	-     Returns an array segment
    Unpin() -     Unpins pinned memory so that the garbage collector is free to move it.

MemoryPool<T>	- Represents a pool of memory blocks.
    public abstract class MemoryPool<T> : IDisposable
    Constructors:
    ------------
    MemoryPool<T>()	-     Constructs a new instance of a memory pool.

    Properties:
    --------------
    MaxBufferSize -     Gets the maximum buffer size supported by this pool.
    Shared	-     Gets a singleton instance of a memory pool based on arrays.

    Methods:
    ---------
    Dispose()	-     Frees all resources used by the memory pool.
    Dispose(Boolean)	-     Frees the unmanaged resources used by the memory pool and optionally releases the managed resources.
    Equals(Object)	-     Determines whether the specified object is equal to the current object.    (Inherited from Object)
    GetHashCode()	-     Serves as the default hash function.    (Inherited from Object)
    GetType()	-     Gets the Type of the current instance.    (Inherited from Object)
    MemberwiseClone()	-     Creates a shallow copy of the current Object.    (Inherited from Object)
    Rent(Int32)	-     Returns a memory block capable of holding at least minBufferSize elements of T.
        public abstract System.Buffers.IMemoryOwner<T> Rent(int minBufferSize = -1);
        
    ToString()	 -    Returns a string that represents the current object.    (Inherited from Object)

ReadOnlySequenceSegment<T>	- Represents a linked list of ReadOnlyMemory<T> nodes.
    Constructors:
    -------------
    ReadOnlySequenceSegment<T>() - Initializes a new instance of the ReadOnlySequenceSegment<T> class.

    Properties:
    -----------
    Memory	-     Gets or sets a ReadOnlyMemory<T> value for the current node.
    Next	-     Gets or sets the next node.
    RunningIndex	-     Gets or sets the sum of node lengths before the current node.

    Methods:
    ----------
    Equals(Object)	-     Determine  whether the specified object is equal to the current object.    (Inherited from Object)
    GetHashCode()	-     Serves as the default hash function.    (Inherited from Object)
    GetType()	-    Gets the Type of the current instance.    (Inherited from Object)
    MemberwiseClone()	-     Creates a shallow copy of the current Object.    (Inherited from Object)
    ToString()	-     Returns a string that represents the current object.    (Inherited from Object)

SearchValues	- Provides a set of initialization methods for instances of the SearchValues<T> class.
    Create(ReadOnlySpan<Byte>)	-     Creates an optimized representation of values used for efficient searching.
    Create(ReadOnlySpan<Char>)	-     Creates an optimized representation of values used for efficient searching.
    Create(ReadOnlySpan<String>, StringComparison)	-     Creates an optimized representation of values used for efficient searching.

SearchValues<T>	- Provides an immutable, read-only set of values optimized for efficient searching. Instances are created by Create(ReadOnlySpan<Byte>) or Create(ReadOnlySpan<Char>).
    public class SearchValues<T> where T : IEquatable<T>
    SearchValues<T> instances are optimized for situations where the same set of values is frequently used for searching at run time.

    Methods:
    ---------
    Contains(T)	-     Searches for the specified value.
    Equals(Object)	-     Determines whether the specified object is equal to the current object.    (Inherited from Object)
    GetHashCode()	-     Serves as the default hash function.    (Inherited from Object)
    GetType() -     Gets the Type of the current instance.    (Inherited from Object)
    MemberwiseClone() -     Creates a shallow copy of the current Object.    (Inherited from Object)
    ToString() -     Returns a string that represents the current object.    (Inherited from Object)

SequenceReaderExtensions	- Provides extended functionality for the SequenceReader<T> class that allows reading of endian specific numeric values from binary data.
        Methods:
        --------
        TryReadBigEndian(SequenceReader<Byte>, Int16)	-         Tries to read an Int16 as big endian.
        TryReadBigEndian(SequenceReader<Byte>, Int32)	-         Tries to read an Int32 as big endian.
        TryReadBigEndian(SequenceReader<Byte>, Int64)	-         Tries to read an Int64 as big endian.
        TryReadLittleEndian(SequenceReader<Byte>, Int16)	-         Tries to read an Int16 as little endian.
        TryReadLittleEndian(SequenceReader<Byte>, Int32)	-         Tries to read an Int32 as little endian.
        TryReadLittleEndian(SequenceReader<Byte>, Int64)	-         Tries to read an Int64 as little endian.
**/
namespace BufferNamespace{
    class BufferClass{
        public static void Main(){
            Console.WriteLine("Buffer Class.");

            byte[] byteList = [1,2,3,4,5,6,7,8,9];
            ReadOnlySpan<byte> spanByte = byteList;
            SearchValues<byte> tracks = SearchValues.Create(spanByte);
            Console.WriteLine("Contains 5: "+ tracks.Contains(5));

            //ArrayBufferWriter
            ArrayBufferWriter<byte> testBuffer = new ArrayBufferWriter<byte>(10);
            Span<byte> writeSpan = testBuffer.GetSpan(4);
            writeSpan[0] = 10;
            writeSpan[1] = 20;
            testBuffer.Advance(2);
            Console.WriteLine("ArrayBufferWriter :");
            foreach(int i in testBuffer.WrittenSpan){
                Console.Write(i+",");
            }

            //ArrayPool
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;
            byte[] buffer = pool.Rent(1024);
            buffer[0] = 10;
            Console.WriteLine("Array Pool At Index 1st :"+buffer[0]);

            pool.Return(buffer,true);
            Console.WriteLine("Try accessing Array Pool At Index 1st after returned :"+buffer[0]);


            MemoryPool<byte> poolM = MemoryPool<byte>.Shared;
            using (IMemoryOwner<byte> owner = poolM.Rent(1024))
            {
                Memory<byte> memory = owner.Memory;
                memory.Span[0] = 10;
                // Use the memory

            }


            


        }
    }
}