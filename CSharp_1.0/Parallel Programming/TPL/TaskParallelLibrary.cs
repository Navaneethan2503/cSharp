/**

The Task Parallel Library (TPL) is a set of public types and APIs in the System.Threading and System.Threading.Tasks namespaces. 
The purpose of the TPL is to make developers more productive by simplifying the process of adding parallelism and concurrency to applications. 
The TPL dynamically scales the degree of concurrency to use all the available processors most efficiently. In addition, the TPL handles the partitioning of the work, the scheduling of threads on the ThreadPool, cancellation support, state management, and other low-level details. By using TPL, you can maximize the performance of your code while focusing on the work that your program is designed to accomplish.

In .NET Framework 4, the TPL is the preferred way to write multithreaded and parallel code. However, not all code is suitable for parallelization. For example, if a loop performs only a small amount of work on each iteration, or it doesn't run for many iterations, then the overhead of parallelization can cause the code to run more slowly. Furthermore, parallelization, like any multithreaded code, adds complexity to your program execution. Although the TPL simplifies multithreaded scenarios, we recommend that you have a basic understanding of threading concepts, for example, locks, deadlocks, and race conditions, so that you can use the TPL effectively.

1. Overview:
-------------
The TPL is part of the System.Threading.Tasks namespace and provides a set of APIs to help developers write parallel and asynchronous code more easily. It dynamically scales the degree of concurrency to use all available processors efficiently 1.

2. Core Components:
-------------------
Task Class: Represents an asynchronous operation. Tasks can be created and started using the Task class, which provides methods for managing and controlling tasks.
Parallel Class: Provides methods like Parallel.For, Parallel.ForEach, and Parallel.Invoke to execute loops and invoke actions in parallel.
3. Task Creation and Execution
Tasks can be created and executed in several ways:
    Implicitly using Parallel.Invoke for parallel execution of a set of actions.
    Explicitly using the Task class to create and start tasks manually.

4. Task-based Asynchronous Programming
The TPL supports task-based asynchronous programming, which allows you to write asynchronous code that is easier to read and maintain. This is achieved using the async and await keywords in C# 2.

5. Data Parallelism
Data parallelism involves performing the same operation on elements in a collection concurrently. The Parallel.For and Parallel.ForEach methods are used to achieve data parallelism 1.

6. Exception Handling
The TPL provides robust mechanisms for handling exceptions in parallel and asynchronous code. Exceptions thrown by tasks are captured and can be observed using the Task.Exception property.

7. Cancellation and Continuations
Cancellation: The TPL supports cancellation of tasks using CancellationToken and CancellationTokenSource.
Continuations: Tasks can be chained together using continuation tasks, which are tasks that start after another task completes.

8. Synchronization and Coordination
The TPL includes synchronization primitives like SemaphoreSlim, Mutex, and Monitor to coordinate access to shared resources.

9. Performance and Scalability
The TPL is designed to maximize performance by efficiently utilizing system resources. It handles the partitioning of work, scheduling of threads, and other low-level details, allowing developers to focus on the logic of their applications 1.

===================================================================================================
Data Paralellism:
-----------------
Data parallelism refers to scenarios in which the same operation is performed concurrently (that is, in parallel) on elements in a source collection or array. In data parallel operations, the source collection is partitioned so that multiple threads can operate on different segments concurrently.
The Task Parallel Library (TPL) supports data parallelism through the System.Threading.Tasks.Parallel class. This class provides method-based parallel implementations of for and foreach loops (For and For Each in Visual Basic). You write the loop logic for a Parallel.For or Parallel.ForEach loop much as you would write a sequential loop. You do not have to create threads or queue work items. In basic loops, you do not have to take locks. The TPL handles all the low-level work for you. For in-depth information about the use of Parallel.For and Parallel.ForEach.

When a parallel loop runs, the TPL partitions the data source so that the loop can operate on multiple parts concurrently. Behind the scenes, the Task Scheduler partitions the task based on system resources and workload. When possible, the scheduler redistributes work among multiple threads and processors if the workload becomes unbalanced.
Both the Parallel.For and Parallel.ForEach methods have several overloads that let you stop or break loop execution, monitor the state of the loop on other threads, maintain thread-local state, finalize thread-local objects, control the degree of concurrency, and so on. The helper types that enable this functionality include ParallelLoopState, ParallelOptions, ParallelLoopResult, CancellationToken, and CancellationTokenSource.

The Delegate
The third parameter of this overload of For is a delegate of type Action<int> in C# or Action(Of Integer) in Visual Basic. An Action delegate, whether it has zero, one or sixteen type parameters, always returns void. In Visual Basic, the behavior of an Action is defined with a Sub.

The Iteration Value
The delegate takes a single input parameter whose value is the current iteration. This iteration value is supplied by the runtime and its starting value is the index of the first element on the segment (partition) of the source that is being processed on the current thread.

Return Value and Exception Handling
For returns use a System.Threading.Tasks.ParallelLoopResult object when all threads have completed. This return value is useful when you are stopping or breaking loop iteration manually, because the ParallelLoopResult stores information such as the last iteration that ran to completion. If one or more exceptions occur on one of the threads, a System.AggregateException will be thrown.

Analysis and Performance
You can use the Performance Wizard to view CPU usage on your computer. As an experiment, increase the number of columns and rows in the matrices. The larger the matrices, the greater the performance difference between the parallel and sequential versions of the computation. When the matrix is small, the sequential version will run faster because of the overhead in setting up the parallel loop.

Synchronous calls to shared resources, like the Console or the File System, will significantly degrade the performance of a parallel loop. When measuring performance, try to avoid calls such as Console.WriteLine within the loop.

The loop partitions the source collection and schedules the work on multiple threads based on the system environment. The more processors on the system, the faster the parallel method runs. For some source collections, a sequential loop might be faster, depending on the size of the source and the kind of work the loop performs.

The Parallel.For and Parallel.ForEach methods support cancellation through the use of cancellation tokens
When you add your own exception-handling logic to parallel loops, handle the case in which similar exceptions might be thrown on multiple threads concurrently, and the case in which an exception thrown on one thread causes another exception to be thrown on another thread. You can handle both cases by wrapping all exceptions from the loop in a System.AggregateException. 

When a Parallel.For loop has a small body, it might perform more slowly than the equivalent sequential loop, such as the for loop in C# and the For loop in Visual Basic. Slower performance is caused by the overhead involved in partitioning the data and the cost of invoking a delegate on each loop iteration. To address such scenarios, the Partitioner class provides the Partitioner.Create method, which enables you to provide a sequential loop for the delegate body, so that the delegate is invoked only once per partition, instead of once per iteration.

**/
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading;

