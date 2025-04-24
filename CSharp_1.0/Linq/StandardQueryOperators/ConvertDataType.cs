using System;
using System.Linq;
using System.Collections.Generic;
/**
Conversion methods change the type of input objects.

Conversion operations in LINQ queries are useful in various applications. Following are some examples:
The Enumerable.AsEnumerable method can be used to hide a type's custom implementation of a standard query operator.
The Enumerable.OfType method can be used to enable non-parameterized collections for LINQ querying.
The Enumerable.ToArray, Enumerable.ToDictionary, Enumerable.ToList, and Enumerable.ToLookup methods can be used to force immediate query execution instead of deferring it until the query is enumerated.

Method Name	Description	C# Query Expression Syntax	More Information
AsEnumerable	Returns the input typed as IEnumerable<T>.	Not applicable.	Enumerable.AsEnumerable
AsQueryable	Converts a (generic) IEnumerable to a (generic) IQueryable.	Not applicable.	Queryable.AsQueryable
Cast	Casts the elements of a collection to a specified type.	Use an explicitly typed range variable. 

For example:
from string str in words	Enumerable.Cast
                            Queryable.Cast
OfType	Filters values, depending on their ability to be cast to a specified type.	Not applicable.	Enumerable.OfType
                                                                                                        Queryable.OfType
ToArray	Converts a collection to an array. This method forces query execution.	Not applicable.	Enumerable.ToArray
ToDictionary	Puts elements into a Dictionary<TKey,TValue> based on a key selector function. This method forces query execution.	Not applicable.	Enumerable.ToDictionary
ToList	Converts a collection to a List<T>. This method forces query execution.	Not applicable.	Enumerable.ToList
ToLookup	Puts elements into a Lookup<TKey,TElement> (a one-to-many dictionary) based on a key selector function. This method forces query execution.	Not applicable.	Enumerable.ToLookup

**/
namespace StandardQueryOperators{
    class ConvertDataType{
        public static void Main(){
            Console.WriteLine("Convert Data Type Linq");
        }
    }
}