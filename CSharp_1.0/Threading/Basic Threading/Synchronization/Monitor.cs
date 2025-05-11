using System;
using System.Threading;
/**
the Monitor class in C# is part of the System.Threading namespace and is used to synchronize access to objects in a multithreaded environment. Here are some key details:

Overview
Purpose: The Monitor class allows you to restrict access to a block of code, known as a critical section, ensuring that only one thread can execute the code at a time 1.
Static Methods: All methods in the Monitor class are static, meaning you don't create an instance of Monitor 1.

Key Methods
Enter(Object): Acquires an exclusive lock on the specified object, marking the beginning of a critical section 1.
Exit(Object): Releases the lock on the specified object, marking the end of the critical section 2.
TryEnter(Object, TimeSpan): Attempts to acquire a lock on the specified object within a given time span 2.
Wait(Object): Releases the lock on an object and blocks the current thread until it reacquires the lock 2.
Pulse(Object): Sends a signal to a waiting thread, notifying it of a change in the locked object's state 2.
PulseAll(Object): Sends a signal to all waiting threads1.

Limitations
Thread Affinity: The thread that acquires the lock must release it 1.
Complexity: More complex than using the lock keyword, but offers greater flexibility 2.

Differences Between Monitor and lock
Monitor: Provides more control with methods like Wait, Pulse, and PulseAll 3.
lock: A simpler syntax for acquiring and releasing locks, essentially a shorthand for Monitor.Enter and Monitor.Exit 3.

Monitor Class:
---------------
Provides a mechanism that synchronizes access to objects.

public static class Monitor

Properties:
------------
LockContentionCount	- Gets the number of times there was contention when trying to take the monitor's lock.

Methods:
--------
Enter(Object, Boolean)	- Acquires an exclusive lock on the specified object, and atomically sets a value that indicates whether the lock was taken.
Enter(Object)	- Acquires an exclusive lock on the specified object.
Exit(Object)	- Releases an exclusive lock on the specified object.
IsEntered(Object)	- Determines whether the current thread holds the lock on the specified object.
Pulse(Object)	- Notifies a thread in the waiting queue of a change in the locked object's state.
PulseAll(Object)	- Notifies all waiting threads of a change in the object's state.
TryEnter(Object, Boolean)	- Attempts to acquire an exclusive lock on the specified object, and atomically sets a value that indicates whether the lock was taken.
TryEnter(Object, Int32, Boolean)	- Attempts, for the specified number of milliseconds, to acquire an exclusive lock on the specified object, and atomically sets a value that indicates whether the lock was taken.
TryEnter(Object, Int32)	- Attempts, for the specified number of milliseconds, to acquire an exclusive lock on the specified object.
TryEnter(Object, TimeSpan, Boolean)	- Attempts, for the specified amount of time, to acquire an exclusive lock on the specified object, and atomically sets a value that indicates whether the lock was taken.
TryEnter(Object, TimeSpan)	- Attempts, for the specified amount of time, to acquire an exclusive lock on the specified object.
TryEnter(Object)	- Attempts to acquire an exclusive lock on the specified object.
Wait(Object, Int32, Boolean)	- Releases the lock on an object and blocks the current thread until it reacquires the lock. If the specified time-out interval elapses, the thread enters the ready queue. This method also specifies whether the synchronization domain for the context (if in a synchronized context) is exited before the wait and reacquired afterward.
Wait(Object, Int32)	- Releases the lock on an object and blocks the current thread until it reacquires the lock. If the specified time-out interval elapses, the thread enters the ready queue.
Wait(Object, TimeSpan, Boolean)	- Releases the lock on an object and blocks the current thread until it reacquires the lock. If the specified time-out interval elapses, the thread enters the ready queue. Optionally exits the synchronization domain for the synchronized context before the wait and reacquires the domain afterward.
Wait(Object, TimeSpan)	- Releases the lock on an object and blocks the current thread until it reacquires the lock. If the specified time-out interval elapses, the thread enters the ready queue.
Wait(Object)	- Releases the lock on an object and blocks the current thread until it reacquires the lock.


**/
namespace ThreadingSynronization{
    class MonitorClass{
        private static readonly object _lockObject = new object();

        public static void Main(){
            Console.WriteLine("Monitor Synchronization class.");

            Thread thread1 = new Thread(DoWork);
            Thread thread2 = new Thread(DoWork);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

        }

        static void DoWork()
        {
            Monitor.Enter(_lockObject);
            try
            {
                // Critical section
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} is working");
                Thread.Sleep(1000); // Simulate work
            }
            finally
            {
                Monitor.Exit(_lockObject);
            }
        }

    }
}