namespace ParallelProgramming{
    class TPLClass{
        public static void Process(int ele){
            Console.Write(ele+",");
        }
        public static void ExceptionTwo()
        {
            // Create some random data to process in parallel.
            // There is a good probability this data will cause some exceptions to be thrown.
            byte[] data = new byte[5_000];
            Random r = Random.Shared;
            r.NextBytes(data);

            try
            {
                ProcessDataInParallel(data);
            }
            catch (AggregateException ae)
            {
                var ignoredExceptions = new List<Exception>();
                // This is where you can choose which exceptions to handle.
                foreach (var ex in ae.Flatten().InnerExceptions)
                {
                    if (ex is ArgumentException) Console.WriteLine(ex.Message);
                    else ignoredExceptions.Add(ex);
                }
                if (ignoredExceptions.Count > 0)
                {
                    throw new AggregateException(ignoredExceptions);
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void ProcessDataInParallel(byte[] data)
        {
            // Use ConcurrentQueue to enable safe enqueueing from multiple threads.
            var exceptions = new ConcurrentQueue<Exception>();

            // Execute the complete loop and capture all exceptions.
            Parallel.ForEach(data, d =>
            {
                try
                {
                    // Cause a few exceptions, but not too many.
                    if (d < 3) throw new ArgumentException($"Value is {d}. Value must be greater than or equal to 3.");
                    else Console.Write(d + " ");
                }
                // Store the exception and continue with the loop.
                catch (Exception e)
                {
                    exceptions.Enqueue(e);
                }
            });
            Console.WriteLine();

            // Throw the exceptions here after the loop completes.
            if (!exceptions.IsEmpty)
            {
                throw new AggregateException(exceptions);
            }
        }

        #region Sequential_Loop
        static void MultiplyMatricesSequential(double[,] matA, double[,] matB,
                                                double[,] result)
        {
            int matACols = matA.GetLength(1);
            int matBCols = matB.GetLength(1);
            int matARows = matA.GetLength(0);

            for (int i = 0; i < matARows; i++)
            {
                for (int j = 0; j < matBCols; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }
                    result[i, j] += temp;
                }
            }
        }
        #endregion

        #region Parallel_Loop
        static void MultiplyMatricesParallel(double[,] matA, double[,] matB, double[,] result)
        {
            int matACols = matA.GetLength(1);
            int matBCols = matB.GetLength(1);
            int matARows = matA.GetLength(0);

            // A basic matrix multiplication.
            // Parallelize the outer loop to partition the source array by rows.
            Parallel.For(0, matARows, i =>
            {
                for (int j = 0; j < matBCols; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }
                    result[i, j] = temp;
                }
            }); // Parallel.For
        }
        #endregion

        private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();


        private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
        {
            var primeNumbers = new ConcurrentBag<int>();

            Parallel.ForEach(numbers, number =>
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            });

            return primeNumbers.ToList();
        }

        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }

