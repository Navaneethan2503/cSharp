using System;
/**
A raw string literal starts and ends with a minimum of three double quote (") characters:

The following rules govern the interpretation of a multi-line raw string literal:

The opening quotes must be the last non-comment token on its respective line, and the closing quote must be the first non-comment token on its respective line.
    Any whitespace to the left of the closing quotes is removed from all lines of the raw string literal.
    Whitespace following the opening quote on the same line is ignored.
    Whitespace only lines following the opening quote are included in the string literal.
    If a whitespace precedes the end delimiter on the same line, the exact number and kind of whitespace characters (e.g. spaces vs. tabs) must exist at the beginning of each content line. Specifically, a space does not match a horizontal tab, and vice versa.
    The newline before the closing quotes isn't included in the literal string.

Raw string literals can also be combined with interpolated strings to embed the { and } characters in the output string. You use multiple $ characters in an interpolated raw string literal to embed { and } characters in the output string without escaping them.

The raw string literal's content must not contain a set of contiguous " characters whose length is equal to or greater than the raw string literal delimiter length. For example, the strings """" """ """" and """"""" """""" """"" """" """ """"""" are well-formed. However, the strings """ """ """ and """ """" """ are ill-formed

Raw string literals were introduced in C# 11.

**/
namespace StringFormating{
    class RawStringLiteralClass{
        public static void Main(){
            Console.WriteLine("RawString Literal ...");
            var singleLine = """This is a "raw string literal". It can contain characters like \, ' and ".""";
            Console.WriteLine(singleLine);
            var xml = """
                <element attr="content">
                    <body>
                    </body>
                </element>

                """;

            Console.WriteLine(xml);

            var moreQuotes = """" As you can see,"""Raw string literals""" can start and end with more than three double-quotes when needed."""";
            Console.WriteLine(moreQuotes);

            var MultiLineQuotes = """"
               """Raw string literals""" can start and end with more than three double-quotes when needed.
               """";
            Console.WriteLine(MultiLineQuotes);

        }
    }
}