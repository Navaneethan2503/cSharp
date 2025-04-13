using System;
using System.Collections;

/**
Enumerates the elements of a nongeneric dictionary.
public interface IDictionaryEnumerator : System.Collections.IEnumerator

Properties:
-----------
1. Current	- Gets the element in the collection at the current position of the enumerator.(Inherited from IEnumerator)
2. Entry - Gets both the key and the value of the current dictionary entry.
    public System.Collections.DictionaryEntry Entry { get; }
    Entry is undefined under any of the following conditions:
    The enumerator is positioned before the first element in the collection, immediately after the enumerator is created. MoveNext must be called to advance the enumerator to the first element of the collection before reading the value of Entry.
    The last call to MoveNext returned false, which indicates the end of the collection.
    The enumerator is invalidated due to changes made in the collection, such as adding, modifying, or deleting elements.
    Entry returns the same object until MoveNext is called. MoveNext sets Entry to the next element.

3. Key	- Gets the key of the current dictionary entry.
    public object Key { get; }


4. Value - Gets the value of the current dictionary entry.
    public object? Value { get; }

**/
namespace IDictionaryEnumeratorNamespace{

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

    class IDictionaryEnumeratorClass{
        public static void Main(){
            Console.WriteLine("IDictionary Enumerator Interface...");
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
