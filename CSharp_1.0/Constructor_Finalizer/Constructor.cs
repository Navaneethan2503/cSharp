using System;
/**
A constructor is a method called by the runtime when an instance of a class or a struct is created. 
A class or struct can have multiple constructors that take different arguments. Constructors enable you to ensure that instances of the type are valid when created.

There are several actions that are part of initializing a new instance. 
The following actions take place in the following order:

1. Instance Fields Set to Default Values:
Action: The runtime initializes all instance fields to their default values (e.g., 0 for numeric types, null for reference types).
Example: If you have an int field, it is set to 0 before any other initialization.

2. Field Initializers Run:
Action: Field initializers in the most derived type run. These are the initial values you assign to fields directly in their declaration.
Example: private int counter = 10; sets counter to 10.

3. Base Type Field Initializers Run:
Action: Field initializers in base types run, starting from the direct base class up through each base type to System.Object.
Example: If your class inherits from another class, the field initializers in the base class run before those in your class.

4. Base Instance Constructors Run:
Action: Instance constructors in base classes run, starting from Object.Object through each base class to the direct base class.
Example: If your class inherits from another class, the constructors in the base class run before the constructor in your class.

5. Instance Constructor Runs::
Action: The constructor for the most derived type runs. This is the constructor you define in your class.
Example: public MyClass() { Constructor runs  } runs after all base class constructors.

6. Object Initializers Run:
Action: If the expression includes any object initializers, they run after the instance constructor. Object initializers set properties or fields in the order they appear in the code.
Example: new MyClass { Property1 = value1, Property2 = value2 }; sets Property1 and Property2 after the constructor runs.

The preceding actions take place when an instance is created using the new operator. If a new instance of a struct is set to its default value, all instance fields are set to 0. 
Elements of an array are set to their default value of 0 or null when an array is created.


Static Constructors:
A static constructor in C# is used to initialize static members of a class. It is called automatically before any instance of the class is created or any static members are accessed. Here are the key points:
1. Runs Before Instance Constructors: The static constructor runs before any instance constructor actions take place. This ensures that all static members are properly initialized before any instances of the class are created.
2. Runs Only Once: The static constructor is guaranteed to run only once, regardless of how many instances of the class are created. It runs the first time any static member of the class is accessed or the first time an instance of the class is created, whichever comes first.

Beginning with C# 14, you can declare instance constructors as partial members. Partial constructors must have both a declaring and implementing declaration.

Constructor syntax
A constructor is a method with the same name as its type. Its method signature can include an optional access modifier, the method name, and its parameter list; it doesn't include a return type. 

Primary constructor:
-----------------------
Primary constructor is a feature introduced in C# 9.0 that allows you to define constructor parameters directly in the class declaration. This makes it clear that certain parameters are required to create an instance of the clas
You can declare a primary constructor on a partial type. Only one primary constructor declaration is allowed. In other words, only one declaration of the partial type can include the parameters for the primary constructor.
If you write an explicit parameterless constructor, it must invoke the primary constructor. In that case, you can specify a different value for the primary constructor parameters.

Static Constructor:
--------------------
A class or struct can also declare a static constructor, which initializes static members of the type. Static constructors are parameterless. If you don't provide a static constructor to initialize static fields, the C# compiler initializes static fields to their default value.
You can also define a static constructor with an expression body definition,

Partial constructors:
Beginning with C# 14, you can declare partial constructors in a partial class or struct. Any partial constructor must have a defining declaration and an implementing declaration. The signatures of the declaring and implementing partial constructors must match according to the rules of partial members. The defining declaration of the partial constructor can't use the : base() or : this() constructor initializer. 
You add any constructor initializer must be added on the implementing declaration.

A constructor that takes no parameters is called a parameterless constructor. The runtime invokes the parameterless constructor when an object is instantiated using the new operator and no arguments are provided to new. C# 12 introduced primary constructors. A primary constructor specifies parameters that must be provided to initialize a new object. For more information, see Instance Constructors.

Unless the class is static, classes without constructors are given a public parameterless constructor by the C# compiler in order to enable class instantiation. 

Constructors for struct types resemble class constructors. 
When a struct type is instantiated with new, the runtime invokes a constructor. 
When a struct is set to its default value, the runtime initializes all memory in the struct to 0. 
If you declare any field initializers in a struct type, you must supply a parameterless constructor.


Constructors can be marked as public, private, protected, internal, protected internal or private protected. These access modifiers define how users of the class can construct the class. 

this Keyword in Constructor:
---------------------------
1. Constructor Chaining: You can use this to call another constructor in the same class. 
This is known as constructor chaining and helps to avoid code duplication by reusing constructor logic.

Parameterless constructors:
------------------------------
If a class has no explicit instance constructors, C# provides a parameterless constructor that you can use to instantiate an instance of that class.

That constructor initializes instance fields and properties according to the corresponding initializers. If a field or property has no initializer, its value is set to the default value of the field's or property's type. If you declare at least one instance constructor in a class, C# doesn't provide a parameterless constructor.

A structure type always provides a parameterless constructor. The parameterless constructor is either an implicit parameterless constructor that produces the default value of a type or an explicitly declared parameterless constructor. 

Primary Constructor Parameters in Classes and Structs:
Availability: Primary constructor parameters are available throughout the body of the class or struct. This means you can use them in methods, properties, and other members of the type.

Captured Private Field: If a primary constructor parameter is used beyond initializers and constructor calls (e.g., in methods or properties), the compiler captures it in a private field. This ensures the parameter's value is retained and accessible throughout the type.
No Private Field Capture: If the parameter is only used in initializers and constructor calls, it isn't captured in a private field. This optimization reduces memory usage.

Record Types and Primary Constructor Parameters
Public Properties: In record types, the compiler automatically generates public properties for primary constructor parameters. This makes the parameters accessible as properties of the record.

Private Constructor:
---------------------
A private constructor is a special instance constructor. It is generally used in classes that contain static members only. If a class has one or more private constructors and no public constructors, other classes (except nested classes) cannot create instances of this class.
The declaration of the empty constructor prevents the automatic generation of a parameterless constructor. Note that if you do not use an access modifier with the constructor it will still be private by default. However, the private modifier is usually used explicitly to make it clear that the class cannot be instantiated.
Private constructors are used to prevent creating instances of a class when there are no instance fields or methods, such as the Math class, or when a method is called to obtain an instance of a class. If all the methods in the class are static, consider making the complete class static.

**/
namespace Constructor{

