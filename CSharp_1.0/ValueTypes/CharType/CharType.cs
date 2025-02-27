using System;

namespace CharType{
    public class CharType{
        /**
        Size: The char data type occupies 2 bytes (16 bits) in memory. This is because it uses the UTF-16 encoding to represent Unicode characters.

        Escape Sequences: The char type supports escape sequences for special characters.
            char newLine = '\n'; // Newline character
            char tab = '\t'; // Tab character
            char backslash = '\\'; // Backslash character

        Character Literals: You can use character literals to represent characters directly.
            char letter = 'A';
            char number = '1';
            char specialChar = '#';

        Default Value: The default value of a char variable is '\0' (the null character).

        Range of char
            Minimum Value: The minimum value of a char is '\u0000' (Unicode code point U+0000), which is the null character.
            Maximum Value: The maximum value of a char is '\uFFFF' (Unicode code point U+FFFF), which is the highest value in the Basic Multilingual Plane (BMP).

        Binary Representation: The Unicode code point is converted to its binary form. For 'A', the binary representation is 0000 0000 0100 0001.


        **/
        public static void Main(){
            System.Console.WriteLine("CharType");
            Console.WriteLine("Min :"+char.MinValue);
            Console.WriteLine("Max :"+char.MaxValue);

            char a = '\u0000';//Null Character
            System.Console.WriteLine("Numeric Value from Char :"+char.GetNumericValue('1'));
            System.Console.WriteLine("Numeric Value from Char in specific Index :"+char.GetNumericValue("Input: A",6));

            Console.WriteLine("Display a:"+ a);
            Console.WriteLine("Hashcode :"+a.GetHashCode());
            Console.WriteLine("Type Code :"+ a.GetTypeCode());
            Console.WriteLine("Type :"+ a.GetType());

            char b = 'A';
            Console.WriteLine("Unicode Category :"+ char.GetUnicodeCategory(b)); //Return A UnicodeCategory value that identifies the group that contains c.
            System.Console.WriteLine("unicode category in specified position :"+ char.GetUnicodeCategory("input:a",6));
            Console.WriteLine("IsAscii encoded :"+ char.IsAscii('1'));
            Console.WriteLine("IsAscii Digit :"+ char.IsAsciiDigit('A'));

            Console.WriteLine("Is Between :"+char.IsBetween(b,'1','9'));
            Console.WriteLine("Is Control :"+ char.IsControl('\u0000'));

            Console.WriteLine("Is Digit :"+ char.IsDigit('2'));
            System.Console.WriteLine("Is Puntuation :"+char.IsPunctuation(','));

            string c = b.ToString();
            System.Console.WriteLine("Print c:"+c);
            System.Console.WriteLine("To Lower :"+c.ToLower());
            Console.WriteLine("Is Equal :" + char.Equals(b,c));

            Console.WriteLine("Compare :"+ b.CompareTo('B'));
            Console.WriteLine($"Unicode number of {(char)((int)'$')} :"+(int)'$');

            Console.WriteLine("Escape Characters :"+ '\n');
            string supplementaryChar = "\uD83D\uDE00"; // 😀 (smiley face) - Sarrogate Pair
            Console.WriteLine(supplementaryChar);


        }
    }
}