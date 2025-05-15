/**
Asynchronous programming in C# allows you to perform tasks without blocking the main thread, making your applications more responsive and efficient. Here are some key details:

Key Concepts:
-------------
Async and Await Keywords:
-------------------------
async: Used to define a method as asynchronous.
await: Used to pause the execution of an async method until the awaited task completes.

Task-Based Asynchronous Pattern (TAP):
--------------------------------------
Utilizes the Task and Task<T> types to represent asynchronous operations.
Methods return Task or Task<T> to indicate they are asynchronous.

Benefits:
--------
Improved Responsiveness: Keeps the UI thread free for user interactions.
Better Resource Utilization: Efficiently uses system resources by not blocking threads.
Scalability: Handles more concurrent operations without increasing the number of threads.

Common Use Cases:
----------------
I/O-bound operations: Such as reading from files, network calls, or database queries.
CPU-bound operations: When you need to perform intensive computations without blocking the main thread.

Best Practices:
---------------
Avoid Blocking Calls: Do not use .Result or .Wait() on tasks in asynchronous methods.
Use ConfigureAwait: Use ConfigureAwait(false) to avoid capturing the context when it's not needed.
Exception Handling: Use try-catch blocks to handle exceptions in asynchronous methods.

This is a broader concept that includes various techniques to perform operations without blocking the main thread. 
It encompasses different models like 
    1.Task asynchronous programming (TAP), 
    2.event-based asynchronous pattern (EAP), and 
    3.asynchronous programming model (APM).

Event-based Asynchronous Pattern (EAP):
---------------------------------------
Concept:
    EAP uses events to signal the completion of asynchronous operations. It relies on event handlers to manage asynchronous tasks.

Asynchronous Programming Model (APM):
-------------------------------------
Concept:
    APM uses Begin and End methods to handle asynchronous operations. It is based on the IAsyncResult interface.

Task Asynchronous Programming (TAP):
------------------------------------
Concept:
    TAP uses tasks (Task and Task<T>) and the async and await keywords to simplify asynchronous programming.
Task Asynchronous Programming (TAP) model in C# is designed to make asynchronous code easier to write and understand.
both the Event-based Asynchronous Pattern (EAP) and the Asynchronous Programming Model (APM) are older models compared to the Task Asynchronous Programming (TAP) model.

The Task asynchronous programming (TAP) model provides a layer of abstraction over typical asynchronous coding. In this model, you write code as a sequence of statements, the same as usual. The difference is you can read your task-based code as the compiler processes each statement and before it starts processing the next statement. To accomplish this model, the compiler performs many transformations to complete each task. Some statements can initiate work and return a Task object that represents the ongoing work and the compiler must resolve these transformations. The goal of task asynchronous programming is to enable code that reads like a sequence of statements, but executes in a more complicated order. Execution is based on external resource allocation and when tasks complete.

Key Concepts of TAP:
----------------------
1.Sequential Code Appearance:
TAP allows you to write asynchronous code that looks like regular synchronous code. This makes it easier to read and maintain.
2.Task Object:
When you perform an asynchronous operation, it returns a Task or Task<T> object Immediately. This object represents the ongoing work and can be awaited.
3.Compiler Transformations:
The compiler transforms your asynchronous code into a state machine. This state machine handles the execution flow, ensuring that each part of the code runs at the right time.

How TAP Works:
----------------
1.Initiating Work:
When you call an asynchronous method, it starts the work and returns a Task object immediately. This task represents the ongoing operation.
2.Awaiting Tasks:
The await keyword is used to pause the execution of the method until the awaited task completes. This doesn't block the thread but allows other work to continue.
3.Resuming Execution:
Once the awaited task completes, the method resumes execution from the point where it was paused. The state machine created by the compiler ensures that the method continues correctly.

A state machine is a computational model used to manage the execution flow of a program based on its current state. In the context of asynchronous programming in C#, the compiler transforms your async methods into state machines to handle the complex flow of asynchronous operations. Here's how it works:

State Machine in Asynchronous Programming:
------------------------------------------
1.States:
The state machine consists of various states that represent different stages of the asynchronous method's execution. Each await statement introduces a new state.
2.Transitions:
The state machine transitions between states based on the completion of asynchronous tasks. When an await statement is encountered, the method pauses and transitions to a waiting state.
3.Resumption:
Once the awaited task completes, the state machine resumes execution from the paused state, continuing with the next statement.

--------------------------------------------------------------------------------

Explore the asynchronous programming model:
-------------------------------------------
The Task and Task<T> objects represent the core of asynchronous programming. These objects are used to model asynchronous operations by supporting the async and await keywords. In most cases, the model is fairly simple for both I/O-bound and CPU-bound scenarios. Inside an async method:
    1.I/O-bound code starts an operation represented by a Task or Task<T> object within the async method.
    2.CPU-bound code starts an operation on a background thread with the Task.Run method.
In both cases, an active Task represents an asynchronous operation that might not be complete.

The await keyword is where the magic happens. It yields control to the caller of the method that contains the await expression, and ultimately allows the UI to be responsive or a service to be elastic. While there are ways to approach asynchronous code other than by using the async and await expressions, this article focuses on the language-level constructs.

When you implement asynchronous programming in your C# code, the compiler transforms your program into a state machine. This construct tracks various operations and state in your code, such as yielding execution when the code reaches an await expression, and resuming execution when a background job completes.

In the asynchronous programming model, there are several key concepts to understand:
    1.You can use asynchronous code for both I/O-bound and CPU-bound code, but the implementation is different.
    2.Asynchronous code uses Task<T> and Task objects as constructs to model work running in the background.
    3.The async keyword declares a method as an asynchronous method, which allows you to use the await keyword in the method body.
    4.When you apply the await keyword, the code suspends the calling method and yields control back to its caller until the task completes.
    5.You can only use the await expression in an asynchronous method.

Recognize CPU-bound and I/O-bound scenarios:
---------------------------------------------
Should the code wait for a result or action, such as data from a database?	I/O-bound	Use the async modifier and await expression without the Task.Run method.
                                                                                        Avoid using the Task Parallel Library.
Should the code run an expensive computation?	CPU-bound	Use the async modifier and await expression, but spawn off the work on another thread with the Task.Run method. This approach addresses concerns with CPU responsiveness.
                                                            If the work is appropriate for concurrency and parallelism, also consider using the Task Parallel Library.

Wait for multiple tasks to complete:
-------------------------------------
In some scenarios, the code needs to retrieve multiple pieces of data concurrently. The Task APIs provide methods that enable you to write asynchronous code that performs a nonblocking wait on multiple background jobs:
    Task.WhenAll method
    Task.WhenAny method

Review considerations for asynchronous programming:
----------------------------------------------------
1. Use await inside async() method body
    When you use the async modifier, you should include one or more await expressions in the method body. If the compiler doesn't encounter an await expression, the method fails to yield. Although the compiler generates a warning, the code still compiles and the compiler runs the method. The state machine generated by the C# compiler for the asynchronous method doesn't accomplish anything, so the entire process is highly inefficient.
2. Add "Async" suffix to asynchronous method names
    The .NET style convention is to add the "Async" suffix to all asynchronous method names. This approach helps to more easily differentiate between synchronous and asynchronous methods. Certain methods that aren't explicitly called by your code (such as event handlers or web controller methods) don't necessarily apply in this scenario. Because these items aren't explicitly called by your code, using explicit naming isn't as important.
3. Return 'async void' only from event handlers
    Event handlers must declare void return types and can't use or return Task and Task<T> objects as other methods do. When you write asynchronous event handlers, you need to use the async modifier on a void returning method for the handlers. Other implementations of async void returning methods don't follow the TAP model and can present challenges:
        Exceptions thrown in an async void method can't be caught outside of that method
        async void methods are difficult to test
        async void methods can cause negative side effects if the caller isn't expecting them to be asynchronous

Use caution with asynchronous lambdas in LINQ:
------------------------------------------------
It's important to use caution when you implement asynchronous lambdas in LINQ expressions. Lambda expressions in LINQ use deferred execution, which means the code can execute at an unexpected time. The introduction of blocking tasks into this scenario can easily result in a deadlock, if the code isn't written correctly. Moreover, the nesting of asynchronous code can also make it difficult to reason about the execution of the code. Async and LINQ are powerful, but these techniques should be used together as carefully and clearly as possible.

Yield for tasks in a nonblocking manner:
-----------------------------------------
If your program needs the result of a task, write code that implements the await expression in a nonblocking manner. Blocking the current thread as a means to wait synchronously for a Task item to complete can result in deadlocks and blocked context threads. This programming approach can require more complex error-handling

Task scenario	Current code	Replace with 'await'
Retrieve the result of a background task	Task.Wait or Task.Result	await
Continue when any task completes	Task.WaitAny	await Task.WhenAny
Continue when all tasks complete	Task.WaitAll	await Task.WhenAll
Continue after some amount of time	Thread.Sleep	await Task.Delay

Consider using ValueTask type:
-------------------------------
When an asynchronous method returns a Task object, performance bottlenecks might be introduced in certain paths. Because Task is a reference type, a Task object is allocated from the heap. If a method declared with the async modifier returns a cached result or completes synchronously, the extra allocations can accrue significant time costs in performance critical sections of code. 

Understand when to set ConfigureAwait(false):
---------------------------------------------
Developers often inquire about when to use the Task.ConfigureAwait(Boolean) boolean. This API allows for a Task instance to configure the context for the state machine that implements any await expression.

Write less-stateful code
Avoid writing code that depends on the state of global objects or the execution of certain methods. Instead, depend only on the return values of methods. There are many benefits to writing code that is less-stateful:
    Easier to reason about code
    Easier to test code
    More simple to mix asynchronous and synchronous code
    Able to avoid race conditions in code
    Simple to coordinate asynchronous code that depends on return values
    (Bonus) Works well with dependency injection in code

Threads:
--------
Async methods are intended to be non-blocking operations. An await expression in an async method doesn't block the current thread while the awaited task is running. Instead, the expression signs up the rest of the method as a continuation and returns control to the caller of the async method.
The async and await keywords don't cause additional threads to be created. Async methods don't require multithreading because an async method doesn't run on its own thread. The method runs on the current synchronization context and uses time on the thread only when the method is active. You can use Task.Run to move CPU-bound work to a background thread, but a background thread doesn't help with a process that's just waiting for results to become available.
The async-based approach to asynchronous programming is preferable to existing approaches in almost every case. In particular, this approach is better than the BackgroundWorker class for I/O-bound operations because the code is simpler and you don't have to guard against race conditions. In combination with the Task.Run method, async programming is better than BackgroundWorker for CPU-bound operations because async programming separates the coordination details of running your code from the work that Task.Run transfers to the thread pool.

Naming convention:
-----------------
By convention, methods that return commonly awaitable types (for example, Task, Task<T>, ValueTask, ValueTask<T>) should have names that end with "Async". Methods that start an asynchronous operation but do not return an awaitable type should not have names that end with "Async", but may start with "Begin", "Start", or some other verb to suggest this method does not return or throw the result of the operation.

Task return type:
--------------------
Async methods that don't contain a return statement or that contain a return statement that doesn't return an operand usually have a return type of Task. Such methods return void if they run synchronously. If you use a Task return type for an async method, a calling method can use an await operator to suspend the caller's completion until the called async method finishes.

Task<TResult> return type:
--------------------------
The Task<TResult> return type is used for an async method that contains a return statement in which the operand is TResult.

The Result property is a blocking property. If you try to access it before its task is finished, the thread that's currently active is blocked until the task completes and the value is available. In most cases, you should access the value by using await instead of accessing the property directly.

Void return type:
-----------------
You use the void return type in asynchronous event handlers, which require a void return type. For methods other than event handlers that don't return a value, you should return a Task instead, because an async method that returns void can't be awaited. Any caller of such a method must continue to completion without waiting for the called async method to finish. The caller must be independent of any values or exceptions that the async method generates.

The caller of a void-returning async method can't catch exceptions thrown from the method. Such unhandled exceptions are likely to cause your application to fail. If a method that returns a Task or Task<TResult> throws an exception, the exception is stored in the returned task. The exception is rethrown when the task is awaited. Make sure that any async method that can produce an exception has a return type of Task or Task<TResult> and that calls to the method are awaited.

Asynchronous file access:
-------------------------
You might consider the following reasons for adding asynchrony to file access calls:

    Asynchrony makes UI applications more responsive because the UI thread that launches the operation can perform other work. If the UI thread must execute code that takes a long time (for example, more than 50 milliseconds), the UI may freeze until the I/O is complete and the UI thread can again process keyboard and mouse input and other events.
    Asynchrony improves the scalability of ASP.NET and other server-based applications by reducing the need for threads. If the application uses a dedicated thread per response and a thousand requests are being handled simultaneously, a thousand threads are needed. Asynchronous operations often don't need to use a thread during the wait. They use the existing I/O completion thread briefly at the end.
    The latency of a file access operation might be very low under current conditions, but the latency may greatly increase in the future. For example, a file may be moved to a server that's across the world.
    The added overhead of using the Async feature is small.
    Asynchronous tasks can easily be run in parallel.

Use appropriate classes:
--------------------------
The simple examples in this topic demonstrate File.WriteAllTextAsync and File.ReadAllTextAsync. For fine control over the file I/O operations, use the FileStream class, which has an option that causes asynchronous I/O to occur at the operating system level. By using this option, you can avoid blocking a thread pool thread in many cases. To enable this option, you specify the useAsync=true or options=FileOptions.Asynchronous argument in the constructor call.

You can't use this option with StreamReader and StreamWriter if you open them directly by specifying a file path. However, you can use this option if you provide them a Stream that the FileStream class opened. Asynchronous calls are faster in UI apps even if a thread pool thread is blocked, because the UI thread isn't blocked during the wait.

Write text:
----------
The following examples write text to a file. At each await statement, the method immediately exits. When the file I/O is complete, the method resumes at the statement that follows the await statement. The async modifier is in the definition of methods that use the await statement.


Cancel a list of tasks:
-----------------------



**/

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Net.Http;

