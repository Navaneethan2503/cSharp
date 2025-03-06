using System;
using ClassType;
/**
A class is a data structure that may contain data members (constants and fields), function members (methods, properties, events, indexers, operators, instance constructors, finalizers, and static constructors), and nested types. 
A class is a blueprint for creating objects. It defines a type by encapsulating data and behavior.
A class in C# is like a blueprint for creating objects. It defines a type by bundling data (fields) and behavior (methods) into a single unit.
Class types support inheritance, a mechanism whereby a derived class can extend and specialize a base class.

the definition of a type—a class, struct, or record—is like a blueprint that specifies what the type can do. 

An object is basically a block of memory that has been allocated and configured according to the blueprint.

Encapsulation is sometimes referred to as the first pillar or principle of object-oriented programming. A class or struct can specify how accessible each of its members is to code outside of the class or struct. Methods and variables that aren't intended to be used from outside of the class or assembly can be hidden to limit the potential for coding errors or malicious exploits.

Classes are declared using the keyword class

Only single inheritance is allowed in C#. In other words, a class can inherit implementation from one base class only. However, a class can implement more than one interface.

Inheritance	Example
None	class ClassA { }
Single	class DerivedClass : BaseClass { }
None, implements two interfaces	class ImplClass : IFace1, IFace2 { }
Single, implements one interface	class ImplDerivedClass : BaseClass, IFace1 { }

Classes that you declare directly within a namespace, not nested within other classes, can be either public or internal. Classes are internal by default.

Class members, including nested classes, can be public, protected internal, protected, internal, private, or private protected. Members are private by default


why does we need Class ?
Which supports :
1. Encapsulation,
2. reusability
3. Abstraction
4. inheritance
5. polymorphism
6. modularity
7. Maintainability

Why Class Members of Value Types Are Not Stored on the Stack
Even though value types (like int, float, etc.) are typically stored on the stack when they are local variables, they are stored on the heap when they are members of a class. This is because the entire object instance, including its fields, must be stored in a single contiguous block of memory on the heap. Here’s why:

Object Integrity: Keeping all parts of an object together on the heap ensures that the object’s data is not fragmented, which simplifies memory management and access.
Garbage Collection: The garbage collector can efficiently manage the memory of objects if they are stored contiguously on the heap. If parts of an object were scattered between the stack and heap, it would complicate garbage collection.
Reference Types: Classes are reference types, and references to objects are stored on the stack. The actual object data, however, is stored on the heap. This allows the reference to be passed around while the object itself remains in a stable memory location.

Reference Type Variable: When you declare a variable of a reference type (like a class), the variable itself is stored on the stack. This variable holds a reference (or address) to the location of the object on the heap.

MyClass obj; // 'obj' is a reference variable stored on the stack
Object Creation: When you create an instance of the class using the new keyword, the object is allocated on the heap, and the reference variable on the stack is updated to point to this heap memory.

obj = new MyClass(); // The object is created on the heap, and 'obj' points to it

Why Use References?
Efficiency: Storing references on the stack is efficient because the stack is faster to access and manage.
Memory Management: The heap allows for dynamic memory allocation, which is necessary for objects that need to persist beyond the scope of a single method call.
Garbage Collection: The .NET runtime uses garbage collection to manage heap memory, automatically reclaiming memory that is no longer in use.

Stack:          Heap:
[obj] --------> [MyClass object]

Metadata of Objects in C#
Metadata in .NET is information about the types defined in your code, stored in a binary format within the assembly (like a .dll or .exe file). This metadata includes details about the assembly, types, members, and attributes. Here’s a breakdown of what metadata contains:

Assembly Information: Name, version, culture, and public key.
Type Information: Names, visibility, base classes, and implemented interfaces.
Member Information: Methods, fields, properties, events, and nested types.
Attributes: Additional descriptive elements that modify types and members.
This metadata is used by the .NET runtime to understand the structure and behavior of your code, enabling features like reflection, type safety, and interoperability between different .NET languages.

Memory Allocation:

Heap Allocation: Objects (instances of classes) are allocated on the heap. This allows for dynamic memory management and longer lifetimes.
Stack Allocation: Local variables and method call information are stored on the stack, which is faster but limited in size.
Class Size and Performance:

Large Classes: Having a large class (many lines of code or many members) does not inherently affect performance significantly. However, it can impact maintainability and readability3.
Memory Overhead: Each object instance on the heap has some overhead due to the metadata and the garbage collector's management. The actual size of an object includes the size of its fields plus some additional overhead for the object header.
Garbage Collection: The .NET garbage collector manages heap memory, reclaiming memory from objects that are no longer in use. Frequent allocations and deallocations can lead to performance overhead due to garbage collection cycles.
Performance Tips:

Use Structs for Small Data: For small, frequently used data structures, consider using structs instead of classes. Structs are value types and are allocated on the stack, which can be more efficient for small sizes4.
Avoid Unnecessary Allocations: Minimize unnecessary object allocations to reduce the load on the garbage collector.
Measure and Profile: Always measure and profile your application to identify memory bottlenecks and optimize accordingly5.

class can contain various types of members that define its data and behavior. Here’s a comprehensive list of what you can declare within a class:

1. Fields
Fields are variables that hold data for a class.

private int age;
public string name;
2. Properties
Properties provide a way to access and modify the fields of a class. They can include logic for getting and setting values.

public int Age
{
    get { return age; }
    set { age = value; }
}
3. Methods
Methods define the behavior of a class. They are functions that can perform actions and return values.

public void DisplayInfo()
{
    Console.WriteLine($"Name: {name}, Age: {age}");
}
4. Constructors
Constructors are special methods used to initialize objects. They have the same name as the class and no return type.

public MyClass(string name, int age)
{
    this.name = name;
    this.age = age;
}
5. Destructors
Destructors are used to clean up resources before an object is reclaimed by garbage collection. They have the same name as the class, preceded by a tilde (~).

~MyClass()
{
    // Cleanup code
}
6. Events
Events are used to provide notifications. They are based on delegates.

public event EventHandler MyEvent;
7. Indexers
Indexers allow instances of a class to be indexed like arrays.

private string[] names = new string[10];

public string this[int index]
{
    get { return names[index]; }
    set { names[index] = value; }
}
8. Nested Types
Classes can contain other types, such as nested classes, structs, enums, and interfaces.

public class OuterClass
{
    public class NestedClass
    {
        // Nested class members
    }

    public struct NestedStruct
    {
        // Nested struct members
    }

    public enum NestedEnum
    {
        // Nested enum members
    }

    public interface NestedInterface
    {
        // Nested interface members
    }
}
9. Static Members
Static members belong to the class itself rather than any object instance. They are accessed using the class name.

public static int InstanceCount { get; set; }
10. Operators
Classes can overload operators to define custom behavior for operations involving class instances.

public static MyClass operator +(MyClass a, MyClass b)
{
    return new MyClass(a.name + b.name, a.age + b.age);
}
11. Delegates
Delegates are type-safe function pointers that can be used to pass methods as arguments.

public delegate void MyDelegate(string message);

In C#, there are several ways to declare and initialize objects. Here are the most common methods:

1. Using Constructors
You can initialize an object by calling a constructor directly.

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

Person person1 = new Person("Alice", 30);
2. Using Object Initializers
Object initializers allow you to initialize an object without explicitly calling a constructor.

Person person2 = new Person { Name = "Bob", Age = 25 };
3. Using Collection Initializers
You can initialize collections using collection initializers.

List<Person> people = new List<Person>
{
    new Person { Name = "Charlie", Age = 35 },
    new Person { Name = "Diana", Age = 28 }
};
4. Using Anonymous Types
Anonymous types are useful for creating objects without defining a class.

var person3 = new { Name = "Eve", Age = 22 };
5. Using Arrays
You can declare and initialize arrays of objects.

Person[] peopleArray = new Person[]
{
    new Person("Frank", 40),
    new Person("Grace", 32)
};
6. Using Default Constructor
If a class has a parameterless constructor, you can use it to create an object.

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
}

Car car1 = new Car();
car1.Make = "Toyota";
car1.Model = "Corolla";
7. Using Static Methods
Sometimes, static methods are used to initialize objects, especially in factory patterns.

public class Factory
{
    public static Person CreatePerson(string name, int age)
    {
        return new Person(name, age);
    }
}

Person person4 = Factory.CreatePerson("Hank", 45);
8. Using Activator.CreateInstance
You can use reflection to create an instance of a type.

Type personType = typeof(Person);
Person person5 = (Person)Activator.CreateInstance(personType, "Ivy", 29);

The new keyword in C# is used to create instances of types, such as classes, structs, arrays, and anonymous types. When you use the new keyword, several important actions take place:

Core Details of the new Keyword
Memory Allocation:

The new keyword allocates memory on the heap for the new object. This memory allocation is necessary to store the object's data and metadata.
Constructor Invocation:

After allocating memory, the new keyword calls the constructor of the class to initialize the object. The constructor sets up the initial state of the object by assigning values to its fields and properties.
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

Person person = new Person("Alice", 30); // Memory allocation and constructor call
Reference Creation:

The new keyword returns a reference to the newly created object. This reference is stored in a variable, which can then be used to access the object's members.
Person person = new Person("Alice", 30); // 'person' holds the reference to the new object
Object Initialization:

You can use object initializers to set properties or fields at the time of object creation, providing a concise way to initialize objects.
Person person = new Person { Name = "Bob", Age = 25 }; // Object initializer
Array Creation:

The new keyword is also used to create arrays, allocating memory for the array elements and initializing them.
int[] numbers = new int[3] { 1, 2, 3 }; // Array creation and initialization
Anonymous Types:

The new keyword can be used to create instances of anonymous types, which are useful for encapsulating a set of read-only properties into a single object.
var person = new { Name = "Eve", Age = 22 }; // Anonymous type

Once you set an object reference to null in C#, you effectively lose the reference to that object. The object itself remains in memory until the garbage collector reclaims it, but you cannot directly reclaim or restore the reference to that object.

there are several types of classes, each serving different purposes and providing various functionalities. Here’s a comprehensive list of the different types of classes:

1. Concrete Class
A concrete class is a regular class that can be instantiated. It can contain fields, properties, methods, and events.

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
2. Abstract Class
An abstract class cannot be instantiated and is used as a base class. It can contain abstract methods that must be implemented by derived classes.

public abstract class Animal
{
    public abstract void MakeSound();
}
3. Static Class
A static class cannot be instantiated and can only contain static members. It is used to group related static methods and properties.

public static class MathUtilities
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}
4. Sealed Class
A sealed class cannot be inherited. It is used to prevent other classes from deriving from it.

public sealed class FinalClass
{
    public void Display()
    {
        Console.WriteLine("This is a sealed class.");
    }
}
5. Partial Class
A partial class allows its definition to be split across multiple files. This is useful for organizing large classes and working with auto-generated code.

// File1.cs
public partial class PartialClass
{
    public void Method1()
    {
        Console.WriteLine("Method1");
    }
}

// File2.cs
public partial class PartialClass
{
    public void Method2()
    {
        Console.WriteLine("Method2");
    }
}
6. Nested Class
A nested class is a class defined within another class. It is used to logically group classes that are only used in one place.

public class OuterClass
{
    public class NestedClass
    {
        public void Display()
        {
            Console.WriteLine("This is a nested class.");
        }
    }
}
7. Generic Class
A generic class allows you to define a class with a placeholder for the type of data it stores or uses. This promotes type safety and code reuse.

public class GenericClass<T>
{
    private T data;

    public GenericClass(T value)
    {
        data = value;
    }

    public T GetData()
    {
        return data;
    }
}
8. Anonymous Class
An anonymous class is a class without a name, typically used for encapsulating a set of read-only properties into a single object.

var person = new { Name = "Alice", Age = 30 };
9. Record Class
Introduced in C# 9.0, a record class is a reference type that provides built-in functionality for value equality, immutability, and concise syntax for defining data objects.

public record Person(string Name, int Age);


**/
namespace ClassType{


