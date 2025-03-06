using System;

namespace InterfaceType{
/**
An interface defines a contract. Any class, record or struct that implements that contract must provide an implementation of the members defined in the interface. 

An interface may define a default implementation for members. It may also define static members in order to provide a single implementation for common functionality.

Beginning with C# 11, an interface may define static abstract or static virtual members to declare that an implementing type must provide the declared members.

A top-level interface, one declared in a namespace but not nested inside another type, can be declared public or internal. 
The default is internal. Nested interface declarations, those declared inside another type, can be declared using any access modifier.

The name of an interface must be a valid C# identifier name. By convention, interface names begin with a capital I.


Declaration:
An interface is declared using the interface keyword.
It can contain method signatures, properties, events, and indexers, but no implementation.

Implementation:
A class or struct that implements an interface must provide an implementation for all its members.
The : interfaceName syntax is used to implement an interface.

Multiple Inheritance:
C# supports multiple interface inheritance, meaning a class or struct can implement multiple interfaces.

the default access modifier for all members of an interface is public.

Interface members without an implementation can't include an access modifier. 
Members with a default implementation can include any access modifier.

An interface can be a member of a namespace or a class. An interface declaration can contain declarations (signatures without any implementation) of the following members:
1.Methods
2.Properties
3.Indexers
4.Events

An interface may include:

Constants
Operators
Static constructor.
Nested types
Static fields, methods, properties, indexers, and events
Member declarations using the explicit interface implementation syntax.
Explicit access modifiers (the default access is public).

For Ref struct type even if we have default implementation also we need to explicity implement.

Static abstract and static virtual :
In C# 11 and .NET 7, interfaces can now include static abstract and static virtual members. 
This feature allows you to define interfaces that include static methods, properties, and operators, which implementing types must provide.
an interface may declare static abstract and static virtual members for all member types except fields

Static Abstract Members:
Static abstract members in an interface require implementing types to provide their own implementation of these static members. This is particularly useful for defining generic algorithms that rely on static methods or operators.

Static Virtual Members:
Static virtual members allow interfaces to provide a default implementation for static members. Implementing types can override these members if needed.

Static Method Dispatch
For static methods, including static abstract and static virtual methods in interfaces, the method dispatch is resolved at compile time based on the compile-time type of the expression. 
This means that the compiler determines which method to call based on the type of the variable as it is declared in the code, not the actual type of the object it refers to at runtime.
BaseClass baseObj = new DerivedClass();
baseObj.Display(); // Calls BaseClass.Display()

Interface Inheritance:
Interface inheritance in C# allows one interface to inherit from one or more other interfaces. This means that an interface can extend the functionality of another interface by inheriting its members.

Explicit Implementation:
1. Name confilict
2.Hiding Interface Members:- When you want to hide the implementation of an interface member from the class's public API, you can use explicit implementation. This makes the member accessible only through the interface.
3.Providing Different Implementations:- When a class needs to provide different implementations for interface members, explicit implementation allows you to define separate implementations for each interface.

Can We Create Instance of Interface?
No, you cannot create an instance of an interface directly in C#. 
Interfaces are abstract types, meaning they only define a contract (a set of methods, properties, events, or indexers) that implementing classes or structs must fulfill. 
Since interfaces do not provide any implementation, they cannot be instantiated.
Ex: IExample example = new ExampleClass(); // Correct way to use the interface
example.MethodA(); // Calls the implementation in ExampleClass

1. IExample example = new ExampleClass();
Variable Type: IExample (the interface type)
Object Type: ExampleClass (the implementing class)
Usage: The variable example is of type IExample, so you can only call methods and access properties defined in the IExample interface. This promotes polymorphism, allowing you to treat different implementations of IExample uniformly.
2. ExampleClass example = new ExampleClass();
Variable Type: ExampleClass (the concrete class type)
Object Type: ExampleClass (the same class)
Usage: The variable example is of type ExampleClass, so you can call all methods and access all properties defined in ExampleClass, including those not defined in the IExample interface.'



Benefits of Using Interfaces
Decoupling: Interfaces help in decoupling the code, making it more modular and easier to maintain.
Polymorphism: They enable polymorphic behavior, allowing different classes to be treated uniformly through a common interface.
Testability: Interfaces make it easier to write unit tests by allowing mock implementations.

Performance Benefits: 
Reduced Coupling: Interfaces help in reducing the coupling between different parts of the code. This makes the codebase more modular and easier to maintain, which can indirectly improve performance by simplifying optimizations and refactoring.
Polymorphism: Interfaces enable polymorphism, allowing different implementations to be used interchangeably. This can lead to more efficient code execution paths, as the most appropriate implementation can be selected at runtime.
Efficient Method Dispatch: Interfaces use virtual method tables (v-tables) for method dispatch, which is a well-optimized mechanism in modern runtime environments. This ensures that method calls through interfaces are efficient1.

Memory Benefits:
Lightweight Definitions:Interfaces are lightweight compared to classes because they do not contain any implementation details. This means they do not consume memory for method bodies or fields, only for the method signatures2.
Shared Implementations:By defining common behaviors through interfaces, multiple classes can share the same interface without duplicating code. This reduces memory usage by avoiding redundant implementations.
Garbage Collection: Interfaces, being reference types, benefit from the garbage collection mechanism in .NET. This helps in efficient memory management by automatically reclaiming memory used by objects that are no longer needed2.

Principle:
1. Single Responsibility Principle: Ensure that an interface has a single responsibility. It should define a specific set of related functionalities.
2. Cohesion: Group related methods together in an interface. High cohesion within an interface makes it easier to understand and implement.
3. Interface Segregation Principle (ISP): Clients should not be forced to depend on methods they do not use. This principle encourages creating smaller, more specific interfaces.

**/

