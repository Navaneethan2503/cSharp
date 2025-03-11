using System;
/**
Selection Statement :
The if, if-else and switch statements select statements to execute from many possible paths based on the value of an expression. 
The if statement executes a statement only if a provided Boolean expression evaluates to true. 
The if-else statement allows you to choose which of the two code paths to follow based on a Boolean expression. 
The switch statement selects a statement list to execute based on a pattern match with an expression.

1. if Statement
The if statement executes a block of code if a specified condition is true.
2. if-else Statement
The if-else statement provides an alternative block of code to execute if the condition is false.
3. else if Ladder
The else if ladder allows you to check multiple conditions sequentially.
4. switch Statement
The switch statement selects a block of code to execute from multiple options based on the value of an expression.

Key Points to Remember
Conditions: Conditions in if, else if, and switch statements must evaluate to a boolean value (true or false).
Break Statement: In a switch statement, the break statement is used to exit the switch block after a case is executed.
Default Case: The default case in a switch statement is executed if none of the specified cases match the expression.

Switch:
the switch statement uses the following patterns:

A relational pattern: to compare an expression result with a constant.
A constant pattern: test if an expression result equals a constant.

The default case specifies statements to execute when a match expression doesn't match any other case pattern. If a match expression doesn't match any case pattern and there's no default case, control falls through a switch statement.

A switch statement executes the statement list in the first switch section whose case pattern matches a match expression and whose case guard, if present, evaluates to true. A switch statement evaluates case patterns in text order from top to bottom. The compiler generates an error when a switch statement contains an unreachable case. That is a case that is already handled by an upper case or whose pattern is impossible to match.

The default case can appear in any place within a switch statement. Regardless of its position, the default case is evaluated only if all other case patterns aren't matched or the goto default; statement is executed in one of the switch sections.

Within a switch statement, control can't fall through from one switch section to the next. As the examples in this section show, typically you use the break statement at the end of each switch section to pass control out of a switch statement. You can also use the return and throw statements to pass control out of a switch statement. To imitate the fall-through behavior and pass control to other switch section, you can use the goto statement.

Every switch section must end with a break, goto or return. Falling through from one switch section to the next generates a compiler error. However, multiple switch labels can be applied to the same switch section, like case < 0: in example above. This deliberate design choice allows for concisely handling multiple cases that share the same or interdependent logic.

Differences between switch expression and switch statement:

switch statement is used to control the execution flow within a block of code.
switch expression is typically used in contexts of value return and value assignment, often as a expression-bodied members.
a switch expression case section cannot be empty, a switch statement can.

Case guards
A case pattern may not be expressive enough to specify the condition for the execution of the switch section. In such a case, you can use a case guard. That is an additional condition that must be satisfied together with a matched pattern. A case guard must be a Boolean expression. You specify a case guard after the when keyword that follows a pattern,
Case guards in a switch statement are additional conditions that can be applied to a case to further refine when that case should be executed. They are specified using the when keyword followed by a condition.

case (> 0, > 0) when a == b:
            Console.WriteLine($"Both measurements are valid and equal to {a}.");
            break;

you can use various patterns in a switch expression to evaluate and match different cases. Here are the main types of patterns you can use:

1. Constant Pattern
Matches a constant value.

switch (number)
{
    case 1:
        Console.WriteLine("One");
        break;
    case 2:
        Console.WriteLine("Two");
        break;
    default:
        Console.WriteLine("Other number");
        break;
}
2. Type Pattern
Matches a specific type.

object obj = "Hello";
switch (obj)
{
    case int i:
        Console.WriteLine($"Integer: {i}");
        break;
    case string s:
        Console.WriteLine($"String: {s}");
        break;
    default:
        Console.WriteLine("Other type");
        break;
}
3. Relational Pattern
Matches based on relational operators.

switch (number)
{
    case > 0:
        Console.WriteLine("Positive number");
        break;
    case < 0:
        Console.WriteLine("Negative number");
        break;
    default:
        Console.WriteLine("Zero");
        break;
}
4. Logical Pattern
Combines patterns using logical operators (and, or, not).

switch (number)
{
    case > 0 and < 10:
        Console.WriteLine("Single-digit positive number");
        break;
    case >= 10:
        Console.WriteLine("Double-digit or larger positive number");
        break;
    default:
        Console.WriteLine("Non-positive number");
        break;
}
5. Property Pattern
Matches based on properties of an object.

switch (person)
{
    case { Age: > 18 }:
        Console.WriteLine("Adult");
        break;
    case { Age: <= 18 }:
        Console.WriteLine("Minor");
        break;
    default:
        Console.WriteLine("Unknown age");
        break;
}
6. Positional Pattern
Matches based on the position of elements in a deconstructed object.

switch (point)
{
    case (0, 0):
        Console.WriteLine("Origin");
        break;
    case (var x, 0):
        Console.WriteLine($"On the X-axis at {x}");
        break;
    case (0, var y):
        Console.WriteLine($"On the Y-axis at {y}");
        break;
    default:
        Console.WriteLine("Somewhere else");
        break;
}
7. Var Pattern
Matches any value and assigns it to a variable.

switch (obj)
{
    case var x:
        Console.WriteLine($"Matched value: {x}");
        break;
}

**/
namespace SelectionStatement{
    class SelectionStatementClass{

