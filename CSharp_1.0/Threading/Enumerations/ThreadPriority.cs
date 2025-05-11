/**
Specifies the scheduling priority of a Thread.
    public enum ThreadPriority

Fields:
----------
Name	Value	Description
Lowest	0	The Thread can be scheduled after threads with any other priority.
BelowNormal	1	The Thread can be scheduled after threads with Normal priority and before those with Lowest priority.
Normal	2	The Thread can be scheduled after threads with AboveNormal priority and before those with BelowNormal priority. Threads have Normal priority by default.
AboveNormal	3	The Thread can be scheduled after threads with Highest priority and before those with Normal priority.
Highest	4	The Thread can be scheduled before threads with any other priority.

Remarks:
-----------
ThreadPriority defines the set of all possible values for a thread priority. Thread priorities specify the relative priority of one thread versus another.

Every thread has an assigned priority. Threads created within the runtime are initially assigned the Normal priority, while threads created outside the runtime retain their previous priority when they enter the runtime. You can get and set the priority of a thread by accessing its Priority property.

Threads are scheduled for execution based on their priority. The scheduling algorithm used to determine the order of thread execution varies with each operating system. The operating system can also adjust the thread priority dynamically as the user interface's focus is moved between the foreground and the background.

The priority of a thread does not affect the thread's state; the state of the thread must be Running before the operating system can schedule it.


**/