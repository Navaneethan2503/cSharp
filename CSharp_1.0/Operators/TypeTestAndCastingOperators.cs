using System;
using System.Collections.Generic;
/**
These operators and expressions perform type checking or type conversion. 
1. The is operator checks if the run-time type of an expression is compatible with a given type. 
2. The as operator explicitly converts an expression to a given type if its run-time type is compatible with that type. 
3. Cast expressions perform an explicit conversion to a target type. 
4. The typeof operator obtains the System.Type instance for a type.

The is operator:
--------------------------------------

The is operator checks if the run-time type of an expression result is compatible with a given type. The is operator also tests an expression result against a pattern.
The expression with the type-testing is operator has the following form
    E is T
Where E is an expression that returns a value and T is the name of a type or a type parameter. E can't be an anonymous method or a lambda expression.
The is operator returns true when an expression result is non-null and any of the following conditions are true:
The run-time type of an expression result is T.
The run-time type of an expression result derives from type T, implements interface T, or another implicit reference conversion exists from it to T.
The run-time type of an expression result is a nullable value type with the underlying type T and the Nullable<T>.HasValue is true.
A boxing or unboxing conversion exists from the run-time type of an expression result to type T when the expression isn't an instance of a ref struct.
The is operator doesn't consider user-defined conversions or implicit span conversions.


The as operator:
----------------------
The as operator explicitly converts the result of an expression to a given reference or nullable value type. If the conversion isn't possible, the as operator returns null. Unlike a cast expression, the as operator never throws an exception.

The expression of the form
E as T
Where E is an expression that returns a value and T is the name of a type or a type parameter, produces the same result as
E is T ? (T)(E) : (T)null
Except that E is only evaluated once.

The as operator considers only reference, nullable, boxing, and unboxing conversions. 
You can't use the as operator to perform a user-defined conversion. To do that, use a cast expression.

-------------------------------------
Cast expression:

A cast expression of the form (T)E performs an explicit conversion of the result of expression E to type T. 
If no explicit conversion exists from the type of E to type T, a compile-time error occurs.
At run time, an explicit conversion might not succeed and a cast expression might throw an exception.

-------------------------------------------------
The typeof operator: 
The typeof operator obtains the System.Type instance for a type. 
The argument to the typeof operator must be the name of a type or a type parameter

he argument mustn't be a type that requires metadata annotations. Examples include the following types:

dynamic
string? (or any nullable reference type)
These types aren't directly represented in metadata. The types include attributes that describe the underlying type. In both cases, you can use the underlying type. Instead of dynamic, you can use object. Instead of string?, you can use string.

You can also use the typeof operator with unbound generic types. The name of an unbound generic type must contain the appropriate number of commas, which is one less than the number of type parameters.

**/
namespace TypeTestAndCastingOperators{
    public class Base { }

    public class Derived : Base { }

    public class Animal { }

    public class Giraffe : Animal { }

    class TypeTestAndCastingOperatorsClass{
        public static void Main(){
            Console.WriteLine("Type Testing and Casting Operators");
            object b = new Base();
            Console.WriteLine(b is Base);  // output: True
            Console.WriteLine(b is Derived);  // output: False

            object d = new Derived();
            Console.WriteLine(d is Base);  // output: True
            Console.WriteLine(d is Derived); // output: True

            int i = 27;
            Console.WriteLine(i is System.IFormattable);  // output: True

            object iBoxed = i;
            Console.WriteLine(iBoxed is int);  // output: True
            Console.WriteLine(iBoxed is long);  // output: False

            // Type testing with pattern matching
            // The is operator also tests an expression result against a pattern.
            
            object iBoxed1 = i;
            int? jNullable = 7;
            if (iBoxed1 is int a && jNullable is int b1)
            {
                Console.WriteLine(a + b1);  // output 30
            }

            //As Operator 
            object obj = "Hello, World!";
            string str = obj as string; // str will be "Hello, World!"

            //Casting
            //object obj = "Hello, World!";
            string str1 = (string)obj; // Explicit cast

            //TypeOf
            void PrintType<T>() => Console.WriteLine(typeof(T));

            Console.WriteLine(typeof(List<string>));
            PrintType<int>();
            PrintType<System.Int32>();
            PrintType<Dictionary<int, char>>();
            // Output:
            // System.Collections.Generic.List`1[System.String]
            // System.Int32
            // System.Int32
            // System.Collections.Generic.Dictionary`2[System.Int32,System.Char]

            object b2 = new Giraffe();
            Console.WriteLine(b2 is Animal);  // output: True
            Console.WriteLine(b2.GetType() == typeof(Animal));  // output: False

            Console.WriteLine(b2 is Giraffe);  // output: True
            Console.WriteLine(b2.GetType() == typeof(Giraffe));  // output: True

        }
    }
}