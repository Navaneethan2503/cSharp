using System;
using System.Collections.Specialized;
using System.Collections;
/**
Provides the abstract base class for a collection of associated String keys and Object values that can be accessed either with the key or with the index.

Properties:
-----------
Count - Gets the number of key/value pairs contained in the NameObjectCollectionBase instance.
IsReadOnly	- Gets or sets a value indicating whether the NameObjectCollectionBase instance is read-only.
Keys - Gets a NameObjectCollectionBase.KeysCollection instance that contains all the keys in the NameObjectCollectionBase instance.

Methods:
--------
BaseAdd(String, Object)	- Adds an entry with the specified key and value into the NameObjectCollectionBase instance.
BaseClear()	- Removes all entries from the NameObjectCollectionBase instance.
BaseGet(Int32)	- Gets the value of the entry at the specified index of the NameObjectCollectionBase instance.
BaseGet(String)	- Gets the value of the first entry with the specified key from the NameObjectCollectionBase instance.
BaseGetAllKeys() - Returns a String array that contains all the keys in the NameObjectCollectionBase instance.
BaseGetAllValues()	- Returns an Object array that contains all the values in the NameObjectCollectionBase instance.
BaseGetAllValues(Type)	- Returns an array of the specified type that contains all the values in the NameObjectCollectionBase instance.
BaseGetKey(Int32)	- Gets the key of the entry at the specified index of the NameObjectCollectionBase instance.
BaseHasKeys()	- Gets a value indicating whether the NameObjectCollectionBase instance contains entries whose keys are not null.
BaseRemove(String)	- Removes the entries with the specified key from the NameObjectCollectionBase instance.
BaseRemoveAt(Int32)	- Removes the entry at the specified index of the NameObjectCollectionBase instance.
BaseSet(Int32, Object)	- Sets the value of the entry at the specified index of the NameObjectCollectionBase instance.
BaseSet(String, Object)	- Sets the value of the first entry with the specified key in the NameObjectCollectionBase instance, if found; otherwise, adds an entry with the specified key and value into the NameObjectCollectionBase instance.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator that iterates through the NameObjectCollectionBase.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetObjectData(SerializationInfo, StreamingContext)	- Obsolete. Implements the ISerializable interface and returns the data needed to serialize the NameObjectCollectionBase instance.
GetType()	-  Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
OnDeserialization(Object) - Implements the ISerializable interface and raises the deserialization event when the deserialization is complete.
ToString()	- Returns a string that represents the current object.(Inherited from Object)


**/
namespace SpecializedCollections{

    public class MyCollection : NameObjectCollectionBase
    {
        // Creates an empty collection.
        public MyCollection()  {
        }

        // Adds elements from an IDictionary into the new collection.
        public MyCollection( IDictionary d, Boolean bReadOnly )  {
            foreach ( DictionaryEntry de in d )  {
                this.BaseAdd( (String) de.Key, de.Value );
            }
            this.IsReadOnly = bReadOnly;
        }

        // Gets a key-and-value pair (DictionaryEntry) using an index.
        public DictionaryEntry this[ int index ]  {
            get  {
                return ( new DictionaryEntry(
                    this.BaseGetKey(index), this.BaseGet(index) ) );
            }
        }

        // Gets or sets the value associated with the specified key.
        public Object this[ String key ]  {
            get  {
                return( this.BaseGet( key ) );
            }
            set  {
                this.BaseSet( key, value );
            }
        }

        // Gets a String array that contains all the keys in the collection.
        public String[] AllKeys  {
            get  {
                return( this.BaseGetAllKeys() );
            }
        }

        // Gets an Object array that contains all the values in the collection.
        public Array AllValues  {
            get  {
                return( this.BaseGetAllValues() );
            }
        }

        // Gets a String array that contains all the values in the collection.
        public String[] AllStringValues  {
            get  {
                return( (String[]) this.BaseGetAllValues( typeof( string ) ));
            }
        }

        // Gets a value indicating if the collection contains keys that are not null.
        public Boolean HasKeys  {
            get  {
                return( this.BaseHasKeys() );
            }
        }

        // Adds an entry to the collection.
        public void Add( String key, Object value )  {
            this.BaseAdd( key, value );
        }

        // Removes an entry with the specified key from the collection.
        public void Remove( String key )  {
            this.BaseRemove( key );
        }

        // Removes an entry in the specified index from the collection.
        public void Remove( int index )  {
            this.BaseRemoveAt( index );
        }

        // Clears all the elements in the collection.
        public void Clear()  {
            this.BaseClear();
        }
    }



    class NameObjectCollectionsBaseClass{
        public static void Main(){
            Console.WriteLine("Name Object Collection Base Class .");
            // Creates and initializes a new MyCollection that is read-only.
            IDictionary d = new ListDictionary();
            d.Add( "red", "apple" );
            d.Add( "yellow", "banana" );
            d.Add( "green", "pear" );
            MyCollection myROCol = new MyCollection( d, true );

            // Tries to add a new item.
            try  {
                myROCol.Add( "blue", "sky" );
            }
            catch ( NotSupportedException e )  {
                Console.WriteLine( e.ToString() );
            }

            // Displays the keys and values of the MyCollection.
            Console.WriteLine( "Read-Only Collection:" );
            PrintKeysAndValues( myROCol );

            // Creates and initializes an empty MyCollection that is writable.
            MyCollection myRWCol = new MyCollection();

            // Adds new items to the collection.
            myRWCol.Add( "purple", "grape" );
            myRWCol.Add( "orange", "tangerine" );
            myRWCol.Add( "black", "berries" );
            Console.WriteLine( "Writable Collection (after adding values):" );
            PrintKeysAndValues( myRWCol );

            // Changes the value of one element.
            myRWCol["orange"] = "grapefruit";
            Console.WriteLine( "Writable Collection (after changing one value):" );
            PrintKeysAndValues( myRWCol );

            // Removes one item from the collection.
            myRWCol.Remove( "black" );
            Console.WriteLine( "Writable Collection (after removing one value):" );
            PrintKeysAndValues( myRWCol );

            // Removes all elements from the collection.
            myRWCol.Clear();
            Console.WriteLine( "Writable Collection (after clearing the collection):" );
            PrintKeysAndValues( myRWCol );

        }

        // Prints the indexes, keys, and values.
        public static void PrintKeysAndValues( MyCollection myCol )  {
            for ( int i = 0; i < myCol.Count; i++ )  {
                Console.WriteLine( "[{0}] : {1}, {2}", i, myCol[i].Key, myCol[i].Value );
            }
        }

        // Prints the keys and values using AllKeys.
        public static void PrintKeysAndValues2( MyCollection myCol )  {
            foreach ( String s in myCol.AllKeys )  {
                Console.WriteLine( "{0}, {1}", s, myCol[s] );
            }
        }

    }
}