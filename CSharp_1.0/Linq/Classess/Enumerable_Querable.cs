using System;
using System.Linq;
using System.Collections.Generic;

/**
Provides a set of static methods for querying objects that implement IEnumerable<T>.
    public static class Enumerable

The methods in this class provide an implementation of the standard query operators for querying data sources that implement IEnumerable<T>. The standard query operators are general purpose methods that follow the LINQ pattern and enable you to express traversal, filter, and projection operations over data in any .NET-based programming language.

The majority of the methods in this class are defined as extension methods that extend IEnumerable<T>. This means they can be called like an instance method on any object that implements IEnumerable<T>.

Methods that are used in a query that returns a sequence of values do not consume the target data until the query object is enumerated. This is known as deferred execution. Methods that are used in a query that returns a singleton value execute and consume the target data immediately.

Methods:
------------
Aggregation Methods:
--------------------
    Aggregate: Applies an accumulator function over a sequence.
    Average: Computes the average of a sequence of numeric values.
    Count: Returns the number of elements in a sequence.
    LongCount: Returns the number of elements in a sequence as a long integer.
    Max: Returns the maximum value in a sequence.
    Min: Returns the minimum value in a sequence.
    Sum: Computes the sum of a sequence of numeric values.

Conversion Methods:
-------------------
    AsEnumerable: Returns the input typed as IEnumerable<T>.
    ToArray: Creates an array from a IEnumerable<T>.
    ToDictionary: Creates a Dictionary<TKey, TValue> from an IEnumerable<T>.
    ToList: Creates a List<T> from an IEnumerable<T>.
    ToLookup: Creates a Lookup<TKey, TElement> from an IEnumerable<T>.

Element Methods:
---------------
    ElementAt: Returns the element at a specified index in a sequence.
    ElementAtOrDefault: Returns the element at a specified index or a default value if the index is out of range.
    First: Returns the first element of a sequence.
    FirstOrDefault: Returns the first element of a sequence, or a default value if no element is found.
    Last: Returns the last element of a sequence.
    LastOrDefault: Returns the last element of a sequence, or a default value if no element is found.
    Single: Returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
    SingleOrDefault: Returns the only element of a sequence, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence.

Filtering Methods:
-------------------
    Where: Filters a sequence of values based on a predicate.
    OfType: Filters the elements of an IEnumerable based on a specified type.
    Grouping Methods
    GroupBy: Groups the elements of a sequence according to a specified key selector function.

Join Methods:
-------------
    Join: Correlates the elements of two sequences based on matching keys.
    GroupJoin: Correlates the elements of two sequences based on key equality and groups the results.

Ordering Methods:
-----------------
    OrderBy: Sorts the elements of a sequence in ascending order.
    OrderByDescending: Sorts the elements of a sequence in descending order.
    ThenBy: Performs a subsequent ordering of the elements in a sequence in ascending order.
    ThenByDescending: Performs a subsequent ordering of the elements in a sequence in descending order.
    Reverse: Inverts the order of the elements in a sequence.

Partitioning Methods:
----------------------
Skip: Bypasses a specified number of elements in a sequence and then returns the remaining elements.
SkipWhile: Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
Take: Returns a specified number of contiguous elements from the start of a sequence.
TakeWhile: Returns elements from a sequence as long as a specified condition is true.

Projection Methods:
-------------------
Select: Projects each element of a sequence into a new form.
SelectMany: Projects each element of a sequence to an IEnumerable<T> and flattens the resulting sequences into one sequence.

Quantifier Methods:
------------------
All: Determines whether all elements of a sequence satisfy a condition.
Any: Determines whether any element of a sequence exists or satisfies a condition.
Contains: Determines whether a sequence contains a specified element.

Set Methods:
-------------
Distinct: Returns distinct elements from a sequence.
Except: Produces the set difference of two sequences.
Intersect: Produces the set intersection of two sequences.
Union: Produces the set union of two sequences.

Miscellaneous Methods:
-----------------------
Append: Appends a value to the end of the sequence.
Prepend: Adds a value to the beginning of the sequence.
DefaultIfEmpty: Returns the elements of the specified sequence or the type parameter's default value in a singleton collection if the sequence is empty.
Zip: Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.



**/
namespace LinqClassNamespace{
    class Clump<T> : List<T>
    {
        
    }

    class Package{
        public required string Company ;

        public required double Weight;

    }


    class EnumerableClass{
        public static void Main(){
            Console.WriteLine("Enumerable Linq.");
            //Aggregate Mthod
            int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };
            int[] ints2 = {12,34,54};

