/**
HttpResponseMessage Class:
--------------------------
Represents a HTTP response message including the status code and data.
    public class HttpResponseMessage : IDisposable

Constructors
HttpResponseMessage()	
Initializes a new instance of the HttpResponseMessage class.

HttpResponseMessage(HttpStatusCode)	
Initializes a new instance of the HttpResponseMessage class with a specific StatusCode.

Properties
Content	
Gets or sets the content of a HTTP response message.

Headers	
Gets the collection of HTTP response headers.

IsSuccessStatusCode	
Gets a value that indicates if the HTTP response was successful.

ReasonPhrase	
Gets or sets the reason phrase, which typically is sent by servers together with the status code.

RequestMessage	
Gets or sets the request message that led to this response message.

StatusCode	
Gets or sets the status code of the HTTP response.

TrailingHeaders	
Gets the collection of trailing headers included in an HTTP response.

Version	
Gets or sets the HTTP message version.

Methods
Dispose()	
Releases the unmanaged resources and disposes of unmanaged resources used by the HttpResponseMessage.

Dispose(Boolean)	
Releases the unmanaged resources used by the HttpResponseMessage and optionally disposes of the managed resources.

EnsureSuccessStatusCode()	
Throws an exception if the IsSuccessStatusCode property for the HTTP response is false.

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
Returns a string that represents the current object.


**/