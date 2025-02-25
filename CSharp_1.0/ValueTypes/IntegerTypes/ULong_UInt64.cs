using System;

namespace ULong_UInt64{
    public class ULong_UInt64{
        /**
        ulong - UInt64 - unsign positive number range starts from 0 to 18,446,744,073,709,551,615
        Eighteen quintillion, four hundred forty-six quadrillion, seven hundred forty-four trillion, seventy-three billion, seven hundred nine million, five hundred fifty-one thousand, six hundred fifteen
        Default Value is 0
        It is not CLS Complience , meaning not gaurentee that all .Net language supports this type. alternative type is Decimal.
        2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2 
        2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2
        = 18,446,744,073,709,551,616

        When assigning a literal value to a ulong variable, you can use the suffix UL, ul, LU, or lu to indicate that the value is of type ulong
        ulong myUlongValue = 12345678901234567890UL;
        positive number - uses regular binary number

        Using the UL suffix is a good practice to ensure clarity and avoid potential issues when dealing with large numbers. It explicitly indicates that the literal is of type ulong, making your code more readable and less error-prone.
        **/
        public static void Main(){
            System.Console.WriteLine("Max:"+ulong.MaxValue);
            System.Console.WriteLine("Min:"+ulong.MinValue);
            ulong a = 9798797979787979879UL;
            System.Console.WriteLine(ulong.CreateChecked(a));
            System.Console.WriteLine(ulong.IsEvenInteger(a));
            System.Console.WriteLine(ulong.LeadingZeroCount(a));
            UInt64 b = 98789879798797987UL;
            System.Console.WriteLine(UInt64.Max(a,b));
            System.Console.WriteLine(typeof(ulong));
            System.Console.WriteLine(sizeof(ulong));
        }
    }
}