        void PrintTemp(double measurement){
            switch(measurement){
                case < 0.0:
            Console.WriteLine($"Measured value is {measurement}; too low.");
            break;

        case > 15.0:
            Console.WriteLine($"Measured value is {measurement}; too high.");
            break;

        case double.NaN:
            Console.WriteLine("Failed measurement.");
            break;

        default:
            Console.WriteLine($"Measured value is {measurement}.");
            break;
            }
        }

        void DisplayMeasurements(int a, int b)
        {
            switch ((a, b))
            {
                case (> 0, > 0) when a == b:
                    Console.WriteLine($"Both measurements are valid and equal to {a}.");
                    break;

                case (> 0, > 0):
                    Console.WriteLine($"First measurement is {a}, second measurement is {b}.");
                    break;

                default:
                    Console.WriteLine("One or both measurements are not valid.");
                    break;
            }
        }

        struct ExampleStruct{
            public int Age { get; set; }
        }


        public static void Main(){
            Console.WriteLine("Selection Statement");
            int num = 100;
            //Single if condition that can be used to evaluate
            if(num >= 100){
                Console.WriteLine("num is Hunder .");
            }

            //if else part condition
            int num1 = 5;
            if(num>0){
                Console.WriteLine("Number {0} is Positive Numbers.", num1);
            }
            else{
                Console.WriteLine("Number {0} is Negative Number.", num1);
            }

            //multiple condition
            int num2 = 1000;
            if(num2 > 0){
                Console.WriteLine("Number is greater then 0.");
            }
            else if(num2 > 10){
                Console.WriteLine("Number is greater than 10.");
            }
            else if(num2 > 50){
                Console.WriteLine("Number is greater than 50.");
            }
            else{
                Console.WriteLine("Number not greater than 0.");
            }
            SelectionStatementClass obj = new SelectionStatementClass();
            obj.PrintTemp(1.0);
            obj.PrintTemp(3.0);
            obj.PrintTemp(-1.0);

            obj.DisplayMeasurements(3, 4);  // Output: First measurement is 3, second measurement is 4.
            obj.DisplayMeasurements(5, 5);  // Output: Both measurements are valid and equal to 5.

            //Type Pattern
            object on = num;
            switch(on){
                case int i:
                    Console.WriteLine("Interger");
                    break;
                case string s:
                    Console.WriteLine("String");
                    break;
            }

            ExampleStruct es = new ExampleStruct();
            es.Age = 24;

            //Property Pattern
            switch(es){
                case { Age: > 18}:
                    Console.WriteLine("Major Completed.");
                    break;
                case { Age: <= 10}:
                    Console.WriteLine("Minor Ongoing");
                    break;
                    //break; - without break Error - Control cannot fall through from one case label ('case { Age: <= 10}:') to another
                case { Age: <= 18}:
                    Console.WriteLine("Major not Completed.");
                    break;//Control cannot fall out of switch from final case label ('case { Age: <= 18}:')
            }

            int x = -3, y = 10;
            //position pattern
            switch(x,y){
                case (0,0):
                    Console.WriteLine("Origin");
                    break;
                case ( > 1, < 0):
                    Console.WriteLine("Down Groght");
                    return;
                case ( < 0, > 0 ):
                    Console.WriteLine("goto");
                    //goto case (0,0);
                    break;
                case ( > 0, < 0):
                    Console.WriteLine("Came to goto");
                    break;
            }
        }
    }
}