/**
The System.Buffers namespace in .NET provides a set of types that are designed to help with efficient memory management, particularly for scenarios involving buffers and pooling. 
This namespace is particularly useful for high-performance applications where managing memory allocations and deallocations efficiently is crucial.

Interfaces:
------------
IBufferWriter<T> -  Represents an output sink into which T data can be written.
        Methods:
        ----------
        Advance(Int32)	- Notifies the IBufferWriter<T> that count data items were written to the output Span<T> or Memory<T>.
        GetMemory(Int32) - Returns a Memory<T> to write to that is at least the requested size (specified by sizeHint).
        GetSpan(Int32)	- Returns a Span<T> to write to that is at least the requested size (specified by sizeHint).

IMemoryOwner<T>	- Identifies the owner of a block of memory who is responsible for disposing of the underlying memory appropriately.
        public interface IMemoryOwner<T> : IDisposable
            The IMemoryOwner<T> interface is used to define the owner responsible for the lifetime management of a Memory<T> buffer. An instance of the IMemoryOwner<T> interface is returned by the MemoryPool<T>.Rent method.
            While a buffer can have multiple consumers, it can only have a single owner at any given time. The owner can:
            Create the buffer either directly or by calling a factory method.
            Transfer ownership to another consumer. In this case, the previous owner should no longer use the buffer.
            Destroy the buffer when it is no longer in use.
            Because the IMemoryOwner<T> object implements the IDisposable interface, you should call its Dispose method only after the memory buffer is no longer needed and you have destroyed it. You should not dispose of the IMemoryOwner<T> object while a reference to its memory is available. This means that the type in which IMemoryOwner<T> is declared should not have a Finalize method.

            Properties:
            ------------
            Memory	- Gets the memory belonging to this owner.

            Methods:
            ----------
            Dispose() - Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.  (Inherited from IDisposable)

IPinnable	- Provides a mechanism for pinning and unpinning objects to prevent the garbage collector from moving them.
            public interface IPinnable

            Methods:
            -----------
            Pin(Int32)	- Pins a block of memory.
                public System.Buffers.MemoryHandle Pin(int elementIndex);
                return :A handle to the block of memory. MemoryHandle

            Unpin()	- Frees a block of pinned memory.
                public void Unpin();
                Call this method to indicate that the IPinnable object no longer needs to be pinned, and that the garbage collector can now move the object.

Enums:
-----
OperationStatus	- Defines the values that can be returned from span-based operations that support processing of input contained in multiple discontiguous buffers.
    public enum OperationStatus
    Name	Value	Description
    Done	0	The entire input buffer has been processed and the operation is complete.
    DestinationTooSmall	1	The input is partially processed, up to what could fit into the destination buffer. The caller can enlarge the destination buffer, slice the buffers appropriately, and retry.
    NeedMoreData	2	The input is partially processed, up to the last valid chunk of the input that could be consumed. The caller can stitch the remaining unprocessed input with more data, slice the buffers appropriately, and retry.
    InvalidData	3	The input contained invalid bytes which could not be processed. If the input is partially processed, the destination contains the partial result. This guarantees that no additional data appended to the input will make the invalid sequence valid.

Delegates:
----------
ReadOnlySpanAction<T,TArg>	- Encapsulates a method that receives a read-only span of objects of type T and a state object of type TArg.
SpanAction<T,TArg>	- Encapsulates a method that receives a span of objects of type T and a state object of type TArg.


**/

using System;
using System.Buffers;

namespace MemoryPerformaceNamespace{
    class MemoryPerformace{

        // IMemoryOwner
        public void ProcessData(IMemoryOwner<byte> memoryOwner)
        {
            Memory<byte> memory = memoryOwner.Memory;
            // Process the memory
            memoryOwner.Dispose(); // Return the memory to the pool
        }

        //IBufferWriter
        public void WriteData(IBufferWriter<byte> writer)
        {
            Span<byte> span = writer.GetSpan(1024);
            // Write data to the span
            writer.Advance(512); // Indicate that 512 bytes were written
        }

        public static void Main(){
            Console.WriteLine("Buffer Namespace.");
        }


    }
}
