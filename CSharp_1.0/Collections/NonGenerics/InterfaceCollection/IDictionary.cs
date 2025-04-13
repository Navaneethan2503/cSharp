using System;
using System.Collections;
/**
The IDictionary interface in non-generic collections is part of the System.Collections namespace in .NET. It represents a collection of key/value pairs that are organized based on the key. 
This interface is used for collections that provide a mapping from keys to values, such as hash tables.

public interface IDictionary : System.Collections.ICollection

The IDictionary interface is the base interface for nongeneric collections of key/value pairs.

Each element is a key/value pair stored in a DictionaryEntry object.

Each pair must have a unique key. Implementations can vary in whether they allow the key to be null. The value can be null and does not have to be unique. The IDictionary interface allows the contained keys and values to be enumerated, but it does not imply any particular sort order.

IDictionary implementations fall into three categories: read-only, fixed-size, variable-size. A read-only IDictionary object cannot be modified. A fixed-size IDictionary object does not allow the addition or removal of elements, but does allow the modification of existing elements. A variable-size IDictionary object allows the addition, removal, and modification of elements.

The foreach statement of the C# language (For Each in Visual Basic) returns an object of the type of the elements in the collection. Since each element of the IDictionary object is a key/value pair, the element type is not the type of the key or the type of the value. Instead, the element type is DictionaryEntry.
foreach (DictionaryEntry de in myDictionary)
{
    //...
}

The foreach statement is a wrapper around the enumerator, which allows only reading from but not writing to the collection.


Properties:
-----------
1. Count - Gets the number of elements contained in the ICollection.(Inherited from ICollection)
2. IsFixedSize	- Gets a value indicating whether the IDictionary object has a fixed size.
    public bool IsFixedSize { get; }
    A collection with a fixed size does not allow the addition or removal of elements after the collection is created, but does allow the modification of existing elements.

3. IsReadOnly	- Gets a value indicating whether the IDictionary object is read-only.
        public bool IsReadOnly { get; }
        A collection that is read-only does not allow the addition, removal, or modification of elements after the collection is created.

4. IsSynchronized	- Gets a value indicating whether access to the ICollection is synchronized (thread safe).(Inherited from ICollection)
5. Item[Object] - Gets or sets the element with the specified key.
    public object? this[object key] { get; set; }
    This property provides the ability to access a specific element in the collection by using the following syntax: myCollection[key].
    You can also use the Item[] property to add new elements by setting the value of a key that does not exist in the dictionary (for example, myCollection["myNonexistentKey"] = myValue). However, if the specified key already exists in the dictionary, setting the Item[] property overwrites the old value. In contrast, the Add method does not modify existing elements.
    Implementations can vary in whether they allow the key to be null.
    The C# language uses the thisthis keyword to define the indexers instead of implementing the Item[] property. Visual Basic implements Item[] as a default property, which provides the same indexing functionality.

6. Keys - Gets an ICollection object containing the keys of the IDictionary object.
    public System.Collections.ICollection Keys { get; }
    The order of the keys in the returned ICollection object is unspecified, but is guaranteed to be the same order as the corresponding values in the ICollection returned by the Values property.

7. SyncRoot - Gets an object that can be used to synchronize access to the ICollection.(Inherited from ICollection)
8. Values	- Gets an ICollection object containing the values in the IDictionary object.
    public System.Collections.ICollection Values { get; }
    The order of the values in the returned ICollection object is unspecified, but is guaranteed to be the same order as the corresponding keys in the ICollection returned by the Keys property.


Methods:
---------
1. Add(Object, Object)	- Adds an element with the provided key and value to the IDictionary object.
    public void Add(object key, object? value);
    You can also use the Item[] property to add new elements by setting the value of a key that does not exist in the dictionary (for example, myCollection["myNonexistentKey"] = myValue). However, if the specified key already exists in the dictionary, setting the Item[] property overwrites the old value. In contrast, the Add method does not modify existing elements.

2. Clear()	- Removes all elements from the IDictionary object.
    public void Clear();

3. Contains(Object)- Determines whether the IDictionary object contains an element with the specified key.
    public bool Contains(object key);
    Starting with the .NET Framework 2.0, this method uses the collection's objects' Equals and CompareTo methods on item to determine whether item exists. In the earlier versions of the .NET Framework, this determination was made by using the Equals and CompareTo methods of the item parameter on the objects in the collection.

4. CopyTo(Array, Int32) - Copies the elements of the ICollection to an Array, starting at a particular Array index.(Inherited from ICollection)
5. GetEnumerator()	- Returns an IDictionaryEnumerator object for the IDictionary object.
    public System.Collections.IDictionaryEnumerator GetEnumerator();

6. Remove(Object)	- Removes the element with the specified key from the IDictionary object.
    public void Remove(object key);
    If the IDictionary object does not contain an element with the specified key, the IDictionary remains unchanged. No exception is thrown.

**/
namespace IDictionaryNamespace{
    // This class implements a simple dictionary using an array of DictionaryEntry objects (key/value pairs).
    public class SimpleDictionary : IDictionary
    {
        // The array of items
        private DictionaryEntry[] items;
        private Int32 ItemsInUse = 0;

        // Construct the SimpleDictionary with the desired number of items.
        // The number of items cannot change for the life time of this SimpleDictionary.
        public SimpleDictionary(Int32 numItems)
        {
            items = new DictionaryEntry[numItems];
        }

