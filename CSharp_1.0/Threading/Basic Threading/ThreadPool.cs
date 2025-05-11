using System;
using System.Threading;
/**

Thread Pool:
--------------
The System.Threading.ThreadPool class provides your application with a pool of worker threads that are managed by the system, allowing you to concentrate on application tasks rather than thread management. If you have short tasks that require background processing, the managed thread pool is an easy way to take advantage of multiple threads. 
Use of the thread pool is significantly easier in Framework 4 and later, since you can create Task and Task<TResult> objects that perform asynchronous tasks on thread pool threads.

.NET uses thread pool threads for many purposes, including Task Parallel Library (TPL) operations, asynchronous I/O completion, timer callbacks, registered wait operations, asynchronous method calls using delegates, and System.Net socket connections.

Thread pool characteristics:
-----------------------------
Thread pool threads are background threads. Each thread uses the default stack size, runs at the default priority, and is in the multithreaded apartment. Once a thread in the thread pool completes its task, it's returned to a queue of waiting threads. From this moment it can be reused. This reuse enables applications to avoid the cost of creating a new thread for each task.

There is only one thread pool per process.

Exceptions in thread pool threads:
------------------------------------
Unhandled exceptions in thread pool threads terminate the process. There are three exceptions to this rule:
    A System.Threading.ThreadAbortException is thrown in a thread pool thread because Thread.Abort was called.
    A System.AppDomainUnloadedException is thrown in a thread pool thread because the application domain is being unloaded.
    The common language runtime or a host process terminates the thread.

Maximum number of thread pool threads:
-------------------------------------
The number of operations that can be queued to the thread pool is limited only by available memory. However, the thread pool limits the number of threads that can be active in the process simultaneously. 
If all thread pool threads are busy, additional work items are queued until threads to execute them become available. The default size of the thread pool for a process depends on several factors, such as the size of the virtual address space. 
A process can call the ThreadPool.GetMaxThreads method to determine the number of threads.

You can control the maximum number of threads by using the ThreadPool.GetMaxThreads and ThreadPool.SetMaxThreads methods.

Thread pool minimums:
---------------------
The thread pool provides new worker threads or I/O completion threads on demand until it reaches a specified minimum for each category. You can use the ThreadPool.GetMinThreads method to obtain these minimum values.
When demand is low, the actual number of thread pool threads can fall below the minimum values.
When a minimum is reached, the thread pool can create additional threads or wait until some tasks complete. The thread pool creates and destroys worker threads in order to optimize throughput, which is defined as the number of tasks that complete per unit of time. Too few threads might not make optimal use of available resources, whereas too many threads could increase resource contention.

Using the thread pool:
------------------------
The easiest way to use the thread pool is to use the Task Parallel Library (TPL). By default, TPL types like Task and Task<TResult> use thread pool threads to run tasks.

You can also use the thread pool by calling ThreadPool.QueueUserWorkItem from managed code (or ICorThreadpool::CorQueueUserWorkItem from unmanaged code) and passing a System.Threading.WaitCallback delegate representing the method that performs the task.

Another way to use the thread pool is to queue work items that are related to a wait operation by using the ThreadPool.RegisterWaitForSingleObject method and passing a System.Threading.WaitHandle that, when signaled or when timed out, calls the method represented by the System.Threading.WaitOrTimerCallback delegate. Thread pool threads are used to invoke callback methods.

Skipping security checks:
--------------------------
The thread pool also provides the ThreadPool.UnsafeQueueUserWorkItem and ThreadPool.UnsafeRegisterWaitForSingleObject methods. Use these methods only when you are certain that the caller's stack is irrelevant to any security checks performed during the execution of the queued task. ThreadPool.QueueUserWorkItem and ThreadPool.RegisterWaitForSingleObject both capture the caller's stack, which is merged into the stack of the thread pool thread when the thread begins to execute a task. If a security check is required, the entire stack must be checked. Although the check provides safety, it also has a performance cost.

When not to use thread pool threads:
------------------------------------
There are several scenarios in which it's appropriate to create and manage your own threads instead of using thread pool threads:

You require a foreground thread.
You require a thread to have a particular priority.
You have tasks that cause the thread to block for long periods of time. The thread pool has a maximum number of threads, so a large number of blocked thread pool threads might prevent tasks from starting.
You need to place threads into a single-threaded apartment. All ThreadPool threads are in the multithreaded apartment.
You need to have a stable identity associated with the thread, or to dedicate a thread to a task.



**/
namespace Threading{
    class ThreadPoolClass{
        public static void Main(){
            Console.WriteLine("Thread Pool .");
        }
    }
}