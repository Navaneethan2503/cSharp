using System;
using System.Collections;
using System.Collections.Specialized;
/**
Creates collections that ignore the case in strings.

These methods generate a case-insensitive instance of the collection using case-insensitive implementations of the hash code provider and the comparer. The resulting instance can be used like any other instances of that class, although it may behave differently.

For example, suppose two objects with the keys "hello" and "HELLO" are to be added to a hash table. A case-sensitive hash table would create two different entries; whereas, a case-insensitive hash table would throw an exception when adding the second object.

Methods:
--------
CreateCaseInsensitiveHashtable() - Creates a new case-insensitive instance of the Hashtable class with the default initial capacity.
CreateCaseInsensitiveHashtable(IDictionary)	- Copies the entries from the specified dictionary to a new case-insensitive instance of the Hashtable class with the same initial capacity as the number of entries copied.
CreateCaseInsensitiveHashtable(Int32)	- Creates a new case-insensitive instance of the Hashtable class with the specified initial capacity.
CreateCaseInsensitiveSortedList()	- Creates a new instance of the SortedList class that ignores the case of strings.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
ToString() - Returns a string that represents the current object.(Inherited from Object)



**/
namespace SpecializedCollections{
    
    class TestCollectionsUtils
    {
        public static void Main()
        {
            Hashtable population1 = CollectionsUtil.CreateCaseInsensitiveHashtable();

            population1["Trapperville"] = 15;
            population1["Doggerton"] = 230;
            population1["New Hollow"] = 1234;
            population1["McHenry"] = 185;

            // Select cities from the table using mixed case.
            Console.WriteLine("Case insensitive hashtable results:\n");
            Console.WriteLine("{0}'s population is: {1}", "Trapperville", population1["trapperville"]);
            Console.WriteLine("{0}'s population is: {1}", "Doggerton", population1["DOGGERTON"]);
            Console.WriteLine("{0}'s population is: {1}", "New Hollow", population1["New hoLLow"]);
            Console.WriteLine("{0}'s population is: {1}", "McHenry", population1["MchenrY"]);

            SortedList population2 = CollectionsUtil.CreateCaseInsensitiveSortedList();

            foreach (string city in population1.Keys)
            {
            population2.Add(city, population1[city]);
            }

            // Select cities from the sorted list using mixed case.
            Console.WriteLine("\nCase insensitive sorted list results:\n");
            Console.WriteLine("{0}'s population is: {1}", "Trapperville", population2["trapPeRVille"]);
            Console.WriteLine("{0}'s population is: {1}", "Doggerton", population2["dOGGeRtON"]);
            Console.WriteLine("{0}'s population is: {1}", "New Hollow", population2["nEW hOLLOW"]);
            Console.WriteLine("{0}'s population is: {1}", "McHenry", population2["MchEnrY"]);
        }
    }
}

// This program displays the following output to the console
//
// Case insensitive hashtable results:
//
// Trapperville's population is: 15
// Doggerton's population is: 230
// New Hollow's population is: 1234
// McHenry's population is: 185
//
// Case insensitive sorted list results:
//
// Trapperville's population is: 15
// Doggerton's population is: 230
// New Hollow's population is: 1234
// McHenry's population is: 185