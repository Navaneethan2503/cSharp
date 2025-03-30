using System;
using System.Collections.Generic;
/**
The new operator creates a new instance of a type. You can also use the new keyword as a member declaration modifier or a generic type constraint.

the new operator is used to create instances of types, such as classes, structs, or arrays. Here's a bit more detail:

Basic Usage
When you use the new operator, it allocates memory for a new object and returns a reference to that memory. For example:

MyClass obj = new MyClass();
In this example, new MyClass() creates a new instance of MyClass and assigns it to the variable obj.

Creating Arrays
You can also use the new operator to create arrays:

int[] numbers = new int[5];

Constructor invocation
To create a new instance of a type, you typically invoke one of the constructors of that type using the new operator:

Automatic Destruction
Value Types: Instances of value types (like int, struct, etc.) are destroyed automatically when the context (such as a method or block of code) that contains them is exited. This is because value types are typically stored on the stack, and their memory is reclaimed as soon as the stack frame is popped.

Reference Types: Instances of reference types (like objects created from classes) are managed by the garbage collector. The garbage collector automatically destroys these instances at some unspecified time after the last reference to them is removed. This means you don't have to manually free the memory for these objects.

Unmanaged Resources
For type instances that contain unmanaged resources (like file handles, database connections, etc.), it's important to release these resources as soon as they are no longer needed. This is because unmanaged resources are not handled by the garbage collector and can lead to resource leaks if not properly released.

Deterministic Clean-up
To ensure that unmanaged resources are released promptly, you should implement deterministic clean-up. This is typically done by implementing the IDisposable interface and using the Dispose method to release resources.

Operator overloadability
A user-defined type can't overload the new operator.

**/
namespace NewOperator{
    class NewOperatorClass{
        public static void Main(){
            Console.WriteLine("New Operator !!!...");
            NewOperatorClass obj = new NewOperatorClass();
            int[] arrObj = new int[5];
            Dictionary<int,string> dicObj = new Dictionary<int,string>();
            dicObj[0] = "nickil";
            dicObj[1] = "Sanjana";
            dicObj[2] = "Navaneethan";
            foreach(var entry in dicObj){
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }

            //You can use an object or collection initializer with the new operator to instantiate and initialize an object in one statement
            Dictionary<string, int> dicObj2 = new Dictionary<string,int>{
                ["first"] = 10,
                ["second"] = 20
            };

            foreach(var entry in dicObj2){
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }

            //Target-typed new
            //Constructor invocation expressions are target-typed. 
            // That is, if a target type of an expression is known, you can omit a type name, as the following example shows:
            List<int> lsObj = new();
            lsObj.Add(1);
            lsObj.Add(23);
            Console.WriteLine(string.Join(",",lsObj));

            List<int> ys = new(capacity: 10_000);
            List<int> zs = new() { Capacity = 20_000 };

            Dictionary<int, List<int>> lookup = new()
            {
                [1] = new() { 1, 2, 3 },
                [2] = new() { 5, 8, 3 },
                [5] = new() { 1, 0, 4 }
            };


            //Array Creation
            //You also use the new operator to create an array instance, as the following example shows:
            var numbers = new int[3];
            numbers[0] = 10;
            numbers[1] = 20;
            numbers[2] = 30;
            Console.WriteLine(string.Join(", ", numbers));

            //Instantiation of anonymous types
            //To create an instance of an anonymous type, use the new operator and object initializer syntax:
            var example = new { Name = "Navaneethan", Age= 25};
            Console.WriteLine($"{example.Name}, {example.Age}!");
            Console.WriteLine(example.GetType());
        }
    }
}