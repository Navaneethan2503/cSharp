using System;
using System.Collections;
/**
Represents a first-in, first-out collection of objects.
    ICollection
This class implements a queue as a circular array. Objects stored in a Queue are inserted at one end and removed from the other.

Queues and stacks are useful when you need temporary storage for information; that is, when you might want to discard an element after retrieving its value. Use Queue if you need to access the information in the same order that it is stored in the collection. Use Stack if you need to access the information in reverse order. Use ConcurrentQueue<T> or ConcurrentStack<T> if you need to access the collection from multiple threads concurrently.

The capacity of a Queue is the number of elements the Queue can hold. As elements are added to a Queue, the capacity is automatically increased as required through reallocation. The capacity can be decreased by calling TrimToSize.

The growth factor is the number by which the current capacity is multiplied when a greater capacity is required. The growth factor is determined when the Queue is constructed. The default growth factor is 2.0. The capacity of the Queue will always increase by at least a minimum of four, regardless of the growth factor. For example, a Queue with a growth factor of 1.0 will always increase in capacity by four when a greater capacity is required.

Queue accepts null as a valid value and allows duplicate elements.

Properties:
----------
Count	- Gets the number of elements contained in the Queue.
    The capacity of a Queue is the number of elements that the Queue can store. Count is the number of elements that are actually in the Queue.
    The capacity of a Queue is always greater than or equal to Count. If Count exceeds the capacity while adding elements, the capacity is automatically increased by reallocating the internal array before copying the old elements and adding the new elements. The new capacity is determined by multiplying the current capacity by the growth factor, which is determined when the Queue is constructed. The capacity of the Queue will always increase by a minimum value, regardless of the growth factor; a growth factor of 1.0 will not prevent the Queue from increasing in size.
    The capacity can be decreased by calling TrimToSize.
    Retrieving the value of this property is an O(1) operation.

IsSynchronized	- Gets a value indicating whether access to the Queue is synchronized (thread safe).
SyncRoot	- Gets an object that can be used to synchronize access to the Queue.

Methods:
--------
Clear() - Removes all objects from the Queue.
Clone()	- Creates a shallow copy of the Queue.
Contains(Object)	- Determines whether an element is in the Queue.
    This method performs a linear search; therefore, this method is an O(n) operation, where n is Count.

CopyTo(Array, Int32)	- Copies the Queue elements to an existing one-dimensional Array, starting at the specified array index.
Dequeue()	- Removes and returns the object at the beginning of the Queue.
Enqueue(Object)	- Adds an object to the end of the Queue.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator that iterates through the Queue.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Peek() - Returns the object at the beginning of the Queue without removing it.
Synchronized(Queue)	 - Returns a new Queue that wraps the original queue, and is thread safe.
ToArray()	 - Copies the Queue elements to a new array.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TrimToSize() - Sets the capacity to the actual number of elements in the Queue.


**/
namespace QueueNamespace{
    class QueueClass{
        public static void Main(){
            Console.WriteLine("Queue Collections!!!");
            Queue test = new Queue(5,2.0f);
            Console.WriteLine("Count :"+test.Count);

            // Creates and initializes a new Queue.
            Queue myQ = new Queue();
            myQ.Enqueue( "The" );
            myQ.Enqueue( "quick" );
            myQ.Enqueue( "brown" );
            myQ.Enqueue( "fox" );

            // Displays the Queue.
            Console.Write( "Queue values:" );
            PrintValues( myQ );

            // Removes an element from the Queue.
            Console.WriteLine( "(Dequeue)\t{0}", myQ.Dequeue() );

            // Displays the Queue.
            Console.Write( "Queue values:" );
            PrintValues( myQ );

            // Removes another element from the Queue.
            Console.WriteLine( "(Dequeue)\t{0}", myQ.Dequeue() );

            // Displays the Queue.
            Console.Write( "Queue values:" );
            PrintValues( myQ );

            // Views the first element in the Queue but does not remove it.
            Console.WriteLine( "(Peek)   \t{0}", myQ.Peek() );

            // Displays the Queue.
            Console.Write( "Queue values:" );
            PrintValues( myQ );


        }

        public static void PrintValues( IEnumerable myCollection )  {
            foreach ( Object obj in myCollection )
                Console.Write( "    {0}", obj );
            Console.WriteLine();
        }
    }
}