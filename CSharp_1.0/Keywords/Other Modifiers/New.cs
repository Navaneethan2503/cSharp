using System;
/**
When used as a declaration modifier, the new keyword explicitly hides a member that is inherited from a base class. When you hide an inherited member, the derived version of the member replaces the base class version. This assumes that the base class version of the member is visible, as it would already be hidden if it were marked as private or, in some cases, internal. Although you can hide public or protected members without using the new modifier, you get a compiler warning. If you use new to explicitly hide a member, it suppresses this warning.

You can also use the new keyword to create an instance of a type or as a generic type constraint.

To hide an inherited member, declare it in the derived class by using the same member name, and modify it with the new keyword.

Name hiding through inheritance takes one of the following forms:

Generally, a constant, field, property, or type that is introduced in a class or struct hides all base class members that share its name. There are special cases. For example, if you declare a new field with name N to have a type that is not invocable, and a base type declares N to be a method, the new field does not hide the base declaration in invocation syntax. For more information, see the Member lookup section of the C# language specification.

A method introduced in a class or struct hides properties, fields, and types that share that name in the base class. It also hides all base class methods that have the same signature.

An indexer introduced in a class or struct hides all base class indexers that have the same signature.

It is an error to use both new and override on the same member, because the two modifiers have mutually exclusive meanings. The new modifier creates a new member with the same name and causes the original member to become hidden. The override modifier extends the implementation for an inherited member.

Using the new modifier in a declaration that does not hide an inherited member generates a warning.

Purpose
Hiding Members: The new modifier is used to hide an inherited member from a base class when you want to provide a new implementation or definition in the derived class.

Key Points
Hiding vs. Overriding: The new keyword hides the base class member, whereas the override keyword overrides it. Hiding does not replace the base class member; it simply hides it in the derived class.
Accessing Hidden Members: You can still access the hidden base class member using the base class reference.

When to Use
Avoiding Conflicts: Use the new keyword when you want to avoid conflicts with members in the base class and provide a new definition in the derived class.
Clarity: It makes your intention clear that you are hiding a member rather than overriding it.

General Rule
When you introduce a new member (constant, field, property, or type) in a class or struct that has the same name as a member in the base class, the new member hides the base class member. This is known as member hiding.

Special Case
However, there are special cases where the new member does not completely hide the base class member. One such case is when the new member is not invocable (e.g., a field) and the base class member is invocable (e.g., a method).

Key Points
Non-Invocable vs. Invocable: The new field in the derived class does not hide the base class method when using invocation syntax.
Member Hiding: The new member hides the base class member only in contexts where the new member is applicable. In this case, the field hides the method only when accessed as a field, not when invoked as a method.

Creating Instances
Purpose: The new keyword is used to create instances of types (classes, structs, arrays, etc.).
Syntax: You use the new keyword followed by the type name and parentheses to create an instance.

Key Points
Instance Creation: The new keyword is used to create instances of types.
Generic Constraints: The new() constraint ensures that a type argument has a parameterless constructor.
Flexibility: These uses of the new keyword provide flexibility in both object creation and generic programming.

Responsibilities of the new Keyword
Memory Allocation:

The new keyword allocates memory for the new object on the heap (for reference types) or on the stack (for value types).
Constructor Invocation:

It calls the constructor of the type to initialize the new object. If no constructor is explicitly defined, the default constructor is called.
Initialization:

The constructor initializes the object's fields and properties, setting them to their initial values.
Reference Assignment:

For reference types, the new keyword returns a reference to the newly created object, which can then be assigned to a variable.

Key Points
Heap vs. Stack: For reference types, memory is allocated on the heap. For value types (e.g., structs), memory is allocated on the stack.
Constructor: The constructor is responsible for initializing the object's state.
Reference: The new keyword returns a reference to the newly created object, which can be used to interact with the object.

If you remove the new modifier, the program will still compile and run, but you will get the following warning:

The keyword new is required on 'MyDerivedC.x' because it hides inherited member 'MyBaseC.x'

To Hide the base class member need to be same signature to hide.

**/
namespace NewNamespace{

    class Shape{

        public int _count = 10;

        public string color { get; set; } = "red";

        public class NestedClasss{
            public int x = 100;
        }

        public void Print(){
            Console.WriteLine("{0} Counts of Color :{1}",_count,color);
        }
    }

    class Circle : Shape{
        new public int _count = 100;
        string color { get; set;} = "Yellow";

        new public class NestedClasss{
            public int x = 999;
        }

        new public void Print(){
            Console.WriteLine("This is Circle : {0} Counts of Color :{1}",_count,color);
        }

    }
    public class NewClass{
        public static void Main(){
            Console.WriteLine("New Modifier");
            Circle c = new Circle();
            c.Print();
            Shape ex = (Shape)c;
            ex.Print();//output - 10 Counts of Color :red - new keyword not completely hided or replace like override it just hide and can access when needed.

            Shape.NestedClasss s = new Shape.NestedClasss();
            Console.WriteLine("Hided Nested base class still exists :"+ s.x);

            Shape s1 = new Shape();
            Console.WriteLine(s1.color);
        }
    }
}