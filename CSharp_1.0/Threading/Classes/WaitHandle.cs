/**
WaitHandle Class
------------------

Encapsulates operating system-specific objects that wait for exclusive access to shared resources.

    public abstract class WaitHandle : MarshalByRefObject, IDisposable

The WaitHandle class encapsulates a native operating system synchronization handle and is used to represent all synchronization objects in the runtime that allow multiple wait operations.

The WaitHandle class itself is abstract. Classes derived from WaitHandle define a signaling mechanism to indicate taking or releasing access to a shared resource, but they use the inherited WaitHandle methods to block while waiting for access to shared resources. The classes derived from WaitHandle include:

The Mutex class. See Mutexes.

The EventWaitHandle class and its derived classes, AutoResetEvent and ManualResetEvent.

The Semaphore class. See Semaphore and SemaphoreSlim.

Threads can block on an individual wait handle by calling the instance method WaitOne, which is inherited by classes derived from WaitHandle.

The derived classes of WaitHandle differ in their thread affinity. Event wait handles (EventWaitHandle, AutoResetEvent, and ManualResetEvent) and semaphores do not have thread affinity; any thread can signal an event wait handle or semaphore. Mutexes, on the other hand, do have thread affinity; the thread that owns a mutex must release it, and an exception is thrown if a thread calls the ReleaseMutex method on a mutex that it does not own.

Because the WaitHandle class derives from MarshalByRefObject, these classes can be used to synchronize the activities of threads across application domain boundaries.

In addition to its derived classes, the WaitHandle class has a number of static methods that block a thread until one or more synchronization objects receive a signal. These include:

SignalAndWait, which allows a thread to signal one wait handle and immediately wait on another.

WaitAll, which allows a thread to wait until all the wait handles in an array receive a signal.

WaitAny, which allows a thread to wait until any one of a specified set of wait handles has been signaled.

The overloads of these methods provide timeout intervals for abandoning the wait, and the opportunity to exit a synchronization context before entering the wait, allowing other threads to use the synchronization context.

Constructors:
-------------
WaitHandle()	- Initializes a new instance of the WaitHandle class.

Fields:
-------
InvalidHandle - Represents an invalid native operating system handle. This field is read-only.
WaitTimeout	- Indicates that a WaitAny(WaitHandle[], Int32, Boolean) operation timed out before any of the wait handles were signaled. This field is constant.

Properties:
-----------
Handle	- Obsolete. Gets or sets the native operating system handle.
SafeWaitHandle	- Gets or sets the native operating system handle.

Methods:
--------
Close()	- Releases all resources held by the current WaitHandle.
Dispose()	- Releases all resources used by the current instance of the WaitHandle class.
Dispose(Boolean)	- When overridden in a derived class, releases the unmanaged resources used by the WaitHandle, and optionally releases the managed resources.
Equals(Object)	- Determines whether the specified object is equal to the current object.
(Inherited from Object)
GetHashCode()	- Serves as the default hash function.
(Inherited from Object)
GetLifetimeService()	- Obsolete. Retrieves the current lifetime service object that controls the lifetime policy for this instance.(Inherited from MarshalByRefObject)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
InitializeLifetimeService()	- Obsolete. Obtains a lifetime service object to control the lifetime policy for this instance.(Inherited from MarshalByRefObject)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
MemberwiseClone(Boolean)	- Creates a shallow copy of the current MarshalByRefObject object.(Inherited from MarshalByRefObject)

SignalAndWait(WaitHandle, WaitHandle, Int32, Boolean)	- Signals one WaitHandle and waits on another, specifying a time-out interval as a 32-bit signed integer and specifying whether to exit the synchronization domain for the context before entering the wait.
SignalAndWait(WaitHandle, WaitHandle, TimeSpan, Boolean)	- Signals one WaitHandle and waits on another, specifying the time-out interval as a TimeSpan and specifying whether to exit the synchronization domain for the context before entering the wait.
SignalAndWait(WaitHandle, WaitHandle)	- Signals one WaitHandle and waits on another.
ToString()	- Returns a string that represents the current object.(Inherited from Object)

WaitAll(WaitHandle[], Int32, Boolean)	- Waits for all the elements in the specified array to receive a signal, using an Int32 value to specify the time interval and specifying whether to exit the synchronization domain before the wait.
WaitAll(WaitHandle[], Int32)	- Waits for all the elements in the specified array to receive a signal, using an Int32 value to specify the time interval.
WaitAll(WaitHandle[], TimeSpan, Boolean)	- Waits for all the elements in the specified array to receive a signal, using a TimeSpan value to specify the time interval, and specifying whether to exit the synchronization domain before the wait.
WaitAll(WaitHandle[], TimeSpan)	- Waits for all the elements in the specified array to receive a signal, using a TimeSpan value to specify the time interval.
WaitAll(WaitHandle[])	- Waits for all the elements in the specified array to receive a signal.

WaitAny(WaitHandle[], Int32, Boolean)	- Waits for any of the elements in the specified array to receive a signal, using a 32-bit signed integer to specify the time interval, and specifying whether to exit the synchronization domain before the wait.
WaitAny(WaitHandle[], Int32)	- Waits for any of the elements in the specified array to receive a signal, using a 32-bit signed integer to specify the time interval.
WaitAny(WaitHandle[], TimeSpan, Boolean)	- Waits for any of the elements in the specified array to receive a signal, using a TimeSpan to specify the time interval and specifying whether to exit the synchronization domain before the wait.
WaitAny(WaitHandle[], TimeSpan)	- Waits for any of the elements in the specified array to receive a signal, using a TimeSpan to specify the time interval.
WaitAny(WaitHandle[])	 -Waits for any of the elements in the specified array to receive a signal.

WaitOne()	- Blocks the current thread until the current WaitHandle receives a signal.
WaitOne(Int32, Boolean)	- Blocks the current thread until the current WaitHandle receives a signal, using a 32-bit signed integer to specify the time interval and specifying whether to exit the synchronization domain before the wait.
WaitOne(Int32)	- Blocks the current thread until the current WaitHandle receives a signal, using a 32-bit signed integer to specify the time interval in milliseconds.
WaitOne(TimeSpan, Boolean)	- Blocks the current thread until the current instance receives a signal, using a TimeSpan to specify the time interval and specifying whether to exit the synchronization domain before the wait.
WaitOne(TimeSpan)	- Blocks the current thread until the current instance receives a signal, using a TimeSpan to specify the time interval.



**/