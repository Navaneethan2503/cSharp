/**
ParallelLoopResult Sturct:
--------------------------
Provides completion status on the execution of a Parallel loop.

    public struct ParallelLoopResult

Remarks
If IsCompleted returns true, then the loop ran to completion, such that all iterations of the loop were executed. If IsCompleted returns false and LowestBreakIteration returns null, a call to Stop was used to end the loop prematurely. If IsCompleted returns false and LowestBreakIteration returns a non-null integral value, Break was used to end the loop prematurely.

Properties:
-----------
IsCompleted	- Gets whether the loop ran to completion, such that all iterations of the loop were executed and the loop didn't receive a request to end prematurely.
LowestBreakIteration	- Gets the index of the lowest iteration from which Break() was called.

**/

using System;

namespace ParallelProgramming{
    class ParallelLoopResult{
        public static void Main(){
            Console.WriteLine("ParallelLoopResult Struct");
        }
    }
}