/**
ConfigureAwaitOptions Enum
---------------------------
Options to control behavior when awaiting.

This enumeration supports a bitwise combination of its member values.

[System.Flags]
public enum ConfigureAwaitOptions

Fields
Name	Value	Description
None	0	No options specified.
ContinueOnCapturedContext	1	Attempts to marshal the continuation back to the original SynchronizationContext or TaskScheduler present on the originating thread at the time of the await.
SuppressThrowing	2	Avoids throwing an exception at the completion of awaiting a Task that ends in the Faulted or Canceled state.
ForceYielding	4	Forces an await on an already completed Task to behave as if the Task wasn't yet completed, such that the current asynchronous method will be forced to yield its execution.



**/