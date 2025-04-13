using System;
using System.Collections.Generic;
/**
The HashSet<T> class in C# is part of the System.Collections.Generic namespace and is used to store a collection of unique elements. It is implemented using a hash table, which allows for fast lookups, additions, and deletions. 

    public class HashSet<T> : System.Collections.Generic.ICollection<T>, System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IReadOnlyCollection<T>, System.Collections.Generic.IReadOnlySet<T>, System.Collections.Generic.ISet<T>, System.Runtime.Serialization.IDeserializationCallback, System.Runtime.Serialization.ISerializable

Key Features:
Uniqueness: Ensures that all elements in the set are unique. Duplicate elements are not allowed.
Performance: Provides O(1) average time complexity for add, remove, and contains operations.
No Order: The elements in a HashSet<T> are not stored in any particular order.

Properties:
-----------
Capacity - Gets the total numbers of elements the internal data structure can hold without resizing.
Comparer - Gets the IEqualityComparer<T> object that is used to determine equality for the values in the set.
Count - Gets the number of elements that are contained in a set.

Methods:
---------
Add(T) - Adds the specified element to a set.
    O(1) if within capacity else O(n)
Clear()	- Removes all elements from a HashSet<T> object.
    O(n)
Contains(T)	- Determines whether a HashSet<T> object contains the specified element.
    O(n)
CopyTo(T[], Int32, Int32)	- Copies the specified number of elements of a HashSet<T> object to an array, starting at the specified array index.
CopyTo(T[], Int32)- Copies the elements of a HashSet<T> object to an array, starting at the specified array index.
CopyTo(T[])	- Copies the elements of a HashSet<T> object to an array.
    O(n)
CreateSetComparer()	- Returns an IEqualityComparer object that can be used for equality testing of a HashSet<T> object.
EnsureCapacity(Int32)	- Ensures that this hash set can hold the specified number of elements without any further expansion of its backing storage.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
ExceptWith(IEnumerable<T>)	- Removes all elements in the specified collection from the current HashSet<T> object.
GetAlternateLookup<TAlternate>()	- Gets an instance of a type that can be used to perform operations on the current HashSet<T> using a TAlternate instead of a T.
GetEnumerator()	 - Returns an enumerator that iterates through a HashSet<T> object.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetObjectData(SerializationInfo, StreamingContext)	- Obsolete. Implements the ISerializable interface and returns the data needed to serialize a HashSet<T> object.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
IntersectWith(IEnumerable<T>)	- Modifies the current HashSet<T> object to contain only elements that are present in that object and in the specified collection.
    O(n)
IsProperSubsetOf(IEnumerable<T>)	- Determines whether a HashSet<T> object is a proper subset of the specified collection.
IsProperSupersetOf(IEnumerable<T>)	- Determines whether a HashSet<T> object is a proper superset of the specified collection.
IsSubsetOf(IEnumerable<T>)	- Determines whether a HashSet<T> object is a subset of the specified collection.
IsSupersetOf(IEnumerable<T>)	- Determines whether a HashSet<T> object is a superset of the specified collection.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
OnDeserialization(Object)	- Implements the ISerializable interface and raises the deserialization event when the deserialization is complete.
Overlaps(IEnumerable<T>)	- Determines whether the current HashSet<T> object and a specified collection share common elements.
Remove(T)	- Removes the specified element from a HashSet<T> object.
RemoveWhere(Predicate<T>)	- Removes all elements that match the conditions defined by the specified predicate from a HashSet<T> collection.
SetEquals(IEnumerable<T>)	- Determines whether a HashSet<T> object and the specified collection contain the same elements.
SymmetricExceptWith(IEnumerable<T>)	- Modifies the current HashSet<T> object to contain only elements that are present either in that object or in the specified collection, but not both.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TrimExcess()	- Sets the capacity of a HashSet<T> object to the actual number of elements it contains, rounded up to a nearby, implementation-specific value.
TrimExcess(Int32)	- Sets the capacity of a HashSet<T> object to the specified number of entries, rounded up to a nearby, implementation-specific value.
TryGetAlternateLookup<TAlternate>(HashSet<T>.AlternateLookup<TAlternate>)	- Gets an instance of a type that can be used to perform operations on the current HashSet<T> using a TAlternate instead of a T.
TryGetValue(T, T)	- Searches the set for a given value and returns the equal value it finds, if any.
    O(n)
UnionWith(IEnumerable<T>)	- Modifies the current HashSet<T> object to contain all elements that are present in itself, the specified collection, or both.


Method	Condition	Example Result
IsSupersetOf	All elements of the specified collection are in the current set.	True
IsProperSupersetOf	All elements of the specified collection are in the current set, and the current set has additional elements.	True
IsSubsetOf	All elements of the current set are in the specified collection.	True
IsProperSubsetOf	All elements of the current set are in the specified collection, and the specified collection has additional elements.	True



**/
namespace HashSetNamepsace{
    public class HashSetClass{
        public static void Main(){
            Console.WriteLine("HAsh Set Collections.");
            HashSet<int> test = new HashSet<int>();
            Console.WriteLine("Count : "+ test.Count+ " Capacity :"+ test.Capacity);
            test.Add(1);
            test.Add(1);
            test.Add(2);
            Console.WriteLine("Count : "+ test.Count+ " Capacity :"+ test.Capacity);
            Print(test);
            test.Add(1);
            test.Add(1);
            test.Add(2);
            Console.WriteLine("Count : "+ test.Count+ " Capacity :"+ test.Capacity);
            Print(test);

            HashSet<int> test2 = new HashSet<int>(test);
            test2.Add(10);
            test2.Add(5);
            test2.IntersectWith(test);
            Console.WriteLine("Intersect :");
            Print(test2);

            HashSet<int> lowNumbers = new HashSet<int>();
            HashSet<int> allNumbers = new HashSet<int>();

            for (int i = 1; i < 5; i++)
            {
                lowNumbers.Add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                allNumbers.Add(i);
            }

            Console.Write("lowNumbers contains {0} elements: ", lowNumbers.Count);
            DisplaySet(lowNumbers);

            Console.Write("allNumbers contains {0} elements: ", allNumbers.Count);
            DisplaySet(allNumbers);

            Console.WriteLine("lowNumbers overlaps allNumbers: {0}",
                lowNumbers.Overlaps(allNumbers));

            // Show the results of sub/superset testing
            Console.WriteLine("lowNumbers is a subset of allNumbers: {0}",
                lowNumbers.IsSubsetOf(allNumbers));

                        // Modify allNumbers to remove numbers that are not in lowNumbers.
            allNumbers.IntersectWith(lowNumbers);
            Console.Write("allNumbers contains {0} elements: ", allNumbers.Count);
            DisplaySet(allNumbers);

            Console.WriteLine("allNumbers and lowNumbers are equal sets: {0}",
                allNumbers.SetEquals(lowNumbers));

            // Show the results of sub/superset testing with the modified set.
            Console.WriteLine("lowNumbers is a subset of allNumbers: {0}",
                lowNumbers.IsSubsetOf(allNumbers));
            Console.WriteLine("allNumbers is a superset of lowNumbers: {0}",
                allNumbers.IsSupersetOf(lowNumbers));
            Console.WriteLine("lowNumbers is a proper subset of allNumbers: {0}",
                lowNumbers.IsProperSubsetOf(allNumbers));
            Console.WriteLine("allNumbers is a proper superset of lowNumbers: {0}",
                allNumbers.IsProperSupersetOf(lowNumbers));

            //UnionWith
            // Create a new HashSet populated with even numbers.
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                // Populate numbers with just even numbers.
                evenNumbers.Add(i * 2);

                // Populate oddNumbers with just odd numbers.
                oddNumbers.Add((i * 2) + 1);
            }
            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Console.WriteLine("numbers UnionWith oddNumbers...");
            numbers.UnionWith(oddNumbers);
            Print(numbers);

            
        }

        static void DisplaySet(HashSet<int> set)
        {
            Console.Write("{");
            foreach (int i in set)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");
        }

        public static void Print(HashSet<int> ex){
            foreach(int i in ex){
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }
    }
}