/**
EventResetMode Enum:
--------------------

Indicates whether an EventWaitHandle is reset automatically or manually after receiving a signal.

public enum EventResetMode

Fields
Name	Value	Description
AutoReset	0	
When signaled, the EventWaitHandle resets automatically after releasing a single thread. If no threads are waiting, the EventWaitHandle remains signaled until a thread blocks, and resets after releasing the thread.

ManualReset	1	
When signaled, the EventWaitHandle releases all waiting threads and remains signaled until it is manually reset.

**/