using System;
/**
The System.Collections.Generic namespace in .NET provides a variety of generic collection classes and interfaces that offer better type safety and performance compared to non-generic collections.

Many of the generic collection types are direct analogs of nongeneric types. Dictionary<TKey,TValue> is a generic version of Hashtable; it uses the generic structure KeyValuePair<TKey,TValue> for enumeration instead of DictionaryEntry.

List<T> is a generic version of ArrayList. There are generic Queue<T> and Stack<T> classes that correspond to the nongeneric versions.

There are generic and nongeneric versions of SortedList<TKey,TValue>. Both versions are hybrids of a dictionary and a list. The SortedDictionary<TKey,TValue> generic class is a pure dictionary and has no nongeneric counterpart.

The LinkedList<T> generic class is a true linked list. It has no nongeneric counterpart.

1. List<T> - Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.

------------------------------------------------------------------------------------------------------
System.Collections.ObjectModel : 
The Collection<T> generic class provides a base class for deriving your own generic collection types. The ReadOnlyCollection<T> class provides an easy way to produce a read-only collection from any type that implements the IList<T> generic interface. The KeyedCollection<TKey,TItem> generic class provides a way to store objects that contain their own keys.


-----------------
Other Generic Types:
The ArraySegment<T> generic structure provides a way to delimit a range of elements within a one-dimensional, zero-based array of any type. The generic type parameter is the type of the array's elements.

The EventHandler<TEventArgs> generic delegate eliminates the need to declare a delegate type to handle events, if your event follows the event-handling pattern used by .NET. For example, suppose you have created a MyEventArgs class, derived from EventArgs, to hold the data for your event.
public event EventHandler<MyEventArgs> MyEvent;

**/
namespace Generics{
    class GenericCollections{
        public static void Main(){
            Console.WriteLine("Generic Collections...");
            //int s = Int32.Parse("9999999991");
            //Console.WriteLine(s);
            Console.WriteLine(9999999991 > int.MaxValue);
        }
    }
}