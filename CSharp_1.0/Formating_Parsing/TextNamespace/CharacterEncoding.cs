using System;
using System.Text;
/**
The term character is used here in the general sense of what a reader perceives as a single display element. Common examples are the letter "a", the symbol "@", and the emoji "🐂". Sometimes what looks like one character is actually composed of multiple independent display elements, as the section on grapheme clusters explains.

The string and char types:
--------------------------
An instance of the string class represents some text. A string is logically a sequence of 16-bit values, each of which is an instance of the char struct. The string.Length property returns the number of char instances in the string instance.

Unicode code points:
--------------------
Unicode is an international encoding standard for use on various platforms and with various languages and scripts.

The Unicode Standard defines over 1.1 million code points. A code point is an integer value that can range from 0 to U+10FFFF (decimal 1,114,111). Some code points are assigned to letters, symbols, or emoji. Others are assigned to actions that control how text or characters are displayed, such as advance to a new line. Many code points are not yet assigned.
Decimal	Hex	Example	Description
10	U+000A	N/A	LINE FEED
97	U+0061	a	LATIN SMALL LETTER A
562	U+0232	Ȳ	LATIN CAPITAL LETTER Y WITH MACRON
68,675	U+10C43	𐱃	OLD TURKIC LETTER ORKHON AT
127,801	U+1F339	🌹	ROSE emoji

Code points are customarily referred to by using the syntax U+xxxx, where xxxx is the hex-encoded integer value.

Within the full range of code points there are two subranges:
    1.The Basic Multilingual Plane (BMP) in the range U+0000..U+FFFF. This 16-bit range provides 65,536 code points, enough to cover the majority of the world's writing systems.
    2.Supplementary code points in the range U+10000..U+10FFFF. This 21-bit range provides more than a million additional code points that can be used for less well-known languages and other purposes such as emojis.

UTF-16 code units:
------------------
16-bit Unicode Transformation Format (UTF-16) is a character encoding system that uses 16-bit code units to represent Unicode code points. .NET uses UTF-16 to encode the text in a string. A char instance represents a 16-bit code unit.

A single 16-bit code unit can represent any code point in the 16-bit range of the Basic Multilingual Plane. But for a code point in the supplementary range, two char instances are needed.

Surrogate pairs:
----------------
The translation of two 16-bit values to a single 21-bit value is facilitated by a special range called the surrogate code points, from U+D800 to U+DFFF (decimal 55,296 to 57,343), inclusive.

When a high surrogate code point (U+D800..U+DBFF) is immediately followed by a low surrogate code point (U+DC00..U+DFFF), the pair is interpreted as a supplementary code point by using the following formula:

code point = 0x10000 +
  ((high surrogate code point - 0xD800) * 0x0400) +
  (low surrogate code point - 0xDC00)
Here's the same formula using decimal notation:

code point = 65,536 +
  ((high surrogate code point - 55,296) * 1,024) +
  (low surrogate code point - 56,320)
A high surrogate code point doesn't have a higher number value than a low surrogate code point. The high surrogate code point is called "high" because it's used to calculate the higher-order 10 bits of a 20-bit code point range. The low surrogate code point is used to calculate the lower-order 10 bits.

Unicode scalar values:
------------------------
The term Unicode scalar value refers to all code points other than the surrogate code points. In other words, a scalar value is any code point that is assigned a character or can be assigned a character in the future. "Character" here refers to anything that can be assigned to a code point, which includes such things as actions that control how text or characters are displayed.


Grapheme clusters:
--------------------
What looks like one character might result from a combination of multiple code points, so a more descriptive term that is often used in place of "character" is grapheme cluster. The equivalent term in .NET is text element.

Consider the string instances "a", "á", "á", and "👩🏽‍🚒". If your operating system handles them as specified by the Unicode standard, each of these string instances appears as a single text element or grapheme cluster. But the last two are represented by more than one scalar value code point.

The string "a" is represented by one scalar value and contains one char instance.

U+0061 LATIN SMALL LETTER A
The string "á" is represented by one scalar value and contains one char instance.

U+00E1 LATIN SMALL LETTER A WITH ACUTE
The string "á" looks the same as "á" but is represented by two scalar values and contains two char instances.

U+0061 LATIN SMALL LETTER A
U+0301 COMBINING ACUTE ACCENT
Finally, the string "👩🏽‍🚒" is represented by four scalar values and contains seven char instances.

U+1F469 WOMAN (supplementary range, requires a surrogate pair)
U+1F3FD EMOJI MODIFIER FITZPATRICK TYPE-4 (supplementary range, requires a surrogate pair)
U+200D ZERO WIDTH JOINER
U+1F692 FIRE ENGINE (supplementary range, requires a surrogate pair)
In some of the preceding examples - such as the combining accent modifier or the skin tone modifier - the code point does not display as a standalone element on the screen. Rather, it serves to modify the appearance of a text element that came before it. These examples show that it might take multiple scalar values to make up what we think of as a single "character," or "grapheme cluster."

UTF-8 and UTF-32:
-----------------
The preceding sections focused on UTF-16 because that's what .NET uses to encode string instances. There are other encoding systems for Unicode - UTF-8 and UTF-32. These encodings use 8-bit code units and 32-bit code units, respectively.

Like UTF-16, UTF-8 requires multiple code units to represent some Unicode scalar values. UTF-32 can represent any scalar value in a single 32-bit code unit.

Scalar: U+0061 LATIN SMALL LETTER A ('a')
UTF-8 : [ 61 ]           (1x  8-bit code unit  = 8 bits total)
UTF-16: [ 0061 ]         (1x 16-bit code unit  = 16 bits total)
UTF-32: [ 00000061 ]     (1x 32-bit code unit  = 32 bits total)

Scalar: U+0429 CYRILLIC CAPITAL LETTER SHCHA ('Щ')
UTF-8 : [ D0 A9 ]        (2x  8-bit code units = 16 bits total)
UTF-16: [ 0429 ]         (1x 16-bit code unit  = 16 bits total)
UTF-32: [ 00000429 ]     (1x 32-bit code unit  = 32 bits total)

Scalar: U+A992 JAVANESE LETTER GA ('ꦒ')
UTF-8 : [ EA A6 92 ]     (3x  8-bit code units = 24 bits total)
UTF-16: [ A992 ]         (1x 16-bit code unit  = 16 bits total)
UTF-32: [ 0000A992 ]     (1x 32-bit code unit  = 32 bits total)

Scalar: U+104CC OSAGE CAPITAL LETTER TSHA ('𐓌')
UTF-8 : [ F0 90 93 8C ]  (4x  8-bit code units = 32 bits total)
UTF-16: [ D801 DCCC ]    (2x 16-bit code units = 32 bits total)
UTF-32: [ 000104CC ]     (1x 32-bit code unit  = 32 bits total)

Endianness:
------------
In .NET, the UTF-16 code units of a string are stored in contiguous memory as a sequence of 16-bit integers (char instances). The bits of individual code units are laid out according to the endianness of the current architecture.

On a little-endian architecture, the string consisting of the UTF-16 code points [ D801 DCCC ] would be laid out in memory as the bytes [ 0x01, 0xD8, 0xCC, 0xDC ]. On a big-endian architecture that same string would be laid out in memory as the bytes [ 0xD8, 0x01, 0xDC, 0xCC ].

Computer systems that communicate with each other must agree on the representation of data crossing the wire. Most network protocols use UTF-8 as a standard when transmitting text, partly to avoid issues that might result from a big-endian machine communicating with a little-endian machine. The string consisting of the UTF-8 code points [ F0 90 93 8C ] will always be represented as the bytes [ 0xF0, 0x90, 0x93, 0x8C ] regardless of endianness.

Since UTF-8 is commonplace on the internet, it may be tempting to read raw bytes from the wire and to treat the data as if it were UTF-8. However, you should validate that it is indeed well-formed. A malicious client might submit ill-formed UTF-8 to your service. If you operate on that data as if it were well-formed, it could cause errors or security holes in your application. To validate UTF-8 data, you can use a method like Encoding.UTF8.GetString, which will perform validation while converting the incoming data to a string.

Well-formed encoding:
---------------------
A well-formed Unicode encoding is a string of code units that can be decoded unambiguously and without error into a sequence of Unicode scalar values. Well-formed data can be transcoded freely back and forth between UTF-8, UTF-16, and UTF-32.

The question of whether an encoding sequence is well-formed or not is unrelated to the endianness of a machine's architecture. An ill-formed UTF-8 sequence is ill-formed in the same way on both big-endian and little-endian machines.

Here are some examples of ill-formed encodings:

In UTF-8, the sequence [ 6C C2 61 ] is ill-formed because C2 cannot be followed by 61.

In UTF-16, the sequence [ DC00 DD00 ] (or, in C#, the string "\udc00\udd00") is ill-formed because the low surrogate DC00 cannot be followed by another low surrogate DD00.

In UTF-32, the sequence [ 0011ABCD ] is ill-formed because 0011ABCD is outside the range of Unicode scalar values.

Encoders and decoders:
----------------------
.NET provides encoding classes that encode and decode text by using various encoding systems. For example, the UTF8Encoding class describes the rules for encoding to, and decoding from, UTF-8. .NET uses UTF-16 encoding (represented by the UnicodeEncoding class) for string instances. Encoders and decoders are available for other encoding schemes.

Encoding and decoding can also include validation. For example, the UnicodeEncoding class checks all char instances in the surrogate range to make sure they're in valid surrogate pairs. A fallback strategy determines how an encoder handles invalid characters or how a decoder handles invalid bytes.

**/
namespace StringBuilderText{
    class CharacterEncoding{
        static void PrintChars(string s)
        {
            Console.WriteLine($"\"{s}\".Length = {s.Length}");
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine($"s[{i}] = '{s[i]}' ('\\u{(int)s[i]:x4}')");
            }
            Console.WriteLine();
        }

        public static void Main(){
            Console.WriteLine("Character Encoding .");
            PrintChars("Hello");
            Console.WriteLine("Buffello :");
            PrintChars("🐂");
            PrintChars("a");

            PrintChars("á");

            PrintChars("👩🏽‍🚒");

            const string s = "\ud800";//An ill-formed literal
            //A substring that splits up a surrogate pair:
            string x = "\ud83e\udd70"; // "🥰"
            string y = x.Substring(1, 1); // "\udd70" standalone low surrogate
            Console.WriteLine(s+" "+ x+ " "+ y);
        }
    }
}