using System;
using System.Collections;

/**

The ArrayList class in C# is a part of the System.Collections namespace and provides a dynamic array that can hold elements of any type. Unlike arrays in C#, ArrayList can automatically resize itself as elements are added or removed.

Implements the IList interface using an array whose size is dynamically increased as required.

Elements in this collection can be accessed using an integer index. Indexes in this collection are zero-based.

The ArrayList collection accepts null as a valid value. It also allows duplicate elements.

Using multidimensional arrays as elements in an ArrayList collection is not supported.

.NET Framework only: For very large ArrayList objects, you can increase the maximum capacity to 2 billion elements on a 64-bit system by setting the enabled attribute of the <gcAllowVeryLargeObjects> configuration element to true in the run-time environment.

The capacity of an ArrayList is the number of elements the ArrayList can hold. As elements are added to an ArrayList, the capacity is automatically increased as required through reallocation. The capacity can be decreased by calling TrimToSize or by setting the Capacity property explicitly.

Constructors:
-------------
ArrayList()	- Initializes a new instance of the ArrayList class that is empty and has the default initial capacity.
ArrayList(ICollection)	- Initializes a new instance of the ArrayList class that contains elements copied from the specified collection and that has the same initial capacity as the number of elements copied.
ArrayList(Int32) - Initializes a new instance of the ArrayList class that is empty and has the specified initial capacity.

Properties:
------------
Capacity - Gets or sets the number of elements that the ArrayList can contain.
    public virtual int Capacity { get; set; }
    Capacity is the number of elements that the ArrayList can store. Count is the number of elements that are actually in the ArrayList.

    Capacity is always greater than or equal to Count. If Count exceeds Capacity while adding elements, the capacity is automatically increased by reallocating the internal array before copying the old elements and adding the new elements.

    The capacity can be decreased by calling TrimToSize or by setting the Capacity property explicitly. When the value of Capacity is set explicitly, the internal array is also reallocated to accommodate the specified capacity.

    Retrieving the value of this property is an O(1) operation; setting the property is an O(n) operation, where n is the new capacity.

Count	- Gets the number of elements actually contained in the ArrayList.
    public virtual int Count { get; }

IsFixedSize	- Gets a value indicating whether the ArrayList has a fixed size.
IsReadOnly	- Gets a value indicating whether the ArrayList is read-only.
IsSynchronized	- Gets a value indicating whether access to the ArrayList is synchronized (thread safe).
Item[Int32]	- Gets or sets the element at the specified index.
SyncRoot- Gets an object that can be used to synchronize access to the ArrayList.


Methods:
----------
Adapter(IList)	- Creates an ArrayList wrapper for a specific IList.
Add(Object)	- Adds an object to the end of the ArrayList.
AddRange(ICollection)	- Adds the elements of an ICollection to the end of the ArrayList.
BinarySearch(Int32, Int32, Object, IComparer)	- Searches a range of elements in the sorted ArrayList for an element using the specified comparer and returns the zero-based index of the element.
BinarySearch(Object, IComparer)	- Searches the entire sorted ArrayList for an element using the specified comparer and returns the zero-based index of the element.
BinarySearch(Object)	- Searches the entire sorted ArrayList for an element using the default comparer and returns the zero-based index of the element.
Clear()	- Removes all elements from the ArrayList.
Clone()	- Creates a shallow copy of the ArrayList.
Contains(Object)	- Determines whether an element is in the ArrayList.
CopyTo(Array, Int32)	- Copies the entire ArrayList to a compatible one-dimensional Array, starting at the specified index of the target array.
CopyTo(Array)	- Copies the entire ArrayList to a compatible one-dimensional Array, starting at the beginning of the target array.
CopyTo(Int32, Array, Int32, Int32)	- Copies a range of elements from the ArrayList to a compatible one-dimensional Array, starting at the specified index of the target array.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
FixedSize(ArrayList)	- Returns an ArrayList wrapper with a fixed size.
FixedSize(IList)	- Returns an IList wrapper with a fixed size.
GetEnumerator()	- Returns an enumerator for the entire ArrayList.
GetEnumerator(Int32, Int32)	- Returns an enumerator for a range of elements in the ArrayList.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetRange(Int32, Int32)	-Returns an ArrayList that represents a subset of the elements in the source ArrayList.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
IndexOf(Object, Int32, Int32)	- Searches for the specified Object and returns the zero-based index of the first occurrence within the range of elements in the ArrayList that starts at the specified index and contains the specified number of elements.
IndexOf(Object, Int32)	- Searches for the specified Object and returns the zero-based index of the first occurrence within the range of elements in the ArrayList that extends from the specified index to the last element.
IndexOf(Object)	- Searches for the specified Object and returns the zero-based index of the first occurrence within the entire ArrayList.
Insert(Int32, Object)	- Inserts an element into the ArrayList at the specified index.
InsertRange(Int32, ICollection)	- Inserts the elements of a collection into the ArrayList at the specified index.
LastIndexOf(Object, Int32, Int32)	- Searches for the specified Object and returns the zero-based index of the last occurrence within the range of elements in the ArrayList that contains the specified number of elements and ends at the specified index.
LastIndexOf(Object, Int32)	- Searches for the specified Object and returns the zero-based index of the last occurrence within the range of elements in the ArrayList that extends from the first element to the specified index.
LastIndexOf(Object)	- Searches for the specified Object and returns the zero-based index of the last occurrence within the entire ArrayList.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ReadOnly(ArrayList)	- Returns a read-only ArrayList wrapper.
ReadOnly(IList)	- Returns a read-only IList wrapper.
Remove(Object)	- Removes the first occurrence of a specific object from the ArrayList.
RemoveAt(Int32)	- Removes the element at the specified index of the ArrayList.
RemoveRange(Int32, Int32)	- Removes a range of elements from the ArrayList.
Repeat(Object, Int32)	- Returns an ArrayList whose elements are copies of the specified value.
Reverse()	- Reverses the order of the elements in the entire ArrayList. - 
Reverse(Int32, Int32)	- Reverses the order of the elements in the specified range.
SetRange(Int32, ICollection)	- Copies the elements of a collection over a range of elements in the ArrayList.
Sort()	-Sorts the elements in the entire ArrayList.
Sort(IComparer)	-Sorts the elements in the entire ArrayList using the specified comparer.
Sort(Int32, Int32, IComparer)	- Sorts the elements in a range of elements in ArrayList using the specified comparer.
Synchronized(ArrayList)	- Returns an ArrayList wrapper that is synchronized (thread safe).
Synchronized(IList)	- Returns an IList wrapper that is synchronized (thread safe).
ToArray()	- Copies the elements of the ArrayList to a new Object array.
ToArray(Type)	- Copies the elements of the ArrayList to a new array of the specified element type.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TrimToSize()	- Sets the capacity to the actual number of elements in the ArrayList.


**/
namespace ArrayListCollection{
    class ArrayListClass{
        public static void Main(){
            Console.WriteLine("Array List Collection...");
            // Creates and initializes a new ArrayList.
            ArrayList myAL = new ArrayList();
            myAL.Add("Hello");
            myAL.Add("World");
            myAL.Add("!");

            // Displays the properties and values of the ArrayList.
            Console.WriteLine( "myAL" );
            Console.WriteLine( "    Count:    {0}", myAL.Count );
            Console.WriteLine( "    Capacity: {0}", myAL.Capacity );
            Console.Write( "    Values:" );
            PrintValues( myAL );

            ArrayList test = new ArrayList();
            Console.WriteLine("Empty ArrayList , Count :"+test.Count+" Capacity :"+ test.Capacity);
            test.Add(10);
            Console.WriteLine("one Added ArrayList , Count :"+test.Count+" Capacity :"+ test.Capacity);
            test.Add(2);
            Console.WriteLine("Two ArrayList , Count :"+test.Count+" Capacity :"+ test.Capacity);
            test.Add(3);
            test.Add(4);
            Console.WriteLine("Four ArrayList , Count :"+test.Count+" Capacity :"+ test.Capacity);
            test.Add(5);
            Console.WriteLine("Five ArrayList , Count :"+test.Count+" Capacity :"+ test.Capacity);
        }

        public static void PrintValues( IEnumerable myList )  {
            foreach ( Object obj in myList )
                Console.Write( "   {0}", obj );
            Console.WriteLine();
        }
    }
}