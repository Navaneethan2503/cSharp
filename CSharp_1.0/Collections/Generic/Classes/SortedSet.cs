using System;
using System.Collections.Generic;
/**
The SortedSet<T> class in C# is part of the System.Collections.Generic namespace and represents a collection of objects that is maintained in sorted order. It is a set, meaning it contains only unique elements, and it automatically sorts the elements as they are added. Here are the key details about the SortedSet<T> class:

    public class SortedSet<T> : System.Collections.Generic.ICollection<T>, System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IReadOnlyCollection<T>, System.Collections.Generic.IReadOnlySet<T>, System.Collections.Generic.ISet<T>, System.Collections.ICollection, System.Runtime.Serialization.IDeserializationCallback, System.Runtime.Serialization.ISerializable

Key Features:
-------------
Sorted Order: Elements are automatically sorted in ascending order by default. You can also provide a custom comparer to define the sort order.
Uniqueness: Ensures that all elements in the set are unique. Duplicate elements are not allowed.
Performance: Provides O(log n) time complexity for add, remove, and contains operations due to its underlying balanced tree structure.
Range Operations: Supports efficient range operations, such as finding elements within a specific range.

Properties:
----------
Comparer - Gets the IComparer<T> object that is used to order the values in the SortedSet<T>.
Count - Gets the number of elements in the SortedSet<T>.
Max	- Gets the maximum value in the SortedSet<T>, as defined by the comparer.
Min	- Gets the minimum value in the SortedSet<T>, as defined by the comparer.

Methods:
----------
Add(T)	- Adds an element to the set and returns a value that indicates if it was successfully added.
Clear()	- Removes all elements from the set.
Contains(T)	- Determines whether the set contains a specific element.
CopyTo(T[], Int32, Int32)	- Copies a specified number of elements from SortedSet<T> to a compatible one-dimensional array, starting at the specified array index.
CopyTo(T[], Int32)	- Copies the complete SortedSet<T> to a compatible one-dimensional array, starting at the specified array index.
CopyTo(T[])	- Copies the complete SortedSet<T> to a compatible one-dimensional array, starting at the beginning of the target array.
CreateSetComparer()	- Returns an IEqualityComparer object that can be used to create a collection that contains individual sets.
CreateSetComparer(IEqualityComparer<T>)	- Returns an IEqualityComparer object, according to a specified comparer, that can be used to create a collection that contains individual sets.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
ExceptWith(IEnumerable<T>)	- Removes all elements that are in a specified collection from the current SortedSet<T> object.
GetEnumerator()	- Returns an enumerator that iterates through the SortedSet<T>.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetObjectData(SerializationInfo, StreamingContext)	- Implements the ISerializable interface and returns the data that you must have to serialize a SortedSet<T> object.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
GetViewBetween(T, T) - Returns a view of a subset in a SortedSet<T>.
        This method returns a view of the range of elements that fall between lowerValue and upperValue, as defined by the comparer. This method does not copy elements from the SortedSet<T>, but provides a window into the underlying SortedSet<T> itself. You can make changes in both the view and in the underlying SortedSet<T>.

IntersectWith(IEnumerable<T>)	- Modifies the current SortedSet<T> object so that it contains only elements that are also in a specified collection.
IsProperSubsetOf(IEnumerable<T>)	- Determines whether a SortedSet<T> object is a proper subset of the specified collection.
IsProperSupersetOf(IEnumerable<T>)	- Determines whether a SortedSet<T> object is a proper superset of the specified collection.
IsSubsetOf(IEnumerable<T>)	- Determines whether a SortedSet<T> object is a subset of the specified collection.
IsSupersetOf(IEnumerable<T>)	- Determines whether a SortedSet<T> object is a superset of the specified collection.
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
OnDeserialization(Object)	- Implements the ISerializable interface, and raises the deserialization event when the deserialization is completed.
Overlaps(IEnumerable<T>) - Determines whether the current SortedSet<T> object and a specified collection share common elements.
Remove(T)	- Removes a specified item from the SortedSet<T>.
RemoveWhere(Predicate<T>)	- Removes all elements that match the conditions defined by the specified predicate from a SortedSet<T>.
Reverse()	- Returns an IEnumerable<T> that iterates over the SortedSet<T> in reverse order.
SetEquals(IEnumerable<T>)	- Determines whether the current SortedSet<T> object and the specified collection contain the same elements.
    This method ignores the order of elements and any duplicate elements in other.
    If the collection represented by other is a SortedSet<T> collection with the same equality comparer as the current SortedSet<T> object, this method is an O(log n) operation. Otherwise, this method is an O(n + m) operation, where n is the number of elements in other and m is Count.

SymmetricExceptWith(IEnumerable<T>)	- Modifies the current SortedSet<T> object so that it contains only elements that are present either in the current object or in the specified collection, but not both.
    any duplicate elements in other are ignored.
    If the other parameter is a SortedSet<T> collection with the same equality comparer as the current SortedSet<T> object, this method is an O(n log m) operation. Otherwise, this method is an O(n log m) + O(n log n) operation, where n is the number of elements in other and m is Count.

ToString()	- Returns a string that represents the current object.(Inherited from Object)
TryGetValue(T, T) - Searches the set for a given value and returns the equal value it finds, if any.
UnionWith(IEnumerable<T>)	- Modifies the current SortedSet<T> object so that it contains all elements that are present in either the current object or the specified collection.



**/
namespace SortedSet{
    class SortedSet{
        public static void Main(){
            Console.WriteLine("Sorted Set");
            SortedSet<int> test = new SortedSet<int>();
            Console.WriteLine("Max : "+ test.Max + " Min :"+ test.Min+ " Count :"+ test.Count);
            Console.WriteLine("Comparer :"+ test.Comparer);
            test.Add(10);
            test.Add(2);
            test.Add(2);
            test.Add(1);
            Print(test);
            Console.WriteLine("Max : "+ test.Max + " Min :"+ test.Min+ " Count :"+ test.Count);

            test.Add(5);
            test.Add(4);
            SortedSet<int> res = test.GetViewBetween(2,5);
            Console.WriteLine("GetViewBetween :");
            Print(res);

            IEnumerable<int> reverseOrder = test.Reverse();
            Console.WriteLine("Reverse Order :");
            foreach(int i in reverseOrder){
                Console.Write(i+",");
            }
            Console.WriteLine();
            Print(test);

            SortedSet<int> test2 = new SortedSet<int>(test);
            test2.Add(7);
            Console.WriteLine("Set Equal :" + test.SetEquals(test2));

            //SymmetricExcept
            
            // Create a SortedSet of integers
            SortedSet<int> setA = new SortedSet<int> { 1, 2, 3, 4, 5 };
            // Create another collection of integers
            List<int> setB = new List<int> { 3, 4, 5, 6, 7 };

            // Perform SymmetricExceptWith operation
            setA.SymmetricExceptWith(setB);
            Console.WriteLine("SymmetricExceptWith");
            Print(setA);



            
        }

        public static void Print(SortedSet<int> ex){
            foreach(int i in ex){
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }
    }
}