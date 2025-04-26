using System;
using System.Buffers;
/**

.NET includes a number of types that represent an arbitrary contiguous region of memory. Span<T> and ReadOnlySpan<T> are lightweight memory buffers that wrap references to managed or unmanaged memory. Because these types can only be stored on the stack, they're unsuitable for scenarios such as asynchronous method calls. To address this problem, .NET 2.1 added some additional types, including Memory<T>, ReadOnlyMemory<T>, IMemoryOwner<T>, and MemoryPool<T>. Like Span<T>, Memory<T> and its related types can be backed by both managed and unmanaged memory. Unlike Span<T>, Memory<T> can be stored on the managed heap.

Both Span<T> and Memory<T> are wrappers over buffers of structured data that can be used in pipelines. That is, they're designed so that some or all of the data can be efficiently passed to components in the pipeline, which can process them and optionally modify the buffer. Because Memory<T> and its related types can be accessed by multiple components or by multiple threads, it's important to follow some standard usage guidelines to produce robust code.

Owners, consumers, and lifetime management:
-------------------------------------------
Buffers can be passed around between APIs and can sometimes be accessed from multiple threads, so be aware of how a buffer's lifetime is managed. There are three core concepts:
Ownership - The owner of a buffer instance is responsible for lifetime management, including destroying the buffer when it's no longer in use. All buffers have a single owner. Generally the owner is the component that created the buffer or that received the buffer from a factory. Ownership can also be transferred; Component-A can relinquish control of the buffer to Component-B, at which point Component-A may no longer use the buffer, and Component-B becomes responsible for destroying the buffer when it's no longer in use.
Consumption - The consumer of a buffer instance is allowed to use the buffer instance by reading from it and possibly writing to it. Buffers can have one consumer at a time unless some external synchronization mechanism is provided. The active consumer of a buffer isn't necessarily the buffer's owner.
Lease - The lease is the length of time that a particular component is allowed to be the consumer of the buffer.


The following are our recommendations for successfully using Memory<T> and its related types. Guidance that applies to Memory<T> and Span<T> also applies to ReadOnlyMemory<T> and ReadOnlySpan<T> unless noted otherwise.

Rule #1: For a synchronous API, use Span<T> instead of Memory<T> as a parameter if possible
Rule #2: Use ReadOnlySpan<T> or ReadOnlyMemory<T> if the buffer should be read-only
Rule #3: If your method accepts Memory<T> and returns void, you must not use the Memory<T> instance after your method returns
Rule #4: If your method accepts a Memory<T> and returns a Task, you must not use the Memory<T> instance after the Task transitions to a terminal state
Rule #5: If your constructor accepts Memory<T> as a parameter, instance methods on the constructed object are assumed to be consumers of the Memory<T> instance
Rule #6: If you have a settable Memory<T>-typed property (or an equivalent instance method) on your type, instance methods on that object are assumed to be consumers of the Memory<T> instance
Rule #7: If you have an IMemoryOwner<T> reference, you must at some point dispose of it or transfer its ownership (but not both)
Rule #8: If you have an IMemoryOwner<T> parameter in your API surface, you are accepting ownership of that instance
Rule #9: If you're wrapping a synchronous P/Invoke method, your API should accept Span<T> as a parameter
Rule #10: If you're wrapping an asynchronous p/invoke method, your API should accept Memory<T> as a parameter





**/
namespace SpanMemoryUsageGuidelines{
    class SpanMemoryUsageGuidelinesClass{
        public static void Main(){
            Console.WriteLine("Span and Memory Usage Guidelines.");
            IMemoryOwner<char> owner = MemoryPool<char>.Shared.Rent();

            Console.Write("Enter a number: ");
            try
            {
                string? s = Console.ReadLine();

                if (s is null)
                    return;

                var value = Int32.Parse(s);

                var memory = owner.Memory;

                WriteInt32ToBuffer(value, memory);

                DisplayBufferToConsole(owner.Memory.Slice(0, value.ToString().Length));
            }
            catch (FormatException)
            {
                Console.WriteLine("You did not enter a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"You entered a number less than {Int32.MinValue:N0} or greater than {Int32.MaxValue:N0}.");
            }
            finally
            {
                owner?.Dispose();
            }

        }

        static void WriteInt32ToBuffer(int value, Memory<char> buffer)
        {
            var strValue = value.ToString();

            var span = buffer.Span;
            for (int ctr = 0; ctr < strValue.Length; ctr++)
                span[ctr] = strValue[ctr];
        }

        static void DisplayBufferToConsole(Memory<char> buffer) =>
            Console.WriteLine($"Contents of the buffer: '{buffer}'");
    }
}