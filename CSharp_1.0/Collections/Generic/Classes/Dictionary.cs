using System;
using System.Collections.Generic;
/**
Properties:
----------
Capacity - Gets the total numbers of elements the internal data structure can hold without resizing.
Comparer -Gets the IEqualityComparer<T> that is used to determine equality of keys for the dictionary.
Count	- Gets the number of key/value pairs contained in the Dictionary<TKey,TValue>.
Item[TKey]	- Gets or sets the value associated with the specified key.
Keys	- Gets a collection containing the keys in the Dictionary<TKey,TValue>.
Values	- Gets a collection containing the values in the Dictionary<TKey,TValue>.

Methods:
---------
Add(TKey, TValue)	- Adds the specified key and value to the dictionary.
    public void Add(TKey key, TValue value);

Clear()	-Removes all keys and values from the Dictionary<TKey,TValue>.
ContainsKey(TKey)	- Determines whether the Dictionary<TKey,TValue> contains the specified key.
    this method approaches an O(1) operation.

ContainsValue(TValue)	- Determines whether the Dictionary<TKey,TValue> contains a specific value.
EnsureCapacity(Int32)	- Ensures that the dictionary can hold up to a specified number of entries without any further expansion of its backing storage.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetAlternateLookup<TAlternateKey>()	- Gets an instance of a type that can be used to perform operations on the current Dictionary<TKey,TValue> using a TAlternateKey as a key instead of a TKey.
GetEnumerator()	- Returns an enumerator that iterates through the Dictionary<TKey,TValue>.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetObjectData(SerializationInfo, StreamingContext)	- Obsolete. Implements the ISerializable interface and returns the data needed to serialize the Dictionary<TKey,TValue> instance.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
OnDeserialization(Object)	- Implements the ISerializable interface and raises the deserialization event when the deserialization is complete.
Remove(TKey, TValue)	- Removes the value with the specified key from the Dictionary<TKey,TValue>, and copies the element to the value parameter.
Remove(TKey)	- Removes the value with the specified key from the Dictionary<TKey,TValue>.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TrimExcess()	- Sets the capacity of this dictionary to what it would be if it had been originally initialized with all its entries.
TrimExcess(Int32)	- Sets the capacity of this dictionary to hold up a specified number of entries without any further expansion of its backing storage.
TryAdd(TKey, TValue)	- Attempts to add the specified key and value to the dictionary.
TryGetAlternateLookup<TAlternateKey>(Dictionary<TKey,TValue>.AlternateLookup<TAlternateKey>) - Gets an instance of a type that can be used to perform operations on the current Dictionary<TKey,TValue> using a TAlternateKey as a key instead of a TKey.
TryGetValue(TKey, TValue)	- Gets the value associated with the specified key.

**/
namespace DictionaryNamespace{
    class DictionaryClass{
        public static void Main(){
            Console.WriteLine("Dictionary Generic Collections.");
            Dictionary<string,int> test = new Dictionary<string,int>();
            Console.WriteLine("Count :"+test.Count+" Capacity :"+ test.Capacity);
            Console.WriteLine("Comparer :"+ test.Comparer);
            test.Add("nic",1);
            Console.WriteLine("Count :"+test.Count+" Capacity :"+ test.Capacity);
            Console.WriteLine(test.ContainsKey("nic"));
            Console.WriteLine(test.ContainsValue(1));
            test.TrimExcess(15);
            Console.WriteLine("Trim set Count :"+test.Count+" Capacity :"+ test.Capacity);
            test.EnsureCapacity(11);
            Console.WriteLine("ensure Count :"+test.Count+" Capacity :"+ test.Capacity);
            Console.WriteLine("Try add duplicate :"+test.TryAdd("nic",1));
            int output;
            Console.WriteLine("Try Get value :"+test.TryGetValue("nic1",out output)+"Value :"+ output);

        }
    }
}