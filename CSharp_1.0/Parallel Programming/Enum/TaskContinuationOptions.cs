/**
TaskContinuationOptions Enum
-----------------------------
Specifies the behavior for a task that is created by using the ContinueWith(Action<Task>, CancellationToken, TaskContinuationOptions, TaskScheduler) or ContinueWith(Action<Task<TResult>>, TaskContinuationOptions) method.

This enumeration supports a bitwise combination of its member values.

Fields
Name	Value	Description
None	0	When no continuation options are specified, specifies that default behavior should be used when executing a continuation. The continuation runs asynchronously when the antecedent task completes, regardless of the antecedent's final Status property value. If the continuation is a child task, it is created as a detached nested task.
PreferFairness	1	A hint to a TaskScheduler to schedule task in the order in which they were scheduled, so that tasks scheduled sooner are more likely to run sooner, and tasks scheduled later are more likely to run later.
LongRunning	2	Specifies that a continuation will be a long-running, course-grained operation. It provides a hint to the TaskScheduler that oversubscription may be warranted.
AttachedToParent	4	Specifies that the continuation, if it is a child task, is attached to a parent in the task hierarchy. The continuation can be a child task only if its antecedent is also a child task. By default, a child task (that is, an inner task created by an outer task) executes independently of its parent. You can use the AttachedToParent option so that the parent and child tasks are synchronized.
Note that if a parent task is configured with the DenyChildAttach option, the AttachedToParent option in the child task has no effect, and the child task will execute as a detached child task.

DenyChildAttach	8	Specifies that any child task (that is, any nested inner task created by this continuation) that is created with the AttachedToParent option and attempts to execute as an attached child task will not be able to attach to the parent task and will execute instead as a detached child task. For more information, see Attached and Detached Child Tasks.
HideScheduler	16	Specifies that tasks created by the continuation by calling methods such as Run(Action) or ContinueWith(Action<Task>) see the default scheduler (Default) rather than the scheduler on which this continuation is running as the current scheduler.
LazyCancellation	32	In the case of continuation cancellation, prevents completion of the continuation until the antecedent has completed.
RunContinuationsAsynchronously	64	Specifies that the continuation task should be run asynchronously. This option has precedence over ExecuteSynchronously.
NotOnRanToCompletion	65536	Specifies that the continuation task should not be scheduled if its antecedent ran to completion. An antecedent runs to completion if its Status property upon completion is RanToCompletion. This option is not valid for multi-task continuations.
NotOnFaulted	131072	Specifies that the continuation task should not be scheduled if its antecedent threw an unhandled exception. An antecedent throws an unhandled exception if its Status property upon completion is Faulted. This option is not valid for multi-task continuations.
OnlyOnCanceled	196608	Specifies that the continuation should be scheduled only if its antecedent was canceled. An antecedent is canceled if its Status property upon completion is Canceled. This option is not valid for multi-task continuations.
NotOnCanceled	262144	Specifies that the continuation task should not be scheduled if its antecedent was canceled. An antecedent is canceled if its Status property upon completion is Canceled. This option is not valid for multi-task continuations.
OnlyOnFaulted	327680	Specifies that the continuation task should be scheduled only if its antecedent threw an unhandled exception. An antecedent throws an unhandled exception if its Status property upon completion is Faulted.
The OnlyOnFaulted option guarantees that the Exception property in the antecedent is not null. You can use that property to catch the exception and see which exception caused the task to fault. If you do not access the Exception property, the exception is unhandled. Also, if you attempt to access the Result property of a task that has been canceled or has faulted, a new exception is thrown.

This option is not valid for multi-task continuations.

OnlyOnRanToCompletion	393216	Specifies that the continuation should be scheduled only if its antecedent ran to completion. An antecedent runs to completion if its Status property upon completion is RanToCompletion. This option is not valid for multi-task continuations.
ExecuteSynchronously	524288	Specifies that the continuation task should be executed synchronously. With this option specified, the continuation runs on the same thread that causes the antecedent task to transition into its final state. If the antecedent is already complete when the continuation is created, the continuation will run on the thread that creates the continuation. If the antecedent's CancellationTokenSource is disposed in a finally block (Finally in Visual Basic), a continuation with this option will run in that finally block. Only very short-running continuations should be executed synchronously.
Because the task executes synchronously, there is no need to call a method such as Wait() to ensure that the calling thread waits for the task to complete.

**/