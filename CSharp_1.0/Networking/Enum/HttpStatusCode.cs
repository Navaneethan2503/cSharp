/**
HttpStatusCode Enum:
--------------------
Contains the values of status codes defined for HTTP defined in RFC 2616 for HTTP 1.1.

public enum HttpStatusCode


Fields
Name	Value	Description
Continue	100	
Equivalent to HTTP status 100. Continue indicates that the client can continue with its request.

SwitchingProtocols	101	
Equivalent to HTTP status 101. SwitchingProtocols indicates that the protocol version or protocol is being changed.

Processing	102	
Equivalent to HTTP status 102. Processing indicates that the server has accepted the complete request but hasn't completed it yet.

EarlyHints	103	
Equivalent to HTTP status 103. EarlyHints indicates to the client that the server is likely to send a final response with the header fields included in the informational response.

OK	200	
Equivalent to HTTP status 200. OK indicates that the request succeeded and that the requested information is in the response. This is the most common status code to receive.

Created	201	
Equivalent to HTTP status 201. Created indicates that the request resulted in a new resource created before the response was sent.

Accepted	202	
Equivalent to HTTP status 202. Accepted indicates that the request has been accepted for further processing.

NonAuthoritativeInformation	203	
Equivalent to HTTP status 203. NonAuthoritativeInformation indicates that the returned meta information is from a cached copy instead of the origin server and therefore may be incorrect.

NoContent	204	
Equivalent to HTTP status 204. NoContent indicates that the request has been successfully processed and that the response is intentionally blank.

ResetContent	205	
Equivalent to HTTP status 205. ResetContent indicates that the client should reset (not reload) the current resource.

PartialContent	206	
Equivalent to HTTP status 206. PartialContent indicates that the response is a partial response as requested by a GET request that includes a byte range.

MultiStatus	207	
Equivalent to HTTP status 207. MultiStatus indicates multiple status codes for a single response during a Web Distributed Authoring and Versioning (WebDAV) operation. The response body contains XML that describes the status codes.

AlreadyReported	208	
Equivalent to HTTP status 208. AlreadyReported indicates that the members of a WebDAV binding have already been enumerated in a preceding part of the multistatus response, and are not being included again.

IMUsed	226	
Equivalent to HTTP status 226. IMUsed indicates that the server has fulfilled a request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance.

Ambiguous	300	
Equivalent to HTTP status 300. Ambiguous indicates that the requested information has multiple representations. The default action is to treat this status as a redirect and follow the contents of the Location header associated with this response. Ambiguous is a synonym for MultipleChoices.

MultipleChoices	300	
Equivalent to HTTP status 300. MultipleChoices indicates that the requested information has multiple representations. The default action is to treat this status as a redirect and follow the contents of the Location header associated with this response. MultipleChoices is a synonym for Ambiguous.

Moved	301	
Equivalent to HTTP status 301. Moved indicates that the requested information has been moved to the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method. Moved is a synonym for MovedPermanently.

MovedPermanently	301	
Equivalent to HTTP status 301. MovedPermanently indicates that the requested information has been moved to the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. MovedPermanently is a synonym for Moved.

Found	302	
Equivalent to HTTP status 302. Found indicates that the requested information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method. Found is a synonym for Redirect.

Redirect	302	
Equivalent to HTTP status 302. Redirect indicates that the requested information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method. Redirect is a synonym for Found.

RedirectMethod	303	
Equivalent to HTTP status 303. RedirectMethod automatically redirects the client to the URI specified in the Location header as the result of a POST. The request to the resource specified by the Location header will be made with a GET. RedirectMethod is a synonym for SeeOther.

SeeOther	303	
Equivalent to HTTP status 303. SeeOther automatically redirects the client to the URI specified in the Location header as the result of a POST. The request to the resource specified by the Location header will be made with a GET. SeeOther is a synonym for RedirectMethod.

NotModified	304	
Equivalent to HTTP status 304. NotModified indicates that the client's cached copy is up to date. The contents of the resource are not transferred.

UseProxy	305	
Equivalent to HTTP status 305. UseProxy indicates that the request should use the proxy server at the URI specified in the Location header.

Unused	306	
Equivalent to HTTP status 306. Unused is a proposed extension to the HTTP/1.1 specification that is not fully specified.

RedirectKeepVerb	307	
Equivalent to HTTP status 307. RedirectKeepVerb indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method. RedirectKeepVerb is a synonym for TemporaryRedirect.

TemporaryRedirect	307	
Equivalent to HTTP status 307. TemporaryRedirect indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method. TemporaryRedirect is a synonym for RedirectKeepVerb.

PermanentRedirect	308	
Equivalent to HTTP status 308. PermanentRedirect indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method.

BadRequest	400	
Equivalent to HTTP status 400. BadRequest indicates that the request could not be understood by the server. BadRequest is sent when no other error is applicable, or if the exact error is unknown or does not have its own error code.

Unauthorized	401	
Equivalent to HTTP status 401. Unauthorized indicates that the requested resource requires authentication. The WWW-Authenticate header contains the details of how to perform the authentication.

PaymentRequired	402	
Equivalent to HTTP status 402. PaymentRequired is reserved for future use.

Forbidden	403	
Equivalent to HTTP status 403. Forbidden indicates that the server refuses to fulfill the request.

NotFound	404	
Equivalent to HTTP status 404. NotFound indicates that the requested resource does not exist on the server.

MethodNotAllowed	405	
Equivalent to HTTP status 405. MethodNotAllowed indicates that the request method (POST or GET) is not allowed on the requested resource.

NotAcceptable	406	
Equivalent to HTTP status 406. NotAcceptable indicates that the client has indicated with Accept headers that it will not accept any of the available representations of the resource.

ProxyAuthenticationRequired	407	
Equivalent to HTTP status 407. ProxyAuthenticationRequired indicates that the requested proxy requires authentication. The Proxy-authenticate header contains the details of how to perform the authentication.

RequestTimeout	408	
Equivalent to HTTP status 408. RequestTimeout indicates that the client did not send a request within the time the server was expecting the request.

Conflict	409	
Equivalent to HTTP status 409. Conflict indicates that the request could not be carried out because of a conflict on the server.

Gone	410	
Equivalent to HTTP status 410. Gone indicates that the requested resource is no longer available.

LengthRequired	411	
Equivalent to HTTP status 411. LengthRequired indicates that the required Content-length header is missing.

PreconditionFailed	412	
Equivalent to HTTP status 412. PreconditionFailed indicates that a condition set for this request failed, and the request cannot be carried out. Conditions are set with conditional request headers like If-Match, If-None-Match, or If-Unmodified-Since.

RequestEntityTooLarge	413	
Equivalent to HTTP status 413. RequestEntityTooLarge indicates that the request is too large for the server to process.

RequestUriTooLong	414	
Equivalent to HTTP status 414. RequestUriTooLong indicates that the URI is too long.

UnsupportedMediaType	415	
Equivalent to HTTP status 415. UnsupportedMediaType indicates that the request is an unsupported type.

RequestedRangeNotSatisfiable	416	
Equivalent to HTTP status 416. RequestedRangeNotSatisfiable indicates that the range of data requested from the resource cannot be returned, either because the beginning of the range is before the beginning of the resource, or the end of the range is after the end of the resource.

ExpectationFailed	417	
Equivalent to HTTP status 417. ExpectationFailed indicates that an expectation given in an Expect header could not be met by the server.

MisdirectedRequest	421	
Equivalent to HTTP status 421. MisdirectedRequest indicates that the request was directed at a server that is not able to produce a response.

UnprocessableContent	422	
Equivalent to HTTP status 422. UnprocessableContent indicates that the request was well-formed but was unable to be followed due to semantic errors. UnprocessableContent is a synonym for UnprocessableEntity.

UnprocessableEntity	422	
Equivalent to HTTP status 422. UnprocessableEntity indicates that the request was well-formed but was unable to be followed due to semantic errors. UnprocessableEntity is a synonym for UnprocessableContent.

Locked	423	
Equivalent to HTTP status 423. Locked indicates that the source or destination resource is locked.

FailedDependency	424	
Equivalent to HTTP status 424. FailedDependency indicates that the method couldn't be performed on the resource because the requested action depended on another action and that action failed.

UpgradeRequired	426	
Equivalent to HTTP status 426. UpgradeRequired indicates that the client should switch to a different protocol such as TLS/1.0.

PreconditionRequired	428	
Equivalent to HTTP status 428. PreconditionRequired indicates that the server requires the request to be conditional.

TooManyRequests	429	
Equivalent to HTTP status 429. TooManyRequests indicates that the user has sent too many requests in a given amount of time.

RequestHeaderFieldsTooLarge	431	
Equivalent to HTTP status 431. RequestHeaderFieldsTooLarge indicates that the server is unwilling to process the request because its header fields (either an individual header field or all the header fields collectively) are too large.

UnavailableForLegalReasons	451	
Equivalent to HTTP status 451. UnavailableForLegalReasons indicates that the server is denying access to the resource as a consequence of a legal demand.

InternalServerError	500	
Equivalent to HTTP status 500. InternalServerError indicates that a generic error has occurred on the server.

NotImplemented	501	
Equivalent to HTTP status 501. NotImplemented indicates that the server does not support the requested function.

BadGateway	502	
Equivalent to HTTP status 502. BadGateway indicates that an intermediate proxy server received a bad response from another proxy or the origin server.

ServiceUnavailable	503	
Equivalent to HTTP status 503. ServiceUnavailable indicates that the server is temporarily unavailable, usually due to high load or maintenance.

GatewayTimeout	504	
Equivalent to HTTP status 504. GatewayTimeout indicates that an intermediate proxy server timed out while waiting for a response from another proxy or the origin server.

HttpVersionNotSupported	505	
Equivalent to HTTP status 505. HttpVersionNotSupported indicates that the requested HTTP version is not supported by the server.

VariantAlsoNegotiates	506	
Equivalent to HTTP status 506. VariantAlsoNegotiates indicates that the chosen variant resource is configured to engage in transparent content negotiation itself and, therefore, isn't a proper endpoint in the negotiation process.

InsufficientStorage	507	
Equivalent to HTTP status 507. InsufficientStorage indicates that the server is unable to store the representation needed to complete the request.

LoopDetected	508	
Equivalent to HTTP status 508. LoopDetected indicates that the server terminated an operation because it encountered an infinite loop while processing a WebDAV request with "Depth: infinity". This status code is meant for backward compatibility with clients not aware of the 208 status code AlreadyReported appearing in multistatus response bodies.

NotExtended	510	
Equivalent to HTTP status 510. NotExtended indicates that further extensions to the request are required for the server to fulfill it.

NetworkAuthenticationRequired	511	
Equivalent to HTTP status 511. NetworkAuthenticationRequired indicates that the client needs to authenticate to gain network access; it's intended for use by intercepting proxies used to control access to the network.
**/
