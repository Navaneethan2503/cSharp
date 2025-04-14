using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
/**
Developers use generics all the time in .NET, whether implicitly or explicitly.

First introduced in .NET Framework 2.0, generics are essentially a "code template" that allows developers to define type-safe data structures without committing to an actual data type.

Generics in C# are a powerful feature that allows you to define classes, methods, and data structures with a placeholder for the type of data they store or use.
These placeholders are known as type parameters.

To understand why generics are useful, let's take a look at a specific class before and after adding generics: ArrayList. In .NET Framework 1.0, the ArrayList elements were of type Object. Any element added to the collection was silently converted into an Object. 
The same would happen when reading elements from the list. This process is known as boxing and unboxing, and it impacts performance. Aside from performance, however, there's no way to determine the type of data in the list at compile time, which makes for some fragile code. 
Generics solve this problem by defining the type of data each instance of list will contain. For example, you can only add integers to List<int> and only add Persons to List<Person>.

A generic class, such as GenericList<T> listed in Introduction to Generics, cannot be used as-is because it is not really a type; it is more like a blueprint for a type.

Generics are also available at run time. The runtime knows what type of data structure you're using and can store it in memory more efficiently.

    Type Safety and Efficiency:
        1.Type Safety:
        At runtime, the CLR ensures that the type constraints and type parameters are respected. This means that you cannot accidentally use an incorrect type, which helps prevent runtime errors.
        2.Memory Efficiency:
        No Boxing/Unboxing: For value types, generics eliminate the need for boxing and unboxing. Boxing is the process of converting a value type to an object type, and unboxing is the reverse. These operations can be costly in terms of performance. With generics, value types are used directly without boxing, leading to more efficient memory usage.
        Optimized Storage: The CLR can optimize the storage of generic types. For example, a List<int> will store integers directly in the list, rather than as objects, which reduces memory overhead.

1. Definition and Syntax
Generics are defined using angle brackets (<>). For example, a generic class might look like this:
    public class GenericClass<T>
    {
    private T data;
    }

2. Benefits of Generics
Type Safety: Generics ensure that you can only use the specified type, reducing runtime errors.
Performance: Generics can improve performance by eliminating the need for boxing and unboxing when working with value types.
Code Reusability: You can create a single class or method that works with any data type, making your code more reusable and easier to maintain.

3. Generic Methods
You can also define generic methods within non-generic classes.

4. Constraints
Generics can have constraints to specify the requirements for the types that can be used. For example:
    public class GenericClass<T> where T : IComparable
    {
        // T must implement IComparable
    }

5. Common Uses
Collections: The .NET framework provides several generic collection classes, such as List<T>, Dictionary<TKey, TValue>, and Queue<T>.
Delegates and Events: Generics can be used with delegates and events to create type-safe event handling mechanisms.


Generic Identifier :
you can use any valid identifier as the type parameter in generics. The letters G, H, F, or any other valid identifier can be used. Here are a few examples:
public class GenericClass<G>
public class AnotherGenericClass<H>
public class YetAnotherGenericClass<F>

When you create an instance of a generic class, you specify the actual types to substitute for the type parameters. 
This establishes a new generic class, referred to as a constructed generic class, with your chosen types substituted everywhere that the type parameters appear. 
The result is a type-safe class that is tailored to your choice of types.

Nested types and generics:
A type that is nested in a generic type can depend on the type parameters of the enclosing generic type. 
The common language runtime considers nested types to be generic, even if they do not have generic type parameters of their own. When you create an instance of a nested type, you must specify type arguments for all enclosing generic types.


Generic Terminalogy:
---------------------
1. A generic type definition is a class, structure, or interface declaration that functions as a template, with placeholders for the types that it can contain or use. 
2. Generic type parameters, or type parameters, are the placeholders in a generic type or method definition. The System.Collections.Generic.Dictionary<TKey,TValue> generic type has two type parameters, TKey and TValue, that represent the types of its keys and values.
3. A constructed generic type, or constructed type, is the result of specifying types for the generic type parameters of a generic type definition. 
   A constructed generic type is a generic type that has been instantiated with specific type arguments. When you create an instance of a generic type and specify the actual types to use, you are constructing the generic type. This process replaces the type parameters with the specified type arguments.
4. A generic type argument is any type that is substituted for a generic type parameter.
5. The general term generic type includes both constructed types and generic type definitions.
6. Covariance and contravariance of generic type parameters enable you to use constructed generic types whose type arguments are more derived (covariance) or less derived (contravariance) than a target constructed type. Covariance and contravariance are collectively referred to as variance.
7. Constraints are limits placed on generic type parameters. For example, you might limit a type parameter to types that implement the System.Collections.Generic.IComparer<T> generic interface, to ensure that instances of the type can be ordered. 
   You can also constrain type parameters to types that have a particular base class, that have a parameterless constructor, or that are reference types or value types. Users of the generic type cannot substitute type arguments that do not satisfy the constraints.
8. A generic method definition is a method with two parameter lists: a list of generic type parameters and a list of formal parameters. Type parameters can appear as the return type or as the types of the formal parameters
9. Generic methods can appear on generic or nongeneric types. It's important to note that a method is not generic just because it belongs to a generic type, or even because it has formal parameters whose types are the generic parameters of the enclosing type. 


Advantages :
    1.Type safety. Generics shift the burden of type safety from you to the compiler. There is no need to write code to test for the correct data type because it is enforced at compile time. The need for type casting and the possibility of run-time errors are reduced.
    2.Less code and code is more easily reused. There is no need to inherit from a base type and override members. For example, the LinkedList<T> is ready for immediate use. For example, you can create a linked list of strings with the following variable declaration:
    3.Better performance. Generic collection types generally perform better for storing and manipulating value types because there is no need to box the value types.
    4.Generic delegates enable type-safe callbacks without the need to create multiple delegate classes. For example, the Predicate<T> generic delegate allows you to create a method that implements your own search criteria for a particular type and to use your method with methods of the Array type such as Find, FindLast, and FindAll.
    5.Generics streamline dynamically generated code. When you use generics with dynamically generated code you do not need to generate the type. This increases the number of scenarios in which you can use lightweight dynamic methods instead of generating entire assemblies.

Disadvantages (Limitations):
    1. Base Classes and Constraints
        Base Classes: In .NET, you can create generic types that inherit from most base classes. For example, you can have a generic class that inherits from MarshalByRefObject.
        Constraints: You can also use constraints to ensure that the type parameters for your generic types derive from specific base classes like MarshalByRefObject.
    2. Context-Bound Generic Types
        Context-Bound Classes: ContextBoundObject is a special base class in .NET used for context-bound objects, which are objects that need to be executed in a specific context, such as for remoting or synchronization.
        Limitation: .NET does not support creating generic types that are context-bound. This means you can't create a generic type that works with ContextBoundObject in the same way you can with other base classes.
    3. Enumerations cannot have generic type parameters. An enumeration can be generic only incidentally (for example, because it is nested in a generic type that is defined using Visual Basic, C#, or C++)
    4. Lightweight dynamic methods cannot be generic.
    5.  a nested type that is enclosed in a generic type cannot be instantiated unless types have been assigned to the type parameters of all enclosing types. Another way of saying this is that in reflection, a nested type that is defined using these languages includes the type parameters of all its enclosing types. 
        This allows the type parameters of enclosing types to be used in the member definitions of a nested type.

        A nested type that is defined by emitting code in a dynamic assembly or by using the Ilasm.exe (IL Assembler) is not required to include the type parameters of its enclosing types; however, if it does not include them, the type parameters are not in scope in the nested class.



Class library and language support:
---------------------------------------------
.NET provides a number of generic collection classes in the following namespaces:

    1.The System.Collections.Generic namespace contains most of the generic collection types provided by .NET, such as the List<T> and Dictionary<TKey,TValue> generic classes.

    2.The System.Collections.ObjectModel namespace contains additional generic collection types, such as the ReadOnlyCollection<T> generic class, that are useful for exposing object models to users of your classes.

Generic interfaces for implementing sort and equality comparisons are provided in the System namespace, along with generic delegate types for event handlers, conversions, and search predicates.

The System.Numerics namespace provides generic interfaces for mathematical functionality (available in .NET 7 and later versions). For more information, see Generic math.

Support for generics has been added to the System.Reflection namespace for examining generic types and generic methods, to System.Reflection.Emit for emitting dynamic assemblies that contain generic types and methods, and to System.CodeDom for generating source graphs that include generics.

The common language runtime provides new opcodes and prefixes to support generic types in common intermediate language (CIL), including Stelem, Ldelem, Unbox_Any, Constrained, and Readonly.

Generics in Runtime:
--------------------
When a generic type or method is compiled into common intermediate language (CIL), it contains metadata that identifies it as having type parameters. How the CIL for a generic type is used differs based on whether the supplied type parameter is a value type or reference type.

When a generic type is first constructed with a value type as a parameter, the runtime creates a specialized generic type with the supplied parameter or parameters substituted in the appropriate locations in the CIL. Specialized generic types are created one time for each unique value type that is used as a parameter.
At this point, the runtime generates a specialized version of the Stack<T> class that has the integer substituted appropriately for its parameter. Now, whenever your program code uses a stack of integers, the runtime reuses the generated specialized Stack<T> class. In the following example, two instances of a stack of integers are created, and they share a single instance of the Stack<int> code:
Stack<int> stackOne = new Stack<int>();
Stack<int> stackTwo = new Stack<int>();
However, suppose that another Stack<T> class with a different value type such as a long or a user-defined structure as its parameter is created at another point in your code. As a result, the runtime generates another version of the generic type and substitutes a long in the appropriate locations in CIL. Conversions are no longer necessary because each specialized generic class natively contains the value type.
Generics work somewhat differently for reference types. The first time a generic type is constructed with any reference type, the runtime creates a specialized generic type with object references substituted for the parameters in the CIL. Then, every time that a constructed type is instantiated with a reference type as its parameter, regardless of what type it is, the runtime reuses the previously created specialized version of the generic type. This is possible because all references are the same size.
At this point, the runtime generates a specialized version of the Stack<T> class that stores object references that will be filled in later instead of storing data.
Unlike with value types, another specialized version of the Stack<T> class is not created for the Order type. Instead, an instance of the specialized version of the Stack<T> class is created and the orders variable is set to reference it.
As with the previous use of the Stack<T> class created by using the Order type, another instance of the specialized Stack<T> class is created. The pointers that are contained therein are set to reference an area of memory the size of a Customer type. Because the number of reference types can vary wildly from program to program, the C# implementation of generics greatly reduces the amount of code by reducing to one the number of specialized classes created by the compiler for generic classes of reference types.

Moreover, when a generic C# class is instantiated by using a value type or reference type parameter, reflection can query it at run time and both its actual type and its type parameter can be ascertained.
**/
namespace Generics{

