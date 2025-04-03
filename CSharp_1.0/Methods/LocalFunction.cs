using System;
using System.Collections.Generic;

/**
Local functions in C# are methods defined within the body of another method. They help organize code, improve readability, and encapsulate functionality that is only relevant within the containing method.

They can only be called from their containing member.
Local functions can be declared in and called from:

Methods, especially iterator methods and async methods
Constructors
Property accessors
Event accessors
Anonymous methods
Lambda expressions
Finalizers
Other local functions
However, local functions can't be declared inside an expression-bodied member.


Local function syntax
A local function is defined as a nested method inside a containing member. Its definition has the following syntax:
<modifiers> <return-type> <method-name> <parameter-list>

The <parameter-list> shouldn't contain the parameters named with contextual keyword value. The compiler creates the temporary variable "value", which contains the referenced outer variables, which later causes ambiguity and may also cause an unexpected behaviour.

You can use the following modifiers with a local function:

async
unsafe
static A static local function can't capture local variables or instance state.
extern An external local function must be static.
All local variables that are defined in the containing member, including its method parameters, are accessible in a non-static local function.

Unlike a method definition, a local function definition can't include the member access modifier. Because all local functions are private, including an access modifier, such as the private keyword, generates compiler error CS0106, "The modifier 'private' isn't valid for this item."
You can apply attributes to a local function, its parameters, and type parameters,

Local functions vs. lambda expressions :
At first glance, local functions and lambda expressions are similar. In many cases, the choice between using lambda expressions and local functions is a matter of style and personal preference. 
However, there are real differences in where you can use one or the other that you should be aware of.

Key Differences:
----------------------
Syntax and Definition:
Local Functions: Defined using the standard method syntax within another method.
Lambda Expressions: Defined using the lambda syntax (=>), often inline.

Usage Context:
Local Functions: Can be used anywhere within the containing method, including before their definition.
Lambda Expressions: Typically used in contexts where delegates are required, such as LINQ queries, event handlers, or passing functions as arguments.

Access to Variables:
Local Functions: Can access variables and parameters from the containing method, including ref and out parameters.
Lambda Expressions: Can capture variables from the surrounding scope, but cannot use ref or out parameters.

Recursion:
Local Functions: Can call themselves recursively.
Lambda Expressions: Can be recursive, but require a workaround to reference themselves.

Performance:
Local Functions: Generally have better performance because they are compiled as regular methods.
Lambda Expressions: May have slightly more overhead due to their anonymous nature and delegate creation.


**/
namespace LocalFunction{
    class LocalFunction{

        //Iterator Methods
        //Iterator methods use the yield keyword to return elements one at a time. 
        //Exceptions in iterator methods are not thrown when the iterator is created but when the sequence is enumerated (i.e., when you start iterating over the elements).
        public IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            throw new Exception("Error in iterator");
        }

        public void ProcessNumbers()
        {
            var numbers = GetNumbers(); // No exception thrown here
            foreach (var number in numbers) // Exception thrown here
            {
                Console.WriteLine(number);
            }
        }

        


        public class Example
        {
            public void OuterMethod()
            {
                Console.WriteLine("Outer method");

                void LocalFunction()
                {
                    Console.WriteLine("Local function");
                }

                LocalFunction();
            }
        }



        public static void Main(){
            Console.WriteLine("Local Function ...");

            Example e = new Example();
            e.OuterMethod();

            //Iterator:
            LocalFunction l = new LocalFunction();
            //l.ProcessNumbers();

            //async Exceptions
            //await l.ProcessDataAsync();
            
        }
    }
}