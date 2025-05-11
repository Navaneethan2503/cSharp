using System;
using System.Threading;
/**
EventWaitHandle is a synchronization primitive in .NET that allows threads to communicate by signaling and waiting for signals.

The EventWaitHandle class allows threads to communicate with each other by signaling and by waiting for signals. Event wait handles (also referred to simply as events) are wait handles that can be signaled in order to release one or more waiting threads. After it is signaled, an event wait handle is reset either manually or automatically. The EventWaitHandle class can represent either a local event wait handle (local event) or a named system event wait handle (named event or system event, visible to all processes).

Event wait handles are not .NET events. There are no delegates or event handlers involved. The word "event" is used to describe them because they have traditionally been referred to as operating-system events, and because the act of signaling the wait handle indicates to waiting threads that an event has occurred.

Both local and named event wait handles use system synchronization objects, which are protected by SafeWaitHandle wrappers to ensure that the resources are released. You can use the Dispose method to free the resources immediately when you have finished using the object.

What is EventWaitHandle?
EventWaitHandle allows threads to wait for a signal before proceeding.
It can be signaled to release one or more waiting threads.
It can be reset either manually or automatically.

🛠️ Types of EventWaitHandle
----------------------------
AutoResetEvent:
---------------
Resets automatically after releasing a single waiting thread.
Ideal for providing exclusive access to a resource for one thread at a time.
Created using EventResetMode.AutoReset.

ManualResetEvent:
------------------
Must be reset manually after being signaled.
Remains signaled until Reset is called, allowing multiple threads to proceed.
Created using EventResetMode.ManualReset.

Features Common to Automatic and Manual Events:
--------------------------------------------------
Typically, one or more threads block on an EventWaitHandle until an unblocked thread calls the Set method, which releases one of the waiting threads (in the case of automatic reset events) or all of them (in the case of manual reset events). A thread can signal an EventWaitHandle and then block on it, as an atomic operation, by calling the static WaitHandle.SignalAndWait method.

EventWaitHandle objects can be used with the static WaitHandle.WaitAll and WaitHandle.WaitAny methods. Because the EventWaitHandle and Mutex classes both derive from WaitHandle, you can use both classes with these methods.

Named Events:
-------------
The Windows operating system allows event wait handles to have names. A named event is system wide. That is, once the named event is created, it is visible to all threads in all processes. Thus, named events can be used to synchronize the activities of processes as well as threads.

You can create an EventWaitHandle object that represents a named system event by using one of the constructors that specifies an event name.


EventWaitHandle Class:
-----------------------
    
    public class EventWaitHandle : System.Threading.WaitHandle

Constructors:
--------------
EventWaitHandle(Boolean, EventResetMode, String, Boolean)	- Initializes a new instance of the EventWaitHandle class, specifying whether the wait handle is initially signaled if created as a result of this call, whether it resets automatically or manually, the name of a system synchronization event, and a Boolean variable whose value after the call indicates whether the named system event was created.
EventWaitHandle(Boolean, EventResetMode, String)	- Initializes a new instance of the EventWaitHandle class, specifying whether the wait handle is initially signaled if created as a result of this call, whether it resets automatically or manually, and the name of a system synchronization event.
EventWaitHandle(Boolean, EventResetMode)	- Initializes a new instance of the EventWaitHandle class, specifying whether the wait handle is initially signaled, and whether it resets automatically or manually.


Fields:
----------
WaitTimeout	- Indicates that a WaitAny(WaitHandle[], Int32, Boolean) operation timed out before any of the wait handles were signaled. This field is constant.(Inherited from WaitHandle)

Methods:
----------
OpenExisting(String)	- Opens the specified named synchronization event, if it already exists.
Reset()	- Sets the state of the event to nonsignaled, causing threads to block.
Set()	- Sets the state of the event to signaled, allowing one or more waiting threads to proceed.
TryOpenExisting(String, EventWaitHandle)	- Opens the specified named synchronization event, if it already exists, and returns a value that indicates whether the operation succeeded.
WaitOne()	- Blocks the current thread until the current WaitHandle receives a signal.(Inherited from WaitHandle)

**/
namespace ThreadingSynronization{
    class EventWaitHandleClass{
        public static void Main(){
            Console.WriteLine("Synronization EventWaitHandle and Class");

            //AutoResetEvent Example
            EventWaitHandle autoEvent = new EventWaitHandle(false, EventResetMode.AutoReset);

            void ThreadProc()
            {
                Console.WriteLine("Thread waiting...");
                autoEvent.WaitOne(); // Wait for signal
                Console.WriteLine("Thread proceeding...");
            }

            Thread t = new Thread(ThreadProc);
            t.Start();

            // Simulate some work
            Thread.Sleep(5000);
            Console.WriteLine("Signalled the event");
            autoEvent.Set(); // Signal the event

            //AutoResetEvent Example

            //ManualResetEvent Example
            Console.WriteLine("Manual Reset Event");
            EventWaitHandle manualEvent = new EventWaitHandle(false, EventResetMode.ManualReset);

            void ThreadProc1()
            {
                Console.WriteLine("Thread waiting...");
                manualEvent.WaitOne(); // Wait for signal
                Console.WriteLine("Thread proceeding...");
            }

            Thread t1 = new Thread(ThreadProc1);
            Thread t2 = new Thread(ThreadProc1);
            t1.Start();
            t2.Start();

            // Simulate some work
            Thread.Sleep(1000);
            manualEvent.Set(); // Signal the event

            // Both threads proceed
            Thread.Sleep(1000);
            manualEvent.Reset(); // Reset the event

            //ManualResetEvent Example

        }
    }
}