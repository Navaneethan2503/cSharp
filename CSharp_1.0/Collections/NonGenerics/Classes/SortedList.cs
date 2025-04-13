using System;
using System.Collections;
/**
Represents a collection of key/value pairs that are sorted by the keys and are accessible by key and by index.
    public class SortedList : ICloneable, System.Collections.IDictionary

A SortedList element can be accessed by its key, like an element in any IDictionary implementation, or by its index, like an element in any IList implementation.

A SortedList element can be accessed by its key, like an element in any IDictionary implementation, or by its index, like an element in any IList implementation.

A SortedList object internally maintains two arrays to store the elements of the list; that is, one array for the keys and another array for the associated values. Each element is a key/value pair that can be accessed as a DictionaryEntry object. A key cannot be null, but a value can be.

The capacity of a SortedList object is the number of elements the SortedList can hold. As elements are added to a SortedList, the capacity is automatically increased as required through reallocation. The capacity can be decreased by calling TrimToSize or by setting the Capacity property explicitly.

.NET Framework only: For very large SortedList objects, you can increase the maximum capacity to 2 billion elements on a 64-bit system by setting the enabled attribute of the <gcAllowVeryLargeObjects> configuration element to true in the run-time environment.

The elements of a SortedList object are sorted by the keys either according to a specific IComparer implementation specified when the SortedList is created or according to the IComparable implementation provided by the keys themselves. In either case, a SortedList does not allow duplicate keys.

The index sequence is based on the sort sequence. When an element is added, it is inserted into SortedList in the correct sort order, and the indexing adjusts accordingly. When an element is removed, the indexing also adjusts accordingly. Therefore, the index of a specific key/value pair might change as elements are added or removed from the SortedList object.

Operations on a SortedList object tend to be slower than operations on a Hashtable object because of the sorting. However, the SortedList offers more flexibility by allowing access to the values either through the associated keys or through the indexes.

Elements in this collection can be accessed using an integer index. Indexes in this collection are zero-based.

The foreach statement of the C# language (for each in Visual Basic) returns an object of the type of the elements in the collection. Since each element of the SortedList object is a key/value pair, the element type is not the type of the key or the type of the value. Rather, the element type is DictionaryEntry. 

The foreach statement is a wrapper around the enumerator, which allows only reading from, not writing to, the collection.

Properties:
-----------
Capacity - Gets or sets the capacity of a SortedList object.
Count	 - Gets the number of elements contained in a SortedList object.
IsFixedSize	- Gets a value indicating whether a SortedList object has a fixed size.
IsReadOnly	- Gets a value indicating whether a SortedList object is read-only.
IsSynchronized	- Gets a value indicating whether access to a SortedList object is synchronized (thread safe).
Item[Object]	- Gets or sets the value associated with a specific key in a SortedList object.
Keys	- Gets the keys in a SortedList object.
SyncRoot	- Gets an object that can be used to synchronize access to a SortedList object.
Values	- Gets the values in a SortedList object.

Methods:
---------
Add(Object, Object)	- Adds an element with the specified key and value to a SortedList object.
    The insertion point is determined based on the comparer selected, either explicitly or by default, when the SortedList object was created.
    If Count already equals Capacity, the capacity of the SortedList object is increased by automatically reallocating the internal array, and the existing elements are copied to the new array before the new element is added.
    You can also use the Item[] property to add new elements by setting the value of a key that does not exist in the SortedList object (for example, myCollection["myNonexistentKey"] = myValue). However, if the specified key already exists in the SortedList, setting the Item[] property overwrites the old value. In contrast, the Add method does not modify existing elements.
    The elements of a SortedList object are sorted by the keys either according to a specific IComparer implementation specified when the SortedList is created or according to the IComparable implementation provided by the keys themselves.
    A key cannot be null, but a value can be.
    This method is an O(n) operation for unsorted data, where n is Count. It is an O(log n) operation if the new element is added at the end of the list. If insertion causes a resize, the operation is O(n).

Clear()	- Removes all elements from a SortedList object.
Clone()	- Creates a shallow copy of a SortedList object.
Contains(Object)	- Determines whether a SortedList object contains a specific key.This method uses a binary search algorithm; therefore, this method is an O(log n) operation, where n is Count.
    This method uses a binary search algorithm; therefore, this method is an O(log n) operation, where n is Count.
    
ContainsKey(Object)	- Determines whether a SortedList object contains a specific key.
ContainsValue(Object)	- Determines whether a SortedList object contains a specific value.
CopyTo(Array, Int32)	- Copies SortedList elements to a one-dimensional Array object, starting at the specified index in the array.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetByIndex(Int32)	- Gets the value at the specified index of a SortedList object.
GetEnumerator()	- Returns an IDictionaryEnumerator object that iterates through a SortedList object.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetKey(Int32)	- Gets the key at the specified index of a SortedList object.
GetKeyList()	- Gets the keys in a SortedList object.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
GetValueList()	- Gets the values in a SortedList object.
IndexOfKey(Object)	- Returns the zero-based index of the specified key in a SortedList object.
IndexOfValue(Object)	- Returns the zero-based index of the first occurrence of the specified value in a SortedList object.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Remove(Object)	- Removes the element with the specified key from a SortedList object.
RemoveAt(Int32)	- Removes the element at the specified index of a SortedList object.
SetByIndex(Int32, Object)	- Replaces the value at a specific index in a SortedList object.
Synchronized(SortedList)	- Returns a synchronized (thread-safe) wrapper for a SortedList object.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TrimToSize() - Sets the capacity to the actual number of elements in a SortedList object.


**/
namespace SortedListNamespace{
    class SortedListClass{
        public static void Main(){
            Console.WriteLine("Sorted List Collections ....");
            SortedList test = new SortedList();
            test.Add(10,"First");
            test.Add(1,"Second");
            test.Add(20,"Third");
            test.Add(4,"Four");
            foreach(int i in test.Keys){
                Console.Write(i+",");
            }

            // Creates and initializes a new SortedList.
            SortedList mySL = new SortedList();
            mySL.Add( "one", "The" );
            mySL.Add( "two", "quick" );
            mySL.Add( "three", "brown" );
            mySL.Add( "four", "fox" );

            // Displays the SortedList.
            // Displays the properties and values of the SortedList.
            Console.WriteLine("mySL");
            Console.WriteLine("  Count:    {0}", mySL.Count);
            Console.WriteLine("  Capacity: {0}", mySL.Capacity);
            Console.WriteLine( "The SortedList contains the following:" );
            PrintKeysAndValues( mySL );
        }

        public static void PrintKeysAndValues( SortedList myList )  {
            Console.WriteLine( "\t-KEY-\t-VALUE-" );
            for ( int i = 0; i < myList.Count; i++ )  {
                Console.WriteLine( "\t{0}:\t{1}", myList.GetKey(i), myList.GetByIndex(i) );
            }
            Console.WriteLine();
        }
    }
}