using System;
/**
pointers are a powerful but advanced feature that allow direct memory manipulation, similar to C or C++. 
However, they are not commonly used in everyday C# programming because C# is designed to be a safe and managed language. Still, pointers can be useful in performance-critical applications like game development or interop with unmanaged code.

What is a Pointer?
A pointer is a variable that holds the memory address of another variable.

2. Enabling Unsafe Code
Pointers require unsafe context because they bypass C#'s type safety.
    1.You must use the unsafe keyword.
    2.The project must allow unsafe code (enabled in project settings or via compiler flag /unsafe).

3. Pointer Operations
You can perform several operations with pointers:
    1.Dereferencing: Access the value at the pointer's address using *.
    2.Address-of: Get the address of a variable using &.
    3.Pointer arithmetic: Increment or decrement pointers (only in unsafe context).

    You use the following operators to work with pointers:
        Unary & (address-of) operator: to get the address of a variable
        Unary * (pointer indirection) operator: to obtain the variable pointed by a pointer
        The -> (member access) and [] (element access) operators
        Arithmetic operators +, -, ++, and --
        Comparison operators ==, !=, <, >, <=, and >=

4. Fixed Keyword
Used to pin a variable in memory so the garbage collector doesn’t move it.

5. Common Use Cases
    1.Interfacing with unmanaged code (e.g., C/C++ libraries via P/Invoke).
    2.Performance-critical code (e.g., image processing, game engines).
    3.Working with hardware-level operations.

6. Limitations and Risks
    Can lead to memory corruption if misused.
    Not CLS-compliant (Common Language Specification).
    Not allowed in safe or managed environments like Unity (unless explicitly enabled).


Any operation with pointers requires an unsafe context. The code that contains unsafe blocks must be compiled with the AllowUnsafeBlocks compiler option.

fixed statement:
----------------
pin a variable for pointer operations
Fixed variables are variables that reside in storage locations that are unaffected by operation of the garbage collector. In the preceding example, the local variable number is a fixed variable, because it resides on the stack. Variables that reside in storage locations that can be affected by the garbage collector (for example, relocated) are called movable variables. Object fields and array elements are examples of movable variables. You can get the address of a movable variable if you "fix", or "pin", it with a fixed statement. 
You can't get the address of a constant or a value.
The address of a fixed, or pinned, variable doesn't change during execution of the statement. You can use the declared pointer only inside the corresponding fixed statement. The declared pointer is readonly and can't be modifie
You can use the fixed statement only in an unsafe context. The code that contains unsafe blocks must be compiled with the AllowUnsafeBlocks compiler option.

You can't apply the * operator to an expression of type void*.

Pointer member access operator ->:
----------------------------------
The -> operator combines pointer indirection and member access. That is, if x is a pointer of type T* and y is an accessible member of type T, an expression of the form
        x->y is equilant to (*x).y

You can't apply the -> operator to an expression of type void*.

Pointer Element Access p[]:
-----------------------------
For an expression p of a pointer type, a pointer element access of the form p[n] is evaluated as *(p + n)
where n must be of a type implicitly convertible to int, uint, long, or ulong. 
You can't use [] for pointer element access with an expression of type void*.


Pointer arithmetic operators:
-------------------------------
You can perform the following arithmetic operations with pointers:
    Add or subtract an integral value to or from a pointer
    Subtract two pointers
    Increment or decrement a pointer

Addition or subtraction of an integral value to or from a pointer:
-----------------------------------------------------------------
Both p + n and n + p expressions produce a pointer of type T* that results from adding n * sizeof(T) to the address given by p.
The p - n expression produces a pointer of type T* that results from subtracting n * sizeof(T) from the address given by p.

Pointer increment and decrement:
---------------------------------
The ++ increment operator adds 1 to its pointer operand. The -- decrement operator subtracts 1 from its pointer operand.

Both operators are supported in two forms: postfix (p++ and p--) and prefix (++p and --p). The result of p++ and p-- is the value of p before the operation. The result of ++p and --p is the value of p after the operation.

Pointer comparison operators:
---------------------------------
You can use the ==, !=, <, >, <=, and >= operators to compare operands of any pointer type, including void*. Those operators compare the addresses given by the two operands as if they're unsigned integers.



unsafe Keyword:
----------------
The unsafe keyword denotes an unsafe context, which is required for any operation involving pointers.
You can use the unsafe modifier in the declaration of a type or a member. The entire textual extent of the type or member is therefore considered an unsafe context.

**/
namespace Pointers{
    public struct Coords
    {
        public int X;
        public int Y;
        public override string ToString() => $"({X}, {Y})";
    }
    class PointerOperatorKeyword{
        //method declared with the unsafe modifier:
        //The scope of the unsafe context extends from the parameter list to the end of the method, so pointers can also be used in the parameter list:
        unsafe static void FastCopy(byte[] src, byte[] dst, int count)
        {
            // Unsafe context: can use pointers here.
        }

