using System;
/**
Represents the result of a sorting operation.
    public interface IOrderedQueryable<out T> : System.Collections.Generic.IEnumerable<out T>, System.Linq.IOrderedQueryable, System.Linq.IQueryable<out T>

The IOrderedQueryable<T> interface is intended for implementation by query providers.

This interface represents the result of a sorting query that calls the method(s) OrderBy, OrderByDescending, ThenBy or ThenByDescending. When CreateQuery<TElement>(Expression) is called and passed an expression tree that represents a sorting query, the resulting IQueryable<T> object must be of a type that implements IOrderedQueryable<T>.

Properties:
----------
ElementType	- Gets the type of the element(s) that are returned when the expression tree associated with this instance of IQueryable is executed.(Inherited from IQueryable)
Expression	- Gets the expression tree that is associated with the instance of IQueryable.(Inherited from IQueryable)
Provider - Gets the query provider that is associated with this data source.(Inherited from IQueryable)

Methods:
--------
GetEnumerator()	- Returns an enumerator that iterates through a collection.(Inherited from IEnumerable) 

Extension Methods:
-------------------
Cast<TResult>(IEnumerable)	- Casts the elements of an IEnumerable to the specified type.
OfType<TResult>(IEnumerable)	- Filters the elements of an IEnumerable based on a specified type.
AsParallel(IEnumerable)	- Enables parallelization of a query.
AsQueryable(IEnumerable)	- Converts an IEnumerable to an IQueryable.
Cast<TResult>(IQueryable)	- Converts the elements of an IQueryable to the specified type.
OfType<TResult>(IQueryable)	- Filters the elements of an IQueryable based on a specified type.


**/
namespace LinqInterface{
    class IOrderedQueryableT{
        public static void Main(){
            Console.WriteLine("IOrdered Queryable.");
        }
    }
}