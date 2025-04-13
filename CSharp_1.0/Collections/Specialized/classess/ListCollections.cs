using System;
using System.Collections;
using System.Collections.Specialized;
/**
Implements IDictionary using a singly linked list. Recommended for collections that typically include fewer than 10 items.

This is a simple implementation of IDictionary using a singly linked list. It is smaller and faster than a Hashtable if the number of elements is 10 or less. This should not be used if performance is important for large numbers of elements.

Items in a ListDictionary are not in any guaranteed order; code should not depend on the current order. The ListDictionary is implemented for fast keyed retrieval; the actual internal order of items is implementation-dependent and could change in future versions of the product.

Members, such as Item[], Add, Remove, and Contains are O(n) operations, where n is Count.

A key cannot be null, but a value can.

The foreach statement of the C# language (for each in Visual Basic) returns an object of the type of the elements in the collection. Since each element of the ListDictionary is a key/value pair, the element type is not the type of the key or the type of the value. Instead, the element type is DictionaryEntry. 

The foreach statement is a wrapper around the enumerator, which only allows reading from, not writing to, the collection.

Properties:
-------------
Count- Gets the number of key/value pairs contained in the ListDictionary.
IsFixedSize	- Gets a value indicating whether the ListDictionary has a fixed size.
IsReadOnly	- Gets a value indicating whether the ListDictionary is read-only.
IsSynchronized	- Gets a value indicating whether the ListDictionary is synchronized (thread safe).
Item[Object]	- Gets or sets the value associated with the specified key.
Keys	- Gets an ICollection containing the keys in the ListDictionary.
SyncRoot	- Gets an object that can be used to synchronize access to the ListDictionary.
Values	- Gets an ICollection containing the values in the ListDictionary.


Methods:
----------
Add(Object, Object)	- Adds an entry with the specified key and value into the ListDictionary.
Clear()	- Removes all entries from the ListDictionary.
Contains(Object)	- Determines whether the ListDictionary contains a specific key.
CopyTo(Array, Int32) - Copies the ListDictionary entries to a one-dimensional Array instance at the specified index.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an IDictionaryEnumerator that iterates through the ListDictionary.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
Remove(Object) - Removes the entry with the specified key from the ListDictionary.
ToString()	- Returns a string that represents the current object.(Inherited from Object)

**/
namespace SpecializedCollections{
    class ListCollectionsClass{
        public static void Main(){
            Console.WriteLine("List Collections.");
            // Creates and initializes a new ListDictionary.
            ListDictionary myCol = new ListDictionary();
            myCol.Add( "Braeburn Apples", "1.49" );
            myCol.Add( "Fuji Apples", "1.29" );
            myCol.Add( "Gala Apples", "1.49" );
            myCol.Add( "Golden Delicious Apples", "1.29" );
            myCol.Add( "Granny Smith Apples", "0.89" );
            myCol.Add( "Red Delicious Apples", "0.99" );

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine( "Displays the elements using foreach:" );
            PrintKeysAndValues1( myCol );

            // Display the contents of the collection using the enumerator.
            Console.WriteLine( "Displays the elements using the IDictionaryEnumerator:" );
            PrintKeysAndValues2( myCol );

            // Display the contents of the collection using the Keys, Values, Count, and Item properties.
            Console.WriteLine( "Displays the elements using the Keys, Values, Count, and Item properties:" );
            PrintKeysAndValues3( myCol );

            // Copies the ListDictionary to an array with DictionaryEntry elements.
            DictionaryEntry[] myArr = new DictionaryEntry[myCol.Count];
            myCol.CopyTo( myArr, 0 );

            // Displays the values in the array.
            Console.WriteLine( "Displays the elements in the array:" );
            Console.WriteLine( "   KEY                       VALUE" );
            for ( int i = 0; i < myArr.Length; i++ )
                Console.WriteLine( "   {0,-25} {1}", myArr[i].Key, myArr[i].Value );
            Console.WriteLine();

            // Searches for a key.
            if ( myCol.Contains( "Kiwis" ) )
                Console.WriteLine( "The collection contains the key \"Kiwis\"." );
            else
                Console.WriteLine( "The collection does not contain the key \"Kiwis\"." );
            Console.WriteLine();

            // Deletes a key.
            myCol.Remove( "Plums" );
            Console.WriteLine( "The collection contains the following elements after removing \"Plums\":" );
            PrintKeysAndValues1( myCol );

            // Clears the entire collection.
            myCol.Clear();
            Console.WriteLine( "The collection contains the following elements after it is cleared:" );
            PrintKeysAndValues1( myCol );

        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintKeysAndValues1( IDictionary myCol )  {
            Console.WriteLine( "   KEY                       VALUE" );
            foreach ( DictionaryEntry de in myCol )
                Console.WriteLine( "   {0,-25} {1}", de.Key, de.Value );
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintKeysAndValues2( IDictionary myCol )  {
            IDictionaryEnumerator myEnumerator = myCol.GetEnumerator();
            Console.WriteLine( "   KEY                       VALUE" );
            while ( myEnumerator.MoveNext() )
                Console.WriteLine( "   {0,-25} {1}", myEnumerator.Key, myEnumerator.Value );
            Console.WriteLine();
        }

        // Uses the Keys, Values, Count, and Item properties.
        public static void PrintKeysAndValues3( ListDictionary myCol )  {
            String[] myKeys = new String[myCol.Count];
            myCol.Keys.CopyTo( myKeys, 0 );

            Console.WriteLine( "   INDEX KEY                       VALUE" );
            for ( int i = 0; i < myCol.Count; i++ )
                Console.WriteLine( "   {0,-5} {1,-25} {2}", i, myKeys[i], myCol[myKeys[i]] );
            Console.WriteLine();
        }

    }
}