        #region Helper Functions
        static double[,] InitializeMatrix(int rows, int cols)
        {
            double[,] matrix = new double[rows, cols];

            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = r.Next(100);
                }
            }
            return matrix;
        }
        #endregion

        public static void Main(){
            Console.WriteLine("Task parallel Library (TPL).");
            int[] arr1 = new int[100];
            Parallel.ForEach(arr1, (item) => Process(item));

            Console.WriteLine("For Loop Demonstration.");
            // Set up matrices. Use small values to better view
            // result matrix. Increase the counts to see greater
            // speedup in the parallel loop vs. the sequential loop.
            int colCount = 180;
            int rowCount = 2000;
            int colCount2 = 270;
            double[,] m1 = InitializeMatrix(rowCount, colCount);
            double[,] m2 = InitializeMatrix(colCount, colCount2);
            double[,] result = new double[rowCount, colCount2];

            // First do the sequential version.
            Console.Error.WriteLine("Executing sequential loop...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MultiplyMatricesSequential(m1, m2, result);
            stopwatch.Stop();
            Console.Error.WriteLine("Sequential loop time in milliseconds: {0}",
                                    stopwatch.ElapsedMilliseconds);

            // Reset timer and results matrix.
            stopwatch.Reset();
            result = new double[rowCount, colCount2];

            // Do the parallel loop.
            Console.Error.WriteLine("Executing parallel loop...");
            stopwatch.Start();
            MultiplyMatricesParallel(m1, m2, result);
            stopwatch.Stop();
            Console.Error.WriteLine("Parallel loop time in milliseconds: {0}",
                                    stopwatch.ElapsedMilliseconds);
            // Executing parallel loop...
            //Sequential loop time in milliseconds: 1084
            // Executing parallel loop...
            // Parallel loop time in milliseconds: 238


            ////Foreach
            // 2 million
            var limit = 2_000_000;
            var numbers = Enumerable.Range(0, limit).ToList();

            var watch = Stopwatch.StartNew();
            var primeNumbersFromForeach = GetPrimeList(numbers);
            watch.Stop();

            //Foreach
            var watchForParallel = Stopwatch.StartNew();
            var primeNumbersFromParallelForeach = GetPrimeListWithParallel(numbers);
            watchForParallel.Stop();

            Console.WriteLine($"Classical foreach loop | Total prime numbers : {primeNumbersFromForeach.Count} | Time Taken : {watch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"Parallel.ForEach loop  | Total prime numbers : {primeNumbersFromParallelForeach.Count} | Time Taken : {watchForParallel.ElapsedMilliseconds} ms.");

            // Source must be array or IList.
            int[] source = Enumerable.Range(0, 10).ToArray();

            // Partition the entire source array.
            var rangePartitioner = Partitioner.Create(0, source.Length);

            double[] results = new double[source.Length];

            // Loop over the partitions in parallel.
            var watchForSeq = Stopwatch.StartNew();
            Parallel.ForEach(rangePartitioner, (range, loopState) =>
            {
                // Loop over each range element without a delegate invocation.
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    results[i] = source[i] * Math.PI;
                }
            });
            watchForSeq.Stop();
            Console.WriteLine("Small - For Loop with partitioning :"+ watchForSeq.ElapsedMilliseconds+" ms." );

            int[] nums = Enumerable.Range(0, 1_000_000).ToArray();
            long total = 0;

            // Use type parameter to make subtotal a long, not an int
            Parallel.For<long>(0, nums.Length, () => 0,
                (j, loop, subtotal) =>
                {
                    subtotal += nums[j];
                    return subtotal;
                },
                subtotal => Interlocked.Add(ref total, subtotal));

            Console.WriteLine($"The total is {total:N0}");

            //int[] nums = Enumerable.Range(0, 10_000_000).ToArray();
            CancellationTokenSource cts = new();

            // Use ParallelOptions instance to store the CancellationToken
            ParallelOptions options = new()
            {
                CancellationToken = cts.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            Console.WriteLine("Press any key to start. Press 'c' to cancel.");
            //Console.ReadKey();

            // Run a task so that we can cancel from another thread.
            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar is 'c')
                    cts.Cancel();
                Console.WriteLine("press any key to exit");
            });

            try
            {
                Parallel.ForEach(nums, options, (num) =>
                {
                    double d = Math.Sqrt(num);
                    Console.WriteLine($"{d} on {Environment.CurrentManagedThreadId}");
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cts.Dispose();
            }

            Console.ReadKey();

            
        }
    }
}