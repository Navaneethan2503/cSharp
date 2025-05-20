using System;
/**
Most of the C# code you write is "verifiably safe code." Verifiably safe code means .NET tools can verify that the code is safe. In general, safe code doesn't directly access memory using pointers. It also doesn't allocate raw memory. It creates managed objects instead.

C# supports an unsafe context, in which you can write unverifiable code. In an unsafe context, code can use pointers, allocate and free blocks of memory, and call methods using function pointers. Unsafe code in C# isn't necessarily dangerous; it's just code whose safety can't be verified.

Unsafe code is required when you call native functions that require pointers.

Pointer types:
-------------
n an unsafe context, a type can be a pointer type, in addition to a value type, or a reference type. 
A pointer type declaration takes one of the following forms:
    type* identifier;
    void* identifier; //allowed but not recommended
The type specified before the * in a pointer type is called the referent type.
Pointer types don't inherit from object and no conversions exist between pointer types and object. Also, boxing and unboxing don't support pointers. However, you can convert between different pointer types and between pointer types and integral types
When you declare multiple pointers in the same declaration, you write the asterisk (*) together with the underlying type only. It isn't used as a prefix to each pointer name.
    int* p1, p2, p3;   // Ok
    int *p1, *p2, *p3;   // Invalid in C#

The garbage collector doesn't keep track of whether an object is being pointed to by any pointer types. If the referrant is an object in the managed heap (including local variables captured by lambda expressions or anonymous delegates), the object must be pinned for as long as the pointer is used.
The value of the pointer variable of type MyType* is the address of a variable of type MyType. The following are examples of pointer type declarations:
    int* p: p is a pointer to an integer.
    int** p: p is a pointer to a pointer to an integer.
    int*[] p: p is a single-dimensional array of pointers to integers.
    char* p: p is a pointer to a char.
    void* p: p is a pointer to an unknown type.
The pointer indirection operator * can be used to access the contents at the location pointed to by the pointer variable
The expression *myVariable denotes the int variable found at the address contained in myVariable.
There are several examples of pointers in the articles on the fixed statement. The following example uses the unsafe keyword and the fixed statement, and shows how to increment an interior pointer. You can paste this code into the Main function of a console application to run it. These examples must be compiled with the AllowUnsafeBlocks compiler option set.
You can't apply the indirection operator to a pointer of type void*. However, you can use a cast to convert a void pointer to any other pointer type, and vice versa.
A pointer can be null. Applying the indirection operator to a null pointer causes an implementation-defined behavior.
Passing pointers between methods can cause undefined behavior. Consider a method that returns a pointer to a local variable through an in, out, or ref parameter or as the function result. If the pointer was set in a fixed block, the variable to which it points might no longer be fixed.
Any pointer type can be implicitly converted to a void* type. Any pointer type can be assigned the value null. Any pointer type can be explicitly converted to any other pointer type using a cast expression. You can also convert any integral type to a pointer type, or any pointer type to an integral type. These conversions require an explicit cast.


Fixed-size buffers:
---------------------

You can use the fixed keyword to create a buffer with a fixed-size array in a data structure. Fixed-size buffers are useful when you write methods that interoperate with data sources from other languages or platforms. The fixed-size buffer can take any attributes or modifiers that are allowed for regular struct members. The only restriction is that the array type must be bool, byte, char, short, int, long, sbyte, ushort, uint, ulong, float, or double.
    private fixed char name[30];
In safe code, a C# struct that contains an array doesn't contain the array elements. The struct contains a reference to the elements instead. You can embed an array of fixed size in a struct when it's used in an unsafe code block.
Another common fixed-size array is the bool array. The elements in a bool array are always 1 byte in size. bool arrays aren't appropriate for creating bit arrays or buffers.

Fixed-size buffers are compiled with the System.Runtime.CompilerServices.UnsafeValueTypeAttribute, which instructs the common language runtime (CLR) that a type contains an unmanaged array that can potentially overflow. Memory allocated using stackalloc also automatically enables buffer overrun detection features in the CLR. The previous example shows how a fixed-size buffer could exist in an unsafe struct.
    internal unsafe struct Buffer
    {
        public fixed char fixedBuffer[128];
    }


Fixed-size buffers differ from regular arrays in the following ways:
    May only be used in an unsafe context.
    May only be instance fields of structs.
    They're always vectors, or one-dimensional arrays.
    The declaration should include the length, such as fixed char id[8]. You can't use fixed char id[].


Function pointers:
------------------
A function pointer is a variable that holds the memory address of a method, allowing you to call that method indirectly.

In C#, function pointers are declared using the delegate* syntax.

✅ Requirements:
---------------------
Must be in an unsafe context.
The method must be static and unmanaged.
The project must allow unsafe code.

Feature	Function Pointer (delegate*)	Delegate
Type Safety	Low	High
Performance	High (no heap allocation)	Lower
Interop Friendly	Yes	Limited
Garbage Collected	No	Yes
Can Point to Instance Methods	No	Yes


🔐 Security and Safety:
---------------------------
Function pointers are unsafe because:
    They bypass the type system.
    They can point to invalid memory.
    They are not garbage collected.
    Use them only when necessary.



**/
namespace Pointers{
    public struct PathArray
    {
        public char[] pathName;
        private int reserved;
    }

    //A struct can contain an embedded array in unsafe code. In the following example, the fixedBuffer array has a fixed size. You use a fixed statement to get a pointer to the first element. You access the elements of the array through this pointer. The fixed statement pins the fixedBuffer instance field to a specific location in memory.
    internal unsafe struct Buffer
    {
        public fixed char fixedBuffer[128];
    }

    internal unsafe class Example
    {
        public Buffer buffer = default;
    }

    


    class PointerTypesFunction{
        private static void AccessEmbeddedArray()
        {
            var example = new Example();

            unsafe
            {
                // Pin the buffer to a fixed location in memory.
                fixed (char* charPtr = example.buffer.fixedBuffer)
                {
                    *charPtr = 'A';
                }
                // Access safely through the index:
                char c = example.buffer.fixedBuffer[0];
                Console.WriteLine(c);

                // Modify through the index:
                example.buffer.fixedBuffer[0] = 'B';
                Console.WriteLine(example.buffer.fixedBuffer[0]);
            }
        }

        public static void Main(){
            Console.WriteLine("Pointer Types and Functions");
            int number = 1024;

            unsafe
            {
                // Convert to byte:
                byte* p = (byte*)&number;

                System.Console.Write("The 4 bytes of the integer:");

                // Display the 4 bytes of the int variable:
                for (int i = 0 ; i < sizeof(int) ; ++i)
                {
                    System.Console.Write(" {0:X2}", *p);
                    // Increment the pointer:
                    p++;
                }
                System.Console.WriteLine();
                System.Console.WriteLine($"The value of the integer: {number}");

                /* Output:
                    The 4 bytes of the integer: 00 04 00 00
                    The value of the integer: 1024
                */
            }

            //Function Pointer
            static int Add(int a, int b) => a + b;
            unsafe
            {
                delegate*<int, int, int> addPtr = &Add;
                int result = addPtr(3, 4); // Calls Add(3, 4)
                Console.WriteLine("function Pointer : "+result);
            }



        }
    }
}