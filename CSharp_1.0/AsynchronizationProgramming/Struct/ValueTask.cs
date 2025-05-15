/**
Provides an awaitable result of an asynchronous operation.

    public readonly struct ValueTask : IEquatable<System.Threading.Tasks.ValueTask>

A ValueTask instance may either be awaited or converted to a Task using AsTask. A ValueTask instance may only be awaited once, and consumers may not call GetAwaiter() until the instance has completed. If these limitations are unacceptable, convert the ValueTask to a Task by calling AsTask.

The following operations should never be performed on a ValueTask instance:

Awaiting the instance multiple times.
Calling AsTask multiple times.
Using more than one of these techniques to consume the instance.
If you do any of the above, the results are undefined.

A ValueTask is a structure that can wrap either a Task or a IValueTaskSource instance. Returning a ValueTask that wraps a IValueTaskSource instance from an asynchronous method enables high-throughput applications to avoid allocations by using a pool of reusable IValueTaskSource objects. For more information, see Understanding the Whys, Whats, and Whens of ValueTask.

Using a ValueTask instead of a Task introduces some overhead. Because ValueTask is a structure with multiple fields, returning it from the method results in copying more data compared to returning a single Task reference. As such, the default choice for any asynchronous method that does not return a result should be to return a Task. Only if performance analysis proves it worthwhile should a ValueTask be used instead of a Task. The Task.CompletedTask property should be used to hand back a successfully completed singleton in the case where a method returning a Task completes synchronously and successfully.

Constructors:
-------------
ValueTask(IValueTaskSource, Int16)	- Initializes a new instance of the ValueTask class using the supplied IValueTaskSource object that represents the operation.
ValueTask(Task)	- Initializes a new instance of the ValueTask class using the supplied task that represents the operation.

Properties:
-----------
CompletedTask	- Gets a task that has already completed successfully.
IsCanceled	- Gets a value that indicates whether this object represents a canceled operation.
IsCompleted	- Gets a value that indicates whether this object represents a completed operation.
IsCompletedSuccessfully	- Gets a value that indicates whether this object represents a successfully completed operation.
IsFaulted	- Gets a value that indicates whether this object represents a failed operation.

Methods:
--------
AsTask() - Retrieves a Task object that represents this ValueTask.
ConfigureAwait(Boolean)	- Configures an awaiter for this value.
Equals(Object)	- Determines whether the specified object is equal to the current ValueTask instance.
Equals(ValueTask)	- Determines whether the specified ValueTask object is equal to the current ValueTask object.
FromCanceled(CancellationToken)	- Creates a ValueTask that has completed due to cancellation with the specified cancellation token.
FromCanceled<TResult>(CancellationToken) - Creates a ValueTask<TResult> that has completed due to cancellation with the specified cancellation token.
FromException(Exception)	- Creates a ValueTask that has completed with the specified exception.
FromException<TResult>(Exception)	- Creates a ValueTask<TResult> that has completed with the specified exception.
FromResult<TResult>(TResult)	- Creates a ValueTask<TResult> that's completed successfully with the specified result.
GetAwaiter()	- Creates an awaiter for this value.
GetHashCode()	- Returns the hash code for this instance.
Preserve()	- Gets a ValueTask that may be used at any point in the future.

Operators:
-----------
Equality(ValueTask, ValueTask)	- Compares two ValueTask values for equality.
Inequality(ValueTask, ValueTask)	- Determines whether two ValueTask values are unequal.


ValueTask<TResult> Struct:
--------------------------
Provides a value type that wraps a Task<TResult> and a TResult, only one of which is used.

    public readonly struct ValueTask<TResult> : IEquatable<System.Threading.Tasks.ValueTask<TResult>>

Constructors:
-------------
ValueTask<TResult>(IValueTaskSource<TResult>, Int16) - Initializes a new instance of the ValueTask<TResult> class with a IValueTaskSource<TResult> object that represents the operation.
ValueTask<TResult>(Task<TResult>)	- Initializes a new instance of the ValueTask<TResult> class using the supplied task that represents the operation.
ValueTask<TResult>(TResult)	- Initializes a new instance of the ValueTask<TResult> class using the supplied result of a successful operation.

Properties:
-----------
IsCanceled	- Gets a value that indicates whether this object represents a canceled operation.
IsCompleted	- Gets a value that indicates whether this object represents a completed operation.
IsCompletedSuccessfully	- Gets a value that indicates whether this object represents a successfully completed operation.
IsFaulted	- Gets a value that indicates whether this object represents a failed operation.
Result	- Gets the result.

Methods:
---------
AsTask() - Retrieves a Task<TResult> object that represents this ValueTask<TResult>.
ConfigureAwait(Boolean)	- Configures an awaiter for this value.
Equals(Object)	- Determines whether the specified object is equal to the current object.
Equals(ValueTask<TResult>)	- Determines whether the specified ValueTask<TResult> object is equal to the current ValueTask<TResult> object.
GetAwaiter()	- Creates an awaiter for this value.
GetHashCode()	- Returns the hash code for this instance.
Preserve()	- Gets a ValueTask<TResult> that may be used at any point in the future.
ToString()	- Returns a string that represents the current object.


Operators:
----------
Equality(ValueTask<TResult>, ValueTask<TResult>)	- Compares two values for equality.
Inequality(ValueTask<TResult>, ValueTask<TResult>)	- Determines whether two ValueTask<TResult> values are unequal.

**/