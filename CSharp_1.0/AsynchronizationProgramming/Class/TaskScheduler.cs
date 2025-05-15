using System;
/**
TaskScheduler Class
---------------------
Represents an object that handles the low-level work of queuing tasks onto threads.
    public abstract class TaskScheduler

Constructors:
-------------
TaskScheduler()	- Initializes the TaskScheduler.

Properties:
----------
Current	- Gets the TaskScheduler associated with the currently executing task.
Default	- Gets the default TaskScheduler instance that is provided by .NET.
Id	- Gets the unique ID for this TaskScheduler.
MaximumConcurrencyLevel	- Indicates the maximum concurrency level this TaskScheduler is able to support.

Methods:
----------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
FromCurrentSynchronizationContext()	- Creates a TaskScheduler associated with the current SynchronizationContext.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetScheduledTasks()	- For debugger support only, generates an enumerable of Task instances currently queued to the scheduler waiting to be executed.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
QueueTask(Task)	- Queues a Task to the scheduler.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryDequeue(Task)	- Attempts to dequeue a Task that was previously queued to this scheduler.
TryExecuteTask(Task)	- Attempts to execute the provided Task on this scheduler.
TryExecuteTaskInline(Task, Boolean)	- Determines whether the provided Task can be executed synchronously in this call, and if it can, executes it.

Events:
-------
UnobservedTaskException	- Occurs when a faulted task's unobserved exception is about to trigger exception escalation policy, which, by default, would terminate the process.


**/

namespace AsynchronousProgramming{
    class TaskSchedulerClass{
        public static void Main(){
            Console.WriteLine("Task Scheduler class.");
        }
    }
}