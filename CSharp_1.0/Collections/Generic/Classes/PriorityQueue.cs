using System;
using System.Collections.Generic;
/**
Represents a collection of items that have a value and a priority. On dequeue, the item with the lowest priority value is removed.

public class PriorityQueue<TElement,TPriority>

Implements an array-backed, quaternary min-heap. 
Each element is enqueued with an associated priority that determines the dequeue order. 
Elements with the lowest priority are dequeued first. 
Note that the type does not guarantee first-in-first-out semantics for elements of equal priority.

The PriorityQueue<TElement, TPriority> class in C# is a part of the System.Collections.Generic namespace and is designed to manage a collection of elements that are prioritized based on their associated priority values. This class is particularly useful for scenarios where elements need to be processed in order of their priority, such as task scheduling, pathfinding algorithms, and event handling.

Key Features:
--------------
Priority-Based Ordering: Elements are dequeued in order of their priority, with the element having the highest priority being dequeued first.
Generic Types: The class is generic, allowing you to specify the types of the elements (TElement) and their priority values (TPriority).
Efficient Operations: Provides efficient insertion and removal operations based on priority, typically implemented using a heap data structure.


Properties:
-----------
Comparer - Gets the priority comparer used by the PriorityQueue<TElement,TPriority>.
Count - Gets the number of elements contained in the PriorityQueue<TElement,TPriority>.
UnorderedItems - Gets a collection that enumerates the elements of the queue in an unordered manner.
    The PriorityQueue<TElement, TPriority> class in C# includes a property called UnorderedItems. This property provides access to the elements in the priority queue without considering their priority order. This can be useful for scenarios where you need to inspect all elements in the queue without dequeuing them or when the order of elements is not important for a specific operation.


Methods:
---------
Clear()	- Removes all items from the PriorityQueue<TElement,TPriority>.
Dequeue() - Removes and returns the minimal element from the PriorityQueue<TElement,TPriority> - that is, the element with the lowest priority value.
DequeueEnqueue(TElement, TPriority)	- Removes the minimal element and then immediately adds the specified element with associated priority to the PriorityQueue<TElement,TPriority>.
Enqueue(TElement, TPriority) - Adds the specified element with associated priority to the PriorityQueue<TElement,TPriority>.
EnqueueDequeue(TElement, TPriority)	- Adds the specified element with associated priority to the PriorityQueue<TElement,TPriority>, and immediately removes the minimal element, returning the result.
EnqueueRange(IEnumerable<TElement>, TPriority)	- Enqueues a sequence of elements pairs to the PriorityQueue<TElement,TPriority>, all associated with the specified priority.
EnqueueRange(IEnumerable<ValueTuple<TElement,TPriority>>) - Enqueues a sequence of element-priority pairs to the PriorityQueue<TElement,TPriority>.
EnsureCapacity(Int32)	-  Ensures that the PriorityQueue<TElement,TPriority> can hold up to capacity items without further expansion of its backing storage.
Equals(Object)- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode() - Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
Peek() - Returns the minimal element from the PriorityQueue<TElement,TPriority> without removing it.
Remove(TElement, TElement, TPriority, IEqualityComparer<TElement>)	 - Removes the first occurrence that equals the specified parameter.
ToString() - Returns a string that represents the current object.(Inherited from Object)
TrimExcess() - Sets the capacity to the actual number of items in the PriorityQueue<TElement,TPriority>, if that is less than 90 percent of current capacity.
TryDequeue(TElement, TPriority)	- Removes the minimal element from the PriorityQueue<TElement,TPriority>, and copies it and its associated priority to the element and priority arguments.
TryPeek(TElement, TPriority - Returns a value that indicates whether there is a minimal element in the PriorityQueue<TElement,TPriority>, and if one is present, copies it and its associated priority to the element and priority arguments. The element is not removed from the PriorityQueue<TElement,TPriority>.




**/
namespace PriorityQueueNamespace{
    class PriorityQueueClass{
        public static void Main(){
            Console.WriteLine("Priority Queue...");
            PriorityQueue<int,int> test = new PriorityQueue<int,int>();
            test.Enqueue(10,5);
            test.Enqueue(8,10);
            Console.WriteLine("Count :"+ test.Count );
            Print(test.UnorderedItems);
            test.Enqueue(3,1);
            test.Enqueue(4,2);
            test.Enqueue(7,9);
            Print(test.UnorderedItems);
            Console.WriteLine("Dequeue is :"+test.Dequeue());
        }

        public static void Print(PriorityQueue<int,int>.UnorderedItemsCollection ex){
            foreach((int Element, int Priority) i in ex){
                Console.WriteLine("Element is : "+i.Element+ " Priority : "+ i.Priority + ",");
            }
        }

    }
}