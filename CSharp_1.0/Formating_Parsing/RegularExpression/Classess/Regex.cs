/**
Regex Class:
------------

Represents an immutable regular expression.

    public class Regex : System.Runtime.Serialization.ISerializable

Constructors:
-------------
Regex()	- Initializes a new instance of the Regex class.
    protected Regex();
Regex(String, RegexOptions, TimeSpan) - Initializes a new instance of the Regex class for the specified regular expression, with options that modify the pattern and a value that specifies how long a pattern matching method should attempt a match before it times out.
    public Regex(string pattern, System.Text.RegularExpressions.RegexOptions options, TimeSpan matchTimeout);

Regex(String, RegexOptions)	 - Initializes a new instance of the Regex class for the specified regular expression, with options that modify the pattern.
    public Regex(string pattern, System.Text.RegularExpressions.RegexOptions options);

Regex(String)	- Initializes a new instance of the Regex class for the specified regular expression.
    public Regex(string pattern);


Fields:
--------
capnames	- Used by a Regex object generated by the CompileToAssembly method.
caps	- Used by a Regex object generated by the CompileToAssembly method.
capsize	- Used by a Regex object generated by the CompileToAssembly method.
capslist	- Used by a Regex object generated by the CompileToAssembly method.
factory	- Used by a Regex object generated by the CompileToAssembly method.
InfiniteMatchTimeout	- Specifies that a pattern-matching operation should not time out.
internalMatchTimeout	- The maximum amount of time that can elapse in a pattern-matching operation before the operation times out.
pattern	- Used by a Regex object generated by the CompileToAssembly method.
roptions	- Used by a Regex object generated by the CompileToAssembly method.

Properties:
-----------
CacheSize - Gets or sets the maximum number of entries in the current static cache of compiled regular expressions.
CapNames	- Gets or sets a dictionary that maps named capturing groups to their index values.
Caps	- Gets or sets a dictionary that maps numbered capturing groups to their index values.
MatchTimeout	- Gets the time-out interval of the current instance.
Options	- Gets the options that were passed into the Regex constructor.
    public System.Text.RegularExpressions.RegexOptions Options { get; }

RightToLeft	- Gets a value that indicates whether the regular expression searches from right to left.
    public bool RightToLeft { get; }


Methods:
---------

Count(ReadOnlySpan<Char>, Int32) - Searches an input span for all occurrences of a regular expression and returns the number of matches.
Count(ReadOnlySpan<Char>, String, RegexOptions, TimeSpan)	- Searches an input span for all occurrences of a regular expression and returns the number of matches.
Count(ReadOnlySpan<Char>, String, RegexOptions)	- Searches an input span for all occurrences of a regular expression and returns the number of matches.
Count(ReadOnlySpan<Char>, String)	- Searches an input span for all occurrences of a regular expression and returns the number of matches.
Count(ReadOnlySpan<Char>)	- Searches an input span for all occurrences of a regular expression and returns the number of matches.
Count(String, String, RegexOptions, TimeSpan)	- Searches an input string for all occurrences of a regular expression and returns the number of matches.
Count(String, String, RegexOptions)	- Searches an input string for all occurrences of a regular expression and returns the number of matches.
Count(String, String)	- Searches an input string for all occurrences of a regular expression and returns the number of matches.
Count(String)	- Searches an input string for all occurrences of a regular expression and returns the number of matches.
EnumerateMatches(ReadOnlySpan<Char>, Int32)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueMatchEnumerator to iterate over the matches.
EnumerateMatches(ReadOnlySpan<Char>, String, RegexOptions, TimeSpan)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueMatchEnumerator to iterate over the matches.
EnumerateMatches(ReadOnlySpan<Char>, String, RegexOptions)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueMatchEnumerator to iterate over the matches.
EnumerateMatches(ReadOnlySpan<Char>, String)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueMatchEnumerator to iterate over the matches.
EnumerateMatches(ReadOnlySpan<Char>)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueMatchEnumerator to iterate over the matches.
EnumerateSplits(ReadOnlySpan<Char>, Int32, Int32)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueSplitEnumerator to iterate over the splits around matches.
EnumerateSplits(ReadOnlySpan<Char>, Int32)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueSplitEnumerator to iterate over the splits around matches.
EnumerateSplits(ReadOnlySpan<Char>, String, RegexOptions, TimeSpan)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueSplitEnumerator to iterate over the splits around matches.
EnumerateSplits(ReadOnlySpan<Char>, String, RegexOptions)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueSplitEnumerator to iterate over the splits around matches.
EnumerateSplits(ReadOnlySpan<Char>, String)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueSplitEnumerator to iterate over the splits around matches.
EnumerateSplits(ReadOnlySpan<Char>)	- Searches an input span for all occurrences of a regular expression and returns a Regex.ValueSplitEnumerator to iterate over the splits around matches.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Escape(String)	- Escapes a minimal set of characters (\, *, +, ?, |, {, [, (,), ^, $, ., #, and white space) by replacing them with their escape codes. This instructs the regular expression engine to interpret these characters literally rather than as metacharacters.
GetGroupNames()	- Returns an array of capturing group names for the regular expression.
GetGroupNumbers()	- Returns an array of capturing group numbers that correspond to group names in an array.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
GroupNameFromNumber(Int32)	- Gets the group name that corresponds to the specified group number.
GroupNumberFromName(String)	- Returns the group number that corresponds to the specified group name.

IsMatch(ReadOnlySpan<Char>, Int32)	- Indicates whether the regular expression specified in the Regex constructor finds a match in a specified input span.
IsMatch(ReadOnlySpan<Char>, String, RegexOptions, TimeSpan)	- Indicates whether the specified regular expression finds a match in the specified input span, using the specified matching options and time-out interval.
IsMatch(ReadOnlySpan<Char>, String, RegexOptions)	- Indicates whether the specified regular expression finds a match in the specified input span, using the specified matching options.
IsMatch(ReadOnlySpan<Char>, String)	- Indicates whether the specified regular expression finds a match in the specified input span.
IsMatch(ReadOnlySpan<Char>)	- Indicates whether the regular expression specified in the Regex constructor finds a match in a specified input span.
IsMatch(String, Int32)	- Indicates whether the regular expression specified in the Regex constructor finds a match in the specified input string, beginning at the specified starting position in the string.
IsMatch(String, String, RegexOptions, TimeSpan)	- Indicates whether the specified regular expression finds a match in the specified input string, using the specified matching options and time-out interval.
IsMatch(String, String, RegexOptions)	- Indicates whether the specified regular expression finds a match in the specified input string, using the specified matching options.
IsMatch(String, String)	- Indicates whether the specified regular expression finds a match in the specified input string.
IsMatch(String)	- Indicates whether the regular expression specified in the Regex constructor finds a match in a specified input string.
    public bool IsMatch(string input);
    public static bool IsMatch(string input, string pattern, System.Text.RegularExpressions.RegexOptions options, TimeSpan matchTimeout);
    public static System.Text.RegularExpressions.Match Match(string input, string pattern);

Match(String, Int32, Int32)	- Searches the input string for the first occurrence of a regular expression, beginning at the specified starting position and searching only the specified number of characters.
Match(String, Int32)	- Searches the input string for the first occurrence of a regular expression, beginning at the specified starting position in the string.
Match(String, String, RegexOptions, TimeSpan)	 -Searches the input string for the first occurrence of the specified regular expression, using the specified matching options and time-out interval.
Match(String, String, RegexOptions)	- Searches the input string for the first occurrence of the specified regular expression, using the specified matching options.
Match(String, String)	- Searches the specified input string for the first occurrence of the specified regular expression.
Match(String)	- Searches the specified input string for the first occurrence of the regular expression specified in the Regex constructor.
    public System.Text.RegularExpressions.Match Match(string input, int beginning, int length);
    public System.Text.RegularExpressions.Match Match(string input);
    public static System.Text.RegularExpressions.Match Match(string input, string pattern, System.Text.RegularExpressions.RegexOptions options, TimeSpan matchTimeout);

Matches(String, Int32)	- Searches the specified input string for all occurrences of a regular expression, beginning at the specified starting position in the string.
Matches(String, String, RegexOptions, TimeSpan)	- Searches the specified input string for all occurrences of a specified regular expression, using the specified matching options and time-out interval.
Matches(String, String, RegexOptions)	- Searches the specified input string for all occurrences of a specified regular expression, using the specified matching options.
Matches(String, String)	- Searches the specified input string for all occurrences of a specified regular expression.
Matches(String)	- Searches the specified input string for all occurrences of a regular expression.
    public static System.Text.RegularExpressions.MatchCollection Matches(string input, string pattern, System.Text.RegularExpressions.RegexOptions options, TimeSpan matchTimeout);

MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)

Replace(String, MatchEvaluator, Int32, Int32)	- In a specified input substring, replaces a specified maximum number of strings that match a regular expression pattern with a string returned by a MatchEvaluator delegate.
Replace(String, MatchEvaluator, Int32)	- In a specified input string, replaces a specified maximum number of strings that match a regular expression pattern with a string returned by a MatchEvaluator delegate.
Replace(String, MatchEvaluator)	- In a specified input string, replaces all strings that match a specified regular expression with a string returned by a MatchEvaluator delegate.
Replace(String, String, Int32, Int32)	- n a specified input substring, replaces a specified maximum number of strings that match a regular expression pattern with a specified replacement string.
Replace(String, String, Int32)	- In a specified input string, replaces a specified maximum number of strings that match a regular expression pattern with a specified replacement string.
Replace(String, String, MatchEvaluator, RegexOptions, TimeSpan)	- In a specified input string, replaces all substrings that match a specified regular expression with a string returned by a MatchEvaluator delegate. Additional parameters specify options that modify the matching operation and a time-out interval if no match is found.
Replace(String, String, MatchEvaluator, RegexOptions)	- In a specified input string, replaces all strings that match a specified regular expression with a string returned by a MatchEvaluator delegate. Specified options modify the matching operation.
Replace(String, String, MatchEvaluator)	- In a specified input string, replaces all strings that match a specified regular expression with a string returned by a MatchEvaluator delegate.
Replace(String, String, String, RegexOptions, TimeSpan)	- In a specified input string, replaces all strings that match a specified regular expression with a specified replacement string. Additional parameters specify options that modify the matching operation and a time-out interval if no match is found.
Replace(String, String, String, RegexOptions)	- In a specified input string, replaces all strings that match a specified regular expression with a specified replacement string. Specified options modify the matching operation.
Replace(String, String, String)	- In a specified input string, replaces all strings that match a specified regular expression with a specified replacement string.
Replace(String, String)	- In a specified input string, replaces all strings that match a regular expression pattern with a specified replacement string.
    public static string Replace(string input, string pattern, string replacement, System.Text.RegularExpressions.RegexOptions options);

Split(String, Int32, Int32)	- Splits an input string a specified maximum number of times into an array of substrings, at the positions defined by a regular expression specified in the Regex constructor. The search for the regular expression pattern starts at a specified character position in the input string.
Split(String, Int32)	- Splits an input string a specified maximum number of times into an array of substrings, at the positions defined by a regular expression specified in the Regex constructor.
Split(String, String, RegexOptions, TimeSpan)	- Splits an input string into an array of substrings at the positions defined by a specified regular expression pattern. Additional parameters specify options that modify the matching operation and a time-out interval if no match is found.
Split(String, String, RegexOptions)	- Splits an input string into an array of substrings at the positions defined by a specified regular expression pattern. Specified options modify the matching operation.
Split(String, String)	- Splits an input string into an array of substrings at the positions defined by a regular expression pattern.
Split(String)	- Splits an input string into an array of substrings at the positions defined by a regular expression pattern specified in the Regex constructor.
    public static string[] Split(string input, string pattern, System.Text.RegularExpressions.RegexOptions options, TimeSpan matchTimeout);
    public static string[] Split(string input, string pattern);
    
ToString()	- Returns the regular expression pattern that was passed into the Regex constructor.
Unescape(String)	- Converts any escaped characters in the input string.
ValidateMatchTimeout(TimeSpan)	- Checks whether a time-out interval is within an acceptable range.




**/
using System;
using System.Text.RegularExpressions;

namespace RegularExpressions{
    class RegexClass{
        public static void Main(){
            Console.WriteLine("Regex Class");
        }
    }
}