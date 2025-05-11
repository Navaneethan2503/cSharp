/**
This enumeration supports a bitwise combination of its member values.
    [System.Flags]
public enum ThreadState

Fields
Name	Value	Description
Running	0	The thread has been started and not yet stopped.

StopRequested	1	The thread is being requested to stop. This is for internal use only.

SuspendRequested	2	The thread is being requested to suspend.

Background	4	The thread is being executed as a background thread, as opposed to a foreground thread. This state is controlled by setting the IsBackground property.

Unstarted	8	The Start() method has not been invoked on the thread.

Stopped	16	The thread has stopped.

WaitSleepJoin	32	The thread is blocked. This could be the result of calling Sleep(Int32) or Join(), of requesting a lock - for example, by calling Enter(Object) or Wait(Object, Int32, Boolean) - or of waiting on a thread synchronization object such as ManualResetEvent.

Suspended	64	The thread has been suspended.

AbortRequested	128	The Abort(Object) method has been invoked on the thread, but the thread has not yet received the pending ThreadAbortException that will attempt to terminate it.

Aborted	256	The thread state includes AbortRequested and the thread is now dead, but its state has not yet changed to Stopped.

Remarks:
------------
The ThreadState enumeration defines a set of all possible execution states for threads. It's of interest only in a few debugging scenarios. Your code should never use the thread state to synchronize the activities of threads.

Once a thread is created, it's in at least one of the states until it terminates. Threads created within the common language runtime are initially in the Unstarted state, while external, or unmanaged, threads that come into the runtime are already in the Running state. A thread is transitioned from the Unstarted state into the Running state by calling Thread.Start. Once a thread leaves the Unstarted state as the result of a call to Start, it can never return to the Unstarted state.

A thread can be in more than one state at a given time. For example, if a thread is blocked on a call to Monitor.Wait, and another thread calls Thread.Abort on the blocked thread, the blocked thread will be in both the WaitSleepJoin and AbortRequested states at the same time. In this case, as soon as the thread returns from the call to Monitor.Wait or is interrupted, it will receive the ThreadAbortException to begin aborting. Not all combinations of ThreadState values are valid; for example, a thread cannot be in both the Aborted and Unstarted states.

A thread can never leave the Stopped state.

 Important

There are two thread state enumerations: System.Threading.ThreadState and System.Diagnostics.ThreadState.

The following table shows the actions that cause a change of state.

Action	ThreadState
A thread is created within the common language runtime.	Unstarted
Another thread calls the Thread.Start method on the new thread, and the call returns.

The Start method does not return until the new thread has started running. There is no way to know at what point the new thread will start running, during the call to Start.	Running
The thread calls Sleep	WaitSleepJoin
The thread calls Monitor.Wait on another object.	WaitSleepJoin
The thread calls Join on another thread.	WaitSleepJoin
Another thread calls Interrupt	Running
Another thread calls Suspend	SuspendRequested
The thread responds to a Suspend request.	Suspended
Another thread calls Resume	Running
Another thread calls Abort	AbortRequested
The thread responds to an Abort request.	Stopped
A thread is terminated.	Stopped
In addition to the states noted above, there is also the Background state, which indicates whether the thread is running in the background or foreground. For more information, see Foreground and Background Threads.

The Thread.ThreadState property of a thread provides the current state of a thread. Applications must use a bit mask to determine whether a thread is running. Since the value for Running is zero (0), test whether a thread is running by the following code:

(myThread.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted)) == 0
**/