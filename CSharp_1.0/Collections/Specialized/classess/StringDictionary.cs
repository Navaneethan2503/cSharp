using System;
using System.Collections.Specialized;
using System.Collections;
/**
Implements a hash table with the key and the value strongly typed to be strings rather than objects.

Description: Represents a dictionary with string keys and string values.
Use Case: Provides a strongly typed dictionary for string keys and values, offering a simpler interface than Dictionary<string, string>.

A key cannot be null, but a value can.

The key is handled in a case-insensitive manner; it is translated to lowercase before it is used with the string dictionary.

In .NET Framework version 1.0, this class uses culture-sensitive string comparisons. However, in .NET Framework version 1.1 and later, this class uses CultureInfo.InvariantCulture when comparing strings. For more information about how culture affects comparisons and sorting, see Performing Culture-Insensitive String Operations.

Properties:
-----------
Count -Gets the number of key/value pairs in the StringDictionary.
IsSynchronized	- Gets a value indicating whether access to the StringDictionary is synchronized (thread safe).
Item[String]	- Gets or sets the value associated with the specified key.
Keys	- Gets a collection of keys in the StringDictionary.
SyncRoot	- Gets an object that can be used to synchronize access to the StringDictionary.
Values	- Gets a collection of values in the StringDictionary.


Methods:
----------
Add(String, String)	- Adds an entry with the specified key and value into the StringDictionary.
    The key is handled in a case-insensitive manner; it is translated to lowercase before it is added to the string dictionary.

Clear()	- Removes all entries from the StringDictionary.
ContainsKey(String)	- Determines if the StringDictionary contains a specific key.
ContainsValue(String)	- Determines if the StringDictionary contains a specific value.
    The key is handled in a case-insensitive manner; it is translated to lowercase before it is used.
    
CopyTo(Array, Int32)	- Copies the string dictionary values to a one-dimensional Array instance at the specified index.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator that iterates through the string dictionary.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
Remove(String) - Removes the entry with the specified key from the string dictionary.
ToString()	- Returns a string that represents the current object.(Inherited from Object)



**/
namespace SpecializedCollections{
    class StringDictionaryClass{
        public static void Main(){
            Console.WriteLine("String Dictionary Class.");
            // Creates and initializes a new StringDictionary.
            StringDictionary myCol = new StringDictionary();
            myCol.Add( "red", "rojo" );
            myCol.Add( "green", "verde" );
            myCol.Add( "blue", "azul" );

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine( "Displays the elements using foreach:" );
            PrintKeysAndValues1( myCol );

            // Display the contents of the collection using the enumerator.
            Console.WriteLine( "Displays the elements using the IEnumerator:" );
            PrintKeysAndValues2( myCol );

            // Display the contents of the collection using the Keys, Values, Count, and Item properties.
            Console.WriteLine( "Displays the elements using the Keys, Values, Count, and Item properties:" );
            PrintKeysAndValues3( myCol );

            // Copies the StringDictionary to an array with DictionaryEntry elements.
            DictionaryEntry[] myArr = new DictionaryEntry[myCol.Count];
            myCol.CopyTo( myArr, 0 );

            // Displays the values in the array.
            Console.WriteLine( "Displays the elements in the array:" );
            Console.WriteLine( "   KEY        VALUE" );
            for ( int i = 0; i < myArr.Length; i++ )
                Console.WriteLine( "   {0,-10} {1}", myArr[i].Key, myArr[i].Value );
            Console.WriteLine();

            // Searches for a value.
            if ( myCol.ContainsValue( "amarillo" ) )
                Console.WriteLine( "The collection contains the value \"amarillo\"." );
            else
                Console.WriteLine( "The collection does not contain the value \"amarillo\"." );
            Console.WriteLine();

            // Searches for a key and deletes it.
            if ( myCol.ContainsKey( "green" ) )
                myCol.Remove( "green" );
            Console.WriteLine( "The collection contains the following elements after removing \"green\":" );
            PrintKeysAndValues1( myCol );

            // Clears the entire collection.
            myCol.Clear();
            Console.WriteLine( "The collection contains the following elements after it is cleared:" );
            PrintKeysAndValues1( myCol );
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintKeysAndValues1( StringDictionary myCol )  {
            Console.WriteLine( "   KEY                       VALUE" );
            foreach ( DictionaryEntry de in myCol )
                Console.WriteLine( "   {0,-25} {1}", de.Key, de.Value );
            Console.WriteLine();

        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintKeysAndValues2( StringDictionary myCol )  {
            IEnumerator myEnumerator = myCol.GetEnumerator();
            DictionaryEntry de;
            Console.WriteLine( "   KEY                       VALUE" );
            while ( myEnumerator.MoveNext() )  {
                de = (DictionaryEntry) myEnumerator.Current;
                Console.WriteLine( "   {0,-25} {1}", de.Key, de.Value );
            }
            Console.WriteLine();
        }

        // Uses the Keys, Values, Count, and Item properties.
        public static void PrintKeysAndValues3( StringDictionary myCol )  {
            String[] myKeys = new String[myCol.Count];
            myCol.Keys.CopyTo( myKeys, 0 );

            Console.WriteLine( "   INDEX KEY                       VALUE" );
            for ( int i = 0; i < myCol.Count; i++ )
                Console.WriteLine( "   {0,-5} {1,-25} {2}", i, myKeys[i], myCol[myKeys[i]] );
            Console.WriteLine();
        }
    }
}