namespace AsynchronousProgramming{
    class User
    {
        public bool isEnabled
        {
            get;
            set;
        }

        public int id
        {
            get;
            set;
        }
    }

    public class NaiveButton
    {
        public event EventHandler? Clicked;

        public void Click()
        {
            Console.WriteLine("Somebody has clicked a button. Let's raise the event...");
            Clicked?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("All listeners are notified.");
        }
    }

    public class AsyncVoidExample
    {
        static readonly TaskCompletionSource<bool> s_tcs = new TaskCompletionSource<bool>();

        public static async Task MultipleEventHandlersAsync()
        {
            Task<bool> secondHandlerFinished = s_tcs.Task;

            var button = new NaiveButton();

            button.Clicked += OnButtonClicked1;
            button.Clicked += OnButtonClicked2Async;
            button.Clicked += OnButtonClicked3;

            Console.WriteLine("Before button.Click() is called...");
            button.Click();
            Console.WriteLine("After button.Click() is called...");

            await secondHandlerFinished;
        }

        private static void OnButtonClicked1(object? sender, EventArgs e)
        {
            Console.WriteLine("   Handler 1 is starting...");
            Task.Delay(100).Wait();
            Console.WriteLine("   Handler 1 is done.");
        }

        private static async void OnButtonClicked2Async(object? sender, EventArgs e)
        {
            Console.WriteLine("   Handler 2 is starting...");
            Task.Delay(100).Wait();
            Console.WriteLine("   Handler 2 is about to go async...");
            await Task.Delay(500);
            Console.WriteLine("   Handler 2 is done.");
            s_tcs.SetResult(true);
        }

