/**
The Dataflow Library in the Task Parallel Library (TPL) is designed to help developers build robust, concurrent applications by providing in-process message passing for coarse-grained dataflow and pipelining tasks. Here are the key details:

The TPL Dataflow Library (the System.Threading.Tasks.Dataflow namespace) is not distributed with .NET. To install the System.Threading.Tasks.Dataflow namespace in Visual Studio, open your project, choose Manage NuGet Packages from the Project menu, and search online for the System.Threading.Tasks.Dataflow package. Alternatively, to install it using the .NET Core CLI, run dotnet add package System.Threading.Tasks.Dataflow.

1. Overview
The TPL Dataflow Library promotes actor-based programming by enabling asynchronous message passing between components. This model is particularly useful for applications that need to process data as it becomes available, such as real-time data processing 1.

2. Core Components
The Dataflow Library consists of several building blocks, each designed to handle specific types of data processing tasks:

    BufferBlock: Stores messages in a FIFO order.
    BroadcastBlock: Sends each message to multiple targets.
    WriteOnceBlock: Stores and broadcasts a single message.
    TransformBlock<TInput, TOutput>: Applies a transformation to each message.
    ActionBlock: Executes an action for each message.
    BatchBlock: Groups messages into batches.
    JoinBlock<T1, T2>: Joins messages from multiple sources 1.
3. Creating and Linking Blocks
Dataflow blocks can be linked together to form pipelines. For example, you can create a pipeline that reads data, processes it, and then writes the results:


4. Configuring Dataflow Blocks
You can configure dataflow blocks to meet specific requirements, such as setting the maximum degree of parallelism or specifying how data is buffered:

5. Handling Exceptions
The Dataflow Library provides mechanisms for handling exceptions that occur during data processing. Exceptions can be observed and handled using the Faulted state of a blocK.

6. Cancellation
Dataflow blocks support cancellation using CancellationToken. This allows you to stop the processing of data based on certain conditions:

7. Performance Considerations
The Dataflow Library is designed to maximize performance by efficiently utilizing system resources. It handles the scheduling of tasks, partitioning of data, and other low-level details, allowing developers to focus on the logic of their applications 1.

The Task Parallel Library (TPL) provides dataflow components to help increase the robustness of concurrency-enabled applications. These dataflow components are collectively referred to as the TPL Dataflow Library. This dataflow model promotes actor-based programming by providing in-process message passing for coarse-grained dataflow and pipelining tasks. The dataflow components build on the types and scheduling infrastructure of the TPL and integrate with the C#, Visual Basic, and F# language support for asynchronous programming. These dataflow components are useful when you have multiple operations that must communicate with one another asynchronously or when you want to process data as it becomes available. For example, consider an application that processes image data from a web camera. By using the dataflow model, the application can process image frames as they become available. If the application enhances image frames, for example, by performing light correction or red-eye reduction, you can create a pipeline of dataflow components. Each stage of the pipeline might use more coarse-grained parallelism functionality, such as the functionality that is provided by the TPL, to transform the image.


Programming Model:
-------------------
The TPL Dataflow Library provides a foundation for message passing and parallelizing CPU-intensive and I/O-intensive applications that have high throughput and low latency. It also gives you explicit control over how data is buffered and moves around the system. To better understand the dataflow programming model, consider an application that asynchronously loads images from disk and creates a composite of those images. Traditional programming models typically require that you use callbacks and synchronization objects, such as locks, to coordinate tasks and access to shared data. By using the dataflow programming model, you can create dataflow objects that process images as they are read from disk. Under the dataflow model, you declare how data is handled when it becomes available, and also any dependencies between data. Because the runtime manages dependencies between data, you can often avoid the requirement to synchronize access to shared data. In addition, because the runtime schedules work based on the asynchronous arrival of data, dataflow can improve responsiveness and throughput by efficiently managing the underlying threads.

Connecting Blocks:
---------------==--
You can connect dataflow blocks to form pipelines, which are linear sequences of dataflow blocks, or networks, which are graphs of dataflow blocks. A pipeline is one form of network. In a pipeline or network, sources asynchronously propagate data to targets as that data becomes available. The ISourceBlock<TOutput>.LinkTo method links a source dataflow block to a target block. A source can be linked to zero or more targets; targets can be linked from zero or more sources. You can add or remove dataflow blocks to or from a pipeline or network concurrently. The predefined dataflow block types handle all thread-safety aspects of linking and unlinking.

Filtering:
---------
When you call the ISourceBlock<TOutput>.LinkTo method to link a source to a target, you can supply a delegate that determines whether the target block accepts or rejects a message based on the value of that message. This filtering mechanism is a useful way to guarantee that a dataflow block receives only certain values. For most of the predefined dataflow block types, if a source block is connected to multiple target blocks, when a target block rejects a message, the source offers that message to the next target. The order in which a source offers messages to targets is defined by the source and can vary according to the type of the source. Most source block types stop offering a message after one target accepts that message. One exception to this rule is the BroadcastBlock<T> class, which offers each message to all targets, even if some targets reject the message. For an example that uses filtering to process only certain messages, see Walkthrough: Using Dataflow in a Windows Forms Application.

Sources and Targets:
--------------------
The TPL Dataflow Library consists of dataflow blocks, which are data structures that buffer and process data. The TPL defines three kinds of dataflow blocks: source blocks, target blocks, and propagator blocks. A source block acts as a source of data and can be read from. A target block acts as a receiver of data and can be written to. A propagator block acts as both a source block and a target block, and can be read from and written to. The TPL defines the System.Threading.Tasks.Dataflow.ISourceBlock<TOutput> interface to represent sources, System.Threading.Tasks.Dataflow.ITargetBlock<TInput> to represent targets, and System.Threading.Tasks.Dataflow.IPropagatorBlock<TInput,TOutput> to represent propagators. IPropagatorBlock<TInput,TOutput> inherits from both ISourceBlock<TOutput>, and ITargetBlock<TInput>.

The TPL Dataflow Library provides several predefined dataflow block types that implement the ISourceBlock<TOutput>, ITargetBlock<TInput>, and IPropagatorBlock<TInput,TOutput> interfaces. These dataflow block types are described in this document in the section Predefined Dataflow Block Types.

Message Passing:
----------------
The dataflow programming model is related to the concept of message passing, where independent components of a program communicate with one another by sending messages. One way to propagate messages among application components is to call the Post (synchronous) and SendAsync (asynchronous) methods to send messages to target dataflow blocks, and the Receive, ReceiveAsync, and TryReceive methods to receive messages from source blocks. You can combine these methods with dataflow pipelines or networks by sending input data to the head node (a target block), and by receiving output data from the terminal node of the pipeline or the terminal nodes of the network (one or more source blocks). You can also use the Choose method to read from the first of the provided sources that has data available and perform action on that data.

Source blocks offer data to target blocks by calling the ITargetBlock<TInput>.OfferMessage method. The target block responds to an offered message in one of three ways: it can accept the message, decline the message, or postpone the message. When the target accepts the message, the OfferMessage method returns Accepted. When the target declines the message, the OfferMessage method returns Declined. When the target requires that it no longer receives any messages from the source, OfferMessage returns DecliningPermanently. The predefined source block types do not offer messages to linked targets after such a return value is received, and they automatically unlink from such targets.

When a target block postpones the message for later use, the OfferMessage method returns Postponed. A target block that postpones a message can later call the ISourceBlock<TOutput>.ReserveMessage method to try to reserve the offered message. At this point, the message is either still available and can be used by the target block, or the message has been taken by another target. When the target block later requires the message or no longer needs the message, it calls the ISourceBlock<TOutput>.ConsumeMessage or ReleaseReservation method, respectively. Message reservation is typically used by the dataflow block types that operate in non-greedy mode. Non-greedy mode is explained later in this document. Instead of reserving a postponed message, a target block can also use the ISourceBlock<TOutput>.ConsumeMessage method to attempt to directly consume the postponed message.

Dataflow Block Completion:
---------------------------
Dataflow blocks also support the concept of completion. A dataflow block that is in the completed state does not perform any further work. Each dataflow block has an associated System.Threading.Tasks.Task object, known as a completion task, that represents the completion status of the block. Because you can wait for a Task object to finish, by using completion tasks, you can wait for one or more terminal nodes of a dataflow network to finish. The IDataflowBlock interface defines the Complete method, which informs the dataflow block of a request for it to complete, and the Completion property, which returns the completion task for the dataflow block. Both ISourceBlock<TOutput> and ITargetBlock<TInput> inherit the IDataflowBlock interface.

There are two ways to determine whether a dataflow block completed without error, encountered one or more errors, or was canceled. The first way is to call the Task.Wait method on the completion task in a try-catch block (Try-Catch in Visual Basic). The following example creates an ActionBlock<TInput> object that throws ArgumentOutOfRangeException if its input value is less than zero. AggregateException is thrown when this example calls Wait on the completion task. The ArgumentOutOfRangeException is accessed through the InnerExceptions property of the AggregateException object.

BufferBlock<T>:
----------------
The BufferBlock<T> class represents a general-purpose asynchronous messaging structure. This class stores a first in, first out (FIFO) queue of messages that can be written to by multiple sources or read from by multiple targets. When a target receives a message from a BufferBlock<T> object, that message is removed from the message queue. Therefore, although a BufferBlock<T> object can have multiple targets, only one target will receive each message. The BufferBlock<T> class is useful when you want to pass multiple messages to another component, and that component must receive each message.

BroadcastBlock<T>:
------------------
The BroadcastBlock<T> class is useful when you must pass multiple messages to another component, but that component needs only the most recent value. This class is also useful when you want to broadcast a message to multiple components.

WriteOnceBlock<T>:
------------------
The WriteOnceBlock<T> class resembles the BroadcastBlock<T> class, except that a WriteOnceBlock<T> object can be written to one time only. You can think of WriteOnceBlock<T> as being similar to the C# readonly (ReadOnly in Visual Basic) keyword, except that a WriteOnceBlock<T> object becomes immutable after it receives a value instead of at construction. Like the BroadcastBlock<T> class, when a target receives a message from a WriteOnceBlock<T> object, that message is not removed from that object. Therefore, multiple targets receive a copy of the message. The WriteOnceBlock<T> class is useful when you want to propagate only the first of multiple messages.

ActionBlock<T>:
--------------
The ActionBlock<TInput> class is a target block that calls a delegate when it receives data. Think of a ActionBlock<TInput> object as a delegate that runs asynchronously when data becomes available. The delegate that you provide to an ActionBlock<TInput> object can be of type Action<T> or type System.Func<TInput, Task>. When you use an ActionBlock<TInput> object with Action<T>, processing of each input element is considered completed when the delegate returns. When you use an ActionBlock<TInput> object with System.Func<TInput, Task>, processing of each input element is considered completed only when the returned Task object is completed. By using these two mechanisms, you can use ActionBlock<TInput> for both synchronous and asynchronous processing of each input element.

TransformBlock<TInput, TOutput>:
-----------------------------------
The TransformBlock<TInput,TOutput> class resembles the ActionBlock<TInput> class, except that it acts as both a source and as a target. The delegate that you pass to a TransformBlock<TInput,TOutput> object returns a value of type TOutput. The delegate that you provide to a TransformBlock<TInput,TOutput> object can be of type System.Func<TInput, TOutput> or type System.Func<TInput, Task<TOutput>>. When you use a TransformBlock<TInput,TOutput> object with System.Func<TInput, TOutput>, processing of each input element is considered completed when the delegate returns. When you use a TransformBlock<TInput,TOutput> object used with System.Func<TInput, Task<TOutput>>, processing of each input element is considered completed only when the returned Task<TResult> object is completed. As with ActionBlock<TInput>, by using these two mechanisms, you can use TransformBlock<TInput,TOutput> for both synchronous and asynchronous processing of each input element.

TransformManyBlock<TInput, TOutput>:
------------------------------------
The TransformManyBlock<TInput,TOutput> class resembles the TransformBlock<TInput,TOutput> class, except that TransformManyBlock<TInput,TOutput> produces zero or more output values for each input value, instead of only one output value for each input value. The delegate that you provide to a TransformManyBlock<TInput,TOutput> object can be of type System.Func<TInput, IEnumerable<TOutput>> or type System.Func<TInput, Task<IEnumerable<TOutput>>>. When you use a TransformManyBlock<TInput,TOutput> object with System.Func<TInput, IEnumerable<TOutput>>, processing of each input element is considered completed when the delegate returns. When you use a TransformManyBlock<TInput,TOutput> object with System.Func<TInput, Task<IEnumerable<TOutput>>>, processing of each input element is considered complete only when the returned System.Threading.Tasks.Task<IEnumerable<TOutput>> object is completed.

Degree of Parallelism:
-----------------------
Every ActionBlock<TInput>, TransformBlock<TInput,TOutput>, and TransformManyBlock<TInput,TOutput> object buffers input messages until the block is ready to process them. By default, these classes process messages in the order in which they are received, one message at a time. You can also specify the degree of parallelism to enable ActionBlock<TInput>, TransformBlock<TInput,TOutput> and TransformManyBlock<TInput,TOutput> objects to process multiple messages concurrently. For more information about concurrent execution, see the section Specifying the Degree of Parallelism later in this document. For an example that sets the degree of parallelism to enable an execution dataflow block to process more than one message at a time, see How to: Specify the Degree of Parallelism in a Dataflow Block.

BatchBlock<T>:
----------------
The BatchBlock<T> class combines sets of input data, which are known as batches, into arrays of output data. You specify the size of each batch when you create a BatchBlock<T> object. When the BatchBlock<T> object receives the specified count of input elements, it asynchronously propagates out an array that contains those elements. If a BatchBlock<T> object is set to the completed state but does not contain enough elements to form a batch, it propagates out a final array that contains the remaining input elements.

The BatchBlock<T> class operates in either greedy or non-greedy mode. In greedy mode, which is the default, a BatchBlock<T> object accepts every message that it is offered and propagates out an array after it receives the specified count of elements. In non-greedy mode, a BatchBlock<T> object postpones all incoming messages until enough sources have offered messages to the block to form a batch. Greedy mode typically performs better than non-greedy mode because it requires less processing overhead. However, you can use non-greedy mode when you must coordinate consumption from multiple sources in an atomic fashion. Specify non-greedy mode by setting Greedy to False in the dataflowBlockOptions parameter in the BatchBlock<T> constructor.

JoinBlock<T1, T2, ...>:
------------------------
The JoinBlock<T1,T2> and JoinBlock<T1,T2,T3> classes collect input elements and propagate out System.Tuple<T1,T2> or System.Tuple<T1,T2,T3> objects that contain those elements. The JoinBlock<T1,T2> and JoinBlock<T1,T2,T3> classes do not inherit from ITargetBlock<TInput>. Instead, they provide properties, Target1, Target2, and Target3, that implement ITargetBlock<TInput>.

Like BatchBlock<T>, JoinBlock<T1,T2> and JoinBlock<T1,T2,T3> operate in either greedy or non-greedy mode. In greedy mode, which is the default, a JoinBlock<T1,T2> or JoinBlock<T1,T2,T3> object accepts every message that it is offered and propagates out a tuple after each of its targets receives at least one message. In non-greedy mode, a JoinBlock<T1,T2> or JoinBlock<T1,T2,T3> object postpones all incoming messages until all targets have been offered the data that is required to create a tuple. At this point, the block engages in a two-phase commit protocol to atomically retrieve all required items from the sources. This postponement makes it possible for another entity to consume the data in the meantime, to allow the overall system to make forward progress.

BatchedJoinBlock<T1, T2, ...>:
------------------------------
The BatchedJoinBlock<T1,T2> and BatchedJoinBlock<T1,T2,T3> classes collect batches of input elements and propagate out System.Tuple(IList(T1), IList(T2)) or System.Tuple(IList(T1), IList(T2), IList(T3)) objects that contain those elements. Think of BatchedJoinBlock<T1,T2> as a combination of BatchBlock<T> and JoinBlock<T1,T2>. Specify the size of each batch when you create a BatchedJoinBlock<T1,T2> object. BatchedJoinBlock<T1,T2> also provides properties, Target1 and Target2, that implement ITargetBlock<TInput>. When the specified count of input elements are received from across all targets, the BatchedJoinBlock<T1,T2> object asynchronously propagates out a System.Tuple(IList(T1), IList(T2)) object that contains those elements.

Enabling Cancellation:"
------------------------
The TPL provides a mechanism that enables tasks to coordinate cancellation in a cooperative manner. To enable dataflow blocks to participate in this cancellation mechanism, set the CancellationToken property. When this CancellationToken object is set to the canceled state, all dataflow blocks that monitor this token finish execution of their current item but do not start processing subsequent items. These dataflow blocks also clear any buffered messages, release connections to any source and target blocks, and transition to the canceled state. By transitioning to the canceled state, the Completion property has the Status property set to Canceled, unless an exception occurred during processing. In that case, Status is set to Faulted.

**/
using System;
using System.Threading.Tasks.Dataflow;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Linq;

