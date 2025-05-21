/**
🔹 What is a Group?:
---------------------
A group in regex is created using parentheses (). It lets you:
    Extract a specific part of the match.
    Apply quantifiers to part of the pattern.
    Reuse the matched value later (backreferences).

🔸 What is a Capture?
-------------------------
A capture is the actual text that matched a group. So:
    A group is the pattern.
    A capture is the result of that pattern.


Group Class:
------------

Represents the results from a single capturing group.
    public class Group : System.Text.RegularExpressions.Capture

Remarks
A capturing group can capture zero, one, or more strings in a single match because of quantifiers. (For more information, see Quantifiers.) All the substrings matched by a single capturing group are available from the Group.Captures property. Information about the last substring captured can be accessed directly from the Value and Index properties. (That is, the Group instance is equivalent to the last item of the collection returned by the Captures property, which reflects the last capture made by the capturing group.)

Properties:
-------------
Captures	- Gets a collection of all the captures matched by the capturing group, in innermost-leftmost-first order (or innermost-rightmost-first order if the regular expression is modified with the RightToLeft option). The collection may have zero or more items.
    public System.Text.RegularExpressions.CaptureCollection Captures { get; }

Index	- The position in the original string where the first character of the captured substring is found.(Inherited from Capture)
Length	- Gets the length of the captured substring.(Inherited from Capture)
Name	- Returns the name of the capturing group represented by the current instance.
    public string Name { get; }

Success	- Gets a value indicating whether the match is successful.
    public bool Success { get; }

Value	- Gets the captured substring from the input string.(Inherited from Capture)
ValueSpan	- Gets the captured span from the input string.(Inherited from Capture)

Methods:
----------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Synchronized(Group)	- Returns a Group object equivalent to the one supplied that is safe to share between multiple threads.
ToString()	- Retrieves the captured substring from the input string by calling the Value property.(Inherited from Capture)


**/
using System;
using System.Text.RegularExpressions;

namespace RegularExpressions{
    class GroupClass{
        public static void Main(){
            Console.WriteLine("Group Class");
            string pattern = @"(\b(\w+?)[,:;]?\s?)+[?.!]";
            string input = "This is one sentence. This is a second sentence.";

            Match match = Regex.Match(input, pattern);
            Console.WriteLine("Match: " + match.Value);
            int groupCtr = 0;
            foreach (Group group in match.Groups)
            {
                groupCtr++;
                Console.WriteLine("   Group {0}: '{1}'", groupCtr, group.Value);
                int captureCtr = 0;
                foreach (Capture capture in group.Captures)
                {
                    captureCtr++;
                    Console.WriteLine("      Capture {0}: '{1}'", captureCtr, capture.Value);
                }
            }   
            /**
            Match: This is one sentence.
                Group 1: 'This is one sentence.'
                    Capture 1: 'This is one sentence.'
                Group 2: 'sentence'
                    Capture 1: 'This '
                    Capture 2: 'is '
                    Capture 3: 'one '
                    Capture 4: 'sentence'
                Group 3: 'sentence'
                    Capture 1: 'This'
                    Capture 2: 'is'
                    Capture 3: 'one'
                    Capture 4: 'sentence'
            **/

            // string pattern = @"Name: (?<name>\w+), Age: (?<age>\d+)";
            // Console.WriteLine(match.Groups["name"].Value);  // John
            // Console.WriteLine(match.Groups["age"].Value);   // 30

            string inputt = "Name: John, Age: 30";
            string ppattern = @"Name: (\w+), Age: (\d+)";
            Match mmatch = Regex.Match(inputt, ppattern);

            if (mmatch.Success)
            {
                Console.WriteLine("Full Match: " + mmatch.Value);       // Full match
                Console.WriteLine("Name: "+ mmatch.Groups[1].Name+" - " + mmatch.Groups[1].Value);   // Group 1
                Console.WriteLine("Age: " + mmatch.Groups[2].Value);    // Group 2
                
            }

        }
    }
}
