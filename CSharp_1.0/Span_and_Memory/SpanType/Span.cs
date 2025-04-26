using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
/**
Problem Statement:
-------------------
Sorting Full Arrays: You have a method that sorts an entire array.
Sorting Subsets of Arrays: You need an overload that sorts only a part of an array, specified by an offset and a count.
Sorting Arbitrary Memory Regions: You want to support sorting data that isn't necessarily in an array. This data might come from native code or be located on the stack, represented by a pointer and a length.

Or take another example. You’re implementing an operation over System.String, such as a specialized parsing method. You’d likely expose a method that takes a string and provide an implementation that operates on strings. But what if you wanted to support operating over a subset of that string? 
String.Substring could be used to carve out just the piece that’s interesting to them, but that’s a relatively expensive operation, involving a string allocation and memory copy. You could, as mentioned in the array example, take an offset and a count, but then what if the caller doesn’t have a string but instead has a char[]? Or 
what if the caller has a char*, like one they created with stackalloc to use some space on the stack, or as the result of a call to native code? How could you write your parsing method in a way that didn’t force the caller to do any allocations or copies, and yet worked equally well with inputs of type string, char[] and char*?

In both situations, you might be able to use unsafe code and pointers, exposing an implementation that accepted a pointer and a length. That, however, eliminates the safety guarantees that are core to .NET and opens you up to problems like buffer overruns and access violations that for most .NET developers are a thing of the past. 
It also invites additional performance penalties, such as needing to pin managed objects for the duration of the operation so that the pointer you retrieve remains valid. And depending on the type of data involved, getting a pointer at all may not be practical.

There’s an answer to this conundrum, and its name is Span<T>.

Solution Using Span<T>:
----------------------
Span<T> is ideal for this scenario because it can represent a contiguous region of memory, whether it's part of an array, a slice of an array, or even unmanaged memory. Here's how you can implement a sort routine that works with Span<T>:


What Is Span<T>?
System.Span<T> is a new value type at the heart of .NET. It enables the representation of contiguous regions of arbitrary memory, regardless of whether that memory is associated with a managed object, is provided by native code via interop, or is on the stack. 
And it does so while still providing safe access with performance characteristics like that of arrays.

Span<T> essentially represents a reference to a contiguous region of memory, but it does not store the actual data itself. Instead, it provides a view or a window into the memory that is managed elsewhere. Here's a more detailed explanation:

How Span<T> Works:
------------------
Reference to Memory: Span<T> holds a reference to the start of the memory region and the length of the region. It does not copy or own the memory; it merely provides a way to access and manipulate it.
Stack Allocation: When you create a Span<T>, it is typically allocated on the stack. This means the Span<T> itself (the reference and length) is stored on the stack, but the memory it references can be anywhere: on the heap, in unmanaged memory, or on the stack.
Memory Safety: Span<T> ensures memory safety by preventing out-of-bounds access. It keeps track of the length of the memory region and throws exceptions if you try to access elements outside this range.

Key Points:
------------
Reference, Not Copy: Span<T> does not copy the data; it only references the existing memory.
Memory Location: The memory referenced by Span<T> can be on the heap (managed objects), in unmanaged memory (native code), or on the stack (stackalloc).
Stack Allocation of Span: The Span<T> itself is a stack-allocated structure, but the memory it references can be anywhere.


The Span<T> indexer takes advantage of a C# language feature introduced in C# 7.0 called ref returns. The indexer is declared with a “ref T” return type, which provides semantics like that of indexing into arrays, returning a reference to the actual storage location rather than returning a copy of what lives at that location:

Ref-Returning Indexer (Span)
In contrast, a ref-returning indexer allows you to access the element by reference, enabling direct modification of the original element.


public ref T this[int index] { get { ... } }


ReadOnlySpan:
--------------

System.ReadOnlySpan<T> is a variant of Span<T> that provides read-only access to a contiguous region of memory. This type is particularly useful for working with immutable data types, such as strings, without the need for allocations or copying. Let's break down the key points and explain how ReadOnlySpan<T> works, especially in the context of slicing strings efficiently.

Key Features of ReadOnlySpan<T>:
-------------------------------
Read-Only Access: ReadOnlySpan<T> ensures that the data it references cannot be modified. This is enforced by the type system, making it safe to use with immutable data.
Ref Readonly Indexer: The indexer of ReadOnlySpan<T> returns a ref readonly T, which means you get a read-only reference to the element. This allows you to access elements efficiently without copying them.
Efficient Slicing: ReadOnlySpan<T> makes it possible to create slices of strings or other read-only data without allocating new memory or copying data. This is particularly useful for performance-critical applications.

Benefits:
---------
No Allocations: Slicing a string with ReadOnlySpan<char> does not allocate new memory, making it very efficient.
Safety: The read-only nature of ReadOnlySpan<T> ensures that the underlying data cannot be modified, which is important for immutable types like strings.
Performance: By avoiding allocations and copying, ReadOnlySpan<T> provides significant performance benefits, especially in scenarios where you need to work with substrings or slices of data frequently.


Span<T> in C# provides a powerful feature known as reinterpret casts, which allows you to safely and efficiently reinterpret the underlying data of a span as a different type. This is particularly useful when you need to work with raw byte data and interpret it as another type, such as integers.

Reinterpret Casts with Span<T>:
--------------------------------
Concept:
A reinterpret cast allows you to treat the memory referenced by a Span<byte> as if it were a Span<int>, without copying the data. This means that the first four bytes of the Span<byte> will correspond to the first int in the Span<int>, the next four bytes to the second int, and so on.

Implementation of Span Library:
-------------------------------
public readonly ref struct Span<T>
{
  private readonly ref T _pointer;
  private readonly int _length;
  ...
}

The concept of a ref T field may be strange at first—in fact, one can’t actually declare a ref T field in C# or even in MSIL. But Span<T> is actually written to use a special internal type in the runtime that’s treated as a just-in-time (JIT) intrinsic, with the JIT generating for it the equivalent of a ref T field. Consider a ref usage that’s likely much more familiar:

1.Span<T> is defined in such a way that operations can be as efficient as on arrays: indexing into a span doesn’t require computation to determine the beginning from a pointer and its starting offset, as the ref field itself already encapsulates both. (By contrast, ArraySegment<T> has a separate offset field, making it more expensive both to index into and to pass around.)
2.The nature of Span<T> as a ref-like type brings with it some constraints due to its ref T field.

Explanation of Interior Pointers and Stack Constraints in Simple Terms:
-----------------------------------------------------------------------
Span<T> is a special type in C# that allows you to work with a contiguous region of memory. It is a ref-like type, meaning it contains a reference (or pointer) to the memory it represents. This reference can point not only to the beginning of an array but also to any position within the array. These references are called interior pointers.

Why Interior Pointers Are Special:
---------------------------------
Interior Pointers: These are references that point to the middle of an object (like an array) rather than the beginning. They are useful for working with subarrays or slices of data without copying it.
Garbage Collector (GC) Tracking: The .NET runtime's garbage collector needs to keep track of all references to manage memory efficiently. Tracking interior pointers is more complex and costly because the GC has to understand that these pointers are part of a larger object.

Stack Constraints:
-------------------
To manage the complexity and cost of tracking interior pointers, the .NET runtime imposes a constraint: ref-like types such as Span<T> must only live on the stack. This means:
Stack Allocation: Span<T> instances are allocated on the stack, which is a region of memory with a limited lifetime tied to the execution of a method.
Limited Lifetime: Because the stack is automatically cleaned up when a method returns, this constraint ensures that the number of interior pointers is limited and manageable.

Benefits of Stack Allocation:
---------------------------
Performance: Stack allocation is very fast compared to heap allocation.
Safety: By limiting Span<T> to the stack, the runtime ensures that these references do not outlive the memory they point to, preventing potential memory corruption or leaks.

Size of Span<T>:
---------------
Larger than Machine's Word Size: Span<T> is a structure that contains multiple fields, such as a reference to the memory (_pointer) and the length of the span (_length). These fields together make Span<T> larger than the typical word size of a machine (e.g., 32-bit or 64-bit).

Atomic Operations:
--------------------
Atomic Operations: These are operations that are completed as a single, indivisible step. For example, reading or writing a single 32-bit integer is typically atomic on a 32-bit machine.
Non-Atomic Operations: Since Span<T> is larger than the machine's word size, reading or writing a Span<T> involves multiple steps (reading/writing multiple fields). This means these operations are not atomic.

Tearing:
----------
Tearing: This occurs when a multi-threaded application reads or writes a structure in a non-atomic manner, leading to inconsistent or partial updates. For example, one thread might update part of the structure while another thread reads it, resulting in a mix of old and new values.


Limitations of Span<T>:
------------------------
    Stack-Only: Span<T> instances can only live on the stack, not on the heap. This is because:
    Interior Pointers: Span<T> can contain interior pointers, which are references to the middle of objects. Tracking these pointers is complex and expensive for the garbage collector.
    Non-Atomic Operations: Span<T> is larger than the machine's word size, making reads and writes non-atomic. This can lead to tearing in multi-threaded scenarios.
    No Boxing: Span<T> cannot be boxed, which means it cannot be used with APIs that require boxing, such as reflection invoke APIs.
    No Fields in Classes: You cannot have Span<T> fields in classes or non-ref-like structs. This is to prevent Span<T> from being stored on the heap.
    No Capturing in Lambdas or Async Methods: Span<T> cannot be captured in lambdas or used as locals in async methods or iterators. This is because these constructs may result in the Span<T> being stored on the heap as part of the compiler-generated state machines.
    No Generic Constraints: You cannot use Span<T> as a generic argument because instances of the type argument could end up getting boxed or stored on the heap. There is no "where T : ref struct" constraint available.



Why Span not suits for async Method:
-------------------------------------
Span<T> cannot be used in asynchronous methods due to its stack-only nature and the constraints imposed by the .NET runtime to ensure memory safety and performance. Let's break down the reasons why Span<T> is unsuitable for async methods:

Stack-Only Nature of Span<T>
Stack Allocation: Span<T> instances are allocated on the stack, which means their lifetime is tied to the scope of the method in which they are created. When the method returns, the stack frame is cleaned up, and any Span<T> instances are no longer valid.

Lifetime Management: Async methods often involve suspending and resuming execution, which can lead to the method's state being stored on the heap in a compiler-generated state machine. Since Span<T> cannot be stored on the heap, it cannot be safely persisted across these suspension points.

Memory Safety Concerns
Interior Pointers: Span<T> can contain interior pointers, which are references to the middle of objects. Tracking these pointers is complex and expensive for the garbage collector. Allowing Span<T> to be stored on the heap would increase the complexity and cost of garbage collection.

Non-Atomic Operations: Span<T> is larger than the machine's word size, making reads and writes non-atomic. This can lead to tearing in multi-threaded scenarios, where partial updates to the Span<T> structure could result in inconsistent states.

**/
namespace SpanNamespace{
    
