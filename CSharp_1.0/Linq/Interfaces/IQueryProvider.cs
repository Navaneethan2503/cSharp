using System;
/**
Defines methods to create and execute queries that are described by an IQueryable object.
    public interface IQueryProvider

The IQueryProvider interface is intended for implementation by query providers.

Methods:
--------
CreateQuery(Expression)	- Constructs an IQueryable object that can evaluate the query represented by a specified expression tree.
CreateQuery<TElement>(Expression) - Constructs an IQueryable<T> object that can evaluate the query represented by a specified expression tree.
Execute(Expression)	-Executes the query represented by a specified expression tree.
Execute<TResult>(Expression) - Executes the strongly-typed query represented by a specified expression tree.


**/
namespace LinqInterface{
    class IQueryProviderClass{
        public static void Main(){
            Console.WriteLine("IQuery Provider .");
        }
    }
}