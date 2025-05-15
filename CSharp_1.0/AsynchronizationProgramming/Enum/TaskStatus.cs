/**
Represents the current stage in the lifecycle of a Task.

public enum TaskStatus

Fields
Name	Value	Description
Created	0	The task has been initialized but has not yet been scheduled.
WaitingForActivation	1	The task is waiting to be activated and scheduled internally by the .NET infrastructure.
WaitingToRun	2	The task has been scheduled for execution but has not yet begun executing.
Running	3	The task is running but has not yet completed.
WaitingForChildrenToComplete	4	The task has finished executing and is implicitly waiting for attached child tasks to complete.
RanToCompletion	5	The task completed execution successfully.
Canceled	6	The task acknowledged cancellation by throwing an OperationCanceledException with its own CancellationToken while the token was in signaled state, or the task's CancellationToken was already signaled before the task started executing. For more information, see Task Cancellation.
Faulted	7	The task completed due to an unhandled exception.


**/