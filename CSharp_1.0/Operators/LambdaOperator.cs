using System;
using System.Linq;
/**
In lambda expressions, the lambda operator => separates the input parameters on the left side from the lambda body on the right side.

Expression body definition
An expression body definition has the following general syntax:
member => expression;

the lambda operator (=>) is used to define lambda expressions, which can be assigned to members like properties, methods, or delegates. The expression on the right side of the lambda operator must be a valid expression, and its return type must be implicitly convertible to the member's return type.

Key Points:
Void Return Type: If the member has a void return type, the lambda expression should not return a value. For example:

Action<int> print = x => Console.WriteLine(x);
print(5); // Output: 5
Constructors: Lambda expressions cannot be used directly as constructors, but they can be used to initialize objects in LINQ queries or other contexts.

Finalizers: Lambda expressions cannot be used as finalizers.

Property or Indexer Set Accessors: Lambda expressions can be used in property or indexer set accessors to define the logic for setting a value. For example:

private int _value;
public int Value
{
    get => _value;
    set => _value = value > 0 ? value : 0; // Ensures value is non-negative
}



**/
namespace LambdaOperator{
    class LambdaOperatorClass{
        public static void Main(){
            Console.WriteLine("Lambda Operators !!!");

            string[] words = { "bot", "apple", "apricot" };
            int minimalLength = words
            .Where(w => w.StartsWith("a"))
            .Min(w => w.Length);
            Console.WriteLine(minimalLength);   // output: 5

            int[] numbers = { 4, 7, 10 };
            int product = numbers.Aggregate(1, (interim, next) => interim * next);
            Console.WriteLine(product);   // output: 280
            //Input parameters of a lambda expression are strongly typed at compile time. When the compiler can infer the types of input parameters, like in the preceding example, you can omit type declarations. 
            //If you need to specify the type of input parameters, you must do that for each parameter, as the following example shows:
                     
            var greet = () => "Hello, World!";
            Console.WriteLine(greet());
        }
    }
}