    class SpanClass{
        public int[] intArry = [323,2334,433,23];
        //public Span<int> spanIntArray = intArry;
        //error CS8345: Field or auto-implemented property cannot be of type 'Span<int>' unless it is an instance member of a ref struct.

        public async Task TestAsync(){
            int[] intArry2 = [2,5,3,1,67,5];
            Task.Delay(100);
            Span<int> asd = intArry2;
            foreach(int i in asd){
                Console.Write(i+",");
            }
        }

        public async Task ProcessDataAsync()
        {
            byte[] data = new byte[100];
            Span<byte> span = data.AsSpan();

            await Task.Delay(1000); // Suspension point

            // Attempt to use span after suspension
            //span[0] = 42; // Unsafe, span may no longer be valid
        }

        
        public async static Task Main(){
            Console.WriteLine("Span");

            SpanClass sa = new SpanClass();
            await sa.TestAsync();

            //Managed Array
            //When you create a Span<T> from an array, the Span<T> references the array's memory:
            int[] array = { 1, 2, 3, 4, 5 };
            Span<int> span = new Span<int>(array);
            // span references the memory of the array

            //Unmanaged Memory
            //When you create a Span<T> from unmanaged memory, such as a pointer, the Span<T> references the memory pointed to by the pointer:
            unsafe
            {
                int* ptr = stackalloc int[5] { 1, 2, 3, 4, 5 };
                Span<int> spanPtr = new Span<int>(ptr, 5);
                // span references the memory pointed to by ptr
            }

            //Stack Memory
            //When you create a Span<T> using stackalloc, the memory is allocated on the stack, and the Span<T> references this stack-allocated memory:
            Span<int> spanStack = stackalloc int[5] { 1, 2, 3, 4, 5 };
            // span references the stack-allocated memory


            var arr = new byte[10];
            Span<byte> bytes = arr; // Implicit cast from T[] to Span<T>

            //Span give control within range by in-memory without creating copy or additional operations.
            Span<byte> sliceBytes = bytes.Slice(start: 5, length: 2);
            sliceBytes[0] = 43;
            sliceBytes[1] = 45;

            //Error When try to access out of index for slicebytes.
            //sliceBytes[3] = 85; // Error - System.IndexOutOfRangeException: Index was outside the bounds of the array.

            //span also gives the performace characteristics of array to span array.
            bytes[0] = 1;//OK
            
            Console.Write("Slice Bytes :");
            foreach(int i in sliceBytes){
                Console.Write(i+",");
            }
            Console.WriteLine();
            Console.Write("Original Array :");
            foreach(int i in arr){
                Console.Write(i+",");
            }
            Console.WriteLine();


            //As mentioned, spans are more than just a way to access and subset arrays. They can also be used to refer to data on the stack. For example:
            Span<byte> bytesStack = stackalloc byte[2]; // Using C# 7.2 stackalloc support for spans
            bytesStack[0] = 42;
            bytesStack[1] = 43;
            //bytesStack[2] = 44; // throws IndexOutOfRangeException - Error

            //ReadOnly Span
            string str = "hello, world";
            string worldString = str.Substring(startIndex: 7, length: 5); // Allocates
            ReadOnlySpan<char> worldSpan =
            str.AsSpan().Slice(start: 7, length: 5); // No allocation
            Console.WriteLine($"\'w\' is equals to \'{worldSpan[0]}\'");
            //worldSpan[0] = 'a'; // Error CS0200: indexer cannot be assigned to 
            //Error - use it as the right hand side of a ref assignment because it is a readonly variable

            //Span<char> helloSpan = str.AsSpan().Slice(start: 0, length: 5);//error CS0029: Cannot implicitly convert type 'System.ReadOnlySpan<char>' to 'System.Span<char>'
            ReadOnlySpan<byte> readSpanInt = arr;


            //Reintercept of cast array
            byte[] byteArray = new byte[16] { 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0 };
            Span<byte> byteSpan = byteArray;

            // Reinterpret cast the Span<byte> to Span<int>
            Span<int> intSpan = MemoryMarshal.Cast<byte, int>(byteSpan);

            // Access the integers
            for (int i = 0; i < intSpan.Length; i++)
            {
                Console.WriteLine(intSpan[i]); // Output: 1, 2, 3, 4
            }

            //Interior Pointers
            var arrInteriorP = new byte[100];
            Span<byte> interiorRef1 = arrInteriorP.AsSpan(start: 20); // Points to the array starting at index 20
            Span<byte> interiorRef2 = new Span<byte>(arrInteriorP, 20, arrInteriorP.Length - 20); // Another way to do the same
            //Span<byte> interiorRef3 = MemoryMarshal.CreateSpan<byte>(arrInteriorP, ref arrInteriorP[20], arrInteriorP.Length - 20); // Yet another way



        }
    }
}