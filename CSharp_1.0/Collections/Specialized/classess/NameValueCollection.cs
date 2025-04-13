using System;
using System.Collections.Specialized;
/**
NameValueCollection:
--------------------
Description: Represents a collection of associated String keys and String values that can be accessed either with the key or with the index.
Use Case: Useful for storing multiple values under a single key, similar to a dictionary but with support for multiple values per key.

Properties:
-----------
AllKeys	- Gets all the keys in the NameValueCollection.
Count	- Gets the number of key/value pairs contained in the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
IsReadOnly	- Gets or sets a value indicating whether the NameObjectCollectionBase instance is read-only.(Inherited from NameObjectCollectionBase)
Item[Int32]	- Gets the entry at the specified index of the NameValueCollection.
Item[String]	- Gets or sets the entry with the specified key in the NameValueCollection.
Keys	- Gets a NameObjectCollectionBase.KeysCollection instance that contains all the keys in the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)


Methods:
--------
Add(NameValueCollection)- Copies the entries in the specified NameValueCollection to the current NameValueCollection.
Add(String, String)	- Adds an entry with the specified name and value to the NameValueCollection.
BaseAdd(String, Object)	- Adds an entry with the specified key and value into the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseClear() - Removes all entries from the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseGet(Int32) - Gets the value of the entry at the specified index of the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseGet(String)	- Gets the value of the first entry with the specified key from the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseGetAllKeys() - Returns a String array that contains all the keys in the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseGetAllValues()	- Returns an Object array that contains all the values in the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseGetAllValues(Type)	- Returns an array of the specified type that contains all the values in the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseGetKey(Int32) - Gets the key of the entry at the specified index of the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseHasKeys() - Gets a value indicating whether the NameObjectCollectionBase instance contains entries whose keys are not null.(Inherited from NameObjectCollectionBase)
BaseRemove(String) - Removes the entries with the specified key from the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseRemoveAt(Int32) - Removes the entry at the specified index of the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseSet(Int32, Object) - Sets the value of the entry at the specified index of the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
BaseSet(String, Object) - Sets the value of the first entry with the specified key in the NameObjectCollectionBase instance, if found; otherwise, adds an entry with the specified key and value into the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
Clear() - Invalidates the cached arrays and removes all entries from the NameValueCollection.
CopyTo(Array, Int32)	 - Copies the entire NameValueCollection to a compatible one-dimensional Array, starting at the specified index of the target array.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Get(Int32)	- Gets the values at the specified index of the NameValueCollection combined into one comma-separated list.
Get(String)	- Gets the values associated with the specified key from the NameValueCollection combined into one comma-separated list.
GetEnumerator()	- Returns an enumerator that iterates through the NameObjectCollectionBase.(Inherited from NameObjectCollectionBase)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetKey(Int32) - Gets the key at the specified index of the NameValueCollection.
GetObjectData(SerializationInfo, StreamingContext)	- Obsolete. Implements the ISerializable interface and returns the data needed to serialize the NameObjectCollectionBase instance.(Inherited from NameObjectCollectionBase)
GetType() - Gets the Type of the current instance.(Inherited from Object)
GetValues(Int32) - Gets the values at the specified index of the NameValueCollection.
GetValues(String) - Gets the values associated with the specified key from the NameValueCollection.
HasKeys()	- Gets a value indicating whether the NameValueCollection contains keys that are not null.
InvalidateCachedArrays()	- Resets the cached arrays of the collection to null.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
OnDeserialization(Object)	- Implements the ISerializable interface and raises the deserialization event when the deserialization is complete.(Inherited from NameObjectCollectionBase)
Remove(String)	- Removes the entries with the specified key from the NameObjectCollectionBase instance.
Set(String, String)	- Sets the value of an entry in the NameValueCollection.
ToString()	- Returns a string that represents the current object.(Inherited from Object)



**/
namespace SpecializedCollections{
    class NameValueCollectionsClass{
        public static void Main(){
            Console.WriteLine("NameValue Collections");
            // Creates and initializes a new NameValueCollection.
            NameValueCollection myCol = new NameValueCollection();
            myCol.Add( "red", "rojo" );
            myCol.Add( "green", "verde" );
            myCol.Add( "blue", "azul" );
            myCol.Add( "red", "rouge" );

            // Displays the values in the NameValueCollection in two different ways.
            Console.WriteLine( "Displays the elements using the AllKeys property and the Item (indexer) property:" );
            PrintKeysAndValues( myCol );
            Console.WriteLine( "Displays the elements using GetKey and Get:" );
            PrintKeysAndValues2( myCol );

            // Gets a value either by index or by key.
            Console.WriteLine( "Index 1 contains the value {0}.", myCol[1] );
            Console.WriteLine( "Key \"red\" has the value {0}.", myCol["red"] );
            Console.WriteLine();

            // Copies the values to a string array and displays the string array.
            String[] myStrArr = new String[myCol.Count];
            myCol.CopyTo( myStrArr, 0 );
            Console.WriteLine( "The string array contains:" );
            foreach ( String s in myStrArr )
                Console.WriteLine( "   {0}", s );
            Console.WriteLine();

            // Searches for a key and deletes it.
            myCol.Remove( "green" );
            Console.WriteLine( "The collection contains the following elements after removing \"green\":" );
            PrintKeysAndValues( myCol );

            // Clears the entire collection.
            myCol.Clear();
            Console.WriteLine( "The collection contains the following elements after it is cleared:" );
            PrintKeysAndValues( myCol );
        }

        public static void PrintKeysAndValues( NameValueCollection myCol )  {
            Console.WriteLine( "   KEY        VALUE" );
            foreach ( String s in myCol.AllKeys )
                Console.WriteLine( "   {0,-10} {1}", s, myCol[s] );
            Console.WriteLine();
        }

        public static void PrintKeysAndValues2( NameValueCollection myCol )  {
            Console.WriteLine( "   [INDEX] KEY        VALUE" );
            for ( int i = 0; i < myCol.Count; i++ )
                Console.WriteLine( "   [{0}]     {1,-10} {2}", i, myCol.GetKey(i), myCol.Get(i) );
            Console.WriteLine();
        }

    }
}