namespace ParallelProgramming{
    class DataFlow{
        public static void Main(){
            Console.WriteLine("DataFlow");
            // Create an ActionBlock<int> object that prints its input
            // and throws ArgumentOutOfRangeException if the input
            // is less than zero.
            var throwIfNegative = new ActionBlock<int>(n =>
            {
            Console.WriteLine($"n = {n}");
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            });

            // Post values to the block.
            throwIfNegative.Post(0);
            throwIfNegative.Post(-1);
            throwIfNegative.Post(1);
            throwIfNegative.Post(-2);
            throwIfNegative.Complete();

            // Wait for completion in a try/catch block.
            try
            {
            throwIfNegative.Completion.Wait();
            }
            catch (AggregateException ae)
            {
            // If an unhandled exception occurs during dataflow processing, all
            // exceptions are propagated through an AggregateException object.
            ae.Handle(e =>
            {
                Console.WriteLine($"Encountered {e.GetType().Name}: {e.Message}");
                return true;
            });
            }

            /* Output:
            n = 0
            n = -1
            Encountered ArgumentOutOfRangeException: Specified argument was out of the range
            of valid values.
            */

            // Create a BufferBlock<int> object.
            var bufferBlock = new BufferBlock<int>();

            // Post several messages to the block.
            for (int i = 0; i < 3; i++)
            {
            bufferBlock.Post(i);
            }

            // Receive the messages back from the block.
            for (int i = 0; i < 3; i++)
            {
            Console.WriteLine(bufferBlock.Receive());
            }

            /* Output:
            0
            1
            2
            */

            // Create a BroadcastBlock<double> object.
            var broadcastBlock = new BroadcastBlock<double>(null);

            // Post a message to the block.
            broadcastBlock.Post(Math.PI);

            // Receive the messages back from the block several times.
            for (int i = 0; i < 3; i++)
            {
            Console.WriteLine(broadcastBlock.Receive());
            }

            /* Output:
            3.14159265358979
            3.14159265358979
            3.14159265358979
            */

            // Create a WriteOnceBlock<string> object.
            var writeOnceBlock = new WriteOnceBlock<string>(null);

            // Post several messages to the block in parallel. The first
            // message to be received is written to the block.
            // Subsequent messages are discarded.
            Parallel.Invoke(
            () => writeOnceBlock.Post("Message 1"),
            () => writeOnceBlock.Post("Message 2"),
            () => writeOnceBlock.Post("Message 3"));

            // Receive the message from the block.
            Console.WriteLine(writeOnceBlock.Receive());

            /* Sample output:
            Message 2
            */

            // Performs several computations by using dataflow and returns the elapsed
            // time required to perform the computations.
            static TimeSpan TimeDataflowComputations(int maxDegreeOfParallelism,
            int messageCount)
            {
            // Create an ActionBlock<int> that performs some work.
            var workerBlock = new ActionBlock<int>(
                // Simulate work by suspending the current thread.
                millisecondsTimeout => Thread.Sleep(millisecondsTimeout),
                // Specify a maximum degree of parallelism.
                new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = maxDegreeOfParallelism
                });

            // Compute the time that it takes for several messages to
            // flow through the dataflow block.

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < messageCount; i++)
            {
                workerBlock.Post(1000);
            }
            workerBlock.Complete();

