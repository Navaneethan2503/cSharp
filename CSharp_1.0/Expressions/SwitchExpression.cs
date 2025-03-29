using System;
/**
Switch expressions in C# are a powerful feature introduced in C# 8.0 that allow you to perform pattern matching and return values based on different cases in a concise and readable manner. 
They are an enhancement over traditional switch statements, providing a more functional approach to conditional logic.

Basic Syntax:
The basic syntax of a switch expression is as follows:

var result = expression switch
{
    pattern1 => value1,
    pattern2 => value2,
    ...
    _ => defaultValue // Default case
};

Key Features:
Pattern Matching: Switch expressions support various patterns, including constant patterns, type patterns, and property patterns.
Expression-Based: Unlike traditional switch statements, switch expressions return a value, making them suitable for use in expressions.
Concise Syntax: Switch expressions provide a more concise and readable syntax compared to traditional switch statements.

Practical Applications:
Data Transformation: Switch expressions can be used to transform data based on different conditions.
Conditional Logic: They simplify complex conditional logic, making the code more readable and maintainable.
Pattern Matching: Switch expressions leverage pattern matching to handle different types and shapes of data.

When to Use Each:
Use Switch Statement:

When you need to execute multiple statements or perform side effects.
When the logic is complex and involves multiple steps.
When you need to handle fall-through cases (though this is generally discouraged).
Use Switch Expression:

When you need to return a value based on conditions.
When the logic is simple and can be expressed concisely.
When you prefer a more functional programming style.

-------------------------------------------
Case gaurd:
 In a switch expression, the result is determined by the first arm that matches the input expression and whose case guard (if any) evaluates to true. 
 The arms are evaluated in the order they appear in the code.

A pattern may be not expressive enough to specify the condition for the evaluation of an arm's expression. 
In such a case, you can use a case guard. A case guard is another condition that must be satisfied together with a matched pattern. 
A case guard must be a Boolean expression


------------------------------------------------
Non-exhaustive switch expressions :
If none of a switch expression's patterns matches an input value, the runtime throws an exception. 
In .NET Core 3.0 and later versions, the exception is a System.Runtime.CompilerServices.SwitchExpressionException. In .NET Framework, the exception is an InvalidOperationException. 
In most cases, the compiler generates a warning if a switch expression doesn't handle all possible input values. 
List patterns don't generate a warning when all possible inputs aren't handled.

To guarantee that a switch expression handles all possible input values, provide a switch expression arm with a discard pattern.


**/
namespace SwitchExpression{
    public enum Traffic{
        Red,
        Green,
        Orange,
        Police
    }

    class SwitchExpressionClass{

        class Person{
            public string Name { get; set; }

            public int Age { get; set; }

            public Person(string n, int a){
                this.Name = n;
                this.Age = a;
            }
        }

        class Car{
            public string Color { get; set; }

            public int Wheel { get; set; }
        }

        public readonly struct Point
        {
            public Point(int x, int y) => (X, Y) = (x, y);
            
            public int X { get; }
            public int Y { get; }
        }

        static Point Transform(Point point) => point switch
        {
            { X: 0, Y: 0 }                    => new Point(0, 0),
            { X: var x, Y: var y } when x < y => new Point(x + y, y),
            { X: var x, Y: var y } when x > y => new Point(x - y, y),
            { X: var x, Y: var y }            => new Point(2 * x, 2 * y),
        };

        public static void Main(){
            Console.WriteLine("Switch Expression :");

            //Constant Pattern
            Traffic t = Traffic.Police;
            Traffic t1 = (Traffic)10;
            var mesg = t1 switch{
                Traffic.Red => "Stop",
                Traffic.Green => "Go",
                Traffic.Orange => "Wait",
                _ => "No Relavent Options"
            };
            Console.WriteLine(t1 + " - "+ mesg);

            //Type Pattern
            object name = "nickil";
            object number = 100;
            var res = number switch{
                string a => "name",
                int b => $"integer - {b+5}",
                _ => "Default Value"
            };
            Console.WriteLine(res);

            //Property Pattern
            Person p1 = new Person("navaneethan", 24);
            var mesgs = p1 switch{
                { Age : > 18 and <= 45 } => "Adult",
                { Name:"nickil" , Age: 18 } => "Welcome Nickil",
                _ => "Nothing Pops up"
            };
            Console.WriteLine(mesgs);

            //Combine Pattern
            object p2 = new Person("nickil",18);
            object c1 = new Car{ Color = "White", Wheel = 4};
            var resMesg = c1 switch{
                Person{ Name: "nickil", Age: >= 18 and <= 25 } => "Major Person",
                Car{ Color: "White", Wheel: >= 4} => "Good Model Car",
                _ => "None of the Options"
            };
            Console.WriteLine(resMesg);

            //Case gaurd
            int number1 = 15;
            string result = number1 switch
            {
                _ when number1 % 2 == 0 => "Even",
                _ when number1 % 3 == 0 => "Divisible by 3",
                _ => "Other"
            };

            Console.WriteLine(result); // Output: Divisible by 3
            //In this example:

            // The first arm checks if the number is even. Since 15 is not even, this arm is skipped.
            // The second arm checks if the number is divisible by 3. Since 15 is divisible by 3, this arm matches, and "Divisible by 3" is returned.
            // The third arm is the default case, which would be used if none of the previous arms matched.


        }
    }
}