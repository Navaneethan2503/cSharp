using System;
using System.Runtime.InteropServices;
/**
The sizeof operator in C# is used to determine the size, in bytes, of a value type. 
This can be particularly useful when working with low-level code, such as interop with unmanaged code or performance-critical applications.

Basic Usage
The sizeof operator can be used with built-in value types and user-defined structs. For example:

int size = sizeof(int); // Returns 4
In this example, sizeof(int) returns 4 because an int is 4 bytes in size.

Usage with Structs
You can also use sizeof with user-defined structs:

struct MyStruct
{
    public int a;
    public double b;
}

int size = sizeof(MyStruct); // Returns the size of MyStruct
Unsafe Context
The sizeof operator can only be used in an unsafe context for user-defined structs. This is because the size of a struct can depend on the packing and alignment of its fields, which is not always straightforward to determine in safe code. Here's how you can use it in an unsafe context:

unsafe
{
    int size = sizeof(MyStruct);
}

The sizeof operator returns the number of bytes occupied by a variable of a given type. In safe code, the argument to the sizeof operator must be the name of an unmanaged type or a type parameter that is constrained to be an unmanaged type. Unmanaged types include all numeric types, enum types, and tuple and struct types where all members are unmanaged types.

The result of the sizeof operator might differ from the result of the Marshal.SizeOf method, which returns the size of a type in unmanaged memory.

! In unsafe code, when you use the sizeof operator with a managed type (such as a class or record), it returns the size of the reference to the object, not the size of the object itself. This is typically the size of a pointer, which is 4 bytes on a 32-bit system and 8 bytes on a 64-bit system.

sizeof Operator
Purpose: Used to determine the size of a value type at compile time.
Context: Works with value types and unmanaged types.
Result: Returns the size of the type as it is represented in managed memory.
Example: sizeof(char) returns 2 because .NET uses Unicode characters, which are 2 bytes each.

Marshal.SizeOf Method
Purpose: Used to determine the size of a type in unmanaged memory.
Context: Works with both value types and reference types.
Result: Returns the size of the type as it would be represented in unmanaged memory.
Example: Marshal.SizeOf(typeof(char)) returns 1 because a char in unmanaged memory (ANSI) is typically 1 byte.

Key Differences
Managed vs. Unmanaged Memory: sizeof returns the size in managed memory, while Marshal.SizeOf returns the size in unmanaged memory.
Evaluation Time: sizeof is evaluated at compile time, making it faster but less flexible. Marshal.SizeOf is evaluated at runtime, making it more flexible but slightly slower123.
Supported Types: sizeof only works with value types and unmanaged types, while Marshal.SizeOf can handle both value types and reference types.
**/
namespace SizeOfOperator{

    public struct Point
    {
        public Point(byte tag, double x, double y) => (Tag, X, Y) = (tag, x, y);

        public byte Tag { get; }
        public double X { get; }
        public double Y { get; }
    }

    public record Test{
        public int num = default;
    }


    [StructLayout(LayoutKind.Sequential)]
    //StructLayout Attribute: The [StructLayout(LayoutKind.Sequential)] attribute ensures that the fields of the class are laid out in memory in the same order as they are declared. This is important for interop scenarios.
    class SizeOfOperatorClass{
        public int num = 1000;
        public static void Main(){
            Console.WriteLine("Size Of Operator !...");
            int a = 1000;
            Console.WriteLine(sizeof(int));

            Console.WriteLine(sizeof(byte));  // output: 1
            Console.WriteLine(sizeof(double));  // output: 8

            //Struct
            Point p1 = new Point(1,20.0,30.0);
            //Console.WriteLine("Size of Struct :"+ sizeof(Point)); 
            //error CS0233: 'Point' does not have a pre defined size, therefore sizeof can only be used in an unsafe context
            unsafe{
                int size = sizeof(Point);
                Console.WriteLine("Size of Struct on unsafe code :"+ size);

                Test t = new Test();
                SizeOfOperatorClass s = new SizeOfOperatorClass();
                Console.WriteLine(sizeof(SizeOfOperatorClass));
                Console.WriteLine(sizeof(Test));//Returns size of reference
            }

            //MArshal
            Console.WriteLine("Marshal");
            Console.WriteLine(Marshal.SizeOf(typeof(SizeOfOperatorClass)));
            Console.WriteLine(Marshal.SizeOf(typeof(int)));
            

        

            

        }

    }
}