using System;

namespace Int_Int32{
    public class Int_Int32{
        public static void Main(){
            /**
            int stores 32 bit (4 byte) and Range starts from -2,147,483,648 to 2,147,483,647
            2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2 = 4,294,967,296
            two billion, one hundred forty-seven million, four hundred eighty-three thousand, six hundred forty-eight
            It is CLS Complience, means available in all .Net 
            int is default for c# in any operations like arimethic to complex operations.
            int and Int32 are alise name for System.Int32.
            positive number - uses regular binary number
            negative number - Stored in two's complement form. For example, -1 is represented as 11111111111111111111111111111111 in binary
            **/
            System.Console.WriteLine("Max Value is :"+ int.MaxValue);
            System.Console.WriteLine("Min Value is :"+ int.MinValue);
            int a = 1000000;
            int b = -19000393;
            System.Console.WriteLine("Check within Range :"+Int32.CreateChecked(a));
            System.Console.WriteLine("Check a and b are Equal :"+int.Equals(a,b));
        }
    }
}