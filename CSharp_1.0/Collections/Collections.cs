using System;
using System.Collections;
/**
Similar data can often be handled more efficiently when stored and manipulated as a collection.

There are two main types of collections; 
   generic collections and non-generic collections. 
   
Generic collections are type-safe at compile time. Because of this, generic collections typically offer better performance. Generic collections accept a type parameter when they're constructed. 
They don't require that you cast to and from the Object type when you add or remove items from the collection. In addition, most generic collections are supported in Windows Store apps. 

Choose Right Collections based on requirement :
-----------------------------------------------
Be sure to choose your collection class carefully. Using the wrong type can restrict your use of the collection.

Avoid using the types in the System.Collections namespace. The generic and concurrent versions of the collections are recommended because of their greater type safety and other improvements.

Consider the following questions:

Do you need a sequential list where the element is typically discarded after its value is retrieved?

    If yes, consider using the Queue class or the Queue<T> generic class if you need first-in, first-out (FIFO) behavior. Consider using the Stack class or the Stack<T> generic class if you need last-in, first-out (LIFO) behavior. For safe access from multiple threads, use the concurrent versions, ConcurrentQueue<T> and ConcurrentStack<T>. For immutability, consider the immutable versions, ImmutableQueue<T> and ImmutableStack<T>.

    If not, consider using the other collections.

Do you need to access the elements in a certain order, such as FIFO, LIFO, or random?

    The Queue class, as well as the Queue<T>, ConcurrentQueue<T>, and ImmutableQueue<T> generic classes all offer FIFO access. For more information, see When to Use a Thread-Safe Collection.

    The Stack class, as well as the Stack<T>, ConcurrentStack<T>, and ImmutableStack<T> generic classes all offer LIFO access. For more information, see When to Use a Thread-Safe Collection.

    The LinkedList<T> generic class allows sequential access either from the head to the tail, or from the tail to the head.

Do you need to access each element by index?

    The ArrayList and StringCollection classes and the List<T> generic class offer access to their elements by the zero-based index of the element. For immutability, consider the immutable generic versions, ImmutableArray<T> and ImmutableList<T>.

    The Hashtable, SortedList, ListDictionary, and StringDictionary classes, and the Dictionary<TKey,TValue> and SortedDictionary<TKey,TValue> generic classes offer access to their elements by the key of the element. Additionally, there are immutable versions of several corresponding types: ImmutableHashSet<T>, ImmutableDictionary<TKey,TValue>, ImmutableSortedSet<T>, and ImmutableSortedDictionary<TKey,TValue>.

    The NameObjectCollectionBase and NameValueCollection classes, and the KeyedCollection<TKey,TItem> and SortedList<TKey,TValue> generic classes offer access to their elements by either the zero-based index or the key of the element.

    Will each element contain one value, a combination of one key and one value, or a combination of one key and multiple values?

    One value: Use any of the collections based on the IList interface or the IList<T> generic interface. For an immutable option, consider the IImmutableList<T> generic interface.

    One key and one value: Use any of the collections based on the IDictionary interface or the IDictionary<TKey,TValue> generic interface. For an immutable option, consider the IImmutableSet<T> or IImmutableDictionary<TKey,TValue> generic interfaces.

    One value with embedded key: Use the KeyedCollection<TKey,TItem> generic class.

    One key and multiple values: Use the NameValueCollection class.

Do you need to sort the elements differently from how they were entered?

    The Hashtable class sorts its elements by their hash codes.

    The SortedList class, and the SortedList<TKey,TValue> and SortedDictionary<TKey,TValue> generic classes sort their elements by the key. The sort order is based on the implementation of the IComparer interface for the SortedList class and on the implementation of the IComparer<T> generic interface for the SortedList<TKey,TValue> and SortedDictionary<TKey,TValue> generic classes. Of the two generic types, SortedDictionary<TKey,TValue> offers better performance than SortedList<TKey,TValue>, while SortedList<TKey,TValue> consumes less memory.

    ArrayList provides a Sort method that takes an IComparer implementation as a parameter. Its generic counterpart, the List<T> generic class, provides a Sort method that takes an implementation of the IComparer<T> generic interface as a parameter.

Do you need fast searches and retrieval of information?

    ListDictionary is faster than Hashtable for small collections (10 items or fewer). The Dictionary<TKey,TValue> generic class provides faster lookup than the SortedDictionary<TKey,TValue> generic class. The multi-threaded implementation is ConcurrentDictionary<TKey,TValue>. ConcurrentBag<T> provides fast multi-threaded insertion for unordered data. For more information about both multi-threaded types, see When to Use a Thread-Safe Collection.

Do you need collections that accept only strings?

    StringCollection (based on IList) and StringDictionary (based on IDictionary) are in the System.Collections.Specialized namespace.

    In addition, you can use any of the generic collection classes in the System.Collections.Generic namespace as strongly typed string collections by specifying the String class for their generic type arguments. For example, you can declare a variable to be of type List<String> or Dictionary<String,String>.


Collection types represent different ways to collect data, such as hash tables, queues, stacks, bags, dictionaries, and lists.

All collections are based on the ICollection or ICollection<T> interfaces, either directly or indirectly. IList and IDictionary and their generic counterparts all derive from these two interfaces.

In collections based on IList or directly on ICollection, every element contains only a value. These types include:

Array
ArrayList
List<T>
Queue
ConcurrentQueue<T>
Stack
ConcurrentStack<T>
LinkedList<T>
In collections based on the IDictionary interface, every element contains both a key and a value. These types include:

Hashtable
SortedList
SortedList<TKey,TValue>
Dictionary<TKey,TValue>
ConcurrentDictionary<TKey,TValue>
The KeyedCollection<TKey,TItem> class is unique because it is a list of values with keys embedded within the values. As a result, it behaves both like a list and like a dictionary.

When you need efficient multi-threaded collection access, use the generic collections in the System.Collections.Concurrent namespace.

The Queue and Queue<T> classes provide first-in-first-out lists. The Stack and Stack<T> classes provide last-in-first-out lists.

Strong typing
Generic collections are the best solution to strong typing. For example, adding an element of any type other than an Int32 to a List<Int32> collection causes a compile-time error. However, if your language does not support generics, the System.Collections namespace includes abstract base classes that you can extend to create collection classes that are strongly typed. These base classes include:

CollectionBase
ReadOnlyCollectionBase
DictionaryBase
How collections vary
Collections vary in how they store, sort, and compare elements, and how they perform searches.

The SortedList class and the SortedList<TKey,TValue> generic class provide sorted versions of the Hashtable class and the Dictionary<TKey,TValue> generic class.

All collections use zero-based indexes except Array, which allows arrays that are not zero-based.

You can access the elements of a SortedList or a KeyedCollection<TKey,TItem> by either the key or the element's index. You can only access the elements of a Hashtable or a Dictionary<TKey,TValue> by the element's key.

Use LINQ with collection types
The LINQ to Objects feature provides a common pattern for accessing in-memory objects of any type that implements IEnumerable or IEnumerable<T>. LINQ queries have several benefits over standard constructs like foreach loops:

They are concise and easier to understand.
They can filter, order, and group data.
They can improve performance.


**/
namespace CollectionNamespace{
    class CollectionClass{
        public static void Main(){
            Console.WriteLine("Collection ...");
            
        }
    }
}