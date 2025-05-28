/**
HttpMethod Classs:
--------------------
A helper class for retrieving and comparing standard HTTP methods and for creating new HTTP methods.

public class HttpMethod : IEquatable<System.Net.Http.HttpMethod>

Remarks
The most common usage of HttpMethod is to use one of the static properties on this class. However, if an app needs a different value for the HTTP method, the HttpMethod constructor initializes a new instance of the HttpMethod with an HTTP method that the app specifies.

Constructors
HttpMethod(String)	
Initializes a new instance of the HttpMethod class with a specific HTTP method.

Properties
Connect	
Gets the HTTP CONNECT protocol method.

Delete	
Represents an HTTP DELETE protocol method.

Get	
Represents an HTTP GET protocol method.

Head	
Represents an HTTP HEAD protocol method. The HEAD method is identical to GET except that the server only returns message-headers in the response, without a message-body.

Method	
An HTTP method.

Options	
Represents an HTTP OPTIONS protocol method.

Patch	
Gets the HTTP PATCH protocol method.

Post	
Represents an HTTP POST protocol method that is used to post a new entity as an addition to a URI.

Put	
Represents an HTTP PUT protocol method that is used to replace an entity identified by a URI.

Trace	
Represents an HTTP TRACE protocol method.

Methods
Equals(HttpMethod)	
Determines whether the specified HttpMethod is equal to the current Object.

Equals(Object)	
Determines whether the specified Object is equal to the current Object.

GetHashCode()	
Serves as a hash function for this type.

GetType()	
Gets the Type of the current instance.

(Inherited from Object)
MemberwiseClone()	
Creates a shallow copy of the current Object.

(Inherited from Object)
Parse(ReadOnlySpan<Char>)	
Parses the provided method into an HttpMethod instance.

ToString()	
Returns a string that represents the current object.

Operators
Equality(HttpMethod, HttpMethod)	
The equality operator for comparing two HttpMethod objects.

Inequality(HttpMethod, HttpMethod)	
The inequality operator for comparing two HttpMethod objects.

**/