        private static void OnButtonClicked3(object? sender, EventArgs e)
        {
            Console.WriteLine("   Handler 3 is starting...");
            Task.Delay(100).Wait();
            Console.WriteLine("   Handler 3 is done.");
        }
    }
    // Example output:
    //
    // Before button.Click() is called...
    // Somebody has clicked a button. Let's raise the event...
    //    Handler 1 is starting...
    //    Handler 1 is done.
    //    Handler 2 is starting...
    //    Handler 2 is about to go async...
    //    Handler 3 is starting...
    //    Handler 3 is done.
    // All listeners are notified.
    // After button.Click() is called...
    //    Handler 2 is done.

    

    class Program
    {
        static readonly CancellationTokenSource s_cts = new CancellationTokenSource();

        static readonly HttpClient s_client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };

        static readonly IEnumerable<string> s_urlList = new string[]
        {
                "https://learn.microsoft.com",
                "https://learn.microsoft.com/aspnet/core",
                "https://learn.microsoft.com/azure",
                "https://learn.microsoft.com/azure/devops",
                "https://learn.microsoft.com/dotnet",
                "https://learn.microsoft.com/dynamics365",
                "https://learn.microsoft.com/education",
                "https://learn.microsoft.com/enterprise-mobility-security",
                "https://learn.microsoft.com/gaming",
                "https://learn.microsoft.com/graph",
                "https://learn.microsoft.com/microsoft-365",
                "https://learn.microsoft.com/office",
                "https://learn.microsoft.com/powershell",
                "https://learn.microsoft.com/sql",
                "https://learn.microsoft.com/surface",
                "https://learn.microsoft.com/system-center",
                "https://learn.microsoft.com/visualstudio",
                "https://learn.microsoft.com/windows",
                "https://learn.microsoft.com/maui"
        };

