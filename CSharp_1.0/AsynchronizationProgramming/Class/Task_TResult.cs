using System;
using System.Threading.Tasks;
/**
Task<TResult> Class
--------------------

Represents an asynchronous operation that can return a value.

public class Task<TResult> : System.Threading.Tasks.Task

Constructors:
--------------
Task<TResult>(Func<Object,TResult>, Object, CancellationToken, TaskCreationOptions)	- Initializes a new Task<TResult> with the specified action, state, and options.
Task<TResult>(Func<Object,TResult>, Object, CancellationToken)	- Initializes a new Task<TResult> with the specified action, state, and options.
Task<TResult>(Func<Object,TResult>, Object, TaskCreationOptions)	- Initializes a new Task<TResult> with the specified action, state, and options.
Task<TResult>(Func<Object,TResult>, Object)	- Initializes a new Task<TResult> with the specified function and state.
Task<TResult>(Func<TResult>, CancellationToken, TaskCreationOptions)	- Initializes a new Task<TResult> with the specified function and creation options.
Task<TResult>(Func<TResult>, CancellationToken)	- Initializes a new Task<TResult> with the specified function.
Task<TResult>(Func<TResult>, TaskCreationOptions)	- Initializes a new Task<TResult> with the specified function and creation options.
Task<TResult>(Func<TResult>)	- Initializes a new Task<TResult> with the specified function.

Properties:
-----------
Result	- Gets the result value of this Task<TResult>.



**/
namespace AsynchronousProgramming{
    class TaskTResult{
        public static void Main(){
            Console.WriteLine("Task<TResult> Class");
            var t = Task<int>.Run( () => {
                                      // Just loop.
                                      int max = 1000000;
                                      int ctr = 0;
                                      for (ctr = 0; ctr <= max; ctr++) {
                                         if (ctr == max / 2 && DateTime.Now.Hour <= 12) {
                                            ctr++;
                                            break;
                                         }
                                      }
                                      return ctr;
                                    } );
            Console.WriteLine("Finished {0:N0} iterations.", t.Result);
        }
    }
}