using System;
/**

Multithreading allows you to increase the responsiveness of your application and, if your application runs on a multiprocessor or multi-core system, increase its throughput.

Processes:
Definition: A process is an executing program. It represents an instance of a program running on a computer.
Isolation: The operating system uses processes to separate applications, ensuring that each application runs independently. This isolation helps in managing resources and preventing one application from interfering with another.
Resources: Each process has its own memory space, file handles, and other resources. This separation ensures that processes do not corrupt each other's data.

Threads:
Definition: A thread is the basic unit to which an operating system allocates processor time. It is a sequence of executable instructions within a process.
Context: Each thread maintains a set of structures known as the thread context, which includes:
CPU Registers: The current values of the CPU registers.
Stack: The memory stack used by the thread.
Scheduling Priority: Determines the order in which threads are scheduled for execution.
Execution: Multiple threads can run within the context of a single process. All threads of a process share the process's virtual address space, meaning they can access the same memory.

Threads in .NET Programming:
-----------------------------
Primary Thread:
Default Behavior: By default, a .NET program starts with a single thread, often referred to as the primary thread. This thread is responsible for executing the main entry point of the program.

Worker Threads:
Creation: A .NET program can create additional threads to execute code in parallel or concurrently with the primary thread. These additional threads are often called worker threads.
Usage: Worker threads are used to perform background tasks, handle asynchronous operations, and improve the responsiveness of applications by offloading work from the primary thread.

Key Concepts in Multithreading:
------------------------------------
Parallel Execution:
Definition: Parallel execution involves running multiple threads simultaneously to perform different tasks. This can lead to better utilization of CPU resources and faster completion of tasks.
Concurrent Execution:
Definition: Concurrent execution involves running multiple threads in an overlapping manner. Threads may not run simultaneously but can progress independently, allowing for efficient task management.
Thread Synchronization:
Importance: Synchronization is crucial to ensure that threads do not interfere with each other when accessing shared resources. Techniques like locks, mutexes, and semaphores are used to manage synchronization.

When to use multiple threads:
-----------------------------
You use multiple threads to increase the responsiveness of your application and to take advantage of a multiprocessor or multi-core system to increase the application's throughput.

Consider a desktop application, in which the primary thread is responsible for user interface elements and responds to user actions. Use worker threads to perform time-consuming operations that, otherwise, would occupy the primary thread and make the user interface non-responsive. You can also use a dedicated thread for network or device communication to be more responsive to incoming messages or events.

If your program performs operations that can be done in parallel, the total execution time can be decreased by performing those operations in separate threads and running the program on a multiprocessor or multi-core system. On such a system, use of multithreading might increase throughput along with the increased responsiveness.

How to use multithreading in .NET:
------------------------------------
Starting with .NET Framework 4, the recommended way to utilize multithreading is to use Task Parallel Library (TPL) and Parallel LINQ (PLINQ). For more information, see Parallel programming.

Both TPL and PLINQ rely on the ThreadPool threads. The System.Threading.ThreadPool class provides a .NET application with a pool of worker threads. You can also use thread pool threads. For more information, see The managed thread pool.

At last, you can use the System.Threading.Thread class that represents a managed thread. For more information, see Using threads and threading.

Multiple threads might need to access a shared resource. To keep the resource in an uncorrupted state and avoid race conditions, you must synchronize the thread access to it. You also might want to coordinate the interaction of multiple threads. .NET provides a range of types that you can use to synchronize access to a shared resource or coordinate thread interaction. For more information, see Overview of synchronization primitives.

Do handle exceptions in threads. Unhandled exceptions in threads generally terminate the process. For more information,


Threads vs Threading:
----------------------
Threads: The individual units of execution within a process, each with its own execution context.
Threading: The concept and techniques of using threads in a program, including their creation, management, and synchronization.

Exceptions in managed threads:
------------------------------
The common language runtime allows most unhandled exceptions in threads to proceed naturally. In most cases, this means that the unhandled exception causes the application to terminate. However, the common language runtime provides a backstop for certain unhandled exceptions that are used for controlling program flow:

A ThreadAbortException is thrown in a thread because Abort was called. This only applies to .NET Framework apps.

An AppDomainUnloadedException is thrown in a thread because the application domain in which the thread is executing is being unloaded.

The common language runtime or a host process terminates the thread by throwing an internal exception.

If any of these exceptions are unhandled in threads created by the common language runtime, the exception terminates the thread, but the common language runtime does not allow the exception to proceed further.

If these exceptions are unhandled in the main thread, or in threads that entered the runtime from unmanaged code, they proceed normally, resulting in termination of the application.

Exposing Threading Problems During Development:
---------------------------------------------------
Silent Failures and Their Consequences:
---------------------------------------
Silent Failures: When threads fail silently without terminating the application, serious programming issues can go undetected. This is particularly problematic for services and applications that run for extended periods.
Gradual Corruption: As threads fail silently, the program state can gradually become corrupted. This corruption can lead to degraded application performance or cause the application to become unresponsive over time.

Importance of Detecting Threading Problems:
-------------------------------------------
Early Detection: Allowing unhandled exceptions in threads to proceed naturally until the operating system terminates the program helps expose threading problems during development and testing.
Debugging Support: When the application terminates due to unhandled exceptions, error reports and logs generated by the operating system provide valuable information for debugging. These reports can pinpoint the source of the problem, making it easier for developers to identify and fix threading issues.

Benefits of Allowing Unhandled Exceptions to Proceed Naturally:
---------------------------------------------------------------
Visibility of Issues:
----------------------
Immediate Feedback: When an unhandled exception causes the application to terminate, developers receive immediate feedback that something went wrong. This visibility is crucial for identifying and addressing threading problems early in the development cycle.

Improved Debugging:
-------------------
Error Reports: Termination due to unhandled exceptions generates error reports that contain detailed information about the state of the application at the time of the crash. These reports can include stack traces, memory dumps, and other diagnostic data that are invaluable for debugging.
Root Cause Analysis: With detailed error reports, developers can perform root cause analysis to understand why the exception occurred and how to prevent it in the future.

Enhanced Reliability:
----------------------
Proactive Fixes: By exposing threading problems during development, developers can proactively fix issues before they affect end users. This leads to more reliable and robust applications.
Preventing Gradual Degradation: Detecting and fixing threading issues early prevents the gradual degradation of application performance and responsiveness, ensuring that the application remains stable over time.


Synchronizing data for multithreading:
--------------------------------------
When multiple threads can make calls to the properties and methods of a single object, it is critical that those calls be synchronized. Otherwise one thread might interrupt what another thread is doing, and the object could be left in an invalid state. A class whose members are protected from such interruptions is called thread-safe.

.NET provides several strategies to synchronize access to instance and static members:
    Synchronized code regions. You can use the Monitor class or compiler support for this class to synchronize only the code block that needs it, improving performance.
    Manual synchronization. You can use the synchronization objects provided by the .NET class library. See Overview of Synchronization Primitives, which includes a discussion of the Monitor class.
    Synchronized contexts. For .NET Framework applications only, you can use the SynchronizationAttribute to enable simple, automatic synchronization for ContextBoundObject objects.
    Collection classes in the System.Collections.Concurrent namespace. These classes provide built-in synchronized add and remove operations. For more information, see Thread-Safe Collections.

The common language runtime provides a thread model in which classes fall into a number of categories that can be synchronized in a variety of different ways depending on the requirements. The following table shows what synchronization support is provided for fields and methods with a given synchronization category.

Category	Global fields	Static fields	Static methods	Instance fields	Instance methods	Specific code blocks
No Synchronization	No	No	No	No	No	No
Synchronized Context	No	No	No	Yes	Yes	No
Synchronized Code Regions	No	No	Only if marked	No	Only if marked	Only if marked
Manual Synchronization	Manual	Manual	Manual	Manual	Manual	Manual

No synchronization:
--------------------
This is the default for objects. Any thread can access any method or field at any time. Only one thread at a time should access these objects.

Manual synchronization:
-------------------------
The .NET class library provides a number of classes for synchronizing threads. See Overview of Synchronization Primitives.

Synchronized code regions:
-----------------------------
You can use the Monitor class or a compiler keyword to synchronize blocks of code, instance methods, and static methods. There is no support for synchronized static fields.
Both Visual Basic and C# support the marking of blocks of code with a particular language keyword, the lock statement in C# or the SyncLock statement in Visual Basic. When the code is executed by a thread, an attempt is made to acquire the lock. If the lock has already been acquired by another thread, the thread blocks until the lock becomes available. When the thread exits the synchronized block of code, the lock is released, no matter how the thread exits the block.
Beginning in C# 13, the lock statement recognizes if the locked object is an instance of System.Threading.Lock and uses the EnterScope method to create a synchronized region. The lock, when the target isn't a Lock instance, and SyncLock statements are implemented using Monitor.Enter and Monitor.Exit, so other methods of Monitor can be used in conjunction with them within the synchronized region.
You can also decorate a method with a MethodImplAttribute with a value of MethodImplOptions.Synchronized, which has the same effect as using Monitor or one of the compiler keywords to lock the entire body of the method.
Thread.Interrupt can be used to break a thread out of blocking operations such as waiting for access to a synchronized region of code. Thread.Interrupt is also used to break threads out of operations like Thread.Sleep.
Do not lock the type — that is, typeof(MyType) in C#, GetType(MyType) in Visual Basic, or MyType::typeid in C++ — in order to protect static methods (Shared methods in Visual Basic). Use a private static object instead. Similarly, do not use this in C# (Me in Visual Basic) to lock instance methods. Use a private object instead. A class or instance can be locked by code other than your own, potentially causing deadlocks or performance problems.

Compiler support:
-------------------
Both Visual Basic and C# support a language keyword that uses Monitor.Enter and Monitor.Exit to lock the object. Visual Basic supports the SyncLock statement; C# supports the lock statement.
In both cases, if an exception is thrown in the code block, the lock acquired by the lock or SyncLock is released automatically. The C# and Visual Basic compilers emit a try/finally block with Monitor.Enter at the beginning of the try, and Monitor.Exit in the finally block. If an exception is thrown inside the lock or SyncLock block, the finally handler runs to allow you to do any clean-up work.

Synchronized Context:
----------------------
In .NET Framework applications only, you can use the SynchronizationAttribute on any ContextBoundObject to synchronize all instance methods and fields. All objects in the same context domain share the same lock. Multiple threads are allowed to access the methods and fields, but only a single thread is allowed at any one time.

Managed Threads: Background vs. Foreground:
--------------------------------------------
Foreground Threads:
-------------------
Definition: Foreground threads are threads that keep the managed execution environment running. As long as any foreground thread is active, the application will continue to run.
Behavior: The application will not shut down until all foreground threads have completed their execution.

Background Threads:
-------------------
Definition: Background threads are identical to foreground threads in terms of functionality, but they do not keep the managed execution environment running.
Behavior: The application can shut down even if background threads are still running. Once all foreground threads have stopped, the system will stop all background threads and shut down the application.

Application Shutdown and Thread Behavior:
-----------------------------------------
Application Shutdown:
------------------------
Foreground Threads: The application will wait for all foreground threads to complete before shutting down.
Background Threads: When the application shuts down (after all foreground threads have stopped), the runtime stops all background threads. No exception is thrown in the background threads when they are stopped due to application shutdown.

AppDomain Unloading:
----------------------
AppDomain.Unload Method: This method unloads an application domain, which is a boundary within which applications run. When an application domain is unloaded, it affects both foreground and background threads.
ThreadAbortException: When the AppDomain.Unload method is called, a ThreadAbortException is thrown in both foreground and background threads. This exception is used to signal that the thread is being terminated due to the unloading of the application domain.

The foreground or background status of a thread does not affect the outcome of an unhandled exception in the thread. An unhandled exception in either foreground or background threads results in termination of the application.

Threads that belong to the managed thread pool (that is, threads whose IsThreadPoolThread property is true) are background threads. All threads that enter the managed execution environment from unmanaged code are marked as background threads. All threads generated by creating and starting a new Thread object are by default foreground threads.

If you use a thread to monitor an activity, such as a socket connection, set its IsBackground property to true so that the thread does not prevent your process from terminating.

Why Set IsBackground = true?
By setting IsBackground = true, you're telling the system:

"This thread is not essential to keep the app running. If the main work is done, it's okay to terminate this thread too."


Managed and unmanaged threading in Windows:
------------------------------------------

Managed Threading (in .NET):
-------------------------------
✅ What It Is:
Managed threading is provided by the Common Language Runtime (CLR) in the .NET framework. It abstracts away many of the complexities of working directly with the Windows API.

🔧 Features:
Automatic memory management (garbage collection).
Thread pooling via ThreadPool or Task APIs.
Synchronization primitives like Monitor, Mutex, Semaphore, etc.
Exception handling integrated with the .NET runtime.
Cross-platform support (via .NET Core and .NET 5+).

Unmanaged Threading:
-------------------
Unmanaged threading involves using the Windows API directly (e.g., via C or C++), without the help of the .NET runtime. You have full control over thread creation, scheduling, and termination.

🔧 Features:
Lower-level control over thread behavior.
More performance tuning options.
Manual memory management.
Requires careful handling of synchronization, deadlocks, and resource leaks.


Management of all threads is done through the Thread class, including threads created by the common language runtime and those created outside the runtime that enter the managed environment to execute code. The runtime monitors all the threads in its process that have ever executed code within the managed execution environment. It does not track any other threads. Threads can enter the managed execution environment through COM interop (because the runtime exposes managed objects as COM objects to the unmanaged world), the COM DllGetClassObject function, and platform invoke.

When an unmanaged thread enters the runtime through, for example, a COM callable wrapper, the system checks the thread-local store of that thread to look for an internal managed Thread object. If one is found, the runtime is already aware of this thread. If it cannot find one, however, the runtime builds a new Thread object and installs it in the thread-local store of that thread.

In managed threading, Thread.GetHashCode is the stable managed thread identification. For the lifetime of your thread, it will not collide with the value from any other thread, regardless of the application domain from which you obtain this value.

Mapping from Win32 threading to managed threading:
---------------------------------------------------
The following table maps Win32 threading elements to their approximate runtime equivalent. Note that this mapping does not represent identical functionality. For example, TerminateThread does not execute finally clauses or free up resources, and cannot be prevented. However, Thread.Abort executes all your rollback code, reclaims all the resources, and can be denied using ResetAbort. Be sure to read the documentation closely before making assumptions about functionality.
In Win32	In the common language runtime
CreateThread	Combination of Thread and ThreadStart
TerminateThread	Thread.Abort
SuspendThread	Thread.Suspend
ResumeThread	Thread.Resume
Sleep	Thread.Sleep
WaitForSingleObject on the thread handle	Thread.Join
ExitThread	No equivalent
GetCurrentThread	Thread.CurrentThread
SetThreadPriority	Thread.Priority
No equivalent	Thread.Name
No equivalent	Thread.IsBackground
Close to CoInitializeEx (OLE32.DLL)	Thread.ApartmentState

🧠 What is COM and Apartment State?:
------------------------------------------
COM (Component Object Model) is a Microsoft technology that allows different software components to communicate. It uses a concept called apartments to manage how threads interact with COM objects.

Think of an apartment like a room where threads live. There are two main types:

🧍 STA (Single-Threaded Apartment): One thread per room. Only that thread can touch the objects in that room.
🧑‍🤝‍🧑 MTA (Multi-Threaded Apartment): Many threads can share the same room and access the objects.


🧵 Managed Threads and Apartment State:
--------------------------------------------
In .NET (managed code), when you create a thread, you can set its apartment state to either STA or MTA using:

SetApartmentState(ApartmentState.STA)
SetApartmentState(ApartmentState.MTA)
But there are rules:

You must set it before the thread starts.
You can only set it once.
If you don’t set it, it defaults to MTA.

🏁 Application Startup:
----------------------------
When your application starts, you can control the apartment state of the main thread using attributes:

[STAThread] → Main thread is STA (used for Windows Forms/WPF apps).
[MTAThread] → Main thread is MTA (default for console apps).

🧩 COM Interop and Managed Code:
---------------------------------
When managed code (like C#) talks to COM objects:

It respects COM rules. If the COM object is in an STA, .NET uses a proxy to call it safely.
Managed objects exposed to COM behave like they are free-threaded (can be accessed from any apartment), unless they inherit from special base classes like:
ServicedComponent
StandardOleMarshalObject

🔄 Synchronization and Contexts:
---------------------------------
In .NET:
There’s no built-in support for COM-style synchronization unless you use Enterprise Services or context-bound objects.
If you need COM-like behavior (like automatic synchronization), your class must inherit from ServicedComponent.


🧵 What Happens When a Thread is Blocked?
A blocked thread is one that is waiting for something—like a file to load, a network response, or a lock to be released. There are two types of blocking:

1. Managed Blocking (Good)
Done using .NET methods like:
Thread.Join()
Monitor.Enter()
WaitHandle.WaitOne()
GC.WaitForPendingFinalizers()
These are runtime-aware, meaning the .NET runtime knows the thread is waiting and can interrupt or abort it if needed.

2. Unmanaged Blocking (Risky)
Happens when a thread calls into native Windows APIs or other unmanaged code that blocks (e.g., waiting for a file or socket using Win32 APIs).
The .NET runtime loses control of the thread while it’s in unmanaged code.

If you call Thread.Abort() or Thread.Interrupt() during this time, nothing happens immediately.

🛑 Why This Matters

🔴 Thread.Abort()
If the thread is in unmanaged code, the abort is delayed.
The runtime marks the thread for abortion.
The thread is only aborted when it returns to managed code.

🟡 Thread.Interrupt()
Works only if the thread is blocked in managed code.
If the thread is in unmanaged code, the interrupt is ignored until it comes back.

✅ Best Practice: Use Managed Blocking
Using managed blocking methods ensures:

The runtime can interrupt or abort the thread safely.
The thread can pump messages if it’s in a Single-Threaded Apartment (STA)—important for UI apps like Windows Forms or WPF.

🧠 What is Message Pumping in STA?
In STA (Single-Threaded Apartment), the thread needs to process Windows messages (like mouse clicks, redraws, etc.). If it blocks without pumping messages, the UI freezes.

Managed blocking methods like WaitHandle.WaitOne() are smart—they pump messages while waiting, so the UI stays responsive.

🧵 What Are Fibers?
Fibers are a type of lightweight thread used in unmanaged (native) Windows programming. Unlike regular threads, fibers are manually scheduled by the application, not by the operating system.

Think of it like this:

Threads = automatic workers managed by the OS.
Fibers = manual workers you have to manage yourself.
⚠️ Why .NET Does Not Support Fibers
The .NET runtime (CLR) is designed to work with OS-managed threads, not fibers. Here's why fibers are problematic in .NET:

.NET assumes OS control: The CLR expects the OS to manage thread scheduling, stack switching, and context.
Fibers bypass the OS: When you switch between fibers, the OS and CLR don’t know it happened.
This breaks the runtime: The CLR might get confused about which thread is running, leading to crashes, memory corruption, or unpredictable behavior.
🚫 What You Should Avoid
You should not call unmanaged functions (like from a C++ DLL) that:

Use fibers internally.
Switch execution contexts manually.
These can crash your .NET application because the CLR loses track of what’s happening.

✅ What You Should Do Instead
Stick to:

Managed threads (System.Threading.Thread, Task, ThreadPool)
OS threads created and managed by the Windows scheduler
Avoid libraries or APIs that mention fiber-based scheduling or coroutines in unmanaged code


Thread Local Storage: Thread-Relative Static Fields and Data Slots:
----------------------------------------------------------------------

You can use managed thread local storage (TLS) to store data that's unique to a thread and application domain. .NET provides two ways to use managed TLS: thread-relative static fields and data slots.
    1.Use thread-relative static fields (thread-relative Shared fields in Visual Basic) if you can anticipate your exact needs at compile time. Thread-relative static fields provide the best performance. They also give you the benefits of compile-time type checking.
    2. Use data slots when your actual requirements might be discovered only at run time. Data slots are slower and more awkward to use than thread-relative static fields, and data is stored as type Object, so you must cast it to the correct type before you use it.
In unmanaged C++, you use TlsAlloc to allocate slots dynamically and __declspec(thread) to declare that a variable should be allocated in thread-relative storage. Thread-relative static fields and data slots provide the managed version of this behavior.
You can use the System.Threading.ThreadLocal<T> class to create thread-local objects that are initialized lazily when the object is first consumed. For more information, see Lazy Initialization.


Uniqueness of Data in Managed TLS:
-------------------------------------
Whether you use thread-relative static fields or data slots, data in managed TLS is unique to the combination of thread and application domain.
        1.Within an application domain, one thread cannot modify data from another thread, even when both threads use the same field or slot.
        2.When a thread accesses the same field or slot from multiple application domains, a separate value is maintained in each application domain.
For example, if a thread sets the value of a thread-relative static field, enters another application domain, and then retrieves the value of the field, the value retrieved in the second application domain differs from the value in the first application domain. Setting a new value for the field in the second application domain does not affect the field's value in the first application domain.
Similarly, when a thread gets the same named data slot in two different application domains, the data in the first application domain remains independent of the data in the second application domain.

Thread-Relative Static Fields:
-------------------------------
If you know that a piece of data is always unique to a thread and application-domain combination, apply the ThreadStaticAttribute attribute to the static field. Use the field as you would use any other static field. The data in the field is unique to each thread that uses it.
Thread-relative static fields provide better performance than data slots and have the benefit of compile-time type checking
Be aware that any class constructor code will run on the first thread in the first context that accesses the field. In all other threads or contexts in the same application domain, the fields will be initialized to null (Nothing in Visual Basic) if they are reference types, or to their default values if they are value types. Therefore, you should not rely on class constructors to initialize thread-relative static fields. Instead, avoid initializing thread-relative static fields and assume that they are initialized to null (Nothing) or to their default values.

Data Slots:
------------
.NET provides dynamic data slots that are unique to a combination of thread and application domain. There are two types of data slots: named slots and unnamed slots. Both are implemented by using the LocalDataStoreSlot structure.
To create a named data slot, use the Thread.AllocateNamedDataSlot or Thread.GetNamedDataSlot method. To get a reference to an existing named slot, pass its name to the GetNamedDataSlot method.
To create an unnamed data slot, use the Thread.AllocateDataSlot method.
For both named and unnamed slots, use the Thread.SetData and Thread.GetData methods to set and retrieve the information in the slot. These are static methods that always act on the data for the thread that is currently executing them.
Named slots can be convenient, because you can retrieve the slot when you need it by passing its name to the GetNamedDataSlot method, instead of maintaining a reference to an unnamed slot. However, if another component uses the same name for its thread-relative storage and a thread executes code from both your component and the other component, the two components might corrupt each other's data. (This scenario assumes that both components are running in the same application domain, and that they are not designed to share the same data.)

====================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================


**/
namespace ThreadsNamespace{
    class ThreadsClass{
        public static void Main(){
            Console.WriteLine("Threads ..");
        }
    }
}