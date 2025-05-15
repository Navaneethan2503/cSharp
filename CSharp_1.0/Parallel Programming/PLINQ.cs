/**
Parallel LINQ (PLINQ) is a powerful extension of LINQ that enables parallel execution of queries, leveraging multiple processors to improve performance.
PLINQ is part of the System.Linq namespace and provides parallel implementations of LINQ standard query operators. It combines the simplicity and readability of LINQ syntax with the power of parallel programming.

Features:
-----------
Parallel Execution: PLINQ partitions the data source into segments and executes the query on each segment in parallel, utilizing multiple processors 1.
Deferred Execution: Like LINQ, PLINQ queries have deferred execution, meaning they do not begin executing until the query is enumerated

Basic Usage:
-----------
To use PLINQ, you simply add the AsParallel method to your LINQ queries.

var parallelQuery = dataCollection.AsParallel().Where(item => item.IsValid);

ParallelEnumerable Class:
--------------------------
The ParallelEnumerable class in the System.Linq namespace exposes most of PLINQ's functionality. It includes implementations of standard query operators and additional methods for parallel operations 1.

Controlling Parallelism:
------------------------
PLINQ allows you to control the degree of parallelism using the WithDegreeOfParallelism method.
    var parallelQuery = dataCollection.AsParallel().WithDegreeOfParallelism(4).Where(item => item.IsValid);

This specifies the maximum number of concurrent tasks.
by default, PLINQ uses all of the processors on the host computer. You can instruct PLINQ to use no more than a specified number of processors by using the WithDegreeOfParallelism method. This is useful when you want to make sure that other processes running on the computer receive a certain amount of CPU time.


Handling Ordering:
-------------------
PLINQ can preserve the order of elements using the AsOrdered method.

However, preserving order can impact performance, so it's important to use it only when necessary 

Exception Handling:
-------------------
PLINQ aggregates exceptions that occur during parallel execution. You can handle these exceptions using the AggregateException class.

Cancellation:
---------------
PLINQ supports cancellation of queries using a CancellationToken.

Performance Considerations:
---------------------------
While PLINQ can significantly improve performance for many queries, not all queries benefit from parallel execution. It's important to understand the nature of your query and test performance to determine if PLINQ is beneficial.

What is a Parallel query?:
---------------------------
A PLINQ query in many ways resembles a non-parallel LINQ to Objects query. PLINQ queries, just like sequential LINQ queries, operate on any in-memory IEnumerable or IEnumerable<T> data source, and have deferred execution, which means they do not begin executing until the query is enumerated. The primary difference is that PLINQ attempts to make full use of all the processors on the system. It does this by partitioning the data source into segments, and then executing the query on each segment on separate worker threads in parallel on multiple processors. In many cases, parallel execution means that the query runs significantly faster.

Through parallel execution, PLINQ can achieve significant performance improvements over legacy code for certain kinds of queries, often just by adding the AsParallel query operation to the data source. However, parallelism can introduce its own complexities, and not all query operations run faster in PLINQ. In fact, parallelization actually slows down certain queries. Therefore, you should understand how issues such as ordering affect parallel queries.

Execution Modes:
----------------
By default, PLINQ is conservative. At run time, the PLINQ infrastructure analyzes the overall structure of the query. If the query is likely to yield speedups by parallelization, PLINQ partitions the source sequence into tasks that can be run concurrently. If it is not safe to parallelize a query, PLINQ just runs the query sequentially. If PLINQ has a choice between a potentially expensive parallel algorithm or an inexpensive sequential algorithm, it chooses the sequential algorithm by default. You can use the WithExecutionMode method and the System.Linq.ParallelExecutionMode enumeration to instruct PLINQ to select the parallel algorithm. This is useful when you know by testing and measurement that a particular query executes faster in parallel. 

Parallel vs. Sequential Queries:
--------------------------------
Some operations require that the source data be delivered in a sequential manner. The ParallelEnumerable query operators revert to sequential mode automatically when it is required. For user-defined query operators and user delegates that require sequential execution, PLINQ provides the AsSequential method. When you use AsSequential, all subsequent operators in the query are executed sequentially until AsParallel is called again.

Options for Merging Query Results:
----------------------------------
When a PLINQ query executes in parallel, its results from each worker thread must be merged back onto the main thread for consumption by a foreach loop (For Each in Visual Basic), or insertion into a list or array. In some cases, it might be beneficial to specify a particular kind of merge operation, for example, to begin producing results more quickly. For this purpose, PLINQ supports the WithMergeOptions method, and the ParallelMergeOptions enumeration.

The ForAll Operator:
--------------------
In sequential LINQ queries, execution is deferred until the query is enumerated either in a foreach (For Each in Visual Basic) loop or by invoking a method such as ToList , ToArray , or ToDictionary. In PLINQ, you can also use foreach to execute the query and iterate through the results. However, foreach itself does not run in parallel, and therefore, it requires that the output from all parallel tasks be merged back into the thread on which the loop is running. In PLINQ, you can use foreach when you must preserve the final ordering of the query results, and also whenever you are processing the results in a serial manner, for example when you are calling Console.WriteLine for each element. For faster query execution when order preservation is not required and when the processing of the results can itself be parallelized, use the ForAll method to execute a PLINQ query. ForAll does not perform this final merge step.

Cancellation:
---------------
PLINQ is integrated with the cancellation types in .NET. (For more information, see Cancellation in Managed Threads.) Therefore, unlike sequential LINQ to Objects queries, PLINQ queries can be canceled. To create a cancelable PLINQ query, use the WithCancellation operator on the query and provide a CancellationToken instance as the argument. When the IsCancellationRequested property on the token is set to true, PLINQ will notice it, stop processing on all threads, and throw an OperationCanceledException.

It is possible that a PLINQ query might continue to process some elements after the cancellation token is set.

For greater responsiveness, you can also respond to cancellation requests in long-running user delegates

Exceptions:
------------
When a PLINQ query executes, multiple exceptions might be thrown from different threads simultaneously. Also, the code to handle the exception might be on a different thread than the code that threw the exception. PLINQ uses the AggregateException type to encapsulate all the exceptions that were thrown by a query, and marshal those exceptions back to the calling thread. On the calling thread, only one try-catch block is required. However, you can iterate through all of the exceptions that are encapsulated in the AggregateException and catch any that you can safely recover from. In rare cases, some exceptions may be thrown that are not wrapped in an AggregateException, and ThreadAbortExceptions are also not wrapped.

When exceptions are allowed to bubble up back to the joining thread, then it is possible that a query may continue to process some items after the exception is raised.

Custom Partitioners:
--------------------
In some cases, you can improve query performance by writing a custom partitioner that takes advantage of some characteristic of the source data. In the query, the custom partitioner itself is the enumerable object that is queried.
    int[] arr = new int[9999];
    Partitioner<int> partitioner = new MyArrayPartitioner<int>(arr);
    var query = partitioner.AsParallel().Select(SomeFunction);

PLINQ supports a fixed number of partitions (although data may be dynamically reassigned to those partitions during run time for load balancing.). For and ForEach support only dynamic partitioning, which means that the number of partitions changes at run time. For more information,

Measuring PLINQ Performance:
-----------------------------
In many cases, a query can be parallelized, but the overhead of setting up the parallel query outweighs the performance benefit gained. If a query does not perform much computation or if the data source is small, a PLINQ query may be slower than a sequential LINQ to Objects query. You can use the Parallel Performance Analyzer in Visual Studio Team Server to compare the performance of various queries, to locate processing bottlenecks, and to determine whether your query is running in parallel or sequentially.

The primary purpose of PLINQ is to speed up the execution of LINQ to Objects queries by executing the query delegates in parallel on multi-core computers. PLINQ performs best when the processing of each element in a source collection is independent, with no shared state involved among the individual delegates. Such operations are common in LINQ to Objects and PLINQ, and are often called "delightfully parallel" because they lend themselves easily to scheduling on multiple threads. 
However, not all queries consist entirely of delightfully parallel operations. In most cases, a query involves some operators that either cannot be parallelized, or that slow down parallel execution. And even with queries that are entirely delightfully parallel, PLINQ must still partition the data source and schedule the work on the threads, and usually merge the results when the query completes. All these operations add to the computational cost of parallelization; these costs of adding parallelization are called overhead. To achieve optimum performance in a PLINQ query, the goal is to maximize the parts that are delightfully parallel and minimize the parts that require overhead.

Factors that Impact PLINQ Query Performance:
--------------------------------------------
1. Computational cost of the overall work.
2. The number of logical cores on the system (degree of parallelism).
3. The number and kind of operations.
4. The form of query execution.
5. The type of merge options.
6. The kind of partitioning.

Merge Options:
---------------
When a query is executing as parallel, PLINQ partitions the source sequence so that multiple threads can work on different parts concurrently, typically on separate threads. If the results are to be consumed on one thread, for example, in a foreach (For Each in Visual Basic) loop, then the results from every thread must be merged back into one sequence.
    var scanLines = from n in nums.AsParallel()
                    .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                where n % 2 == 0
                select ExpensiveFunc(n);



**/
using System;
using System.Linq;
using System.Diagnostics;

