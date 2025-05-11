using System;
using System.Threading;
/**
Creating a thread:
---------------------

Creating a new Thread object creates a new managed thread. The Thread class has constructors that take a ThreadStart delegate or a ParameterizedThreadStart delegate; the delegate wraps the method that is invoked by the new thread when you call the Start method. Calling Start more than once causes a ThreadStateException to be thrown.

The Start method returns immediately, often before the new thread has actually started. You can use the ThreadState and IsAlive properties to determine the state of the thread at any one moment, but these properties should never be used for synchronizing the activities of threads.

Once a thread is started, it is not necessary to retain a reference to the Thread object. The thread continues to execute until the thread procedure ends.

Passing data to threads:
------------------------
The ParameterizedThreadStart delegate provides an easy way to pass an object containing data to a thread when you call Thread.Start(Object). See ParameterizedThreadStart for a code example.

Using the ParameterizedThreadStart delegate is not a type-safe way to pass data, because the Thread.Start(Object) method accepts any object. An alternative is to encapsulate the thread procedure and the data in a helper class and use the ThreadStart delegate to execute the thread procedure.

Neither ThreadStart nor ParameterizedThreadStart delegate has a return value, because there is no place to return the data from an asynchronous call. To retrieve the results of a thread method, you can use a callback method,


Pausing and interrupting threads
--------------------------------
The most common ways to synchronize the activities of threads are to block and release threads, or to lock objects or regions of code.

You can also have threads put themselves to sleep. When threads are blocked or sleeping, you can use a ThreadInterruptedException to break them out of their wait states.

Calling Thread.Sleep with a value of Timeout.Infinite causes a thread to sleep until it is interrupted by another thread that calls the Thread.Interrupt method on the sleeping thread, or until it is terminated by a call to its Thread.Abort method.

Interrupting threads:
---------------------
You can interrupt a waiting thread by calling the Thread.Interrupt method on the blocked thread to throw a ThreadInterruptedException, which breaks the thread out of the blocking call. The thread should catch the ThreadInterruptedException and do whatever is appropriate to continue working. If the thread ignores the exception, the runtime catches the exception and stops the thread.
If the target thread is not blocked when Thread.Interrupt is called, the thread is not interrupted until it blocks. If the thread never blocks, it could complete without ever being interrupted.

If a wait is a managed wait, then Thread.Interrupt and Thread.Abort both wake the thread immediately. If a wait is an unmanaged wait (for example, a platform invoke call to the Win32 WaitForSingleObject function), neither Thread.Interrupt nor Thread.Abort can take control of the thread until it returns to or calls into managed code. In managed code, the behavior is as follows:

    Thread.Interrupt wakes a thread out of any wait it might be in and causes a ThreadInterruptedException to be thrown in the destination thread.

    .NET Framework only: Thread.Abort wakes a thread out of any wait it might be in and causes a ThreadAbortException to be thrown on the thread. For details, see Destroy threads.

Scheduling Task:
----------------
Every thread has a thread priority assigned to it. Threads created within the common language runtime are initially assigned the priority of ThreadPriority.Normal. Threads created outside the runtime retain the priority they had before they entered the managed environment. You can get or set the priority of any thread with the Thread.Priority property.

Threads are scheduled for execution based on their priority. Even though threads are executing within the runtime, all threads are assigned processor time slices by the operating system. The details of the scheduling algorithm used to determine the order in which threads are executed vary with each operating system. Under some operating systems, the thread with the highest priority (of those threads that can be executed) is always scheduled to run first. If multiple threads with the same priority are all available, the scheduler cycles through the threads at that priority, giving each thread a fixed time slice in which to execute. As long as a thread with a higher priority is available to run, lower priority threads do not get to execute. When there are no more runnable threads at a given priority, the scheduler moves to the next lower priority and schedules the threads at that priority for execution. If a higher priority thread becomes runnable, the lower priority thread is preempted and the higher priority thread is allowed to execute once again. On top of all that, the operating system can also adjust thread priorities dynamically as an application's user interface is moved between foreground and background. Other operating systems might choose to use a different scheduling algorithm.

Canceling threads cooperatively:
---------------------------------
Prior to .NET Framework 4, .NET provided no built-in way to cancel a thread cooperatively after it was started. However, starting with .NET Framework 4, you can use a System.Threading.CancellationToken to cancel threads, just as you can use them to cancel System.Threading.Tasks.Task objects or PLINQ queries. Although the System.Threading.Thread class does not offer built-in support for cancellation tokens, you can pass a token to a thread procedure by using the Thread constructor that takes a ParameterizedThreadStart delegate.


Destroy threads:
---------------

To terminate the execution of the thread, you usually use the cooperative cancellation model. However, sometimes it's not possible to stop a thread cooperatively, because it runs third-party code not designed for cooperative cancellation. In .NET Framework apps, you can use the Thread.Abort method to terminate a managed thread forcibly. When you call Abort, the Common Language Runtime throws a ThreadAbortException in the target thread, which the target thread can catch. (However, the .NET Framework runtime always automatically rethrows the exception after the catch block.) For more information, see Thread.Abort.

The Thread.Abort method is not supported in .NET 5 (including .NET Core) and later versions. If you need to terminate the execution of third-party code forcibly in .NET 5+, run it in the separate process and use Process.Kill.

Once a thread is aborted, it cannot be restarted.

The Abort method does not cause the thread to abort immediately, because the target thread can catch the ThreadAbortException and execute arbitrary amounts of code in a finally block. You can call Thread.Join if you need to wait until the thread has ended. Thread.Join is a blocking call that does not return until the thread has actually stopped executing or an optional timeout interval has elapsed. The aborted thread could call the ResetAbort method or perform unbounded processing in a finally block, so if you do not specify a timeout, the wait is not guaranteed to end.

Threads that are waiting on a call to the Thread.Join method can be interrupted by other threads that call Thread.Interrupt.

Handling ThreadAbortException:
-----------------------------
If you expect your thread to be aborted, either as a result of calling Abort from your own code or as a result of unloading an application domain in which the thread is running (AppDomain.Unload uses Thread.Abort to terminate threads), your thread must handle the ThreadAbortException and perform any final processing in a finally clause

Your clean-up code must be in the catch clause or the finally clause, because a ThreadAbortException is rethrown by the system at the end of the finally clause, or at the end of the catch clause if there is no finally clause.

You can prevent the system from rethrowing the exception by calling the Thread.ResetAbort method. However, you should do this only if your own code caused the ThreadAbortException.

**/
namespace Threading
{
    // The ThreadWithState2 class contains the information needed for
    // a task, the method that executes the task, and a delegate
    // to call when the task is complete.
    public class ThreadWithState2
    {
        // State information used in the task.
        private string _boilerplate;
        private int _numberValue;

