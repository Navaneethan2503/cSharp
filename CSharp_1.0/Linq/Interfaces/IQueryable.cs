using System;
using System.Linq;
/**
The IQueryable interface in C# is a powerful feature used primarily for querying data from a data source. 
It is part of the System.Linq namespace and is designed to work with LINQ (Language Integrated Query) to provide a way to execute queries against a specific data source where the type of the data is not specified.

Provides functionality to evaluate queries against a specific data source wherein the type of the data is not specified.

    public interface IQueryable : System.Collections.IEnumerable

Properties:
-------------
ElementType	- Gets the type of the element(s) that are returned when the expression tree associated with this instance of IQueryable is executed.
Expression	- Gets the expression tree that is associated with the instance of IQueryable.
    public System.Linq.Expressions.Expression Expression { get; }

Provider	- Gets the query provider that is associated with this data source.
    public System.Linq.IQueryProvider Provider { get; }

Methods:
---------
GetEnumerator()	- Returns an enumerator that iterates through a collection.(Inherited from IEnumerable)

Key Features:
------------
Deferred Execution: Queries using IQueryable are not executed when they are defined. Instead, they are executed when the query is enumerated, for example, by using a foreach loop or calling methods like ToList(), ToArray(), etc.
Expression Trees: IQueryable uses expression trees to represent the query. This allows the query to be translated into a format that the data source can understand, such as SQL for a database.
Provider: The IQueryable interface works with a query provider that is responsible for translating the expression tree into the appropriate query language for the data source.

What is Query Providers:
------------------------
A query provider is a component or service that translates LINQ (Language Integrated Query) queries into a format that can be executed against a specific data source. 
Think of it as a translator that takes the LINQ query you write in C# and converts it into the language that your data source understands, such as SQL for a database.

Simple Explanation:
----------------------
LINQ Query: You write a query in C# using LINQ, like filtering or sorting data.
Query Provider: The query provider takes this LINQ query and translates it into the appropriate query language for the data source.
Execution: The translated query is executed against the data source, and the results are returned.

Common Query Providers:
------------------------
Entity Framework: Translates LINQ queries into SQL for relational databases.
LINQ to XML: Translates LINQ queries to work with XML data.
LINQ to Objects: Works with in-memory collections like arrays and lists.

Linq to Object:
---------------
LINQ to Objects is a feature of LINQ (Language Integrated Query) that allows you to query in-memory collections like arrays, lists, and other objects that implement IEnumerable<T>. This is different from querying external data sources like databases or XML files. LINQ to Objects provides a convenient and powerful way to perform operations on collections using a query syntax similar to SQL.
LINQ to Objects is implemented using extension methods provided by the System.Linq namespace. These methods extend the IEnumerable<T> interface, which is the base interface for all collections in .NET that can be enumerated. This means that any collection that implements IEnumerable<T> can use LINQ to Objects to perform queries.

The IQueryable interface is intended for implementation by query providers. It is only supposed to be implemented by providers that also implement IQueryable<T>. If the provider does not also implement IQueryable<T>, the standard query operators cannot be used on the provider's data source.

The IQueryable interface inherits the IEnumerable interface so that if it represents a query, the results of that query can be enumerated. Enumeration causes the expression tree associated with an IQueryable object to be executed. The definition of "executing an expression tree" is specific to a query provider.

Purpose: Used for querying data sources that can be remote, like databases, XML files, etc.

Key Characteristics:
---------------------
Remote Data Sources: IQueryable is designed to work with data sources that may not be loaded into memory, such as databases.
Deferred Execution: Queries are not executed until the results are enumerated. This allows for building complex queries without immediate performance costs.
Expression Trees: IQueryable uses expression trees to represent the query. These trees are translated by the query provider into the appropriate query language (e.g., SQL).
Query Provider: IQueryable works with a query provider that translates the expression tree into a format that the data source understands.


Querayable Vs Enumerable:
-------------------------
IEnumerable is best suited for querying in-memory collections where immediate execution is acceptable.
IQueryable is ideal for querying remote data sources where deferred execution and expression trees are necessary for translating queries into the appropriate format.


**/
namespace LinqInterface{
    class IQueryableClass{
        public static void Main(){
            Console.WriteLine("IQueryable...");
        }
    }
}