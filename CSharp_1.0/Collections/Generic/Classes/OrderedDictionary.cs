using System;
using System.Collections.Generic;
/**

Key Features:
Ordered Elements: Maintains the order of elements based on the sequence in which they were added.
Key/Value Pairs: Stores elements as key/value pairs, similar to a dictionary.
Index Access: Allows access to elements by their index, similar to a list.
Dynamic Size: The size of the OrderedDictionary<TKey, TValue> can dynamically increase or decrease as elements are added or removed.

The OrderedDictionary<TKey, TValue> class combines features of both a list and a dictionary. It maintains the order of elements and allows access by both key and index. Here are the complexities for common operations:
    Insertion: O(n) in the worst case, because elements may need to be shifted to maintain order.
    Removal: O(n) in the worst case, because elements may need to be shifted to maintain order.
    Lookup by Key: O(1) on average, similar to a dictionary, because it uses a hash table for key lookups.
    Lookup by Index: O(1), similar to a list, because it maintains an internal list for index-based access.

Properties:
-----------
Capacity - Gets the total number of key/value pairs the internal data structure can hold without resizing.
Comparer - Gets the IEqualityComparer<T> that is used to determine equality of keys for the dictionary.
Count - Gets the number of elements contained in the ICollection<T>.
Item[TKey]	- Gets or sets the element with the specified key.
Keys - Gets a collection containing the keys in the OrderedDictionary<TKey,TValue>.
Values - Gets a collection containing the values in the OrderedDictionary<TKey,TValue>.

Methods:
---------
Add(TKey, TValue) - Adds an element with the provided key and value to the IDictionary<TKey,TValue>.
Clear()	- Removes all items from the ICollection<T>.
ContainsKey(TKey) - Determines whether the IDictionary<TKey,TValue> contains an element with the specified key.
ContainsValue(TValue) - Determines whether the OrderedDictionary<TKey,TValue> contains a specific value.
EnsureCapacity(Int32)- Ensures that the dictionary can hold up to capacity entries without resizing.
Equals(Object)	-  Determines whether the specified object is equal to the current object.(Inherited from Object)
GetAt(Int32) - Gets the key/value pair at the specified index.
GetEnumerator()	- Returns an enumerator that iterates through the OrderedDictionary<TKey,TValue>.
GetHashCode() - Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
IndexOf(TKey) - Determines the index of a specific key in the OrderedDictionary<TKey,TValue>.
Insert(Int32, TKey, TValue)	- Inserts an item into the collection at the specified index.
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
Remove(TKey, TValue) - Removes the value with the specified key from the OrderedDictionary<TKey,TValue> and copies the element to the value parameter.
Remove(TKey) - Removes the element with the specified key from the IDictionary<TKey,TValue>.
RemoveAt(Int32)	- Removes the IList<T> item at the specified index.
SetAt(Int32, TKey, TValue)	- Sets the key/value pair at the specified index.
SetAt(Int32, TValue) - Sets the value for the key at the specified index.
ToString()	-  Returns a string that represents the current object.(Inherited from Object)
TrimExcess() - Sets the capacity of this dictionary to what it would be if it had been originally initialized with all its entries.
TrimExcess(Int32) - Sets the capacity of this dictionary to hold up a specified number of entries without resizing.
TryAdd(TKey, TValue) - Adds the specified key and value to the dictionary if the key doesn't already exist.
TryGetValue(TKey, TValue)	- Gets the value associated with the specified key.


**/
namespace OrderedDictionaryNamespace{
    class OrderedDictionaryClass{
        public static void Main(){
            Console.WriteLine("Ordered Dictionary Collections.");
            OrderedDictionary<int,string> test = new OrderedDictionary<int,string>();
            test.Add(1,"one");
            test.Add(10,"ten");
            test.Add(5,"five");
            test.Add(4,"four");
            Print(test);
            Console.WriteLine(test.GetAt(2).Key+ " - "+ test.GetAt(2).Value);
        }

        public static void Print(OrderedDictionary<int,string> ex){
            foreach(KeyValuePair<int,string> i in ex){
                Console.Write("Key :"+i.Key+ " ,Value :"+ i.Value + ",");
            }
            Console.WriteLine();
        }
    }
}