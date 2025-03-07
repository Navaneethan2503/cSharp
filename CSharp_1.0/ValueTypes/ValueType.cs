using System;
/**
A variable of a value type contains an instance of the type( that store their value directly in memory).
By default, on assignment, passing an argument to a method, and returning a method result, variable values are copied.
Variable of value types directly contain their data

With value types, each variable has its own copy of the data, and it's not possible for operations on one variable to affect the other (except in the case of in, ref, and out parameter variables;

Direct Storage: The actual data is stored directly in the variable.
Stack Allocation: Value types are typically stored on the stack, which allows for efficient memory management and quick access.
Copying Behavior: When a value type is assigned to another variable, passed to a method, or returned from a method, a copy of the value is made.
Examples: Common value types include primitive data types like int, float, char, and bool, as well as structs and enums.

Why Value type Stored in Stack?
Value types are stored on the stack rather than the heap for several reasons:
Performance: The stack is faster to access and manage compared to the heap. Since value types are often small and frequently used, storing them on the stack allows for quicker read and write operations.
Memory Management: The stack automatically handles memory allocation and deallocation as variables go in and out of scope. This makes it easier to manage memory for value types without the need for garbage collection.
Predictability: The stack has a Last-In-First-Out (LIFO) structure, which makes the allocation and deallocation of memory very predictable. This predictability is beneficial for value types that have a short lifespan and are used in a well-defined scope.
Isolation: When a value type is assigned to another variable, a copy of the value is made. This isolation ensures that changes to one variable do not affect the other, which can help prevent unintended side effects in your code.

A new stack frame is created whenever a function (or method) is called. This stack frame is used to store the function's local variables, parameters, and return address. Here's a breakdown of when, why, and how a new stack frame is created:

When
Function Call: Each time a function is called, a new stack frame is created.
Nested Calls: If a function calls another function, a new stack frame is created for the called function.
Why
Isolation: Each function needs its own isolated space to store its local variables and parameters.
Scope Management: Stack frames help manage the scope of variables, ensuring that variables are only accessible within the function they are defined in.
Return Address: The stack frame stores the return address, which is the point in the code to return to after the function completes.
How
Function Call: When a function is called, the program's control flow jumps to the function's code.
Stack Pointer Adjustment: The stack pointer (a special register that tracks the top of the stack) is adjusted to allocate space for the new stack frame.
Frame Creation: The new stack frame is created, and it includes:
Return Address: The address to return to after the function completes.
Parameters: The function's parameters are pushed onto the stack.
Local Variables: Space is allocated for the function's local variables.
Execution: The function's code is executed using the new stack frame.
Function Return: When the function completes, the stack frame is popped off the stack, and the stack pointer is adjusted back to its previous position.

Comman Value Types:
1. Primitive Types - Integral, Floating point, Boolean, Char
2. Non Primitives/Composite Data Type - enum, struct, tuple

Value types are copied to a new instance in several scenarios. Here are the main situations where this occurs:
1. Assignment - When you assign a value type to another variable, a copy of the value is made.
2. Passing as Arguments to Methods - When a value type is passed to a method, a copy of the value is made.
3. Returning from Methods - When a value type is returned from a method, a copy of the value is made.
4. Boxing and Unboxing - When a value type is boxed (converted to an object), a copy of the value is made. Unboxing (converting back to a value type) also involves copying.
5. Array Elements - When a value type is stored in an array, each element is a separate instance.
6. Structs - When a struct (which is a value type) is assigned or passed, a copy of the entire struct is made.

Lifetime of Value Types
The lifetime of value types is determined by their scope and where they are stored:
Local Variables:Scope: The lifetime is limited to the block of code (usually a function or method) in which they are declared.
Method Parameters: Scope: The lifetime is limited to the duration of the method call.
Struct Fields: Scope: The lifetime is tied to the instance of the struct.
Array Elements: Scope: The lifetime is tied to the array instance.

ValueType class in the System namespace serves as the base class for all value types in .NET.
Purpose of ValueType:
Base Class for Value Types: ValueType provides the foundation for all value types, including primitive types (like int, float, bool) and user-defined structs.
Overrides Methods: It overrides some methods from the Object class to provide more appropriate implementations for value types. For example, it overrides Equals and GetHashCode to compare the actual values rather than references.
Boxing and Unboxing: ValueType plays a role in the boxing and unboxing process, which allows value types to be treated as objects. When a value type is boxed, it is wrapped in an object and stored on the heap. Unboxing extracts the value type from the object.

Usage:
While you typically don't use ValueType directly in your code, it is implicitly used by the .NET runtime. Here are some scenarios where ValueType is relevant:
Method Parameters: You can use ValueType as a parameter type to restrict method arguments to value types only.
Type Checking: It can be used in type checking and reflection to determine if a type is a value type.



**/

namespace ValueType{
    public struct MutablePoint
{
    public int X;
    public int Y;

    public MutablePoint(int x, int y) => (X, Y) = (x, y);

    public override string ToString() => $"({X}, {Y})";
}
    public class ValueType{

        public struct TaggedInteger
        {
            //Reference type containing inside
            public int Number;
            private string[] tags;//reference type

            public TaggedInteger(int n)
            {
                Number = n;
                tags = new string[n];
            }

            public void AddTag(int index,string tag) => tags[index] = tag ;

            public override string ToString() => $"{Number} [{string.Join(", ", tags)}]";
        }

        public static void Main(){
            Console.WriteLine("Value Type :");
            MutablePoint p1 = new MutablePoint(1,5);
            Console.WriteLine("p1 before change :"+p1.ToString());//p1 before change :(1, 5)
            MutablePoint p2 = p1;
            p1.X = 10;
            Console.WriteLine("p1 after change :"+p1.ToString());//p1 after change :(10, 5)
            Console.WriteLine("p2 :"+p2);//p2 :(1, 5)

            int a = 10;
            int b = a;
            a = 20;
            Console.WriteLine(a + " Changes not affected b: " + b);
            //these way all the value types does not effected the copied value becz it copies data itself to b and stored in stack.

            //If a value type contains a data member of a reference type, only the reference to the instance of the reference type is copied when a value-type instance is copied.
            //Both the copy and original value-type instance have access to the same reference-type instance.
            TaggedInteger taggedInteger = new TaggedInteger(5);
            taggedInteger.AddTag(0,"10");
            Console.WriteLine("Created Instance :"+ taggedInteger.ToString());//Created Instance :5 [10, , , , ]
            TaggedInteger copy = taggedInteger;
            taggedInteger.AddTag(1,"20");
            taggedInteger.AddTag(2,"30");
            Console.WriteLine("Created Instance :"+ taggedInteger.ToString());//Created Instance :5 [10, 20, 30, , ]
            Console.WriteLine("Copy :"+copy.ToString());//Copy :5 [10, 20, 30, , ]

        }
    }
}