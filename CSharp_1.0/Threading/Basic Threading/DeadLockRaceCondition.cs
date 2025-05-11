using System;
using System.Threading;
/**
Multithreading requires careful programming. For most tasks, you can reduce complexity by queuing requests for execution by thread pool threads.

Deadlocks and race conditions:
--------------------------------
Multithreading solves problems with throughput and responsiveness, but in doing so it introduces new problems: deadlocks and race conditions.

Deadlocks:
----------
A deadlock occurs when each of two threads tries to lock a resource the other has already locked. Neither thread can make any further progress.

Many methods of the managed threading classes provide time-outs to help you detect deadlocks. For example, the following code attempts to acquire a lock on an object named lockObject. If the lock is not obtained in 300 milliseconds, Monitor.TryEnter returns false.

How Deadlock Occurs:
--------------------
Thread A locks Resource 1 and waits for Resource 2.
Thread B locks Resource 2 and waits for Resource 1.
Both threads are now stuck, waiting for each other to release the resources.

How to Prevent Deadlocks:
-------------------------
1. Lock Ordering
2. Timeouts
3. Deadlock Detection


Race Condition:
--------------
A race condition is a bug that occurs when the outcome of a program depends on which of two or more threads reaches a particular block of code first. Running the program many times produces different results, and the result of any given run cannot be predicted.

A simple example of a race condition is incrementing a field. Suppose a class has a private static field (Shared in Visual Basic) that is incremented every time an instance of the class is created, using code such as objCt++; (C#) or objCt += 1 (Visual Basic). This operation requires loading the value from objCt into a register, incrementing the value, and storing it in objCt.

In a multithreaded application, a thread that has loaded and incremented the value might be preempted by another thread which performs all three steps; when the first thread resumes execution and stores its value, it overwrites objCt without taking into account the fact that the value has changed in the interim.

This particular race condition is easily avoided by using methods of the Interlocked class, such as Interlocked.Increment. To read about other techniques for synchronizing data among multiple threads, see Synchronizing Data for Multithreading.

Race conditions can also occur when you synchronize the activities of multiple threads. Whenever you write a line of code, you must consider what might happen if a thread were preempted before executing the line (or before any of the individual machine instructions that make up the line), and another thread overtook it.

A race condition is a situation in programming where the outcome of a program depends on the timing or sequence of uncontrollable events, such as the order in which threads execute. This can lead to unpredictable behavior and bugs that are difficult to reproduce.

Understanding Race Conditions

🔄 How Race Conditions Occur:
-----------------------------

Race conditions typically occur when:
--------------------------------------
    1.Multiple threads access shared data.
    2.At least one thread modifies the data.
    3.The threads do not use proper synchronization mechanisms.

🛠️ How to Prevent Race Conditions
1. Locking
Use locks to ensure that only one thread can access the shared resource at a time.
2. Interlocked Operations
Use atomic operations provided by the Interlocked class for simple updates.
3. Volatile Keyword
Use the volatile keyword to ensure that a variable is read from and written to main memory directly.
4. Higher-Level Constructs
Use higher-level concurrency constructs like ConcurrentDictionary, ConcurrentQueue, or Task for more complex scenarios.


Recommendations for class libraries:
--------------------------------------
Consider the following guidelines when designing class libraries for multithreading:

Avoid the need for synchronization, if possible. This is especially true for heavily used code. For example, an algorithm might be adjusted to tolerate a race condition rather than eliminate it. Unnecessary synchronization decreases performance and creates the possibility of deadlocks and race conditions.

Make static data (Shared in Visual Basic) thread safe by default.

Do not make instance data thread safe by default. Adding locks to create thread-safe code decreases performance, increases lock contention, and creates the possibility for deadlocks to occur. In common application models, only one thread at a time executes user code, which minimizes the need for thread safety. For this reason, the .NET class libraries are not thread safe by default.

Avoid providing static methods that alter static state. In common server scenarios, static state is shared across requests, which means multiple threads can execute that code at the same time. This opens up the possibility of threading bugs. Consider using a design pattern that encapsulates data into instances that are not shared across requests. Furthermore, if static data are synchronized, calls between static methods that alter state can result in deadlocks or redundant synchronization, adversely affecting performance.



**/
namespace Threading{
    class Counter
    {
        private int _count = 0;

        public void Increment()
        {
            _count++;
        }

        public int GetCount()
        {
            return _count;
        }
    }

    class DeadLockRaceConditionClass{
        public static void Main(){
            Console.WriteLine("DeadLock and Race Condition. ");

            //Deadlock
            object lock1 = new object();
            object lock2 = new object();

            void ThreadA()
            {
                lock (lock1)
                {
                    Thread.Sleep(100); // Simulate some work
                    lock (lock2)
                    {
                        Console.WriteLine("Thread A acquired both locks");
                    }
                }
            }

            void ThreadB()
            {
                lock (lock2)
                {
                    Thread.Sleep(100); // Simulate some work
                    lock (lock1)
                    {
                        Console.WriteLine("Thread B acquired both locks");
                    }
                }
            }

            Thread t1 = new Thread(ThreadA);
            Thread t2 = new Thread(ThreadB);

            // t1.Start();
            // t2.Start();

            // t1.Join();
            // t2.Join();

            //Race Condition

            Counter counter = new Counter();

            void RaceThreadA()
            {
                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(1);
                    counter.Increment();
                }
            }

            void RaceThreadB()
            {
                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(1);
                    counter.Increment();
                }
            }

            Thread tt1 = new Thread(RaceThreadA);
            Thread tt2 = new Thread(RaceThreadB);

            tt1.Start();
            tt2.Start();

            Console.WriteLine($"{0} State : {1}",tt1.Name, tt1.ThreadState);
            Console.WriteLine($"{0} State : {1}",tt2.Name, tt2.ThreadState);
            tt1.Join();
            Console.WriteLine($"{0} State : {1}",tt1.Name, tt1.ThreadState);
            Console.WriteLine($"{0} State : {1}",tt2.Name, tt2.ThreadState);
            tt2.Join();
            Console.WriteLine($"{0} State : {1}",tt1.Name, tt1.ThreadState);
            Console.WriteLine($"{0} State : {1}",tt2.Name, tt2.ThreadState);

            Console.WriteLine($"Final count: {counter.GetCount()}");
            //Expected Result is 2000 but Acutal result is less than 2000 where each time value is different when running program.
            //Like - 1971


        }
    }
}
