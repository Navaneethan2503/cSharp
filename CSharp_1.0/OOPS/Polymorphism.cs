using System;
/**
Polymorphism is often referred to as the third pillar of object-oriented programming, after encapsulation and inheritance.
Polymorphism is a core concept in Object-Oriented Programming (OOP) that allows objects to be treated as instances of their parent class rather than their actual class. 
This enables a single interface to represent different underlying forms (data types). 
In C#, polymorphism can be achieved through method overriding, method overloading, and interfaces.

There are two types of polymorphism in C#. They are as follows:
Static Polymorphism / Compile-Time Polymorphism / Early Binding
Dynamic Polymorphism / Run-Time Polymorphism / Late Binding

Polymorphism is a Greek word that means "many-shaped" and it has two distinct aspects:
1.At run time, objects of a derived class may be treated as objects of a base class in places such as method parameters and collections or arrays. When this polymorphism occurs, the object's declared type is no longer identical to its run-time type.
2.Base classes may define and implement virtual methods, and derived classes can override them, which means they provide their own definition and implementation. At run-time, when client code calls the method, the CLR looks up the run-time type of the object, and invokes that override of the virtual method. In your source code you can call a method on a base class, and cause a derived class's version of the method to be executed.

1.Method Overriding (Runtime Polymorphism)
Definition: Allows a derived class to provide a specific implementation of a method that is already defined in its base class.
Virtual Methods: Methods in the base class that can be overridden in derived classes. Declared using the virtual keyword.
Override Methods: Methods in the derived class that override the base class methods. Declared using the override keyword.

2. Method Overloading (Compile-Time Polymorphism)
Definition: Allows multiple methods in the same class to have the same name but different parameters (different type, number, or both).
3. Interfaces and Polymorphism
Definition: Interfaces define a contract that implementing classes must follow. They enable polymorphism by allowing objects to be treated as instances of the interface rather than their actual class.
3. Interfaces and Polymorphism
Definition: Interfaces define a contract that implementing classes must follow. They enable polymorphism by allowing objects to be treated as instances of the interface rather than their actual class.
eg: IShape shape = new Circle(5);
4. Abstract Classes and Polymorphism
Definition: Abstract classes can have abstract methods that must be implemented by derived classes. This allows for polymorphic behavior.
5. Polymorphism with Collections
Polymorphism is often used with collections to store objects of different types that share a common base class or interface.
Eg: List<Animal> animals = new List<Animal>
        {
            new Dog(),
            new Cat()
        };

6. Polymorphism and Design Patterns
Polymorphism is a key principle in many design patterns, such as Strategy, Factory, and Observer patterns.
Example (Strategy Pattern)

Explanation:
Base Class: Animal defines a virtual method MakeSound.
Derived Classes: Dog and Cat override the MakeSound method.
Polymorphism: At runtime, the CLR determines the actual type of the object and calls the appropriate overridden method.
Collections: The list animals contains objects of the base class type Animal, but at runtime, the actual types (Dog and Cat) are used to invoke the correct method.

Key Points:
Declared Type vs. Runtime Type: The declared type of the object is Animal, but the runtime type can be Dog or Cat.
Virtual Methods: The base class defines virtual methods that can be overridden by derived classes.
Method Overriding: Derived classes provide their own implementation of the virtual methods.
CLR Method Lookup: At runtime, the CLR looks up the actual type of the object and invokes the overridden method.

Virtual members
When a derived class inherits from a base class, it includes all the members of the base class. All the behavior declared in the base class is part of the derived class. That enables objects of the derived class to be treated as objects of the base class. Access modifiers (public, protected, private and so on) determine if those members are accessible from the derived class implementation. Virtual methods gives the designer different choices for the behavior of the derived class:

The derived class may override virtual members in the base class, defining new behavior.
The derived class may inherit the closest base class method without overriding it, preserving the existing behavior but enabling further derived classes to override the method.
The derived class may define new non-virtual implementation of those members that hide the base class implementations.
A derived class can override a base class member only if the base class member is declared as virtual or abstract. The derived member must use the override keyword to explicitly indicate that the method is intended to participate in virtual invocation.

Fields can't be virtual; only methods, properties, events, and indexers can be virtual. 
When a derived class overrides a virtual member, that member is called even when an instance of that class is being accessed as an instance of the base class. 

Hide base class members with new members
If you want your derived class to have a member with the same name as a member in a base class, you can use the new keyword to hide the base class member. The new keyword is put before the return type of a class member that is being replaced.
Hidden base class members may be accessed from client code by casting the instance of the derived class to an instance of the base class. 


**/
namespace Polymorphism{
    
    //Mthod Overriding - Run Time Polymorphism
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Some sound");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Bark");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }

        public void Print(){
            Console.WriteLine("Print");
        }
    }

    //Hiding the Method without new keyword but for compile confusion need new to hide base class implementation.
    class ExampleHideBaseClassMethod : Cat{
        public void Print(){
            Console.WriteLine("ExampleHideBaseClassMethod");
        }
    }

    class ExampleHideBaseMethodWithNew : Cat{
        public new void Print(){
            Console.WriteLine("ExampleHideBaseMethodWithNew");
        }
    }

    //Method OverLoading - Compile Time Polymorphism
    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
    }
    class Polymorphism{
        public static void Main(){
            Console.WriteLine("Polymorphism :");

            Console.WriteLine("Method Overrding :");
            Animal myAnimal = new Dog();
            myAnimal.MakeSound(); // Output: Bark

            myAnimal = new Cat();
            myAnimal.MakeSound(); // Output: Meow

            Dog d = new Dog();
            d.MakeSound();
            Cat c = new Cat();
            c.MakeSound();

            Console.WriteLine("Method Overloading");
            MathOperations math = new MathOperations();
            Console.WriteLine(math.Add(2, 3));       // Output: 5
            Console.WriteLine(math.Add(2.5, 3.5));   // Output: 6.0
            Console.WriteLine(math.Add(1, 2, 3));    // Output: 6

            Console.WriteLine("Hiding the implementation of Base Class without new");
            //Hiding the base class implementation at runtime - without new
            ExampleHideBaseClassMethod e = new ExampleHideBaseClassMethod();
            e.Print();
            Cat e1 = e;
            e1.Print();

            Console.WriteLine("Hiding the implementation of Base Class with new");
            //Hide base method with new keyword
            ExampleHideBaseMethodWithNew n = new ExampleHideBaseMethodWithNew();
            n.Print();
            Cat n1 = (Cat)n;
            n1.Print();


        }
    }
}