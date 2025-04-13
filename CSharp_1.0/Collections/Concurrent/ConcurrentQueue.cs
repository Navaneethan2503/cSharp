using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
/**
Properties:
-----------
Count	- Gets the number of elements contained in the ConcurrentQueue<T>.
IsEmpty	- Gets a value that indicates whether the ConcurrentQueue<T> is empty.

Methods:
--------
Clear()	- Removes all objects from the ConcurrentQueue<T>.
CopyTo(T[], Int32)	- Copies the ConcurrentQueue<T> elements to an existing one-dimensional Array, starting at the specified array index.
Enqueue(T)	- Adds an object to the end of the ConcurrentQueue<T>.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator that iterates through the ConcurrentQueue<T>.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
ToArray() -  Copies the elements stored in the ConcurrentQueue<T> to a new array.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryDequeue(T) - Tries to remove and return the object at the beginning of the concurrent queue.
    ConcurrentQueue<T> handles all synchronization internally. If two threads call TryDequeue at precisely the same moment, neither operation is blocked. When a conflict is detected between two threads, one thread has to try again to retrieve the next element, and the synchronization is handled internally.
    TryDequeue tries to remove an element from the queue. If the method is successful, the item is removed and the method returns true; otherwise, it returns false. That happens atomically with respect to other operations on the queue. If the queue was populated with code such as q.Enqueue("a"); q.Enqueue("b"); q.Enqueue("c"); and two threads concurrently try to dequeue an element, one thread will dequeue a and the other thread will dequeue b. Both calls to TryDequeue will return true, because they were both able to dequeue an element. If each thread goes back to dequeue an additional element, one of the threads will dequeue c and return true, whereas the other thread will find the queue empty and will return false.

TryPeek(T)	- Tries to return an object from the beginning of the ConcurrentQueue<T> without removing it.


**/
namespace ConcurrentCollections{
    class ConcurrentQueueClass{
        public static void Main(){
            Console.WriteLine("Concurrent Queue Collection.");
            // Construct a ConcurrentQueue.
            ConcurrentQueue<int> cq = new ConcurrentQueue<int>();

            // Populate the queue.
            for (int i = 0; i < 10000; i++)
            {
                cq.Enqueue(i);
            }

            // Peek at the first element.
            int result;
            if (!cq.TryPeek(out result))
            {
                Console.WriteLine("CQ: TryPeek failed when it should have succeeded");
            }
            else if (result != 0)
            {
                Console.WriteLine("CQ: Expected TryPeek result of 0, got {0}", result);
            }

            int outerSum = 0;
            // An action to consume the ConcurrentQueue.
            Action action = () =>
            {
                int localSum = 0;
                int localValue;
                while (cq.TryDequeue(out localValue)) localSum += localValue;
                Interlocked.Add(ref outerSum, localSum);
            };

            // Start 4 concurrent consuming actions.
            Parallel.Invoke(action, action, action, action);

            Console.WriteLine("outerSum = {0}, should be 49995000", outerSum);
        }
    }
}