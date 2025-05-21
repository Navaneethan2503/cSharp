/**

RegexOptions Enum
------------------
Provides enumerated values to use to set regular expression options.

This enumeration supports a bitwise combination of its member values.

[System.Flags]
public enum RegexOptions

Fields
Name	Value	Description
None	0	
Specifies that no options are set. For more information about the default behavior of the regular expression engine, see the "Default Options" section in the Regular Expression Options article.

IgnoreCase	1	
Specifies case-insensitive matching. For more information, see the "Case-Insensitive Matching " section in the Regular Expression Options article.

Multiline	2	
Multiline mode. Changes the meaning of ^ and $ so they match at the beginning and end, respectively, of any line, and not just the beginning and end of the entire string. For more information, see the "Multiline Mode" section in the Regular Expression Options article.

ExplicitCapture	4	
Specifies that the only valid captures are explicitly named or numbered groups of the form (?<name>...). This allows unnamed parentheses to act as noncapturing groups without the syntactic clumsiness of the expression (?:...). For more information, see the "Explicit Captures Only" section in the Regular Expression Options article.

Compiled	8	
Specifies that the regular expression is compiled to MSIL code, instead of being interpreted. Compiled regular expressions maximize run-time performance at the expense of initialization time. This value should not be assigned to the Options property when calling the CompileToAssembly(RegexCompilationInfo[], AssemblyName) method. For more information, see the "Compiled Regular Expressions" section in the Regular Expression Options article.

Singleline	16	
Specifies single-line mode. Changes the meaning of the dot (.) so it matches every character (instead of every character except \n). For more information, see the "Single-line Mode" section in the Regular Expression Options article.

IgnorePatternWhitespace	32	
Eliminates unescaped white space from the pattern and enables comments marked with #. However, this value does not affect or eliminate white space in character classes, numeric quantifiers, or tokens that mark the beginning of individual regular expression language elements. For more information, see the "Ignore White Space" section of the Regular Expression Options article.

RightToLeft	64	
Specifies that the search will be from right to left instead of from left to right. For more information, see the "Right-to-Left Mode" section in the Regular Expression Options article.

ECMAScript	256	
Enables ECMAScript-compliant behavior for the expression. This value can be used only in conjunction with the IgnoreCase, Multiline, and Compiled values. The use of this value with any other values results in an exception.

For more information on the ECMAScript option, see the "ECMAScript Matching Behavior" section in the Regular Expression Options article.

CultureInvariant	512	
Specifies that cultural differences in language is ignored. For more information, see the "Comparison Using the Invariant Culture" section in the Regular Expression Options article.

NonBacktracking	1024	
Enable matching using an approach that avoids backtracking and guarantees linear-time processing in the length of the input.


**/
