using System;
/**
hese examples show you how to perform the following tasks:

Obtain the hexadecimal value of each character in a string.

Obtain the char that corresponds to each value in a hexadecimal string.

Convert a hexadecimal string to an int.

Convert a hexadecimal string to a float.

Convert a byte array to a hexadecimal string.

**/
namespace CastingTypeConvertion{
    class HexadecimalToNumericClass{
        public static void Main(){
            Console.WriteLine("Hexa Decimal to Numeric Convertion.");

            //This example outputs the hexadecimal value of each character in a string. 
            // First it parses the string to an array of characters. Then it calls ToInt32(Char) on each character to obtain its numeric value. 
            // Finally, it formats the number as its hexadecimal representation in a string
            string input = "Hello World!";
            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the integer value to a hexadecimal value in string form.
                Console.WriteLine($"Hexadecimal value of {letter} is {value:X}");
            }

            //This example parses a string of hexadecimal values and outputs the character corresponding to each hexadecimal value. 
            // First it calls the Split(Char[]) method to obtain each hexadecimal value as an individual string in an array. 
            // Then it calls ToInt32(String, Int32) to convert the hexadecimal value to a decimal value represented as an int. It shows two different ways to obtain the character corresponding to that character code. The first technique uses ConvertFromUtf32(Int32), which returns the character corresponding to the integer argument as a string. The second technique explicitly casts the int to a char.
            string hexValues = "48 65 6C 6C 6F 20 57 6F 72 6C 64 21";
            string[] hexValuesSplit = hexValues.Split(' ');
            foreach (string hex in hexValuesSplit)
            {
                // Convert the number expressed in base-16 to an integer.
                int value = Convert.ToInt32(hex, 16);
                // Get the character corresponding to the integral value.
                string stringValue = Char.ConvertFromUtf32(value);
                char charValue = (char)value;
                Console.WriteLine("hexadecimal value = {0}, int value = {1}, char value = {2} or {3}",
                                    hex, value, stringValue, charValue);


                //This example shows another way to convert a hexadecimal string to an integer, by calling the Parse(String, NumberStyles) method.
                string hexString = "8E2";
                int num = Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
                Console.WriteLine(num);
                //Output: 2274

                //The following example shows how to convert a hexadecimal string to a float by using the System.BitConverter class and the UInt32.Parse method.
                string hexString1 = "43480170";
                uint num1 = uint.Parse(hexString1, System.Globalization.NumberStyles.AllowHexSpecifier);

                byte[] floatVals = BitConverter.GetBytes(num1);
                float f = BitConverter.ToSingle(floatVals, 0);
                Console.WriteLine($"float convert = {f}");

                // Output: 200.0056

                //The following example shows how to convert a byte array to a hexadecimal string by using the System.BitConverter class.
                byte[] vals = [0x01, 0xAA, 0xB1, 0xDC, 0x10, 0xDD];
                string str = BitConverter.ToString(vals);
                Console.WriteLine(str);

                str = BitConverter.ToString(vals).Replace("-", "");
                Console.WriteLine(str);

                /*Output:
                01-AA-B1-DC-10-DD
                01AAB1DC10DD
                */

                //The following example shows how to convert a byte array to a hexadecimal string by calling the Convert.ToHexString method introduced in .NET 5.0.
                byte[] array = [0x64, 0x6f, 0x74, 0x63, 0x65, 0x74];

                string hexValue = Convert.ToHexString(array);
                Console.WriteLine(hexValue);

                /*Output:
                646F74636574
                */
            }


        }
    }
}