using System;
using System.Threading;
/**
A SpinLock is a low-level synchronization primitive that can be used to manage access to a resource by multiple threads. Unlike traditional locks, a SpinLock repeatedly checks if the lock is available, "spinning" in a loop until it can acquire the lock.

🧠 Key Concepts
🔄 What is a SpinLock?:
------------------------
SpinLock is a mutual exclusion lock that spins while waiting to acquire the lock.
It is designed for scenarios where wait times are expected to be short and contention is minimal.
On multicore systems, SpinLock can perform better than other locks because it avoids context switching 1.

🛠️ Basic Usage:
-----------------
Initialization: Create a SpinLock instance.
Enter(): Attempts to acquire the lock.
Exit(): Releases the lock.

🧩 Advanced Features:
-----------------------
1. Thread-Tracking Mode
Helps track which thread holds the lock at a specific time.
Useful for debugging but can slow performance.

2. Avoiding Thread-Priority Inversion
SpinLock may yield the time slice of the thread even if it has not yet acquired the lock.
This helps avoid thread-priority inversion and allows the garbage collector to make progress.

3. Performance Considerations
SpinLock is beneficial when the critical section performs minimal work.
For longer critical sections, traditional locks like Monitor or Mutex may be more efficient .

SpinLock Struct:
----------------
Provides a mutual exclusion lock primitive where a thread trying to acquire the lock waits in a loop repeatedly checking until the lock becomes available.

    public struct SpinLock

Constructors:
---------------
SpinLock(Boolean)	- Initializes a new instance of the SpinLock structure with the option to track thread IDs to improve debugging.

Properties:
-----------
IsHeld	- Gets whether the lock is currently held by any thread.
IsHeldByCurrentThread	- Gets whether the lock is held by the current thread.
IsThreadOwnerTrackingEnabled	- Gets whether thread ownership tracking is enabled for this instance.

Methods:
---------
Enter(Boolean)	- Acquires the lock in a reliable manner, such that even if an exception occurs within the method call, lockTaken can be examined reliably to determine whether the lock was acquired.
Exit()	- Releases the lock.
Exit(Boolean)	- Releases the lock.
TryEnter(Boolean)	- Attempts to acquire the lock in a reliable manner, such that even if an exception occurs within the method call, lockTaken can be examined reliably to determine whether the lock was acquired.
TryEnter(Int32, Boolean)	- Attempts to acquire the lock in a reliable manner, such that even if an exception occurs within the method call, lockTaken can be examined reliably to determine whether the lock was acquired.
TryEnter(TimeSpan, Boolean)	- Attempts to acquire the lock in a reliable manner, such that even if an exception occurs within the method call, lockTaken can be examined reliably to determine whether the lock was acquired.

In general, while holding a spin lock, one should avoid any of these actions:
    blocking,
    calling anything that itself may block,
    holding more than one spin lock at once,
    making dynamically dispatched calls (interface and virtuals),
    making statically dispatched calls into any code one doesn't own, or
    allocating memory.

SpinLock should only be used after you have been determined that doing so will improve an application's performance. It is also important to note that SpinLock is a value type, for performance reasons. 
For this reason, you must be very careful not to accidentally copy a SpinLock instance, as the two instances (the original and the copy) would then be completely independent of one another, which would likely lead to erroneous behavior of the application. 
If a SpinLock instance must be passed around, it should be passed by reference rather than by value.

Do not store SpinLock instances in readonly fields.


**/
namespace ThreadingSynronization{
    class SpinLockClass{
        static SpinLock spinLock = new SpinLock();

        public static void Main(){
            Console.WriteLine("SpinLock Synchronization.");
            for (int i = 0; i < 5; i++)
            {
                new Thread(Worker).Start(i);
            }

            // Wait for all threads to complete
            Console.ReadLine();
        }

        static void Worker(object id)
        {
            bool lockTaken = false;
            try
            {
                spinLock.Enter(ref lockTaken); // Attempt to acquire the lock
                Console.WriteLine($"Thread {id} acquired the lock");
                Thread.Sleep(1000); // Simulate work
            }
            finally
            {
                if (lockTaken)
                {
                    spinLock.Exit(); // Release the lock
                    Console.WriteLine($"Thread {id} released the lock");
                }
            }
        }

    }
}


