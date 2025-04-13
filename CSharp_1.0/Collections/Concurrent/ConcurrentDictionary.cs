using System;
using System.Collections.Concurrent;
/**
Concurrent collections in C# are part of the System.Collections.Concurrent namespace. These collections are designed to handle multi-threaded scenarios and provide thread-safe operations without the need for additional synchronization mechanisms. They are optimized for performance and scalability, making them ideal for applications that require concurrent access to shared data.

Key Features of Concurrent Collections
Thread Safety: Concurrent collections are inherently thread-safe, meaning multiple threads can safely access and modify the collection simultaneously.
Performance: These collections are optimized for performance, reducing contention and improving scalability in multi-threaded environments.
Atomic Operations: Concurrent collections provide atomic operations, ensuring that complex operations are performed safely without race conditions.

Provides several thread-safe collection classes that should be used in place of the corresponding types in the System.Collections and System.Collections.Generic namespaces whenever multiple threads are accessing the collection concurrently.

However, access to elements of a collection object through extension methods or through explicit interface implementations are not guaranteed to be thread-safe and may need to be synchronized by the caller.

For very large ConcurrentDictionary<TKey,TValue> objects, you can increase the maximum array size to 2 gigabytes (GB) on a 64-bit system by setting the <gcAllowVeryLargeObjects> configuration element to true in the run-time environment.

Like the System.Collections.Generic.Dictionary<TKey,TValue> class, ConcurrentDictionary<TKey,TValue> implements the IDictionary<TKey,TValue> interface. In addition, ConcurrentDictionary<TKey,TValue> provides several methods for adding or updating key/value pairs in the dictionary, as described in the following table.

To do this	Use this method	Usage notes
Add a new key to the dictionary, if it doesn't already exist in the dictionary	TryAdd	This method adds the specified key/value pair, if the key doesn't currently exist in the dictionary. The method returns true or false depending on whether the new pair was added.
Update the value for an existing key in the dictionary, if that key has a specific value	TryUpdate	This method checks whether the key has a specified value, and if it does, updates the key with a new value. It's similar to the CompareExchange method, except that it's used for dictionary elements.
Store a key/value pair in the dictionary unconditionally, and overwrite the value of a key that already exists	The indexer's setter: dictionary[key] = newValue	
Add a key/value pair to the dictionary, or if the key already exists, update the value for the key based on the key's existing value	AddOrUpdate(TKey, Func<TKey,TValue>, Func<TKey,TValue,TValue>)

-or-

AddOrUpdate(TKey, TValue, Func<TKey,TValue,TValue>)	AddOrUpdate(TKey, Func<TKey,TValue>, Func<TKey,TValue,TValue>) accepts the key and two delegates. It uses the first delegate if the key doesn't exist in the dictionary; it accepts the key and returns the value that should be added for the key. It uses the second delegate if the key does exist; it accepts the key and its current value, and it returns the new value that should be set for the key.

AddOrUpdate(TKey, TValue, Func<TKey,TValue,TValue>) accepts the key, a value to add, and the update delegate. This is the same as the previous overload, except that it doesn't use a delegate to add a key.
Get the value for a key in the dictionary, adding the value to the dictionary and returning it if the key doesn't exist	GetOrAdd(TKey, TValue)

-or-

GetOrAdd(TKey, Func<TKey,TValue>)	These overloads provide lazy initialization for a key/value pair in the dictionary, adding the value only if it's not there.

GetOrAdd(TKey, TValue) takes the value to be added if the key doesn't exist.

GetOrAdd(TKey, Func<TKey,TValue>) takes a delegate that will generate the value if the key doesn't exist.
All these operations are atomic and are thread-safe with regards to all other operations on the ConcurrentDictionary<TKey,TValue> class. The only exceptions are the methods that accept a delegate, that is, AddOrUpdate and GetOrAdd. For modifications and write operations to the dictionary, ConcurrentDictionary<TKey,TValue> uses fine-grained locking to ensure thread safety. (Read operations on the dictionary are performed in a lock-free manner.) However, delegates for these methods are called outside the locks to avoid the problems that can arise from executing unknown code under a lock. Therefore, the code executed by these delegates is not subject to the atomicity of the operation.

Properties:
----------
Comparer - Gets the IEqualityComparer<T> that is used to determine equality of keys for the dictionary.
Count	- Gets the number of key/value pairs contained in the ConcurrentDictionary<TKey,TValue>.
IsEmpty	- Gets a value that indicates whether the ConcurrentDictionary<TKey,TValue> is empty.
Item[TKey]	- Gets or sets the value associated with the specified key.
Keys	- Gets a collection containing the keys in the Dictionary<TKey,TValue>.
Values	- Gets a collection that contains the values in the Dictionary<TKey,TValue>.

Methods:
--------
AddOrUpdate(TKey, Func<TKey,TValue>, Func<TKey,TValue,TValue>)	 - Uses the specified functions to add a key/value pair to the ConcurrentDictionary<TKey,TValue> if the key does not already exist, or to update a key/value pair in the ConcurrentDictionary<TKey,TValue> if the key already exists.
AddOrUpdate(TKey, TValue, Func<TKey,TValue,TValue>)	- Adds a key/value pair to the ConcurrentDictionary<TKey,TValue> if the key does not already exist, or updates a key/value pair in the ConcurrentDictionary<TKey,TValue> by using the specified function if the key already exists.
AddOrUpdate<TArg>(TKey, Func<TKey,TArg,TValue>, Func<TKey,TValue,TArg,TValue>, TArg)	- Uses the specified functions and argument to add a key/value pair to the ConcurrentDictionary<TKey,TValue> if the key does not already exist, or to update a key/value pair in the ConcurrentDictionary<TKey,TValue> if the key already exists.
Clear()	- Removes all keys and values from the ConcurrentDictionary<TKey,TValue>.
ContainsKey(TKey)	- Determines whether the ConcurrentDictionary<TKey,TValue> contains the specified key.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetAlternateLookup<TAlternateKey>()	- Gets an instance of a type that may be used to perform operations on a ConcurrentDictionary<TKey,TValue>
using a TAlternateKey as a key instead of a TKey.
GetEnumerator()	- Returns an enumerator that iterates through the ConcurrentDictionary<TKey,TValue>.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetOrAdd(TKey, Func<TKey,TValue>) - Adds a key/value pair to the ConcurrentDictionary<TKey,TValue> by using the specified function if the key does not already exist. Returns the new value, or the existing value if the key exists.
GetOrAdd(TKey, TValue)	- Adds a key/value pair to the ConcurrentDictionary<TKey,TValue> if the key does not already exist. Returns the new value, or the existing value if the key exists.
GetOrAdd<TArg>(TKey, Func<TKey,TArg,TValue>, TArg)	- Adds a key/value pair to the ConcurrentDictionary<TKey,TValue> by using the specified function and an argument if the key does not already exist, or returns the existing value if the key exists.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
ToArray() - Copies the key and value pairs stored in the ConcurrentDictionary<TKey,TValue> to a new array.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryAdd(TKey, TValue) -  Attempts to add the specified key and value to the ConcurrentDictionary<TKey,TValue>.
TryGetAlternateLookup<TAlternateKey>(ConcurrentDictionary<TKey,TValue>.AlternateLookup<TAlternateKey>)	- Gets an instance of a type that may be used to perform operations on a ConcurrentDictionary<TKey,TValue> using a TAlternateKey as a key instead of a TKey.
TryGetValue(TKey, TValue)	- Attempts to get the value associated with the specified key from the ConcurrentDictionary<TKey,TValue>.
TryRemove(KeyValuePair<TKey,TValue>)	- Removes a key and value from the dictionary.
TryRemove(TKey, TValue)	- Attempts to remove and return the value that has the specified key from the ConcurrentDictionary<TKey,TValue>.
TryUpdate(TKey, TValue, TValue)	- Updates the value associated with key to newValue if the existing value with key is equal to comparisonValue.


**/
namespace ConcurrentCollections{
    class ConcurrentDictionaryClass{
        public static void Main(){
            Console.WriteLine("Concurrent Dictionary.");
            // We know how many items we want to insert into the ConcurrentDictionary.
            // So set the initial capacity to some prime number above that, to ensure that
            // the ConcurrentDictionary does not need to be resized while initializing it.
            int NUMITEMS = 64;
            int initialCapacity = 101;

            // The higher the concurrencyLevel, the higher the theoretical number of operations
            // that could be performed concurrently on the ConcurrentDictionary.  However, global
            // operations like resizing the dictionary take longer as the concurrencyLevel rises.
            // For the purposes of this example, we'll compromise at numCores * 2.
            int numProcs = Environment.ProcessorCount;
            int concurrencyLevel = numProcs * 2;

            // Construct the dictionary with the desired concurrencyLevel and initialCapacity
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);

            // Initialize the dictionary
            for (int i = 0; i < NUMITEMS; i++) cd[i] = i * i;

            Console.WriteLine("The square of 23 is {0} (should be {1})", cd[23], 23 * 23);

            
            ConcurrentDictionary<string, int> dictionary = new ConcurrentDictionary<string, int>();
            dictionary["Alice"] = 30;
            dictionary["Bob"] = 25;

            dictionary.AddOrUpdate("Charlie", 35, (key, oldValue) => oldValue + 1);
            dictionary.AddOrUpdate("Charlie", 35, (key, oldValue) => oldValue + 1);

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }


        }
    }
}