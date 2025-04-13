using System;
using System.Collections;
/**
Represents a simple last-in-first-out (LIFO) non-generic collection of objects.
    public class Stack : ICloneable, System.Collections.ICollection

The capacity of a Stack is the number of elements the Stack can hold. As elements are added to a Stack, the capacity is automatically increased as required through reallocation.

If Count is less than the capacity of the stack, Push is an O(1) operation. If the capacity needs to be increased to accommodate the new element, Push becomes an O(n) operation, where n is Count. Pop is an O(1) operation.

Stack accepts null as a valid value and allows duplicate elements.

Properties:
--------------
Count - Gets the number of elements contained in the Stack.
IsSynchronized	- Gets a value indicating whether access to the Stack is synchronized (thread safe).
SyncRoot	- Gets an object that can be used to synchronize access to the Stack.

Methods:
---------
Clear()	- Removes all objects from the Stack.
Clone()	- Creates a shallow copy of the Stack.
Contains(Object) - Determines whether an element is in the Stack.
    O(n) - linear Search
CopyTo(Array, Int32) - Copies the Stack to an existing one-dimensional Array, starting at the specified array index.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an IEnumerator for the Stack.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() -Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Peek()	- Returns the object at the top of the Stack without removing it.
Pop()	- Removes and returns the object at the top of the Stack.
Push(Object)	- Inserts an object at the top of the Stack.
Synchronized(Stack)	- Returns a synchronized (thread safe) wrapper for the Stack.
ToArray()	- Copies the Stack to a new array.
ToString()	- Returns a string that represents the current object.(Inherited from Object)



**/
namespace StackNamespace{
    class StackClass{
        public static void Main(){
            Console.WriteLine("Stack Collection...");
            Stack test = new Stack();
            Console.WriteLine(test.Count);
            // Creates and initializes a new Stack.
            Stack myStack = new Stack();
            myStack.Push( "The" );
            myStack.Push( "quick" );
            myStack.Push( "brown" );
            myStack.Push( "fox" );

            // Displays the Stack.
            Console.Write( "Stack values:" );
            PrintValues( myStack, '\t' );

            // Removes an element from the Stack.
            Console.WriteLine( "(Pop)\t\t{0}", myStack.Pop() );

            // Displays the Stack.
            Console.Write( "Stack values:" );
            PrintValues( myStack, '\t' );

            // Removes another element from the Stack.
            Console.WriteLine( "(Pop)\t\t{0}", myStack.Pop() );

            // Displays the Stack.
            Console.Write( "Stack values:" );
            PrintValues( myStack, '\t' );

            // Views the first element in the Stack but does not remove it.
            Console.WriteLine( "(Peek)\t\t{0}", myStack.Peek() );

            // Displays the Stack.
            Console.Write( "Stack values:" );
            PrintValues( myStack, '\t' );

        }

        public static void PrintValues( IEnumerable myCollection, char mySeparator )  {
            foreach ( Object obj in myCollection )
                Console.Write( "{0}{1}", mySeparator, obj );
            Console.WriteLine();
        }


    }
}