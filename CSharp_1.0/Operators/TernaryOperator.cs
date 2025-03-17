using System;
using System.Collections.Generic;
/**
The conditional operator ?:, also known as the ternary conditional operator, evaluates a Boolean expression and returns the result of one of the two expressions, depending on whether the Boolean expression evaluates to true or false, 
Syntax :
condition ? consequent : alternative

The condition expression must evaluate to true or false. If condition evaluates to true, the consequent expression is evaluated, and its result becomes the result of the operation. 
If condition evaluates to false, the alternative expression is evaluated, and its result becomes the result of the operation. Only consequent or alternative is evaluated. Conditional expressions are target-typed. 
That is, if a target type of a conditional expression is known, the types of consequent and alternative must be implicitly convertible to the target type.

Nested Ternary Operators:
You can nest ternary operators to handle multiple conditions, but be cautious as it can make the code harder to read.
The conditional operator is right-associative, that is, an expression of the form
a ? b : c ? d : e
is evaluated as
a ? b : (c ? d : e)

Conditional ref expression
A conditional ref expression conditionally returns a variable reference
Syntax :
condition ? ref consequent : ref alternative

Conditional operator and an if statement
Use of the conditional operator instead of an if statement might result in more concise code in cases when you need conditionally to compute a value. 

Notes: 
Sometimes Ternary Operator is bit faster than Condition if-else statement.

Operator overloadability
A user-defined type can't overload the conditional operator.

**/
namespace TernaryOperator{
    class TernaryOperator{
        public static void Main(){
            Console.WriteLine("Ternary Operator. ");

            string GetWeatherDisplay(double tempInCelsius) => tempInCelsius < 20.0 ? "Cold." : "Perfect!";

            Console.WriteLine(GetWeatherDisplay(15));  // output: Cold.
            Console.WriteLine(GetWeatherDisplay(27));  // output: Perfect!

            var rand = new Random();
            var condition = rand.NextDouble() > 0.5;

            int? x = condition ? 12 : null;

            IEnumerable<int> xs = x is null ? new List<int>() { 0, 1 } : new int[] { 2, 3 };
            //If a target type of a conditional expression is unknown (for example, when you use the var keyword) or the type of consequent and alternative must be the same or there must be an implicit conversion from one type to the other:

            int[] smallArray = {1, 2, 3, 4, 5};
            int[] largeArray = {10, 20, 30, 40, 50};

            int index = 7;
            ref int refValue = ref ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]);
            refValue = 0;

            index = 2;
            ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]) = 100;

            Console.WriteLine(string.Join(" ", smallArray));
            Console.WriteLine(string.Join(" ", largeArray));
            // Output:
            // 1 2 100 4 5
            // 10 20 0 40 50

            int input = new Random().Next(-5, 5);

            string classify;
            if (input >= 0)
            {
                classify = "nonnegative";
            }
            else
            {
                classify = "negative";
            }

            classify = (input >= 0) ? "nonnegative" : "negative";




        }
    }
}