using System;
using System.Threading;
using System.Threading.Tasks;
/**
IAsyncResult Interface
---------------------------
Represents the status of an asynchronous operation.

Properties:
----------
AsyncState	- Gets a user-defined object that qualifies or contains information about an asynchronous operation.
AsyncWaitHandle	- Gets a WaitHandle that is used to wait for an asynchronous operation to complete.
CompletedSynchronously	- Gets a value that indicates whether the asynchronous operation completed synchronously.
IsCompleted	- Gets a value that indicates whether the asynchronous operation has completed.




**/
namespace AsynchronousProgramming{
    public class AsyncDemo
    {
        // The method to be executed asynchronously.
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }
    // The delegate must have the same signature as the method
    // it will call asynchronously.
    public delegate string AsyncMethodCaller(int callDuration, out int threadId);

    class IAsyncResultClass{
        public static void Main(){
            Console.WriteLine("IAsyncResult Interface.");
            // The asynchronous method puts the thread id here.
            int threadId;

            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            // Initiate the asychronous call.
            IAsyncResult result = caller.BeginInvoke(3000,
                out threadId, null, null);

            Thread.Sleep(0);
            Console.WriteLine("Main thread {0} does some work.",
                Thread.CurrentThread.ManagedThreadId);

            // Wait for the WaitHandle to become signaled.
            result.AsyncWaitHandle.WaitOne();

            // Perform additional processing here.
            // Call EndInvoke to retrieve the results.
            string returnValue = caller.EndInvoke(out threadId, result);

            // Close the wait handle.
            result.AsyncWaitHandle.Close();

            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".",
                threadId, returnValue);

        }
    }
}