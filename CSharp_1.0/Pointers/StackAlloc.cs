using System;
/**
A stackalloc expression allocates a block of memory on the stack. A stack-allocated memory block created during the method execution is automatically discarded when that method returns. You can't explicitly free the memory allocated with stackalloc. A stack allocated memory block isn't subject to garbage collection and doesn't have to be pinned with a fixed statement.

You can assign the result of a stackalloc expression to a variable of one of the following types:

System.Span<T> or System.ReadOnlySpan<T>,

The amount of memory available on the stack is limited. If you allocate too much memory on the stack, a StackOverflowException is thrown. To avoid that, follow the rules below:

Limit the amount of memory you allocate with stackalloc. For example, if the intended buffer size is below a certain limit, you allocate the memory on the stack; otherwise, use an array of the required length, as the following code shows:

Because the amount of memory available on the stack depends on the environment in which the code is executed, be conservative when you define the actual limit value.

Avoid using stackalloc inside loops. Allocate the memory block outside a loop and reuse it inside the loop.

The content of the newly allocated memory is undefined. You should initialize it, either with a stackalloc initializer, or a method like Span<T>.Clear before it's used.

Not initializing memory allocated by stackalloc is an important difference from the new operator. Memory allocated using the new operator is initialized to the 0 bit pattern

Security
The use of stackalloc automatically enables buffer overrun detection features in the common language runtime (CLR). If a buffer overrun is detected, the process is terminated as quickly as possible to minimize the chance that malicious code is executed.


**/
namespace Pointers{
    class StackAlloc{
        public static void Main(){
            Console.WriteLine("StackAlloc Expression.");
            int length = 3;
            Span<int> numbers = stackalloc int[length];
            for (var i = 0; i < length; i++){
                numbers[i] = i;
                Console.Write(numbers[i]+",");
            }
            Console.WriteLine();

            //You don't have to use an unsafe context when you assign a stack allocated memory block to a Span<T> or ReadOnlySpan<T> variable.

            //When you work with those types, you can use a stackalloc expression in conditional or assignment expressions
            //int length = 1000;
            Span<byte> buffer = length <= 1024 ? stackalloc byte[length] : new byte[length];

            //you can use a stackalloc expression or a collection expression inside other expressions whenever a Span<T> or ReadOnlySpan<T> variable is allowed,
            //You can use array initializer syntax to define the content of the newly allocated memory.
            Span<int> numbers1 = stackalloc[] { 1, 2, 3, 4, 5, 6 };
            var ind = numbers1.IndexOfAny(stackalloc[] { 2, 4, 6, 8 });
            Console.WriteLine(ind);  // output: 1

            Span<int> numbers2 = [1, 2, 3, 4, 5, 6];
            var ind2 = numbers2.IndexOfAny([2, 4, 6, 8]);
            Console.WriteLine(ind2);  // output: 1

            //A pointer type,
            unsafe
            {
                //int length = 3;
                int* numbers3 = stackalloc int[length];
                for (var i = 0; i < length; i++)
                {
                    numbers3[i] = i;
                }
            }
        }
    }
}