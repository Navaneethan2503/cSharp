using System;
using System.Collections.Generic;
/**
Represents a collection of key/value pairs that are sorted by key based on the associated IComparer<T> implementation.

    public class SortedList<TKey,TValue> : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>, System.Collections.Generic.IDictionary<TKey,TValue>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>, System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>, System.Collections.IDictionary

The SortedList<TKey,TValue> generic class is an array of key/value pairs with O(log n) retrieval, where n is the number of elements in the dictionary. In this, it is similar to the SortedDictionary<TKey,TValue> generic class. The two classes have similar object models, and both have O(log n) retrieval. Where the two classes differ is in memory use and speed of insertion and removal:

SortedList<TKey,TValue> uses less memory than SortedDictionary<TKey,TValue>.

SortedDictionary<TKey,TValue> has faster insertion and removal operations for unsorted data, O(log n) as opposed to O(n) for SortedList<TKey,TValue>.

If the list is populated all at once from sorted data, SortedList<TKey,TValue> is faster than SortedDictionary<TKey,TValue>.

Another difference between the SortedDictionary<TKey,TValue> and SortedList<TKey,TValue> classes is that SortedList<TKey,TValue> supports efficient indexed retrieval of keys and values through the collections returned by the Keys and Values properties. It is not necessary to regenerate the lists when the properties are accessed, because the lists are just wrappers for the internal arrays of keys and values. The following code shows the use of the Values property for indexed retrieval of values from a sorted list of strings:

string v = mySortedList.Values[3];

SortedList<TKey,TValue> is implemented as an array of key/value pairs, sorted by the key. Each element can be retrieved as a KeyValuePair<TKey,TValue> object.

Key objects must be immutable as long as they are used as keys in the SortedList<TKey,TValue>. Every key in a SortedList<TKey,TValue> must be unique. A key cannot be null, but a value can be, if the type of values in the list, TValue, is a reference type.

SortedList<TKey,TValue> requires a comparer implementation to sort and to perform comparisons. The default comparer Comparer<T>.Default checks whether the key type TKey implements System.IComparable<T> and uses that implementation, if available. If not, Comparer<T>.Default checks whether the key type TKey implements System.IComparable. If the key type TKey does not implement either interface, you can specify a System.Collections.Generic.IComparer<T> implementation in a constructor overload that accepts a comparer parameter.

The capacity of a SortedList<TKey,TValue> is the number of elements the SortedList<TKey,TValue> can hold. As elements are added to a SortedList<TKey,TValue>, the capacity is automatically increased as required by reallocating the internal array. The capacity can be decreased by calling TrimExcess or by setting the Capacity property explicitly. Decreasing the capacity reallocates memory and copies all the elements in the SortedList<TKey,TValue>.

.NET Framework only: For very large SortedList<TKey,TValue> objects, you can increase the maximum capacity to 2 billion elements on a 64-bit system by setting the enabled attribute of the <gcAllowVeryLargeObjects> configuration element to true in the run-time environment.

The foreach statement of the C# language (for each in C++, For Each in Visual Basic) returns an object of the type of the elements in the collection. Since the elements of the SortedList<TKey,TValue> are key/value pairs, the element type is not the type of the key or the type of the value. Instead, the element type is KeyValuePair<TKey,TValue>.

Key Features:
Sorted Order: The elements are automatically sorted by the keys.
Key/Value Pairs: Stores elements as key/value pairs, similar to a dictionary.
Index Access: Allows access to elements by their index, similar to a list.
Performance: Provides O(log n) time complexity for lookups and O(n) for insertions and deletions due to the need to maintain order.

Properties:
-----------
Capacity - Gets or sets the number of elements that the SortedList<TKey,TValue> can contain.
Comparer - Gets the IComparer<T> for the sorted list.
Count - Gets the number of key/value pairs contained in the SortedList<TKey,TValue>.
Item[TKey]	- Gets or sets the value associated with the specified key.
Keys - Gets a collection containing the keys in the SortedList<TKey,TValue>, in sorted order.
Values	- Gets a collection containing the values in the SortedList<TKey,TValue>.


Methods:
--------
Add(TKey, TValue) - Adds an element with the specified key and value into the SortedList<TKey,TValue>.
    A key cannot be null, but a value can be, if the type of values in the sorted list, TValue, is a reference type.
    You can also use the Item[] property to add new elements by setting the value of a key that does not exist in the SortedList<TKey,TValue>; for example, myCollection["myNonexistentKey"] = myValue. However, if the specified key already exists in the SortedList<TKey,TValue>, setting the Item[] property overwrites the old value. In contrast, the Add method does not modify existing elements.
    If Count already equals Capacity, the capacity of the SortedList<TKey,TValue> is increased by automatically reallocating the internal array, and the existing elements are copied to the new array before the new element is added.
    This method is an O(n) operation for unsorted data, where n is Count. It is an O(log n) operation if the new element is added at the end of the list. If insertion causes a resize, the operation is O(n).

Clear()	- Removes all elements from the SortedList<TKey,TValue>.
ContainsKey(TKey)	- Determines whether the SortedList<TKey,TValue> contains a specific key.
    This method is an O(log n) operation, where n is Count.
ContainsValue(TValue)	- Determines whether the SortedList<TKey,TValue> contains a specific value.
    This method is an O(log n) operation, where n is Count.

Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator that iterates through the SortedList<TKey,TValue>.
GetHashCode() - Serves as the default hash function.(Inherited from Object)
GetKeyAtIndex(Int32) - Gets the key corresponding to the specified index.
GetType() - Gets the Type of the current instance.(Inherited from Object)
GetValueAtIndex(Int32)	- Gets the value corresponding to the specified index.
IndexOfKey(TKey) - Searches for the specified key and returns the zero-based index within the entire SortedList<TKey,TValue>.
IndexOfValue(TValue) - Searches for the specified value and returns the zero-based index of the first occurrence within the entire SortedList<TKey,TValue>.

        This method performs a binary search; therefore, this method is an O(log n) operation, where n is Count.
        
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
Remove(TKey) - Removes the element with the specified key from the SortedList<TKey,TValue>.
RemoveAt(Int32)	- Removes the element at the specified index of the SortedList<TKey,TValue>.
SetValueAtIndex(Int32, TValue) - Updates the value corresponding to the specified index.
ToString() - Returns a string that represents the current object.(Inherited from Object)
TrimExcess() - Sets the capacity to the actual number of elements in the SortedList<TKey,TValue>, if that number is less than 90 percent of current capacity.
TryGetValue(TKey, TValue) - Gets the value associated with the specified key.



**/
namespace SortedListNamespaceGeneric{
    class SortedListClass{
        public static void Main(){
            Console.WriteLine("Sorted List Collections.");
            SortedList<int,string> test = new SortedList<int,string>();
            Console.WriteLine("Count :"+ test.Count+ " Capacity :"+ test.Capacity); 
            test.Add(5,"Five");
            test.Add(3,"Three");
            test.Add(1,"One");
            test.Add(2, "Two");
            Print(test);

            //Keys
            foreach(var i in test.Keys){
                Console.Write(i+",");
            }
            Console.WriteLine();

            //Value
            foreach(var i in test.Values){
                Console.Write(i+",");
            }
            Console.WriteLine();
            Console.WriteLine("Count :"+ test.Count+ " Capacity :"+ test.Capacity); 
        }

        public static void Print(SortedList<int,string> ex){
            foreach(KeyValuePair<int,string> i in ex){
                Console.Write("Key :"+i.Key+ " ,Value :"+ i.Value + ",");
            }
            Console.WriteLine();
        }
    }
}