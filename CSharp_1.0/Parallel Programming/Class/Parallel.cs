/**
Parallel Class
----------------

Provides support for parallel loops and regions.

    public static class Parallel

Remarks:
--------
The Parallel class provides library-based data parallel replacements for common operations such as for loops, for each loops, and execution of a set of statements.

Methods:
---------
For(Int32, Int32, Action<Int32,ParallelLoopState>)	- Executes a for loop in which iterations may run in parallel and the state of the loop can be monitored and manipulated.
For(Int32, Int32, Action<Int32>)	- Executes a for loop in which iterations may run in parallel.
For(Int32, Int32, ParallelOptions, Action<Int32,ParallelLoopState>)	- Executes a for loop in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
For(Int32, Int32, ParallelOptions, Action<Int32>)	- Executes a for loop in which iterations may run in parallel and loop options can be configured.
For(Int64, Int64, Action<Int64,ParallelLoopState>)	- Executes a for loop with 64-bit indexes in which iterations may run in parallel and the state of the loop can be monitored and manipulated.
For(Int64, Int64, Action<Int64>)	- Executes a for loop with 64-bit indexes in which iterations may run in parallel.
For(Int64, Int64, ParallelOptions, Action<Int64,ParallelLoopState>)	- Executes a for loop with 64-bit indexes in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
For(Int64, Int64, ParallelOptions, Action<Int64>)	- Executes a for loop with 64-bit indexes in which iterations may run in parallel and loop options can be configured.
For<TLocal>(Int32, Int32, Func<TLocal>, Func<Int32,ParallelLoopState,TLocal,TLocal>, Action<TLocal>)	- Executes a for loop with thread-local data in which iterations may run in parallel, and the state of the loop can be monitored and manipulated.
For<TLocal>(Int32, Int32, ParallelOptions, Func<TLocal>, Func<Int32,ParallelLoopState,TLocal,TLocal>, Action<TLocal>)	-Executes a for loop with thread-local data in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
For<TLocal>(Int64, Int64, Func<TLocal>, Func<Int64,ParallelLoopState,TLocal,TLocal>, Action<TLocal>)	- Executes a for loop with 64-bit indexes and thread-local data in which iterations may run in parallel, and the state of the loop can be monitored and manipulated.
For<TLocal>(Int64, Int64, ParallelOptions, Func<TLocal>, Func<Int64,ParallelLoopState,TLocal,TLocal>, Action<TLocal>)	- Executes a for loop with 64-bit indexes and thread-local data in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
    public static System.Threading.Tasks.ParallelLoopResult For(long fromInclusive, long toExclusive, Action<long> body);
    public static System.Threading.Tasks.ParallelLoopResult For(long fromInclusive, long toExclusive, Action<long,System.Threading.Tasks.ParallelLoopState> body);
    public static System.Threading.Tasks.ParallelLoopResult For<TLocal>(int fromInclusive, int toExclusive, Func<TLocal> localInit, Func<int,System.Threading.Tasks.ParallelLoopState,TLocal,TLocal> body, Action<TLocal> localFinally);
    
ForAsync<T>(T, T, CancellationToken, Func<T,CancellationToken,ValueTask>)	- Executes a for loop in which iterations may run in parallel.
ForAsync<T>(T, T, Func<T,CancellationToken,ValueTask>)	- Executes a for loop in which iterations may run in parallel.
ForAsync<T>(T, T, ParallelOptions, Func<T,CancellationToken,ValueTask>)	- Executes a for loop in which iterations may run in parallel.
ForEach<TSource,TLocal>(IEnumerable<TSource>, Func<TLocal>, Func<TSource,ParallelLoopState,Int64,TLocal,TLocal>, Action<TLocal>)	- Executes a foreach (For Each in Visual Basic) operation with thread-local data on an IEnumerable in which iterations may run in parallel and the state of the loop can be monitored and manipulated.
ForEach<TSource,TLocal>(IEnumerable<TSource>, Func<TLocal>, Func<TSource,ParallelLoopState,TLocal,TLocal>, Action<TLocal>)	- Executes a foreach (For Each in Visual Basic) operation with thread-local data on an IEnumerable in which iterations may run in parallel, and the state of the loop can be monitored and manipulated.
ForEach<TSource,TLocal>(IEnumerable<TSource>, ParallelOptions, Func<TLocal>, Func<TSource,ParallelLoopState,Int64,TLocal,TLocal>, Action<TLocal>)	- Executes a foreach (For Each in Visual Basic) operation with thread-local data and 64-bit indexes on an IEnumerable in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
ForEach<TSource,TLocal>(IEnumerable<TSource>, ParallelOptions, Func<TLocal>, Func<TSource,ParallelLoopState,TLocal,TLocal>, Action<TLocal>)	- Executes a foreach (For Each in Visual Basic) operation with thread-local data on an IEnumerable in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
ForEach<TSource,TLocal>(OrderablePartitioner<TSource>, Func<TLocal>, Func<TSource,ParallelLoopState,Int64,TLocal,TLocal>, Action<TLocal>)	- Executes a foreach (For Each in Visual Basic) operation with thread-local data on a OrderablePartitioner<TSource> in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
ForEach<TSource,TLocal>(OrderablePartitioner<TSource>, ParallelOptions, Func<TLocal>, Func<TSource,ParallelLoopState,Int64,TLocal,TLocal>, Action<TLocal>)	- Executes a foreach (For Each in Visual Basic) operation with 64-bit indexes and with thread-local data on a OrderablePartitioner<TSource> in which iterations may run in parallel , loop options can be configured, and the state of the loop can be monitored and manipulated.
ForEach<TSource,TLocal>(Partitioner<TSource>, Func<TLocal>, Func<TSource,ParallelLoopState,TLocal,TLocal>, Action<TLocal>)	- Executes a foreach (For Each in Visual Basic) operation with thread-local data on a Partitioner in which iterations may run in parallel and the state of the loop can be monitored and manipulated.
ForEach<TSource,TLocal>(Partitioner<TSource>, ParallelOptions, Func<TLocal>, Func<TSource,ParallelLoopState,TLocal,TLocal>, Action<TLocal>)	- Executes a foreach (For Each in Visual Basic) operation with thread-local data on a Partitioner in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
ForEach<TSource>(IEnumerable<TSource>, Action<TSource,ParallelLoopState,Int64>)	- Executes a foreach (For Each in Visual Basic) operation with 64-bit indexes on an IEnumerable in which iterations may run in parallel, and the state of the loop can be monitored and manipulated.
ForEach<TSource>(IEnumerable<TSource>, Action<TSource,ParallelLoopState>)	- Executes a foreach (For Each in Visual Basic) operation on an IEnumerable in which iterations may run in parallel, and the state of the loop can be monitored and manipulated.
ForEach<TSource>(IEnumerable<TSource>, Action<TSource>)	- Executes a foreach (For Each in Visual Basic) operation on an IEnumerable in which iterations may run in parallel.
ForEach<TSource>(IEnumerable<TSource>, ParallelOptions, Action<TSource,ParallelLoopState,Int64>)	- Executes a foreach (For Each in Visual Basic) operation with 64-bit indexes on an IEnumerable in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
ForEach<TSource>(IEnumerable<TSource>, ParallelOptions, Action<TSource,ParallelLoopState>)	-Executes a foreach (For Each in Visual Basic) operation on an IEnumerable in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
ForEach<TSource>(IEnumerable<TSource>, ParallelOptions, Action<TSource>)	- Executes a foreach (For Each in Visual Basic) operation on an IEnumerable in which iterations may run in parallel and loop options can be configured.
ForEach<TSource>(OrderablePartitioner<TSource>, Action<TSource,ParallelLoopState,Int64>)	- Executes a foreach (For Each in Visual Basic) operation on a OrderablePartitioner<TSource> in which iterations may run in parallel and the state of the loop can be monitored and manipulated.
ForEach<TSource>(OrderablePartitioner<TSource>, ParallelOptions, Action<TSource,ParallelLoopState,Int64>)	- Executes a foreach (For Each in Visual Basic) operation on a OrderablePartitioner<TSource> in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
ForEach<TSource>(Partitioner<TSource>, Action<TSource,ParallelLoopState>)	- Executes a foreach (For Each in Visual Basic) operation on a Partitioner in which iterations may run in parallel, and the state of the loop can be monitored and manipulated.
ForEach<TSource>(Partitioner<TSource>, Action<TSource>)	- Executes a foreach (For Each in Visual Basic) operation on a Partitioner in which iterations may run in parallel.
ForEach<TSource>(Partitioner<TSource>, ParallelOptions, Action<TSource,ParallelLoopState>)	- Executes a foreach (For Each in Visual Basic) operation on a Partitioner in which iterations may run in parallel, loop options can be configured, and the state of the loop can be monitored and manipulated.
ForEach<TSource>(Partitioner<TSource>, ParallelOptions, Action<TSource>)	- Executes a foreach (For Each in Visual Basic) operation on a Partitioner in which iterations may run in parallel and loop options can be configured.
ForEachAsync<TSource>(IAsyncEnumerable<TSource>, CancellationToken, Func<TSource,CancellationToken,ValueTask>)	- Executes a for-each operation on an IEnumerable<T> in which iterations may run in parallel.
ForEachAsync<TSource>(IAsyncEnumerable<TSource>, Func<TSource,CancellationToken,ValueTask>)	- Executes a for-each operation on an IEnumerable<T> in which iterations may run in parallel.
ForEachAsync<TSource>(IAsyncEnumerable<TSource>, ParallelOptions, Func<TSource,CancellationToken,ValueTask>)	- Executes a for-each operation on an IEnumerable<T> in which iterations may run in parallel.
ForEachAsync<TSource>(IEnumerable<TSource>, CancellationToken, Func<TSource,CancellationToken,ValueTask>)	- Executes a for-each operation on an IEnumerable<T> in which iterations may run in parallel.
ForEachAsync<TSource>(IEnumerable<TSource>, Func<TSource,CancellationToken,ValueTask>)	- Executes a for-each operation on an IEnumerable<T> in which iterations may run in parallel.
ForEachAsync<TSource>(IEnumerable<TSource>, ParallelOptions, Func<TSource,CancellationToken,ValueTask>)	- Executes a for-each operation on an IEnumerable<T> in which iterations may run in parallel.
Invoke(Action[])	- Executes each of the provided actions, possibly in parallel.
Invoke(ParallelOptions, Action[])	- Executes each of the provided actions, possibly in parallel, unless the operation is cancelled by the user.

**/
using System;

namespace ParallelProgramming{
    class ParallelClass{
        public static void Main(){
            Console.WriteLine("Parallel Programming .");
        }
    }
}