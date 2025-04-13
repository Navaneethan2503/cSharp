using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

/**
Represents a thread-safe last in-first out (LIFO) collection.

ConcurrentStack<T> provides a few main operations:

Push inserts an element at the top of the ConcurrentStack<T>.

TryPop removes an element from the top of the ConcurrentStack<T>, or returns false if the item cannot be removed.

TryPeek returns an element that is at the top of the ConcurrentStack<T> but does not remove it from the ConcurrentStack<T>.

The TryPopRange and PushRange methods provide efficient pushing and popping of multiple elements in a single operation.

Properties:
--------------
Count - Gets the number of elements contained in the ConcurrentStack<T>.
IsEmpty	- Gets a value that indicates whether the ConcurrentStack<T> is empty.


Methods:
-------
Clear() - Removes all objects from the ConcurrentStack<T>.
CopyTo(T[], Int32)	- Copies the ConcurrentStack<T> elements to an existing one-dimensional Array, starting at the specified array index.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	 - Returns an enumerator that iterates through the ConcurrentStack<T>.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() -Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Push(T) - Inserts an object at the top of the ConcurrentStack<T>.
PushRange(T[], Int32, Int32) - Inserts multiple objects at the top of the ConcurrentStack<T> atomically.
PushRange(T[])	- Inserts multiple objects at the top of the ConcurrentStack<T> atomically.
ToArray()	- Copies the items stored in the ConcurrentStack<T> to a new array.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryPeek(T)	- Attempts to return an object from the top of the ConcurrentStack<T> without removing it.
TryPop(T)	- Attempts to pop and return the object at the top of the ConcurrentStack<T>.
TryPopRange(T[], Int32, Int32)	- Attempts to pop and return multiple objects from the top of the ConcurrentStack<T> atomically.
TryPopRange(T[])	- Attempts to pop and return multiple objects from the top of the ConcurrentStack<T> atomically.


**/
namespace ConcurrentCollections{
    class ConcurrentStackClass{
        public static async Task Main(){
            Console.WriteLine("Concurrent Stack Class .");
            int items = 10000;

            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            // Create an action to push items onto the stack
            Action pusher = () =>
            {
                for (int i = 0; i < items; i++)
                {
                    stack.Push(i);
                }
            };

            // Run the action once
            pusher();

            if (stack.TryPeek(out int result))
            {
                Console.WriteLine($"TryPeek() saw {result} on top of the stack.");
            }
            else
            {
                Console.WriteLine("Could not peek most recently added number.");
            }

            // Empty the stack
            stack.Clear();

            if (stack.IsEmpty)
            {
                Console.WriteLine("Cleared the stack.");
            }

            // Create an action to push and pop items
            Action pushAndPop = () =>
            {
                Console.WriteLine($"Task started on {Task.CurrentId}");

                int item;
                for (int i = 0; i < items; i++)
                    stack.Push(i);
                for (int i = 0; i < items; i++)
                    stack.TryPop(out item);

                Console.WriteLine($"Task ended on {Task.CurrentId}");
            };

            // Spin up five concurrent tasks of the action
            var tasks = new Task[5];
            for (int i = 0; i < tasks.Length; i++)
                tasks[i] = Task.Factory.StartNew(pushAndPop);

            // Wait for all the tasks to finish up
            await Task.WhenAll(tasks);

            if (!stack.IsEmpty)
            {
                Console.WriteLine("Did not take all the items off the stack");
            }

        }
    }
}