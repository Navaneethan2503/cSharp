using System;

namespace UInt_UInt32{
    public class UInt_UInt32{
        public static void Main(){
            /**
            uint or UInt32 - unsign number that stores each number 32 bit (4 byte) - range from 0 to 4,294,967,295.
            2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2 = 4,294,967,296
            it is not CLS complience, means it is not available in all .Net. alternative for this is ulong / ULong64
            positive number - uses regular binary number
            **/
            System.Console.WriteLine("Unit 32 Max Value :"+uint.MaxValue);
            System.Console.WriteLine("Unit 32 Min Value :"+ uint.MinValue);
            uint a = 2332333;
            UInt32 b = 2356546565;
            uint result = a*b;
            System.Console.WriteLine("Result:"+result);
            System.Console.WriteLine("Checks the Sign of Value :"+uint.Sign(a));
            System.Console.WriteLine("Checks Max Number between a and b :"+uint.Max(a,b));

        }
    }
}