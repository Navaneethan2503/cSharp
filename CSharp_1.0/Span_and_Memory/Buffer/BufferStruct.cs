/**
Structs:
--------
MemoryHandle - Provides a memory handle for a block of memory.
    public struct MemoryHandle : IDisposable
    A MemoryHandle instance represents a handle to a pinned block of memory. It is returned by the following methods:
    IPinnable.Pin.
    Memory<T>.Pin
    ReadOnlyMemory<T>.Pin.
    MemoryManager<T>.Pin

    Constructors:
    ----------------
    MemoryHandle(Void*, GCHandle, IPinnable) - Creates a new memory handle for the block of memory.

    Properties:
    ----------
    Pointer	- Returns a pointer to the memory block.
        [System.CLSCompliant(false)]
        public void* Pointer { get; }

    Methods:
    ----------
    Dispose() - Frees the pinned handle and releases the IPinnable instance.

ReadOnlySequence<T>.Enumerator	- Represents an enumerator over a ReadOnlySequence<T>.
ReadOnlySequence<T>	- Represents a sequence that can read a sequential series of T.
    public readonly struct ReadOnlySequence<T>

    Constructors:
    -------------
    ReadOnlySequence<T>(ReadOnlyMemory<T>)	- Creates an instance of ReadOnlySequence<T> from a ReadOnlyMemory<T>.
    ReadOnlySequence<T>(ReadOnlySequenceSegment<T>, Int32, ReadOnlySequenceSegment<T>, Int32)	- Creates an instance of a ReadOnlySequence<T> from a linked memory list represented by start and end segments and the corresponding indexes in them.
    ReadOnlySequence<T>(T[], Int32, Int32)	- Creates an instance of a ReadOnlySequence<T> from a section of an array.
    ReadOnlySequence<T>(T[])	- Creates an instance of ReadOnlySequence<T> from the array.
    Fields:
    --------
    Empty- Returns an empty ReadOnlySequence<T>.
    Properties:
    -----------
    End	- Gets the position at the end of the ReadOnlySequence<T>.
    First	- Gets the ReadOnlyMemory<T> from the first segment.
    FirstSpan	- Gets the ReadOnlySpan<T> from the first segment.
        public ReadOnlySpan<T> FirstSpan { get; }

    IsEmpty	- Gets a value that indicates whether the ReadOnlySequence<T> is empty.
    IsSingleSegment	- Gets a value that indicates whether the ReadOnlySequence<T> contains a single ReadOnlyMemory<T> segment.
    Length	- Gets the length of the ReadOnlySequence<T>.
    Start	- Gets the position to the start of the ReadOnlySequence<T>.
    Methods:
    ---------
    GetEnumerator()	- Returns an enumerator over the ReadOnlySequence<T>.
    GetOffset(SequencePosition)	- Returns the offset of a position within this sequence from the start.
    GetPosition(Int64, SequencePosition)	- Returns a new SequencePosition starting at the specified offset from the origin position.
    GetPosition(Int64)	- Returns a new SequencePosition at an offset from the start of the sequence.
    Slice(Int32, Int32)	- Forms a slice out of the current ReadOnlySequence<T>, beginning at start, with length items.
    Slice(Int32, SequencePosition)	- Forms a slice out of the current ReadOnlySequence<T>, beginning at start and ending at end (exclusive).
    Slice(Int64, Int64)	- Forms a slice out of the given ReadOnlySequence<T>, beginning at start, with length items.
    Slice(Int64, SequencePosition)	- Forms a slice out of the current ReadOnlySequence<T>, beginning at start and ending at end (exclusive).
    Slice(Int64)	- Forms a slice out of the current ReadOnlySequence<T>, beginning at a specified index and continuing to the end of the read-only sequence.
    Slice(SequencePosition, Int32)	- Forms a slice out of the current ReadOnlySequence<T>, beginning at start, with length items.
    Slice(SequencePosition, Int64)	- Forms a slice out of the current ReadOnlySequence<T>, beginning at start, with length items.
    Slice(SequencePosition, SequencePosition)	- Forms a slice out of the current ReadOnlySequence<T>, beginning at start and ending at end (exclusive).
    Slice(SequencePosition)	- Forms a slice out of the current ReadOnlySequence<T>, beginning at a specified sequence position and continuing to the end of the read-only sequence.
    ToString()	- Returns a string that represents the current sequence.
    TryGet(SequencePosition, ReadOnlyMemory<T>, Boolean)	- Tries to retrieve the next segment after position and returns a value that indicates whether the operation succeeded.

SequenceReader<T>	- Provides methods for reading binary and text data out of a ReadOnlySequence<T> with a focus on performance and minimal or zero heap allocations.
    public ref struct SequenceReader<T> where T : struct
    SequenceReader<T> is a helper type for reading data from a ReadOnlySequence<T>.

        Reading Methods: Provides methods to read data from the sequence.
        Position Management: Manages the current position in the sequence.

    Constructors:
    -------------
    SequenceReader<T>(ReadOnlySequence<T>)	-  Creates a SequenceReader<T> over a given ReadOnlySequence<T>.

    Properties:
    ------------
    Consumed - Gets the total number of T values processed by the reader.
    CurrentSpan	- Gets a Span<T> that contains the current segment in the Sequence.
    CurrentSpanIndex - Gets the index in the CurrentSpan.
    End	- Gets a value that indicates whether there is no more data in the Sequence.
    Length	- Gets the count of items in the reader's Sequence.
    Position	- Gets the current position in the Sequence.
    Remaining	- Gets the remaining items in the reader's Sequence.
    Sequence	- Gets the underlying ReadOnlySequence<T> for the reader.
    UnreadSequence	- Gets the unread portion of the Sequence.
    UnreadSpan	- Gets the unread portion of the CurrentSpan.

    Methods:
    --------
    Advance(Int64)	- Moves the reader ahead a specified number of items.
    AdvancePast(T)	- Advances past consecutive instances of the given value.
    AdvancePastAny(ReadOnlySpan<T>)	- Skips consecutive instances of any of the specified values.
    AdvancePastAny(T, T, T, T)	- Advances past consecutive instances of any of four specified values.
    AdvancePastAny(T, T, T)	 - Advances past consecutive instances of any of three specified values.
    AdvancePastAny(T, T)	- Advances past consecutive instances of either of two specified values.
    AdvanceToEnd()	- Moves the reader to the end of the sequence.
    IsNext(ReadOnlySpan<T>, Boolean)	- Checks whether the values specified in a read-only span are next in the sequence.
    IsNext(T, Boolean)	- Checks whether a specified value is next in the sequence.
    Rewind(Int64)	- Moves the reader back the specified number of items.
    TryAdvanceTo(T, Boolean)	- Searches for a specified delimiter and optionally advances past it if it is found.
    TryAdvanceToAny(ReadOnlySpan<T>, Boolean)	- Searches for any of a number of specified delimiters and optionally advances past the first one to be found.
    TryCopyTo(Span<T>)	- Copies data from the current position to the given destination span if there is enough data to fill it.
    TryPeek(Int64, T)	- Peeks at the next value at the specified offset without advancing the reader.
    TryPeek(T)	- Peeks at the next value without advancing the reader.
    TryRead(T)	- Reads the next value and advance the reader.
    TryReadExact(Int32, ReadOnlySequence<T>)	- Attempts to read exactly count values from the current sequence.
    TryReadTo(ReadOnlySequence<T>, ReadOnlySpan<T>, Boolean)	- Tries to read data until the entire delimiter specified as a read-only span matches.
    TryReadTo(ReadOnlySequence<T>, T, Boolean)	- Tries to read everything up to the given delimiter.
    TryReadTo(ReadOnlySequence<T>, T, T, Boolean)	- Tries to read everything up to the given delimiter, ignoring delimiters that are preceded by delimiterEscape.
    TryReadTo(ReadOnlySpan<T>, ReadOnlySpan<T>, Boolean)	- Try to read everything up to the given delimiter.
    TryReadTo(ReadOnlySpan<T>, T, Boolean)	- Tries to read everything up to the given delimiter.
    TryReadTo(ReadOnlySpan<T>, T, T, Boolean)	- Tries to read everything up to the given delimiter, ignoring delimiters that are preceded by delimiterEscape.
    TryReadToAny(ReadOnlySequence<T>, ReadOnlySpan<T>, Boolean)	- Tries to read everything up to any of the specified delimiters.
    TryReadToAny(ReadOnlySpan<T>, ReadOnlySpan<T>, Boolean)	- Tries to read everything up to any of the specified delimiters.

StandardFormat	- Represents a standard format string without using an actual string.
    A StandardFormat object consists of a single character standard format specifier (such as 'G', 'D', or 'X') and an optional precision specifier. The precision specifier can range from 0 to 9, or it can be the special StandardFormat.NoPrecision value.
    Constructors:
    -------------
    StandardFormat(Char, Byte)	- Initializes a new instance of the StandardFormat structure.

    Fields:
    -------
    MaxPrecision - Defines the maximum valid precision value.
    NoPrecision	- Indicates that a format doesn't use a precision or that the precision is unspecified.
    
    Properties:
    -----------
    HasPrecision - Gets a value that indicates whether a format has a defined precision.
    IsDefault	-     Gets a value that indicates whether the current instance is a default format.
    Precision	-     Gets the precision component of the format.
    Symbol	-     Gets the character component of the format.

    Methods:
    -----------
    Equals(Object)	-      Returns a value that indicates whether the specified object is a StandardFormat object that is equal to the current instance.
    Equals(StandardFormat)	-     Returns a value that indicates whether the specified StandardFormat is equal to the current instance.
    GetHashCode()	-     Returns the hash code for this instance.
    Parse(ReadOnlySpan<Char>)	-     Converts a ReadOnlySpan<System.Char> into a StandardFormat instance using NoPrecision precision.
    Parse(String)	-     Converts a classic .NET standard format string to a StandardFormat instance.
    ToString()	-     Returns the string representation of this format.
    TryParse(ReadOnlySpan<Char>, StandardFormat)	-     Attempts to convert a ReadOnlySpan<Char> to a StandardFormat instance and returns a value that indicates whether the parsing operation succeeded.


**/
using System;
using System.Buffers;
using System.Buffers.Binary;

namespace BufferNamespace{

    class BuffferStruc{
        
        public static void Main(){
            ReadOnlySequence<byte> sequence1 = new ReadOnlySequence<byte>(new byte[] { 1, 2, 3, 4, 5 });
            foreach (var segment in sequence1)
            {
                ReadOnlyMemory<byte> memory = segment;
                // Process the memory
            }

            //
             // Create a ReadOnlySequence<byte> from an array
            byte[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ReadOnlySequence<byte> sequence = new ReadOnlySequence<byte>(data);

            // Create a SequenceReader<byte> to read the data
            SequenceReader<byte> reader = new SequenceReader<byte>(sequence);

            // Read bytes one by one
            while (reader.TryRead(out byte value))
            {
                Console.WriteLine(value); // Output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            }

            // Reset the reader
            reader = new SequenceReader<byte>(sequence);

            // Read an integer (4 bytes)
            if (reader.TryReadBigEndian(out int intValue))
            {
                Console.WriteLine(intValue); // Output: 16909060 (which is 0x01020304 in big-endian)
            }

            reader.Rewind(3);
            Console.WriteLine();
        }
    }
}




