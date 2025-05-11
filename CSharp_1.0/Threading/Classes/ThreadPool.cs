using System;
using System.Threading;
/**
ThreadPool Class
-----------------

Provides a pool of threads that can be used to execute tasks, post work items, process asynchronous I/O, wait on behalf of other threads, and process timers.

    public static class ThreadPool

Properties:
-----------
CompletedWorkItemCount	- Gets the number of work items that have been processed so far.
PendingWorkItemCount	- Gets the number of work items that are currently queued to be processed.
ThreadCount	- Gets the number of thread pool threads that currently exist.

Methods:
----------
BindHandle(IntPtr)	- Obsolete.Binds an operating system handle to the ThreadPool.
BindHandle(SafeHandle)	- Binds an operating system handle to the ThreadPool.
GetAvailableThreads(Int32, Int32)	- Retrieves the difference between the maximum number of thread pool threads returned by the GetMaxThreads(Int32, Int32) method, and the number currently active.
GetMaxThreads(Int32, Int32)	- Retrieves the number of requests to the thread pool that can be active concurrently. All requests above that number remain queued until thread pool threads become available.
GetMinThreads(Int32, Int32)	- Retrieves the minimum number of threads the thread pool creates on demand, as new requests are made, before switching to an algorithm for managing thread creation and destruction.

QueueUserWorkItem(WaitCallback, Object)	- Queues a method for execution, and specifies an object containing data to be used by the method. The method executes when a thread pool thread becomes available.
    
    public static bool QueueUserWorkItem(System.Threading.WaitCallback callBack, object? state);

QueueUserWorkItem(WaitCallback)	- Queues a method for execution. The method executes when a thread pool thread becomes available.
    public static bool QueueUserWorkItem(System.Threading.WaitCallback callBack);


QueueUserWorkItem<TState>(Action<TState>, TState, Boolean)	- Queues a method specified by an Action<T> delegate for execution, and provides data to be used by the method. The method executes when a thread pool thread becomes available.
    public static bool QueueUserWorkItem<TState>(Action<TState> callBack, TState state, bool preferLocal);
    
RegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, Int32, Boolean)	- Registers a delegate to wait for a WaitHandle, specifying a 32-bit signed integer for the time-out in milliseconds.
RegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, Int64, Boolean)	- Registers a delegate to wait for a WaitHandle, specifying a 64-bit signed integer for the time-out in milliseconds.
RegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, TimeSpan, Boolean)	- Registers a delegate to wait for a WaitHandle, specifying a TimeSpan value for the time-out.
RegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, UInt32, Boolean)	- Registers a delegate to wait for a WaitHandle, specifying a 32-bit unsigned integer for the time-out in milliseconds.
SetMaxThreads(Int32, Int32)	- Sets the number of requests to the thread pool that can be active concurrently. All requests above that number remain queued until thread pool threads become available.
SetMinThreads(Int32, Int32)	- Sets the minimum number of threads the thread pool creates on demand, as new requests are made, before switching to an algorithm for managing thread creation and destruction.
UnsafeQueueNativeOverlapped(NativeOverlapped*)	- Queues an overlapped I/O operation for execution.
UnsafeQueueUserWorkItem(IThreadPoolWorkItem, Boolean)	- Queues the specified work item object to the thread pool.
UnsafeQueueUserWorkItem(WaitCallback, Object)	- Queues the specified delegate to the thread pool, but does not propagate the calling stack to the worker thread.
UnsafeQueueUserWorkItem<TState>(Action<TState>, TState, Boolean)	- 
Queues a method specified by an Action<T> delegate for execution, and specifies an object containing data to be used by the method. The method executes when a thread pool thread becomes available.
UnsafeRegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, Int32, Boolean)	- Registers a delegate to wait for a WaitHandle, using a 32-bit signed integer for the time-out in milliseconds. This method does not propagate the calling stack to the worker thread.
UnsafeRegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, Int64, Boolean)	- Registers a delegate to wait for a WaitHandle, specifying a 64-bit signed integer for the time-out in milliseconds. This method does not propagate the calling stack to the worker thread.
UnsafeRegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, TimeSpan, Boolean)	- Registers a delegate to wait for a WaitHandle, specifying a TimeSpan value for the time-out. This method does not propagate the calling stack to the worker thread.
UnsafeRegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, UInt32, Boolean)	- Registers a delegate to wait for a WaitHandle, specifying a 32-bit unsigned integer for the time-out in milliseconds. This method does not propagate the calling stack to the worker thread.

Remark:
----------
Many applications create threads that spend a great deal of time in the sleeping state, waiting for an event to occur. Other threads might enter a sleeping state only to be awakened periodically to poll for a change or update status information. The thread pool enables you to use threads more efficiently by providing your application with a pool of worker threads that are managed by the system.

Examples of operations that use thread pool threads include the following:
    When you create a Task or Task<TResult> object to perform some task asynchronously, by default the task is scheduled to run on a thread pool thread.
    Asynchronous timers use the thread pool. Thread pool threads execute callbacks from the System.Threading.Timer class and raise events from the System.Timers.Timer class.
    When you use registered wait handles, a system thread monitors the status of the wait handles. When a wait operation completes, a worker thread from the thread pool executes the corresponding callback function.
    When you call the QueueUserWorkItem method to queue a method for execution on a thread pool thread. You do this by passing the method a WaitCallback delegate. The delegate has the signature


**/
namespace ThreadingClass{
    class ThreadPoolClass{
        // This thread procedure performs the task.
        static void ThreadProc(Object stateInfo) 
        {
            // No state object was passed to QueueUserWorkItem, so stateInfo is null.
            Console.WriteLine("Hello from the thread pool.");
        }

        public static void Main(){
            Console.WriteLine("Thread Pool Class .");
            // Queue the task.
            ThreadPool.QueueUserWorkItem(ThreadProc);
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);

            Console.WriteLine("Main thread exits.");

        }
    }
}