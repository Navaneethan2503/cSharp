/**
ParallelLoopState Class
------------------------
Enables iterations of parallel loops to interact with other iterations. An instance of this class is provided by the Parallel class to each loop; you can not create instances in your code.

    public class ParallelLoopState

Note that you cannot instantiate an instance of this class. It is automatically generated by the compiler as an argument in a call to the Parallel.For or Parallel.ForEach method. The example provides an illustration.

Constructs such as for and foreach (in C#) and For and For Each (in Visual Basic) execute sequentially from the lowest index to the highest or from the first object in a set to the last. In contrast, the Parallel.For and Parallel.ForEach methods do not. Because individual iterations of the loop run in parallel, they can begin and end in any order. The ParallelLoopState class allows individual iterations of parallel loops to interact with one another. The ParallelLoopState class allows you to:
    Exit the current iteration and prevent any additional iterations from starting by calling the Stop method. This does not affect iterations that have already begun execution.
    Prevent any iterations with an index greater than the current index from executing by calling the Break method. This does not affect iterations that have already begun execution.
    Determine whether an exception has occurred in any loop iteration by retrieving the value of the IsExceptional property.
    Determine whether any iteration of the loop has called the Stop method by retrieving the value of the IsStopped property. You can use this property to return from iterations of the loop that started before the call to the Stop method but are still executing.
    Determine whether any iteration of the loop has called the Break or Stop method or has thrown an exception by retrieving the value of the ShouldExitCurrentIteration property.
    Exit from a long-running iteration whose index is greater than the index of an iteration in which Break was called by retrieving the value of the LowestBreakIteration property.

Properties:
-------------
IsExceptional	- Gets whether any iteration of the loop has thrown an exception that went unhandled by that iteration.
IsStopped	- Gets whether any iteration of the loop has called the Stop() method.
LowestBreakIteration	- Gets the lowest iteration of the loop from which Break() was called.
ShouldExitCurrentIteration	- Gets whether the current iteration of the loop should exit based on requests made by this or other iterations.

Methods:
--------
Break()	- Communicates that the Parallel loop should cease execution of iterations beyond the current iteration at the system's earliest convenience.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Stop()	- Communicates that the Parallel loop should cease execution at the system's earliest convenience.
ToString()	- Returns a string that represents the current object.(Inherited from Object)


**/
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming{
    public class ParallelLoopState
    {
        public static void Main()
        {
            var rnd = new Random();
            int breakIndex = rnd.Next(1, 11);

            Console.WriteLine($"Will call Break at iteration {breakIndex}\n");

            var result = Parallel.For(1, 101, (i, state) => 
            {
                Console.WriteLine($"Beginning iteration {i}");
                int delay;
                lock (rnd)
                    delay = rnd.Next(1, 1001);
                Thread.Sleep(delay);

                if (state.ShouldExitCurrentIteration)
                {
                    if (state.LowestBreakIteration < i)
                        return;
                }

                if (i == breakIndex)
                {
                    Console.WriteLine($"Break in iteration {i}");
                    state.Break();
                }

                Console.WriteLine($"Completed iteration {i}");
            });

            if (result.LowestBreakIteration.HasValue)
                Console.WriteLine($"\nLowest Break Iteration: {result.LowestBreakIteration}");
            else
                Console.WriteLine($"\nNo lowest break iteration.");
        }
    }
    // The example displays output like the following:
    //       Will call Break at iteration 8
    //
    //       Beginning iteration 1
    //       Beginning iteration 13
    //       Beginning iteration 97
    //       Beginning iteration 25
    //       Beginning iteration 49
    //       Beginning iteration 37
    //       Beginning iteration 85
    //       Beginning iteration 73
    //       Beginning iteration 61
    //       Completed iteration 85
    //       Beginning iteration 86
    //       Completed iteration 61
    //       Beginning iteration 62
    //       Completed iteration 86
    //       Beginning iteration 87
    //       Completed iteration 37
    //       Beginning iteration 38
    //       Completed iteration 38
    //       Beginning iteration 39
    //       Completed iteration 25
    //       Beginning iteration 26
    //       Completed iteration 26
    //       Beginning iteration 27
    //       Completed iteration 73
    //       Beginning iteration 74
    //       Completed iteration 62
    //       Beginning iteration 63
    //       Completed iteration 39
    //       Beginning iteration 40
    //       Completed iteration 40
    //       Beginning iteration 41
    //       Completed iteration 13
    //       Beginning iteration 14
    //       Completed iteration 1
    //       Beginning iteration 2
    //       Completed iteration 97
    //       Beginning iteration 98
    //       Completed iteration 49
    //       Beginning iteration 50
    //       Completed iteration 87
    //       Completed iteration 27
    //       Beginning iteration 28
    //       Completed iteration 50
    //       Beginning iteration 51
    //       Beginning iteration 88
    //       Completed iteration 14
    //       Beginning iteration 15
    //       Completed iteration 15
    //       Completed iteration 2
    //       Beginning iteration 3
    //       Beginning iteration 16
    //       Completed iteration 63
    //       Beginning iteration 64
    //       Completed iteration 74
    //       Beginning iteration 75
    //       Completed iteration 41
    //       Beginning iteration 42
    //       Completed iteration 28
    //       Beginning iteration 29
    //       Completed iteration 29
    //       Beginning iteration 30
    //       Completed iteration 98
    //       Beginning iteration 99
    //       Completed iteration 64
    //       Beginning iteration 65
    //       Completed iteration 42
    //       Beginning iteration 43
    //       Completed iteration 88
    //       Beginning iteration 89
    //       Completed iteration 51
    //       Beginning iteration 52
    //       Completed iteration 16
    //       Beginning iteration 17
    //       Completed iteration 43
    //       Beginning iteration 44
    //       Completed iteration 44
    //       Beginning iteration 45
    //       Completed iteration 99
    //       Beginning iteration 4
    //       Completed iteration 3
    //       Beginning iteration 8
    //       Completed iteration 4
    //       Beginning iteration 5
    //       Completed iteration 52
    //       Beginning iteration 53
    //       Completed iteration 75
    //       Beginning iteration 76
    //       Completed iteration 76
    //       Beginning iteration 77
    //       Completed iteration 65
    //       Beginning iteration 66
    //       Completed iteration 5
    //       Beginning iteration 6
    //       Completed iteration 89
    //       Beginning iteration 90
    //       Completed iteration 30
    //       Beginning iteration 31
    //       Break in iteration 8
    //       Completed iteration 8
    //       Completed iteration 6
    //       Beginning iteration 7
    //       Completed iteration 7
    //
    //       Lowest Break Iteration: 8
}