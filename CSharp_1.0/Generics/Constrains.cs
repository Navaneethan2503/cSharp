using System;
using System.Collections.Generic;
/**
Why use constraints
Constraints specify the capabilities and expectations of a type parameter. 
Declaring those constraints means you can use the operations and method calls of the constraining type. 
You apply constraints to the type parameter when your generic class or method uses any operation on the generic members beyond simple assignment, which includes calling any methods not supported by System.Object. 



Constraining multiple parameters:
You can apply constraints to multiple parameters, and multiple constraints to a single parameter, as shown in the following example:

where T : struct	The type argument must be a non-nullable value type, which includes record struct types
where T : class	The type argument must be a reference type. This constraint applies also to any class, interface, delegate, or array type. In a nullable context, T must be a non-nullable reference type.
where T : class?	The type argument must be a reference type, either nullable or non-nullable. This constraint applies also to any class, interface, delegate, or array type, including records.
where T : notnull	The type argument must be a non-nullable type. The argument can be a non-nullable reference type or a non-nullable value type.
where T : unmanaged	The type argument must be a non-nullable unmanaged type. The unmanaged constraint implies the struct constraint and can't be combined with either the struct or new() constraints.
where T : new()	The type argument must have a public parameterless constructor. When used together with other constraints, the new() constraint must be specified last. The new() constraint can't be combined with the struct and unmanaged constraints.
where T : <base class name>	The type argument must be or derive from the specified base class. In a nullable context, T must be a non-nullable reference type derived from the specified base class.
where T : <base class name>?	The type argument must be or derive from the specified base class. In a nullable context, T can be either a nullable or non-nullable type derived from the specified base class.
where T : <interface name>	The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic. In a nullable context, T must be a non-nullable type that implements the specified interface.
where T : <interface name>?	The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic. In a nullable context, T can be a nullable reference type, a non-nullable reference type, or a value type. T can't be a nullable value type.
where T : U	The type argument supplied for T must be or derive from the argument supplied for U. In a nullable context, if U is a non-nullable reference type, T must be a non-nullable reference type. If U is a nullable reference type, T can be either nullable or non-nullable.
where T : default	This constraint resolves the ambiguity when you need to specify an unconstrained type parameter when you override a method or provide an explicit interface implementation. The default constraint implies the base method without either the class or struct constraint. For more information, see the default constraint spec proposal. - parameterless constructor allows.:
          To apply the default constraint, you use the where keyword followed by the type parameter and the new() constraint:
where T : System.Enum - You can also specify the System.Enum type as a base class constraint. The CLR always allowed this constraint, but the C# language disallowed it. Generics using System.Enum provide type-safe programming to cache results from using the static methods in System.Enum. 
where T : allows ref struct	This anti-constraint declares that the type argument for T can be a ref struct type. The generic type or method must obey ref safety rules for any instance of T because it might be a ref struct.
where TDelegate : System.Delegate

Some constraints are mutually exclusive, and some constraints must be in a specified order:

You can apply at most one of the struct, class, class?, notnull, and unmanaged constraints. If you supply any of these constraints, it must be the first constraint specified for that type parameter.
The base class constraint (where T : Base or where T : Base?) can't be combined with any of the constraints struct, class, class?, notnull, or unmanaged.
You can apply at most one base class constraint, in either form. If you want to support the nullable base type, use Base?.
You can't name both the non-nullable and nullable form of an interface as a constraint.
The new() constraint can't be combined with the struct or unmanaged constraint. If you specify the new() constraint, it must be the last constraint for that type parameter. Anti-constraints, if applicable, can follow the new() constraint.
The default constraint can be applied only on override or explicit interface implementations. It can't be combined with either the struct or class constraints.
The allows ref struct anti-constraint can't be combined with the class or class? constraint.
The allows ref struct anti-constraint must follow all constraints for that type parameter.

Unbounded type parameters
Type parameters that have no constraints, such as T in public class SampleClass<T>{}, are called unbounded type parameters. Unbounded type parameters have the following rules:

The != and == operators can't be used because there's no guarantee that the concrete type argument supports these operators.
They can be converted to and from System.Object or explicitly converted to any interface type.
You can compare them to null. If an unbounded parameter is compared to null, the comparison always returns false if the type argument is a value type.

Type parameters as constraints :
The use of a generic type parameter as a constraint is useful when a member function with its own type parameter has to constrain that parameter to the type parameter of the containing type.

Type parameters can also be used as constraints in generic class definitions. The type parameter must be declared within the angle brackets together with any other type parameters:
//Type parameter V is used as a type constraint.
public class SampleClass<T, U, V> where T : V { }


**/
namespace Generics{

    //Type parameters as constraints
    public class List<T>
    {
        public void Add<U>(List<U> items) where U : T {/*...*/}
    }

    class Base{

    }

    class Test<T,U> 
    where T : class 
    where U : Base, new()
    {

    }

    public class Employee
    {
        public Employee(string name, int id) => (Name, ID) = (name, id);
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class GenericList<T> where T : Employee
    {
        private class Node
        {
            public Node(T t) => (Next, Data) = (null, t);

            public Node? Next { get; set; }
            public T Data { get; set; }
        }

        private Node? head;

        public void AddHead(T t)
        {
            Node n = new Node(t) { Next = head };
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node? current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T? FindFirstOccurrence(string s)
        {
            Node? current = head;
            T? t = null;

            while (current != null)
            {
                //The constraint enables access to the Name property.
                if (current.Data.Name == s)
                {
                    t = current.Data;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return t;
        }
    }

    
    public class Allow<T> where T : allows ref struct
    {

    }

    public class Disallow<T>
    {
    }

    public class Example<T> where T : allows ref struct
    {
        private Allow<T> fieldOne; // Allowed. T is allowed to be a ref struct

        //private Disallow<T> fieldTwo; // Error. T is not allowed to be a ref struct
    }

    static class Constrains{
        //Delegate Constraint
        public static TDelegate? TypeSafeCombine<TDelegate>(this TDelegate source, TDelegate target)
        where TDelegate : System.Delegate
        => Delegate.Combine(source, target) as TDelegate;


        //Enum Constraints
        public static Dictionary<int, string> EnumNamedValues<T>() where T : System.Enum
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
                result.Add(item, Enum.GetName(typeof(T), item)!);
            return result;
        }

        enum Rainbow
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }

        public static void Main(){
            Console.WriteLine("Generic Constains.");

            Action first = () => Console.WriteLine("this");
            Action second = () => Console.WriteLine("that");

            var combined = first.TypeSafeCombine(second);
            combined!();

            Func<bool> test = () => true;
            // Combine signature ensures combined delegates must
            // have the same type.
            //var badCombined = first.TypeSafeCombine(test);

            var map = EnumNamedValues<Rainbow>();

            foreach (var pair in map)
                Console.WriteLine($"{pair.Key}:\t{pair.Value}");
        }
    }
}