        // Delegate used to execute the callback method when the
        // task is complete.
        private ExampleCallback _callback;

        // The constructor obtains the state information and the
        // callback delegate.
        public ThreadWithState2(string text, int number,
            ExampleCallback callbackDelegate)
        {
            _boilerplate = text;
            _numberValue = number;
            _callback = callbackDelegate;
        }

        // The thread procedure performs the task, such as
        // formatting and printing a document, and then invokes
        // the callback delegate with the number of lines printed.
        public void ThreadProc()
        {
            Console.WriteLine(_boilerplate, _numberValue);
            _callback?.Invoke(1);
        }
    }

    // Delegate that defines the signature for the callback method.
    public delegate void ExampleCallback(int lineCount);

    public class ThreadWithState
    {
        // State information used in the task.
        private string _boilerplate;
        private int _numberValue;

        // The constructor obtains the state information.
        public ThreadWithState(string text, int number)
        {
            _boilerplate = text;
            _numberValue = number;
        }

        // The thread procedure performs the task, such as formatting
        // and printing a document.
        public void ThreadProc()
        {
            Console.WriteLine(_boilerplate, _numberValue);
        }
    }


    public class ServerClass
    {
        // The method that will be called when the thread is started.
        public void InstanceMethod()
        {
            Console.WriteLine(
                "ServerClass.InstanceMethod is running on another thread.");

            // Pause for a moment to provide a delay to make
            // threads more apparent.
            Thread.Sleep(3000);
            Console.WriteLine(
                "The instance method called by the worker thread has ended.");
        }

        public static void StaticMethod()
        {
            Console.WriteLine(
                "ServerClass.StaticMethod is running on another thread.");

            // Pause for a moment to provide a delay to make
            // threads more apparent.
            Thread.Sleep(5000);
            Console.WriteLine(
                "The static method called by the worker thread has ended.");
        }

