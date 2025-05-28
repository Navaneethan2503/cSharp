
/**
URI :
-------
.NET provides a layered, extensible, and managed implementation of Internet services that can be quickly and easily integrated into your apps. Your network apps can build on pluggable protocols to automatically take advantage of various Internet protocols, or they can use a managed implementation of cross-platform socket interfaces to work with the network on the socket level.

Internet apps:
--------------
Internet apps can be classified broadly into two kinds: client apps that request information and server apps that respond to information requests from clients. The classic Internet client-server app is the World Wide Web, where people use browsers to access documents and other data stored on web servers worldwide.

Apps are not limited to just one of these roles; for instance, the familiar middle-tier app server responds to requests from clients by requesting data from another server, in which case it is acting as both a server and a client.

The client app requests by identifying the requested Internet resource and the communication protocol to use for the request and response. If necessary, the client also provides any additional data required to complete the request, such as proxy location or authentication information (user name, password, and so on). Once the request is formed, the request can be sent to the server.

Identifying resources:
-----------------------
.NET uses a uniform resource identifier (URI) to identify the requested Internet resource and communication protocol. The URI consists of at least three, and possibly four, fragments: the scheme identifier, which identifies the communications protocol for the request and response; the server identifier, which consists of either a domain name system (DNS) hostname or a TCP address that uniquely identifies the server on the Internet; the path identifier, which locates the requested information on the server; and an optional query string, which passes information from the client to the server.

The System.Uri type is used as a representation of a uniform resource identifier (URI) and easy access to the parts of the URI. To create a Uri instance you can pass it a string:
Uri canonicalUri = new(uriString);

The Uri class automatically performs validation and canonicalization per RFC 3986. These validation and canonicalization rules are used to ensure that a URI is well-formed and that the URI is in a canonical form.


Uri Class:
----------
Provides an object representation of a uniform resource identifier (URI) and easy access to the parts of the URI.

public class Uri : IEquatable<Uri>, ISpanFormattable, System.Runtime.Serialization.ISerializable

Constructors:
---------------

Uri(String, UriCreationOptions)	- Initializes a new instance of the Uri class with the specified URI and additional UriCreationOptions.
Uri(String, UriKind)	- Initializes a new instance of the Uri class with the specified URI. This constructor allows you to specify if the URI string is a relative URI, absolute URI, or is indeterminate.
Uri(String)	- Initializes a new instance of the Uri class with the specified URI.
    public Uri(string uriString);

Uri(Uri, String)	- Initializes a new instance of the Uri class based on the specified base URI and relative URI string.
    public Uri(Uri baseUri, string? relativeUri);

Uri(Uri, Uri)	- Initializes a new instance of the Uri class based on the combination of a specified base Uri instance and a relative Uri instance.
    public Uri(Uri baseUri, Uri relativeUri);

Fields:
---------
SchemeDelimiter	- Specifies the characters that separate the communication protocol scheme from the address portion of the URI. This field is read-only.
    public static readonly string SchemeDelimiter;

UriSchemeFile	- Specifies that the URI is a pointer to a file. This field is read-only.
UriSchemeFtp	- Specifies that the URI is accessed through the File Transfer Protocol (FTP). This field is read-only.
UriSchemeFtps	- Specifies that the URI is accessed through the File Transfer Protocol Secure (FTPS). This field is read-only.
UriSchemeGopher	- Specifies that the URI is accessed through the Gopher protocol. This field is read-only.
UriSchemeHttp	- Specifies that the URI is accessed through the Hypertext Transfer Protocol (HTTP). This field is read-only.
UriSchemeHttps	- Specifies that the URI is accessed through the Secure Hypertext Transfer Protocol (HTTPS). This field is read-only.
UriSchemeMailto	- Specifies that the URI is an email address and is accessed through the Simple Mail Transport Protocol (SMTP). This field is read-only.
UriSchemeNetPipe	- Specifies that the URI is accessed through the NetPipe scheme used by Windows Communication Foundation (WCF). This field is read-only.
UriSchemeNetTcp	- Specifies that the URI is accessed through the NetTcp scheme used by Windows Communication Foundation (WCF). This field is read-only.
UriSchemeNews	- Specifies that the URI is an Internet news group and is accessed through the Network News Transport Protocol (NNTP). This field is read-only.
UriSchemeNntp	- Specifies that the URI is an Internet news group and is accessed through the Network News Transport Protocol (NNTP). This field is read-only.
UriSchemeSftp	- Specifies that the URI is accessed through the SSH File Transfer Protocol (SFTP). This field is read-only.
UriSchemeSsh	- Specifies that the URI is accessed through the Secure Socket Shell protocol (SSH). This field is read-only.
UriSchemeTelnet	- Specifies that the URI is accessed through the Telnet protocol. This field is read-only.
UriSchemeWs	- Specifies that the URI is accessed through the WebSocket protocol (WS). This field is read-only.
UriSchemeWss	- Specifies that the URI is accessed through the WebSocket Secure protocol (WSS). This field is read-only.

Properties:
------------
AbsolutePath	- Gets the absolute path of the URI.
    public string AbsolutePath { get; }

AbsoluteUri	- Gets the absolute URI.
    public string AbsoluteUri { get; }

Authority	- Gets the Domain Name System (DNS) host name or IP address and the port number for a server.
    public string Authority { get; }

DnsSafeHost	- Gets a host name that, after being unescaped if necessary, is safe to use for DNS resolution.
    public string DnsSafeHost { get; }

Fragment	- Gets the escaped URI fragment, including the leading '#' character if not empty.
    public string Fragment { get; }

Host	- Gets the host component of this instance.
    public string Fragment { get; }

HostNameType	- Gets the type of the host name specified in the URI.
    public string Fragment { get; }

IdnHost	- Gets the RFC 3490 compliant International Domain Name of the host, using Punycode as appropriate. This string, after being unescaped if necessary, is safe to use for DNS resolution.
IsAbsoluteUri	- Gets a value that indicates whether the Uri instance is absolute.
IsDefaultPort	- Gets a value that indicates whether the port value of the URI is the default for this scheme.
    public bool IsDefaultPort { get; }
    
IsFile	- Gets a value that indicates whether the specified Uri is a file URI.
IsLoopback	- Gets a value that indicates whether the specified Uri references the local host.
IsUnc	- Gets a value that indicates whether the specified Uri is a universal naming convention (UNC) path.
LocalPath	- Gets a local operating-system representation of a file name.
OriginalString	- Gets the original URI string that was passed to the Uri constructor.
PathAndQuery	- Gets the AbsolutePath and Query properties separated by a question mark (?).
Port	- Gets the port number of this URI.
Query	- Gets any query information included in the specified URI, including the leading '?' character if not empty.
Scheme	- Gets the scheme name for this URI.
Segments	- Gets an array containing the path segments that make up the specified URI.
UserEscaped	- Gets a value that indicates whether the URI string was completely escaped before the Uri instance was created.
UserInfo	- Gets the user name, password, or other user-specific information associated with the specified URI.

Methods:
--------
CheckHostName(String)	- Determines whether the specified host name is a valid DNS name.
CheckSchemeName(String)	- Determines whether the specified scheme name is valid.
Compare(Uri, Uri, UriComponents, UriFormat, StringComparison)	- Compares the specified parts of two URIs using the specified comparison rules.
Equals(Object)	- Compares two Uri instances for equality.
Equals(Uri)	- Compares two Uri instances for equality.
EscapeDataString(ReadOnlySpan<Char>)	- Converts a span to its escaped representation.
EscapeDataString(String)	- Converts a string to its escaped representation.
FromHex(Char)	- Gets the decimal value of a hexadecimal digit.
GetComponents(UriComponents, UriFormat)	- Gets the specified components of the current instance using the specified escaping for special characters.
GetHashCode()	- Gets the hash code for the URI.
GetLeftPart(UriPartial)	- Gets the specified portion of a Uri instance.
GetObjectData(SerializationInfo, StreamingContext)	- Returns the data needed to serialize the current instance.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
HexEscape(Char)	- Converts a specified character into its hexadecimal equivalent.
HexUnescape(String, Int32)	- Converts a specified hexadecimal representation of a character to the character.
IsBaseOf(Uri)	- Determines whether the current Uri instance is a base of the specified Uri instance.
IsHexDigit(Char)	- Determines whether a specified character is a valid hexadecimal digit.
IsHexEncoding(String, Int32)	- Determines whether a character in a string is hexadecimal encoded.
IsWellFormedOriginalString()	- Indicates whether the string used to construct this Uri was well-formed and does not require further escaping.
IsWellFormedUriString(String, UriKind)	- Indicates whether the string is well-formed by attempting to construct a URI with the string and ensures that the string does not require further escaping.
MakeRelativeUri(Uri)	- Determines the difference between two Uri instances.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Gets a canonical string representation for the specified Uri instance.
TryCreate(String, UriCreationOptions, Uri)	- Creates a new Uri using the specified String instance and UriCreationOptions.
TryCreate(String, UriKind, Uri)	- Creates a new Uri using the specified String instance and a UriKind.
TryCreate(Uri, String, Uri)	- Creates a new Uri using the specified base and relative String instances.
TryCreate(Uri, Uri, Uri)	- Creates a new Uri using the specified base and relative Uri instances.
TryEscapeDataString(ReadOnlySpan<Char>, Span<Char>, Int32)	- Attempts to convert a span to its escaped representation.
TryFormat(Span<Char>, Int32)	- Attempts to format a canonical string representation for the Uri instance into the specified span.
TryUnescapeDataString(ReadOnlySpan<Char>, Span<Char>, Int32)	- Attempts to convert a span to its unescaped representation.
UnescapeDataString(ReadOnlySpan<Char>)	- Converts a span to its unescaped representation.
UnescapeDataString(String)	- Converts a string to its unescaped representation.

Operators:
-----------
Equality(Uri, Uri)	- Determines whether two Uri instances have the same value.
Inequality(Uri, Uri)	- Determines whether two Uri instances do not have the same value.

**/
using System;
using System.Net;

