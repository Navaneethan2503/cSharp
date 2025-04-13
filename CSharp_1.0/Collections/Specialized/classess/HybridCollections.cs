using System;
using System.Collections;
using System.Collections.Specialized;
/**
Implements IDictionary by using a ListDictionary while the collection is small, and then switching to a Hashtable when the collection gets large.

This class is recommended for cases where the number of elements in a dictionary is unknown. It takes advantage of the improved performance of a ListDictionary with small collections, and offers the flexibility of switching to a Hashtable, which handles larger collections better than ListDictionary.

If the initial size of the collection is greater than the optimal size for a ListDictionary, the collection is stored in a Hashtable to avoid the overhead of copying elements from the ListDictionary to a Hashtable.

The constructor accepts a Boolean parameter that allows the user to specify whether the collection ignores the case when comparing strings. If the collection is case-sensitive, it uses the key's implementations of Object.GetHashCode and Object.Equals. If the collection is case-insensitive, it performs a simple ordinal case-insensitive comparison, which obeys the casing rules of the invariant culture only. By default, the collection is case-sensitive. For more information on the invariant culture, see System.Globalization.CultureInfo.

A key cannot be null, but a value can.

The foreach statement of the C# language (For Each in Visual Basic) returns an object of the type of the elements in the collection. Since each element of the HybridDictionary is a key/value pair, the element type is not the type of the key or the type of the value. Instead, the element type is DictionaryEntry.

The foreach statement is a wrapper around the enumerator, which only allows reading from, not writing to, the collection.

Properties:
-----------
Count - Gets the number of key/value pairs contained in the HybridDictionary.
IsFixedSize	- Gets a value indicating whether the HybridDictionary has a fixed size.
IsReadOnly	- Gets a value indicating whether the HybridDictionary is read-only.
IsSynchronized	- Gets a value indicating whether the HybridDictionary is synchronized (thread safe).
Item[Object] - Gets or sets the value associated with the specified key.
Keys - Gets an ICollection containing the keys in the HybridDictionary.
SyncRoot - Gets an object that can be used to synchronize access to the HybridDictionary.
Values	- Gets an ICollection containing the values in the HybridDictionary.

Methods:
--------
Add(Object, Object)	- Adds an entry with the specified key and value into the HybridDictionary.
Clear()	- Removes all entries from the HybridDictionary.
Contains(Object)	- Determines whether the HybridDictionary contains a specific key.
CopyTo(Array, Int32)	- Copies the HybridDictionary entries to a one-dimensional Array instance at the specified index.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an IDictionaryEnumerator that iterates through the HybridDictionary.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
Remove(Object)	- Removes the entry with the specified key from the HybridDictionary.
ToString()	- Returns a string that represents the current object.(Inherited from Object)



**/
namespace SpecializedCollections{
    class HybridCollectionsClass{
        public static void Main(){
            Console.WriteLine("Hybrid Collections.");
            // Creates and initializes a new HybridDictionary.
            HybridDictionary myCol = new HybridDictionary();
            myCol.Add( "Braeburn Apples", "1.49" );
            myCol.Add( "Fuji Apples", "1.29" );
            myCol.Add( "Gala Apples", "1.49" );
            myCol.Add( "Golden Delicious Apples", "1.29" );
            myCol.Add( "Granny Smith Apples", "0.89" );
            myCol.Add( "Red Delicious Apples", "0.99" );
            myCol.Add( "Plantain Bananas", "1.49" );
            myCol.Add( "Yellow Bananas", "0.79" );
            myCol.Add( "Strawberries", "3.33" );
            myCol.Add( "Cranberries", "5.98" );
            myCol.Add( "Navel Oranges", "1.29" );
            myCol.Add( "Grapes", "1.99" );
            myCol.Add( "Honeydew Melon", "0.59" );
            myCol.Add( "Seedless Watermelon", "0.49" );
            myCol.Add( "Pineapple", "1.49" );
            myCol.Add( "Nectarine", "1.99" );
            myCol.Add( "Plums", "1.69" );
            myCol.Add( "Peaches", "1.99" );

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine( "Displays the elements using foreach:" );
            PrintKeysAndValues1( myCol );

            // Display the contents of the collection using the enumerator.
            Console.WriteLine( "Displays the elements using the IDictionaryEnumerator:" );
            PrintKeysAndValues2( myCol );

            // Display the contents of the collection using the Keys, Values, Count, and Item properties.
            Console.WriteLine( "Displays the elements using the Keys, Values, Count, and Item properties:" );
            PrintKeysAndValues3( myCol );

            // Copies the HybridDictionary to an array with DictionaryEntry elements.
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
        public static void PrintKeysAndValues3( HybridDictionary myCol )  {
            String[] myKeys = new String[myCol.Count];
            myCol.Keys.CopyTo( myKeys, 0 );

            Console.WriteLine( "   INDEX KEY                       VALUE" );
            for ( int i = 0; i < myCol.Count; i++ )
                Console.WriteLine( "   {0,-5} {1,-25} {2}", i, myKeys[i], myCol[myKeys[i]] );
            Console.WriteLine();
        }

    }
}