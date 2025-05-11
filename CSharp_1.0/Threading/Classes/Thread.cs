using System;
using System.Threading;
/**
Creates and controls a thread, sets its priority, and gets its status.

    public sealed class Thread : System.Runtime.ConstrainedExecution.CriticalFinalizerObject

Constructors:
--------------
Thread(ParameterizedThreadStart, Int32)	- Initializes a new instance of the Thread class, specifying a delegate that allows an object to be passed to the thread when the thread is started and specifying the maximum stack size for the thread.
Thread(ParameterizedThreadStart)	- Initializes a new instance of the Thread class, specifying a delegate that allows an object to be passed to the thread when the thread is started.
Thread(ThreadStart, Int32)	- Initializes a new instance of the Thread class, specifying the maximum stack size for the thread.
Thread(ThreadStart)	- Initializes a new instance of the Thread class.
    public Thread(System.Threading.ParameterizedThreadStart start);

Properties:
-----------
ApartmentState	- Obsolete. Gets or sets the apartment state of this thread.
CurrentCulture	- Gets or sets the culture for the current thread.
CurrentPrincipal	 - Gets or sets the thread's current principal (for role-based security).
CurrentThread	- Gets the currently running thread.
    public static System.Threading.Thread CurrentThread { get; }

CurrentUICulture	- Gets or sets the current culture used by the Resource Manager to look up culture-specific resources at run time.
ExecutionContext	- Gets an ExecutionContext object that contains information about the various contexts of the current thread.
IsAlive	- Gets a value indicating the execution status of the current thread.
    public bool IsAlive { get; }
    true if this thread has been started and has not terminated normally or aborted; otherwise, false.

IsBackground	- Gets or sets a value indicating whether or not a thread is a background thread.
    public bool IsBackground { get; set; }

IsThreadPoolThread	- Gets a value indicating whether or not a thread belongs to the managed thread pool.
    public bool IsThreadPoolThread { get; }

ManagedThreadId	- Gets a unique identifier for the current managed thread.
Name	- Gets or sets the name of the thread.
    public string? Name { get; set; }

Priority	- Gets or sets a value indicating the scheduling priority of a thread.
ThreadState	- Gets a value containing the states of the current thread.
    public System.Threading.ThreadState ThreadState { get; }



Methods:
---------
Abort()	- Obsolete. Raises a ThreadAbortException in the thread on which it is invoked, to begin the process of terminating the thread. Calling this method usually terminates the thread.
Abort(Object)	- Obsolete. Raises a ThreadAbortException in the thread on which it is invoked, to begin the process of terminating the thread while also providing exception information about the thread termination. Calling this method usually terminates the thread.
    When this method is invoked on a thread, the system throws a ThreadAbortException in the thread to abort it. ThreadAbortException is a special exception that can be caught by application code, but is re-thrown at the end of the catch block unless ResetAbort is called. ResetAbort cancels the request to abort, and prevents the ThreadAbortException from terminating the thread. Unexecuted finally blocks are executed before the thread is aborted.
    If Abort is called on a thread that has not been started, the thread will abort when Start is called. If Abort is called on a thread that is blocked or is sleeping, the thread is interrupted and then aborted.
    If Abort is called on a thread that has been suspended, a ThreadStateException is thrown in the thread that called Abort, and AbortRequested is added to the ThreadState property of the thread being aborted. A ThreadAbortException is not thrown in the suspended thread until Resume is called.
    If Abort is called on a managed thread while it is executing unmanaged code, a ThreadAbortException is not thrown until the thread returns to managed code.
    If two calls to Abort come at the same time, it is possible for one call to set the state information and the other call to execute the Abort. However, an application cannot detect this situation.
    After Abort is invoked on a thread, the state of the thread includes AbortRequested. After the thread has terminated as a result of a successful call to Abort, the state of the thread is changed to Stopped. With sufficient permissions, a thread that is the target of an Abort can cancel the abort using the ResetAbort method. For an example that demonstrates calling the ResetAbort method, see the ThreadAbortException class.

AllocateDataSlot()	- Allocates an unnamed data slot on all the threads. For better performance, use fields that are marked with the ThreadStaticAttribute attribute instead.
    public static LocalDataStoreSlot AllocateDataSlot();

AllocateNamedDataSlot(String)	- Allocates a named data slot on all threads. For better performance, use fields that are marked with the ThreadStaticAttribute attribute instead.
BeginCriticalRegion()	- Notifies a host that execution is about to enter a region of code in which the effects of a thread abort or unhandled exception might jeopardize other tasks in the application domain.
BeginThreadAffinity()	- Notifies a host that managed code is about to execute instructions that depend on the identity of the current physical operating system thread.
DisableComObjectEagerCleanup()	- Turns off automatic cleanup of runtime callable wrappers (RCW) for the current thread.
EndCriticalRegion()	- Notifies a host that execution is about to enter a region of code in which the effects of a thread abort or unhandled exception are limited to the current task.
EndThreadAffinity()	- Notifies a host that managed code has finished executing instructions that depend on the identity of the current physical operating system thread.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Finalize()	- Ensures that resources are freed and other cleanup operations are performed when the garbage collector reclaims the Thread object.
FreeNamedDataSlot(String)	- Eliminates the association between a name and a slot, for all threads in the process. For better performance, use fields that are marked with the ThreadStaticAttribute attribute instead.
GetApartmentState()	- Returns an ApartmentState value indicating the apartment state.
GetCurrentProcessorId()	- Gets an ID used to indicate on which processor the current thread is executing.
    public static int GetCurrentProcessorId();
    
GetData(LocalDataStoreSlot)	- Retrieves the value from the specified slot on the current thread, within the current thread's current domain. For better performance, use fields that are marked with the ThreadStaticAttribute attribute instead.
GetDomain()	- Returns the current domain in which the current thread is running.
GetDomainID()	- Returns a unique application domain identifier.
GetHashCode()	- Returns a hash code for the current thread.
GetNamedDataSlot(String)	- Looks up a named data slot. For better performance, use fields that are marked with the ThreadStaticAttribute attribute instead.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
Interrupt()	- Interrupts a thread that is in the WaitSleepJoin thread state.
    If this thread is not currently blocked in a wait, sleep, or join state, it will be interrupted when it next begins to block.
    ThreadInterruptedException is thrown in the interrupted thread, but not until the thread blocks. If the thread never blocks, the exception is never thrown, and thus the thread might complete without ever being interrupted.

Join()	- Blocks the calling thread until the thread represented by this instance terminates, while continuing to perform standard COM and SendMessage pumping.
    Blocks the calling thread until the thread represented by this instance terminates.
        public void Join();
    Join is a synchronization method that blocks the calling thread (that is, the thread that calls the method) until the thread whose Join method is called has completed. Use this method to ensure that a thread has been terminated. The caller will block indefinitely if the thread does not terminate.
    If the thread has already terminated when Join is called, the method returns immediately.
    You should never call the Join method of the Thread object that represents the current thread from the current thread. This causes your app to become unresponsive because the current thread waits upon itself indefinitely,
    This method changes the state of the calling thread to include ThreadState.WaitSleepJoin. You cannot invoke Join on a thread that is in the ThreadState.Unstarted state.

Join(Int32)	- Blocks the calling thread until the thread represented by this instance terminates or the specified time elapses, while continuing to perform standard COM and SendMessage pumping.
Join(TimeSpan)	- Blocks the calling thread until the thread represented by this instance terminates or the specified time elapses, while continuing to perform standard COM and SendMessage pumping.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
MemoryBarrier()	- Synchronizes memory access as follows: The processor executing the current thread cannot reorder instructions in such a way that memory accesses prior to the call to MemoryBarrier() execute after memory accesses that follow the call to MemoryBarrier().
SetApartmentState(ApartmentState)	- Sets the apartment state of a thread before it is started.
SetData(LocalDataStoreSlot, Object)	- Sets the data in the specified slot on the currently running thread, for that thread's current domain. For better performance, use fields marked with the ThreadStaticAttribute attribute instead.
Sleep(Int32)	- Suspends the current thread for the specified number of milliseconds.
    public static void Sleep(int millisecondsTimeout);

Sleep(TimeSpan)	- Suspends the current thread for the specified amount of time.
    public static void Sleep(TimeSpan timeout);

    The thread will not be scheduled for execution by the operating system for the amount of time specified. This method changes the state of the thread to include WaitSleepJoin.
    You can specify Timeout.Infinite for the millisecondsTimeout parameter to suspend the thread indefinitely. However, we recommend that you use other System.Threading classes such as Mutex, Monitor, EventWaitHandle, or Semaphore instead to synchronize threads or manage resources.
    The system clock ticks at a specific rate called the clock resolution. The actual timeout might not be exactly the specified timeout, because the specified timeout will be adjusted to coincide with clock ticks.
    This method does not perform standard COM and SendMessage pumping.

SpinWait(Int32)	- Causes a thread to wait the number of times defined by the iterations parameter.

Start()	- Causes the operating system to change the state of the current instance to Running.
    [System.Runtime.Versioning.UnsupportedOSPlatform("browser")]
    public void Start();

Start(Object)	- Causes the operating system to change the state of the current instance to Running, and optionally supplies an object containing data to be used by the method the thread executes.
    [System.Runtime.Versioning.UnsupportedOSPlatform("browser")]
    public void Start(object? parameter);
    Once a thread is in the ThreadState.Running state, the operating system can schedule it for execution. The thread begins executing at the first line of the method represented by the ThreadStart or ParameterizedThreadStart delegate supplied to the thread constructor. Note that the call to Start does not block the calling thread.
    Once the thread terminates, it cannot be restarted with another call to Start.

ToString()	- Returns a string that represents the current object.(Inherited from Object)
TrySetApartmentState(ApartmentState)	- Sets the apartment state of a thread before it is started.
UnsafeStart()	- Causes the operating system to change the state of the current instance to Running.
UnsafeStart(Object)	- Causes the operating system to change the state of the current instance to Running, and optionally supplies an object containing data to be used by the method the thread executes.
Yield()	- Causes the calling thread to yield execution to another thread that is ready to run on the current processor. The operating system selects the thread to yield to.


**/
namespace Threading{
    class ThreadClass{
        static Thread thread1, thread2;

