using System;
/**

Verbatim Identifiers:
----------------------

The @ special character serves as a verbatim identifier.

To indicate that a string literal is to be interpreted verbatim. The @ character in this instance defines a verbatim string literal.
Simple escape sequences (such as "\\" for a backslash), hexadecimal escape sequences (such as "\x0041" for an uppercase A), and Unicode escape sequences (such as "\u0041" for an uppercase A) are interpreted or ignored literally

Only a quote escape sequence ("") isn't interpreted literally; it produces one double quotation mark. 
Additionally, in case of a verbatim interpolated string brace escape sequences ({{ and }}) aren't interpreted literally; they produce single brace characters.

interpreted Means:
-------------------
An interpreted language is one where the code is executed directly by an interpreter, rather than being compiled into machine code beforehand

To use C# keywords as identifiers. The @ character prefixes a code element that the compiler is to interpret as an identifier rather than a C# keyword. The following example uses the @ character to define an identifier named for that it uses in a for loop.

To enable the compiler to distinguish between attributes in cases of a naming conflict. An attribute is a class that derives from Attribute. Its type name typically includes the suffix Attribute, although the compiler doesn't enforce this convention. The attribute can then be referenced in code either by its full type name (for example, [InfoAttribute] or its shortened name (for example, [Info]). However, a naming conflict occurs if two shortened attribute type names are identical, and one type name includes the Attribute suffix but the other doesn't.


**/
namespace StringFormating{
    class VerbatimIdentifierClass{
        public static void Main(){
            Console.WriteLine("Verbatim Identifier.");
            string filename1 = @"c:\documents\files\u0066.txt";
            string filename2 = "c:\\documents\\files\\u0066.txt";

            Console.WriteLine(filename1);
            Console.WriteLine(filename2);
            // The example displays the following output:
            //     c:\documents\files\u0066.txt
            //     c:\documents\files\u0066.txt

            string s1 = "He said, \"This is the last \u0063hance\x0021\"";
            string s2 = @"He said, ""This is the last \u0063hance\x0021""";

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            // The example displays the following output:
            //     He said, "This is the last chance!"
            //     He said, "This is the last \u0063hance\x0021"

            string[] @for = { "John", "James", "Joan", "Jamie" };
            for (int ctr = 0; ctr < @for.Length; ctr++)
            {
            Console.WriteLine($"Here is your gift, {@for[ctr]}!");
            }
            // The example displays the following output:
            //     Here is your gift, John!
            //     Here is your gift, James!
            //     Here is your gift, Joan!
            //     Here is your gift, Jamie!

        }
    }
}