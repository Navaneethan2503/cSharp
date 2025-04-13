using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
/**
Represents a dynamic data collection that provides notifications when items get added or removed, or when the whole list is refreshed.


Properties:
-----------
Count - Gets the number of elements actually contained in the Collection<T>.(Inherited from Collection<T>)
Item[Int32]	- Gets or sets the element at the specified index.(Inherited from Collection<T>)
Items - Gets a IList<T> wrapper around the Collection<T>.(Inherited from Collection<T>)


Methods:
--------

Add(T) - Adds an object to the end of the Collection<T>.(Inherited from Collection<T>)
BlockReentrancy()	-Disallows reentrant attempts to change this collection.
CheckReentrancy()	- Checks for reentrant attempts to change this collection.
Clear()	- Removes all elements from the Collection<T>.(Inherited from Collection<T>)
ClearItems() - Removes all items from the collection.
Contains(T)	- Determines whether an element is in the Collection<T>.(Inherited from Collection<T>)
CopyTo(T[], Int32) - Copies the entire Collection<T> to a compatible one-dimensional Array, starting at the specified index of the target array.(Inherited from Collection<T>)
Equals(Object) - Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator() - Returns an enumerator that iterates through the Collection<T>.(Inherited from Collection<T>)
GetHashCode() - Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
IndexOf(T) - Searches for the specified object and returns the zero-based index of the first occurrence within the entire Collection<T>.(Inherited from Collection<T>)
Insert(Int32, T) - Inserts an element into the Collection<T> at the specified index.(Inherited from Collection<T>)
InsertItem(Int32, T) - Inserts an item into the collection at the specified index.
MemberwiseClone()	 - Creates a shallow copy of the current Object.(Inherited from Object)
Move(Int32, Int32) - Moves the item at the specified index to a new location in the collection.
MoveItem(Int32, Int32)	- Moves the item at the specified index to a new location in the collection.
OnCollectionChanged(NotifyCollectionChangedEventArgs)	- Raises the CollectionChanged event with the provided arguments.
OnPropertyChanged(PropertyChangedEventArgs)	 - Raises the PropertyChanged event with the provided arguments.
Remove(T) - Removes the first occurrence of a specific object from the Collection<T>.(Inherited from Collection<T>)
RemoveAt(Int32)	- Removes the element at the specified index of the Collection<T>.(Inherited from Collection<T>)
RemoveItem(Int32) - Removes the item at the specified index of the collection.
SetItem(Int32, T)	- Replaces the element at the specified index.
ToString()	- Returns a string that represents the current object.(Inherited from Object)

Events:
--------
CollectionChanged -Occurs when an item is added, removed, or moved, or the entire list is refreshed.
PropertyChanged	- Occurs when a property value changes.

**/
namespace ObjectModelCollections{
    class ObservableCollections{
        public static void Main(){
            Console.WriteLine("Observable Collections.");
        }
    }
}