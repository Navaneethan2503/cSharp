using System;
using System.Threading;
/**
CountdownEvent is a synchronization primitive in C# that allows threads to wait until a specified number of signals have been received. It's particularly useful in scenarios where you need to wait for multiple operations to complete before proceeding.

🧠 Key Concepts
🔄 What is CountdownEvent?:
---------------------------
CountdownEvent starts with an initial count.
Each call to Signal() decrements the count.
When the count reaches zero, the event is signaled, and any waiting threads are released.

🛠️ Basic Usage:
------------------
Initialization: Set the initial count.
Signaling: Call Signal() to decrement the count.
Waiting: Call Wait() to block until the count reaches zero.

CountdownEvent has these additional features:
    The wait operation can be canceled by using cancellation tokens.
    Its signal count can be incremented after the instance is created.
    Instances can be reused after Wait has returned by calling the Reset method.
    Instances expose a WaitHandle for integration with other .NET synchronization APIs, such as WaitAll.


 Advanced Features:
 -----------------
1. Resetting - You can reset the CountdownEvent to reuse it.
2. Adding Count - You can dynamically increase the count.
3. Cancellation - You can use a CancellationToken to cancel the wait operation.

CountdownEvent Class:
---------------------

Represents a synchronization primitive that is signaled when its count reaches zero.

    public class CountdownEvent : IDisposable

Constructors:
-------------
CountdownEvent(Int32)	- Initializes a new instance of CountdownEvent class with the specified count.

Properties:
------------
CurrentCount - Gets the number of remaining signals required to set the event.
InitialCount - Gets the numbers of signals initially required to set the event.
IsSet	- Indicates whether the CountdownEvent object's current count has reached zero.
WaitHandle	- Gets a WaitHandle that is used to wait for the event to be set.

Methods:
---------
AddCount()	- Increments the CountdownEvent's current count by one.
AddCount(Int32)	- Increments the CountdownEvent's current count by a specified value.
Dispose()	- Releases all resources used by the current instance of the CountdownEvent class.
Dispose(Boolean)	- Releases the unmanaged resources used by the CountdownEvent, and optionally releases the managed resources.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Reset()	- Resets the CurrentCount to the value of InitialCount.
Reset(Int32) - Resets the InitialCount property to a specified value.
Signal()	- Registers a signal with the CountdownEvent, decrementing the value of CurrentCount.
Signal(Int32)	- Registers multiple signals with the CountdownEvent, decrementing the value of CurrentCount by the specified amount.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryAddCount()	- Attempts to increment CurrentCount by one.
TryAddCount(Int32)	- Attempts to increment CurrentCount by a specified value.
Wait()	- Blocks the current thread until the CountdownEvent is set.
Wait(CancellationToken)	- Blocks the current thread until the CountdownEvent is set, while observing a CancellationToken.
Wait(Int32, CancellationToken)	- Blocks the current thread until the CountdownEvent is set, using a 32-bit signed integer to measure the timeout, while observing a CancellationToken.
Wait(Int32)	- Blocks the current thread until the CountdownEvent is set, using a 32-bit signed integer to measure the timeout.
Wait(TimeSpan, CancellationToken)	- Blocks the current thread until the CountdownEvent is set, using a TimeSpan to measure the timeout, while observing a CancellationToken.
Wait(TimeSpan)	- Blocks the current thread until the CountdownEvent is set, using a TimeSpan to measure the timeout.


**/
namespace ThreadingSynronization{
    class CountDownEventClass{
        public static void Main(){
            Console.WriteLine("Count Down Event .");
            CountdownEvent countdown = new CountdownEvent(3);

            void Worker()
            {
                Console.WriteLine("Worker started");
                Thread.Sleep(1000); // Simulate work
                countdown.Signal();
                Console.WriteLine("Worker finished");
            }

            // Start three worker threads
            new Thread(Worker).Start();
            new Thread(Worker).Start();
            new Thread(Worker).Start();

            // Wait for all workers to finish
            countdown.Wait();
            Console.WriteLine("All workers finished");

            countdown.Reset(5); // Reset with a new count

            countdown.AddCount(2); // Increase the count by 2

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel(); // Cancel the token

            try
            {
                countdown.Wait(cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Wait operation was canceled");
            }



        }
    }
}


