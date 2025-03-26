using System;
using System.Linq;

/**
You use a lambda expression to create an anonymous function. Use the lambda declaration operator => to separate the lambda's parameter list from its body. A lambda expression can be of any of the following two forms:

Expression lambda that has an expression as its body:

(input-parameters) => expression

Statement lambda that has a statement block as its body:
(input-parameters) => { <sequence-of-statements> }

To create a lambda expression, you specify input parameters (if any) on the left side of the lambda operator and an expression or a statement block on the other side.

Any lambda expression can be converted to a delegate type. The types of its parameters and return value define the delegate type to which a lambda expression can be converted. 
If a lambda expression doesn't return a value, it can be converted to one of the Action delegate types; otherwise, it can be converted to one of the Func delegate types.

Expression lambdas can also be converted to the expression tree types.

Input parameters of a lambda expression:
You enclose input parameters of a lambda expression in parentheses. Specify zero input parameters with empty parentheses:
Action line = () => Console.WriteLine();

Input parameter types must be all explicit or all implicit; otherwise, a CS0748 compiler error occurs. Before C# 14, you must include the explicit type on a parameter if it has any modifiers, such as ref or out. 
In C# 14, that restriction is removed. 
However, you must still declare the type if you use the params modifier.

You can use discards to specify two or more input parameters of a lambda expression that aren't used in the expression.
Func<int, int, int> constant = (_, _) => 42;

Lambda discard parameters can be useful when you use a lambda expression to provide an event handler.

Beginning with C# 12, you can provide default values for explicitly typed parameter lists. The syntax and the restrictions on default parameter values are the same as for methods and local functions.

You can also declare lambda expressions with params arrays or collections as the last parameter in an explicitly typed parameter list:

Lambda expressions with default parameters or params collections as parameters don't have natural types that correspond to Func<> or Action<> types. However, you can define delegate types that include default parameter values:

you can use implicitly typed variables with var declarations to define the delegate type. The compiler synthesizes the correct delegate type

Async lambdas:
You can easily create lambda expressions and statements that incorporate asynchronous processing by using the async and await keywords.

Lambda expressions and tuples:
The C# language provides built-in support for tuples. 
You can provide a tuple as an argument to a lambda expression, and your lambda expression can also return a tuple. In some cases, the C# compiler uses type inference to determine the types of tuple elements.

You define a tuple by enclosing a comma-delimited list of its components in parentheses. 

Ordinarily, the fields of a tuple are named Item1, Item2, and so on. You can, however, define a tuple with named components, as the following example does.

Lambdas with the standard query operators
LINQ to Objects, among other implementations, has an input parameter whose type is one of the Func<TResult> family of generic delegates. 
These delegates use type parameters to define the number and type of input parameters, and the return type of the delegate. Func delegates are useful for encapsulating user-defined expressions that are applied to each element in a set of source data.

Type inference in lambda expressions
When writing lambdas, you often don't have to specify a type for the input parameters because the compiler can infer the type based on the lambda body, the parameter types,

The general rules for type inference for lambdas are as follows:
The lambda must contain the same number of parameters as the delegate type.
Each input parameter in the lambda must be implicitly convertible to its corresponding delegate parameter.
The return value of the lambda (if any) must be implicitly convertible to the delegate's return type.



Natural type of a lambda expression:
A lambda expression in itself doesn't have a type because the common type system has no intrinsic concept of "lambda expression." However, it's sometimes convenient to speak informally of the "type" of a lambda expression. That informal "type" refers to the delegate type or Expression type to which the lambda expression is converted.

A lambda expression can have a natural type. Instead of forcing you to declare a delegate type, such as Func<...> or Action<...> for a lambda expression, the compiler can infer the delegate type from the lambda expression. For example, consider the following declaration:

var parse = (string s) => int.Parse(s);
object parse = (string s) => int.Parse(s);   // Func<string, int>
Delegate parse = (string s) => int.Parse(s); // Func<string, int>
LambdaExpression parseExpr = (string s) => int.Parse(s); // Expression<Func<string, int>>
Expression parseExpr = (string s) => int.Parse(s);       // Expression<Func<string, int>>


Explicit return type:
Typically, the return type of a lambda expression is obvious and inferred. For some expressions that doesn't work:

var choose = (bool b) => b ? 1 : "two"; // ERROR: Can't infer return type
You can specify the return type of a lambda expression before the input parameters. When you specify an explicit return type, you must parenthesize the input parameters:

var choose = object (bool b) => b ? 1 : "two"; // Func<bool, object>


Attributes:
You can add attributes to a lambda expression and its parameters. The following example shows how to add attributes to a lambda expression:

Func<string?, int?> parse = [ProvidesNullCheck] (s) => (s is not null) ? int.Parse(s) : null;
You can also add attributes to the input parameters or return value, as the following example shows:

var concat = ([DisallowNull] string a, [DisallowNull] string b) => a + b;
var inc = [return: NotNullIfNotNull(nameof(s))] (int? s) => s.HasValue ? 

Capture of outer variables and variable scope in lambda expressions :
Lambdas can refer to outer variables. These outer variables are the variables that are in scope in the method that defines the lambda expression, or in scope in the type that contains the lambda expression. 
Variables that are captured in this manner are stored for use in the lambda expression even if the variables would otherwise go out of scope and be garbage collected. An outer variable must be definitely assigned before it can be consumed in a lambda expression.


The following rules apply to variable scope in lambda expressions:
A variable that is captured isn't garbage-collected until the delegate that references it becomes eligible for garbage collection.
Variables introduced within a lambda expression aren't visible in the enclosing method.
A lambda expression can't directly capture an in, ref, or out parameter from the enclosing method.
A return statement in a lambda expression doesn't cause the enclosing method to return.
A lambda expression can't contain a goto, break, or continue statement if the target of that jump statement is outside the lambda expression block. It's also an error to have a jump statement outside the lambda expression block if the target is inside the block.
You can apply the static modifier to a lambda expression to prevent unintentional capture of local variables or instance state by the lambda:

Func<double, double> square = static x => x * x;
A static lambda can't capture local variables or instance state from enclosing scopes, but can reference static members and constant definitions.


**/

