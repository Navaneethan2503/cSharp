using System;

namespace Long_Long64{
    public class Long_Long64{
        /**
        size - 64 bit (8 bytes) - signed number
        Range of long is from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807.
        2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2 = 9,223,372,036,854,775,807 * 2 
        nine quintillion, two hundred twenty-three quadrillion, three hundred seventy-two trillion, thirty-six billion, eight hundred fifty-four million, seven hundred seventy-five thousand, eight hundred eight.
        it is CLS Complience, available in all .Net.
        Default Value: The default value of a long variable is 0.
        Literals: When assigning a literal value to a long variable, you can use the suffix L or l to indicate that the value is of type long.
        long myLongValue = 123456789L;
        By default, integer literals in C# are treated as int (32-bit signed integer)
        Using the L suffix is a good practice to ensure clarity and avoid potential issues when dealing with large numbers. It explicitly indicates that the literal is of type long, making your code more readable and less error-prone.
        **/
        public static void Main(){
            System.Console.WriteLine("Max:"+long.MaxValue);
            System.Console.WriteLine("Min:"+long.MinValue);
            long a = 9223372036854775807L;
            System.Console.WriteLine("Size for Long :"+sizeof(long));
            System.Console.WriteLine("type of a:"+a.GetType());
            Int64 b = 487979878L;
            System.Console.WriteLine(long.Equals(a,b));
        }
    }
}