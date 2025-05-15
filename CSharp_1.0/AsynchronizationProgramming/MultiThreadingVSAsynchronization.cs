using System;
using System.Threading;
using System.Threading.Tasks;
/**
Multithreading:
---------------
Concept:
---------
Multithreading involves running multiple threads concurrently within a single process. Each thread can execute code independently.

Use Cases:
----------
CPU-bound tasks: Ideal for tasks that require significant computation, such as data processing or complex calculations.
Parallel execution: Useful when you need to perform multiple operations simultaneously.

Pros:
-----
Parallelism: Can leverage multiple CPU cores for better performance.
Fine-grained control: Allows explicit management of thread lifecycle and synchronization.

Cons:
-----
Complexity: Requires careful handling of shared resources to avoid issues like race conditions and deadlocks.
Overhead: Creating and managing threads can be resource-intensive.


Asynchronous Programming:
-------------------------
Concept:
----------
Asynchronous programming uses non-blocking operations to improve responsiveness, especially for I/O-bound tasks. It doesn't necessarily involve multiple threads.

Use Cases:
----------
I/O-bound tasks: Ideal for tasks that involve waiting for external resources, such as file I/O, network requests, or database queries.
Responsive applications: Keeps the UI thread free for user interactions in applications with graphical interfaces.

Pros:
Simplicity: Easier to write and maintain compared to multithreading.
Resource efficiency: Uses fewer system resources by not blocking threads.

Cons:
Limited parallelism: Not suitable for CPU-bound tasks that require parallel execution.
Context switching: Can introduce overhead due to frequent context switching.

Choosing Between Them:
----------------------
Multithreading: Choose when you need to perform CPU-bound tasks in parallel and can manage the complexity of thread synchronization.
Asynchronous Programming: Choose when you need to perform I/O-bound tasks without blocking the main thread, especially in applications with user interfaces.


**/
namespace AsynchronousProgramming{
    class MultiThreadingVsAsynchronous{

        public async Task PerformTaskAsync()
        {
            await Task.Run(() => {
                // Task to be performed asynchronously
                Console.WriteLine("Task running asynchronously.");
            });
        }

        public void PerformTask()
        {
            Thread thread = new Thread(() => {
                // Task to be performed in a separate thread
                Console.WriteLine("Task running in a separate thread.");
            });
            thread.Start();
        }

        public static void Main(){
            Console.WriteLine("Multi Threading and Asynchronization Programming.");
        }
    }
}