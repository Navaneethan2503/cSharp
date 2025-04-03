using System;
/**
A static constructor is used to initialize any static data, or to perform a particular action that needs to be performed only once. 
It's called automatically before the first instance is created or any static members are referenced. 
A static constructor is called at most once.

There are several actions that are part of static initialization. Those actions take place in the following order:
1. Static fields are set to 0. The runtime typically does this initialization.
2. Static field initializers run. The static field initializers in the most derived type run.
3. Base type static field initializers run. Static field initializers starting with the direct base through each base type to System.Object.
4. Any static constructor runs. Any static constructors, from the ultimate base class of Object.Object through each base class through the type run. The order of static constructor execution isn't specified. However, all static constructors in the hierarchy run before any instances are created.

Remarks
Static constructors have the following properties:

1. A static constructor doesn't take access modifiers or have parameters.
2. A class or struct can only have one static constructor.
3. Static constructors can't be inherited or overloaded.
4. A static constructor can't be called directly and is only meant to be called by the common language runtime (CLR). It's invoked automatically.
5.The user has no control on when the static constructor is executed in the program.
6. A static constructor is called automatically. It initializes the class before the first instance is created or any static members declared in that class (not its base classes) are referenced. A static constructor runs before an instance constructor. If static field variable initializers are present in the class of the static constructor, they run in the textual order in which they appear in the class declaration. The initializers run immediately before the static constructor.
7. If you don't provide a static constructor to initialize static fields, all static fields are initialized to their default value as listed in Default values of C# types.
8. If a static constructor throws an exception, the runtime doesn't invoke it a second time, and the type remains uninitialized for the lifetime of the application domain. Most commonly, a TypeInitializationException exception is thrown when a static constructor is unable to instantiate a type or for an unhandled exception occurring within a static constructor. For static constructors that aren't explicitly defined in source code, troubleshooting might require inspection of the intermediate language (IL) code.
9. The presence of a static constructor prevents the addition of the BeforeFieldInit type attribute. This limits runtime optimization.
10. A field declared as static readonly can only be assigned as part of its declaration or in a static constructor. When an explicit static constructor isn't required, initialize static fields at declaration rather than through a static constructor for better runtime optimization.
11. The runtime calls a static constructor no more than once in a single application domain. That call is made in a locked region based on the specific type of the class. No extra locking mechanisms are needed in the body of a static constructor. To avoid the risk of deadlocks, don't block the current thread in static constructors and initializers. For example, don't wait on tasks, threads, wait handles or events, don't acquire locks, and don't execute blocking parallel operations such as parallel loops, Parallel.Invoke and Parallel LINQ queries.

Usage
1. A typical use of static constructors is when the class is using a log file and the constructor is used to write entries to this file.
2. Static constructors are also useful when creating wrapper classes for unmanaged code, when the constructor can call the LoadLibrary method.
3. Static constructors are also a convenient place to enforce run-time checks on the type parameter that can't be checked at compile time via type-parameter constraints.

**/

namespace StaticConstructor{

    public class baseClass
    {
        public static long data ;

        static baseClass(){
            Console.WriteLine("baseClass static Constructor");
        }

        public baseClass(){
            Console.WriteLine("baseClase Constructor");
        }
    }

    class SimpleClass : baseClass
    {
        // Static variable that must be initialized at run time.
        public static readonly long baseline;

        public int number;

        // Static constructor is called at most one time, before any
        // instance constructor is invoked or member is accessed.
        static SimpleClass()
        {
            baseline = DateTime.Now.Ticks;
        }

        public SimpleClass(){
            Console.WriteLine("Simple Class Constructor...");
            number = 0;
        }

    }

    //If a static field initializer creates an instance of the type, the instance constructor is called before the static constructor runs. 
    //This happens because the static field initializer needs to execute to initialize the static field, and part of that initialization involves creating an instance of the type.
    public class Singleton
    {
        // Static field initializer calls instance constructor.
        private static Singleton instance = new Singleton();

        public Singleton()
        { 
            Console.WriteLine("Executes before static constructor.");
        }

        static Singleton()
        { 
            Console.WriteLine("Executes after instance constructor.");
        }

        public static Singleton Instance => instance;
    }

    class StaticConstructor{
        public static void Main(){
            Console.WriteLine("Static Constructor...");
            SimpleClass s = new SimpleClass();
            Console.WriteLine(SimpleClass.baseline);

            Singleton s1 = new Singleton();
        }
    }
}