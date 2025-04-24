using System;
using System.Linq;
using System.Collections.Generic;
/**
Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the C# language.

A query is an expression that retrieves data from a data source. Different data sources have different native query languages, 
for example SQL for relational databases and XQuery for XML. 
Developers must learn a new query language for each type of data source or data format that they must support. 

LINQ simplifies this situation by offering a consistent C# language model for kinds of data sources and formats. 
In a LINQ query, you always work with C# objects. You use the same basic coding patterns to query and transform data in XML documents, SQL databases, .NET collections, and any other format when a LINQ provider is available.

Three Parts of a Query Operation:
---------------------------------
All LINQ query operations consist of three distinct actions:
    1.Obtain the data source.
    2.Create the query.
    3.Execute the query.

This fact means it can be queried with LINQ. 
A query is executed in a foreach statement, and foreach requires IEnumerable or IEnumerable<T>. Types that support IEnumerable<T> or a derived interface such as the generic IQueryable<T> are called queryable types.

The Query:
-----------
The query specifies what information to retrieve from the data source or sources. Optionally, a query also specifies how that information should be sorted, grouped, and shaped before being returned. 
A query is stored in a query variable and initialized with a query expression.

Classification of standard query operators by manner of execution:
---------------------------------------------------------------------
The LINQ to Objects implementations of the standard query operator methods execute in one of two main ways: 
    1. immediate
    2. deferred. 
    
    The query operators that use deferred execution can be additionally divided into two categories: 
    2.A) streaming 
    2.B) nonstreaming.

Immediate:
------------
Immediate execution means that the data source is read and the operation is performed once. All the standard query operators that return a scalar result execute immediately. 
Examples of such queries are Count, Max, Average, and First. 
These methods execute without an explicit foreach statement because the query itself must use foreach in order to return a result. These queries return a single value, not an IEnumerable collection. 
You can force any query to execute immediately using the Enumerable.ToList or Enumerable.ToArray methods. Immediate execution provides reuse of query results, not query declaration. The results are retrieved once, then stored for future use.
    
Deferred:
--------
Deferred execution means that the operation isn't performed at the point in the code where the query is declared. The operation is performed only when the query variable is enumerated, for example by using a foreach statement. The results of executing the query depend on the contents of the data source when the query is executed rather than when the query is defined. If the query variable is enumerated multiple times, the results might differ every time. Almost all the standard query operators whose return type is IEnumerable<T> or IOrderedEnumerable<TElement> execute in a deferred manner. Deferred execution provides the facility of query reuse since the query fetches the updated data from the data source each time query results are iterated.
The foreach statement is also where the query results are retrieved. For example, in the previous query, the iteration variable num holds each value (one at a time) in the returned sequence.
Because the query variable itself never holds the query results, you can execute it repeatedly to retrieve updated data. For example, a separate application might update a database continually. In your application, you could create one query that retrieves the latest data, and you could execute it at intervals to retrieve updated results.
Query operators that use deferred execution can be additionally classified as streaming or nonstreaming.

Streaming:
------------
Streaming operators don't have to read all the source data before they yield elements. At the time of execution, a streaming operator performs its operation on each source element as it is read and yields the element if appropriate. A streaming operator continues to read source elements until a result element can be produced. This means that more than one source element might be read to produce one result element.

Nonstreaming:
-------------
Nonstreaming operators must read all the source data before they can yield a result element. Operations such as sorting or grouping fall into this category. At the time of execution, nonstreaming query operators read all the source data, put it into a data structure, perform the operation, and yield the resulting elements.

Classification table:
-----------------------
The following table classifies each standard query operator method according to its method of execution.

If an operator is marked in two columns, two input sequences are involved in the operation, and each sequence is evaluated differently. In these cases, it is always the first sequence in the parameter list that is evaluated in a deferred, streaming manner.
Standard query operator	Return type	Immediate execution	Deferred streaming execution	Deferred nonstreaming execution
Aggregate	TSource	✓		
All	Boolean	✓		
Any	Boolean	✓		
AsEnumerable	IEnumerable<T>		✓	
Average	Single numeric value	✓		
Cast	IEnumerable<T>		✓	
Concat	IEnumerable<T>		✓	
Contains	Boolean	✓		
Count	Int32	✓		
DefaultIfEmpty	IEnumerable<T>		✓	
Distinct	IEnumerable<T>		✓	
ElementAt	TSource	✓		
ElementAtOrDefault	TSource?	✓		
Empty	IEnumerable<T>	✓		
Except	IEnumerable<T>		✓	✓
First	TSource	✓		
FirstOrDefault	TSource?	✓		
GroupBy	IEnumerable<T>			✓
GroupJoin	IEnumerable<T>		✓	✓
Intersect	IEnumerable<T>		✓	✓
Join	IEnumerable<T>		✓	✓
Last	TSource	✓		
LastOrDefault	TSource?	✓		
LongCount	Int64	✓		
Max	Single numeric value, TSource, or TResult?	✓		
Min	Single numeric value, TSource, or TResult?	✓		
OfType	IEnumerable<T>		✓	
OrderBy	IOrderedEnumerable<TElement>			✓
OrderByDescending	IOrderedEnumerable<TElement>			✓
Range	IEnumerable<T>		✓	
Repeat	IEnumerable<T>		✓	
Reverse	IEnumerable<T>			✓
Select	IEnumerable<T>		✓	
SelectMany	IEnumerable<T>		✓	
SequenceEqual	Boolean	✓		
Single	TSource	✓		
SingleOrDefault	TSource?	✓		
Skip	IEnumerable<T>		✓	
SkipWhile	IEnumerable<T>		✓	
Sum	Single numeric value	✓		
Take	IEnumerable<T>		✓	
TakeWhile	IEnumerable<T>		✓	
ThenBy	IOrderedEnumerable<TElement>			✓
ThenByDescending	IOrderedEnumerable<TElement>			✓
ToArray	TSource[] array	✓		
ToDictionary	Dictionary<TKey,TValue>	✓		
ToList	IList<T>	✓		
ToLookup	ILookup<TKey,TElement>	✓		
Union	IEnumerable<T>		✓	
Where	IEnumerable<T>		✓	


LINQ to objects:
-----------------
"LINQ to Objects" refers to the use of LINQ queries with any IEnumerable or IEnumerable<T> collection directly. You can use LINQ to query any enumerable collections, such as List<T>, Array, or Dictionary<TKey,TValue>. The collection can be user-defined or a type returned by a .NET API. In the LINQ approach, you write declarative code that describes what you want to retrieve. LINQ to Objects provides a great introduction to programming with LINQ.

LINQ queries offer three main advantages over traditional foreach loops:

They're more concise and readable, especially when filtering multiple conditions.
They provide powerful filtering, ordering, and grouping capabilities with a minimum of application code.
They can be ported to other data sources with little or no modification.
The more complex the operation you want to perform on the data, the more benefit you realize using LINQ instead of traditional iteration techniques.


Store the results of a query in memory:
---------------------------------------
A query is basically a set of instructions for how to retrieve and organize data. Queries are executed lazily, as each subsequent item in the result is requested. When you use foreach to iterate the results, items are returned as accessed. To evaluate a query and store its results without executing a foreach loop, just call one of the following methods on the query variable:

ToList
ToArray
ToDictionary
ToLookup


**/
namespace LinqNamespace{
    class LinqClass{
        public static void Main(){
            Console.WriteLine("Linq ...");
            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] numbers = [ 0, 1, 2, 3, 4, 5, 6 ];

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            //the query variable itself takes no action and returns no data.
            //It just stores the information that is required to produce the results when the query is executed at some later point.
            var numQuery = from num in numbers
                        where (num % 2) == 0
                        select num;
            //The from clause specifies the data source, 
            //the where clause applies the filter, 
            //the select clause specifies the type of the returned elements

            // 3. Query execution.
            //Deffered
            Console.WriteLine("Deffered Query :");
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
            Console.WriteLine();


            //Immediate - Query Execution
            var evenNumQuery = from num in numbers
                   where (num % 2) == 0
                   select num;

            int evenNumCount = evenNumQuery.Count();

            List<int> numQuery2 = (from num in numbers
                       where (num % 2) == 0
                       select num).ToList();

            // or like this:
            // numQuery3 is still an int[]

            var numQuery3 = (from num in numbers
                            where (num % 2) == 0
                            select num).ToArray();

            Console.WriteLine("Immediate Query :");
            Console.WriteLine(string.Join(',',numQuery3));
            Console.WriteLine("Indexing the Query results : "+ numQuery3[0]);
        }
    }
}