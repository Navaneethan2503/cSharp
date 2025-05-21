/**
Regular expressions (or regex) in C# are a powerful tool for pattern matching and text manipulation. They are part of the System.Text.RegularExpressions namespace and are used to search, match, extract, and replace text using specific patterns.

What is a Regular Expression?
A regular expression is a sequence of characters that defines a search pattern. It can be used to:
    Validate input (e.g., email, phone number)
    Search for specific patterns in text
    Replace or split strings based on patterns

🔸 Key Class: Regex
using System.Text.RegularExpressions;

🔹 Basic Regex Syntax":
----------------------
Pattern	Meaning:
------------------
.	Any character except newline
^	Start of string
$	End of string
*	0 or more of the preceding element
+	1 or more of the preceding element
?	0 or 1 of the preceding element
\d	Digit (0–9)
\w	Word character (a-z, A-Z, 0–9, _)
\s	Whitespace
[abc]	Any one of a, b, or c
[^abc]	Not a, b, or c
(abc)	Grouping
\b	Begin/End the match on a word boundary.

Regular expressions provide a powerful, flexible, and efficient method for processing text. The extensive pattern-matching notation of regular expressions enables you to quickly parse large amounts of text to:
    Find specific character patterns.
    Validate text to ensure that it matches a predefined pattern (such as an email address).
    Extract, edit, replace, or delete text substrings.
    Add extracted strings to a collection in order to generate a report.
For many applications that deal with strings or that parse large blocks of text, regular expressions are an indispensable tool.


How regular expressions work:
-----------------------------
The centerpiece of text processing with regular expressions is the regular expression engine, which is represented by the System.Text.RegularExpressions.Regex object in .NET. At a minimum, processing text using regular expressions requires that the regular expression engine be provided with the following two items of information:
1.The regular expression pattern to identify in the text.
2.The text to parse for the regular expression pattern.

The regular expression engine:
------------------------------
The regular expression engine in .NET is represented by the Regex class. The regular expression engine is responsible for parsing and compiling a regular expression, and for performing operations that match the regular expression pattern with an input string. The engine is the central component in the .NET regular expression object model.

You can use the regular expression engine in either of two ways:
    1.By calling the static methods of the Regex class. The method parameters include the input string and the regular expression pattern. The regular expression engine caches regular expressions that are used in static method calls, so repeated calls to static regular expression methods that use the same regular expression offer relatively good performance.
    2.By instantiating a Regex object, that is, by passing a regular expression to the class constructor. In this case, the Regex object is immutable (read-only) and represents a regular expression engine that is tightly coupled with a single regular expression. Because regular expressions used by Regex instances aren't cached, you shouldn't instantiate a Regex object multiple times with the same regular expression.

You can call the methods of the Regex class to perform the following operations:
    Determine whether a string matches a regular expression pattern.
    Extract a single match or the first match.
    Extract all matches.
    Replace a matched substring.
    Split a single string into an array of strings.





**/
using System;
using System.Text.RegularExpressions;

namespace RegularExpressions{
    class RegularExpressionClass{
        public static void Main(){
            Console.WriteLine("Regular Expression.");

            //Match a regular expression pattern
            string[] values = { "111-22-3333", "111-2-3333"};
            string pattern = @"^\d{3}-\d{2}-\d{4}$";
            foreach (string value in values) {
                if (Regex.IsMatch(value, pattern))
                    Console.WriteLine($"{value} is a valid SSN.");
                else
                    Console.WriteLine($"{value}: Invalid");
            }

            //Extract a single match or the first match
            string input = "This is a a farm that that raises dairy cattle.";
            string pattern1 = @"\b(\w+)\W+(\1)\b";
            Match match = Regex.Match(input, pattern1);
            while (match.Success)
            {
                Console.WriteLine($"Duplicate '{match.Groups[1].Value}' found at position {match.Groups[2].Index}.");
                match = match.NextMatch();
            }

            //Extract all matches
            string inputmatches = "This is a a farm that that raises dairy cattle.";
            string patternmatches = @"\b(\w+)\W+(\1)\b";
            foreach (Match matchpatternmatches in Regex.Matches(inputmatches, patternmatches))
                Console.WriteLine($"Duplicate '{matchpatternmatches.Groups[1].Value}' found at position {matchpatternmatches.Groups[2].Index}.");

            //Replace a matched substring
            string patternReplace = @"\b\d+\.\d{2}\b";
            string replacementReplace = "$$$&";
            string inputReplace = "Total Cost: 103.64";
            Console.WriteLine(Regex.Replace(inputReplace, patternReplace, replacementReplace));
            //$$	The dollar sign ($) character.
            //$&	The entire matched substring.

            //Split a single string into an array of strings
            string inputSplit = "1. Eggs 2. Bread 3. Milk 4. Coffee 5. Tea";
            string patternSplit = @"\b\d{1,2}\.\s";
            foreach (string item in Regex.Split(inputSplit, patternSplit))
            {
                if (! String.IsNullOrEmpty(item))
                    Console.WriteLine(item);
            }

            string url = "http://www.contoso.com:8080/letters/readme.html";

            Regex r = new Regex(@"^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
                                RegexOptions.None, TimeSpan.FromMilliseconds(150));
            Match m = r.Match(url);
            if (m.Success)
                Console.WriteLine(m.Result("${proto}${port}"));

            

        }
    }
}