    public class Person
    {
        private string last;
        private string first;

        //Chaining Constructor
        public Person() : this("","")
        {
            Console.WriteLine("parameter less Constructors:");
        }

        public Person(string lastName, string firstName)
        {
            last = lastName;
            first = firstName;
        }

        public void Print() => Console.WriteLine(this.first+","+this.last);
    }

    public class Adult : Person
    {
    private static int minimumAge;

    public Adult(string lastName, string firstName) : base(lastName, firstName)
    { }

    static Adult() => minimumAge = 18;

    // Remaining implementation of Adult class.
    }

    //If a constructor can be implemented as a single statement, you can use an expression body member. 
    //The following example defines a Location class whose constructor has a single string parameter, name. 
    //The expression body definition assigns the argument to the locationName field.
    public class Location
    {
    private string locationName;

    public Location(string name) => Name = name;

    public string Name
    {
        get => locationName;
        set => locationName = value;
    }
    }
    
    //You can prevent a class from being instantiated by making the constructor private,
    class NLog
    {
        // Private Constructor:
        private NLog() { }

        public static double e = Math.E;  //2.71828...
    }

    public class Employee
    {
        public int Salary;

        public Employee() { 
            Console.WriteLine("Employee Base Class Constructor ."); 
        }

        public Employee(int annualSalary) => Salary = annualSalary;

        public Employee(int weeklySalary, int numberOfWeeks) => Salary = weeklySalary * numberOfWeeks;
    }

    public class Manager : Employee
    {
        //A constructor can use the base keyword to call the constructor of a base class.
        public Manager(int annualSalary)
            : base(annualSalary)
        {
            //Add further instructions here.
        }
    }

    public class Intern: Employee{
        public Intern(int _) : base()
        {
            Console.WriteLine("Test Intern Constructor");
        }
    }

    class Coords
    {
        public Coords()
            : this(0, 0)
        {  }

        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => $"({X},{Y})";
    }

    // name isn't captured in Widget.
    // width, height, and depth are captured as private fields
    public class Widget(string name, int width, int height, int depth)
    {
        public Widget() : this("N/A", 1,1,1) {} // unnamed unit cube

        public int WidthInCM => width;
        public int HeightInCM => height;
        public int DepthInCM => depth;

        public int Volume => width * height * depth;

        public void Print() => Console.WriteLine(name);
    }


    class ConstructorClass{
        public static void Main(){
            Console.WriteLine("Constructor ...");
            Person p = new Person("nickil","S");
            Location l = new Location("Chennai");
            Console.WriteLine(l.Name);

            //private constructor
            //NLog nl = new NLog(); - error: constructor inaccessable
            
            //parameter less constructor
            //The following code uses the parameterless constructor for Int32, so that you're assured that the integer is initialized:
            int i = new int();
            Console.WriteLine(i);

            int a;
            //Console.WriteLine(a); - Error access of unassign local variable.

            //Multiple Constructors:
            Employee e = new Employee();
            Employee e1 = new Employee(30000);
            Employee e2 = new Employee(500, 52);
            Console.WriteLine(e.Salary+ " , "+ e1.Salary+ " , "+ e2.Salary);

            //calling base class constructor
            Manager m = new Manager(10000);
            Console.WriteLine("Base Class Cponstructor :"+m.Salary);
            
            Intern invObje = new Intern(10);
            Console.WriteLine("Intern Salary :"+invObje.Salary);

            //Chaining Constructor - this keyword
            Person p1 = new Person();
            p1.Print();

            var p2 = new Coords();

            Console.WriteLine($"Coords #1 at {p2}");
            // Output: Coords #1 at (0,0)

            var p3 = new Coords(5, 3);
            Console.WriteLine($"Coords #2 at {p3}");
            // Output: Coords #2 at (5,3)

            //Primary Constructor and Parameterless Constructor present but also invokes the Primary constructor.
            Widget w = new Widget("nic", 10,12,330);
        }
    }
}