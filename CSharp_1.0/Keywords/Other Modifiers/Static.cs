using System;
using AbstractNamespace;
/**
static modifier to declare a static member, which belongs to the type itself rather than to a specific object. 
The static modifier can be used to declare static classes. 
In classes, interfaces, and structs, you may add the static modifier to fields, methods, properties, operators, events, and constructors. 
The static modifier can't be used with indexers or finalizers.

You can add the static modifier to a local function. A static local function can't capture local variables or instance state.

You can add the static modifier to a lambda expression or anonymous method. A static lambda or anonymous method can't capture local variables or instance state.

A constant or type declaration is implicitly a static member. A static member can't be referenced through an instance. Instead, it's referenced through the type name.

While an instance of a class contains a separate copy of all instance fields of the class, there's only one copy of each static field.

It isn't possible to use this to reference static methods or property accessors.

If the static keyword is applied to a class, all the members of the class must be static.

Classes, interfaces, and static classes may have static constructors. A static constructor is called at some point between when the program starts and the class is instantiated.

Static Members
Definition: Static members are shared among all instances of a class. They are accessed using the class name rather than an instance of the class.
Types: You can declare fields, methods, properties, constructors, and events as static.
Static Fields
Shared Data: Static fields are used to store data that is shared among all instances of a class.
Initialization: They can be initialized at the point of declaration or in a static constructor.
Static Methods
Utility Functions: Static methods are often used for utility or helper functions that do not require access to instance data.
Access: They can only access other static members of the class.
Static Properties
Encapsulation: Static properties provide a way to encapsulate static fields.
Static Constructors
Initialization: Static constructors are used to initialize static fields or perform actions that need to be done only once.
Execution: They are called automatically before any static members are accessed or any instances are created.
Static Classes
Utility Classes: Static classes can only contain static members and cannot be instantiated.
Declaration: You declare a class as static using the static keyword.


Key Points
No Instances: Static members belong to the class itself and not to any specific instance.
Access: Static members are accessed using the class name, not an instance.
Restrictions: Static methods cannot access instance members directly.
Initialization: Static constructors are used to initialize static members and are called automatically
**/
namespace StaticNamespace{
    class Employee{
        public static int _count ;//Static field which is belongs to class itself , not for speficed object instance.

        public string _Name { get; set; }

        public int _Age { get; set; }

        static Employee(){
            _count = 1;
        }

        public Employee(string name, int age){
            _Name = name;
            _Age = age;
            _count++;
        }

        public static void PrintCount(){
            //Console.WriteLine("Static Members Cannot access instance state and local variable: "+ _Name);//Accessible only static members wthin static methods.
            Console.WriteLine("Total Employee Count is :"+ _count);
            //PrintDetails(); Cannot access the non static members in static member.
        }

        public void PrintDetails(){
            Console.WriteLine("Name is {0}, and Age is {1}", _Name,_Age);
        }



    }
    
    static class Example
    {
        public static int x = y;
        public static int y = 5;
        public static double PI = 3.14;//All members of static class is static members only

        public static void Print(){
            Console.WriteLine(PI+" PI Vlaue");
        }
    }
    class StaticClass{
        public static void Main(){
            Console.WriteLine("Static Method");
            Console.WriteLine("Count of Employee before Object Creation: "+ Employee._count);//static contractors are automatically called between accessing the static fields and creating the objects.
            Employee e1 = new Employee("Nickil", 20);
            Employee e2 = new Employee("Navaneethan", 22);
            Console.WriteLine(Employee._count);//Output - 2 becz only one copy is created when type of class is created object and use that same copy or share the copy with all instance or object.
            Employee.PrintCount();//access the static member using type , not the object instance.
            e1.PrintDetails();
            e2.PrintDetails();

            //Example e = new Example(); - cannot create instance of object.
            System.Console.WriteLine(Example.x);
            Console.WriteLine(Example.y);
            
        }
    }
}