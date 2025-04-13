using System;
using System.Collections.Generic;
/**
Represents a collection of key/value pairs that are sorted on the key.

public class SortedDictionary<TKey,TValue> : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>, System.Collections.Generic.IDictionary<TKey,TValue>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>, System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>, System.Collections.IDictionary

The SortedDictionary<TKey, TValue> class in C# is part of the System.Collections.Generic namespace and represents a collection of key/value pairs that are sorted by the keys. It is similar to the Dictionary<TKey, TValue> class but maintains the elements in sorted order based on the keys. Here are the key details about the SortedDictionary<TKey, TValue> class:

Key Features:
Sorted Order: The elements are automatically sorted by the keys.
Key/Value Pairs: Stores elements as key/value pairs, similar to a dictionary.
Performance: Provides O(log n) time complexity for lookups, insertions, and deletions due to its underlying balanced tree structure.
Dynamic Size: The size of the SortedDictionary<TKey, TValue> can dynamically increase or decrease as elements are added or removed.

The SortedDictionary<TKey,TValue> generic class is a binary search tree with O(log n) retrieval, where n is the number of elements in the dictionary. In this respect, it is similar to the SortedList<TKey,TValue> generic class. The two classes have similar object models, and both have O(log n) retrieval. Where the two classes differ is in memory use and speed of insertion and removal:

SortedList<TKey,TValue> uses less memory than SortedDictionary<TKey,TValue>.

SortedDictionary<TKey,TValue> has faster insertion and removal operations for unsorted data: O(log n) as opposed to O(n) for SortedList<TKey,TValue>.

If the list is populated all at once from sorted data, SortedList<TKey,TValue> is faster than SortedDictionary<TKey,TValue>.

Each key/value pair can be retrieved as a KeyValuePair<TKey,TValue> structure, or as a DictionaryEntry through the nongeneric IDictionary interface.

Keys must be immutable as long as they are used as keys in the SortedDictionary<TKey,TValue>. Every key in a SortedDictionary<TKey,TValue> must be unique. A key cannot be null, but a value can be, if the value type TValue is a reference type.

SortedDictionary<TKey,TValue> requires a comparer implementation to perform key comparisons. You can specify an implementation of the IComparer<T> generic interface by using a constructor that accepts a comparer parameter; if you do not specify an implementation, the default generic comparer Comparer<T>.Default is used. If type TKey implements the System.IComparable<T> generic interface, the default comparer uses that implementation.

The foreach statement of the C# language (for each in C++, For Each in Visual Basic) returns an object of the type of the elements in the collection. Since each element of the SortedDictionary<TKey,TValue> is a key/value pair, the element type is not the type of the key or the type of the value. Instead, the element type is KeyValuePair<TKey,TValue>. The following code shows C#, C++, and Visual Basic syntax.

The foreach statement is a wrapper around the enumerator, which allows only reading from the collection, not writing to it.

Properties:
----------
Comparer - Gets the IComparer<T> used to order the elements of the SortedDictionary<TKey,TValue>.
Count - Gets the number of key/value pairs contained in the SortedDictionary<TKey,TValue>.
Item[TKey]	- Gets or sets the value associated with the specified key.
Keys - Gets a collection containing the keys in the SortedDictionary<TKey,TValue>.
Values	- Gets a collection containing the values in the SortedDictionary<TKey,TValue>.

Methods:
--------
Add(TKey, TValue) - Adds an element with the specified key and value into the SortedDictionary<TKey,TValue>.
    You can also use the Item[] property to add new elements by setting the value of a key that does not exist in the SortedDictionary<TKey,TValue>; for example, myCollection["myNonexistentKey"] = myValue (in Visual Basic, myCollection("myNonexistantKey") = myValue). However, if the specified key already exists in the SortedDictionary<TKey,TValue>, setting the Item[] property overwrites the old value. In contrast, the Add method throws an exception if an element with the specified key already exists.
    A key cannot be null, but a value can be, if the value type TValue is a reference type.
    This method is an O(log n) operation, where n is Count.

Clear()	- Removes all elements from the SortedDictionary<TKey,TValue>.
ContainsKey(TKey) - Determines whether the SortedDictionary<TKey,TValue> contains an element with the specified key.
ContainsValue(TValue) - Determines whether the SortedDictionary<TKey,TValue> contains an element with the specified value.
CopyTo(KeyValuePair<TKey,TValue>[], Int32)	- Copies the elements of the SortedDictionary<TKey,TValue> to the specified array of KeyValuePair<TKey,TValue> structures, starting at the specified index.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator that iterates through the SortedDictionary<TKey,TValue>.
GetHashCode() - Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
Remove(TKey) - Removes the element with the specified key from the SortedDictionary<TKey,TValue>.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryGetValue(TKey, TValue) - Gets the value associated with the specified key.



**/
namespace SortedDictionaryNamespace{
    class SortedDictionaryClass{
        public static void Main(){
            Console.WriteLine("Sorted Dictionary...");
            // Create a new sorted dictionary of strings, with string
            // keys.
            SortedDictionary<string, string> openWith =
                new SortedDictionary<string, string>();

            // Add some elements to the dictionary. There are no
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is
            // already in the dictionary.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            Print(openWith);
        }

        public static void Print(SortedDictionary<string,string> ex){
            foreach(KeyValuePair<string,string> i in ex){
                Console.Write("Key :"+i.Key+ " ,Value :"+ i.Value + ",");
            }
            Console.WriteLine();
        }

    }
}