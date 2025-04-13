using System;
using System.Collections.Generic;
/**
Represents a variable size last-in-first-out (LIFO) collection of instances of the same specified type.

    public class Stack<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IReadOnlyCollection<T>, System.Collections.ICollection

Stack<T> is implemented as an array.

Stacks and queues are useful when you need temporary storage for information; that is, when you might want to discard an element after retrieving its value.

A common use for System.Collections.Generic.Stack<T> is to preserve variable states during calls to other procedures.

Three main operations can be performed on a System.Collections.Generic.Stack<T> and its elements:
    Push inserts an element at the top of the Stack<T>.
    Pop removes an element from the top of the Stack<T>.
    Peek returns an element that is at the top of the Stack<T> but does not remove it from the Stack<T>.

The capacity of a Stack<T> is the number of elements the Stack<T> can hold. As elements are added to a Stack<T>, the capacity is automatically increased as required by reallocating the internal array. The capacity can be decreased by calling TrimExcess.

If Count is less than the capacity of the stack, Push is an O(1) operation. If the capacity needs to be increased to accommodate the new element, Push becomes an O(n) operation, where n is Count. Pop is an O(1) operation.

Stack<T> accepts null as a valid value for reference types and allows duplicate elements.

Properties:
----------
Capacity - Gets the total numbers of elements the internal data structure can hold without resizing.
Count - Gets the number of elements contained in the Stack<T>.

Methods:
---------
Clear()	- Removes all objects from the Stack<T>.
    Count is set to zero, and references to other objects from elements of the collection are also released.
    The capacity remains unchanged. To reset the capacity of the Stack<T>, call TrimExcess. Trimming an empty Stack<T> sets the capacity of the Stack<T> to the default capacity.
    This method is an O(n) operation, where n is Count.

Contains(T)	- Determines whether an element is in the Stack<T>.
    This method determines equality using the default equality comparer EqualityComparer<T>.Default for T, the type of values in the list.
    This method performs a linear search; therefore, this method is an O(n) operation, where n is Count.

CopyTo(T[], Int32)	- Copies the Stack<T> to an existing one-dimensional Array, starting at the specified array index.
EnsureCapacity(Int32)	- Ensures that the capacity of this Stack is at least the specified capacity. If the current capacity is less than capacity, it is increased to at least the specified capacity.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator for the Stack<T>.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
Peek() - Returns the object at the top of the Stack<T> without removing it.
    This method is an O(1) operation.

Pop() - emoves and returns the object at the top of the Stack<T>.
    Stack<T> is implemented as an array. This method is an O(1) operation.
    
Push(T)	- Inserts an object at the top of the Stack<T>.
    If Count is less than the capacity of the stack, Push is an O(1) operation. If the capacity needs to be increased to accommodate the new element, Push becomes an O(n) operation, where n is Count.

ToArray()	- Copies the Stack<T> to a new array.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TrimExcess() - Sets the capacity to the actual number of elements in the Stack<T>, if that number is less than 90 percent of current capacity.
TrimExcess(Int32)	- Sets the capacity of a Stack<T> object to a specified number of entries.
TryPeek(T)	- Returns a value that indicates whether there is an object at the top of the Stack<T>, and if one is present, copies it to the result parameter. The object is not removed from the Stack<T>.
TryPop(T)	- Returns a value that indicates whether there is an object at the top of the Stack<T>, and if one is present, copies it to the result parameter, and removes it from the Stack<T>.



**/
namespace StackNamespaceGeneric{
    class StackClassGeneric{
        public static void Main(){
            Console.WriteLine("Stack Collection.");
            Stack<string> numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");

            // A stack can be enumerated without disturbing its contents.
            foreach( string number in numbers )
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nPopping '{0}'", numbers.Pop());
            Console.WriteLine("Peek at next item to destack: {0}",
                numbers.Peek());
            Console.WriteLine("Popping '{0}'", numbers.Pop());

            // Create a copy of the stack, using the ToArray method and the
            // constructor that accepts an IEnumerable<T>.
            Stack<string> stack2 = new Stack<string>(numbers.ToArray());

            Console.WriteLine("\nContents of the first copy:");
            foreach( string number in stack2 )
            {
                Console.WriteLine(number);
            }

            // Create an array twice the size of the stack and copy the
            // elements of the stack, starting at the middle of the
            // array.
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Create a second stack, using the constructor that accepts an
            // IEnumerable(Of T).
            Stack<string> stack3 = new Stack<string>(array2);

            Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach( string number in stack3 )
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nstack2.Contains(\"four\") = {0}",
                stack2.Contains("four"));

            Console.WriteLine("\nstack2.Clear()");
            stack2.Clear();
            Console.WriteLine("\nstack2.Count = {0}", stack2.Count);
            
        }
    }
}

/* This code example produces the following output:

five
four
three
two
one

Popping 'five'
Peek at next item to destack: four
Popping 'four'

Contents of the first copy:
one
two
three

Contents of the second copy, with duplicates and nulls:
one
two
three




stack2.Contains("four") = False

stack2.Clear()

stack2.Count = 0
 */