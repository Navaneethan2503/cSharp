using System;
using System.Collections;
/**
Provides the abstract base class for a strongly typed collection of key/value pairs.

Properties:
-------------
Count - Gets the number of elements contained in the DictionaryBase instance.
Dictionary	- Gets the list of elements contained in the DictionaryBase instance.
InnerHashtable	- Gets the list of elements contained in the DictionaryBase instance.


Methods:
-------
Clear()-Clears the contents of the DictionaryBase instance.
CopyTo(Array, Int32)	-Copies the DictionaryBase elements to a one-dimensional Array at the specified index.
Equals(Object)	-Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an IDictionaryEnumerator that iterates through the DictionaryBase instance.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
OnClear() - Performs additional custom processes before clearing the contents of the DictionaryBase instance.
OnClearComplete()	- Performs additional custom processes after clearing the contents of the DictionaryBase instance.
OnGet(Object, Object)	- Gets the element with the specified key and value in the DictionaryBase instance.
OnInsert(Object, Object)	- Performs additional custom processes before inserting a new element into the DictionaryBase instance.
OnInsertComplete(Object, Object)	- Performs additional custom processes after inserting a new element into the DictionaryBase instance.
OnRemove(Object, Object)	- Performs additional custom processes before removing an element from the DictionaryBase instance.
OnRemoveComplete(Object, Object)	- Performs additional custom processes after removing an element from the DictionaryBase instance.
OnSet(Object, Object, Object)	- Performs additional custom processes before setting a value in the DictionaryBase instance.
OnSetComplete(Object, Object, Object)	- Performs additional custom processes after setting a value in the DictionaryBase instance.
OnValidate(Object, Object)	- Performs additional custom processes when validating the element with the specified key and value.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
 


**/
namespace DictionaryBaseNamespace{

    public class ShortStringDictionary : DictionaryBase  {

        public String this[ String key ]  {
            get  {
                return( (String) Dictionary[key] );
            }
            set  {
                Dictionary[key] = value;
            }
        }

        public ICollection Keys  {
            get  {
                return( Dictionary.Keys );
            }
        }

        public ICollection Values  {
            get  {
                return( Dictionary.Values );
            }
        }

        public void Add( String key, String value )  {
            Dictionary.Add( key, value );
        }

        public bool Contains( String key )  {
            return( Dictionary.Contains( key ) );
        }

        public void Remove( String key )  {
            Dictionary.Remove( key );
        }

        protected override void OnInsert( Object key, Object value )  {
            if ( key.GetType() != typeof(System.String) )
                {
                    throw new ArgumentException( "key must be of type String.", "key" );
                }
                else  {
                String strKey = (String) key;
                if ( strKey.Length > 5 )
                    throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
            }

            if ( value.GetType() != typeof(System.String) )
                {
                    throw new ArgumentException( "value must be of type String.", "value" );
                }
                else  {
                String strValue = (String) value;
                if ( strValue.Length > 5 )
                    throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
            }
        }

        protected override void OnRemove( Object key, Object value )  {
            if ( key.GetType() != typeof(System.String) )
                {
                    throw new ArgumentException( "key must be of type String.", "key" );
                }
                else  {
                String strKey = (String) key;
                if ( strKey.Length > 5 )
                    throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
            }
        }

        protected override void OnSet( Object key, Object oldValue, Object newValue )  {
            if ( key.GetType() != typeof(System.String) )
                {
                    throw new ArgumentException( "key must be of type String.", "key" );
                }
                else  {
                String strKey = (String) key;
                if ( strKey.Length > 5 )
                    throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
            }

            if ( newValue.GetType() != typeof(System.String) )
                {
                    throw new ArgumentException( "newValue must be of type String.", "newValue" );
                }
                else  {
                String strValue = (String) newValue;
                if ( strValue.Length > 5 )
                    throw new ArgumentException( "newValue must be no more than 5 characters in length.", "newValue" );
            }
        }

        protected override void OnValidate( Object key, Object value )  {
            if ( key.GetType() != typeof(System.String) )
                {
                    throw new ArgumentException( "key must be of type String.", "key" );
                }
                else  {
                String strKey = (String) key;
                if ( strKey.Length > 5 )
                    throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
            }

            if ( value.GetType() != typeof(System.String) )
                {
                    throw new ArgumentException( "value must be of type String.", "value" );
                }
                else  {
                String strValue = (String) value;
                if ( strValue.Length > 5 )
                    throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
            }
        }
    }

    class DictionaryBaseClass{
        public static void Main(){
            Console.WriteLine("Dictionary Base Collection.");
            // Creates and initializes a new DictionaryBase.
            ShortStringDictionary mySSC = new ShortStringDictionary();

            // Adds elements to the collection.
            mySSC.Add( "One", "a" );
            mySSC.Add( "Two", "ab" );
            mySSC.Add( "Three", "abc" );
            mySSC.Add( "Four", "abcd" );
            mySSC.Add( "Five", "abcde" );

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine( "Contents of the collection (using foreach):" );
            PrintKeysAndValues1( mySSC );

            // Display the contents of the collection using the enumerator.
            Console.WriteLine( "Contents of the collection (using enumerator):" );
            PrintKeysAndValues2( mySSC );

            // Display the contents of the collection using the Keys property and the Item property.
            Console.WriteLine( "Initial contents of the collection (using Keys and Item):" );
            PrintKeysAndValues3( mySSC );

            // Tries to add a value that is too long.
            try  {
                mySSC.Add( "Ten", "abcdefghij" );
            }
            catch ( ArgumentException e )  {
                Console.WriteLine( e.ToString() );
            }

            // Tries to add a key that is too long.
            try  {
                mySSC.Add( "Eleven", "ijk" );
            }
            catch ( ArgumentException e )  {
                Console.WriteLine( e.ToString() );
            }

            Console.WriteLine();

            // Searches the collection with Contains.
            Console.WriteLine( "Contains \"Three\": {0}", mySSC.Contains( "Three" ) );
            Console.WriteLine( "Contains \"Twelve\": {0}", mySSC.Contains( "Twelve" ) );
            Console.WriteLine();

            // Removes an element from the collection.
            mySSC.Remove( "Two" );

            // Displays the contents of the collection.
            Console.WriteLine( "After removing \"Two\":" );
            PrintKeysAndValues1( mySSC );

        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintKeysAndValues1( ShortStringDictionary myCol )  {
            foreach ( DictionaryEntry myDE in myCol )
                Console.WriteLine( "   {0,-5} : {1}", myDE.Key, myDE.Value );
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintKeysAndValues2( ShortStringDictionary myCol )  {
            DictionaryEntry myDE;
            System.Collections.IEnumerator myEnumerator = myCol.GetEnumerator();
            while ( myEnumerator.MoveNext() )
                if ( myEnumerator.Current != null )  {
                    myDE = (DictionaryEntry) myEnumerator.Current;
                    Console.WriteLine( "   {0,-5} : {1}", myDE.Key, myDE.Value );
                }
            Console.WriteLine();
        }

        // Uses the Keys property and the Item property.
        public static void PrintKeysAndValues3( ShortStringDictionary myCol )  {
            ICollection myKeys = myCol.Keys;
            foreach ( String k in myKeys )
                Console.WriteLine( "   {0,-5} : {1}", k, myCol[k] );
            Console.WriteLine();
        }

    }
}