using System;
using System.Collections.Generic;
/**
Represents a first-in, first-out collection of objects.

public class Queue<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IReadOnlyCollection<T>, System.Collections.ICollection

This class implements a generic queue as a circular array. Objects stored in a Queue<T> are inserted at one end and removed from the other. Queues and stacks are useful when you need temporary storage for information; that is, when you might want to discard an element after retrieving its value. Use Queue<T> if you need to access the information in the same order that it is stored in the collection. Use Stack<T> if you need to access the information in reverse order. Use ConcurrentQueue<T> or ConcurrentStack<T> if you need to access the collection from multiple threads concurrently.

Three main operations can be performed on a Queue<T> and its elements:

Enqueue adds an element to the end of the Queue<T>.

Dequeue removes the oldest element from the start of the Queue<T>.

Peek peek returns the oldest element that is at the start of the Queue<T> but does not remove it from the Queue<T>.

The capacity of a Queue<T> is the number of elements the Queue<T> can hold. As elements are added to a Queue<T>, the capacity is automatically increased as required by reallocating the internal array. The capacity can be decreased by calling TrimExcess.

Queue<T> accepts null as a valid value for reference types and allows duplicate elements.

Properties:
-----------
Capacity - Gets the total numbers of elements the internal data structure can hold without resizing.
Count - Gets the number of elements contained in the Queue<T>.

Methods:
----------
Clear()	- Removes all objects from the Queue<T>.
    Count is set to zero, and references to other objects from elements of the collection are also released.
    The capacity remains unchanged. To reset the capacity of the Queue<T>, call TrimExcess. Trimming an empty Queue<T> sets the capacity of the Queue<T> to the default capacity.
    This method is an O(n) operation, where n is Count.

Contains(T)	- Determines whether an element is in the Queue<T>.
    This method determines equality using the default equality comparer EqualityComparer<T>.Default for T, the type of values in the queue.
    This method performs a linear search; therefore, this method is an O(n) operation, where n is Count.

CopyTo(T[], Int32)	- Copies the Queue<T> elements to an existing one-dimensional Array, starting at the specified array index.
Dequeue()	- Removes and returns the object at the beginning of the Queue<T>.
    This method is an O(1) operation.

Enqueue(T)	- Adds an object to the end of the Queue<T>.
    If Count is less than the capacity of the internal array, this method is an O(1) operation. If the internal array needs to be reallocated to accommodate the new element, this method becomes an O(n) operation, where n is Count.

EnsureCapacity(Int32)	- Ensures that the capacity of this queue is at least the specified capacity. If the current capacity is less than capacity, it is increased to at least the specified capacity.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	-Returns an enumerator that iterates through the Queue<T>.
GetHashCode() - Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
Peek() - Returns the object at the beginning of the Queue<T> without removing it.
    This method is an O(1) operation.

ToArray() - Copies the Queue<T> elements to a new array.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TrimExcess() - Sets the capacity to the actual number of elements in the Queue<T>, if that number is less than 90 percent of current capacity.
TrimExcess(Int32) - Sets the capacity of a Queue<T> object to the specified number of entries.
TryDequeue(T) - Removes the object at the beginning of the Queue<T>, and copies it to the result parameter.
TryPeek(T)	- Returns a value that indicates whether there is an object at the beginning of the Queue<T>, and if one is present, copies it to the result parameter. The object is not removed from the Queue<T>.


**/
namespace QueueNamespaceGeneric{
    class QueueClassGeneric{
        public static void Main(){
            Console.WriteLine("Queue Generic Collections");
            Queue<string> numbers = new Queue<string>();
            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");
            numbers.Enqueue("five");

            // A queue can be enumerated without disturbing its contents.
            foreach( string number in numbers )
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nDequeuing '{0}'", numbers.Dequeue());
            Console.WriteLine("Peek at next item to dequeue: {0}",
                numbers.Peek());
            Console.WriteLine("Dequeuing '{0}'", numbers.Dequeue());

            // Create a copy of the queue, using the ToArray method and the
            // constructor that accepts an IEnumerable<T>.
            Queue<string> queueCopy = new Queue<string>(numbers.ToArray());

            Console.WriteLine("\nContents of the first copy:");
            foreach( string number in queueCopy )
            {
                Console.WriteLine(number);
            }

            // Create an array twice the size of the queue and copy the
            // elements of the queue, starting at the middle of the
            // array.
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Create a second queue, using the constructor that accepts an
            // IEnumerable(Of T).
            Queue<string> queueCopy2 = new Queue<string>(array2);

            Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach( string number in queueCopy2 )
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nqueueCopy.Contains(\"four\") = {0}",
                queueCopy.Contains("four"));

            Console.WriteLine("\nqueueCopy.Clear()");
            queueCopy.Clear();
            Console.WriteLine("\nqueueCopy.Count = {0}", queueCopy.Count);

            Queue<int> test = new Queue<int>();
            Console.WriteLine("Capacity : "+ test.Capacity+ " Count :"+ test.Count);
            test.Enqueue(1);
            test.Enqueue(20);
            Console.WriteLine("Capacity : "+ test.Capacity+ " Count :"+ test.Count);
            test.Enqueue(1);
            test.Enqueue(20);
            Console.WriteLine("Capacity : "+ test.Capacity+ " Count :"+ test.Count);
            test.Enqueue(1);
            test.Enqueue(20);
            Console.WriteLine("Capacity : "+ test.Capacity+ " Count :"+ test.Count);

        }
    }
}



/* This code example produces the following output:

one
two
three
four
five

Dequeuing 'one'
Peek at next item to dequeue: two
Dequeuing 'two'

Contents of the first copy:
three
four
five

Contents of the second copy, with duplicates and nulls:



three
four
five

queueCopy.Contains("four") = True

queueCopy.Clear()

queueCopy.Count = 0
 */