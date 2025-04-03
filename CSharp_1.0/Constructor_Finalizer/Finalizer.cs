using System;
/**
Finalizers (historically referred to as destructors) are used to perform any necessary final clean-up when a class instance is being collected by the garbage collector. 
In most cases, you can avoid writing a finalizer by using the System.Runtime.InteropServices.SafeHandle or derived classes to wrap any unmanaged handle.

Syntax: 
A finalizer is defined using a tilde (~) followed by the class name. It does not take any parameters and does not have a return type.


Remarks
Finalizers cannot be defined in structs. They are only used with classes.
A class can only have one finalizer.
Finalizers cannot be inherited or overloaded.
Finalizers cannot be called. They are invoked automatically.
A finalizer does not take modifiers or have parameters.

class Car
{
    ~Car()  // finalizer
    {
        // cleanup statements...
    }
}


Empty finalizers should not be used. When a class contains a finalizer, an entry is created in the Finalize queue. This queue is processed by the garbage collector. When the GC processes the queue, it calls each finalizer. 
Unnecessary finalizers, including empty finalizers, finalizers that only call the base class finalizer, or finalizers that only call conditionally emitted methods, cause a needless loss of performance.

The programmer has no control over when the finalizer is called; the garbage collector decides when to call it. The garbage collector checks for objects that are no longer being used by the application. 
If it considers an object eligible for finalization, it calls the finalizer (if any) and reclaims the memory used to store the object. It's possible to force garbage collection by calling Collect, but most of the time, this call should be avoided because it may create performance issues.

Whether or not finalizers are run as part of application termination is specific to each implementation of .NET. When an application terminates, .NET Framework makes every reasonable effort to call finalizers for objects that haven't yet been garbage collected, unless such cleanup has been suppressed (by a call to the library method GC.SuppressFinalize

If you need to perform cleanup reliably when an application exits, register a handler for the System.AppDomain.ProcessExit event. 
That handler would ensure IDisposable.Dispose() (or, IAsyncDisposable.DisposeAsync()) has been called for all objects that require cleanup before application exit. Because you can't call Finalize directly, and you can't guarantee the garbage collector calls all finalizers before exit, you must use Dispose or DisposeAsync to ensure resources are freed.


Using finalizers to release resources:
In general, C# does not require as much memory management on the part of the developer as languages that don't target a runtime with garbage collection. This is because the .NET garbage collector implicitly manages the allocation and release of memory for your objects. However, when your application encapsulates unmanaged resources, such as windows, files, and network connections, you should use finalizers to free those resources. 
When the object is eligible for finalization, the garbage collector runs the Finalize method of the object.

Explicit release of resources
If your application is using an expensive external resource, we also recommend that you provide a way to explicitly release the resource before the garbage collector frees the object. To release the resource, implement a Dispose method from the IDisposable interface that performs the necessary cleanup for the object. This can considerably improve the performance of the application. Even with this explicit control over resources, the finalizer becomes a safeguard to clean up resources if the call to the Dispose method fails.


**/
namespace Finalizers{

    //A finalizer can also be implemented as an expression body definition, 
    public class Destroyer
    {
    public override string ToString() => GetType().Name;

    ~Destroyer() => Console.WriteLine($"The {ToString()} finalizer is executing.");
    }

    //when you define a finalizer (destructor) for a class, it implicitly calls the Finalize method of its base class. This ensures that the cleanup logic defined in the base class's finalizer is also executed. 
    //The compiler translates a finalizer into a call to the base class's Finalize method, ensuring proper cleanup in the inheritance hierarchy.
    public class BaseClass
    {
        // Finalizer in the base class
        ~BaseClass()
        {
            Console.WriteLine("BaseClass finalizer called.");
        }
    }

    public class DerivedClass : BaseClass
    {
        // Finalizer in the derived class
        //This design means that the Finalize method is called recursively for all instances in the inheritance chain, from the most-derived to the least-derived.
        ~DerivedClass()
        {
            Console.WriteLine("DerivedClass finalizer called.");
        }
    }

    class First
    {
        ~First()
        {
            System.Diagnostics.Trace.WriteLine("First's finalizer is called.");
        }
    }

    class Second : First
    {
        ~Second()
        {
            System.Diagnostics.Trace.WriteLine("Second's finalizer is called.");
        }
    }

    class Third : Second
    {
        ~Third()
        {
            System.Diagnostics.Trace.WriteLine("Third's finalizer is called.");
        }
    }

    /* 
    Test with code like the following:
        Third t = new Third();
        t = null;

    When objects are finalized, the output would be:
    Third's finalizer is called.
    Second's finalizer is called.
    First's finalizer is called.
    */


    class FinalizersClass{
        public static void Main(){
            Console.WriteLine("Finalizer Class");
            Destroyer d = new Destroyer();
            
            Third t = new Third();
            t = null;
        }
    }
}