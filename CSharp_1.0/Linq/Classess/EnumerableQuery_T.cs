/**
Represents an IEnumerable<T> collection as an IQueryable<T> data source.

public class EnumerableQuery<T> : System.Linq.EnumerableQuery, System.Collections.Generic.IEnumerable<T>, System.Linq.IOrderedQueryable<T>, System.Linq.IQueryable<T>, System.Linq.IQueryProvider

Constructors
EnumerableQuery<T>(Expression)	
This API supports the product infrastructure and is not intended to be used directly from your code.

Initializes a new instance of the EnumerableQuery<T> class and associates the instance with an expression tree.

EnumerableQuery<T>(IEnumerable<T>)	
This API supports the product infrastructure and is not intended to be used directly from your code.

Initializes a new instance of the EnumerableQuery<T> class and associates it with an IEnumerable<T> collection.

Methods
Equals(Object)	
Determines whether the specified object is equal to the current object.

(Inherited from Object)
GetHashCode()	
Serves as the default hash function.

(Inherited from Object)
GetType()	
Gets the Type of the current instance.

(Inherited from Object)
MemberwiseClone()	
Creates a shallow copy of the current Object.

(Inherited from Object)
ToString()	
This API supports the product infrastructure and is not intended to be used directly from your code.

Returns a textual representation of the enumerable collection or, if it is null, of the expression tree that is associated with this instance.

**/