        public static async Task Main1()
        {
            Console.WriteLine("Application started.");

            try
            {
                s_cts.CancelAfter(3500);

                await SumPageSizesAsync();
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nTasks cancelled: timed out.\n");
            }
            finally
            {
                s_cts.Dispose();
            }

            Console.WriteLine("Application ending.");
        }

        static async Task SumPageSizesAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            int total = 0;
            foreach (string url in s_urlList)
            {
                int contentLength = await ProcessUrlAsync(url, s_client, s_cts.Token);
                total += contentLength;
            }

            stopwatch.Stop();

            Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
            Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
        }

        static async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken token)
        {
            HttpResponseMessage response = await client.GetAsync(url, token);
            byte[] content = await response.Content.ReadAsByteArrayAsync(token);
            Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

            return content.Length;
        }
    }

    class AsynchronousProgrammingClass{
        private static async Task<User> GetUserAsync(int userId)
        {
            // Code omitted:
            //
            // Given a user Id {userId}, retrieves a User object corresponding
            // to the entry in the database with {userId} as its Id.

            return await Task.FromResult(new User() { id = userId });
        }

        private static async Task<IEnumerable<User>> GetUsersAsync(IEnumerable<int> userIds)
        {
            var getUserTasks = new List<Task<User>>();
            foreach (int userId in userIds)
            {
                getUserTasks.Add(GetUserAsync(userId));
            }

            return await Task.WhenAll(getUserTasks);
        }

        public async Task<int> DoWork(int id){
            Console.WriteLine("DoWord Started :"+ id);
            await Task.Delay(2000);
            Console.WriteLine("DoWord Completed. :"+ id);
            return id;
        }

        public async Task<int> DoWork2(int id){
            Console.WriteLine("DoWord2 Started :"+ id);
            await Task.Delay(500);
            Console.WriteLine("DoWord2 Completed. :"+ id);
            return id;
        }

        public void Example(){
            Console.WriteLine("Moved to example.");
        }

        public static async Task DisplayCurrentInfoAsync()
        {
            await WaitAndApologizeAsync();

            Console.WriteLine($"Today is {DateTime.Now:D}");
            Console.WriteLine($"The current time is {DateTime.Now.TimeOfDay:t}");
            Console.WriteLine("The current temperature is 76 degrees.");
        }

        static async Task WaitAndApologizeAsync()
        {
            await Task.Delay(2000);

            Console.WriteLine("Sorry for the delay...\n");
        }
        // Example output:
        //    Sorry for the delay...
        //
        // Today is Monday, August 17, 2020
        // The current time is 12:59:24.2183304
        // The current temperature is 76 degrees.

        public static async Task ShowTodaysInfoAsync()
        {
            string message =
                $"Today is {DateTime.Today:D}\n" +
                "Today's hours of leisure: " +
                $"{await GetLeisureHoursAsync()}";

            Console.WriteLine(message);
        }

        static async Task<int> GetLeisureHoursAsync()
        {
            DayOfWeek today = await Task.FromResult(DateTime.Now.DayOfWeek);

            int leisureHours =
                today is DayOfWeek.Saturday || today is DayOfWeek.Sunday
                ? 16 : 5;

            return leisureHours;
        }
        // Example output:
        //    Today is Wednesday, May 24, 2017
        //    Today's hours of leisure: 5
        


        public static async Task Main(){
            Console.WriteLine("Understand Async Programming.");
            int i = 0;

            AsynchronousProgrammingClass asyncTest = new AsynchronousProgrammingClass();
            Console.WriteLine("Work Start for Id : "+ ++i);
            var rest = asyncTest.DoWork(i);
            //var rest2 = await asyncTest.DoWork2(i);
            asyncTest.Example();
            await rest;
            Console.WriteLine("DoWark Move next from : "+ rest.Result);
            
            var rest2 = asyncTest.DoWork(++i);
            //var rest2 = await asyncTest.DoWork2(i);
            asyncTest.Example();
            await rest2;
            Console.WriteLine("DoWark Move next from : "+ rest2.Result);

            /**
            Work Start for Id : 1
            DoWord Started :1
            Moved to example.
            DoWord Completed. :1
            DoWark Move next from : 1
            DoWord Started :2
            Moved to example.
            DoWord Completed. :2
            DoWark Move next from : 2
            **/

            async Task<int> GetTaskOfTResultAsync()
            {
                int hours = 0;
                await Task.Delay(0);

                return hours;
            }


            Task<int> returnedTaskTResult = GetTaskOfTResultAsync();
            int intResult = await returnedTaskTResult;
            // Single line
            // int intResult = await GetTaskOfTResultAsync();

            async Task GetTaskAsync()
            {
                Console.WriteLine("GetTaskAsync Method started.");
                await Task.Delay(100);
                // No return statement needed
                Console.WriteLine("GetTaskAsync Method Completed.");
            }

            Task returnedTask = GetTaskAsync();
            await returnedTask;
            // Single line
            Console.WriteLine("Main Methods GetTaskAsync");
            await GetTaskAsync();
            Console.WriteLine("GetTaskAsync Two Completed.");

            /**
            GetTaskAsync Method started.
            GetTaskAsync Method Completed.
            Main Methods GetTaskAsync
            GetTaskAsync Method started.
            GetTaskAsync Method Completed.
            GetTaskAsync Two Completed.
            **/


            Task waitAndApologizeTask = WaitAndApologizeAsync();

            string output =
                $"Today is {DateTime.Now:D}\n" +
                $"The current time is {DateTime.Now.TimeOfDay:t}\n" +
                "The current temperature is 76 degrees.\n";

            await waitAndApologizeTask;
            Console.WriteLine(output);

            //Program p = new Program();
            Program.Main1();



        }
    }
}