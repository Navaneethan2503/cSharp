using System;
using System.Threading;
/**
A Mutex (short for mutual exclusion) is a synchronization primitive that can be used to manage access to a resource across multiple threads or even across different processes.

🧠 Key Concepts:
----------------
🔄 What is a Mutex?:
-------------------
A Mutex ensures that only one thread can access a resource at a time.
It can be used for interprocess synchronization, meaning it can synchronize threads across different processes.

🛠️ Types of Mutexes
---------------------
Local Mutex:
--------------
Exists only within your process.
Can be used by any thread in your process that has a reference to the Mutex object.

Named System Mutex
-------------------
Associated with an operating-system object of a given name.
Visible throughout the operating system and can be used to synchronize activities of different processes .

🧩 Key Features
1. Thread Affinity
------------------
A mutex can only be released by the thread that owns it.
If a thread releases a mutex it does not own, an ApplicationException is thrown 2.

2. Abandoned Mutexes:
---------------------
If a thread terminates without releasing a mutex, the mutex is considered abandoned.
This often indicates a serious programming error because the resource might be left in an inconsistent state.
An AbandonedMutexException is thrown in the next thread that acquires the mutex 2.

3. Wait Methods:
-----------------
You can use WaitHandle.WaitAll or WaitHandle.WaitAny to wait for multiple mutexes or other wait handles.

Mutex Class:
-----------

A synchronization primitive that can also be used for interprocess synchronization.

    
    public sealed class Mutex : System.Threading.WaitHandle

Constructors:
-------------
Mutex()	- Initializes a new instance of the Mutex class with default properties.
Mutex(Boolean, String, Boolean)	- Initializes a new instance of the Mutex class with a Boolean value that indicates whether the calling thread should have initial ownership of the mutex, a string that is the name of the mutex, and a Boolean value that, when the method returns, indicates whether the calling thread was granted initial ownership of the mutex.
Mutex(Boolean, String)	- Initializes a new instance of the Mutex class with a Boolean value that indicates whether the calling thread should have initial ownership of the mutex, and a string that is the name of the mutex.
Mutex(Boolean)	- Initializes a new instance of the Mutex class with a Boolean value that indicates whether the calling thread should have initial ownership of the mutex.

Methods:
----------
OpenExisting(String)	- Opens the specified named mutex, if it already exists.
ReleaseMutex()	- Releases the Mutex once.
TryOpenExisting(String, Mutex)	- Opens the specified named mutex, if it already exists, and returns a value that indicates whether the operation succeeded.
WaitOne()	- Blocks the current thread until the current WaitHandle receives a signal.
(Inherited from WaitHandle)- WaitOne(Int32, Boolean)	
Blocks the current thread unil the current WaitHandle receives a signal, using a 32-bit signed integer to specify the time interval and specifying whether to exit the synchronization domain before the wait.(Inherited from WaitHandle)
WaitOne(Int32) - Blocks the current thread until the current WaitHandle receives a signal, using a 32-bit signed integer to specify the time interval in milliseconds.(Inherited from WaitHandle)
WaitOne(TimeSpan, Boolean)	- Blocks the current thread until the current instance receives a signal, using a TimeSpan to specify the time interval and specifying whether to exit the synchronization domain before the wait.(Inherited from WaitHandle)
WaitOne(TimeSpan)	- Blocks the current thread until the current instance receives a signal, using a TimeSpan to specify the time interval.(Inherited from WaitHandle)



**/
namespace ThreadingSynronization{
    class MutexClass{

        //Local Mutex
        private static Mutex mut = new Mutex();

        ////Local Mutex
        private static void ThreadProc()
        {
            for (int i = 0; i < 1; i++)
            {
                UseResource();
            }
        }

        //Local Mutex
        private static void UseResource()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is requesting the mutex");
            mut.WaitOne(); // Request ownership of the mutex
            Console.WriteLine($"{Thread.CurrentThread.Name} has entered the protected area");

            // Simulate some work
            Thread.Sleep(500);

            Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the protected area");
            mut.ReleaseMutex(); // Release ownership of the mutex
            Console.WriteLine($"{Thread.CurrentThread.Name} has released the mutex");
        }

        public static void Main(){

            //Local Mutex Start
            Console.WriteLine("Mutex Class");
            for (int i = 0; i < 3; i++)
            {
                Thread newThread = new Thread(ThreadProc);
                newThread.Name = $"Thread{i + 1}";
                newThread.Start();
            }
            //Local Mutex end

            Thread.Sleep(2000);
            //Named System Mutex Start
            Console.WriteLine("Named System Mutex");
            using (Mutex mutex = new Mutex(false, "MyNamedMutex"))
            {
                if (mutex.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    try
                    {
                        Console.WriteLine("Mutex acquired");
                        // Simulate some work
                        Thread.Sleep(1000);
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                        Console.WriteLine("Mutex released");
                    }
                }
                else
                {
                    Console.WriteLine("Unable to acquire mutex");
                }
            }

            //Named System Mutex End
        }
    }
}


