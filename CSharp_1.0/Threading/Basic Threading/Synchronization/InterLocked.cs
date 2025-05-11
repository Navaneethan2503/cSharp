using System;
using System.Threading;
/**

The Interlocked class in C# is part of the System.Threading namespace and provides atomic operations for variables shared by multiple threads. This ensures thread safety when performing operations on shared variables. Here are some key details:

Overview:
---------
Purpose: The Interlocked class is used to perform atomic operations, which means the operations are completed as a single, indivisible step 1.
Atomic Operations: These operations prevent race conditions and ensure that the variable's value is updated correctly even when accessed by multiple threads simultaneously 1.

Key Methods:
------------
Increment(ref int): Atomically increments the specified variable by one1.
Decrement(ref int): Atomically decrements the specified variable by one 1.
Exchange(ref int, int): Sets a variable to a specified value and returns the original value 1.
CompareExchange(ref int, int, int): Compares two values and, if they are equal, replaces one of the values 1.
Add(ref int, int): Atomically adds a specified value to a variable 1.

Advantages:
-----------
Thread Safety: Ensures that operations on shared variables are performed safely without the need for explicit locks 2.
Performance: Generally faster than using locks because it avoids the overhead associated with locking mechanisms 2.

Limitations:
------------
Limited Scope: Only supports basic operations like increment, decrement, exchange, and compare-exchange 1.
Single Variable: Operations are limited to single variables and cannot be used for complex data structures 2.

Comparison with Other Synchronization Techniques:
--------------------------------------------------
Volatile: Ensures visibility of changes to variables across threads but does not provide atomicity 2.
Lock: Provides mutual exclusion but can be slower due to the overhead of acquiring and releasing locks 2.

Interlocked Class
-----------------

Provides atomic operations for variables that are shared by multiple threads.

    public static class Interlocked

Methods:
----------
Add(Int32, Int32)	- Adds two 32-bit integers and replaces the first integer with the sum, as an atomic operation.
Add(Int64, Int64)	- Adds two 64-bit integers and replaces the first integer with the sum, as an atomic operation.
Add(UInt32, UInt32)	- Adds two 32-bit unsigned integers and replaces the first integer with the sum, as an atomic operation.
Add(UInt64, UInt64)	- Adds two 64-bit unsigned integers and replaces the first integer with the sum, as an atomic operation.
And(Int32, Int32)	- Bitwise "ands" two 32-bit signed integers and replaces the first integer with the result, as an atomic operation.
And(Int64, Int64)	- Bitwise "ands" two 64-bit signed integers and replaces the first integer with the result, as an atomic operation.
And(UInt32, UInt32)	- Bitwise "ands" two 32-bit unsigned integers and replaces the first integer with the result, as an atomic operation.
And(UInt64, UInt64)	- Bitwise "ands" two 64-bit unsigned integers and replaces the first integer with the result, as an atomic operation.
CompareExchange(Byte, Byte, Byte)	- Compares two 8-bit unsigned integers for equality and, if they are equal, replaces the first value, as an atomic operation.
CompareExchange(Double, Double, Double)	- Compares two double-precision floating point numbers for equality and, if they are equal, replaces the first value, as an atomic operation.
CompareExchange(Int16, Int16, Int16)	- Compares two 16-bit unsigned integers for equality and, if they are equal, replaces the first value, as an atomic operation.
CompareExchange(Int32, Int32, Int32)	- Compares two 32-bit signed integers for equality and, if they are equal, replaces the first value, as an atomic operation.
CompareExchange(Int64, Int64, Int64)	- Compares two 64-bit signed integers for equality and, if they are equal, replaces the first value, as an atomic operation.
CompareExchange(IntPtr, IntPtr, IntPtr)	- Compares two platform-specific handles or pointers for equality and, if they are equal, replaces the first one, as an atomic operation.
CompareExchange(Object, Object, Object)	- Compares two objects for reference equality and, if they are equal, replaces the first object, as an atomic operation.
CompareExchange(SByte, SByte, SByte)	- Compares two 8-bit signed integers for equality and, if they are equal, replaces the first value, as an atomic operation.
CompareExchange(Single, Single, Single)	- Compares two single-precision floating point numbers for equality and, if they are equal, replaces the first value, as an atomic operation.
CompareExchange(UInt16, UInt16, UInt16)	- Compares two 16-bit signed integers for equality and, if they are equal, replaces the first value, as an atomic operation.
CompareExchange(UInt32, UInt32, UInt32)	- Compares two 32-bit unsigned integers for equality and, if they are equal, replaces the first value, as an atomic operation.
CompareExchange(UInt64, UInt64, UInt64)	- Compares two 64-bit unsigned integers for equality and, if they are equal, replaces the first value, as an atomic operation.
CompareExchange(UIntPtr, UIntPtr, UIntPtr)	- Compares two platform-specific handles or pointers for equality and, if they are equal, replaces the first one, as an atomic operation.
CompareExchange<T>(T, T, T)	- Compares two instances of the specified reference type T for reference equality and, if they are equal, replaces the first one, as an atomic operation.
Decrement(Int32)	- Decrements a specified variable and stores the result, as an atomic operation.
Decrement(Int64)	- Decrements the specified variable and stores the result, as an atomic operation.
Decrement(UInt32)	- Decrements a specified variable and stores the result, as an atomic operation.
Decrement(UInt64)	- Decrements a specified variable and stores the result, as an atomic operation.
Exchange(Byte, Byte)	- Sets a 8-bit unsigned integer to a specified value and returns the original value, as an atomic operation.
Exchange(Double, Double) - Sets a double-precision floating point number to a specified value and returns the original value, as an atomic operation.
Exchange(Int16, Int16)	- Sets a 16-bit unsigned integer to a specified value and returns the original value, as an atomic operation.
Exchange(Int32, Int32)	- Sets a 32-bit signed integer to a specified value and returns the original value, as an atomic operation.
Exchange(Int64, Int64)	- Sets a 64-bit signed integer to a specified value and returns the original value, as an atomic operation.
Exchange(IntPtr, IntPtr)	- Sets a platform-specific handle or pointer to a specified value and returns the original value, as an atomic operation.
Exchange(Object, Object)	- Sets an object to a specified value and returns a reference to the original object, as an atomic operation.
Exchange(SByte, SByte)	- Sets a 8-bit signed integer to a specified value and returns the original value, as an atomic operation.
Exchange(Single, Single)	- Sets a single-precision floating point number to a specified value and returns the original value, as an atomic operation.
Exchange(UInt16, UInt16)	- Sets a 16-bit signed integer to a specified value and returns the original value, as an atomic operation.
Exchange(UInt32, UInt32)	- Sets a 32-bit unsigned integer to a specified value and returns the original value, as an atomic operation
Exchange(UInt64, UInt64)	- Sets a 64-bit unsigned integer to a specified value and returns the original value, as an atomic operation.
Exchange(UIntPtr, UIntPtr)	-Sets a platform-specific handle or pointer to a specified value and returns the original value, as an atomic operation.
Exchange<T>(T, T)	- Sets a variable of the specified type T to a specified value and returns the original value, as an atomic operation.
Increment(Int32)	- Increments a specified variable and stores the result, as an atomic operation.
Increment(Int64)	- Increments a specified variable and stores the result, as an atomic operation.
Increment(UInt32)	- Increments a specified variable and stores the result, as an atomic operation.
Increment(UInt64)	- Increments a specified variable and stores the result, as an atomic operation.
MemoryBarrier()	- Synchronizes memory access as follows: The processor that executes the current thread cannot reorder instructions in such a way that memory accesses before the call to MemoryBarrier() execute after memory accesses that follow the call to MemoryBarrier().
MemoryBarrierProcessWide()	- Provides a process-wide memory barrier that ensures that reads and writes from any CPU cannot move across the barrier.
Or(Int32, Int32)	- Bitwise "ors" two 32-bit signed integers and replaces the first integer with the result, as an atomic operation.
Or(Int64, Int64)	- Bitwise "ors" two 64-bit signed integers and replaces the first integer with the result, as an atomic operation.
Or(UInt32, UInt32)	- Bitwise "ors" two 32-bit unsigned integers and replaces the first integer with the result, as an atomic operation.
Or(UInt64, UInt64)	- Bitwise "ors" two 64-bit unsigned integers and replaces the first integer with the result, as an atomic operation.
Read(Int64)	- Returns a 64-bit value, loaded as an atomic operation.
Read(UInt64)	- Returns a 64-bit unsigned value, loaded as an atomic operation.


**/
namespace ThreadingSynronization{
    class InterLockedClass{

        private static int _counter = 0;

        public static void Main(){
            Console.WriteLine("InterLocked Synchronization Class.");
            Thread thread1 = new Thread(IncrementCounter);
            Thread thread2 = new Thread(IncrementCounter);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Final counter value: {_counter}");
        }

        static void IncrementCounter()
        {
            for (int i = 0; i < 1000; i++)
            {
                Interlocked.Increment(ref _counter);
            }
        }

    }
}

