/**
 creating and scheduling Task objects.

    public class TaskFactory

.NET provides two factories for creating and scheduling tasks:

    The TaskFactory class, which creates Task and Task<TResult> objects. You can call the overloads of this method to create and execute a task that requires non-default arguments.
    The TaskFactory<TResult> class, which creates Task<TResult> objects.

The TaskFactory class allows you to do the following:

    Create a task and start it immediately by calling the StartNew method.
    Create a task that starts when any one of the tasks in an array has completed by calling the ContinueWhenAny method.
    Create a task that starts when all the tasks in an array have completed by calling the ContinueWhenAll method.

The static Task<TResult>.Factory property returns a default TaskFactory<TResult> object. You can also call one of the TaskFactory class constructors to configure the Task objects that the TaskFactory class creates.

Constructors:
-------------
TaskFactory()	- Initializes a TaskFactory instance with the default configuration.
TaskFactory(CancellationToken, TaskCreationOptions, TaskContinuationOptions, TaskScheduler)	- Initializes a TaskFactory instance with the specified configuration.
TaskFactory(CancellationToken)	- Initializes a TaskFactory instance with the specified configuration.
TaskFactory(TaskCreationOptions, TaskContinuationOptions)	- Initializes a TaskFactory instance with the specified configuration.
TaskFactory(TaskScheduler)	- Initializes a TaskFactory instance with the specified configuration.

Properties:
-----------
CancellationToken	- Gets the default cancellation token for this task factory.
ContinuationOptions	- Gets the default task continuation options for this task factory.
CreationOptions	- Gets the default task creation options for this task factory.
Scheduler	- Gets the default task scheduler for this task factory.

Methods:
--------
ContinueWhenAll(Task[], Action<Task[]>, CancellationToken, TaskContinuationOptions, TaskScheduler)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll(Task[], Action<Task[]>, CancellationToken)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll(Task[], Action<Task[]>, TaskContinuationOptions)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll(Task[], Action<Task[]>)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TAntecedentResult,TResult>(Task<TAntecedentResult>[], Func<Task<TAntecedentResult>[],TResult>, CancellationTok- en, TaskContinuationOptions, TaskScheduler)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TAntecedentResult,TResult>(Task<TAntecedentResult>[], Func<Task<TAntecedentResult>[],TResult>, CancellationToken)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TAntecedentResult,TResult>(Task<TAntecedentResult>[], Func<Task<TAntecedentResult>[],TResult>, TaskContinuationOptions)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TAntecedentResult,TResult>(Task<TAntecedentResult>[], Func<Task<TAntecedentResult>[],TResult>)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[], Action<Task<TAntecedentResult>[]>, CancellationToken, TaskContinuationOptions, TaskScheduler)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[], Action<Task<TAntecedentResult>[]>, CancellationToken)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[], Action<Task<TAntecedentResult>[]>, TaskContinuationOptions)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[], Action<Task<TAntecedentResult>[]>)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TResult>(Task[], Func<Task[],TResult>, CancellationToken, TaskContinuationOptions, TaskScheduler)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TResult>(Task[], Func<Task[],TResult>, CancellationToken)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TResult>(Task[], Func<Task[],TResult>, TaskContinuationOptions)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAll<TResult>(Task[], Func<Task[],TResult>)	- Creates a continuation task that starts when a set of specified tasks has completed.
ContinueWhenAny(Task[], Action<Task>, CancellationToken, TaskContinuationOptions, TaskScheduler)	- Creates a continuation Task that will be started upon the completion of any Task in the provided set.
ContinueWhenAny(Task[], Action<Task>, CancellationToken)	- Creates a continuation Task that will be started upon the completion of any Task in the provided set.
ContinueWhenAny(Task[], Action<Task>, TaskContinuationOptions)	- Creates a continuation Task that will be started upon the completion of any Task in the provided set.
ContinueWhenAny(Task[], Action<Task>)	- Creates a continuation Task that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TAntecedentResult,TResult>(Task<TAntecedentResult>[], Func<Task<TAntecedentResult>,TResult>, CancellationToken, TaskContinuatio- Options, TaskScheduler)	- Creates a continuation Task<TResult> that will be started upon the completion of any Task in the provided set
ContinueWhenAny<TAntecedentResult,TResult>(Task<TAntecedentResult>[], Func<Task<TAntecedentResult>,TResult>, CancellationToken)	- Creates a continuation Task<TResult> that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TAntecedentResult,TResult>(Task<TAntecedentResult>[], Func<Task<TAntecedentResult>,TResult>, TaskContinuationOptions)	- Creates a continuation Task<TResult> that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TAntecedentResult,TResult>(Task<TAntecedentResult>[], Func<Task<TAntecedentResult>,TResult>)	- Creates a continuation Task<TResult> that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[], Action<Task<TAntecedentResult>>, CancellationToken, TaskContinuationOptions, TaskScheduler)	- Creates a continuation Task that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[], Action<Task<TAntecedentResult>>, CancellationToken)	- Creates a continuation Task that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[], Action<Task<TAntecedentResult>>, TaskContinuationOptions)	- Creates a continuation Task that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[], Action<Task<TAntecedentResult>>)	- Creates a continuation Task that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TResult>(Task[], Func<Task,TResult>, CancellationToken, TaskContinuationOptions, TaskScheduler)	- Creates a continuation Task<TResult> that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TResult>(Task[], Func<Task,TResult>, CancellationToken)	- Creates a continuation Task<TResult> that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TResult>(Task[], Func<Task,TResult>, TaskContinuationOptions)	- Creates a continuation Task<TResult> that will be started upon the completion of any Task in the provided set.
ContinueWhenAny<TResult>(Task[], Func<Task,TResult>)	- Creates a continuation Task<TResult> that will be started upon the completion of any Task in the provided set.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
FromAsync(Func<AsyncCallback,Object,IAsyncResult>, Action<IAsyncResult>, Object, TaskCreationOptions)	- Creates a Task that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync(Func<AsyncCallback,Object,IAsyncResult>, Action<IAsyncResult>, Object)	- Creates a Task that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync(IAsyncResult, Action<IAsyncResult>, TaskCreationOptions, TaskScheduler)	- Creates a Task that executes an end method action when a specified IAsyncResult completes.
FromAsync(IAsyncResult, Action<IAsyncResult>, TaskCreationOptions)	- Creates a Task that executes an end method action when a specified IAsyncResult completes.
FromAsync(IAsyncResult, Action<IAsyncResult>)	- Creates a Task that executes an end method action when a specified IAsyncResult completes.
FromAsync<TArg1,TArg2,TArg3,TResult>(Func<TArg1,TArg2,TArg3,AsyncCallback, Object,IAsyncResult>, Func<IAsyncResult,TResult>, TArg1, TArg2, T- rg3, Object, TaskCreationOptions)	- Creates a Task<TResult> that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern
FromAsync<TArg1,TArg2,TArg3,TResult>(Func<TArg1,TArg2,TArg3,AsyncCallback, Object,IAsyncResult>, Func<IAsyncResult,TResult>, TArg1, TArg2, TArg3, Object)	- Creates a Task<TResult> that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TArg1,TArg2,TArg3>(Func<TArg1,TArg2,TArg3,AsyncCallback, Object,IAsyncResult>, Action<IAsyncResult>, TArg1, TArg2, TArg3, Object, TaskCreationOptions)	- Creates a Task that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TArg1,TArg2,TArg3>(Func<TArg1,TArg2,TArg3,AsyncCallback,Object,IAsyncResult>, Action<IAsyncResult>, TArg1, TArg2, TArg3, Object)	- Creates a Task that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TArg1,TArg2,TResult>(Func<TArg1,TArg2,AsyncCallback, Object,IAsyncResult>, Func<IAsyncResult,TResult>, TArg1, TArg2, Object, TaskCreationOptions)	- Creates a Task<TResult> that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TArg1,TArg2,TResult>(Func<TArg1,TArg2,AsyncCallback,Object,IAsyncResult>, Func<IAsyncResult,TResult>, TArg1, TArg2, Object)	- Creates a Task<TResult> that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TArg1,TArg2>(Func<TArg1,TArg2,AsyncCallback,Object,IAsyncResult>, Action<IAsyncResult>, TArg1, TArg2, Object, TaskCreationOptions)	- Creates a Task that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TArg1,TArg2>(Func<TArg1,TArg2,AsyncCallback,Object,IAsyncResult>, Action<IAsyncResult>, TArg1, TArg2, Object)	- Creates a Task that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TArg1,TResult>(Func<TArg1,AsyncCallback,Object,IAsyncResult>, Func<IAsyncResult,TResult>, TArg1, Object, TaskCreationOptions)	- Creates a Task<TResult> that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TArg1,TResult>(Func<TArg1,AsyncCallback,Object,IAsyncResult>, Func<IAsyncResult,TResult>, TArg1, Object)	- Creates a Task<TResult> that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TArg1>(Func<TArg1,AsyncCallback,Object,IAsyncResult>, Action<IAsyncResult>, TArg1, Object, TaskCreationOptions)	- Creates a Task that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TArg1>(Func<TArg1,AsyncCallback,Object,IAsyncResult>, Action<IAsyncResult>, TArg1, Object)	- Creates a Task that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TResult>(Func<AsyncCallback,Object,IAsyncResult>, Func<IAsyncResult,TResult>, Object, TaskCreationOptions)	- Creates a Task<TResult> that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TResult>(Func<AsyncCallback,Object,IAsyncResult>, Func<IAsyncResult,TResult>, Object)	- Creates a Task<TResult> that represents a pair of begin and end methods that conform to the Asynchronous Programming Model pattern.
FromAsync<TResult>(IAsyncResult, Func<IAsyncResult,TResult>, TaskCreationOptions, TaskScheduler)	- Creates a Task<TResult> that executes an end method function when a specified IAsyncResult completes.
FromAsync<TResult>(IAsyncResult, Func<IAsyncResult,TResult>, TaskCreationOptions)	- Creates a Task<TResult> that executes an end method function when a specified IAsyncResult completes.
FromAsync<TResult>(IAsyncResult, Func<IAsyncResult,TResult>)	- Creates a Task<TResult> that executes an end method function when a specified IAsyncResult completes.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)

StartNew(Action, CancellationToken, TaskCreationOptions, TaskScheduler)	- Creates and starts a task for the specified action delegate, cancellation token, creation options and state.
StartNew(Action, CancellationToken)	- Creates and starts a task for the specified action delegate and cancellation token.
StartNew(Action, TaskCreationOptions)	- Creates and starts a task for the specified action delegate and creation options.
StartNew(Action)	- Creates and starts a task for the specified action delegate.
StartNew(Action<Object>, Object, CancellationToken, TaskCreationOptions, TaskScheduler)	- Creates and starts a task for the specified action delegate, state, cancellation token, creation options and task scheduler.
StartNew(Action<Object>, Object, CancellationToken)	- Creates and starts a task for the specified action delegate, state and cancellation token.
StartNew(Action<Object>, Object, TaskCreationOptions)	- Creates and starts a task for the specified action delegate, state and creation options.
StartNew(Action<Object>, Object)	- Creates and starts a task for the specified action delegate and state.
StartNew<TResult>(Func<Object,TResult>, Object, CancellationToken, TaskCreationOptions, TaskScheduler)	- Creates and starts a task of type TResult for the specified function delegate, state, cancellation token, creation options and task scheduler.
StartNew<TResult>(Func<Object,TResult>, Object, CancellationToken)	- Creates and starts a task of type TResult for the specified function delegate, state and cancellation token.
StartNew<TResult>(Func<Object,TResult>, Object, TaskCreationOptions)	- Creates and starts a task of type TResult for the specified function delegate, state and creation options.
StartNew<TResult>(Func<Object,TResult>, Object)	- Creates and starts a task of type TResult for the specified function delegate and state.
StartNew<TResult>(Func<TResult>, CancellationToken, TaskCreationOptions, TaskScheduler)	- Creates and starts a task of type TResult for the specified function delegate, cancellation token, creation options and task scheduler.
StartNew<TResult>(Func<TResult>, CancellationToken)	- Creates and starts a task of type TResult for the specified function delegate and cancellation token.
StartNew<TResult>(Func<TResult>, TaskCreationOptions)	- Creates and starts a task of type TResult for the specified function delegate and creation options.
StartNew<TResult>(Func<TResult>)	- Creates and starts a task of type TResult for the specified function delegate.
ToString()	- Returns a string that represents the current object.(Inherited from Object)

**/
using System;
using System.Threading.Tasks;

namespace ParallelProgramming{
    class TaskFactoryClass{
        public static void Main(){
            Console.WriteLine("Task Factory Class.");
            
        }
    }
}