            // Wait for all messages to propagate through the network.
            workerBlock.Completion.Wait();

            // Stop the timer and return the elapsed number of milliseconds.
            stopwatch.Stop();
            return stopwatch.Elapsed;
            }

            // Create a TransformBlock<int, double> object that
            // computes the square root of its input.
            var transformBlock = new TransformBlock<int, double>(n => Math.Sqrt(n));

            // Post several messages to the block.
            transformBlock.Post(10);
            transformBlock.Post(20);
            transformBlock.Post(30);

            // Read the output messages from the block.
            for (int i = 0; i < 3; i++)
            {
            Console.WriteLine(transformBlock.Receive());
            }

            /* Output:
            3.16227766016838
            4.47213595499958
            5.47722557505166
            */

            // Create a TransformManyBlock<string, char> object that splits
            // a string into its individual characters.
            var transformManyBlock = new TransformManyBlock<string, char>(
            s => s.ToCharArray());

            // Post two messages to the first block.
            transformManyBlock.Post("Hello");
            transformManyBlock.Post("World");

            // Receive all output values from the block.
            for (int i = 0; i < ("Hello" + "World").Length; i++)
            {
            Console.WriteLine(transformManyBlock.Receive());
            }

            /* Output:
            H
            e
            l
            l
            o
            W
            o
            r
            l
            d
            */

