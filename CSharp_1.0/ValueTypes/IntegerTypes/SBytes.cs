using System.Runtime.InteropServices;

namespace SBytes{
    public class SBytes{
        public static void Main(){
            //sbytes range -128 to 127 and stored 8 bit of memory for each sbyte , over all total 256 number it holds
            //sbytes are not CLS Complience -not supported in all .Net.
            //Always be cautious when performing arithmetic operations on smaller integer types like short and byte. Ensure that you handle potential overflows and use explicit casting when necessary.
            //During Arithmetic operation in short numeric types like bytes and short , C# promotes to int to avoid overflow then the result we need to explicit cast it.
            ////2*2*2*2*2*2*2*2 = 256 - first half for negative and second half for positive.
            sbyte a = -50;
            System.Console.WriteLine($"SBytes : {sizeof(sbyte)}");
            System.Console.WriteLine(sbyte.MaxValue);
            System.Console.WriteLine(sbyte.MinValue);
            System.Console.WriteLine(sbyte.Abs(19));//return absolute of a value.


            sbyte b = 2;
            System.Console.WriteLine("copy sign :"+sbyte.CopySign(a,b));//return a value with the magnitude of the first argument (value) and the sign of the second argument (sign).
            System.Console.WriteLine($"IsNegative Integer ({a}): "+sbyte.IsNegative(a));
            System.Console.WriteLine($"IsPositive Integer: ({b})"+ sbyte.IsPositive(b));
            System.Console.WriteLine($"Max Magnitude is:"+sbyte.MaxMagnitude(a,b)+ "Max is:"+ sbyte.Max(a,b));
            System.Console.WriteLine($"Min Magnitude Is: "+sbyte.MinMagnitude(a,b)+ "Min is: "+ sbyte.Min(a,b));
            System.Console.WriteLine("PopCount is "+sbyte.PopCount(a));//EG: Binary: 11101 , count - 4 ;return count the number of set bits (1s) in the binary representation of a value
            System.Console.WriteLine("Left Rotate Is "+ sbyte.RotateLeft(b,1));//rotates the bits of an sbyte value to the left by a specified number of positions.
            System.Console.WriteLine("Right Rotate IS "+sbyte.RotateRight(b,8));
            System.Console.WriteLine($"Sign of ({a}) is :"+sbyte.Sign(a)+ $"Sign of ({b}) is:"+ sbyte.Sign(b));//return 1 if value is positive, Zero if value is zero, and a -1 if value is negative.
            System.Console.WriteLine("Trailing Zero "+ sbyte.TrailingZeroCount(b));//Return compute of zero in value of binary
        }
    }   
}