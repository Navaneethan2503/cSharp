using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
/**
Signals to a CancellationToken that it should be canceled.
    public class CancellationTokenSource : IDisposable


Remarks
Starting with the .NET Framework 4, the .NET Framework uses a unified model for cooperative cancellation of asynchronous or long-running synchronous operations that involves two objects:
A CancellationTokenSource object, which provides a cancellation token through its Token property and sends a cancellation message by calling its Cancel or CancelAfter method.
A CancellationToken object, which indicates whether cancellation is requested.

The general pattern for implementing the cooperative cancellation model is:
Instantiate a CancellationTokenSource object, which manages and sends cancellation notification to the individual cancellation tokens.
Pass the token returned by the CancellationTokenSource.Token property to each task or thread that listens for cancellation.
Call the CancellationToken.IsCancellationRequested method from operations that receive the cancellation token. Provide a mechanism for each task or thread to respond to a cancellation request. Whether you choose to cancel an operation, and exactly how you do it, depends on your application logic.
Call the CancellationTokenSource.Cancel method to provide notification of cancellation. This sets the CancellationToken.IsCancellationRequested property on every copy of the cancellation token to true.
Call the Dispose method when you are finished with the CancellationTokenSource object.

This type implements the IDisposable interface. When you have finished using an instance of the type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its Dispose method in a try/finally block. To dispose of it indirectly, use a language construct such as using (in C#) or Using (in Visual Basic). For more information, see the "Using an Object that Implements IDisposable" section in the IDisposable interface topic.

Constructors:
---------------
CancellationTokenSource()	- Initializes a new instance of the CancellationTokenSource class.
CancellationTokenSource(Int32)	- Initializes a new instance of the CancellationTokenSource class that will be canceled after the specified delay in milliseconds.
CancellationTokenSource(TimeSpan, TimeProvider)	- Initializes a new instance of the CancellationTokenSource class that will be canceled after the specified TimeSpan.
CancellationTokenSource(TimeSpan)	- Initializes a new instance of the CancellationTokenSource class that will be canceled after the specified time span.

Properties:
------------
IsCancellationRequested	- Gets whether cancellation has been requested for this CancellationTokenSource.
Token	- Gets the CancellationToken associated with this CancellationTokenSource.

Methods:
---------
Cancel()	- Communicates a request for cancellation.
    public void Cancel();

Cancel(Boolean)	- Communicates a request for cancellation, and specifies whether remaining callbacks and cancelable operations should be processed if an exception occurs.
CancelAfter(Int32)	- Schedules a cancel operation on this CancellationTokenSource after the specified number of milliseconds.
    public void CancelAfter(int millisecondsDelay);

CancelAfter(TimeSpan)	- Schedules a cancel operation on this CancellationTokenSource after the specified time span.
CancelAsync()	- Communicates a request for cancellation asynchronously.
CreateLinkedTokenSource(CancellationToken, CancellationToken)	- Creates a CancellationTokenSource that will be in the canceled state when any of the source tokens are in the canceled state.
    public System.Threading.Tasks.Task CancelAsync();

CreateLinkedTokenSource(CancellationToken)	- Creates a CancellationTokenSource that will be in the canceled state when the supplied token is in the canceled state.
CreateLinkedTokenSource(CancellationToken[])	- Creates a CancellationTokenSource that will be in the canceled state when any of the source tokens in the specified array are in the canceled state.
CreateLinkedTokenSource(ReadOnlySpan<CancellationToken>)	- Creates a CancellationTokenSource that will be in the canceled state when any of the source tokens are in the canceled state.
Dispose()	- Releases all resources used by the current instance of the CancellationTokenSource class.
    public void Dispose();

Dispose(Boolean)	- Releases the unmanaged resources used by the CancellationTokenSource class and optionally releases the managed resources.
TryReset()	- Attempts to reset the CancellationTokenSource to be used for an unrelated operation.
    public bool TryReset();



**/
namespace ThreadClass{
    class CancellationTokenSourceClass{
        public static void Main(){
            Console.WriteLine("CancellationTokenSource Class");
            // Define the cancellation token.
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Random rnd = new Random();
            Object lockObj = new Object();
            
            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(token);
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++) {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew( () => {
                int value;
                int[] values = new int[10];
                for (int ctr = 1; ctr <= 10; ctr++) {
                    lock (lockObj) {
                        value = rnd.Next(0,101);
                    }
                    if (value == 0) { 
                        source.Cancel();
                        Console.WriteLine("Cancelling at task {0}", iteration);
                        break;
                    }   
                    values[ctr-1] = value; 
                }
                return values;
                }, token));   
            }
            try {
                Task<double> fTask = factory.ContinueWhenAll(tasks.ToArray(), 
                (results) => {
                    Console.WriteLine("Calculating overall mean...");
                    long sum = 0;
                    int n = 0; 
                    foreach (var t in results) {
                    foreach (var r in t.Result) {
                        sum += r;
                        n++;
                    }
                    }
                    return sum/(double) n;
                } , token);
                Console.WriteLine("The mean is {0}.", fTask.Result);
            }   
            catch (AggregateException ae) {
                foreach (Exception e in ae.InnerExceptions) {
                    if (e is TaskCanceledException)
                    Console.WriteLine("Unable to compute mean: {0}", 
                        ((TaskCanceledException) e).Message);
                    else
                    Console.WriteLine("Exception: " + e.GetType().Name);
                }
            }
            finally {
                source.Dispose();
            }

            // Create the token source.
            CancellationTokenSource cts = new CancellationTokenSource();

            // Pass the token to the cancelable operation.
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoSomeWork), cts.Token);
            Thread.Sleep(2500);

            // Request cancellation.
            cts.Cancel();
            Console.WriteLine("Cancellation set in token source...");
            Thread.Sleep(2500);
            // Cancellation should have happened, so call Dispose.
            cts.Dispose();

            // Thread 2: The listener
            static void DoSomeWork(object? obj)
            {
                if (obj is null)
                    return;

                CancellationToken token = (CancellationToken)obj;

                for (int i = 0; i < 100000; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("In iteration {0}, cancellation has been requested...",
                                        i + 1);
                        // Perform cleanup if necessary.
                        //...
                        // Terminate the operation.
                        break;
                    }
                    // Simulate some work.
                    Thread.SpinWait(500000);
                }
            }

        }
    }
}