    //Generic Class define Generic parameter type placeholder.
    class GenericClass<T>{
        private T Data;

        public GenericClass(T d){
            Data = d;
        }

        public T GetData(){
            return Data;
        }

    }

    class BaseNode { }
    class BaseNodeGeneric<T> { }

    // concrete type
    class NodeConcrete<T> : BaseNode { }

    //closed constructed type
    class NodeClosed<T> : BaseNodeGeneric<int> { }

    //open constructed type
    class NodeOpen<T> : BaseNodeGeneric<T> { }

    //Non-generic, in other words, concrete, classes can inherit from closed constructed base classes, but not from open constructed classes or from type parameters because there is no way at run time for client code to supply the type argument required to instantiate the base class.
    //No error
    class Node1 : BaseNodeGeneric<int> { }

    //Generates an error
    //class Node2 : BaseNodeGeneric<T> {}

    //Generates an error
    //class Node3 : T {}

    //Generic classes that inherit from open constructed types must supply type arguments for any base class type parameters that are not shared by the inheriting class
    class BaseNodeMultiple<T, U> { }

    //No error
    class Node4<T> : BaseNodeMultiple<T, int> { }

    //No error
    class Node5<T, U> : BaseNodeMultiple<T, U> { }

    //Generates an error
    //class Node6<T> : BaseNodeMultiple<T, U> {}

