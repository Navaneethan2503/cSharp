using System;
using System.Collections.Frozen;
using System.Collections.Generic;
/**
Contains types that provide immutable, read-only collections optimized for fast lookup and enumeration.

Frozen Dictionary<TKey,TValue>:
---------------------------------
Provides an immutable, read-only dictionary optimized for fast lookup and enumeration.

FrozenDictionary<TKey,TValue> is immutable and is optimized for situations where a dictionary is created infrequently but is used frequently at run time. It has a relatively high cost to create but provides excellent lookup performance. Thus, it is ideal for cases where a dictionary is created once, potentially at the startup of an application, and is used throughout the remainder of the life of the application. FrozenDictionary<TKey,TValue> should only be initialized with trusted keys, as the details of the keys impacts construction time.

Properties:
-----------
Comparer - Gets the comparer used by this dictionary.
Count - Gets the number of key/value pairs contained in the dictionary.
Empty - Gets an empty FrozenDictionary<TKey,TValue>.
Item[TKey]	- Gets a reference to the value associated with the specified key.
Keys - Gets a collection containing the keys in the dictionary.
Values	- Gets a collection containing the values in the dictionary.

Methods:
---------
ContainsKey(TKey) - Determines whether the dictionary contains the specified key.
CopyTo(KeyValuePair<TKey,TValue>[], Int32)	- Copies the elements of the dictionary to an array of type KeyValuePair<TKey,TValue>, starting at the specified destinationIndex.
CopyTo(Span<KeyValuePair<TKey,TValue>>)	- Copies the elements of the dictionary to a span of type KeyValuePair<TKey,TValue>.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetAlternateLookup<TAlternateKey>()	- Gets an instance of a type that may be used to perform operations on a FrozenDictionary<TKey,TValue>
using a TAlternateKey as a key instead of a TKey.- 
GetEnumerator() - Returns an enumerator that iterates through the dictionary.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
GetValueRefOrNullRef(TKey) - Gets either a reference to a TValue in the dictionary or a null reference if the key does not exist in the dictionary.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryGetAlternateLookup<TAlternateKey>(FrozenDictionary<TKey,TValue>.AlternateLookup<TAlternateKey>)	- Gets an instance of a type that may be used to perform operations on a FrozenDictionary<TKey,TValue> using a TAlternateKey as a key instead of a TKey.
TryGetValue(TKey, TValue)	- Gets the value associated with the specified key.

FrozenSet<T>:
-------------
Provides an immutable, read-only set optimized for fast lookup and enumeration.

FrozenSet<T> is immutable and is optimized for situations where a set is created infrequently but is used frequently at run time. It has a relatively high cost to create but provides excellent lookup performance. Thus, it is ideal for cases where a set is created once, potentially at the startup of an application, and is used throughout the remainder of the life of the application. FrozenSet<T> should only be initialized with trusted elements, as the details of the elements impacts construction time.

Properties:
------------
Comparer - Gets the comparer used by this set.
Count -Gets the number of values contained in the set.
Empty - Gets an empty FrozenSet<T>.
Items- Gets a collection containing the values in the set.

Methods:
---------
Contains(T)	- Determines whether the set contains the specified element.
CopyTo(Span<T>)	- Copies the values in the set to a span.
CopyTo(T[], Int32)	- Copies the values in the set to an array, starting at the specified destinationIndex.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetAlternateLookup<TAlternate>()	- Gets an instance of a type that may be used to perform operations on a FrozenSet<T>
using a TAlternate instead of a T.
GetEnumerator()	- Returns an enumerator that iterates through the set.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()- Gets the Type of the current instance.(Inherited from Object)
IsProperSubsetOf(IEnumerable<T>) - Determines whether the current set is a proper (strict) subset of a specified collection.
IsProperSupersetOf(IEnumerable<T>)	- Determines whether the current set is a proper (strict) superset of a specified collection.
IsSubsetOf(IEnumerable<T>)	- Determines whether a set is a subset of a specified collection.
IsSupersetOf(IEnumerable<T>)	- Determines whether the current set is a superset of a specified collection.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Overlaps(IEnumerable<T>)	- Determines whether the current set overlaps with the specified collection.
SetEquals(IEnumerable<T>)	- Determines whether the current set and the specified collection contain the same elements.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryGetAlternateLookup<TAlternate>(FrozenSet<T>.AlternateLookup<TAlternate>)	 - Gets an instance of a type that may be used to perform operations on a FrozenSet<T> using a TAlternate instead of a T.
TryGetValue(T, T)	- Searches the set for a given value and returns the equal value it finds, if any.

**/
namespace FrozenCollections{
    class FrozenMainClass{
        public static void Main(){
            Console.WriteLine("Frozen Collections .");
            Dictionary<int, string> test = new Dictionary<int, string>();
            test.Add(1,"one1");
            test.Add(2,"two");
            FrozenDictionary<int,string> frozenTest = test.ToFrozenDictionary();
            Console.WriteLine(frozenTest[1]);

            
            var set = new HashSet<int> { 1, 2, 3, 4, 5 };
            var frozenSet = set.ToFrozenSet();

            Console.WriteLine(frozenSet.Contains(3)); // Output: True

        }
    }
}