/**
Capture Class:
-----------------

Represents the results from a single successful subexpression capture.
    public class Capture

A Capture object is immutable and has no public constructor. Instances are returned through the CaptureCollection object, which is returned by the Match.Captures and Group.Captures properties. However, the Match.Captures property provides information about the same match as the Match object.

If you do not apply a quantifier to a capturing group, the Group.Captures property returns a CaptureCollection with a single Capture object that provides information about the same capture as the Group object. If you do apply a quantifier to a capturing group, the Group.Index, Group.Length, and Group.Value properties provide information only about the last captured group, whereas the Capture objects in the CaptureCollection provide information about all subexpression captures. The example provides an illustration.

Properties:
-----------
Index	- The position in the original string where the first character of the captured substring is found.
Length	- Gets the length of the captured substring.
Value	- Gets the captured substring from the input string.
ValueSpan	- Gets the captured span from the input string.

Methods :-
----------
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
Retrieves the captured substring from the input string by calling the Value property.


**/
using System;
using System.Text.RegularExpressions;

namespace RegularExpressions{
    class CaptureClass{
        public static void Main(){
            Console.WriteLine("Capture Class.");
            string input = "Yes. This dog is very friendly.";
            string pattern = @"((\w+)[\s.])+";
            foreach (Match match in Regex.Matches(input, pattern))
            {
                Console.WriteLine("Match: {0}", match.Value);
                for (int groupCtr = 0; groupCtr < match.Groups.Count; groupCtr++)
                {
                    Group group = match.Groups[groupCtr];
                    Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value);
                    for (int captureCtr = 0; captureCtr < group.Captures.Count; captureCtr++)
                    Console.WriteLine("      Capture {0}: {1}", captureCtr, 
                                        group.Captures[captureCtr].Value);
                }                      
            }
            /**
            Match: Yes.
                Group 0: Yes.
                    Capture 0: Yes.
                Group 1: Yes.
                    Capture 0: Yes.
                Group 2: Yes
                    Capture 0: Yes
            Match: This dog is very friendly.
                Group 0: This dog is very friendly.
                    Capture 0: This dog is very friendly.
                Group 1: friendly.
                    Capture 0: This
                    Capture 1: dog
                    Capture 2: is
                    Capture 3: very
                    Capture 4: friendly.
                Group 2: friendly
                    Capture 0: This
                    Capture 1: dog
                    Capture 2: is
                    Capture 3: very
                    Capture 4: friendly
            **/
        }
    }
}