namespace LambdaExpression{
    class LambdaExpressionClass{

        public static void Main(){
            Console.WriteLine("Lambda Expression !!!");

            Action<string> printName = (name) => Console.WriteLine("Name is :"+ name);
            printName("Niickil");

            Func<string,int, string> printDetails = (name,age) => $"Name is {name}, and age is {age}";
            Console.WriteLine(printDetails("navaneethan",25));

            System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            Console.WriteLine(e);
            // Output:
            // x => (x * x)

            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("World");
            // Output:
            // Hello World!

            Action line = () => Console.WriteLine("Empty Parameters");

            //The compiler typically infers the types for parameters to lambda expressions, referred to as an implicitly typed parameter list. 
            //You can specify the types explicitly, referred to as an explicitly typed parameter list. 
            //An explicitly typed parameter list is shown in the following example. :

            Func<int,string,bool> isTooLong = (size,word) => word.Length > size;
            Console.WriteLine("isTooLong :"+isTooLong(5,"applefd"));
            //Input parameter types must be all explicit or all implicit; otherwise, a CS0748 compiler error occurs.

            Func<int, int, int> constant = (_, _) => 42;
            Console.WriteLine("Discard Lambda Expression : "+ constant(0,0));

            //Default value on Lambda Parameters
            var IncrementBy = (int source, int increment = 1) => source + increment;

            Console.WriteLine(IncrementBy(5)); // 6
            Console.WriteLine(IncrementBy(5, 2)); // 7

            Func<(int,int),(int,int)> multiplyByTwo = inputs => (2*inputs.Item1, 2*inputs.Item2);
            (int,int) test = (10,20);
            Console.WriteLine("multiple :"+multiplyByTwo(test));

            //named tuple
            Func<(int n1, int n2),(int,int)> multipy = inputs => (2*inputs.n1, 2*inputs.n2);
            Console.WriteLine("named Multiply :"+ multipy((5,10)));


        




        
        }
    }
}