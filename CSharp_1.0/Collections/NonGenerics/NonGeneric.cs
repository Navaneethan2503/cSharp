using System;
using System.Collections;
/**
Non-generic collections store items as Object, require casting, and most aren't supported for Windows Store app development. However, you might see non-generic collections in older code.

In .NET Framework 4 and later versions, the collections in the System.Collections.Concurrent namespace provide efficient thread-safe operations for accessing collection items from multiple threads. 
The immutable collection classes in the System.Collections.Immutable namespace (NuGet package) are inherently thread-safe because operations are performed on a copy of the original collection, and the original collection can't be modified.

Common collection features:
All collections provide methods for adding, removing, or finding items in the collection. In addition, all collections that directly or indirectly implement the ICollection interface or the ICollection<T> interface share these features:
1. The ability to enumerate the collection
2. The ability to copy the collection contents to an array
3. Capacity and Count properties
4. A consistent lower bound
5. Synchronization for access from multiple threads (System.Collections classes only).

DictionaryEntry Struct:
-----------------------
Defines a dictionary key/value pair that can be set or retrieved.
    public struct DictionaryEntry

Properties:
--------------
Key	- Gets or sets the key in the key/value pair.
Value - Gets or sets the value in the key/value pair.

Classess:
--------
ArrayList	- Implements the IList interface using an array whose size is dynamically increased as required.
BitArray	- Manages a compact array of bit values, which are represented as Booleans, where true indicates that the bit is on (1) and false indicates the bit is off (0).
CaseInsensitiveComparer	- Compares two objects for equivalence, ignoring the case of strings.
CaseInsensitiveHashCodeProvider	- Supplies a hash code for an object, using a hashing algorithm that ignores the case of strings.
CollectionBase	- Provides the abstract base class for a strongly typed collection.
Comparer	- Compares two objects for equivalence, where string comparisons are case-sensitive.
DictionaryBase	- Provides the abstract base class for a strongly typed collection of key/value pairs.
Hashtable	- Represents a collection of key/value pairs that are organized based on the hash code of the key.
Queue	- Represents a first-in, first-out collection of objects.
ReadOnlyCollectionBase	- Provides the abstract base class for a strongly typed non-generic read-only collection.
SortedList	- Represents a collection of key/value pairs that are sorted by the keys and are accessible by key and by index.
Stack	- Represents a simple last-in-first-out (LIFO) non-generic collection of objects.
StructuralComparisons	- Provides objects for performing a structural comparison of two collection objects.

**/
namespace NonGenericCollection{
    class NonGenericCollection{
        public static void Main(){
            Console.WriteLine("Non Generic Collection...");
            // Create a new hash table.
            //
            Hashtable openWith = new Hashtable();

            // Add some elements to the hash table. There are no
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // When you use foreach to enumerate hash table elements,
            // the elements are retrieved as DictionaryEntry objects.
            Console.WriteLine();
            foreach (DictionaryEntry de in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }
        }
    }
}