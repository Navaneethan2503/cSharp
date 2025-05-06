using System;
using System.Globalization;
/**
Determines the styles permitted in numeric string arguments that are passed to the Parse and TryParse methods of the integral and floating-point numeric types.

This enumeration supports a bitwise combination of its member values.

Field:
-----
Name	Value	Description
None	0	Indicates that no style elements, such as leading or trailing white space, thousands separators, or a decimal separator, can be present in the parsed string. The string to be parsed must consist of integral decimal digits only.
AllowLeadingWhite	1	Indicates that leading white-space characters can be present in the parsed string. Valid white-space characters have the Unicode values U+0009, U+000A, U+000B, U+000C, U+000D, and U+0020. Note that this is a subset of the characters for which the IsWhiteSpace(Char) method returns true.
AllowTrailingWhite	2	Indicates that trailing white-space characters can be present in the parsed string. Valid white-space characters have the Unicode values U+0009, U+000A, U+000B, U+000C, U+000D, and U+0020. Note that this is a subset of the characters for which the IsWhiteSpace(Char) method returns true.
AllowLeadingSign	4	Indicates that the numeric string can have a leading sign. Valid leading sign characters are determined by the PositiveSign and NegativeSign properties.
Integer	7	Indicates that the AllowLeadingWhite, AllowTrailingWhite, and AllowLeadingSign styles are used. This is a composite number style.
AllowTrailingSign	8	Indicates that the numeric string can have a trailing sign. Valid trailing sign characters are determined by the PositiveSign and NegativeSign properties.
AllowParentheses	16	Indicates that the numeric string can have one pair of parentheses enclosing the number. The parentheses indicate that the string to be parsed represents a negative number.
AllowDecimalPoint	32	Indicates that the numeric string can have a decimal point. If the NumberStyles value includes the AllowCurrencySymbol flag and the parsed string includes a currency symbol, the decimal separator character is determined by the CurrencyDecimalSeparator property. Otherwise, the decimal separator character is determined by the NumberDecimalSeparator property.
AllowThousands	64 Indicates that the numeric string can have group separators, such as symbols that separate hundreds from thousands. If the NumberStyles value includes the AllowCurrencySymbol flag and the string to be parsed includes a currency symbol, the valid group separator character is determined by the CurrencyGroupSeparator property, and the number of digits in each group is determined by the CurrencyGroupSizes property. Otherwise, the valid group separator character is determined by the NumberGroupSeparator property, and the number of digits in each group is determined by the NumberGroupSizes property.
Number	111	Indicates that the AllowLeadingWhite, AllowTrailingWhite, AllowLeadingSign, AllowTrailingSign, AllowDecimalPoint, and AllowThousands styles are used. This is a composite number style.
AllowExponent	128	Indicates that the numeric string can be in exponential notation. The AllowExponent flag allows the parsed string to contain an exponent that begins with the "E" or "e" character and that is followed by an optional positive or negative sign and an integer. In other words, it successfully parses strings in the form nnnExx, nnnE+xx, and nnnE-xx. It does not allow a decimal separator or sign in the significand or mantissa; to allow these elements in the string to be parsed, use the AllowDecimalPoint and AllowLeadingSign flags, or use a composite style that includes these individual flags.
Float	167	Indicates that the AllowLeadingWhite, AllowTrailingWhite, AllowLeadingSign, AllowDecimalPoint, and AllowExponent styles are used. This is a composite number style.
AllowCurrencySymbol	256	Indicates that the numeric string can contain a currency symbol. Valid currency symbols are determined by the CurrencySymbol property.
Currency	383	Indicates that all styles except AllowExponent and AllowHexSpecifier are used. This is a composite number style.
Any	511	Indicates that all styles except AllowHexSpecifier and AllowBinarySpecifier are used. This is a composite number style.
AllowHexSpecifier	512	Indicates that the numeric string represents a hexadecimal value. Valid hexadecimal values include the numeric digits 0-9 and the hexadecimal digits A-F and a-f. Strings that are parsed using this style cannot be prefixed with "0x" or "&h". A string that is parsed with the AllowHexSpecifier style will always be interpreted as a hexadecimal value. The only flags that can be combined with AllowHexSpecifier are AllowLeadingWhite and AllowTrailingWhite. The NumberStyles enumeration includes a composite style, HexNumber, that consists of these three flags.
HexNumber	515	Indicates that the AllowLeadingWhite, AllowTrailingWhite, and AllowHexSpecifier styles are used. This is a composite number style.
AllowBinarySpecifier	1024	Indicates that the numeric string represents a binary value. Valid binary values include the numeric digits 0 and 1. Strings that are parsed using this style do not employ a prefix; 0b cannot be used. A string that is parsed with the AllowBinarySpecifier style will always be interpreted as a binary value. The only flags that can be combined with AllowBinarySpecifier are AllowLeadingWhite and AllowTrailingWhite. The NumberStyles enumeration includes a composite style, BinaryNumber, that consists of these three flags.
BinaryNumber	1027	Indicates that the AllowLeadingWhite, AllowTrailingWhite, and AllowBinarySpecifier styles are used. This is a composite number style.

**/
namespace GlobalizationEnum{
    class NumberStylesClass{
        public static void Main(){
            Console.WriteLine("Number Styles Enum.");
            // Parse the string as a hex value and display the value as a decimal.
            String num = "A";
            int val = int.Parse(num, NumberStyles.HexNumber);
            Console.WriteLine("{0} in hex = {1} in decimal.", num, val);

            // Parse the string, allowing a leading sign, and ignoring leading and trailing white spaces.
            num = "    -45   ";
            val = int.Parse(num, NumberStyles.AllowLeadingSign |
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite);
            Console.WriteLine("'{0}' parsed to an int is '{1}'.", num, val);

            // Parse the string, allowing parentheses, and ignoring leading and trailing white spaces.
            num = "    (37)   ";
            val = int.Parse(num, NumberStyles.AllowParentheses | NumberStyles.AllowLeadingSign |                         NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite);
            Console.WriteLine("'{0}' parsed to an int is '{1}'.", num, val);
        }
    }
}