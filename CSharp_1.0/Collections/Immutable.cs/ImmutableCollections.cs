using System;
using System.Collections.Immutable;
using System.Collections.Generic;
/**
Immutable collections in C# are part of the System.Collections.Immutable namespace. These collections are designed to be immutable, meaning once they are created, they cannot be modified. This immutability provides several benefits, including thread safety, predictability, and ease of reasoning about code.

Key Features of Immutable Collections:
--------------------------------------
Thread Safety: Since immutable collections cannot be changed after they are created, they are inherently thread-safe. Multiple threads can read from the same collection without any risk of data corruption.
Predictability: Immutable collections ensure that the state of the collection does not change, making it easier to reason about the code and avoid bugs related to unexpected modifications.
Performance: Immutable collections are optimized for performance. They use structural sharing to minimize memory usage and avoid unnecessary copying of data
Ease of Use: Immutable collections provide a rich set of methods for creating and manipulating collections in a functional style.


Classes:
----------
ImmutableArray	- Provides methods for creating an array that is immutable; meaning it cannot be changed once it is created.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableArray<T>.Builder	- A writable array accessor that can be converted into an ImmutableArray<T> instance without allocating extra memory. NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableDictionary -	Provides a set of initialization methods for instances of the ImmutableDictionary<TKey,TValue> class.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableDictionary<TKey,TValue>.Builder	- Represents a hash map that mutates with little or no memory allocations and that can produce or build on immutable hash map instances very efficiently.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableDictionary<TKey,TValue>	- Represents an immutable, unordered collection of keys and values. NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableHashSet	- Provides a set of initialization methods for instances of the ImmutableHashSet<T> class. NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableHashSet<T>.Builder	- Represents a hash set that mutates with little or no memory allocations and that can produce or build on immutable hash set instances very efficiently.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableHashSet<T>	-  Represents an immutable, unordered hash set.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableInterlocked	- Contains interlocked exchange mechanisms for immutable collections.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableList	- Provides a set of initialization methods for instances of the ImmutableList<T> class.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableList<T>.Builder	 -Represents a list that mutates with little or no memory allocations and that can produce or build on immutable list instances very efficiently.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableList<T>	- Represents an immutable list, which is a strongly typed list of objects that can be accessed by index.
NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableQueue - Provides a set of initialization methods for instances of the ImmutableQueue<T> class.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableQueue<T>	- Represents an immutable queue.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableSortedDictionary	- Provides a set of initialization methods for instances of the ImmutableSortedDictionary<TKey,TValue> class.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableSortedDictionary<TKey,TValue>.Builder	- Represents a sorted dictionary that mutates with little or no memory allocations and that can produce or build on immutable sorted dictionary instances very efficiently.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableSortedDictionary<TKey,TValue>	- Represents an immutable sorted dictionary.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableSortedSet - Provides a set of initialization methods for instances of the ImmutableSortedSet<T> class.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableSortedSet<T>.Builder	- Represents a sorted set that enables changes with little or no memory allocations, and efficiently manipulates or builds immutable sorted sets.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableSortedSet<T>	- Represents an immutable sorted set implementation.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableStack	 - Provides a set of initialization methods for instances of the ImmutableStack<T> class.NuGet package: System.Collections.Immutable (about immutable collections and how to install)
ImmutableStack<T> - Represents an immutable stack.NuGet package: System.Collections.Immutable (about immutable collections and how to install)



**/
namespace ImmutableCollections{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class ImmutableCollectionsClass{
        public static void Main(){
            Console.WriteLine("Immutable Collections.");
            //Immutable HashSet
            // Create immutable set of strings
            ImmutableHashSet<string> colors = ImmutableHashSet.Create("Red", "Green", "Blue");

            // Iterate over all items in the set and print them
            Console.WriteLine("colors:");

            foreach (string s in colors)
            {
                Console.WriteLine(s);
            }

            // Try to add duplicate item into the set 
            ImmutableHashSet<string> colors2 = colors.Add("Red");
            Console.WriteLine("colors2:");

            colors2.Add("White");

            // Print items in the new set
            foreach (string s in colors2)
            {
                Console.WriteLine(s);
            }

            //Immutable List
            var numbers = ImmutableList.Create(1, 2, 3, 4, 5);
            var newNumbers = numbers.Add(6);
            numbers.Add(6); //Not Added
            //numbers[0] = 10; - readonly Error
            foreach (int number in newNumbers)
            {
             Console.WriteLine(number);
            }

            //Immutable Dictionary
            
            var ages = ImmutableDictionary.CreateBuilder<string, int>();
            ages.Add("Alice", 30);
            ages.Add("Bob", 25);
            var immutableAges = ages.ToImmutable();
            var updatedAges = immutableAges.SetItem("Charlie", 35);
            foreach (var kvp in updatedAges)
            {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }


            var person1 = new Person { Name = "Alice", Age = 30 };
            var person2 = new Person { Name = "Bob", Age = 25 };

            var immutableList = ImmutableList.Create(person1, person2);

            // Attempting to modify the collection itself will result in an error
            // immutableList.Add(new Person { Name = "Charlie", Age = 35 }); // This line will not compile

            // However, modifying the objects within the collection is allowed
            person1.Age = 31;
            person2.Name = "Robert";

            foreach (var person in immutableList)
            {
                Console.WriteLine($"{person.Name}: {person.Age}");
            }

            ImmutableList<int> test = ImmutableList.Create(5,4,3,2);
            test.Add(4);
            test.Add(3);
            Display(test);


        }

        private static void Display(ImmutableList<int> list)
        {
            Console.WriteLine();
            foreach( int s in list )
            {
                Console.WriteLine(s);
            }
        }
    }
}


