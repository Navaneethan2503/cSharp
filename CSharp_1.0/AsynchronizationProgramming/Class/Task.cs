using System;
/**

Constructors:
-------------
Task(Action, CancellationToken, TaskCreationOptions)	- Initializes a new Task with the specified action and creation options.
Task(Action, CancellationToken)	- Initializes a new Task with the specified action and CancellationToken.
Task(Action, TaskCreationOptions)	- Initializes a new Task with the specified action and creation options.
Task(Action)	- Initializes a new Task with the specified action.
Task(Action<Object>, Object, CancellationToken, TaskCreationOptions) - Initializes a new Task with the specified action, state, and options
Task(Action<Object>, Object, CancellationToken)	- Initializes a new Task with the specified action, state, and CancellationToken.
Task(Action<Object>, Object, TaskCreationOptions)	- Initializes a new Task with the specified action, state, and options.
Task(Action<Object>, Object)	- Initializes a new Task with the specified action and state.

Properties:
-----------
AsyncState	- Gets the state object supplied when the Task was created, or null if none was supplied.
CompletedTask	- Gets a task that has already completed successfully.
CreationOptions	- Gets the TaskCreationOptions used to create this task.
CurrentId	- Returns the ID of the currently executing Task.
Exception	- Gets the AggregateException that caused the Task to end prematurely. If the Task completed successfully or has not yet thrown any exceptions, this will return null.
Factory	- Provides access to factory methods for creating and configuring Task and Task<TResult> instances.
    public static System.Threading.Tasks.TaskFactory Factory { get; }

Id	- Gets an ID for this Task instance.
IsCanceled	- Gets whether this Task instance has completed execution due to being canceled.
IsCompleted	- Gets a value that indicates whether the task has completed.
IsCompletedSuccessfully	- Gets whether the task ran to completion.
IsFaulted	- Gets whether the Task completed due to an unhandled exception.
Status	- Gets the TaskStatus of this task.


Methods:
--------
ConfigureAwait(Boolean)	- Configures an awaiter used to await this Task.
ConfigureAwait(ConfigureAwaitOptions)	 - Configures an awaiter used to await this Task.
    public System.Runtime.CompilerServices.ConfiguredTaskAwaitable ConfigureAwait(bool continueOnCapturedContext);
    When an asynchronous method awaits a Task directly, continuation usually occurs in the same thread that created the task, depending on the async context. This behavior can be costly in terms of performance and can result in a deadlock on the UI thread. To avoid these problems, call Task.ConfigureAwait(false)
    
ContinueWith(Action<Task,Object>, Object, CancellationToken, TaskContinuationOptions, TaskScheduler)	- Creates a continuation that receives caller-supplied state information and a cancellation token and that executes when the target Task completes. The continuation executes based on a set of specified conditions and uses a specified scheduler.
ContinueWith(Action<Task,Object>, Object, CancellationToken)	- Creates a continuation that receives caller-supplied state information and a cancellation token and that executes asynchronously when the target Task completes.
ContinueWith(Action<Task,Object>, Object, TaskContinuationOptions)	- Creates a continuation that receives caller-supplied state information and executes when the target Task completes. The continuation executes based on a set of specified conditions.
ContinueWith(Action<Task,Object>, Object, TaskScheduler)	- Creates a continuation that receives caller-supplied state information and executes asynchronously when the target Task completes. The continuation uses a specified scheduler.
ContinueWith(Action<Task,Object>, Object)	- Creates a continuation that receives caller-supplied state information and executes when the target Task completes.
ContinueWith(Action<Task>, CancellationToken, TaskContinuationOptions, TaskScheduler)	- Creates a continuation that executes when the target task competes according to the specified TaskContinuationOptions. The continuation receives a cancellation token and uses a specified scheduler.
ContinueWith(Action<Task>, CancellationToken)	- Creates a continuation that receives a cancellation token and executes asynchronously when the target Task completes.
ContinueWith(Action<Task>, TaskContinuationOptions)	- Creates a continuation that executes when the target task completes according to the specified TaskContinuationOptions.
ContinueWith(Action<Task>, TaskScheduler)	- Creates a continuation that executes asynchronously when the target Task completes. The continuation uses a specified scheduler.
ContinueWith(Action<Task>)	- Creates a continuation that executes asynchronously when the target Task completes.
ContinueWith<TResult>(Func<Task,Object,TResult>, Object, CancellationToken, TaskContinuationOptions, TaskScheduler)	 - Creates a continuation that executes based on the specified task continuation options when the target Task completes and returns a value. The continuation receives caller-supplied state information and a cancellation token and uses the specified scheduler.
ContinueWith<TResult>(Func<Task,Object,TResult>, Object, CancellationToken)	- Creates a continuation that executes asynchronously when the target Task completes and returns a value. The continuation receives caller-supplied state information and a cancellation token.
ContinueWith<TResult>(Func<Task,Object,TResult>, Object, TaskContinuationOptions)	- Creates a continuation that executes based on the specified task continuation options when the target Task completes. The continuation receives caller-supplied state information.
ContinueWith<TResult>(Func<Task,Object,TResult>, Object, TaskScheduler)	- Creates a continuation that executes asynchronously when the target Task completes. The continuation receives caller-supplied state information and uses a specified scheduler.
ContinueWith<TResult>(Func<Task,Object,TResult>, Object)	- Creates a continuation that receives caller-supplied state information and executes asynchronously when the target Task completes and returns a value.
ContinueWith<TResult>(Func<Task,TResult>, CancellationToken, TaskContinuationOptions, TaskScheduler)	- Creates a continuation that executes according to the specified continuation options and returns a value. The continuation is passed a cancellation token and uses a specified scheduler.
ContinueWith<TResult>(Func<Task,TResult>, CancellationToken)	- Creates a continuation that executes asynchronously when the target Task completes and returns a value. The continuation receives a cancellation token.
ContinueWith<TResult>(Func<Task,TResult>, TaskContinuationOptions)	- Creates a continuation that executes according to the specified continuation options and returns a value.
ContinueWith<TResult>(Func<Task,TResult>, TaskScheduler)	- Creates a continuation that executes asynchronously when the target Task completes and returns a value. The continuation uses a specified scheduler.
ContinueWith<TResult>(Func<Task,TResult>)	- Creates a continuation that executes asynchronously when the target Task<TResult> completes and returns a value.
    Creates a continuation that executes asynchronously when the target Task completes.


Delay(Int32, CancellationToken)	- Creates a cancellable task that completes after a specified number of milliseconds.
Delay(Int32)	- Creates a task that completes after a specified number of milliseconds.
    The number of milliseconds to wait before completing the returned task, or -1 to wait indefinitely.

Delay(TimeSpan, CancellationToken)	- Creates a cancellable task that completes after a specified time interval.
Delay(TimeSpan, TimeProvider, CancellationToken)	- Creates a cancellable task that completes after a specified time interval.
Delay(TimeSpan, TimeProvider)	- Creates a task that completes after a specified time interval.
Delay(TimeSpan)	- Creates a task that completes after a specified time interval.
    Creates a task that will complete after a time delay.

Dispose()	- Releases all resources used by the current instance of the Task class.
Dispose(Boolean)	- Disposes the Task, releasing all of its unmanaged resources.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)

FromCanceled(CancellationToken)	- Creates a Task that's completed due to cancellation with a specified cancellation token.
FromCanceled<TResult>(CancellationToken)	- Creates a Task<TResult> that's completed due to cancellation with a specified cancellation token.

FromException(Exception)	- Creates a Task that has completed with a specified exception.
FromException<TResult>(Exception)	- Creates a Task<TResult> that's completed with a specified exception.
FromResult<TResult>(TResult)	- Creates a Task<TResult> that's completed successfully with the specified result.
    public static System.Threading.Tasks.Task<TResult> FromResult<TResult>(TResult result);

GetAwaiter()	- Gets an awaiter used to await this Task.
    public System.Runtime.CompilerServices.TaskAwaiter GetAwaiter();

GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)

Run(Action, CancellationToken)	- Queues the specified work to run on the thread pool and returns a Task object that represents that work. A cancellation token allows the work to be cancelled if it has not yet started.
Run(Action)	- Queues the specified work to run on the thread pool and returns a Task object that represents that work.
Run(Func<Task>, CancellationToken)	- Queues the specified work to run on the thread pool and returns a proxy for the task returned by function. A cancellation token allows the work to be cancelled if it has not yet started.
Run(Func<Task>)	- Queues the specified work to run on the thread pool and returns a proxy for the task returned by function.
Run<TResult>(Func<Task<TResult>>, CancellationToken)	- Queues the specified work to run on the thread pool and returns a proxy for the Task(TResult) returned by function.
Run<TResult>(Func<Task<TResult>>)	- Queues the specified work to run on the thread pool and returns a proxy for the Task(TResult) returned by function. A cancellation token allows the work to be cancelled if it has not yet started.
Run<TResult>(Func<TResult>, CancellationToken)	- Queues the specified work to run on the thread pool and returns a Task(TResult) object that represents that work.
Run<TResult>(Func<TResult>)	- Queues the specified work to run on the thread pool and returns a Task<TResult> object that represents that work. A cancellation token allows the work to be cancelled if it has not yet started.
    Queues the specified work to run on the ThreadPool and returns a task or Task<TResult> handle for that work.

RunSynchronously()	- Runs the Task synchronously on the current TaskScheduler.
RunSynchronously(TaskScheduler)	- Runs the Task synchronously on the TaskScheduler provided.

Start()	- Starts the Task, scheduling it for execution to the current TaskScheduler.
Start(TaskScheduler)	- Starts the Task, scheduling it for execution to the specified TaskScheduler.

ToString()	- Returns a string that represents the current object.(Inherited from Object)

Wait()	- Waits for the Task to complete execution.
Wait(CancellationToken)	- Waits for the Task to complete execution. The wait terminates if a cancellation token is canceled before the task completes.
Wait(Int32, CancellationToken)	- Waits for the Task to complete execution. The wait terminates if a timeout interval elapses or a cancellation token is canceled before the task completes.
Wait(Int32)	- Waits for the Task to complete execution within a specified number of milliseconds.
Wait(TimeSpan, CancellationToken)	- Waits for the Task to complete execution.
Wait(TimeSpan)	- Waits for the Task to complete execution within a specified time interval.


WaitAll(IEnumerable<Task>, CancellationToken)	- Waits for all of the provided Task objects to complete execution unless the wait is cancelled.
WaitAll(ReadOnlySpan<Task>)	- Waits for all of the provided Task objects to complete execution.
WaitAll(Task[], CancellationToken)	- Waits for all of the provided Task objects to complete execution unless the wait is cancelled.
WaitAll(Task[], Int32, CancellationToken)	- Waits for all of the provided Task objects to complete execution within a specified number of milliseconds or until the wait is cancelled.
WaitAll(Task[], Int32)	- Waits for all of the provided Task objects to complete execution within a specified number of milliseconds.
WaitAll(Task[], TimeSpan)	- Waits for all of the provided cancellable Task objects to complete execution within a specified time interval.
WaitAll(Task[])	- Waits for all of the provided Task objects to complete execution.
    Waits for all of the provided Task objects to complete execution.

WaitAny(Task[], CancellationToken)	- Waits for any of the provided Task objects to complete execution unless the wait is cancelled.
WaitAny(Task[], Int32, CancellationToken)	- Waits for any of the provided Task objects to complete execution within a specified number of milliseconds or until a cancellation token is cancelled.
WaitAny(Task[], Int32)	- Waits for any of the provided Task objects to complete execution within a specified number of milliseconds.
WaitAny(Task[], TimeSpan)	- Waits for any of the provided Task objects to complete execution within a specified time interval.
WaitAny(Task[])	- Waits for any of the provided Task objects to complete execution.

WaitAsync(CancellationToken)	- Gets a Task that will complete when this Task completes or when the specified CancellationToken has cancellation requested.
WaitAsync(TimeSpan, CancellationToken)	- Gets a Task that will complete when this Task completes, when the specified timeout expires, or when the specified CancellationToken has cancellation requested.
WaitAsync(TimeSpan, TimeProvider, CancellationToken)	- Gets a Task that will complete when this Task completes, when the specified timeout expires, or when the specified CancellationToken has cancellation requested.
WaitAsync(TimeSpan, TimeProvider)	- Gets a Task that will complete when this Task completes or when the specified timeout expires.
WaitAsync(TimeSpan)	- Gets a Task that will complete when this Task completes or when the specified timeout expires.

WhenAll(IEnumerable<Task>)	- Creates a task that will complete when all of the Task objects in an enumerable collection have completed.
WhenAll(ReadOnlySpan<Task>)	- Creates a task that will complete when all of the supplied tasks have completed.
WhenAll(Task[])	- Creates a task that will complete when all of the Task objects in an array have completed.
WhenAll<TResult>(IEnumerable<Task<TResult>>)	- Creates a task that will complete when all of the Task<TResult> objects in an enumerable collection have completed.
WhenAll<TResult>(ReadOnlySpan<Task<TResult>>)	- Creates a task that will complete when all of the supplied tasks have completed.
WhenAll<TResult>(Task<TResult>[])	- Creates a task that will complete when all of the Task<TResult> objects in an array have completed.
    public static System.Threading.Tasks.Task WhenAll(System.Collections.Generic.IEnumerable<System.Threading.Tasks.Task> tasks);

WhenAny(IEnumerable<Task>)	- Creates a task that will complete when any of the supplied tasks have completed.
WhenAny(ReadOnlySpan<Task>)	- Creates a task that will complete when any of the supplied tasks have completed.
WhenAny(Task, Task)	- Creates a task that will complete when either of the supplied tasks have completed.
WhenAny(Task[])	- Creates a task that will complete when any of the supplied tasks have completed.
WhenAny<TResult>(IEnumerable<Task<TResult>>)	- Creates a task that will complete when any of the supplied tasks have completed.
WhenAny<TResult>(ReadOnlySpan<Task<TResult>>)	 - Creates a task that will complete when any of the supplied tasks have completed.
WhenAny<TResult>(Task<TResult>, Task<TResult>)	- Creates a task that will complete when either of the supplied tasks have completed.
WhenAny<TResult>(Task<TResult>[])	- Creates a task that will complete when any of the supplied tasks have completed.

WhenEach(IEnumerable<Task>)
WhenEach(ReadOnlySpan<Task>)
WhenEach(Task[])	
Creates an IAsyncEnumerable<T> that will yield the supplied tasks as those tasks complete.

WhenEach<TResult>(IEnumerable<Task<TResult>>)
WhenEach<TResult>(ReadOnlySpan<Task<TResult>>)
WhenEach<TResult>(Task<TResult>[])
Yield()	- Creates an awaitable task that asynchronously yields back to the current context when awaited.

Explicit Interface Implementations:
-----------------------------------
IAsyncResult.AsyncWaitHandle	- Gets a WaitHandle that can be used to wait for the task to complete.
IAsyncResult.CompletedSynchronously	- Gets an indication of whether the operation completed synchronously.


**/
namespace AsynchronousProgramming{
    class TaskClass{
        public static void Main(){
            Console.WriteLine("Task Class");
        }
    }
}