        public static void StaticMethod(object? obj)
        {
            if (obj is null)
                return;

            CancellationToken ct = (CancellationToken)obj;
            Console.WriteLine("ServerClass.StaticMethod is running on another thread.");

            // Simulate work that can be canceled.
            while (!ct.IsCancellationRequested)
            {
                Thread.SpinWait(50000);
            }
            Console.WriteLine("The worker thread has been canceled. Press any key to exit.");
            Console.ReadKey(true);
        }

    }

    class ThreadUsage
    {
        private static void SleepIndefinitely()
        {
            Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' about to sleep indefinitely.");
            try {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException) {
                Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' awoken.");
            }
            catch (ThreadAbortException) {
                Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' aborted.");
            }
            finally
            {
                Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' executing finally block.");
            }
            Console.WriteLine($"Thread '{Thread.CurrentThread.Name} finishing normal execution.");
            Console.WriteLine();
        }

        public static void Main()
        {
            Console.WriteLine("Threading .");
            ServerClass serverObject = new ServerClass();

            // Create the thread object, passing in the
            // serverObject.InstanceMethod method using a
            // ThreadStart delegate.
            Thread InstanceCaller = new(new ThreadStart(serverObject.InstanceMethod));

            // Start the thread.
            InstanceCaller.Start();

            Console.WriteLine("The Main() thread calls this after "
                + "starting the new InstanceCaller thread.");

            // Create the thread object, passing in the
            // serverObject.StaticMethod method using a
            // ThreadStart delegate.
            Thread StaticCaller = new(new ThreadStart(ServerClass.StaticMethod));

            // Start the thread.
            StaticCaller.Start();

            Console.WriteLine("The Main() thread calls this after "
                + "starting the new StaticCaller thread.");

            // Supply the state information required by the task.
            ThreadWithState tws = new("This report displays the number {0}.", 42);

            // Create a thread to execute the task, and then
            // start the thread.
            Thread t = new(new ThreadStart(tws.ThreadProc));
            t.Start();
            Console.WriteLine("Main thread does some work, then waits.");
            t.Join();
            Console.WriteLine(
                "Independent task has completed; main thread ends.");

            // Supply the state information required by the task.
            ThreadWithState2 tws1 = new(
                "This report displays the number {0}.",
                42,
                new ExampleCallback(ResultCallback)
            );

            Thread t1 = new(new ThreadStart(tws1.ThreadProc));
            t1.Start();
            Console.WriteLine("Main thread does some work, then waits.");
            t1.Join();
            Console.WriteLine(
                "Independent task has completed; main thread ends.");

            //Pause and Interupt
            // Interrupt a sleeping thread.
            Console.WriteLine("Pause and Interupt Thread.");
            var sleepingThread = new Thread(ThreadUsage.SleepIndefinitely);
            sleepingThread.Name = "Sleeping";
            sleepingThread.Start();
            Thread.Sleep(2000);
            sleepingThread.Interrupt();

            Thread.Sleep(1000);

            sleepingThread = new Thread(ThreadUsage.SleepIndefinitely);
            sleepingThread.Name = "Sleeping2";
            sleepingThread.Start();
            Thread.Sleep(2000);
            //sleepingThread.Abort();
            sleepingThread.Interrupt();

            //Cancel Thread
            // The Simple class controls access to the token source.
            Console.WriteLine("CancellationTokenSource .........");
            CancellationTokenSource cts = new CancellationTokenSource();

            Console.WriteLine("Press 'C' to terminate the application...\n");
            // Allow the UI thread to capture the token source, so that it
            // can issue the cancel command.
            Thread t11 = new Thread(() =>
            {
                cts.Cancel();
            });

            // ServerClass sees only the token, not the token source.
            Thread t2 = new Thread(new ParameterizedThreadStart(ServerClass.StaticMethod));
            // Start the UI thread.

            t11.Start();

            // Start the worker thread and pass it the token.
            t2.Start(cts.Token);

            t2.Join();
            cts.Dispose();

        }

        // The callback method must match the signature of the
        // callback delegate.
        public static void ResultCallback(int lineCount)
        {
            Console.WriteLine($"Independent task printed {lineCount} lines.");
        }

    }
}