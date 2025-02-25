using System;
using System.Runtime.InteropServices;

namespace UIntPtrNamespace{
    public class UIntPtrInt32Int64{

        [DllImport("user32.dll")]
        private static extern UIntPtr GetForegroundWindow();
        /**
        UIntPtr: Represents an unsigned integer where the bit-width is the same as a pointer. It is designed to be platform-specific, adapting to the architecture of the system (32-bit or 64-bit).
        Platform-Specific Size:
            On a 32-bit system, UIntPtr is 4 bytes.
            On a 64-bit system, UIntPtr is 8 bytes.
        
        Usage:
            Pointers: Used to store pointers to memory locations, especially when interacting with unmanaged code.
            Handles: Often used to store handles to resources like windows, files, or other system objects.
            Interoperability: Facilitates interaction between managed and unmanaged code, making it useful in scenarios involving P/Invoke or COM interop.

        Methods and Properties:
            UIntPtr.Zero: Represents a null pointer.
            ToUInt32(): Converts the value of the UIntPtr instance to a 32-bit unsigned integer.
            ToUInt64(): Converts the value of the UIntPtr instance to a 64-bit unsigned integer.
            Add(UIntPtr, int): Adds an offset to the value of a pointer.
            Subtract(UIntPtr, int): Subtracts an offset from the value of a pointer.

        it is not CLS Complience, means it is not gaurentee available in all .Net languages

        alisa name is nuint or UIntPtr

        Used Essential for interoperability between managed and unmanaged code.
        **/
        public static void Main(){
            System.Console.WriteLine("UIntPtr");
             System.Console.WriteLine("Maximum of nint :"+nuint.MaxValue);
            System.Console.WriteLine("Min of nint :"+ nuint.MinValue);
            nuint a = new nuint(8678686876);
            System.Console.WriteLine("Size of nint"+ nuint.Size);
            nuint b = nuint.Zero;
            System.Console.WriteLine("Print the Value of b :"+b);
            nuint result = nuint.Add(a,5);
            System.Console.WriteLine("Add of A plus 5 :"+ result);
            nuint resultSub = nuint.Subtract(result,5);
            System.Console.WriteLine("Subtract Is :"+ resultSub);
            nuint longNum = new nuint(9223372036854775807);
            System.Console.WriteLine(nuint.CreateChecked(longNum));
            
            UIntPtr handle = GetForegroundWindow();
            Console.WriteLine("Output of handle form GetForegroundWindow of Windows Api method :"+handle); // Output: Handle to the foreground window

        }
    }
}