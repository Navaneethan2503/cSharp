/**

Specifies flags that control optional behavior for the creation and execution of tasks.

This enumeration supports a bitwise combination of its member values.

[System.Flags]
public enum TaskCreationOptions

Fields
Name	Value	Description
None	0	Specifies that the default behavior should be used.
PreferFairness	1	A hint to a TaskScheduler to schedule a task in as fair a manner as possible, meaning that tasks scheduled sooner will be more likely to be run sooner, and tasks scheduled later will be more likely to be run later.
LongRunning	2	Specifies that a task will be a long-running, coarse-grained operation involving fewer, larger components than fine-grained systems. It provides a hint to the TaskScheduler that oversubscription may be warranted. Oversubscription lets you create more threads than the available number of hardware threads. It also provides a hint to the task scheduler that an additional thread might be required for the task so that it does not block the forward progress of other threads or work items on the local thread-pool queue.
AttachedToParent	4	Specifies that a task is attached to a parent in the task hierarchy. By default, a child task (that is, an inner task created by an outer task) executes independently of its parent. You can use the AttachedToParent option so that the parent and child tasks are synchronized.
Note that if a parent task is configured with the DenyChildAttach option, the AttachedToParent option in the child task has no effect, and the child task will execute as a detached child task.

DenyChildAttach	8	Specifies that any child task that attempts to execute as an attached child task (that is, it is created with the AttachedToParent option) will not be able to attach to the parent task and will execute instead as a detached child task. For more information, see Attached and Detached Child Tasks.
HideScheduler	16	Prevents the ambient scheduler from being seen as the current scheduler in the created task. This means that operations like StartNew or ContinueWith that are performed in the created task will see Default as the current scheduler.
RunContinuationsAsynchronously	64	Forces continuations added to the current task to be executed asynchronously.
Note that the RunContinuationsAsynchronously member is available in the TaskCreationOptions enumeration starting with the .NET Framework 4.6.

Remarks:
-------
The TaskCreationOptions enumeration is used with the following methods:

The TaskFactory and TaskFactory<TResult> constructors with a creationOptions parameter, to specify the default options for tasks created by the task factory.

The Task and Task<TResult> constructors with a creationOptions parameter, to specify the options used to customize the task's behavior.

The StartNew and StartNew methods with a creationOptions parameter, to specify the options used to customize the task's behavior.

The FromAsync and FromAsync methods with a creationOptions parameter, to specify the options used to customize the behavior of the task that executes an end method when a specified IAsyncResult completes.

The TaskCompletionSource<TResult> constructors with a creationOptions parameter, to specify the options used to customize the behavior of the underlying task.

**/