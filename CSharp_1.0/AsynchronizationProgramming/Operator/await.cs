/**
The await keyword is a fundamental part of asynchronous programming in C#. It allows you to pause the execution of an asynchronous method until the awaited task completes, without blocking the thread.

The await operator suspends evaluation of the enclosing async method until the asynchronous operation represented by its operand completes. When the asynchronous operation completes, the await operator returns the result of the operation, if any. When the await operator is applied to the operand that represents an already completed operation, it returns the result of the operation immediately without suspension of the enclosing method. The await operator doesn't block the thread that evaluates the async method. When the await operator suspends the enclosing async method, the control returns to the caller of the method.

How await Works:
-----------------
1.Pausing Execution:
When you use await on a task, the method pauses at that point and returns control to the caller. This allows other code to run while waiting for the task to complete.
2.Resuming Execution:
Once the awaited task completes, the method resumes execution from the point where it was paused. The state machine created by the compiler ensures that the method continues correctly.


Compiler Stage:
----------------
1.Transformation:
    When the compiler encounters an await keyword in an async method, it transforms the method into a state machine. This transformation involves breaking the method into multiple states, each representing a point where the method can be paused and resumed.
2.State Machine Creation:
    The compiler generates a state machine class that manages the execution flow of the asynchronous method. This class includes fields to store the state, local variables, and the task being awaited.
3.Code Generation:
    The compiler generates code that handles the transitions between states. This includes pausing the method when an await is encountered and resuming it when the awaited task completes.

Runtime Stage (CLR):
--------------------
1.Execution:
    At runtime, when the await keyword is encountered, the CLR executes the generated state machine code. The method is paused, and control is returned to the caller.
2.Task Completion:
    The CLR monitors the awaited task. Once the task completes, the state machine resumes execution from the paused state. The CLR ensures that the method continues from the correct point, using the state machine to manage the flow.
3.Continuation:
    The state machine handles the continuation of the method, executing the remaining code after the await statement. This ensures that the method completes correctly once the awaited task is done.

State Machine Details:
-------------------------
State machines are a powerful concept used in various fields, including computer science, to manage the execution flow based on different states. In the context of asynchronous programming in C#, state machines play a crucial role in handling the execution of async methods. Let's dive into the details:

What is a State Machine?:
-------------------------
A state machine is a computational model that consists of:
    1. States: Distinct conditions or stages in the execution flow.
    2. Transitions: Rules that define how the system moves from one state to another.
    3. Events: Triggers that cause transitions between states.

State Machines in Asynchronous Programming:
--------------------------------------------
In asynchronous programming, the compiler transforms async methods into state machines to manage the complex flow of asynchronous operations. Here's how it works:

Components of a State Machine:
-----------------------------
1.States:
    Each await statement introduces a new state. The method can pause at these points and resume later.
2. Transitions:
    The state machine transitions between states based on the completion of asynchronous tasks. When an await statement is encountered, the method pauses and transitions to a waiting state.
3. Events:
    The completion of an awaited task acts as an event that triggers the transition from the waiting state to the next state.


Async Main Method:
-------------------
If and only if Main returns a Task or Task<int>, the declaration of Main may include the async modifier. This specifically excludes an async void Main method.


The operand of the await operator is usually of one of the following .NET types: 
Task, Task<TResult>, ValueTask, or ValueTask<TResult>. However, any awaitable expression can be the operand of the await operator.

The type of expression await t is TResult if the type of expression t is Task<TResult> or ValueTask<TResult>. If the type of t is Task or ValueTask, the type of await t is void. In both cases, if t throws an exception, await t rethrows the exception.

Asynchronous streams and disposables:
--------------------------------------
You use the await foreach statement to consume an asynchronous stream of data.
that is, the collection type that implements the IAsyncEnumerable<T> interface. Each iteration of the loop may be suspended while the next element is retrieved asynchronously. The following example shows how to use the await foreach statement:

await foreach (var item in GenerateSequenceAsync())
{
    Console.WriteLine(item);
}

You can also use the await foreach statement with an instance of any type that satisfies the following conditions:

A type has the public parameterless GetAsyncEnumerator method. That method can be a type's extension method.
The return type of the GetAsyncEnumerator method has the public Current property and the public parameterless MoveNextAsync method whose return type is Task<bool>, ValueTask<bool>, or any other awaitable type whose awaiter's GetResult method returns a bool value.
By default, stream elements are processed in the captured context. If you want to disable capturing of the context, use the TaskAsyncEnumerableExtensions.ConfigureAwait extension method.


await operator in the Main method:
-----------------------------------
Main() return values:
----------------------
static async Task<int> Main()	No use of args, uses await
static async Task<int> Main(string[] args)	Uses args and await
static async Task Main()	No use of args, uses await
static async Task Main(string[] args)	Uses args and await

**/

using System;
using System.Threading.Tasks;

namespace AsynchronousProgramming{
    class awaitKeywordClass{
        public async Task ProcessDataAsync()
        {
            int data1 = await FetchDataAsync();
            int data2 = await FetchOtherDataAsync();
            Console.WriteLine($"Data1: {data1}, Data2: {data2}");
        }

        public async Task<int> FetchOtherDataAsync()
        {
            await Task.Delay(500);
            return 24;
        }

        public async Task<int> FetchDataAsync()
        {
            await Task.Delay(1000); // State 1: Waiting for the task to complete
            return 42;              // State 2: Task completed, returning result
        }


        public static async Task Main(){
            Console.WriteLine("Await Keywork");
            awaitKeywordClass test = new awaitKeywordClass();
            await test.ProcessDataAsync();
        }
    }
}