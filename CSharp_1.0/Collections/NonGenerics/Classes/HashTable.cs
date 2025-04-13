using System;
using System.Collections;
/**
Represents a collection of key/value pairs that are organized based on the hash code of the key.

Each element is a key/value pair stored in a DictionaryEntry object. A key cannot be null, but a value can be.

Key Features of HashTable:
-------------------------
Key-Value Pairs: Each entry in a HashTable is a key-value pair. The key is used to access the corresponding value.
Hashing: HashTables use a hash function to compute an index into an array of buckets or slots, from which the desired value can be found.
Non-Generic: Unlike Dictionary<TKey, TValue>, HashTable is non-generic, meaning it can store objects of any type.
Thread Safety: HashTable is thread-safe for use by multiple reader threads and a single writer thread. For multiple writers, you need to use synchronization.

Performance Considerations:
---------------------------
Time Complexity: The average time complexity for insertion, deletion, and lookup operations in a HashTable is O(1). However, in the worst case, it can degrade to O(n) if many keys hash to the same bucket.
Load Factor: The performance of a HashTable is affected by its load factor, which is the ratio of the number of elements to the number of buckets. A higher load factor means more collisions and potentially slower operations.


Properties:
-----------
comparer - Obsolete. - Gets or sets the IComparer to use for the Hashtable.
Count	- Gets the number of key/value pairs contained in the Hashtable.
EqualityComparer	- Gets the IEqualityComparer to use for the Hashtable.
hcp	- Obsolete. Gets or sets the object that can dispense hash codes.
IsFixedSize	- Gets a value indicating whether the Hashtable has a fixed size.
IsReadOnly	- Gets a value indicating whether the Hashtable is read-only.
IsSynchronized	- Gets a value indicating whether access to the Hashtable is synchronized (thread safe).
Item[Object]	- Gets or sets the value associated with the specified key.
Keys	- Gets an ICollection containing the keys in the Hashtable.
SyncRoot	- Gets an object that can be used to synchronize access to the Hashtable.
Values	- Gets an ICollection containing the values in the Hashtable.

Methods:
----------
Add(Object, Object)	- Adds an element with the specified key and value into the Hashtable.
Clear()	- Removes all elements from the Hashtable.
Clone()	- Creates a shallow copy of the Hashtable.
Contains(Object)	- Determines whether the Hashtable contains a specific key.
ContainsKey(Object)	- Determines whether the Hashtable contains a specific key.
ContainsValue(Object)	- Determines whether the Hashtable contains a specific value.
CopyTo(Array, Int32)	- Copies the Hashtable elements to a one-dimensional Array instance at the specified index.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an IDictionaryEnumerator that iterates through the Hashtable.
GetHash(Object)	- Returns the hash code for the specified key.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetObjectData(SerializationInfo, StreamingContext)	- Obsolete. Implements the ISerializable interface and returns the data needed to serialize the Hashtable.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
KeyEquals(Object, Object)	- Compares a specific Object with a specific key in the Hashtable.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
OnDeserialization(Object)	- Implements the ISerializable interface and raises the deserialization event when the deserialization is complete.
Remove(Object)	- Removes the element with the specified key from the Hashtable.
Synchronized(Hashtable)	- Returns a synchronized (thread-safe) wrapper for the Hashtable.
ToString()	- Returns a string that represents the current object.(Inherited from Object)


The objects used as keys by a Hashtable are required to override the Object.GetHashCode method (or the IHashCodeProvider interface) and the Object.Equals method (or the IComparer interface). The implementation of both methods and interfaces must handle case sensitivity the same way; otherwise, the Hashtable might behave incorrectly. For example, when creating a Hashtable, you must use the CaseInsensitiveHashCodeProvider class (or any case-insensitive IHashCodeProvider implementation) with the CaseInsensitiveComparer class (or any case-insensitive IComparer implementation).

Furthermore, these methods must produce the same results when called with the same parameters while the key exists in the Hashtable. An alternative is to use a Hashtable constructor with an IEqualityComparer parameter. If key equality were simply reference equality, the inherited implementation of Object.GetHashCode and Object.Equals would suffice.

Key objects must be immutable as long as they are used as keys in the Hashtable.

When an element is added to the Hashtable, the element is placed into a bucket based on the hash code of the key. Subsequent lookups of the key use the hash code of the key to search in only one particular bucket, thus substantially reducing the number of key comparisons required to find an element.

The load factor of a Hashtable determines the maximum ratio of elements to buckets. Smaller load factors cause faster average lookup times at the cost of increased memory consumption. The default load factor of 1.0 generally provides the best balance between speed and size. A different load factor can also be specified when the Hashtable is created.

As elements are added to a Hashtable, the actual load factor of the Hashtable increases. When the actual load factor reaches the specified load factor, the number of buckets in the Hashtable is automatically increased to the smallest prime number that is larger than twice the current number of Hashtable buckets.

Each key object in the Hashtable must provide its own hash function, which can be accessed by calling GetHash. However, any object implementing IHashCodeProvider can be passed to a Hashtable constructor, and that hash function is used for all objects in the table.

The capacity of a Hashtable is the number of elements the Hashtable can hold. As elements are added to a Hashtable, the capacity is automatically increased as required through reallocation.

.NET Framework only: For very large Hashtable objects, you can increase the maximum capacity to 2 billion elements on a 64-bit system by setting the enabled attribute of the <gcAllowVeryLargeObjects> configuration element to true in the run-time environment.

The foreach statement of the C# language (For Each in Visual Basic) returns an object of the type of the elements in the collection. Since each element of the Hashtable is a key/value pair, the element type is not the type of the key or the type of the value. Instead, the element type is DictionaryEntry.

**/
namespace HashtableNamespace{
    class HashTableClass{
        public static void Main(){
            Console.WriteLine("Hash Table !!!");
            // Creates and initializes a new Hashtable.
            var myHT = new Hashtable();
            myHT.Add("one", "The");
            myHT.Add("two", "quick");
            myHT.Add("three", "brown");
            myHT.Add("four", "fox");

            // Displays the Hashtable.
            Console.WriteLine("The Hashtable contains the following:");
            PrintKeysAndValues(myHT);

            foreach(var key in myHT.Keys){
                Console.WriteLine(key);
            }

            //Console.WriteLine("Access by Index :"+myHT[0]); - not accessable using index
        }

        public static void PrintKeysAndValues( Hashtable myHT )
        {
            Console.WriteLine("\t-KEY-\t-VALUE-");
            foreach (DictionaryEntry de in myHT)
                Console.WriteLine($"\t{de.Key}:\t{de.Value}");
            Console.WriteLine();
        }

    }
}