/**

The Task Parallel Library (TPL) is based on the concept of a task, which represents an asynchronous operation. In some ways, a task resembles a thread or ThreadPool work item but at a higher level of abstraction. The term task parallelism refers to one or more independent tasks running concurrently. Tasks provide two primary benefits:
    1.More efficient and more scalable use of system resources.
    Behind the scenes, tasks are queued to the ThreadPool, which has been enhanced with algorithms that determine and adjust to the number of threads. These algorithms provide load balancing to maximize throughput. This process makes tasks relatively lightweight, and you can create many of them to enable fine-grained parallelism.
    2.More programmatic control than is possible with a thread or work item.
    Tasks and the framework built around them provide a rich set of APIs that support waiting, cancellation, continuations, robust exception handling, detailed status, custom scheduling, and more.

For both reasons, TPL is the preferred API for writing multi-threaded, asynchronous, and parallel code in .NET.

Creating and running tasks implicitly:
--------------------------------------
The Parallel.Invoke method provides a convenient way to run any number of arbitrary statements concurrently. Just pass in an Action delegate for each item of work. The easiest way to create these delegates is to use lambda expressions. The lambda expression can either call a named method or provide the code inline. 

Parallel.Invoke(() => DoSomeWork(), () => DoSomeOtherWork());

For greater control over task execution or to return a value from the task, you must work with Task objects more explicitly.

Creating and running tasks explicitly:
--------------------------------------
A task that doesn't return a value is represented by the System.Threading.Tasks.Task class. A task that returns a value is represented by the System.Threading.Tasks.Task<TResult> class, which inherits from Task. The task object handles the infrastructure details and provides methods and properties that are accessible from the calling thread throughout the lifetime of the task. For example, you can access the Status property of a task at any time to determine whether it has started running, ran to completion, was canceled, or has thrown an exception. The status is represented by a TaskStatus enumeration.

When you create a task, you give it a user delegate that encapsulates the code that the task will execute. The delegate can be expressed as a named delegate, an anonymous method, or a lambda expression. Lambda expressions can contain a call to a named method, as shown in the following example. The example includes a call to the Task.Wait method to ensure that the task completes execution before the console mode application ends.

You can also use the Task.Run methods to create and start a task in one operation. To manage the task, the Run methods use the default task scheduler, regardless of which task scheduler is associated with the current thread. The Run methods are the preferred way to create and start tasks when more control over the creation and scheduling of the task isn't needed.

You can also use the TaskFactory.StartNew method to create and start a task in one operation. As shown in the following example, you can use this method when:
    1.Creation and scheduling don't have to be separated and you require additional task creation options or the use of a specific scheduler.
    2.You need to pass additional state into the task that you can retrieve through its Task.AsyncState property.

they each have a public Task<TResult>.Result property that contains the result of the computation. The tasks run asynchronously and might complete in any order. If the Result property is accessed before the computation finishes, the property blocks the calling thread until the value is available.

when you use a lambda expression to create a delegate, you have access to all the variables that are visible at that point in your source code. However, in some cases, most notably within loops, a lambda doesn't capture the variable as expected. It only captures the reference of the variable, not the value, as it mutates after each iteration. 

Task ID:
---------
Every task receives an integer ID that uniquely identifies it in an application domain and can be accessed by using the Task.Id property. The ID is useful for viewing task information in the Visual Studio debugger Parallel Stacks and Tasks windows. The ID is created lazily, which means it isn't created until it's requested. Therefore, a task might have a different ID every time the program is run. 

Task creation options:
----------------------
Most APIs that create tasks provide overloads that accept a TaskCreationOptions parameter. By specifying one or more of these options, you tell the task scheduler how to schedule the task on the thread pool. Options might be combined by using a bitwise OR operation.

The following example shows a task that has the LongRunning and PreferFairness options:
var task3 = new Task(() => MyLongRunningMethod(),
                    TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
task3.Start();

Tasks, threads, and culture:
----------------------------
Each thread has an associated culture and UI culture, which are defined by the Thread.CurrentCulture and Thread.CurrentUICulture properties, respectively. A thread's culture is used in operations such as formatting, parsing, sorting, and string comparison operations. A thread's UI culture is used in resource lookup.

The system culture defines the default culture and UI culture of a thread. However, you can specify a default culture for all the threads in an application domain by using the CultureInfo.DefaultThreadCurrentCulture and CultureInfo.DefaultThreadCurrentUICulture properties. If you explicitly set a thread's culture and launch a new thread, the new thread doesn't inherit the culture of the calling thread; instead, its culture is the default system culture. However, in task-based programming, tasks use the calling thread's culture, even if the task runs asynchronously on a different thread.

Creating task continuations:
---------------------------
The Task.ContinueWith and Task<TResult>.ContinueWith methods let you specify a task to start when the antecedent task finishes. The delegate of the continuation task is passed a reference to the antecedent task so that it can examine the antecedent task's status. And by retrieving the value of the Task<TResult>.Result property, you can use the output of the antecedent as input for the continuation.

Creating child tasks:
----------------------
When user code that's running in a task creates a task with the AttachedToParent option, the new task is known as an attached child task of the parent task. You can use the AttachedToParent option to express structured task parallelism because the parent task implicitly waits for all attached child tasks to finish. The following example shows a parent task that creates 10 attached child tasks. 
A parent task can use the TaskCreationOptions.DenyChildAttach option to prevent other tasks from attaching to the parent task. For more information, see Attached and Detached Child Tasks.

Attached and Detached Child Tasks:
-------------------------------------
A child task (or nested task) is a System.Threading.Tasks.Task instance that is created in the user delegate of another task, which is known as the parent task. A child task can be either detached or attached. A detached child task is a task that executes independently of its parent. An attached child task is a nested task that is created with the TaskCreationOptions.AttachedToParent option whose parent does not explicitly or by default prohibit it from being attached. A task may create any number of attached and detached child tasks, limited only by system resources.

Category	Detached child tasks	Attached child tasks
Parent waits for child tasks to complete.	No	Yes
Parent propagates exceptions thrown by child tasks.	No	Yes
Status of parent depends on status of child.	No	Yes
In most scenarios, we recommend that you use detached child tasks, because their relationships with other tasks are less complex. That is why tasks created inside parent tasks are detached by default, and you must explicitly specify the TaskCreationOptions.AttachedToParent option to create an attached child task.

Waiting for tasks to finish:
----------------------------
The System.Threading.Tasks.Task and System.Threading.Tasks.Task<TResult> types provide several overloads of the Task.Wait methods that enable you to wait for a task to finish. In addition, overloads of the static Task.WaitAll and Task.WaitAny methods let you wait for any or all of an array of tasks to finish.

Typically, you would wait for a task for one of these reasons:
    1.The main thread depends on the final result computed by a task.
    2.You have to handle exceptions that might be thrown from the task.
    3.The application might terminate before all tasks have completed execution. For example, console applications will terminate after all synchronous code in Main (the application entry point) has executed.

Some overloads let you specify a time-out, and others take an additional CancellationToken as an input parameter so that the wait itself can be canceled either programmatically or in response to user input.

When you wait for a task, you implicitly wait for all children of that task that were created by using the TaskCreationOptions.AttachedToParent option. Task.Wait returns immediately if the task has already completed. A Task.Wait method will throw any exceptions raised by a task, even if the Task.Wait method was called after the task completed.

Composing tasks:
-----------------
The Task and Task<TResult> classes provide several methods to help you compose multiple tasks. These methods implement common patterns and make better use of the asynchronous language features that are provided by C#, Visual Basic, and F#. This section describes the WhenAll, WhenAny, Delay, and FromResult methods.

Task.WhenAll:
-------------
The Task.WhenAll method asynchronously waits for multiple Task or Task<TResult> objects to finish. It provides overloaded versions that enable you to wait for non-uniform sets of tasks. For example, you can wait for multiple Task and Task<TResult> objects to complete from one method call.

Task.WhenAny:
-------------
The Task.WhenAny method asynchronously waits for one of multiple Task or Task<TResult> objects to finish. As in the Task.WhenAll method, this method provides overloaded versions that enable you to wait for non-uniform sets of tasks. The WhenAny method is especially useful in the following scenarios:
    Redundant operations: Consider an algorithm or operation that can be performed in many ways. You can use the WhenAny method to select the operation that finishes first and then cancel the remaining operations.
    Interleaved operations: You can start multiple operations that must finish and use the WhenAny method to process results as each operation finishes. After one operation finishes, you can start one or more tasks.
    Throttled operations: You can use the WhenAny method to extend the previous scenario by limiting the number of concurrent operations.
    Expired operations: You can use the WhenAny method to select between one or more tasks and a task that finishes after a specific time, such as a task that's returned by the Delay method. The Delay method is described in the following section.

Task.Delay:
----------------
The Task.Delay method produces a Task object that finishes after the specified time. You can use this method to build loops that poll for data, to specify time-outs, to delay the handling of user input, and so on.

Task(T).FromResult:
------------------
By using the Task.FromResult method, you can create a Task<TResult> object that holds a pre-computed result. This method is useful when you perform an asynchronous operation that returns a Task<TResult> object, and the result of that Task<TResult> object is already computed. For an example that uses FromResult to retrieve the results of asynchronous download operations that are held in a cache, see How to: Create Pre-Computed Tasks.

Handling exceptions in tasks:
-----------------------------
When a task throws one or more exceptions, the exceptions are wrapped in an AggregateException exception. That exception is propagated back to the thread that joins with the task. Typically, it's the thread waiting for the task to finish or the thread accessing the Result property. This behavior enforces the .NET Framework policy that all unhandled exceptions by default should terminate the process. The calling code can handle the exceptions by using any of the following in a try/catch block:

        The Wait method

        The WaitAll method

        The WaitAny method

        The Result property

The joining thread can also handle exceptions by accessing the Exception property before the task is garbage-collected. By accessing this property, you prevent the unhandled exception from triggering the exception propagation behavior that terminates the process when the object is finalized.


Canceling tasks:
-----------------
The Task class supports cooperative cancellation and is fully integrated with the System.Threading.CancellationTokenSource and System.Threading.CancellationToken classes, which were introduced in the .NET Framework 4. Many of the constructors in the System.Threading.Tasks.Task class take a CancellationToken object as an input parameter. Many of the StartNew and Run overloads also include a CancellationToken parameter.

You can create the token and issue the cancellation request at some later time, by using the CancellationTokenSource class. Pass the token to the Task as an argument, and also reference the same token in your user delegate, which does the work of responding to a cancellation request.


The TaskFactory class:
------------------------
The TaskFactory class provides static methods that encapsulate common patterns for creating and starting tasks and continuation tasks.

The most common pattern is StartNew, which creates and starts a task in one statement.

When you create continuation tasks from multiple antecedents, use the ContinueWhenAll method or ContinueWhenAny method or their equivalents in the Task<TResult> class. For more information, see Chaining Tasks by Using Continuation Tasks.

To encapsulate Asynchronous Programming Model BeginX and EndX methods in a Task or Task<TResult> instance, use the FromAsync methods. For more information, see TPL and Traditional .NET Framework Asynchronous Programming.

The default TaskFactory can be accessed as a static property on the Task class or Task<TResult> class. You can also instantiate a TaskFactory directly and specify various options that include a CancellationToken, a TaskCreationOptions option, a TaskContinuationOptions option, or a TaskScheduler. Whatever options are specified when you create the task factory will be applied to all tasks that it creates unless the Task is created by using the TaskCreationOptions enumeration, in which case the task's options override those of the task factory.

Tasks without delegates:
------------------------
In some cases, you might want to use a Task to encapsulate some asynchronous operation that's performed by an external component instead of your user delegate. If the operation is based on the Asynchronous Programming Model Begin/End pattern, you can use the FromAsync methods. If that's not the case, you can use the TaskCompletionSource<TResult> object to wrap the operation in a task and thereby gain some of the benefits of Task programmability. For example, support for exception propagation and continuations. For more information, see TaskCompletionSource<TResult>.

Custom schedulers:
-------------------
Most application or library developers don't care which processor the task runs on, how it synchronizes its work with other tasks, or how it's scheduled on the System.Threading.ThreadPool. They only require that it execute as efficiently as possible on the host computer. If you require more fine-grained control over the scheduling details, the TPL lets you configure some settings on the default task scheduler, and even lets you supply a custom scheduler. For more information, see TaskScheduler.

Related data structures:
-----------------------
The TPL has several new public types that are useful in parallel and sequential scenarios. These include several thread-safe, fast, and scalable collection classes in the System.Collections.Concurrent namespace and several new synchronization types. For example, System.Threading.Semaphore and System.Threading.ManualResetEventSlim, which are more efficient than their predecessors for specific kinds of workloads. Other new types in the .NET Framework 4, for example, System.Threading.Barrier and System.Threading.SpinLock, provide functionality that wasn't available in earlier releases. For more information, see Data Structures for Parallel Programming.

Custom task types:
-------------------
We recommend that you don't inherit from System.Threading.Tasks.Task or System.Threading.Tasks.Task<TResult>. Instead, we recommend that you use the AsyncState property to associate additional data or state with a Task or Task<TResult> object. You can also use extension methods to extend the functionality of the Task and Task<TResult> classes. For more information about extension methods, see Extension Methods and Extension Methods.

If you must inherit from Task or Task<TResult>, you can't use Run or the System.Threading.Tasks.TaskFactory, System.Threading.Tasks.TaskFactory<TResult>, or System.Threading.Tasks.TaskCompletionSource<TResult> classes to create instances of your custom task type. You can't use them because these classes create only Task and Task<TResult> objects. In addition, you can't use the task continuation mechanisms that are provided by Task, Task<TResult>, TaskFactory, and TaskFactory<TResult> to create instances of your custom task type. You can't use them because these classes also create only Task and Task<TResult> objects.



**/
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming{
    class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }

    class TaskBasedAsynchronizationProgramming{
        public static void Main(){
            Console.WriteLine("Task Based Asynchonization Programming.");

            Thread.CurrentThread.Name = "Main";
            // Create a task and supply a user delegate by using a lambda expression.
            Task taskA = new Task( () => Console.WriteLine("Hello from taskA."));
            // Start the task.
            taskA.Start();

            // Output a message from the calling thread.
            Console.WriteLine($"Hello from thread '{Thread.CurrentThread.Name}'.");
            taskA.Wait();

            // Define and run the task.
            Thread.CurrentThread.Name = "Main B";
            Task taskB = Task.Run( () => Console.WriteLine("Hello from taskB."));

            // Output a message from the calling thread.
            Console.WriteLine($"Hello from thread '{Thread.CurrentThread.Name}'.");
            taskB.Wait();

            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) =>
                {
                    CustomData data = obj as CustomData;
                    //var data = new CustomData() {Name = i, CreationTime = DateTime.Now.Ticks};
                    if (data == null) return;

                    data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                    Console.WriteLine($"Task #{data.Name} created at {data.CreationTime} on thread #{data.ThreadNum}.");
                },
                new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }
            Task.WaitAll(taskArray);
            foreach (var task in taskArray)
            {
                var data = task.AsyncState as CustomData;
                if (data != null)
                    Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.",
                                    data.Name, data.CreationTime, data.ThreadNum);
            }

            var getData = Task.Factory.StartNew(() => {
                                             Random rnd = new Random();
                                             int[] values = new int[100];
                                             for (int ctr = 0; ctr <= values.GetUpperBound(0); ctr++)
                                                values[ctr] = rnd.Next();

                                             return values;
                                          } );
            var processData = getData.ContinueWith((x) => {
                                                        int n = x.Result.Length;
                                                        long sum = 0;
                                                        double mean;

                                                        for (int ctr = 0; ctr <= x.Result.GetUpperBound(0); ctr++)
                                                        sum += x.Result[ctr];

                                                        mean = sum / (double) n;
                                                        return Tuple.Create(n, sum, mean);
                                                    } );
            var displayData = processData.ContinueWith((x) => {
                                                            return String.Format("N={0:N0}, Total = {1:N0}, Mean = {2:N2}",
                                                                                x.Result.Item1, x.Result.Item2,
                                                                                x.Result.Item3);
                                                        } );
            Console.WriteLine(displayData.Result);

            var parent = Task.Factory.StartNew(() => {
                      Console.WriteLine("Parent task beginning.");
                      for (int ctr = 0; ctr < 10; ctr++) {
                         int taskNo = ctr;
                         Task.Factory.StartNew((x) => {
                                                  Thread.SpinWait(5000000);
                                                  Console.WriteLine($"Attached child #{x} completed.");
                                               },
                                               taskNo, TaskCreationOptions.AttachedToParent);
                      }
                   });

            parent.Wait();
            Console.WriteLine("Parent task completed.");
            // The example displays output like the following:
            //       Parent task beginning.
            //       Attached child #9 completed.
            //       Attached child #0 completed.
            //       Attached child #8 completed.
            //       Attached child #1 completed.
            //       Attached child #7 completed.
            //       Attached child #2 completed.
            //       Attached child #6 completed.
            //       Attached child #3 completed.
            //       Attached child #5 completed.
            //       Attached child #4 completed.
            //       Parent task completed.

            // Task[] tasks = new Task[3]
            // {
            //     Task.Factory.StartNew(() => MethodA()),
            //     Task.Factory.StartNew(() => MethodB()),
            //     Task.Factory.StartNew(() => MethodC())
            // };

            // //Block until all tasks complete.
            // Task.WaitAll(tasks);

            

        }

        
    }
}