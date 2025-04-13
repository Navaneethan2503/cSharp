using System;
using System.Collections;

/**
The non-generic IList interface in C# is part of the System.Collections namespace and represents a collection of objects that can be individually accessed by index. Unlike the generic IList<T>, the non-generic IList can store elements of any type, making it less type-safe but more flexible in terms of the types of objects it can hold.

Represents a non-generic collection of objects that can be individually accessed by index.

public interface IList : System.Collections.ICollection

Key Features of IList:
1.Indexed Access: Allows access to elements by their index, similar to arrays.
2.Non-Generic: Can store elements of any type, including different types in the same list.
3.Dynamic Sizing: Implementations of IList can dynamically resize as elements are added or removed.
4.Flexibility: Can be implemented by various collection types, such as ArrayList.

IList is a descendant of the ICollection interface and is the base interface of all non-generic lists. 

IList implementations fall into three categories: read-only, fixed-size, and variable-size. 
    A read-only IList cannot be modified. 
    A fixed-size IList does not allow the addition or removal of elements, but it allows the modification of existing elements. 
    A variable-size IList allows the addition, removal, and modification of elements.

Properties:
--------------
1. Count-Gets the number of elements contained in the ICollection.(Inherited from ICollection)
2. IsFixedSize	- Gets a value indicating whether the IList has a fixed size.
    public bool IsFixedSize { get; }
    true if the IList has a fixed size; otherwise, false.

3. IsReadOnly	- Gets a value indicating whether the IList is read-only.
    public bool IsReadOnly { get; }
    true if the IList is read-only; otherwise, false.

4. IsSynchronized	- Gets a value indicating whether access to the ICollection is synchronized (thread safe).(Inherited from ICollection)
5. Item[Int32]	- Gets or sets the element at the specified index.
    public object? this[int index] { get; set; }
    The zero-based index of the element to get or set.

6. SyncRoot - Gets an object that can be used to synchronize access to the ICollection. (Inherited from ICollection)


Methods:
---------
1. Add(Object) - Adds an item to the IList.
    public int Add(object? value);
    Return - The position into which the new element was inserted, or -1 to indicate that the item was not inserted into the collection.
    Parameters - The object to add to the IList.

2. Clear()	- Removes all items from the IList.
    public void Clear();
    Implementations of this method can vary in how they handle the ICollection.Count and the capacity of a collection. Typically, the count is set to zero, and references to other objects from elements of the collection are also released. The capacity can be set to zero or a default value, or it can remain unchanged.

3. Contains(Object) - Determines whether the IList contains a specific value.
    public bool Contains(object? value);
    Starting with the .NET Framework 2.0, this method uses the collection's objects' Equals and CompareTo methods on item to determine whether item exists. In the earlier versions of the .NET Framework, this determination was made by using the Equals and CompareTo methods of the item parameter on the objects in the collection.

4. CopyTo(Array, Int32)- Copies the elements of the ICollection to an Array, starting at a particular Array index.(Inherited from ICollection)
5. GetEnumerator()	- Returns an enumerator that iterates through a collection.(Inherited from IEnumerable)
6. IndexOf(Object)	- Determines the index of a specific item in the IList.
    public int IndexOf(object? value);
    return- The index of value if found in the list; otherwise, -1.
    parameter - The object to locate in the IList.
    Starting with the .NET Framework 2.0, this method uses the collection's objects' Equals and CompareTo methods on item to determine whether item exists. In the earlier versions of the .NET Framework, this determination was made by using the Equals and CompareTo methods of the item parameter on the objects in the collection.

7. Insert(Int32, Object) - Inserts an item to the IList at the specified index.
    public void Insert(int index, object? value);
    If index equals the number of items in the IList, then value is appended to the end.
    In collections of contiguous elements, such as lists, the elements that follow the insertion point move down to accommodate the new element. If the collection is indexed, the indexes of the elements that are moved are also updated. This behavior does not apply to collections where elements are conceptually grouped into buckets, such as a hash table.

8. Remove(Object)	- Removes the first occurrence of a specific object from the IList.
    public void Remove(object? value);
    In collections of contiguous elements, such as lists, the elements that follow the removed element move up to occupy the vacated spot. If the collection is indexed, the indexes of the elements that are moved are also updated. This behavior does not apply to collections where elements are conceptually grouped into buckets, such as a hash table. If value is not found in the IList, the IList remains unchanged and no exception is thrown.

9. RemoveAt(Int32)	- Removes the IList item at the specified index.
    public void RemoveAt(int index);
    In collections of contiguous elements, such as lists, the elements that follow the removed element move up to occupy the vacated spot. If the collection is indexed, the indexes of the elements that are moved are also updated. This behavior does not apply to collections where elements are conceptually grouped into buckets, such as a hash table.


**/
namespace IListNamespace{

    class SimpleList : IList
    {
        private object[] _contents = new object[8];
        private int _count;

        public SimpleList()
        {
            _count = 0;
        }

        // IList Members
        public int Add(object value)
        {
            if (_count < _contents.Length)
            {
                _contents[_count] = value;
                _count++;

                return (_count - 1);
            }

            return -1;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if ((_count + 1 <= _contents.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                for (int i = Count - 1; i > index; i--)
                {
                    _contents[i] = _contents[i - 1];
                }
                _contents[index] = value;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _contents[i] = _contents[i + 1];
                }
                _count--;
            }
        }

        public object this[int index]
        {
            get
            {
                return _contents[index];
            }
            set
            {
                _contents[index] = value;
            }
        }

        // ICollection members.

        public void CopyTo(Array array, int index)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_contents[i], index++);
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        // Return the current instance since the underlying store is not
        // publicly available.
        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        // IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            // Refer to the IEnumerator documentation for an example of
            // implementing an enumerator.
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        public void PrintContents()
        {
            Console.WriteLine($"List has a capacity of {_contents.Length} and currently has {_count} elements.");
            Console.Write("List contents:");
            for (int i = 0; i < Count; i++)
            {
                Console.Write($" {_contents[i]}");
            }
            Console.WriteLine();
        }
    }

    class IListClass{
        public static void Main(){
            Console.WriteLine("IList Collection...");

            var test = new SimpleList();

            // Populate the List.
            Console.WriteLine("Populate the List");
            test.Add("one");
            test.Add("two");
            test.Add("three");
            test.Add("four");
            test.Add("five");
            test.Add("six");
            test.Add("seven");
            test.Add("eight");
            test.PrintContents();
            Console.WriteLine();

            // Remove elements from the list.
            Console.WriteLine("Remove elements from the list");
            test.Remove("six");
            test.Remove("eight");
            test.PrintContents();
            Console.WriteLine();

            // Add an element to the end of the list.
            Console.WriteLine("Add an element to the end of the list");
            test.Add("nine");
            test.PrintContents();
            Console.WriteLine();

            // Insert an element into the middle of the list.
            Console.WriteLine("Insert an element into the middle of the list");
            test.Insert(4, "number");
            test.PrintContents();
            Console.WriteLine();

            // Check for specific elements in the list.
            Console.WriteLine("Check for specific elements in the list");
            Console.WriteLine($"List contains \"three\": {test.Contains("three")}");
            Console.WriteLine($"List contains \"ten\": {test.Contains("ten")}");

            test.Remove("nine");
            test.Add(100);
            Console.WriteLine("Inserted Number :"+ test[1]);
            test.PrintContents();
            
        }
    }
}