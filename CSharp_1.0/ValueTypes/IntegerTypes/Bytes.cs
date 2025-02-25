using System;
using System.Globalization;

namespace Bytes{
    public class Bytes{
        public static void Main(){
            // 1 Byte = 8 bit - it stores 1 byte of memory and value from 0 to 255
            //2*2*2*2*2*2*2*2 = 256
            //1 KB = 1000 Bytes
            Byte numMax = Byte.MaxValue;
            //Byte numMin = Byte.MinValue;
            Byte numFive = 5;
            Byte num100 = 100;
            Console.WriteLine($"memory allocated for Byte is : {sizeof(byte)}");
            Console.WriteLine(Byte.Clamp(1,5,100));//set min and max and get value within that range
            Console.WriteLine(num100.CompareTo(numFive)); //Gives the differance value
            Console.WriteLine(numMax.CompareTo((object)numMax));
            Console.WriteLine(Byte.CreateChecked(1000)); //check the value to type range if it with range then return value passed less throw overflow execption
            Console.WriteLine(Byte.CreateSaturating(-1000));//Value will checked againt range and if value exist range then set its limits 0 or 255.
            Console.WriteLine(Byte.CreateTruncating(257));//it truncate the value that suits to the range, ex: 256 - 0, 257 - 1
            Console.WriteLine(Byte.DivRem(17,3)); //gives the Quotient and remainder when you pass Divident and Divider as a tuple.
            Console.WriteLine(numFive.Equals(5));//Returns True or False by checking Value of both instance.
            Console.WriteLine(numFive.Equals((object)5));//true if obj is an instance of Byte and equals the value of this instance; otherwise, false.
            Console.WriteLine(numFive.GetHashCode()+" "+ num100.GetHashCode());//Generate the Unique key as int using hashfunction used for searck key and it is powerful.
            Console.WriteLine(numFive.GetTypeCode());//Returns the TypeCode for this instance.
            Console.WriteLine(Byte.IsEvenInteger(numFive) + " - " + Byte.IsEvenInteger(num100) );//true if value is an even integer; otherwise, false.
            Console.WriteLine(Byte.IsOddInteger(numFive)+ " - "+ Byte.IsOddInteger(num100));//true if value is an odd integer; otherwise, false.
            Console.WriteLine(Byte.IsPow2(18));//true if value is a power of two; otherwise, false.
            Console.WriteLine(Byte.LeadingZeroCount(200));//The number of leading zeros bit in value. 000100
            Console.WriteLine(Byte.Log2(num100));//Returns The log2 of value.
            Console.WriteLine("MAx Valyue is : "+Byte.Max(numFive,num100));//Return x if it is greater than y; otherwise, y.
            Console.WriteLine("Min Value is: "+ Byte.Min(numFive,num100));//Return x if it is less than y; otherwise, y.
            
        }
    }
}