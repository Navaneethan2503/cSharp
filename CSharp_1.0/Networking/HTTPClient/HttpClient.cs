/**
HttpClient Class:
-------------------
Provides a class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.

public class HttpClient : System.Net.Http.HttpMessageInvoker

Constructors
HttpClient()	
Initializes a new instance of the HttpClient class using a HttpClientHandler that is disposed when this instance is disposed.

HttpClient(HttpMessageHandler, Boolean)	
Initializes a new instance of the HttpClient class with the provided handler, and specifies whether that handler should be disposed when this instance is disposed.

HttpClient(HttpMessageHandler)	
Initializes a new instance of the HttpClient class with the specified handler. The handler is disposed when this instance is disposed.

Properties
BaseAddress	
Gets or sets the base address of Uniform Resource Identifier (URI) of the Internet resource used when sending requests.

DefaultProxy	
Gets or sets the global HTTP proxy.

DefaultRequestHeaders	
Gets the headers which should be sent with each request.

DefaultRequestVersion	
Gets or sets the default HTTP version used on subsequent requests made by this HttpClient instance.

DefaultVersionPolicy	
Gets or sets the default version policy for implicitly created requests in convenience methods, for example, GetAsync(String) and PostAsync(String, HttpContent).

MaxResponseContentBufferSize	
Gets or sets the maximum number of bytes to buffer when reading the response content.

Timeout	
Gets or sets the timespan to wait before the request times out.

Methods
CancelPendingRequests()	
Cancel all pending requests on this instance.

DeleteAsync(String, CancellationToken)	
Send a DELETE request to the specified URI with a cancellation token as an asynchronous operation.

DeleteAsync(String)	
Send a DELETE request to the specified URI as an asynchronous operation.

DeleteAsync(Uri, CancellationToken)	
Send a DELETE request to the specified URI with a cancellation token as an asynchronous operation.

DeleteAsync(Uri)	
Send a DELETE request to the specified URI as an asynchronous operation.

Dispose()	
Releases the unmanaged resources and disposes of the managed resources used by the HttpMessageInvoker.

(Inherited from HttpMessageInvoker)
Dispose(Boolean)	
Releases the unmanaged resources used by the HttpClient and optionally disposes of the managed resources.

Equals(Object)	
Determines whether the specified object is equal to the current object.

(Inherited from Object)
GetAsync(String, CancellationToken)	
Send a GET request to the specified URI with a cancellation token as an asynchronous operation.

GetAsync(String, HttpCompletionOption, CancellationToken)	
Send a GET request to the specified URI with an HTTP completion option and a cancellation token as an asynchronous operation.

GetAsync(String, HttpCompletionOption)	
Send a GET request to the specified URI with an HTTP completion option as an asynchronous operation.

GetAsync(String)	
Send a GET request to the specified URI as an asynchronous operation.

GetAsync(Uri, CancellationToken)	
Send a GET request to the specified URI with a cancellation token as an asynchronous operation.

GetAsync(Uri, HttpCompletionOption, CancellationToken)	
Send a GET request to the specified URI with an HTTP completion option and a cancellation token as an asynchronous operation.

GetAsync(Uri, HttpCompletionOption)	
Send a GET request to the specified URI with an HTTP completion option as an asynchronous operation.

GetAsync(Uri)	
Send a GET request to the specified URI as an asynchronous operation.

GetByteArrayAsync(String, CancellationToken)	
Sends a GET request to the specified URI and return the response body as a byte array in an asynchronous operation.

GetByteArrayAsync(String)	
Sends a GET request to the specified URI and return the response body as a byte array in an asynchronous operation.

GetByteArrayAsync(Uri, CancellationToken)	
Send a GET request to the specified URI and return the response body as a byte array in an asynchronous operation.

GetByteArrayAsync(Uri)	
Send a GET request to the specified URI and return the response body as a byte array in an asynchronous operation.

GetHashCode()	
Serves as the default hash function.

(Inherited from Object)
GetStreamAsync(String, CancellationToken)	
Send a GET request to the specified URI and return the response body as a stream in an asynchronous operation.

GetStreamAsync(String)	
Send a GET request to the specified URI and return the response body as a stream in an asynchronous operation.

GetStreamAsync(Uri, CancellationToken)	
Send a GET request to the specified URI and return the response body as a stream in an asynchronous operation.

GetStreamAsync(Uri)	
Send a GET request to the specified URI and return the response body as a stream in an asynchronous operation.

GetStringAsync(String, CancellationToken)	
Send a GET request to the specified URI and return the response body as a string in an asynchronous operation.

GetStringAsync(String)	
Send a GET request to the specified URI and return the response body as a string in an asynchronous operation.

GetStringAsync(Uri, CancellationToken)	
Send a GET request to the specified URI and return the response body as a string in an asynchronous operation.

GetStringAsync(Uri)	
Send a GET request to the specified URI and return the response body as a string in an asynchronous operation.

GetType()	
Gets the Type of the current instance.

(Inherited from Object)
MemberwiseClone()	
Creates a shallow copy of the current Object.

(Inherited from Object)
PatchAsync(String, HttpContent, CancellationToken)	
Sends a PATCH request with a cancellation token to a URI represented as a string as an asynchronous operation.

PatchAsync(String, HttpContent)	
Sends a PATCH request to a URI designated as a string as an asynchronous operation.

PatchAsync(Uri, HttpContent, CancellationToken)	
Sends a PATCH request with a cancellation token as an asynchronous operation.

PatchAsync(Uri, HttpContent)	
Sends a PATCH request as an asynchronous operation.

PostAsync(String, HttpContent, CancellationToken)	
Send a POST request with a cancellation token as an asynchronous operation.

PostAsync(String, HttpContent)	
Send a POST request to the specified URI as an asynchronous operation.

PostAsync(Uri, HttpContent, CancellationToken)	
Send a POST request with a cancellation token as an asynchronous operation.

PostAsync(Uri, HttpContent)	
Send a POST request to the specified URI as an asynchronous operation.

PutAsync(String, HttpContent, CancellationToken)	
Send a PUT request with a cancellation token as an asynchronous operation.

PutAsync(String, HttpContent)	
Send a PUT request to the specified URI as an asynchronous operation.

PutAsync(Uri, HttpContent, CancellationToken)	
Send a PUT request with a cancellation token as an asynchronous operation.

PutAsync(Uri, HttpContent)	
Send a PUT request to the specified URI as an asynchronous operation.

Send(HttpRequestMessage, CancellationToken)	
Sends an HTTP request with the specified request and cancellation token.

Send(HttpRequestMessage, HttpCompletionOption, CancellationToken)	
Sends an HTTP request with the specified request, completion option and cancellation token.

Send(HttpRequestMessage, HttpCompletionOption)	
Sends an HTTP request.

Send(HttpRequestMessage)	
Sends an HTTP request with the specified request.

SendAsync(HttpRequestMessage, CancellationToken)	
Send an HTTP request as an asynchronous operation.

SendAsync(HttpRequestMessage, HttpCompletionOption, CancellationToken)	
Send an HTTP request as an asynchronous operation.

SendAsync(HttpRequestMessage, HttpCompletionOption)	
Send an HTTP request as an asynchronous operation.

SendAsync(HttpRequestMessage)	
Send an HTTP request as an asynchronous operation.

ToString()	
Returns a string that represents the current object.

(Inherited from Object)
Extension Methods
DeleteFromJsonAsync(HttpClient, String, Type, JsonSerializerOptions, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync(HttpClient, String, Type, JsonSerializerContext, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync(HttpClient, String, Type, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync(HttpClient, Uri, Type, JsonSerializerOptions, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync(HttpClient, Uri, Type, JsonSerializerContext, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync(HttpClient, Uri, Type, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync<TValue>(HttpClient, String, JsonSerializerOptions, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync<TValue>(HttpClient, String, JsonTypeInfo<TValue>, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync<TValue>(HttpClient, String, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync<TValue>(HttpClient, Uri, JsonSerializerOptions, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync<TValue>(HttpClient, Uri, JsonTypeInfo<TValue>, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

DeleteFromJsonAsync<TValue>(HttpClient, Uri, CancellationToken)	
Sends a DELETE request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsAsyncEnumerable<TValue>(HttpClient, String, JsonSerializerOptions, CancellationToken)	
Sends an HTTP GET request to the specified requestUri and returns the value that results from deserializing the response body as JSON in an async enumerable operation.

GetFromJsonAsAsyncEnumerable<TValue>(HttpClient, String, JsonTypeInfo<TValue>, CancellationToken)	
Sends an HTTP GETrequest to the specified requestUri and returns the value that results from deserializing the response body as JSON in an async enumerable operation.

GetFromJsonAsAsyncEnumerable<TValue>(HttpClient, String, CancellationToken)	
Sends an HTTP GETrequest to the specified requestUri and returns the value that results from deserializing the response body as JSON in an async enumerable operation.

GetFromJsonAsAsyncEnumerable<TValue>(HttpClient, Uri, JsonSerializerOptions, CancellationToken)	
Sends an HTTP GETrequest to the specified requestUri and returns the value that results from deserializing the response body as JSON in an async enumerable operation.

GetFromJsonAsAsyncEnumerable<TValue>(HttpClient, Uri, JsonTypeInfo<TValue>, CancellationToken)	
Sends an HTTP GETrequest to the specified requestUri and returns the value that results from deserializing the response body as JSON in an async enumerable operation.

GetFromJsonAsAsyncEnumerable<TValue>(HttpClient, Uri, CancellationToken)	
Sends an HTTP GETrequest to the specified requestUri and returns the value that results from deserializing the response body as JSON in an async enumerable operation.

GetFromJsonAsync(HttpClient, String, Type, JsonSerializerOptions, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync(HttpClient, String, Type, JsonSerializerContext, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync(HttpClient, String, Type, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync(HttpClient, Uri, Type, JsonSerializerOptions, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync(HttpClient, Uri, Type, JsonSerializerContext, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync(HttpClient, Uri, Type, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync<TValue>(HttpClient, String, JsonSerializerOptions, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync<TValue>(HttpClient, String, JsonTypeInfo<TValue>, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync<TValue>(HttpClient, String, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync<TValue>(HttpClient, Uri, JsonSerializerOptions, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync<TValue>(HttpClient, Uri, JsonTypeInfo<TValue>, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

GetFromJsonAsync<TValue>(HttpClient, Uri, CancellationToken)	
Sends a GET request to the specified Uri and returns the value that results from deserializing the response body as JSON in an asynchronous operation.

PatchAsJsonAsync<TValue>(HttpClient, String, TValue, JsonSerializerOptions, CancellationToken)	
Sends a PATCH request to the specified Uri containing the value serialized as JSON in the request body.

PatchAsJsonAsync<TValue>(HttpClient, String, TValue, JsonTypeInfo<TValue>, CancellationToken)	
Sends a PATCH request to the specified Uri containing the value serialized as JSON in the request body.

PatchAsJsonAsync<TValue>(HttpClient, String, TValue, CancellationToken)	
Sends a PATCH request to the specified Uri containing the value serialized as JSON in the request body.

PatchAsJsonAsync<TValue>(HttpClient, Uri, TValue, JsonSerializerOptions, CancellationToken)	
Sends a PATCH request to the specified Uri containing the value serialized as JSON in the request body.

PatchAsJsonAsync<TValue>(HttpClient, Uri, TValue, JsonTypeInfo<TValue>, CancellationToken)	
Sends a PATCH request to the specified Uri containing the value serialized as JSON in the request body.

PatchAsJsonAsync<TValue>(HttpClient, Uri, TValue, CancellationToken)	
Sends a PATCH request to the specified Uri containing the value serialized as JSON in the request body.

PostAsJsonAsync<TValue>(HttpClient, String, TValue, JsonSerializerOptions, CancellationToken)	
Sends a POST request to the specified Uri containing the value serialized as JSON in the request body.

PostAsJsonAsync<TValue>(HttpClient, String, TValue, JsonTypeInfo<TValue>, CancellationToken)	
Sends a POST request to the specified Uri containing the value serialized as JSON in the request body.

PostAsJsonAsync<TValue>(HttpClient, String, TValue, CancellationToken)	
Sends a POST request to the specified Uri containing the value serialized as JSON in the request body.

PostAsJsonAsync<TValue>(HttpClient, Uri, TValue, JsonSerializerOptions, CancellationToken)	
Sends a POST request to the specified Uri containing the value serialized as JSON in the request body.

PostAsJsonAsync<TValue>(HttpClient, Uri, TValue, JsonTypeInfo<TValue>, CancellationToken)	
Sends a POST request to the specified Uri containing the value serialized as JSON in the request body.

PostAsJsonAsync<TValue>(HttpClient, Uri, TValue, CancellationToken)	
Sends a POST request to the specified Uri containing the value serialized as JSON in the request body.

PutAsJsonAsync<TValue>(HttpClient, String, TValue, JsonSerializerOptions, CancellationToken)	
Send a PUT request to the specified Uri containing the value serialized as JSON in the request body.

PutAsJsonAsync<TValue>(HttpClient, String, TValue, JsonTypeInfo<TValue>, CancellationToken)	
Send a PUT request to the specified Uri containing the value serialized as JSON in the request body.

PutAsJsonAsync<TValue>(HttpClient, String, TValue, CancellationToken)	
Send a PUT request to the specified Uri containing the value serialized as JSON in the request body.

PutAsJsonAsync<TValue>(HttpClient, Uri, TValue, JsonSerializerOptions, CancellationToken)	
Send a PUT request to the specified Uri containing the value serialized as JSON in the request body.

PutAsJsonAsync<TValue>(HttpClient, Uri, TValue, JsonTypeInfo<TValue>, CancellationToken)	
Send a PUT request to the specified Uri containing the value serialized as JSON in the request body.

PutAsJsonAsync<TValue>(HttpClient, Uri, TValue, CancellationToken)	
Send a PUT request to the specified Uri containing the value serialized as JSON in the request body.

**/