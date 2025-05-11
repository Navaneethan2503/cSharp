using System;
using System.Threading;
/**

The Lock class in C# is part of the System.Threading namespace and provides a mechanism for achieving mutual exclusion in regions of code between different threads. Here are some key details:

Overview
Purpose: The Lock class is used to define critical sections, ensuring that only one thread can access a resource at a time 1.
Mutual Exclusion: It prevents concurrent accesses to a resource, which is essential for thread safety 1.

Key Methods
Enter(): Acquires the lock, marking the beginning of a critical section 1.
Exit(): Releases the lock, marking the end of the critical section 1.
TryEnter(): Attempts to acquire the lock within a specified timeout1.
EnterScope(): Provides a scope for the lock, ensuring it is released even if an exception occurs 1.

he lock statement acquires the mutual-exclusion lock for a given object, executes a statement block, and then releases the lock. While a lock is held, the thread that holds the lock can again acquire and release the lock. Any other thread is blocked from acquiring the lock and waits until the lock is released. The lock statement ensures that at maximum only one thread executes its body at any moment in time.

The lock statement takes the following form:
lock (x)
{
    // Your code...
}
The variable x is an expression of System.Threading.Lock type

Differences Between Lock and Monitor
Lock: Provides a more structured approach with methods like EnterScope that automatically handle exceptions 1.
Monitor: Offers more granular control with methods like Wait, Pulse, and PulseAll 2.

Best Practices
Dedicated Lock Object: Use a dedicated instance of the Lock class for best performance and to avoid deadlocks 2.
Avoid Common Objects: Do not use common objects like this, type instances, or string literals as lock objects 2.

Lock Class:
-----------

Provides a mechanism for achieving mutual exclusion in regions of code between different threads.

    public sealed class Lock

Constructors:
------------
Lock()	- Initializes a new instance of the Lock class.

Properties:
------------
IsHeldByCurrentThread	- Gets a value that indicates whether the lock is held by the current thread.

Methods:
---------
Enter()	- Enters the lock, waiting if necessary until the lock can be entered.
EnterScope()	- Enters the lock, waiting if necessary until the lock can be entered.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Exit()	- Exits the lock.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryEnter()	- Tries to enter the lock without waiting.
TryEnter(Int32)	- Tries to enter the lock, waiting if necessary for the specified number of milliseconds until the lock can be entered.
TryEnter(TimeSpan)	- Tries to enter the lock, waiting if necessary until the lock can be entered or until the specified timeout expires.


**/
namespace ThreadingSynronization{
    class LockClass{
        private static readonly Lock _lockObj = new Lock();

        public static void Modify()
        {
            lock (_lockObj)
            {
                // Critical section associated with _lockObj
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} is working");
                Thread.Sleep(1000); // Simulate work
            }
        }

        public static void Main(){
            Console.WriteLine("Lock Synconization .");
            Thread t1 = new Thread(new ThreadStart(Modify));
            Thread t2 = new Thread(new ThreadStart(Modify));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();


        }
    }
}