    //regular class - by default internal
    class ConcreteClass{
        string name = "";//all members of class private by default.
        int age = 0;
    }

    class Child{
        string Name ;//Field

        public int Age { get; set; } //Property

        public Child(string n, int a){////Constructor
            Name = n;
            Age = a;
        }
        public void DispalyName(){//Method
            Console.WriteLine("Name of Child Is :"+ Name);
        }
        
    }

    public class ClassType{

        static int age = 0;
        public static void Main(){//We cannot access the private member of ClassType from Main Method even it is within same class members, only private members.
            System.Console.WriteLine("Class Type :");
            Console.WriteLine("ClassType Age :"+ age);
            Child c1 = new Child("nickil", 25);
            Child c2 = new Child("navaneethan",60);
            Console.WriteLine("c1 :"+c1.Age+ " - c2 :" + c2.Age);
            c1.DispalyName();
            c2.DispalyName();

            //Class is reference Type is stores a reference so if we change the value in reference it will effect the original data in heap memory.
            Child c3 = c1;
            c3.Age = 30;//8973455913
            Console.WriteLine("Age of c1 : "+ c1.Age + " - Age of c3 is :"+ c3.Age);
            Console.WriteLine("check the reference of the objects :"+Child.ReferenceEquals(c1,c3));
            Console.WriteLine(c3.ToString());
            Console.WriteLine("GetType :"+ c3.GetType());

        }
    }
}