        #region IDictionary Members
        public bool IsReadOnly { get { return false; } }
        public bool Contains(object key)
        {
            Int32 index;
            return TryGetIndexOfKey(key, out index);
        }
        public bool IsFixedSize { get { return false; } }
        public void Remove(object key)
        {
            if (key == null) throw new ArgumentNullException("key");
            // Try to find the key in the DictionaryEntry array
            Int32 index;
            if (TryGetIndexOfKey(key, out index))
            {
                // If the key is found, slide all the items up.
                Array.Copy(items, index + 1, items, index, ItemsInUse - index - 1);
                ItemsInUse--;
            }
            else
            {
                // If the key is not in the dictionary, just return.
            }
        }
        public void Clear() { ItemsInUse = 0; }
        public void Add(object key, object value)
        {
            // Add the new key/value pair even if this key already exists in the dictionary.
            if (ItemsInUse == items.Length)
                throw new InvalidOperationException("The dictionary cannot hold any more items.");
            items[ItemsInUse++] = new DictionaryEntry(key, value);
        }
        public ICollection Keys
        {
            get
            {
                // Return an array where each item is a key.
                Object[] keys = new Object[ItemsInUse];
                for (Int32 n = 0; n < ItemsInUse; n++)
                    keys[n] = items[n].Key;
                return keys;
            }
        }
        public ICollection Values
        {
            get
            {
                // Return an array where each item is a value.
                Object[] values = new Object[ItemsInUse];
                for (Int32 n = 0; n < ItemsInUse; n++)
                    values[n] = items[n].Value;
                return values;
            }
        }
        public object this[object key]
        {
            get
            {
                // If this key is in the dictionary, return its value.
                Int32 index;
                if (TryGetIndexOfKey(key, out index))
                {
                    // The key was found; return its value.
                    return items[index].Value;
                }
                else
                {
                    // The key was not found; return null.
                    return null;
                }
            }

            set
            {
                // If this key is in the dictionary, change its value.
                Int32 index;
                if (TryGetIndexOfKey(key, out index))
                {
                    // The key was found; change its value.
                    items[index].Value = value;
                }
                else
                {
                    // This key is not in the dictionary; add this key/value pair.
                    Add(key, value);
                }
            }
        }
        private Boolean TryGetIndexOfKey(Object key, out Int32 index)
        {
            for (index = 0; index < ItemsInUse; index++)
            {
                // If the key is found, return true (the index is also returned).
                if (items[index].Key.Equals(key)) return true;
            }

            // Key not found, return false (index should be ignored by the caller).
            return false;
        }
        private class SimpleDictionaryEnumerator : IDictionaryEnumerator
        {
            // A copy of the SimpleDictionary object's key/value pairs.
            DictionaryEntry[] items;
            Int32 index = -1;

            public SimpleDictionaryEnumerator(SimpleDictionary sd)
            {
                // Make a copy of the dictionary entries currently in the SimpleDictionary object.
                items = new DictionaryEntry[sd.Count];
                Array.Copy(sd.items, 0, items, 0, sd.Count);
            }

            // Return the current item.
            public Object Current { get { ValidateIndex(); return items[index]; } }

            // Return the current dictionary entry.
            public DictionaryEntry Entry
            {
                get { return (DictionaryEntry) Current; }
            }

            // Return the key of the current item.
            public Object Key { get { ValidateIndex();  return items[index].Key; } }

            // Return the value of the current item.
            public Object Value { get { ValidateIndex();  return items[index].Value; } }

            // Advance to the next item.
            public Boolean MoveNext()
            {
                if (index < items.Length - 1) { index++; return true; }
                return false;
            }

            // Validate the enumeration index and throw an exception if the index is out of range.
            private void ValidateIndex()
            {
                if (index < 0 || index >= items.Length)
                throw new InvalidOperationException("Enumerator is before or after the collection.");
            }

            // Reset the index to restart the enumeration.
            public void Reset()
            {
                index = -1;
            }
        }
        public IDictionaryEnumerator GetEnumerator()
        {
            // Construct and return an enumerator.
            return new SimpleDictionaryEnumerator(this);
        }
        #endregion

        #region ICollection Members
        public bool IsSynchronized { get { return false; } }
        public object SyncRoot { get { throw new NotImplementedException(); } }
        public int Count { get { return ItemsInUse; } }
        public void CopyTo(Array array, int index) { throw new NotImplementedException(); }
        #endregion

        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Construct and return an enumerator.
            return ((IDictionary)this).GetEnumerator();
        }
        #endregion
    }

    class IDictionaryClass{
        public static void Main(){
            Console.WriteLine("IDictionary Interface ...");
            // Create a dictionary that contains no more than three entries.
            IDictionary d = new SimpleDictionary(3);

            // Add three people and their ages to the dictionary.
            d.Add("Jeff", 40);
            d.Add("Kristin", 34);
            d.Add("Aidan", 1);

            Console.WriteLine("Number of elements in dictionary = {0}", d.Count);

            Console.WriteLine("Does dictionary contain 'Jeff'? {0}", d.Contains("Jeff"));
            Console.WriteLine("Jeff's age is {0}", d["Jeff"]);

            // Display every entry's key and value.
            foreach (DictionaryEntry de in d)
            {
                Console.WriteLine("{0} is {1} years old.", de.Key, de.Value);
            }

            // Remove an entry that exists.
            d.Remove("Jeff");

            // Remove an entry that does not exist, but do not throw an exception.
            d.Remove("Max");

            // Show the names (keys) of the people in the dictionary.
            foreach (String s in d.Keys)
                Console.WriteLine(s);

            // Show the ages (values) of the people in the dictionary.
            foreach (Int32 age in d.Values)
                Console.WriteLine(age);
        }
    }
}