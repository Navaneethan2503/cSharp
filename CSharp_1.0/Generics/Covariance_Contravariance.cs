using System;
using System.Collections.Generic;
/**
Covariance and contravariance are concepts in C# that allow for more flexible use of generics, particularly with interfaces and delegates. 
They enable you to use a derived type 
    where a base type is expected (covariance) or a base type 
    where a derived type is expected (contravariance). 
These concepts are particularly useful when working with collections, event handling, and other scenarios involving generics.

Covariance:
-----------
Covariance allows you to use a more derived type than originally specified. 
It is applicable to generic interfaces and delegates where the type parameter is used only for output purposes.

Contravariance:
----------------
Contravariance allows you to use a less derived type than originally specified. 
It is applicable to generic interfaces and delegates where the type parameter is used only for input purposes.

Why Covariance and Contravariance?
The main reason for covariance and contravariance is to provide flexibility and type safety when working with generics. They allow you to:
Reuse Code: You can write more generic and reusable code.
Type Safety: Ensure that assignments are type-safe and follow the inheritance hierarchy.
Flexibility: Work with collections and delegates in a more flexible manner.

With Covariance and Contravariance in Generics:
------------------------------------------------
Covariance and contravariance come into play when you are dealing with generic types, such as interfaces and delegates. They allow you to assign generic types in a way that respects the inheritance hierarchy.
Without Covariance and Contravariance:
--------------------------------------
When you work with non-generic types, you can directly assign derived types to base types:

Covariance (out keyword): Allows a derived type to be used where a base type is expected. Applicable to return types in interfaces and delegates.
Contravariance (in keyword): Allows a base type to be used where a derived type is expected. Applicable to parameter types in interfaces and delegates.

Invariance in Generics:
------------------------
Invariance is the default behavior of generic types in C#. It means that a generic type parameter is neither covariant nor contravariant. Invariant generic types require that the type arguments match exactly, without any flexibility for derived or base types.

Key Points of Invariance:
---------------------------
Exact Type Matching: Invariant generic types require that the type arguments match exactly. You cannot substitute a base type for a derived type or vice versa.
Type Safety: Invariance ensures type safety by preventing assignments that could lead to runtime errors due to type mismatches.

Why Invariance?
Invariance is useful for ensuring strict type safety. It prevents accidental type mismatches that could lead to runtime errors. By requiring exact type matches, invariance helps maintain the integrity of the type system.

Comparison with Covariance and Contravariance
To understand invariance better, let's compare it with covariance and contravariance:

Covariance (out keyword): Allows a derived type to be used where a base type is expected. Applicable to return types in interfaces and delegates.
Contravariance (in keyword): Allows a base type to be used where a derived type is expected. Applicable to parameter types in interfaces and delegates.
Invariance: Requires exact type matches. No flexibility for derived or base types. Applicable to generic types by default.


A brief summary of facts about variance in the common language runtime:
    Variant type parameters are restricted to generic interface and generic delegate types.
    A generic interface or generic delegate type can have both covariant and contravariant type parameters.
    Variance applies only to reference types; if you specify a value type for a variant type parameter, that type parameter is invariant for the resulting constructed type.
    Variance does not apply to delegate combination. That is, given two delegates of types Action<Derived> and Action<Base> (Action(Of Derived) and Action(Of Base) in Visual Basic), you cannot combine the second delegate with the first although the result would be type safe. Variance allows the second delegate to be assigned to a variable of type Action<Derived>, but delegates can combine only if their types match exactly.
    Starting in C# 9, covariant return types are supported. An overriding method can declare a more derived return type the method it overrides, and an overriding, read-only property can declare a more derived type.

Starting with .NET Framework 4, the following interfaces are variant:
    IEnumerable<T> (T is covariant)
    IEnumerator<T> (T is covariant)
    IQueryable<T> (T is covariant)
    IGrouping<TKey,TElement> (TKey and TElement are covariant)
    IComparer<T> (T is contravariant)
    IEqualityComparer<T> (T is contravariant)
    IComparable<T> (T is contravariant)

Starting with .NET Framework 4.5, the following interfaces are variant:
    IReadOnlyList<T> (T is covariant)
    IReadOnlyCollection<T> (T is covariant)


Generic Delegates That Have Variant Type Parameters in .NET:
------------------------------------------------------------
.NET Framework 4 introduced variance support for generic type parameters in several existing generic delegates:
    Action delegates from the System namespace, for example, Action<T> and Action<T1,T2>
    Func delegates from the System namespace, for example, Func<TResult> and Func<T,TResult>
    The Predicate<T> delegate
    The Comparison<T> delegate
    The Converter<TInput,TOutput> delegate



**/
namespace Generics{

    //Covariant
    public interface ICovariant<out T>
    {
        T GetItem();
    }

    
    public interface IContravariant<in T>
    {
        void SetItem(T item);
    }


    public class Animal { }
    public class Dog : Animal { }

    public class Covariant<T> : ICovariant<T>
    {
        public T GetItem()
        {
            Console.WriteLine("Covariant GetItem : "+ typeof(T));
            // Implementation
            return default(T);
        }
    }

    
    public class Contravariant<T> : IContravariant<T>
    {
        public void SetItem(T item)
        {
            // Implementation
        }
    }


    //delegate - covariant
    public delegate Animal AnimalDelegateCoV();

    public interface IGeneral<T>{
        T work();
    }

    public class A<T>{
        public T work(){
            Console.WriteLine("class A Work" );
            return default(T);
        }
    }

    public class B<T> : A<T>, IGeneral<T>{
        public T work(){
            Console.WriteLine("class B work");
            return default(T);
        }

