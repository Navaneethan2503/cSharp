/**
MatchCollection Class
---------------------

Represents the set of successful matches found by iteratively applying a regular expression pattern to the input string. The collection is immutable (read-only) and has no public constructor. The Matches(String) method returns a MatchCollection object.

public class MatchCollection : System.Collections.Generic.ICollection<System.Text.RegularExpressions.Match>, System.Collections.Generic.IEnumerable<System.Text.RegularExpressions.Match>, System.Collections.Generic.IList<System.Text.RegularExpressions.Match>, System.Collections.Generic.IReadOnlyCollection<System.Text.RegularExpressions.Match>, System.Collections.Generic.IReadOnlyList<System.Text.RegularExpressions.Match>, System.Collections.IList

Remarks
The collection is immutable (read-only) and has no public constructor. The Regex.Matches method returns a MatchCollection object.

The collection contains zero or more System.Text.RegularExpressions.Match objects. If the match is successful, the collection is populated with one System.Text.RegularExpressions.Match object for each match found in the input string. If the match is unsuccessful, the collection contains no System.Text.RegularExpressions.Match objects, and its Count property equals zero.

When applying a regular expression pattern to a particular input string, the regular expression engine uses either of two techniques to build the MatchCollection object:

Direct evaluation.

The MatchCollection object is populated all at once, with all matches resulting from a particular call to the Regex.Matches method. This technique is used when the collection's Count property is accessed. It typically is the more expensive method of populating the collection and entails a greater performance hit.

Lazy evaluation.

The MatchCollection object is populated as needed on a match-by-match basis. It is equivalent to the regular expression engine calling the Regex.Match method repeatedly and adding each match to the collection. This technique is used when the collection is accessed through its GetEnumerator method, or when it is accessed using the foreach statement (in C#) or the For Each...Next statement (in Visual Basic).

To iterate through the members of the collection, you should use the collection iteration construct provided by your language (such as foreach in C# and For Each…Next in Visual Basic) instead of retrieving the enumerator that is returned by the GetEnumerator method.

Properties
Count	
Gets the number of matches.

IsReadOnly	
Gets a value that indicates whether the collection is read only.

IsSynchronized	
Gets a value indicating whether access to the collection is synchronized (thread-safe).

Item[Int32]	
Gets an individual member of the collection.

SyncRoot	
Gets an object that can be used to synchronize access to the collection.

Methods
CopyTo(Array, Int32)	
Copies all the elements of the collection to the given array starting at the given index.

CopyTo(Match[], Int32)	
Copies the elements of the collection to an Array, starting at a particular Array index.

Equals(Object)	
Determines whether the specified object is equal to the current object.

(Inherited from Object)
GetEnumerator()	
Provides an enumerator that iterates through the collection.

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

(Inherited from Object)


Group Collections:
------------------
Returns the set of captured groups in a single match. The collection is immutable (read-only) and has no public constructor.
    public class GroupCollection : System.Collections.Generic.ICollection<System.Text.RegularExpressions.Group>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,System.Text.RegularExpressions.Group>>, System.Collections.Generic.IEnumerable<System.Text.RegularExpressions.Group>, System.Collections.Generic.IList<System.Text.RegularExpressions.Group>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string,System.Text.RegularExpressions.Group>>, System.Collections.Generic.IReadOnlyCollection<System.Text.RegularExpressions.Group>, System.Collections.Generic.IReadOnlyDictionary<string,System.Text.RegularExpressions.Group>, System.Collections.Generic.IReadOnlyList<System.Text.RegularExpressions.Group>, System.Collections.IList

Remarks
The GroupCollection class is a zero-based collection class that consists of one or more Group objects that provide information about captured groups in a regular expression match. The collection is immutable (read-only) and has no public constructor. A GroupCollection object is returned by the Match.Groups property.

The collection contains one or more System.Text.RegularExpressions.Group objects. If the match is successful, the first element in the collection contains the Group object that corresponds to the entire match. Each subsequent element represents a captured group, if the regular expression includes capturing groups. Matches from numbered (unnamed) capturing groups appear in numeric order before matches from named capturing groups. If the match is unsuccessful, the collection contains a single System.Text.RegularExpressions.Group object whose Success property is false and whose Value property equals String.Empty. For more information, see the "Grouping Constructs and Regular Expression Objects" section in the Grouping Constructs article.

To iterate through the members of the collection, you should use the collection iteration construct provided by your language (such as foreach in C# and For Each…Next in Visual Basic) instead of retrieving the enumerator that is returned by the GetEnumerator method. In addition, you can access individual numbered captured groups from the Item[Int32] property (the indexer in C#), and you can access individual named captured groups from the Item[String] property. Note that you can retrieve an array that contains the numbers and names of all capturing groups by calling the Regex.GetGroupNumbers and Regex.GetGroupNames methods, respectively. Both are instance methods and require that you instantiate a Regex object that represents the regular expression to be matched.

Properties
Count	
Returns the number of groups in the collection.

IsReadOnly	
Gets a value that indicates whether the collection is read-only.

IsSynchronized	
Gets a value that indicates whether access to the GroupCollection is synchronized (thread-safe).

Item[Int32]	
Enables access to a member of the collection by integer index.

Item[String]	
Enables access to a member of the collection by string index.

Keys	
Gets a string enumeration that contains the name keys of the group collection.

SyncRoot	
Gets an object that can be used to synchronize access to the GroupCollection.

Values	
Gets a group enumeration with all the groups in the group collection.

Methods
ContainsKey(String)	
Determines whether the group collection contains a captured group identified by the specified name.

CopyTo(Array, Int32)	
Copies all the elements of the collection to the given array beginning at the given index.

CopyTo(Group[], Int32)	
Copies the elements of the group collection to a Group array, starting at a particular array index.

Equals(Object)	
Determines whether the specified object is equal to the current object.

(Inherited from Object)
GetEnumerator()	
Provides an enumerator that iterates through the collection.

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

(Inherited from Object)
TryGetValue(String, Group)	
Attempts to retrieve a group identified by the provided name key, if it exists in the group collection.
**/