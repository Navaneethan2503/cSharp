/**
Encoders and decoders:
--------------------------
.NET provides encoding classes that encode and decode text by using various encoding systems. For example, the UTF8Encoding class describes the rules for encoding to, and decoding from, UTF-8. .NET uses UTF-16 encoding (represented by the UnicodeEncoding class) for string instances. Encoders and decoders are available for other encoding schemes.

Encoding and decoding can also include validation. For example, the UnicodeEncoding class checks all char instances in the surrogate range to make sure they're in valid surrogate pairs. A fallback strategy determines how an encoder handles invalid characters or how a decoder handles invalid bytes.

All character encoding classes in .NET inherit from the System.Text.Encoding class, which is an abstract class that defines the functionality common to all character encodings. To access the individual encoding objects implemented in .NET, do the following:
    Use the static properties of the Encoding class, which return objects that represent the standard character encodings available in .NET (ASCII, UTF-7, UTF-8, UTF-16, and UTF-32). For example, the Encoding.Unicode property returns a UnicodeEncoding object. Each object uses replacement fallback to handle strings that it cannot encode and bytes that it cannot decode. For more information, see Replacement fallback.
    Call the encoding's class constructor. Objects for the ASCII, UTF-7, UTF-8, UTF-16, and UTF-32 encodings can be instantiated in this way. By default, each object uses replacement fallback to handle strings that it cannot encode and bytes that it cannot decode, but you can specify that an exception should be thrown instead. For more information, see Replacement fallback and Exception fallback.
    Call the Encoding(Int32) constructor and pass it an integer that represents the encoding. Standard encoding objects use replacement fallback, and code page and double-byte character set (DBCS) encoding objects use best-fit fallback to handle strings that they cannot encode and bytes that they cannot decode. For more information, see Best-fit fallback.
    Call the Encoding.GetEncoding method, which returns any standard, code page, or DBCS encoding available in .NET. Overloads let you specify a fallback object for both the encoder and the decoder.


Selecting an Encoding Class:
-----------------------------
If you have the opportunity to choose the encoding to be used by your application, you should use a Unicode encoding, preferably either UTF8Encoding or UnicodeEncoding. (.NET also supports a third Unicode encoding, UTF32Encoding.)
If you are planning to use an ASCII encoding (ASCIIEncoding), choose UTF8Encoding instead. The two encodings are identical for the ASCII character set, but UTF8Encoding has the following advantages:
It can represent every Unicode character, whereas ASCIIEncoding supports only the Unicode character values between U+0000 and U+007F.
It provides error detection and better security.
It has been tuned to be as fast as possible and should be faster than any other encoding. Even for content that is entirely ASCII, operations performed with UTF8Encoding are faster than operations performed with ASCIIEncoding.
You should consider using ASCIIEncoding only for legacy applications. However, even for legacy applications, UTF8Encoding might be a better choice for the following reasons (assuming default settings):
If your application has content that is not strictly ASCII and encodes it with ASCIIEncoding, each non-ASCII character encodes as a question mark (?). If the application then decodes this data, the information is lost.
If your application has content that is not strictly ASCII and encodes it with UTF8Encoding, the result seems unintelligible if interpreted as ASCII. However, if the application then uses a UTF-8 decoder to decode this data, the data performs a round trip successfully.
In a web application, characters sent to the client in response to a web request should reflect the encoding used on the client. In most cases, you should set the HttpResponse.ContentEncoding property to the value returned by the HttpRequest.ContentEncoding property to display text in the encoding that the user expects.


Using an Encoding Object:
--------------------------
An encoder converts a string of characters (most commonly, Unicode characters) to its numeric (byte) equivalent. For example, you might use an ASCII encoder to convert Unicode characters to ASCII so that they can be displayed at the console. To perform the conversion, you call the Encoding.GetBytes method. If you want to determine how many bytes are needed to store the encoded characters before performing the encoding, you can call the GetByteCount method.
A decoder converts a byte array that reflects a particular character encoding into a set of characters, either in a character array or in a string. To decode a byte array into a character array, you call the Encoding.GetChars method. To decode a byte array into a string, you call the GetString method. If you want to determine how many characters are needed to store the decoded bytes before performing the decoding, you can call the GetCharCount method.


Choosing a Fallback Strategy
When a method tries to encode or decode a character but no mapping exists, it must implement a fallback strategy that determines how the failed mapping should be handled. There are three types of fallback strategies:
    Best-fit fallback
    Replacement fallback
    Exception fallback

The most common problems in encoding operations occur when a Unicode character cannot be mapped to a particular code page encoding. The most common problems in decoding operations occur when invalid byte sequences cannot be translated into valid Unicode characters. For these reasons, you should know which fallback strategy a particular encoding object uses. Whenever possible, you should specify the fallback strategy used by an encoding object when you instantiate the object.

Best-Fit Fallback:
---------------------
When a character does not have an exact match in the target encoding, the encoder can try to map it to a similar character. (Best-fit fallback is mostly an encoding rather than a decoding issue. There are very few code pages that contain characters that cannot be successfully mapped to Unicode.) Best-fit fallback is the default for code page and double-byte character set encodings that are retrieved by the Encoding.GetEncoding(Int32) and Encoding.GetEncoding(String) overloads.


Replacement Fallback:
-----------------------
When a character does not have an exact match in the target scheme, but there is no appropriate character that it can be mapped to, the application can specify a replacement character or string. This is the default behavior for the Unicode decoder, which replaces any two-byte sequence that it cannot decode with REPLACEMENT_CHARACTER (U+FFFD). It is also the default behavior of the ASCIIEncoding class, which replaces each character that it cannot encode or decode with a question mark.

Exception Fallback:
-------------------
Instead of providing a best-fit fallback or a replacement string, an encoder can throw an EncoderFallbackException if it is unable to encode a set of characters, and a decoder can throw a DecoderFallbackException if it is unable to decode a byte array. To throw an exception in encoding and decoding operations, you supply an EncoderExceptionFallback object and a DecoderExceptionFallback object, respectively, to the Encoding.GetEncoding(String, EncoderFallback, DecoderFallback) method.

**/
using System;
using System.Text;

