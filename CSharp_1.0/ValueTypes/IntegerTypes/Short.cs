using System;

namespace Short{
    public class Short{
        public static void Main(){
            /**
            Short Size - 16 bits (= 2 Bytes) - total range is -32,787 to 32786.
            2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2 = 65536
            positive number representation done as normal binary number
            negative number represented as two complementry form. For example, -1 is represented as 1111111111111111 in binary.
            short is CLS Compliance - means it is available in all .net language.
            Usage - when memory is curtial.
            Alisa name for this is short and Int16.
            Int Convertion on arthicmetic operation - To handle larger intermediate results, C# promotes the short values to int during arithmetic operations.
            **/
            //short a = -32767;
            Int16 b = 32;
            short ab = 1000;
            
            System.Console.WriteLine("Short Max Limit :"+ short.MaxValue);
            System.Console.WriteLine("Short Min Limit: "+ short.MinValue);
            System.Console.WriteLine($"truncate the short for multiply : {short.CreateTruncating<short>(12345)}");
            System.Console.WriteLine("Size for short data type allocated :"+sizeof(short) + "Bytes");
            short result = (short)(b * ab);
            System.Console.WriteLine(result);
        }
    }
}