            // Create a BatchBlock<int> object that holds ten
            // elements per batch.
            var batchBlock = new BatchBlock<int>(10);

            // Post several values to the block.
            for (int i = 0; i < 13; i++)
            {
            batchBlock.Post(i);
            }
            // Set the block to the completed state. This causes
            // the block to propagate out any remaining
            // values as a final batch.
            batchBlock.Complete();

            // Print the sum of both batches.

            Console.WriteLine($"The sum of the elements in batch 1 is {batchBlock.Receive().Sum()}.");

            Console.WriteLine($"The sum of the elements in batch 2 is {batchBlock.Receive().Sum()}.");

            /* Output:
            The sum of the elements in batch 1 is 45.
            The sum of the elements in batch 2 is 33.
            */

            // Create a JoinBlock<int, int, char> object that requires
            // two numbers and an operator.
            var joinBlock = new JoinBlock<int, int, char>();

            // Post two values to each target of the join.

            joinBlock.Target1.Post(3);
            joinBlock.Target1.Post(6);

            joinBlock.Target2.Post(5);
            joinBlock.Target2.Post(4);

            joinBlock.Target3.Post('+');
            joinBlock.Target3.Post('-');

            // Receive each group of values and apply the operator part
            // to the number parts.

            for (int i = 0; i < 2; i++)
            {
            var data = joinBlock.Receive();
            switch (data.Item3)
            {
                case '+':
                    Console.WriteLine($"{data.Item1} + {data.Item2} = {data.Item1 + data.Item2}");
                    break;
                case '-':
                    Console.WriteLine($"{data.Item1} - {data.Item2} = {data.Item1 - data.Item2}");
                    break;
                default:
                    Console.WriteLine($"Unknown operator '{data.Item3}'.");
                    break;
            }
            }

