using System;
using System.Runtime.InteropServices;

namespace IntPtrNameSpace{
    public class IntPtrInt32Int64{

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        public static void Main(){
            /**
            IntPtr: A platform-specific type that is used to represent a pointer or a handle. It is designed to be an integer large enough to hold a memory address.
            Platform-Specific Size: The size of IntPtr depends on the platform:
                On a 32-bit system, IntPtr is 4 bytes.
                On a 64-bit system, IntPtr is 8 bytes.

            Usage:
                Pointers: Used to store pointers to memory locations, especially when interacting with unmanaged code.
                Handles: Often used to store handles to resources like windows, files, or other system objects.
                Interoperability: Facilitates interaction between managed and unmanaged code, making it useful in scenarios involving P/Invoke or COM interop.

            nint or IntPtr is a alise name
            
            It is used in interoper/pointer/windows/File or low level Interaction to get appropiate result and that need to handled properly in c#.
            **/
            System.Console.WriteLine("Maximum of nint :"+nint.MaxValue);
            System.Console.WriteLine("Min of nint :"+ nint.MinValue);
            nint a = new nint(8678686876);
            System.Console.WriteLine("Size of nint"+ nint.Size);
            nint b = nint.Zero;
            System.Console.WriteLine("Print the Value of b :"+b);
            nint result = nint.Add(a,5);
            System.Console.WriteLine("Add of A plus 5 :"+ result);
            nint resultSub = nint.Subtract(result,5);
            System.Console.WriteLine("Subtract Is :"+ resultSub);
            nint longNum = new nint(9223372036854775807);
            System.Console.WriteLine(nint.CreateChecked(longNum));
            
            IntPtr handle = GetForegroundWindow();
            Console.WriteLine("Output of handle form GetForegroundWindow of Windows Api method :"+handle); // Output: Handle to the foreground window

            
        }
    }
}