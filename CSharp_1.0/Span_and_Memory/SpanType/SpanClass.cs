using System;
using System.Collections.Generic;
/**
Provides a type-safe and memory-safe representation of a contiguous region of arbitrary memory.
    [System.Runtime.InteropServices.Marshalling.NativeMarshalling(typeof(System.Runtime.InteropServices.Marshalling.SpanMarshaller<,>))]
    public readonly ref struct Span<T>

Constructors:
-------------
Span<T>(T)	- Creates a new Span<T> of length 1 around the specified reference.
Span<T>(T[], Int32, Int32)	- Creates a new Span<T> object that includes a specified number of elements of an array starting at a specified index.
Span<T>(T[])	- Creates a new Span<T> object over the entirety of a specified array.
Span<T>(Void*, Int32)	- Creates a new Span<T> object from a specified number of T elements starting at a specified memory address.

Properties:
-----------
Empty - Returns an empty Span<T> object.
IsEmpty	- Returns a value that indicates whether the current Span<T> is empty.
Item[Int32]	- Gets the element at the specified zero-based index.
Length	- Returns the length of the current span.

Methods:
---------
Clear()	- Clears the contents of this Span<T> object.
CopyTo(Span<T>)	- Copies the contents of this Span<T> into a destination Span<T>.
Equals(Object)	- Obsolete. Calls to this method are not supported.
Fill(T)	- fills the elements of this span with a specified value.
GetEnumerator()	- Returns an enumerator for this Span<T>.
GetHashCode()	- Obsolete. Throws a NotSupportedException.
GetPinnableReference()	- Returns a reference to an object of type T that can be used for pinning. This method is intended to support .NET compilers and is not intended to be called by user code.
Slice(Int32, Int32)	- Forms a slice out of the current span starting at a specified index for a specified length.
        public Span<T> Slice(int start, int length);
        return : A span that consists of length elements from the current span starting at start.
Slice(Int32)	- Forms a slice out of the current span that begins at a specified index.
ToArray()	- Copies the contents of this span into a new array.
ToString()	- Returns the string representation of this Span<T> object.
TryCopyTo(Span<T>)	- Attempts to copy the current Span<T> to a destination Span<T> and returns a value that indicates whether the copy operation succeeded.

Operators:
----------
Equality(Span<T>, Span<T>)	- Returns a value that indicates whether two Span<T> objects are equal.
    public static bool operator ==(Span<T> left, Span<T> right);

Implicit(ArraySegment<T> to Span<T>)	- Defines an implicit conversion of an ArraySegment<T> to a Span<T>.
Implicit(Span<T> to ReadOnlySpan<T>)	- Defines an implicit conversion of a Span<T> to a ReadOnlySpan<T>.
Implicit(T[] to Span<T>)	- Defines an implicit conversion of an array to a Span<T>.
Inequality(Span<T>, Span<T>)	- Returns a value that indicates whether two Span<T> objects are not equal.


----------------------------=========================================================---------------------------------------
ReadOnlySpan<T>:
-------------------

Provides a type-safe and memory-safe read-only representation of a contiguous region of arbitrary memory.

[System.Runtime.InteropServices.Marshalling.NativeMarshalling(typeof(System.Runtime.InteropServices.Marshalling.ReadOnlySpanMarshaller<,>))]
public readonly ref struct ReadOnlySpan<T>

Remarks
ReadOnlySpan<T> is a ref struct that is allocated on the stack and can never escape to the managed heap. Ref struct types have a number of restrictions to ensure that they cannot be promoted to the managed heap, including that they can't be boxed, captured in lambda expressions, assigned to variables of type Object, assigned to dynamic variables, and they cannot implement any interface type.

A ReadOnlySpan<T> instance is often used to reference the elements of an array or a portion of an array. Unlike an array, however, a ReadOnlySpan<T> instance can point to managed memory, native memory, or memory managed on the stack.

Constructors:
------------
ReadOnlySpan<T>(T)	- Creates a new ReadOnlySpan<T> of length 1 around the specified reference.
ReadOnlySpan<T>(T[], Int32, Int32)	- Creates a new ReadOnlySpan<T> that includes a specified number of elements of an array starting at a specified index.
ReadOnlySpan<T>(T[])	-Creates a new ReadOnlySpan<T> over the entirety of a specified array.
ReadOnlySpan<T>(Void*, Int32)	- Creates a new ReadOnlySpan<T> from a specified number of T elements starting at a specified memory address.











**/
namespace SpanNamespace{
    class SpanClass2{
        public static void Main(){
            Console.WriteLine("Span Class");
            byte[] arr = [1,23,4];
            Span<byte> arrSpan = arr;
            byte[] arr2 = [1,23,4];
            Span<byte> arrSpan2 = arr;
            bool result = (arrSpan == arrSpan2);
            Console.WriteLine("Equality :"+ result);

        }
    }
}