namespace Networking{
    class URIClass{
        public static void Main(){
            Console.WriteLine("Networking Class");
            Uri uri = new Uri("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName");

            Console.WriteLine($"AbsolutePath: {uri.AbsolutePath}");
            Console.WriteLine($"AbsoluteUri: {uri.AbsoluteUri}");
            Console.WriteLine($"DnsSafeHost: {uri.DnsSafeHost}");
            Console.WriteLine($"Fragment: {uri.Fragment}");
            Console.WriteLine($"Host: {uri.Host}");
            Console.WriteLine($"HostNameType: {uri.HostNameType}");
            Console.WriteLine($"IdnHost: {uri.IdnHost}");
            Console.WriteLine($"IsAbsoluteUri: {uri.IsAbsoluteUri}");
            Console.WriteLine($"IsDefaultPort: {uri.IsDefaultPort}");
            Console.WriteLine($"IsFile: {uri.IsFile}");
            Console.WriteLine($"IsLoopback: {uri.IsLoopback}");
            Console.WriteLine($"IsUnc: {uri.IsUnc}");
            Console.WriteLine($"LocalPath: {uri.LocalPath}");
            Console.WriteLine($"OriginalString: {uri.OriginalString}");
            Console.WriteLine($"PathAndQuery: {uri.PathAndQuery}");
            Console.WriteLine($"Port: {uri.Port}");
            Console.WriteLine($"Query: {uri.Query}");
            Console.WriteLine($"Scheme: {uri.Scheme}");
            Console.WriteLine($"Segments: {string.Join(", ", uri.Segments)}");
            Console.WriteLine($"UserEscaped: {uri.UserEscaped}");
            Console.WriteLine($"UserInfo: {uri.UserInfo}");

            // AbsolutePath: /Home/Index.htm
            // AbsoluteUri: https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName
            // DnsSafeHost: www.contoso.com
            // Fragment: #FragmentName
            // Host: www.contoso.com
            // HostNameType: Dns
            // IdnHost: www.contoso.com
            // IsAbsoluteUri: True
            // IsDefaultPort: False
            // IsFile: False
            // IsLoopback: False
            // IsUnc: False
            // LocalPath: /Home/Index.htm
            // OriginalString: https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName
            // PathAndQuery: /Home/Index.htm?q1=v1&q2=v2
            // Port: 80
            // Query: ?q1=v1&q2=v2
            // Scheme: https
            // Segments: /, Home/, Index.htm
            // UserEscaped: False
            // UserInfo: user:password
        }
    }
}