            /* Output:
            3 + 5 = 8
            6 - 4 = 2
            */

            // For demonstration, create a Func<int, int> that
            // returns its argument, or throws ArgumentOutOfRangeException
            // if the argument is less than zero.
            Func<int, int> DoWork = n =>
            {
            if (n < 0)
                throw new ArgumentOutOfRangeException();
            return n;
            };

            // Create a BatchedJoinBlock<int, Exception> object that holds
            // seven elements per batch.
            var batchedJoinBlock = new BatchedJoinBlock<int, Exception>(7);

            // Post several items to the block.
            foreach (int i in new int[] { 5, 6, -7, -22, 13, 55, 0 })
            {
            try
            {
                // Post the result of the worker to the
                // first target of the block.
                batchedJoinBlock.Target1.Post(DoWork(i));
            }
            catch (ArgumentOutOfRangeException e)
            {
                // If an error occurred, post the Exception to the
                // second target of the block.
                batchedJoinBlock.Target2.Post(e);
            }
            }

            // Read the results from the block.
            var results = batchedJoinBlock.Receive();

            // Print the results to the console.

            // Print the results.
            foreach (int n in results.Item1)
            {
            Console.WriteLine(n);
            }
            // Print failures.
            foreach (Exception e in results.Item2)
            {
            Console.WriteLine(e.Message);
            }

            /* Output:
            5
            6
            13
            55
            0
            Specified argument was out of the range of valid values.
            Specified argument was out of the range of valid values.
            */


        }

        
    }
}