using System;

namespace UShort{
    public class UShort{
        public static void Main(){
            /**
            ushort - unsigned short integer only positive number.
            ushort use or allocate memory of 16 bit (2 bytes) on each number to store and Range start from 0 to 65,535
            2*2*2*2*2*2*2*2*2*2*2*2*2*2*2*2 = 65,536
            ushort is not CLS-compliant, which means it might not be available in all .NET languages.
            You can perform arithmetic operations on ushort variables, but you need to cast the result back to ushort if the operation involves other integer types.
            Positive Values: Stored as regular binary numbers.
            **/
            ushort a = 60000;
            UInt16 b = 50000;
            System.Console.WriteLine("ushort Max limit :"+ ushort.MaxValue);
            System.Console.WriteLine("ushort Min Limit :"+ ushort.MinValue);
            System.Console.WriteLine("Check for It is in range or not :"+ ushort.CreateChecked<ushort>(a));
            System.Console.WriteLine("IS even Checks :"+UInt16.IsEvenInteger(b));
        }
    }
}