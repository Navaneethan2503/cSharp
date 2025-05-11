using System;
using System.Threading;

/**
SpinWait is a lightweight synchronization primitive in C# that can be used in low-level scenarios to avoid the expensive context switches and kernel transitions required for kernel events. It is part of the System.Threading namespace and is designed to be used when a resource is expected to be held for a short period of time1.

🧠 Key Concepts
🔄 What is SpinWait?
-----------------------
SpinWait repeatedly checks if a resource is available, "spinning" in a loop until it can acquire the resource.
It is useful for scenarios where the wait time is expected to be very short.
SpinWait combines spinning with yielding to balance CPU usage and responsiveness 1.

🛠️ Basic Usage:
---------------
Initialization: Create a SpinWait instance.
SpinOnce(): Spins once and checks if the resource is available.
NextSpinWillYield: Indicates if the next spin will yield the thread's time slice.

Key Points:
------------
SpinWait is a value type, meaning it avoids unnecessary allocation overheads 2.
It is designed to be used in conjunction with other synchronization primitives like ManualResetEvent 1.

🧩 Advanced Features:
---------------------
1. Two-Phase Wait Operation
SpinWait can be used in a two-phase wait operation, where it spins for a short time and then switches to a kernel-based wait if the resource is still not available 1.
This approach balances CPU usage and responsiveness.
2. Context Switching
SpinWait initiates context switches if it spins for too long, preventing the waiting thread from blocking higher-priority threads or the garbage collector1.
3. Single-Core and Multi-Core Behavior
On single-core systems, SpinWait yields the time slice immediately to avoid blocking progress on all threads.
On multi-core systems, SpinWait can spin for a few dozen or hundred cycles before yielding1.

 Comparison
Feature	SpinWait	SpinLock
Purpose	Spinning until a condition is met	Mutual exclusion lock
Usage	Short wait times, minimal contention	Short critical sections, minimal contention
Type	Value type	Value type
Thread Affinity	N/A	Must be released by the owning thread
Context Switching	Initiates context switches if spinning too long	Spins in a loop until lock is acquired

SpinWait Struct:
---------------

Provides support for spin-based waiting.

public struct SpinWait

Properties:
------------
Count	- Gets the number of times SpinOnce() has been called on this instance.
NextSpinWillYield	- Gets whether the next call to SpinOnce() will yield the processor, triggering a forced context switch.

Methods:
--------
Reset()	- Resets the spin counter.
SpinOnce()	- Performs a single spin.
SpinOnce(Int32)	- Performs a single spin and calls Sleep(Int32) after a minimum spin count.
SpinUntil(Func<Boolean>, Int32)	- Spins until the specified condition is satisfied or until the specified timeout is expired.
SpinUntil(Func<Boolean>, TimeSpan)	- Spins until the specified condition is satisfied or until the specified timeout is expired.
SpinUntil(Func<Boolean>)	- Spins until the specified condition is satisfied.


**/
namespace ThreadingSynronization{
    class SpinWaitClass{
        static volatile bool resourceAvailable = false;

        public static void Main(){
            Console.WriteLine("Spin Wait Synchronization.");

            Thread workerThread = new Thread(Worker);
            workerThread.Start();

            // Simulate some work
            Thread.Sleep(1000);
            resourceAvailable = true; // Make the resource available

            workerThread.Join();
            
        }

        static void Worker()
        {
            SpinWait spinWait = new SpinWait();
            while (!resourceAvailable)
            {
                spinWait.SpinOnce(); // Spin until the resource is available
            }
            Console.WriteLine("Resource acquired");
        }

    }
}