    //Declaration of Interface
    interface IAnimal{//Default Integral and Members are Private
        public string AnimalName { get; set; }//Property

        //bool IsMammal; //Cannot contain Fields

        //Members with Access Modifier Other than Public need to define Default implementation in interface.
        private void PrivateInterfaceMethod(){
            Console.WriteLine("PrivateInterfaceMethod Woow");
        }
        void Sound(string soundName);//Method Signature
    }

    interface ISecond{

        static int secondNumber = 2;
        void PrintAnimalDetails();

        interface IThirdNested{
            void PrintAnimalSound();
        }

        void DefaultImplementation(){
            Console.WriteLine("Default implementation of Public Method Called");
        }
    }

    class DerivedClass : IAnimal, ISecond, ISecond.IThirdNested{
        //Members derived implemented from Interface should be public.
        public string AnimalName { get; set;}   

        public string SoundName { get; set;}

        public void Sound(string soundName) { 
            SoundName = soundName;
            Console.WriteLine("Sound For Mammals :" + SoundName);
        }

        public void PrintAnimalDetails() {
            Console.WriteLine("Animal Name :"+ AnimalName+ "\n Sound is :"+ SoundName);
        }

        public void PrintAnimalSound(){
            Console.WriteLine("{0} Sound Like {1}",AnimalName,SoundName);
        }

        public void PrivateInterfaceMethod(){
            Console.WriteLine("From DeriveClass PrivateInterfaceMethod:");
        }


    }
    
//Static abstract and static virtual - 
//Compile-Time Type: The type of a variable as declared in the code.
// Run-Time Type: The actual type of the object that the variable refers to at runtime.
// Static Method Dispatch: Resolved at compile time based on the compile-time type of the expression.
    interface IStaticExample{

        //static abstract must implemented in derive class and cannot declare a body in interface.
        static abstract void Print();
        static virtual void Display(){
            //static virtual must provide default implementation.
            Console.WriteLine("Display Method Interface static virtual");
        }
    }

    class BaseClass : IStaticExample{
        public static void Display(){
            Console.WriteLine("Baseclass Display method");
        }

        public static void Print(){
            Console.WriteLine("Baseclass class implementation for static abstart");
        }
    }
    class DerivedStaticInterface : BaseClass, IStaticExample{

        public static void Print(){
            Console.WriteLine("Derived class implementation for static abstart");
        }

        public static void Display(){
            //optional implementation
            Console.WriteLine("Display method in Derived class implementation");
        }
    }

