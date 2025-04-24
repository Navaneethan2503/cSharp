using System;
using System.Linq;
/**
Provides functionality to evaluate queries against a specific data source wherein the type of the data is known.

    public interface IQueryable<out T> : System.Collections.Generic.IEnumerable<out T>, System.Linq.IQueryable

The IQueryable<T> interface is intended for implementation by query providers.

This interface inherits the IEnumerable<T> interface so that if it represents a query, the results of that query can be enumerated. Enumeration forces the expression tree associated with an IQueryable<T> object to be executed. Queries that do not return enumerable results are executed when the Execute<TResult>(Expression) method is called.

The definition of "executing an expression tree" is specific to a query provider. For example, it may involve translating the expression tree to a query language appropriate for an underlying data source.

The IQueryable<T> interface enables queries to be polymorphic. That is, because a query against an IQueryable data source is represented as an expression tree, it can be executed against different types of data sources.

Properties:
------------
ElementType	- Gets the type of the element(s) that are returned when the expression tree associated with this instance of IQueryable is executed.(Inherited from IQueryable)
Expression	- Gets the expression tree that is associated with the instance of IQueryable.(Inherited from IQueryable)
Provider - Gets the query provider that is associated with this data source.(Inherited from IQueryable)

Methods:
---------
GetEnumerator()	- Returns an enumerator that iterates through a collection.(Inherited from IEnumerable)


**/
namespace LinqInterface{
    class IQueryableTClass{
        public static void Main(){
            Console.WriteLine("IQueryable Generic Type wherein Type of data is known.");
        }
    }
}