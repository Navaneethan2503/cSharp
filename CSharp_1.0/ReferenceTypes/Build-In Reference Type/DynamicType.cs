using System;

/**
When operations are applied to expressions of type dynamic, their resolution is deferred until the program is run.

no error is given during compilation. Instead, an exception will be thrown when resolution of the operation fails at run-time.

The dynamic language runtime (DLR) provides the infrastructure that supports the dynamic type in C#, and also the implementation of dynamic programming languages such as IronPython and IronRuby.

Dynamic Typing: Unlike statically typed variables (where the type is known at compile time), dynamic variables are resolved at runtime. This means you can assign any type of value to a dynamic variable, and the type checking is deferred until the code is executed.

Syntax: Declaring a dynamic variable is straightforward:

dynamic variableName = value;
For example:

dynamic myVar = 10;
myVar = "Hello, World!";
Interoperability: dynamic is particularly useful when working with COM objects, dynamic languages like Python, or when dealing with JSON or XML data where the structure might not be known at compile time.

No IntelliSense: Since the type is determined at runtime, you won't get IntelliSense support in your IDE for dynamic variables. This can make development a bit more challenging.

Performance: Using dynamic can introduce a performance overhead because the runtime has to perform type checking and binding operations. It's generally advisable to use dynamic only when necessary.

Error Handling: Errors related to dynamic variables are caught at runtime, not compile time. This means you need to be extra cautious and ensure proper error handling to avoid runtime exceptions.

Size and Memory of Dynamic Type
The dynamic type in C# is essentially treated as an object at runtime, but with additional overhead for managing dynamic operations. Here are some key points:

Memory Size: The memory size of a dynamic variable depends on the actual type it holds at runtime. However, there is additional overhead due to the dynamic nature:

On a 32-bit machine, a dynamic variable typically requires 24 bytes.
On a 64-bit machine, it requires 48 bytes1.
Heap Allocation: Since dynamic is a reference type, the actual data is stored on the heap, and the variable holds a reference to this data.

Performance of Dynamic Type
Using dynamic can impact performance due to the runtime type resolution and binding operations. Here are some considerations:

Runtime Type Resolution: The type of a dynamic variable is resolved at runtime, which involves additional processing compared to statically typed variables. This can introduce a performance overhead.

Caching: The .NET runtime uses caching to optimize dynamic operations, reducing the performance hit. However, dynamic operations are still generally slower than their statically typed counterparts2.

Reflection: Dynamic operations often involve reflection, which is slower than direct method calls. However, dynamic operations are optimized to be faster than traditional reflection2.

Performance Comparison: In a simple test, accessing a property using dynamic was found to be about 20 times slower than static C# but significantly faster than using reflection2.

Example
Here's an example to illustrate the performance impact:

dynamic dyn = 10;
int result = dyn + 20; // Runtime type resolution and binding

int stat = 10;
int resultStat = stat + 20; // Compile-time type resolution
In this example, the dynamic addition involves runtime type resolution, making it slower than the statically typed addition.

Summary
Memory: dynamic variables have additional overhead compared to statically typed variables.
Performance: Dynamic operations are slower due to runtime type resolution and reflection but are optimized with caching.

Scope
Local Scope: A dynamic variable declared within a method or block has local scope and is accessible only within that method or block.

void MyMethod() {
    dynamic localVar = "Hello";
    // localVar is accessible only within MyMethod
}
Class Scope: A dynamic variable declared at the class level (as a field) has class scope and is accessible throughout the class.

class MyClass {
    dynamic classVar = 10;
    void MyMethod() {
        // classVar is accessible here
    }
}
Namespace Scope: A dynamic variable cannot be declared directly within a namespace. It must be within a class, struct, or method.

Lifetime
The lifetime of a dynamic variable is determined by its scope:

Local Variables: Exist only during the execution of the method or block in which they are declared.
Class Fields: Exist for the lifetime of the class instance.
Static Fields: Exist for the lifetime of the application domain.

object Type
Static Typing: When you declare a variable as object, it is statically typed. This means that the compiler knows the variable is of type object, but it doesn't know the actual type of the value it holds.

object obj = "Hello";
Type Casting: To use the actual type of the value stored in an object variable, you need to cast it explicitly.

object obj = "Hello";
string str = (string)obj; // Explicit casting
Compile-Time Checking: The compiler performs type checking at compile time. If you try to call a method or access a property that doesn't exist on object, you'll get a compile-time error.

object obj = "Hello";
// obj.Length; // Compile-time error
dynamic Type
Dynamic Typing: When you declare a variable as dynamic, it is dynamically typed. This means that the type of the variable is determined at runtime, and the compiler defers type checking until the code is executed.

dynamic dyn = "Hello";
No Type Casting: You don't need to cast a dynamic variable to its actual type to use it. The runtime handles the type resolution and binding.

dynamic dyn = "Hello";
string str = dyn; // No explicit casting needed
Runtime Checking: The compiler doesn't perform type checking on dynamic variables. Instead, type checking is done at runtime. This allows you to call methods and access properties that are not known at compile time.

dynamic dyn = "Hello";
Console.WriteLine(dyn.Length); // No compile-time error, resolved at runtime
Key Differences
Type Checking: object requires explicit casting and compile-time type checking, while dynamic defers type checking to runtime and doesn't require explicit casting.
Flexibility: dynamic provides more flexibility, allowing you to work with types that are not known at compile time, making it useful for scenarios like COM interop, dynamic languages, and working with JSON/XML data.
IntelliSense: object provides IntelliSense support in IDEs, while dynamic does not, as the type is resolved at runtime.

The dynamic type itself does not have a specific class. Instead, it is a feature provided by the C# language that allows for dynamic typing. Under the hood, dynamic is treated as an object, but with additional runtime support for dynamic operations.

How Dynamic Works
When you declare a variable as dynamic, the C# compiler treats it as an object, but it also marks it with special metadata that tells the runtime to handle it dynamically. This means that the actual type of the variable is determined at runtime, and the runtime uses a mechanism called the Dynamic Language Runtime (DLR) to resolve method calls, property accesses, and other operations dynamically.

Example
Here's a simple example to illustrate how dynamic works:

dynamic dyn = "Hello, World!";
Console.WriteLine(dyn.Length); // Resolved at runtime

dyn = 123;
Console.WriteLine(dyn + 10); // Resolved at runtime
In this example, the type of dyn changes at runtime, and the operations on dyn are resolved dynamically.

Dynamic Language Runtime (DLR)
The DLR is a runtime environment that adds a set of services for dynamic languages to the .NET Framework. It provides the infrastructure that enables dynamic typing and dynamic method dispatch. The DLR is responsible for:

Dynamic Method Dispatch: Resolving method calls and property accesses at runtime.
Dynamic Object Interoperability: Enabling interoperability with dynamic languages like Python and JavaScript.
Expression Trees: Supporting dynamic expressions and operations.
Summary
The dynamic type itself does not have a specific class.
It is treated as an object with additional runtime support for dynamic operations.
The Dynamic Language Runtime (DLR) provides the infrastructure for dynamic typing and method dispatch.

**/

