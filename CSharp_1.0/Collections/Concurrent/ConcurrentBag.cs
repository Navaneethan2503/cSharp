using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
/**

Represents a thread-safe, unordered collection of objects.


Properties:
---------
Count -Gets the number of elements contained in the ConcurrentBag<T>.
IsEmpty	- Gets a value that indicates whether the ConcurrentBag<T> is empty.

Methods:
--------
Add(T)- Adds an object to the ConcurrentBag<T>.
Clear()	- Removes all values from the ConcurrentBag<T>.
CopyTo(T[], Int32)	- Copies the ConcurrentBag<T> elements to an existing one-dimensional Array, starting at the specified array index.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator that iterates through the ConcurrentBag<T>.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
ToArray() - Copies the ConcurrentBag<T> elements to a new array.
ToString()	-  Returns a string that represents the current object.(Inherited from Object)
TryPeek(T) - Attempts to return an object from the ConcurrentBag<T> without removing it.
TryTake(T)	- Attempts to remove and return an object from the ConcurrentBag<T>.

**/
namespace ConcurrentCollections{
    class ConcurrentBagDemo
    {
        // Demonstrates:
        //      ConcurrentBag<T>.Add()
        //      ConcurrentBag<T>.IsEmpty
        //      ConcurrentBag<T>.TryTake()
        //      ConcurrentBag<T>.TryPeek()
        static void Main()
        {
            // Add to ConcurrentBag concurrently
            ConcurrentBag<int> cb = new ConcurrentBag<int>();
            List<Task> bagAddTasks = new List<Task>();
            for (int i = 0; i < 500; i++)
            {
                var numberToAdd = i;
                bagAddTasks.Add(Task.Run(() => cb.Add(numberToAdd)));
            }

            // Wait for all tasks to complete
            Task.WaitAll(bagAddTasks.ToArray());

            // Consume the items in the bag
            List<Task> bagConsumeTasks = new List<Task>();
            int itemsInBag = 0;
            while (!cb.IsEmpty)
            {
                bagConsumeTasks.Add(Task.Run(() =>
                {
                    int item;
                    if (cb.TryTake(out item))
                    {
                        Console.WriteLine(item);
                        Interlocked.Increment(ref itemsInBag);
                    }
                }));
            }
            Task.WaitAll(bagConsumeTasks.ToArray());

            Console.WriteLine($"There were {itemsInBag} items in the bag");

            // Checks the bag for an item
            // The bag should be empty and this should not print anything
            int unexpectedItem;
            if (cb.TryPeek(out unexpectedItem))
                Console.WriteLine("Found an item in the bag when it should be empty");
        }
    }
}