        public static void DoWork(object data)
        {
            Console.WriteLine("Static thread procedure. Data='{0}'",
                data);
        }

        public void DoMoreWork(object data)
        {
            Console.WriteLine("Instance thread procedure. Data='{0}'",
                data);
        }

        public static void DoDisplay(){
            Console.WriteLine("Thread Started");
            Console.WriteLine("Start");
            Thread.Sleep(2000); // Sleep for 2 seconds
            Console.WriteLine("End");
        }

        private static void ThreadProc()
        {
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            if (Thread.CurrentThread.Name == "Thread1" && 
                thread2.ThreadState != ThreadState.Unstarted)
                thread2.Join();
            
            Thread.Sleep(4000);
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread1: {0}", thread1.ThreadState);
            Console.WriteLine("Thread2: {0}\n", thread2.ThreadState);
        }

    

        public static void Main(){
            Console.WriteLine("Threading Class.");

            Thread t1 = new Thread(ThreadClass.DoWork);//Parameterized Delegates

            ThreadClass obj = new ThreadClass();
            Thread t2 = new Thread(obj.DoMoreWork);

            Thread t3 = new Thread(ThreadClass.DoDisplay);//ThreadStart delegate
            Console.WriteLine("t3 State :"+t3.ThreadState);
            Console.WriteLine("t3 IsAlive :"+t3.IsAlive);
            t3.Start();
            Console.WriteLine("t3 State :"+t3.ThreadState);
            Console.WriteLine("t3 IsAlive :"+t3.IsAlive);
            Thread.Sleep(10000);
            Console.WriteLine("t3 State :"+t3.ThreadState);
            Console.WriteLine("t3 IsAlive :"+t3.IsAlive);
            Console.WriteLine("IsThreadPoolThread :"+ t3.IsThreadPoolThread);
            Console.WriteLine("Thread Pool t3 Id: "+ t3.ManagedThreadId);
            Console.WriteLine("Thread Pool t2 Id: "+ t2.ManagedThreadId);
            Console.WriteLine("Current Thread :"+ Thread.CurrentThread.Name);
            Console.WriteLine("Process ID :" + Thread.GetCurrentProcessorId());

            //Join
            Console.WriteLine("Join Example :");
            thread1 = new Thread(ThreadProc);
            thread1.Name = "Thread1";
            thread1.Start();
            
            thread2 = new Thread(ThreadProc);
            thread2.Name = "Thread2";
            thread2.Start();   


        }

        
    }
}