namespace StringBuilderText{
    class EncodingClassUsage{
        public static void Main(){
            Console.WriteLine("Usage of Encoding Classes");
            string[] strings= { "This is the first sentence. ",
                          "This is the second sentence. " };
            Encoding asciiEncoding = Encoding.ASCII;

            // Create array of adequate size.
            byte[] bytes = new byte[49];
            // Create index for current position of array.
            int index = 0;

            Console.WriteLine("Strings to encode:");
            foreach (var stringValue in strings) {
                Console.WriteLine($"   {stringValue}");

                int count = asciiEncoding.GetByteCount(stringValue);
                if (count + index >=  bytes.Length)
                    Array.Resize(ref bytes, bytes.Length + 50);

                int written = asciiEncoding.GetBytes(stringValue, 0,
                                                    stringValue.Length,
                                                    bytes, index);

                index = index + written;
            }
            Console.WriteLine("\nEncoded bytes:");
            Console.WriteLine($"{ShowByteValues(bytes, index)}");
            Console.WriteLine();

            // Decode Unicode byte array to a string.
            string newString = asciiEncoding.GetString(bytes, 0, index);
            Console.WriteLine($"Decoded: {newString}");

            //Fall Back
            //Best Fit Strategies
            try{
                // Get an encoding for code page 1252 (Western Europe character set).
                Encoding cp1252 = Encoding.GetEncoding(1252); //Throw Error - System.NotSupportedException: No data is available for encoding 1252. For information on defining a custom encoding, see the documentation for the Encoding.RegisterProvider method.
            

                // Define and display a string.
                string str = "\u24c8 \u2075 \u221e";
                Console.WriteLine("Original string: " + str);
                Console.Write("Code points in string: ");
                foreach (var ch in str)
                    Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));

                Console.WriteLine("\n");

                // Encode a Unicode string.
                Byte[] bytes1 = cp1252.GetBytes(str);
                Console.Write("Encoded bytes: ");
                foreach (byte byt in bytes1)
                    Console.Write("{0:X2} ", byt);
                Console.WriteLine("\n");

                // Decode the string.
                string str21 = cp1252.GetString(bytes1);
                Console.WriteLine($"String round-tripped: {str.Equals(str21)}");
                if (! str.Equals(str21)) {
                    Console.WriteLine(str21);
                    foreach (var ch in str21)
                        Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));
                }
            }
            catch(NotSupportedException ex){
                Console.WriteLine("Not Supported Exception Occuered .");
            }

            try{
                Encoding cp1252r = Encoding.GetEncoding(1252,
                                  new EncoderReplacementFallback("*"),
                                  new DecoderReplacementFallback("*"));

                string str11 = "\u24C8 \u2075 \u221E";
                Console.WriteLine(str11);
                foreach (var ch in str11)
                    Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));

                Console.WriteLine();

                byte[] bytes3 = cp1252r.GetBytes(str11);
                string str22 = cp1252r.GetString(bytes3);
                Console.WriteLine($"Round-trip: {str11.Equals(str22)}");
                if (! str11.Equals(str22)) {
                    Console.WriteLine(str22);
                    foreach (var ch in str22)
                        Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));

                    Console.WriteLine();
                }
            }
            catch(NotSupportedException ex){
                Console.WriteLine("Not Support Exception .");
            }


            //ASCII and Unicode Characters are having default Replacement Fallback with ? Question mark if no map found with code pages.
            Encoding enc = Encoding.ASCII;

            string str1 = "\u24C8 \u2075 \u221E";
            Console.WriteLine(str1);
            foreach (var ch in str1)
                Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));

            Console.WriteLine("\n");

            // Encode the original string using the ASCII encoder.
            byte[] bytes5 = enc.GetBytes(str1);
            Console.Write("Encoded bytes: ");
            foreach (var byt in bytes5)
                Console.Write("{0:X2} ", byt);
            Console.WriteLine("\n");

            // Decode the ASCII bytes.
            string str2 = enc.GetString(bytes5);
            Console.WriteLine($"Round-trip: {str1.Equals(str2)}");
            if (! str1.Equals(str2)) {
                Console.WriteLine(str2);
                foreach (var ch in str2)
                    Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));

                Console.WriteLine();
            }
            
        }

        private static string ShowByteValues(byte[] bytes, int last )
        {
            string returnString = "   ";
            for (int ctr = 0; ctr <= last - 1; ctr++) {
                if (ctr % 20 == 0)
                    returnString += "\n   ";
                returnString += String.Format("{0:X2} ", bytes[ctr]);
            }
            return returnString;
        }

    }
}