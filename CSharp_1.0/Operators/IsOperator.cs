using System;
/**
The is operator checks if the result of an expression is compatible with a given type. 

The is operator in C# is used to check if an object is compatible with a given type. 
It returns true if the object is of the specified type or can be cast to that type, and false otherwise. 
This operator is particularly useful for type checking and safe type casting.

The is operator can be useful in the following scenarios:
1. To check the run-time type of an expression.
2. To check for null
3. You can use a negation pattern to do a non-null check.
4. Beginning with C# 11, you can use list patterns to match elements of a list or array.


**/
namespace IsOperator{
    class IsOperatorClass{
        public static void Main(){
            Console.WriteLine("Is Operator :");

            int i = 34;
            object iBoxed = i;
            int? jNullable = 42;
            if (iBoxed is int a && jNullable is int b)
            {
                Console.WriteLine(a + b);  // output 76
            }

            if (jNullable is null)
            {
                Console.WriteLine("Is Null");
            }

            if (jNullable is not null)
            {
                Console.WriteLine("jNullable is :"+jNullable.ToString());
            }

            int[] empty = [];
            int[] one = [1];
            int[] odd = [1, 3, 5];
            int[] even = [2, 4, 6];
            int[] fib = [1, 1, 2, 3, 5];

            Console.WriteLine(odd is [1, _, 2, ..]);   // false
            Console.WriteLine(fib is [1, _, 2, ..]);   // true
            Console.WriteLine(fib is [_, 1, 2, 3, ..]);     // true
            Console.WriteLine(fib is [.., 1, 2, 3, _ ]);     // true
            Console.WriteLine(even is [2, _, 6]);     // true
            Console.WriteLine(even is [2, .., 6]);    // true
            Console.WriteLine(odd is [.., 3, 5]); // true
            Console.WriteLine(even is [.., 3, 5]); // false
            Console.WriteLine(fib is [.., 3, 5]); // true

            object obj = "Hello, World!";
            bool isString = obj is string; // true

            //Since C# 7.0, the is operator has been enhanced with pattern matching capabilities, allowing more expressive and concise type checks.
            //Pattern Matching with is operator.
            object obj1 = "Hello, World!";
            if (obj1 is string str)
            {
                Console.WriteLine(str); // Output: Hello, World!
            }

            //constant Pattern
            int number = 5;
            if (number is 5)
            {
                Console.WriteLine("Number is 5"); // Output: Number is 5
            }

            // Var Pattern:
            // The var pattern can be used to assign the value to a variable without type checking.
            object obj2 = "Hello, World!";
            if (obj2 is var value)
            {
                Console.WriteLine(value); // Output: Hello, World!
            }

            // Combining with Logical Patterns:
            // You can combine the is operator with logical patterns like and, or, and not for more complex conditions.
            //And Pattern:
            object obj3 = "Hello, World!";
            if (obj3 is string str1 and not null)
            {
                Console.WriteLine(str1); // Output: Hello, World!
            }

        }
    }
}