    interface IAnimal1
{
    void Eat();
}

interface IMammal : IAnimal1
{
    void Walk();
}

interface IBird : IAnimal1
{
    void Fly();
}

interface IBat : IMammal, IBird
{
    void UseEcholocation(){
        Console.WriteLine("IBat UseEcholocation Called.");
    }
}

class Bat : IBat
{
    public void Eat()
    {
        Console.WriteLine("Bat is eating.");
    }

    public void Walk()
    {
        Console.WriteLine("Bat is walking.");
    }

    public void Fly()
    {
        Console.WriteLine("Bat is flying.");
    }

    public void UseEcholocation()
    {
        Console.WriteLine("Bat is using echolocation.");
    }
}

interface IExample
{
    void MethodA();
}

interface IExampleB{
    void MethodC(){
        Console.WriteLine("Method C interface");    
    }
}

class ExampleClass : IExample,IExampleB
{
    public void MethodA()
    {
        Console.WriteLine("Implementation of MethodA");
    }

    public void MethodB()
    {
        Console.WriteLine("Implementation of MethodB");
    }

    //Expilicit Implimentation
    // void IExampleB.MethodC(){
    //     Console.WriteLine("Method C From devire implementation");
    // }
}

interface IMotherBoard{
    void Good();

    void Bad(){
        Console.WriteLine("Bad From IMotherBoard");
    }

    static virtual void Ugly(){
        Console.WriteLine("Ugly From IMotherBoard");
    }

    void Print();

    static abstract void Display();
}

class Phone : IMotherBoard{

    void IMotherBoard.Print(){
        //Explicitly implementing from derived class.
        Console.WriteLine("Print from Phone");
    }

    public static void Display(){
        Console.WriteLine("Display from Phone");
    }

    public void Good(){
        Console.WriteLine("Good Called from Phone");
    }

    public void Brand(){
        Console.WriteLine("Brand from phone  ");
    }

    public static void Ugly(){
        Console.WriteLine("ugly from Phone");
    }

    
}
    class InterfaceClass{

        interface IClassInterface{//interface can contains within class also.
            void PrintMesage();
        }
        public static void Main(string[] args){
            Console.WriteLine("Interface Class :");

            DerivedClass d = new DerivedClass();
            d.AnimalName = "Dog";
            d.Sound("WOow woow!...");
            d.PrintAnimalDetails();
            d.PrintAnimalSound();
            //d.PrivateInterfaceMethod();//Till not defined in Derived Class so not accessable, since it is private
            d.PrivateInterfaceMethod();
            //To access the default implementation of MethodB, cast to IExample
            ISecond exp = d;
            exp.DefaultImplementation();
            Console.WriteLine("Static Field :"+ISecond.secondNumber);

            Console.WriteLine("Static abstract and static virtual :");
            BaseClass ds = new DerivedStaticInterface();
            BaseClass.Display();
            DerivedStaticInterface.Print();
            DerivedStaticInterface.Display();

            //Multiple inheritance
            Bat bat = new Bat();
            bat.Eat();
            bat.Walk();
            bat.Fly();
            bat.UseEcholocation();

            // Using the interface type
        IExample example1 = new ExampleClass();
        example1.MethodA(); // Allowed
        // example1.MethodB(); // Not allowed, MethodB is not part of IExample

        // Using the concrete class type
        ExampleClass example2 = new ExampleClass();
        example2.MethodA(); // Allowed
        example2.MethodB(); // Allowed

        IExampleB dds = new ExampleClass();
        dds.MethodC();  

        //IInterface variable vs Derived Class
        IMotherBoard m = new Phone();
        Phone p = new Phone();
        m.Good();
        //m.Brand();//Error Compile Time
        m.Bad();  
        //p.Bad();  //Complie Time error
        
        Phone.Ugly();
        //Only scope of implemented thing called.
        //static methods are resolved in compile time, where without static methods/instance methods resolved in runtime based on object reference.

        //Explicit Implimenting
        //p.Print();//Error - Not Defined
        m.Print();
        Phone.Display();
        //IMotherBoard.Display(); Error accessing interfacxe static.

        }
    }
}