        public T BMethod(){
            Console.WriteLine("B Method");
            return default(T);
        }
    }

    // Simple hierarchy of classes.
    class BaseClass { }
    class DerivedClass : BaseClass { }

    // Comparer class.
    class BaseComparer : IEqualityComparer<BaseClass>
    {
        public int GetHashCode(BaseClass baseInstance)
        {
            return baseInstance.GetHashCode();
        }
        public bool Equals(BaseClass x, BaseClass y)
        {
            return x == y;
        }
    }

    //It is also possible to support both covariance and contravariance in the same interface, but for different type parameters, as shown in the following code example.
    interface IVariant<out R, in A>
    {
        R GetSomething();
        void SetSomething(A sampleArg);
        R GetSetSomethings(A sampleArg);
    }

    //You can create an interface that extends both the interface where the generic type parameter T is covariant and the interface where it is contravariant if in the extending interface the generic type parameter T is invariant. This is illustrated in the following code example.
    interface ICovariant1<out T> { }
    interface IContravariant1<in T> { }
    interface IInvariant1<T> : ICovariant<T>, IContravariant<T> { }

    //if a generic type parameter T is declared covariant in one interface, you cannot declare it contravariant in the extending interface, or vice versa.
    interface ICovariant2<out T> { }
    // The following statement generates a compiler error.
    // interface ICoContraVariant<in T> : ICovariant<T> { }

    public class Person { }  
    public class Employee1 : Person { } 

    class CovarianceContraVariance{

        static Employee1 FindByTitle(String title)  
        {  
            // This is a stub for a method that returns  
            // an employee that has the specified title.  
            return new Employee1();  
        }

        static void AddToContacts(Person person)  
        {  
            // This method adds a Person object  
            // to a contact list.  
        } 
        
        public static Dog GetDog()
        {
            return new Dog();
        }

        public delegate void AnimalDelegate(Animal animal);

        
        public static void ProcessAnimal(Animal animal)
        {
                // Implementation
        }


        public static void Main(){
            Console.WriteLine("Covariance and ContraVariance.");

            IGeneral<int> t = new B<int>();
            t.work();
            //t.BMethod();

            ICovariant<Dog> dogCovariant = new Covariant<Dog>();
            ICovariant<Animal> animalCovariant = dogCovariant; // Covariance allows this assignment

            Animal animal1 = animalCovariant.GetItem();
            Console.WriteLine("Check for null :"+animal1 is null);

            // the String type does inherit the Object type, and in some cases you may want to assign objects of these interfaces to each other
            // IEnumerable<String> strings = new List<String>();
            // IEnumerable<Object> objects = strings;
            
            IEqualityComparer<BaseClass> baseComparer = new BaseComparer();

            // Implicit conversion of IEqualityComparer<BaseClass> to
            // IEqualityComparer<DerivedClass>.
            IEqualityComparer<DerivedClass> childComparer = baseComparer;
            // The following line generates a compiler error
            // because classes are invariant.
            // List<Object> list = new List<String>();

            // You can use the interface object instead.
            // IEnumerable<Object> listObjects = new List<String>();

            // Assignment compatibility.
            string str = "test";  
            // An object of a more derived type is assigned to an object of a less derived type.
            object obj = str; 

            //Delegate - covariant
            AnimalDelegateCoV animalDelegate = GetDog; // Covariance allows this assignment
            Animal animal = animalDelegate();

            // Covariance.
            //IEnumerable<string> strings = new List<string>();  
            // An object that is instantiated with a more derived type argument
            // is assigned to an object instantiated with a less derived type argument.
            // Assignment compatibility is preserved.
            //IEnumerable<object> objects = strings;  
            
            // Contravariance.
            // Assume that the following method is in the class:
            static void SetObject(object o) { }
            Action<object> actObject = SetObject;  
            // An object that is instantiated with a less derived type argument
            // is assigned to an object instantiated with a more derived type argument.
            // Assignment compatibility is reversed.
            Action<string> actString = actObject;

            //Contravariant
            IContravariant<Animal> animalContravariant = new Contravariant<Animal>();
            IContravariant<Dog> dogContravariant = animalContravariant; // Contravariance allows this assignment
            dogContravariant.SetItem(new Dog());

            //Delegate 
            AnimalDelegate animalDelegate1 = ProcessAnimal; // Contravariance allows this assignment
            animalDelegate1(new Dog());

            static object GetObject() { return null; }  
            static void SetObject1(object obj) { }  
            
            static string GetString() { return ""; }  
            static void SetString(string str) { }  

            //Covariant:
            // Create an instance of the delegate without using variance.  
            Func<String, Employee1> findEmployee = FindByTitle;  
    
            // The delegate expects a method to return Person,  
            // but you can assign it a method that returns Employee.  
            Func<String, Person> findPerson = FindByTitle;  
    
            // You can also assign a delegate
            // that returns a more derived type
            // to a delegate that returns a less derived type.  
            findPerson = findEmployee; 

            //Contravariant
            // Create an instance of the delegate without using variance.  
            Action<Person> addPersonToContacts = AddToContacts;  
    
            // The Action delegate expects
            // a method that has an Employee parameter,  
            // but you can assign it a method that has a Person parameter  
            // because Employee derives from Person.  
            Action<Employee1> addEmployeeToContacts = AddToContacts;  
    
            // You can also assign a delegate
            // that accepts a less derived parameter to a delegate
            // that accepts a more derived parameter.  
            addEmployeeToContacts = addPersonToContacts;





        }
    }
}