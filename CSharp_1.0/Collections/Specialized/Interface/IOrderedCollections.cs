using System;
using System.Collections.Specialized;
using System.Collections;
/**
Represents an indexed collection of key/value pairs.
IOrderedDictionary elements can be accessed either with the key or with the index.

Each element is a key/value pair stored in a DictionaryEntry structure.

Each pair must have a unique key that is not null, but the value can be null and does not have to be unique. The IOrderedDictionary interface allows the contained keys and values to be enumerated, but it does not imply any particular sort order.

The foreach statement of the C# language (For Each in Visual Basic) returns an object of the type of the elements in the collection. Because each element of the IDictionary is a key/value pair, the element type is not the type of the key or the type of the value. Instead, the element type is DictionaryEntry, as the following example shows.

The foreach statement is a wrapper around the enumerator, which allows only reading from, not writing to, the collection.

Properties:
-----------
Count -Gets the number of elements contained in the ICollection.(Inherited from ICollection)
IsFixedSize	- Gets a value indicating whether the IDictionary object has a fixed size.(Inherited from IDictionary)
IsReadOnly -Gets a value indicating whether the IDictionary object is read-only.(Inherited from IDictionary)
IsSynchronized	 - Gets a value indicating whether access to the ICollection is synchronized (thread safe).(Inherited from ICollection)
Item[Int32]	- Gets or sets the element at the specified index.
Item[Object]	- Gets or sets the element with the specified key.(Inherited from IDictionary)
Keys -Gets an ICollection object containing the keys of the IDictionary object.(Inherited from IDictionary)
SyncRoot - Gets an object that can be used to synchronize access to the ICollection.(Inherited from ICollection)
Values	- Gets an ICollection object containing the values in the IDictionary object.(Inherited from IDictionary)


Methods:
-------
Add(Object, Object)	- Adds an element with the provided key and value to the IDictionary object.(Inherited from IDictionary)
Clear()	- Removes all elements from the IDictionary object.(Inherited from IDictionary)
Contains(Object) - Determines whether the IDictionary object contains an element with the specified key.(Inherited from IDictionary)
CopyTo(Array, Int32) - Copies the elements of the ICollection to an Array, starting at a particular Array index.(Inherited from ICollection)
GetEnumerator() - Returns an enumerator that iterates through the IOrderedDictionary collection.
Insert(Int32, Object, Object)	-  Inserts a key/value pair into the collection at the specified index.
Remove(Object)	- Removes the element with the specified key from the IDictionary object.(Inherited from IDictionary)
RemoveAt(Int32) - Removes the element at the specified index.



**/
namespace IOreredCollections{
    public class People : IOrderedDictionary
    {
        private ArrayList _people;

        public People(int numItems)
        {
            _people = new ArrayList(numItems);
        }

        public int IndexOfKey(object key)
        {
            for (int i = 0; i < _people.Count; i++)
            {
                if (((DictionaryEntry)_people[i]).Key == key)
                    return i;
            }

            // key not found, return -1.
            return -1;
        }

        public object this[object key]
        {
            get
            {
                return ((DictionaryEntry)_people[IndexOfKey(key)]).Value;
            }
            set
            {
                _people[IndexOfKey(key)] = new DictionaryEntry(key, value);
            }
        }

        // IOrderedDictionary Members
        public IDictionaryEnumerator GetEnumerator()
        {
            return new PeopleEnum(_people);
        }

        public void Insert(int index, object key, object value)
        {
            if (IndexOfKey(key) != -1)
            {
                throw new ArgumentException("An element with the same key already exists in the collection.");
            }
            _people.Insert(index, new DictionaryEntry(key, value));
        }

        public void RemoveAt(int index)
        {
            _people.RemoveAt(index);
        }

        public object this[int index]
        {
            get
            {
                return ((DictionaryEntry)_people[index]).Value;
            }
            set
            {
                object key = ((DictionaryEntry)_people[index]).Key;
                _people[index] = new DictionaryEntry(key, value);
            }
        }
        // IDictionary Members

        public void Add(object key, object value)
        {
            if (IndexOfKey(key) != -1)
            {
                throw new ArgumentException("An element with the same key already exists in the collection.");
            }
            _people.Add(new DictionaryEntry(key, value));
        }

        public void Clear()
        {
            _people.Clear();
        }

        public bool Contains(object key)
        {
            if (IndexOfKey(key) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection Keys
        {
            get
            {
                ArrayList KeyCollection = new ArrayList(_people.Count);
                for (int i = 0; i < _people.Count; i++)
                {
                    KeyCollection.Add( ((DictionaryEntry)_people[i]).Key );
                }
                return KeyCollection;
            }
        }

        public void Remove(object key)
        {
            _people.RemoveAt(IndexOfKey(key));
        }

        public ICollection Values
        {
            get
            {
                ArrayList ValueCollection = new ArrayList(_people.Count);
                for (int i = 0; i < _people.Count; i++)
                {
                    ValueCollection.Add( ((DictionaryEntry)_people[i]).Value );
                }
                return ValueCollection;
            }
        }

        // ICollection Members

        public void CopyTo(Array array, int index)
        {
            _people.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return _people.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return _people.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get
            {
                return _people.SyncRoot;
            }
        }

        // IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    public class PeopleEnum : IDictionaryEnumerator
    {
        public ArrayList _people;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public PeopleEnum(ArrayList list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public DictionaryEntry Entry
        {
            get
            {
                return (DictionaryEntry)Current;
            }
        }

        public object Key
        {
            get
            {
                try
                {
                    return ((DictionaryEntry)_people[position]).Key;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public object Value
        {
            get
            {
                try
                {
                    return ((DictionaryEntry)_people[position]).Value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    class IOreredCollectionsClass{
        public static void Main(){
            Console.WriteLine("IOrder Collection.");
            People peopleCollection = new People(3);
            peopleCollection.Add("John", "Smith");
            peopleCollection.Add("Jim", "Johnson");
            peopleCollection.Add("Sue", "Rabon");

            Console.WriteLine("Displaying the entries in peopleCollection:");
            foreach (DictionaryEntry de in peopleCollection)
            {
                Console.WriteLine("{0} {1}", de.Key, de.Value);
            }

            Console.WriteLine();
            Console.WriteLine("Displaying the entries in the modified peopleCollection:");
            peopleCollection["Jim"] = "Jackson";
            peopleCollection.Remove("Sue");
            peopleCollection.Insert(0, "Fred", "Anderson");

            foreach (DictionaryEntry de in peopleCollection)
            {
                Console.WriteLine("{0} {1}", de.Key, de.Value);
            }

        }
    }
}