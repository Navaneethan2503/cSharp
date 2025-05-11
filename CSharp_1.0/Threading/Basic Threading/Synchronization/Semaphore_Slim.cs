using System;
using System.Threading;
using System.Threading.Tasks;

/**
🧠 Semaphore:
---------------
🔄 What is a Semaphore?:
-------------------------
A Semaphore limits the number of threads that can access a resource or pool of resources concurrently.
It uses a counter to keep track of how many threads can access the resource at the same time.

🛠️ Basic Usage:
----------------
Initialization: Set the initial and maximum count.
WaitOne(): Decrements the counter and blocks if the counter is zero.
Release(): Increments the counter and releases a blocked thread if any.

Key Points:
------------
Interprocess Synchronization: Can be used across multiple processes.
Named Semaphores: Can be named and shared across processes

🧠 SemaphoreSlim:
-----------------
🔄 What is SemaphoreSlim?
---------------------------
SemaphoreSlim is a lightweight alternative to Semaphore.
It is designed for use within a single application and does not use Windows kernel semaphores.

🛠️ Basic Usage:
----------------
Initialization: Set the initial and maximum count.
Wait() / WaitAsync(): Decrements the counter and blocks if the counter is zero.
Release(): Increments the counter and releases a blocked thread if any.

Key Points:
-----------
Lightweight: Less overhead compared to Semaphore.
Single Application: Designed for use within a single application 3 4.
Async Support: Supports asynchronous operations with WaitAsync()

SemaphoreSlim relies as much as possible on synchronization primitives provided by the common language runtime (CLR). However, it also provides lazily initialized, kernel-based wait handles as necessary to support waiting on multiple semaphores. SemaphoreSlim also supports the use of cancellation tokens, but it does not support named semaphores or the use of a wait handle for synchronization.


Feature	Semaphore	SemaphoreSlim
Scope	Multiple processes	Single application
Overhead	Higher (uses kernel objects)	Lower (lightweight)
Async Support	No	Yes
Named Semaphores	Yes	No


Managing a Limited Resource:
-----------------------------
Threads enter the semaphore by calling the WaitOne method, which is inherited from the WaitHandle class, in the case of a System.Threading.Semaphore object, or the SemaphoreSlim.Wait or SemaphoreSlim.WaitAsync method, in the case of a SemaphoreSlim object. When the call returns, the count on the semaphore is decremented. When a thread requests entry and the count is zero, the thread blocks. As threads release the semaphore by calling the Semaphore.Release or SemaphoreSlim.Release method, blocked threads are allowed to enter. There is no guaranteed order, such as first-in, first-out (FIFO) or last-in, first-out (LIFO), for blocked threads to enter the semaphore.

A thread can enter the semaphore multiple times by calling the System.Threading.Semaphore object's WaitOne method or the SemaphoreSlim object's Wait method repeatedly. To release the semaphore, the thread can either call the Semaphore.Release() or SemaphoreSlim.Release() method overload the same number of times, or call the Semaphore.Release(Int32) or SemaphoreSlim.Release(Int32) method


Semaphore Class:
---------------
Limits the number of threads that can access a resource or pool of resources concurrently.
    public sealed class Semaphore : System.Threading.WaitHandle

Constructors:
--------------
Semaphore(Int32, Int32, String, Boolean) - Initializes a new instance of the Semaphore class, specifying the initial number of entries and the maximum number of concurrent entries, optionally specifying the name of a system semaphore object, and specifying a variable that receives a value indicating whether a new system semaphore was created.
Semaphore(Int32, Int32, String)	- Initializes a new instance of the Semaphore class, specifying the initial number of entries and the maximum number of concurrent entries, and optionally specifying the name of a system semaphore object.
Semaphore(Int32, Int32)	- Initializes a new instance of the Semaphore class, specifying the initial number of entries and the maximum number of concurrent entries.

Methods:
--------
OpenExisting(String)	- Opens the specified named semaphore, if it already exists.
Release()	- Exits the semaphore and returns the previous count.
Release(Int32)	- Exits the semaphore a specified number of times and returns the previous count.
TryOpenExisting(String, Semaphore)	- Opens the specified named semaphore, if it already exists, and returns a value that indicates whether the operation succeeded.
WaitOne()	- Blocks the current thread until the current WaitHandle receives a signal.(Inherited from WaitHandle)
WaitOne(Int32, Boolean)	- Blocks the current thread unil the current WaitHandle receives a signal, using a 32-bit signed integer to specify the time interval and specifying whether to exit the synchronization domain before the wait.(Inherited from WaitHandle)
WaitOne(Int32)	- Blocks the current thread until the current WaitHandle receives a signal, using a 32-bit signed integer to specify the time interval in milliseconds.(Inherited from WaitHandle)
WaitOne(TimeSpan, Boolean)	- Blocks the current thread until the current instance receives a signal, using a TimeSpan to specify the time interval and specifying whether to exit the synchronization domain before the wait.(Inherited from WaitHandle)
WaitOne(TimeSpan)	- Blocks the current thread until the current instance receives a signal, using a TimeSpan to specify the time interval.(Inherited from WaitHandle)



SemaphoreSlim Class:
--------------------
Represents a lightweight alternative to Semaphore that limits the number of threads that can access a resource or pool of resources concurrently.

public class SemaphoreSlim : IDisposable

Constructors:
-------------
SemaphoreSlim(Int32, Int32)	- Initializes a new instance of the SemaphoreSlim class, specifying the initial and maximum number of requests that can be granted concurrently.
SemaphoreSlim(Int32)	- Initializes a new instance of the SemaphoreSlim class, specifying the initial number of requests that can be granted concurrently.

Methods:
--------
Release()	- Releases the SemaphoreSlim object once.
Release(Int32)	- Releases the SemaphoreSlim object a specified number of times.
Wait() - Blocks the current thread until it can enter the SemaphoreSlim.
Wait(CancellationToken)	- Blocks the current thread until it can enter the SemaphoreSlim, while observing a CancellationToken.
Wait(Int32, CancellationToken)	- Blocks the current thread until it can enter the SemaphoreSlim, using a 32-bit signed integer that specifies the timeout, while observing a CancellationToken.
Wait(Int32)	- Blocks the current thread until it can enter the SemaphoreSlim, using a 32-bit signed integer that specifies the timeout.
Wait(TimeSpan, CancellationToken)	- Blocks the current thread until it can enter the SemaphoreSlim, using a TimeSpan that specifies the timeout, while observing a CancellationToken.
Wait(TimeSpan)	- Blocks the current thread until it can enter the SemaphoreSlim, using a TimeSpan to specify the timeout.
WaitAsync()	- Asynchronously waits to enter the SemaphoreSlim.
WaitAsync(CancellationToken)	- Asynchronously waits to enter the SemaphoreSlim, while observing a CancellationToken.
WaitAsync(Int32, CancellationToken)	- Asynchronously waits to enter the SemaphoreSlim, using a 32-bit signed integer to measure the time interval, while observing a CancellationToken.
WaitAsync(Int32)	- Asynchronously waits to enter the SemaphoreSlim, using a 32-bit signed integer to measure the time interval.
WaitAsync(TimeSpan, CancellationToken)	- Asynchronously waits to enter the SemaphoreSlim, using a TimeSpan to measure the time interval, while observing a CancellationToken.
WaitAsync(TimeSpan)	- Asynchronously waits to enter the SemaphoreSlim, using a TimeSpan to measure the time interval.


**/
namespace ThreadingSynronization{
    class Semaphore_SemaphoreSlim{
        static Semaphore semaphore = new Semaphore(3, 3); // Initial and max count of 3

        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3, 3); // Initial and max count of 3

        public async static Task Main(){
            Console.WriteLine("Semaphore and Semaphore Slim.");
            for (int i = 0; i < 5; i++)
            {
                new Thread(Worker).Start(i);
            }

            //Semaphore Slim
            for (int i = 0; i < 5; i++)
            {
                int id = i;
                Task.Run(() => Worker(id));
            }

            await Task.Delay(5000); // Wait for all tasks to complete
        }

        static async Task Worker(int id)
        {
            Console.WriteLine($"Task {id} waiting to enter...");
            await semaphoreSlim.WaitAsync(); // Wait for the semaphore
            Console.WriteLine($"Task {id} entered");
            await Task.Delay(1000); // Simulate work
            Console.WriteLine($"Task {id} leaving");
            semaphoreSlim.Release(); // Release the semaphore
        }

        static void Worker(object id)
        {
            Console.WriteLine($"Thread {id} waiting to enter...");
            semaphore.WaitOne(); // Wait for the semaphore
            Console.WriteLine($"Thread {id} entered");
            Thread.Sleep(1000); // Simulate work
            Console.WriteLine($"Thread {id} leaving");
            semaphore.Release(); // Release the semaphore
        }

    }
}

