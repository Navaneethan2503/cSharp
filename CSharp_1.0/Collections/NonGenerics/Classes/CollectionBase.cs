using System;
using System.Collections;
/**
Provides the abstract base class for a strongly typed collection.

A CollectionBase instance is always modifiable.

The capacity of a CollectionBase is the number of elements the CollectionBase can hold. As elements are added to a CollectionBase, the capacity is automatically increased as required through reallocation. The capacity can be decreased by setting the Capacity property explicitly.

Properties:
------------
Capacity- Gets or sets the number of elements that the CollectionBase can contain.
Count	- Gets the number of elements contained in the CollectionBase instance. This property cannot be overridden.
InnerList	- Gets an ArrayList containing the list of elements in the CollectionBase instance.
List	- Gets an IList containing the list of elements in the CollectionBase instance.

Methods:
--------
Clear()	- Removes all objects from the CollectionBase instance. This method cannot be overridden.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator that iterates through the CollectionBase instance.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
OnClear()	- Performs additional custom processes when clearing the contents of the CollectionBase instance.
OnClearComplete()	- Performs additional custom processes after clearing the contents of the CollectionBase instance.
OnInsert(Int32, Object)	- Performs additional custom processes before inserting a new element into the CollectionBase instance.
OnInsertComplete(Int32, Object)	- Performs additional custom processes after inserting a new element into the CollectionBase instance.
OnRemove(Int32, Object)	- Performs additional custom processes when removing an element from the CollectionBase instance.
OnRemoveComplete(Int32, Object)	- Performs additional custom processes after removing an element from the CollectionBase instance.
OnSet(Int32, Object, Object)	- Performs additional custom processes before setting a value in the CollectionBase instance.
OnSetComplete(Int32, Object, Object)	- Performs additional custom processes after setting a value in the CollectionBase instance.
OnValidate(Object)	- Performs additional custom processes when validating a value.
RemoveAt(Int32)	- Removes the element at the specified index of the CollectionBase instance. This method is not overridable.
ToString()	- Returns a string that represents the current object.(Inherited from Object)


**/
namespace CollectionBaseNamespace{
    public class Int16Collection : CollectionBase  {

        public Int16 this[ int index ]  {
            get  {
                return( (Int16) List[index] );
            }
            set  {
                List[index] = value;
            }
        }

        public int Add( Int16 value )  {
            return( List.Add( value ) );
        }

        public int IndexOf( Int16 value )  {
            return( List.IndexOf( value ) );
        }

        public void Insert( int index, Int16 value )  {
            List.Insert( index, value );
        }

        public void Remove( Int16 value )  {
            List.Remove( value );
        }

        public bool Contains( Int16 value )  {
            // If value is not of type Int16, this will return false.
            return( List.Contains( value ) );
        }

        protected override void OnInsert( int index, Object value )  {
            // Insert additional code to be run only when inserting values.
        }

        protected override void OnRemove( int index, Object value )  {
            // Insert additional code to be run only when removing values.
        }

        protected override void OnSet( int index, Object oldValue, Object newValue )  {
            // Insert additional code to be run only when setting values.
        }

        protected override void OnValidate( Object value )  {
            if ( value.GetType() != typeof(System.Int16) )
                throw new ArgumentException( "value must be of type Int16.", "value" );
        }
    }

    class CollectionBaseClass{
        public static void Main(){
            Console.WriteLine("Collection Base Class");
            // Create and initialize a new CollectionBase.
            Int16Collection myI16 = new Int16Collection();

            // Add elements to the collection.
            myI16.Add( (Int16) 1 );
            myI16.Add( (Int16) 2 );
            myI16.Add( (Int16) 3 );
            myI16.Add( (Int16) 5 );
            myI16.Add( (Int16) 7 );

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine( "Contents of the collection (using foreach):" );
            PrintValues1( myI16 );

            // Display the contents of the collection using the enumerator.
            Console.WriteLine( "Contents of the collection (using enumerator):" );
            PrintValues2( myI16 );

            // Display the contents of the collection using the Count property and the Item property.
            Console.WriteLine( "Initial contents of the collection (using Count and Item):" );
            PrintIndexAndValues( myI16 );

            // Search the collection with Contains and IndexOf.
            Console.WriteLine( "Contains 3: {0}", myI16.Contains( 3 ) );
            Console.WriteLine( "2 is at index {0}.", myI16.IndexOf( 2 ) );
            Console.WriteLine();

            // Insert an element into the collection at index 3.
            myI16.Insert( 3, (Int16) 13 );
            Console.WriteLine( "Contents of the collection after inserting at index 3:" );
            PrintIndexAndValues( myI16 );

            // Get and set an element using the index.
            myI16[4] = 123;
            Console.WriteLine( "Contents of the collection after setting the element at index 4 to 123:" );
            PrintIndexAndValues( myI16 );

            // Remove an element from the collection.
            myI16.Remove( (Int16) 2 );

            // Display the contents of the collection using the Count property and the Item property.
            Console.WriteLine( "Contents of the collection after removing the element 2:" );
            PrintIndexAndValues( myI16 );

        }

        // Uses the Count property and the Item property.
        public static void PrintIndexAndValues( Int16Collection myCol )  {
            for ( int i = 0; i < myCol.Count; i++ )
                Console.WriteLine( "   [{0}]:   {1}", i, myCol[i] );
            Console.WriteLine();
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintValues1( Int16Collection myCol )  {
            foreach ( Int16 i16 in myCol )
                Console.WriteLine( "   {0}", i16 );
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintValues2( Int16Collection myCol )  {
            System.Collections.IEnumerator myEnumerator = myCol.GetEnumerator();
            while ( myEnumerator.MoveNext() )
                Console.WriteLine( "   {0}", myEnumerator.Current );
            Console.WriteLine();
        }

    }
}