        public static void Main(){
            Console.WriteLine("Pointer Operators.");

            unsafe{
                int x = 10;
                int* ptr = &x; // ptr now holds the address of x
                Console.WriteLine(x+", Memory Address is :"+(int)ptr);
            }

            unsafe
            {
                int[] arr = { 1, 2, 3 };
                //With an array, The initialized pointer contains the address of the first array element.
                fixed (int* p = &arr[1])
                {
                    //Console.WriteLine(*(p + 1)); // prints 2
                    //int* pp = &arr[0];//You can only take the address of an unfixed expression inside of a fixed statement initializer
                    //With an address of a variable. Use the address-of & operator
                    Console.WriteLine(*p);
                }
            }

            //With the instance of the type that implements a method named GetPinnableReference. That method must return a ref variable of an unmanaged type. The .NET types System.Span<T> and System.ReadOnlySpan<T> make use of this pattern. You can pin span instances
            unsafe
            {
                int[] numbers = [10, 20, 30, 40, 50];
                Span<int> interior = numbers.AsSpan()[1..^1];
                fixed (int* p = interior)
                {
                    for (int i = 0; i < interior.Length; i++)
                    {
                        Console.Write(p[i]);  
                    }
                    // output: 203040
                }

                var message = "Hello!";
                fixed (char* p = message)
                {
                    Console.WriteLine(*p);  // output: H
                }
            }

            //Pointer indirection operator *
            unsafe{
                char letter = 'A';
                char* p = &letter;
                Console.WriteLine("Address of letter is :"+ (int)p +"Orginal Varibale Value is : "+letter);
                *p = 'Z';//modify the value by deference the point variable.
                Console.WriteLine("After Modify <> Address of letter is :"+ (int)p +"Orginal Varibale Value is : "+letter);
            }

            //pointer member access
            unsafe{
                Coords coords;
                Coords* p = &coords;
                p->X = 3;
                p->Y = 4;
                Console.WriteLine(p->ToString());  // output: (3, 4)
            }

            //Pointer element access operator []
            unsafe{
                char* pointerToChars = stackalloc char[123];

                for (int i = 65; i < 123; i++)
                {
                    pointerToChars[i] = (char)i;
                }

                Console.Write("Uppercase letters: ");
                for (int i = 65; i < 91; i++)
                {
                    Console.Write(pointerToChars[i]+',');//internally it is expression like this *(pointerToChars+n)
                }
            }

            unsafe{
                int x = 10;
                int y = 20;
                int* xp = &x;
                int* yp = &y;
                Console.WriteLine("Address of x : "+(int)xp);
                int* resp = xp + 1;//1*byte(int) = 4*1 = 4
                Console.WriteLine("After Addition :"+ (int)resp);
                int* subP = xp - 2;
                Console.WriteLine("After Sub :"+ (int)subP);
            }


        }
    }
}