    //Generic classes that inherit from open constructed types must specify constraints that are a superset of, or imply, the constraints on the base type
    class NodeItem<T> where T : System.IComparable<T>, new() { }
    class SpecialNodeItem<T> : NodeItem<T> where T : System.IComparable<T>, new() { }

    
    //Generic types can use multiple type parameters and constraints
    class SuperKeyType<K, V, U>
    where U : System.IComparable<U>
    where V : new()
    { }

    //Open constructed and closed constructed types can be used as method parameters
    class Test{
        void Swap<T>(List<T> list1, List<T> list2)
        {
            //code to swap items
        }

        void Swap(List<int> list1, List<int> list2)
        {
            //code to swap items
        }
    }

    //Generic Method
    //A generic method uses type parameters as placeholders for the types of its parameters or return value.
    class GenericMethodClass{
        public T Display<T>(T data){
            Console.WriteLine("Display is :"+ data );
            return data;
        }
    }

    //Generic Interface
    //A generic interface defines a contract with type parameters.
    public interface IGenericInterface<T>
    {
        T GetData();
        void SetData(T value);
    }

    

    //Generic Structure
    //A generic structure can also use type parameters.
    public struct GenericStruct<T>
    {
        public T Value { get; set; }

        public GenericStruct(T value)
        {
            Value = value;
        }
    }