            // Count the even numbers in the array, using a seed value of 0.
            int numEven = ints.Aggregate(3, (total, next) =>
                                                next % 2 == 0 ? total + 1 : total);

            Console.WriteLine("The number of even integers is: {0}", numEven);

            // This code produces the following output:
            //
            // The number of even integers is: 6

            //Average
            Console.WriteLine("Average :"+ ints.Average());

            //Count
            Console.WriteLine("Count :"+ ints.Count());

            //Sum
            Console.WriteLine("Sum :"+ ints.Sum());

            //AsEnumerable
            Clump<string> fruitClump =
            new Clump<string> { "apple", "passionfruit", "banana",
                "mango", "orange", "blueberry", "grape", "strawberry" };

            IEnumerable<string> query2 =
                fruitClump.AsEnumerable().Where(fruit => fruit.Contains("o"));

            Console.WriteLine("AsEnumerable :"+string.Join(',',query2));

            //Cast 
            IEnumerable<string> CastQuery =
                fruitClump.Cast<string>().OrderBy(fruit => fruit).Select(fruit => fruit);
            
            Console.WriteLine("Cast :"+string.Join(',',CastQuery));

            //Concet
            IEnumerable<int> concetQuery = ints.Concat(ints2);
            Console.WriteLine("Concat :" + string.Join(',',concetQuery));

            //Contains
            Console.WriteLine("Contains apple :"+ fruitClump.Contains("apple"));
            Console.WriteLine("Contains 'A' in apple :"+ "apple".Contains('A'));

            //Distinct
            Console.WriteLine("Distinct :"+ string.Join(',', ints.Distinct()));

            //ElementAt
            Console.WriteLine("ElementAt :"+ ints.ElementAt(4));
            Console.WriteLine("ElementAtDefault :"+ ints.ElementAtOrDefault(40));

            //Empty
            IEnumerable<decimal> empty = Enumerable.Empty<decimal>();

            //First
            Console.WriteLine("First :"+ ints.First());
            Console.WriteLine("firstOrDefault :"+ empty.FirstOrDefault());

            //Last
            Console.WriteLine("Last :"+ ints.Last());
            Console.WriteLine("LastOrDefault :"+ empty.LastOrDefault());

            //MAx
            Console.WriteLine("MAx :"+ ints.Max());

            //Min
            Console.WriteLine("Min :"+ ints.Min());

            //OfType
            System.Collections.ArrayList fruits = new()
                {
                    "Mango",
                    "Orange",
                    null,
                    "Apple",
                    3.0,
                    "Banana"
                };
                // Apply OfType() to the ArrayList.
                IEnumerable<string> queryOfType = fruits.OfType<string>();
                Console.WriteLine("OFTye :"+ string.Join(',',queryOfType));

                //Order
                Console.WriteLine("Order :"+ string.Join(',',ints.Order()));

                //order descending
                Console.WriteLine("Descending Order :"+ string.Join(',',ints.OrderByDescending(t => t)));

                //Prepend
                Console.WriteLine("Prepend :"+ string.Join(',',ints.Prepend(0)));

                //Range
                Console.WriteLine("Range :"+ string.Join(',',Enumerable.Range(100,5)));

                //Reverse
                Console.WriteLine("Original before Reverse :"+ string.Join(',',ints));
                Console.WriteLine("Reverse :"+ string.Join(',',ints.Reverse()));

                //SequenceEqual
                Console.WriteLine("SequenceEqual :"+ ints.SequenceEqual(ints));
                Console.WriteLine("SequenceEqual :"+ ints.SequenceEqual(ints2));

                //Single
                string[] words = ["test"];
                Console.WriteLine("Single :"+ words.Single());
                Console.WriteLine("SingleOrDefault :"+ empty.SingleOrDefault());

                //SkipWhile
                Console.WriteLine("SkipWhile :"+ string.Join(',',ints.SkipWhile(t => t > 4)));

                //ToArray() - Immediate Query Evaluation and stored.
                List<Package> packages =
                    new List<Package>
                        { new Package { Company = "Coho Vineyard", Weight = 25.2 },
                        new Package { Company = "Lucerne Publishing", Weight = 18.7 },
                        new Package { Company = "Wingtip Toys", Weight = 6.0 },
                        new Package { Company = "Adventure Works", Weight = 33.8 } };

                string[] companies = packages.Select(pkg => pkg.Company).ToArray();
                Console.WriteLine("ToArray() :"+ string.Join(',',companies));

        }
    }
}