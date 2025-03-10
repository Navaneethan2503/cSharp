using System;

/**
The sealed modifier in C# is used to prevent a class from being inherited or to prevent further overriding of a method or property in derived classes.
Sealed Classes
Definition: A sealed class cannot be used as a base class. No other class can inherit from a sealed class.
Purpose: It is used to prevent inheritance when it is not necessary or when it could lead to incorrect or unintended behavior.

Sealed Methods
Definition: A sealed method in a derived class prevents further overriding of that method in any further derived classes.
Purpose: It is used to lock down the implementation of a method to prevent it from being overridden again.

Key Points
Prevent Inheritance: The sealed keyword is used to prevent a class from being inherited or a method from being overridden.
Performance: Sealing a class or method can sometimes improve performance because the runtime does not need to check for further overrides.
Design Intent: It clearly communicates the design intent that a class or method should not be extended or modified further
Design Intent: What is the primary purpose of your class? If it is meant to be a flexible base class, avoid sealing it. If it is meant to provide a specific, unchangeable behavior, consider sealing it.


You can also use the sealed modifier on a method or property that overrides a virtual method or property in a base class. This enables you to allow classes to derive from your class and prevent them from overriding specific virtual methods or properties.

When you define new methods or properties in a class, you can prevent deriving classes from overriding them by not declaring them as virtual. When you override a virtual member declared in a base type, you can prevent deriving types from overriding them by using sealed keyword as in the following example:

public sealed override string ToString() => Value;

It is an error to use the abstract modifier with a sealed class, because an abstract class must be inherited by a class that provides an implementation of the abstract methods or properties.

When applied to a method or property, the sealed modifier must always be used with override.

Because structs are implicitly sealed, they cannot be inherited.

1. Potential Benefits of Customization
When deciding whether to seal a class, method, or property, consider the advantages that derived classes might gain by being able to customize your class. Here are some potential benefits:

Extensibility: Allowing inheritance can enable other developers to extend your class with additional functionality, making your class more versatile and reusable.
Customization: Derived classes can override methods to provide specific implementations that suit their needs, enhancing flexibility.
Code Reuse: Inheritance promotes code reuse, reducing redundancy and improving maintainability.
2. Potential Risks of Incorrect Modifications
On the other hand, consider the risks that derived classes might introduce by modifying your class in ways that could break its intended functionality:

Incorrect Behavior: Derived classes might override methods in a way that violates the original design or expected behavior, leading to bugs or unexpected results.
Security Risks: Allowing inheritance might expose internal details or create security vulnerabilities if not carefully managed.
Maintenance Challenges: If derived classes modify core behavior, it can become challenging to maintain and debug the code, especially if the modifications are not well-documented.

**/

namespace SealedNamespace{
    class A{
        public int n = 10;

        public virtual void Print(){
            Console.WriteLine("A");
        }

        public virtual void Print2(){
            Console.WriteLine("A 2");
        }
    }

    class B : A{

        public string Name { get; set; }
        sealed public override void Print()//Cannot be override again by derived class
        {
            Console.WriteLine("B");
        }
    }

    sealed class C : B{
        // public override void Print(){ -- Error cannot override
        //     Console.WriteLine("C");
        // }

        public override void Print2(){
            Console.WriteLine("C");
        }

    }

    // class D : C{ --Error not able to inherit

    // }
    class SealedClass{
        public static void Main(){
            Console.WriteLine("Sealed Modifier");
            C oneObj = new C();
            oneObj.Print();
            oneObj.Print2();
            B oneBobj = new B();
            oneBobj.Print();
            oneBobj.Print2();
            A oneAObj = new A();
            oneAObj.Print();
            oneAObj.Print2();
            A crossObj = new B();
            crossObj.Print();
            crossObj.n = 20;
        }
    }
}