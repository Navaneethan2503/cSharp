/**
HttpRequestMessage Class:
---------------------------
Represents a HTTP request message.

public class HttpRequestMessage : IDisposable

Constructors
HttpRequestMessage()	
Initializes a new instance of the HttpRequestMessage class.

HttpRequestMessage(HttpMethod, String)	
Initializes a new instance of the HttpRequestMessage class with an HTTP method and a request Uri.

HttpRequestMessage(HttpMethod, Uri)	
Initializes a new instance of the HttpRequestMessage class with an HTTP method and a request Uri.

Properties
Content	
Gets or sets the contents of the HTTP message.

Headers	
Gets the collection of HTTP request headers.

Method	
Gets or sets the HTTP method used by the HTTP request message.

Options	
Gets the collection of options to configure the HTTP request.

Properties	
Obsolete.
Gets a set of properties for the HTTP request.

RequestUri	
Gets or sets the Uri used for the HTTP request.

Version	
Gets or sets the HTTP message version.

VersionPolicy	
Gets or sets the policy that determines how Version is interpreted and how the final HTTP version is negotiated with the server.

Methods
Dispose()	
Releases the unmanaged resources and disposes of the managed resources used by the HttpRequestMessage.

Dispose(Boolean)	
Releases the unmanaged resources used by the HttpRequestMessage and optionally disposes of the managed resources.

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