    class Generics{

        public static void Main(){
            Console.WriteLine("Generics...");

            //Generic Class
            GenericClass<int> gC = new GenericClass<int>(5);
            Console.WriteLine("gc - Data is: "+ gC.GetData());

            GenericClass<string> gC1 = new GenericClass<string>("Navaneethan");
            Console.WriteLine("gc1 - Data is: "+ gC1.GetData());

            //Generic Method
            GenericMethodClass gm = new GenericMethodClass();
            Console.WriteLine("Returned :"+ gm.Display<int>(100));
            Console.WriteLine("Returned :"+ gm.Display<string>("nickil"));


            //Comparing the Performace between Generic List and ArrayList
            //generic list
            //List<int> ListGeneric = new List<int> { 5, 9, 1, 4 };
            //non-generic list
            ArrayList ListNonGeneric = new ArrayList { 5, 9, 1, 4 };
            // timer for generic list sort
            Stopwatch s = Stopwatch.StartNew();
            //ListGeneric.Sort();
            s.Stop();
            //Console.WriteLine($"Generic Sort: {ListGeneric}  \n Time taken: {s.Elapsed.TotalMilliseconds}ms");

            //timer for non-generic list sort
            Stopwatch s2 = Stopwatch.StartNew();
            ListNonGeneric.Sort();
            s2.Stop();
            Console.WriteLine($"Non-Generic Sort: {ListNonGeneric}  \n Time taken: {s2.Elapsed.TotalMilliseconds}ms");
            //Console.ReadLine();
            //The first thing you can notice here is that sorting the generic list is significantly faster than sorting the non-generic list. 
            //You might also notice that the type for the generic list is distinct ([System.Int32]), whereas the type for the non-generic list is generalized. Because the runtime knows the generic List<int> is of type Int32, it can store the list elements in an underlying integer array in memory, while the non-generic ArrayList has to cast each list element to an object. 
            //As this example shows, the extra casts take up time and slow down the list sort.
            //An additional advantage of the runtime knowing the type of your generic is a better debugging experience. When you're debugging a generic in C#, you know what type each element is in your data structure. Without generics, you would have no idea what type each element was.

        }
    }
}