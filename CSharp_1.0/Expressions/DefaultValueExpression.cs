using System;
/**

In C#, default value expressions are used to produce the default value for a given type. 
This is particularly useful for initializing variables, parameters, and properties when you don't have a specific value to assign.

A default value expression produces the default value of a type. 
There are two kinds of default value expressions: 
 1. the default operator call and 
 2. a default literal.

You also use the default keyword as the default case label within a switch statement.

Default Value Expressions
The default keyword in C# is used to produce the default value for a type. The default value depends on whether the type is a value type or a reference type:

Value Types: For value types (e.g., int, bool, struct), the default value is typically zero or equivalent (e.g., 0 for int, false for bool).
Reference Types: For reference types (e.g., class, interface), the default value is null.

default operator :
The argument to the default operator must be the name of a type or a type parameter,

default literal :
You can use the default literal to produce the default value of a type when the compiler can infer the expression type. The default literal expression produces the same value as the default(T) expression where T is the inferred type. You can use the default literal in any of the following cases:

In the assignment or initialization of a variable.
In the declaration of the default value for an optional method parameter.
In a method call to provide an argument value.
In a return statement or as an expression in an expression-bodied member.



**/
namespace DefaultValueExpression{
    class DefaultValueExpressionClass{
        public static void Main(){
            Console.WriteLine("Default Value Expression :");

            //Default Operator:
            Console.WriteLine("Default Operator :");
            Console.WriteLine(default(int));  // output: 0
            Console.WriteLine(default(object) is null);  // output: True

            void DisplayDefaultOf<T>()
            {
                var val = default(T);
                Console.WriteLine($"Default value of {typeof(T)} is {(val == null ? "null" : val.ToString())}.");
            }

            DisplayDefaultOf<int?>();
            DisplayDefaultOf<System.Numerics.Complex>();
            DisplayDefaultOf<System.Collections.Generic.List<int>>();
            // Output:
            // Default value of System.Nullable`1[System.Int32] is null.
            // Default value of System.Numerics.Complex is (0, 0).
            // Default value of System.Collections.Generic.List`1[System.Int32] is null.

            //Default Literal
            Console.WriteLine("Default Literal :");
            T[] InitializeArray<T>(int length, T initialValue = default)
            {
                if (length < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(length), "Array length must be nonnegative.");
                }

                var array = new T[length];
                for (var i = 0; i < length; i++)
                {
                    array[i] = initialValue;
                }
                return array;
            }

            void Display<T>(T[] values) => Console.WriteLine($"[ {string.Join(", ", values)} ]");

            Display(InitializeArray<int>(3));  // output: [ 0, 0, 0 ]
            Display(InitializeArray<bool>(4, default));  // output: [ False, False, False, False ]

            System.Numerics.Complex fillValue = default;
            Display(InitializeArray(3, fillValue));  // output: [ (0, 0), (0, 0), (0, 0) ]

        }
    }
}