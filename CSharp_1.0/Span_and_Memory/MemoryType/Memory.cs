using System;
using System.Threading.Tasks;
/**

Memory<T> is a type in C# that provides a way to work with contiguous regions of memory in a more flexible manner than Span<T>. While Span<T> is limited to stack-only usage and short-lived operations, 
Memory<T> can be used for longer-lived data and can be stored on the heap. 
This makes Memory<T> suitable for scenarios where you need to maintain references to memory regions beyond the scope of a single method or stack frame.

Key Features of Memory<T>:
--------------------------
    Heap Allocation: Unlike Span<T>, which is stack-only, Memory<T> can be stored on the heap. This allows it to be used in fields of classes, async methods, and other long-lived scenarios.
    Read-Only Variant: Similar to ReadOnlySpan<T>, there is a ReadOnlyMemory<T> type that provides read-only access to memory regions.
    Interoperability: Memory<T> can be created from arrays, strings, and other memory buffers, making it versatile for various use cases.
    Slicing: You can create slices of Memory<T> without copying the data, similar to Span<T>.

Benefits:
-----------
Long-Lived Data: Memory<T> can be used for data that needs to persist beyond the scope of a single method or stack frame.
Flexibility: It can be stored in fields of classes, passed to async methods, and used in other scenarios where Span<T> cannot be used.
Efficiency: Memory<T> provides efficient access to memory regions without copying data, similar to Span<T>.

Practical Use Cases:
--------------------
Buffer Management: Efficiently manage buffers for I/O operations, network communication, and other scenarios where data needs to persist.
Data Processing: Perform operations on large datasets that need to be accessed and modified over time.
Interoperability: Work with memory regions passed from native code or other systems in a safe and efficient manner.

Impact on Asynchronous Operations:
----------------------------------
These limitations are generally manageable for synchronous, compute-bound operations. However, they pose significant challenges for asynchronous operations. Many of the issues with arrays, array slices, and native memory exist in both synchronous and asynchronous contexts. Since Span<T> cannot be stored on the heap, it cannot be persisted across asynchronous operations.

Solution: Memory<T>:
---------------------
Memory<T> is designed to address these limitations by providing a way to work with contiguous memory regions that can be stored on the heap and used in asynchronous operations.

Memory<T> looks very much like an ArraySegment<T>:

public readonly struct Memory<T>
{
  private readonly object _object;
  private readonly int _index;
  private readonly int _length;
  ...
}

Figure 1 Non-Allocating/Non-Copying Conversions Between Span-Related Types:
---------------------------------------------------------------------------

From	To	Mechanism
ArraySegment<T>	Memory<T>	Implicit cast, AsMemory method
ArraySegment<T>	ReadOnlyMemory<T>	Implicit cast, AsMemory method
ArraySegment<T>	ReadOnlySpan<T>	Implicit cast, AsSpan method
ArraySegment<T>	Span<T>	Implicit cast, AsSpan method
ArraySegment<T>	T[]	Array property
Memory<T>	ArraySegment<T>	MemoryMarshal.TryGetArray method
Memory<T>	ReadOnlyMemory<T>	Implicit cast, AsMemory method
Memory<T>	Span<T>	Span property
ReadOnlyMemory<T>	ArraySegment<T>	MemoryMarshal.TryGetArray method
ReadOnlyMemory<T>	ReadOnlySpan<T>	Span property
ReadOnlySpan<T>	ref readonly T	Indexer get accessor, marshaling methods
Span<T>	ReadOnlySpan<T>	Implicit cast, AsSpan method
Span<T>	ref T	Indexer get accessor, marshaling methods
String	ReadOnlyMemory<char>	AsMemory method
String	ReadOnlySpan<char>	Implicit cast, AsSpan method
T[]	ArraySegment<T>	Ctor, Implicit cast
T[]	Memory<T>	Ctor, Implicit cast, AsMemory method
T[]	ReadOnlyMemory<T>	Ctor, Implicit cast, AsMemory method
T[]	ReadOnlySpan<T>	Ctor, Implicit cast, AsSpan method
T[]	Span<T>	Ctor, Implicit cast, AsSpan method
void*	ReadOnlySpan<T>	Ctor
void*	Span<T>	Ctor


Memory<T> is designed to be a flexible and efficient way to work with contiguous memory regions. One of the key aspects of Memory<T> is its ability to wrap various types of memory, not just arrays. This flexibility is achieved through its internal representation and the use of abstract classes like OwnedMemory<T>. Let's break down the concepts mentioned:

Internal Representation of Memory<T>:
--------------------------------------
_object Field: The _object field in Memory<T> is stored as an object rather than a strongly typed T[]. This allows Memory<T> to wrap different types of memory buffers, not just arrays.
Versatility: By using an object field, Memory<T> can wrap arrays, memory retrieved from pools, and even native memory.

OwnedMemory<T>:
--------------
Abstract Class: OwnedMemory<T> is an abstract class that provides a way to manage the lifetime of memory buffers. This is useful for scenarios where memory needs to be tightly managed, such as memory retrieved from a pool.
Lifetime Management: OwnedMemory<T> can be used to ensure that memory is properly allocated and deallocated, preventing memory leaks and ensuring efficient use of resources.

Wrapping Pointers into Native Memory:
------------------------------------
Native Memory: Memory<T> can be used to wrap pointers into native memory, allowing you to work with memory allocated outside the .NET runtime (e.g., memory allocated by C/C++ code).
Interoperability: This feature is particularly useful for interoperability with native code, enabling efficient and safe manipulation of native memory buffers.

ReadOnlyMemory<char> and Strings:
---------------------------------
Read-Only Access: ReadOnlyMemory<char> provides read-only access to memory regions, similar to ReadOnlySpan<char>.
Strings: ReadOnlyMemory<char> can be used with strings, allowing efficient slicing and manipulation of string data without allocations or copying.


**/
namespace MemoryNamespace{
    public class DataProcessor
    {
        private Memory<int> _data;

        public DataProcessor(int[] data)
        {
            _data = new Memory<int>(data);
        }

        public void Process()
        {
            // Access and modify the data
            for (int i = 0; i < _data.Length; i++)
            {
                _data.Span[i] *= 2;
            }
        }

        public void PrintData()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                Console.WriteLine(_data.Span[i]);
            }
        }
    }




    class MemoryClass{

        public async Task ProcessDataAsync(Memory<int> memory)
        {
            // Perform asynchronous operations on the memory
            await Task.Delay(1000);
            // Access elements in the memory
            for (int i = 0; i < memory.Length; i++)
            {
                Console.WriteLine(memory.Span[i]);
            }
        }


        public static void Main(){
            Console.WriteLine("Memory.");

            int[] array = { 1, 2, 3, 4, 5 };
            Memory<int> memory = new Memory<int>(array);
            Memory<int> slice = memory.Slice(1, 3); // slice contains { 2, 3, 4 }

            Console.WriteLine("Orginal Array :" + string.Join(',', array));
            memory.Span[0] = 10;

            slice.Span[0] = 20;
            for (int i = 0; i < memory.Length; i++)
            {
                Console.Write(memory.Span[i]+",");
            }
            Console.WriteLine();

            // Usage
            int[] data = { 1, 2, 3, 4, 5 };
            DataProcessor processor = new DataProcessor(data);
            processor.Process();
            processor.PrintData(); // Output: 2, 4, 6, 8, 10

        }
    }
}