namespace DynamicType{

    class Calculator{
        dynamic a ;
        dynamic b ;

        public void getUserInput(dynamic input1, dynamic input2){
            Console.Write("Please Enter a Value: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Please Enter a Value:");
            b = int.Parse(Console.ReadLine());
        }

        public dynamic AddMethod(){
            return a+b;
        }
    }

    class ExampleClass
    {
        static dynamic _field;
        dynamic Prop { get; set; }

        public dynamic ExampleMethod(dynamic d)
        {
            dynamic local = "Local variable";
            int two = 2;

            if (d is int)
            {
                _field = local;
                return local;
            }
            else
            {
                return two;
            }
        }
    }
    public class DynamicType{
        public static void Main(){
            System.Console.WriteLine("DynamicType :");
            dynamic name = 1;
            object name1 = 1; 
            System.Console.WriteLine(name.GetType() + " - "+ name1.GetType());
            name = name + 1;
            //name1 = name1 + 1; - error

            ExampleClass ec = new ExampleClass();
            Console.WriteLine(ec.ExampleMethod(10));
            Console.WriteLine(ec.ExampleMethod("value"));

            name = name + "string";//Automatically it is getting changed the type in run time.
            Console.WriteLine(name);
            name = name + 1;
            //Console.WriteLine((int)name);//Runtime Error - Microsoft.CSharp.RuntimeBinder.RuntimeBinderException:

            dynamic obj = new Calculator();//dynamic object instance compiler will skip the compilation rules, syntax rules packages to metadata of dynamic that instruct DRL to validate in runtime.
            //obj.SomeThing();//Not Got Compile Time Error even undefined method accessing. But Encounter RunTime Error.
            obj.getUserInput("sd","sd");//Since argument type is dynamic so it allowed string but not used anywhere operation.
            Console.WriteLine(obj.AddMethod().GetType()+" - "+ obj.AddMethod());


        }
    }
}