namespace ParallelProgramming{
    class PLINQ{
        public static void Main(){
            Console.WriteLine("PLinq");
            var source = Enumerable.Range(1, 10000);

            // Opt in to PLINQ with AsParallel.
            var evenNums = from num in source.AsParallel()
                        where num % 2 == 0
                        select num;
            Console.WriteLine($"{evenNums.Count()} even numbers out of {source.Count()} total");
            // The example displays the following output:
            //       5000 even numbers out of 10000 total


            var query = from item in source.AsParallel().WithDegreeOfParallelism(2)
                        where Compute(item) > 42
                        select item;

            // Result sequence might be out of order.
            var parallelQuery =
                from num in source.AsParallel()
                where num % 10 == 0
                select num;

            // Process result sequence in parallel
            parallelQuery.ForAll((e) => DoSomething(e));

            // Or use foreach to merge results first.
            foreach (var n in parallelQuery)
            {
                Console.Write(n+",");
            }

            // You can also use ToArray, ToList, etc as with LINQ to Objects.
            var parallelQuery2 =
                (from num in source.AsParallel()
                where num % 10 == 0
                select num).ToArray();

            // Method syntax is also supported
            var parallelQuery3 =
                source.AsParallel()
                    .Where(n => n % 10 == 0)
                    .Select(n => n);

            Enumerable.Range(0, 3000000);

            var queryToMeasure =
                from num in source.AsParallel()
                where num % 3 == 0
                select Math.Sqrt(num);

            Console.WriteLine("Measuring...");

            // The query does not run until it is enumerated.
            // Therefore, start the timer here.
            var sw = Stopwatch.StartNew();

            // For pure query cost, enumerate and do nothing else.
            foreach (var n in queryToMeasure) { }

            sw.Stop();
            long elapsed = sw.ElapsedMilliseconds; // or sw.ElapsedTicks
            Console.WriteLine($"Total query time: {elapsed} ms");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


        }

        static void DoSomething(int _) { }

        static int Compute(int s){ return s*s;}
    }
}