using System;
/**
Access modifiers are keywords used to specify the declared accessibility of a member or a type. This section introduces the five access modifiers:

public
protected
internal
private
file
The following seven accessibility levels can be specified using the access modifiers:

public: Code in any assembly can access this type or member. The accessibility level of the containing type controls the accessibility level of public members of the type.
private: Only code declared in the same class or struct can access this member.
protected: Only code in the same class or in a derived class can access this type or member.
internal: Only code in the same assembly can access this type or member.
protected internal: Only code in the same assembly or in a derived class in another assembly can access this type or member.
private protected: Only code in the same assembly and in the same class or a derived class can access the type or member.
file: Only code in the same file can access the type or member.

Accessibility Levels: Using the access modifiers to declare levels of accessibility.
Accessibility Domain: Specifies where, in the program sections, a member can be referenced.
Restrictions on Using Accessibility Levels: A summary of the restrictions on using declared accessibility levels.

1. Accessibility Levels
These are keywords that define who can access a class, method, or member in your code:

Public: Anyone can access it.
Private: Only the same class can access it.
Protected: The same class and its derived classes can access it.
Internal: Only code within the same assembly can access it.
Protected Internal: Code in the same assembly or derived classes in other assemblies can access it.
Private Protected: Only the same class or derived classes within the same assembly can access it.

2.Accessibility Domain
This refers to the scope or area where a member can be accessed, based on its accessibility level and where it is declared:

Top-Level Types: Accessible throughout the project.
Nested Types: Accessible within the containing type and its nested types.
Simple Comparison
Accessibility Levels: Think of them as rules that say "who" can access a member.
Accessibility Domain: Think of it as the "where" these rules apply within your code.

3.Restrictions on using Accessability Levels:
When you specify a type in a declaration, check whether the accessibility level of the type is dependent on the accessibility level of a member or of another type. For example, the direct base class must be at least as accessible as the derived class. The following declarations cause a compiler error because the base class BaseClass is less accessible than MyClass:
class BaseClass {...}
public class MyClass: BaseClass {...} // Error

The following table summarizes the restrictions on declared accessibility levels.

Context	Remarks
Classes	The direct base class of a class type must be at least as accessible as the class type itself.
Interfaces	The explicit base interfaces of an interface type must be at least as accessible as the interface type itself.
Delegates	The return type and parameter types of a delegate type must be at least as accessible as the delegate type itself.
Constants	The type of a constant must be at least as accessible as the constant itself.
Fields	The type of a field must be at least as accessible as the field itself.
Methods	The return type and parameter types of a method must be at least as accessible as the method itself.
Properties	The type of a property must be at least as accessible as the property itself.
Events	The type of an event must be at least as accessible as the event itself.
Indexers	The type and parameter types of an indexer must be at least as accessible as the indexer itself.
Operators	The return type and parameter types of an operator must be at least as accessible as the operator itself.
Constructors	The parameter types of a constructor must be at least as accessible as the constructor itself.

Multiple declarations of a partial class or partial member must have the same accessibility. 
If one declaration of the partial class or member doesn't include an access modifier, the other declarations can't declare an access modifier. The compiler generates an error if multiple declarations for the partial class or method declare different accessibilities.

Classes and structs declared directly within a namespace (aren't nested within other classes or structs) can have public, internal or file access. internal is the default if no access modifier is specified.

Struct members, including nested classes and structs, can be declared public, internal, or private. Class members, including nested classes and structs, can be public, protected internal, protected, internal, private protected, or private. Class and struct members, including nested classes and structs, have private access by default.

Derived classes can't have greater accessibility than their base types. You can't declare a public class B that derives from an internal class A. If allowed, it would have the effect of making A public, because all protected or internal members of A are accessible from the derived class.

You can enable specific other assemblies to access your internal types by using the InternalsVisibleToAttribute

Interfaces declared directly within a namespace can be public or internal and, just like classes and structs, interfaces default to internal access. Interface members are public by default because the purpose of an interface is to enable other types to access a class or struct. Interface member declarations might include any access modifier. You use access modifiers on interface members to provide a common implementation needed by all implementors of an interface.

A delegate type declared directly in a namespace has internal access by default.

Members of a class or struct (including nested classes and structs) can be declared with any of the six types of access. Struct members can't be declared as protected, protected internal, or private protected because structs don't support inheritance.

Normally, the accessibility of a member isn't greater than the accessibility of the type that contains it. However, a public member of an internal class might be accessible from outside the assembly if the member implements interface methods or overrides virtual methods that are defined in a public base class.

The type of any member field, property, or event must be at least as accessible as the member itself. Similarly, the return type and the parameter types of any method, indexer, or delegate must be at least as accessible as the member itself. For example, you can't have a public method M that returns a class C unless C is also public. Likewise, you can't have a protected property of type A if A is declared as private.

User-defined operators must always be declared as public and static. For more information, see Operator overloading.

To set the access level for a class or struct member, add the appropriate keyword to the member declaration, as shown in the following example.

// public class:
public class Tricycle
{
    // protected method:
    protected void Pedal() { }

    // private field:
    private int _wheels = 3;

    // protected internal property:
    protected internal int Wheels
    {
        get { return _wheels; }
    }
}
Finalizers can't have accessibility modifiers. Members of an enum type are always public, and no access modifiers can be applied.

The file access modifier is allowed only on top-level (non-nested) type declarations.
**/

namespace AccessModifier
{
    public class T1
    {
        public static int publicInt;
        internal static int internalInt;
        private static int privateInt = 0;

        static T1()
        {
            // T1 can access public or internal members
            // in a public or private (or internal) nested class.
            M1.publicInt = 1;
            M1.internalInt = 2;
            M2.publicInt = 3;
            M2.internalInt = 4;

            // Cannot access the private member privateInt
            // in either class:
            // M1.privateInt = 2; //CS0122
        }

        public class M1
        {
            public static int publicInt;
            internal static int internalInt;
            private static int privateInt = 0;
        }

        private class M2
        {
            public static int publicInt = 0;
            internal static int internalInt = 0;
            private static int privateInt = 0;
        }
    }

    class MainClass
    {
        static void Main()
        {
            // Access is unlimited.
            T1.publicInt = 1;

            // Accessible only in current assembly.
            T1.internalInt = 2;

            // Error CS0122: inaccessible outside T1.
            // T1.privateInt = 3;

            // Access is unlimited.
            T1.M1.publicInt = 1;

            // Accessible only in current assembly.
            T1.M1.internalInt = 2;

            // Error CS0122: inaccessible outside M1.
            //    T1.M1.privateInt = 3;

            // Error CS0122: inaccessible outside T1.
            //    T1.M2.publicInt = 1;

            // Error CS0122: inaccessible outside T1.
            //    T1.M2.internalInt = 2;

            // Error CS0122: inaccessible outside M2.
            //    T1.M2.privateInt = 3;

            // Keep the console open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}