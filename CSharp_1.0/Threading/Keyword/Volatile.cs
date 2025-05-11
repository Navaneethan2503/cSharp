using System;
using System.Threading;
/**
The volatile keyword in C# is used to indicate that a field might be modified by multiple threads that are executing simultaneously. This ensures that the field is always read from and written to main memory, preventing the compiler, runtime system, and hardware from applying certain optimizations that could lead to inconsistent results in a multithreaded environment 1.

Overview
Purpose: The volatile keyword ensures that the most recent value of a field is always read from memory, rather than from a cached value 1.
Usage: It can be applied to fields of certain types, including reference types, pointer types (in unsafe contexts), simple types like int, bool, char, and float, and enum types with specific base types 1.

Key Characteristics
Memory Visibility: Ensures that changes to the field are immediately visible to all threads 1.
No Atomicity: Does not guarantee atomicity for complex operations; for atomic operations, use the Interlocked class 1.
Limited Types: Cannot be applied to fields of types like double and long because reads and writes to these types cannot be guaranteed to be atomic 1.

When to Use volatile
Simple Flags: Ideal for simple flags that indicate state changes 2.
Avoiding Locks: Useful when you want to avoid the overhead of locks for simple state checks 2.

Limitations
Complex Operations: Not suitable for complex operations that require atomicity 1.
Performance: May not be as performant as other synchronization mechanisms for complex scenarios 2.
Comparison with Other Synchronization Techniques
Interlocked: Provides atomic operations for variables, ensuring thread safety without locks 1.
Lock: Ensures mutual exclusion but can be slower due to the overhead of acquiring and releasing locks


Volatile Class:
--------------

Contains methods for performing volatile memory operations.

    public static class Volatile

Methods:
---------
Read(Boolean) - Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(Byte)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(Double)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(Int16)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(Int32)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(Int64)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(IntPtr)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(SByte)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(Single)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(UInt16)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(UInt32)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(UInt64)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read(UIntPtr)	- Reads the value of the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Read<T>(T)	- Reads the object reference from the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears after this method in the code, the processor cannot move it before this method.
Write(Boolean, Boolean)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(Byte, Byte)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(Double, Double)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(Int16, Int16)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(Int32, Int32)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(Int64, Int64)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(IntPtr, IntPtr)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(SByte, SByte)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(Single, Single)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(UInt16, UInt16)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(UInt32, UInt32)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(UInt64, UInt64)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write(UIntPtr, UIntPtr)	- Writes the specified value to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.
Write<T>(T, T)	- Writes the specified object reference to the specified field. On systems that require it, inserts a memory barrier that prevents the processor from reordering memory operations as follows: If a read or write appears before this method in the code, the processor cannot move it after this method.


**/
namespace ThreadingKeyword{
    public class Worker
    {
        private volatile bool _shouldStop;

        public void DoWork()
        {
            while (!_shouldStop)
            {
                // Simulate some work
                Console.WriteLine("Working...");
                Thread.Sleep(100);
            }
            Console.WriteLine("Worker thread: terminating gracefully.");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }
    }

    class VolatileClass{
        public static void Main(){
            Console.WriteLine("Volatile Keyword .");
            Worker worker = new Worker();
            Thread workerThread = new Thread(worker.DoWork);

            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

            // Let the worker thread run for a while
            Thread.Sleep(500);

            // Request the worker thread to stop
            worker.RequestStop();

            // Wait for the worker thread to finish
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
        }
    }
}



