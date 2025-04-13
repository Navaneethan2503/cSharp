using System;
using System.Collections.ObjectModel;
/**
the Object Model Collections are a set of classes that provide a way to store and manage groups of related objects.

Provides the base class for a generic collection.

Collection: A generic base class for creating custom collections, providing type safety and indexable access.
Generic Collections: Provide type-safe, optimized collections for various use cases, ensuring compile-time type checking.
Non-Generic Collections: Legacy collections that can store any type of object but lack type safety, leading to potential runtime errors.

The Collection<T> class can be used immediately by creating an instance of one of its constructed types; all you have to do is specify the type of object to be contained in the collection. In addition, you can derive your own collection type from any constructed type, or derive a generic collection type from the Collection<T> class itself.

The Collection<T> class provides protected methods that can be used to customize its behavior when adding and removing items, clearing the collection, or setting the value of an existing item.

Most Collection<T> objects can be modified. However, a Collection<T> object that is initialized with a read-only IList<T> object cannot be modified. See ReadOnlyCollection<T> for a read-only version of this class.

Elements in this collection can be accessed using an integer index. Indexes in this collection are zero-based.

Collection<T> accepts null as a valid value for reference types and allows duplicate elements.

This base class is provided to make it easier for implementers to create a custom collection. Implementers are encouraged to extend this base class instead of creating their own.

Properties:
-----------
Count - Gets the number of elements actually contained in the Collection<T>.
Item[Int32]	- Gets or sets the element at the specified index.
Items	- Gets a IList<T> wrapper around the Collection<T>.


Methods:
--------
Add(T) - Adds an object to the end of the Collection<T>.
Clear()	- Removes all elements from the Collection<T>.
ClearItems() - Removes all elements from the Collection<T>.
Contains(T)	- Determines whether an element is in the Collection<T>.
CopyTo(T[], Int32)	- Copies the entire Collection<T> to a compatible one-dimensional Array, starting at the specified index of the target array.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator that iterates through the Collection<T>.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
IndexOf(T) - Searches for the specified object and returns the zero-based index of the first occurrence within the entire Collection<T>.
Insert(Int32, T) - Inserts an element into the Collection<T> at the specified index.
InsertItem(Int32, T) - Inserts an element into the Collection<T> at the specified index.
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
Remove(T) - Removes the first occurrence of a specific object from the Collection<T>.
RemoveAt(Int32)	-  Removes the element at the specified index of the Collection<T>.
RemoveItem(Int32)- Removes the element at the specified index of the Collection<T>.
SetItem(Int32, T)	-  Replaces the element at the specified index.
ToString()	- Returns a string that represents the current object.(Inherited from Object)

Contains classes that can be used as collections in the object model of a reusable library. Use these classes when properties or methods return collections.

Classes:
---------
Collection<T> - Provides the base class for a generic collection.
KeyedCollection<TKey,TItem>	- Provides the abstract base class for a collection whose keys are embedded in the values.
ObservableCollection<T>	- Represents a dynamic data collection that provides notifications when items get added or removed, or when the whole list is refreshed.
ReadOnlyCollection<T>	- Provides the base class for a generic read-only collection.
ReadOnlyDictionary<TKey,TValue>.KeyCollection	- Represents a read-only collection of the keys of a ReadOnlyDictionary<TKey,TValue> object.
ReadOnlyDictionary<TKey,TValue>.ValueCollection	- Represents a read-only collection of the values of a ReadOnlyDictionary<TKey,TValue> object.
ReadOnlyDictionary<TKey,TValue>	-Represents a read-only, generic collection of key/value pairs.
ReadOnlyObservableCollection<T>	- Represents a read-only ObservableCollection<T>.
ReadOnlySet<T>	- Represents a read-only, generic set of values.

**/
namespace CollectionObjectModel{
    class CollectionObjectModelClass{
        public static void Main(){
            Console.WriteLine("Collection Object Model.");
            Collection<string> dinosaurs = new Collection<string>();

            dinosaurs.Add("Psitticosaurus");
            dinosaurs.Add("Caudipteryx");
            dinosaurs.Add("Compsognathus");
            dinosaurs.Add("Muttaburrasaurus");

            Console.WriteLine("{0} dinosaurs:", dinosaurs.Count);
            Display(dinosaurs);

            Console.WriteLine("\nIndexOf(\"Muttaburrasaurus\"): {0}",
                dinosaurs.IndexOf("Muttaburrasaurus"));

            Console.WriteLine("\nContains(\"Caudipteryx\"): {0}",
                dinosaurs.Contains("Caudipteryx"));

            Console.WriteLine("\nInsert(2, \"Nanotyrannus\")");
            dinosaurs.Insert(2, "Nanotyrannus");
            Display(dinosaurs);

            Console.WriteLine("\ndinosaurs[2]: {0}", dinosaurs[2]);

            Console.WriteLine("\ndinosaurs[2] = \"Microraptor\"");
            dinosaurs[2] = "Microraptor";
            Display(dinosaurs);

            Console.WriteLine("\nRemove(\"Microraptor\")");
            dinosaurs.Remove("Microraptor");
            Display(dinosaurs);

            Console.WriteLine("\nRemoveAt(0)");
            dinosaurs.RemoveAt(0);
            Display(dinosaurs);

            Console.WriteLine("\ndinosaurs.Clear()");
            dinosaurs.Clear();
            Console.WriteLine("Count: {0}", dinosaurs.Count);

        }

        private static void Display(Collection<string> cs)
        {
            Console.WriteLine();
            foreach( string item in cs )
            {
                Console.WriteLine(item);
            }
        }

    }
}