/**
Match Class:
------------
Represents the results from a single regular expression match.
    public class Match : System.Text.RegularExpressions.Group

Remarks
The Match object is immutable and has no public constructor. An instance of the Match class is returned by the Regex.Match method and represents the first pattern match in a string. Subsequent matches are represented by Match objects returned by the Match.NextMatch method. In addition, a MatchCollection object that consists of zero, one, or more Match objects is returned by the Regex.Matches method.

If the Regex.Matches method fails to match a regular expression pattern in an input string, it returns an empty MatchCollection object. You can then use a foreach construct in C# or a For Each construct in Visual Basic to iterate the collection.

If the Regex.Match method fails to match the regular expression pattern, it returns a Match object that is equal to Match.Empty. You can use the Success property to determine whether the match was successful. The following example provides an illustration.

Properties:
-----------
Empty	- Gets the empty group. All failed matches return this empty match.
Groups	- Gets a collection of groups matched by the regular expression.


Methods:
--------
NextMatch()	- Returns a new Match object with the results for the next match, starting at the position at which the last match ended (at the character after the last matched character).
Result(String)	- Returns the expansion of the specified replacement pattern.
Synchronized(Match)	- Returns a Match instance equivalent to the one supplied that is suitable to share between multiple threads.



**/
using System;
using System.Text.RegularExpressions;

namespace RegularExpressions{
    class MatchClass{
        public static void Main(){
            Console.WriteLine("Match Class.");
            string s = "this is the plain sentence.";
            string pat = @"plain";
            Match m = Regex.Match(s,pat);
            if(m.Success){
                Console.WriteLine(m.Groups[0].Name+" " + m.Groups[0].Value);
            }

            string input = "int[] values = { 1, 2, 3 };\n" +
                     "for (int ctr = values.GetLowerBound(1); ctr <= values.GetUpperBound(1); ctr++)\n" +
                     "{\n" +
                     "   Console.Write(values[ctr]);\n" +
                     "   if (ctr < values.GetUpperBound(1))\n" +
                     "      Console.Write(\", \");\n" +
                     "}\n" +
                     "Console.WriteLine();\n";   
      
            string pattern = @"Console\.Write(Line)?";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
                Console.WriteLine("'{0}' found in the source code at position {1}.",  
                                match.Value, match.Index);
        }
    }
}