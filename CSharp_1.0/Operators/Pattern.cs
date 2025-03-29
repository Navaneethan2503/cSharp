using System;
using System.Collections;
using System.Collections.Generic;
/**
Declaration and type patterns :
You use declaration and type patterns to check if the run-time type of an expression is compatible with a given type. 
With a declaration pattern, you can also declare a new local variable. 
When a declaration pattern matches an expression, that variable is assigned a converted expression result,

A declaration pattern with type T matches an expression when an expression result is non-null and any of the following conditions are true:
1. The run-time type of an expression result is T.
This means that the actual type of the object at runtime is exactly T.
2. The Type T is a ref struct Type and There is an Identity Conversion from the Expression to T:
A ref struct is a special type of structure that is allocated on the stack. An identity conversion means that the source type and the target type are the same.
3. The Run-Time Type of an Expression Result Derives from Type T, Implements Interface T, or Another Implicit Reference Conversion Exists from it to T:
This means that the runtime type of the object is either a subclass of T, implements the interface T, or there is another implicit reference conversion.
4. The Run-Time Type of an Expression Result is a Nullable Value Type with the Underlying Type T:
This means that the object is a nullable value type, and its underlying type is T.

Constant pattern :
The constant pattern is an alternative syntax for == when the right operand is a constant. 
You use a constant pattern to test if an expression result equals a specified constant, as the following example shows:

In a constant pattern, you can use any constant expression, such as:

an integer or floating-point numerical literal
a char
a string literal.
a Boolean value true or false
an enum value
the name of a declared const field or local
null

No Overloading Operator Invoked :
The compiler guarantees that no user-overloaded equality operator == is invoked when expression x is null is evaluated.
 
------------------------------------------
Precedence and order of checking:
The pattern combinators are ordered based on the binding order of expressions as follows:

not
and
or
The not pattern binds to its operand first. The and pattern binds after any not pattern expression binding. The or pattern binds after all not and and patterns are bound to operands

---------
Property Pattern :
You can also extend a positional pattern in any of the following ways:

Add a run-time type check and a variable declaration, as the following example shows:
public record Point2D(int X, int Y);
public record Point3D(int X, int Y, int Z);

static string PrintIfAllCoordinatesArePositive(object point) => point switch
{
    Point2D (> 0, > 0) p => p.ToString(),
    Point3D (> 0, > 0, > 0) p => p.ToString(),
    _ => string.Empty,
};
The preceding example uses positional records that implicitly provide the Deconstruct method.

Use a property pattern within a positional pattern, as the following example shows:
public record WeightedPoint(int X, int Y)
{
    public double Weight { get; set; }
}

static bool IsInDomain(WeightedPoint point) => point is (>= 0, >= 0) { Weight: >= 0.0 };
Combine two preceding usages, as the following example shows:
if (input is WeightedPoint (> 0, > 0) { Weight: > 0.0 } p)
{
    // ..
}
A positional pattern is a recursive pattern. That is, you can use any pattern as a nested pattern.

---------------------
Var Pattern :
Var Pattern Matched any value and assign it to variable

--------------------
Discard Pattern:
You use a discard pattern _ to match any expression, including null, as the following example shows:
A discard pattern can't be a pattern in an is expression or a switch statement. 
In those cases, to match any expression, use a var pattern with a discard: var _. 
A discard pattern can be a pattern in a switch expression.



**/
namespace Pattern{

    public interface IAnimal { }
    public class Dog : IAnimal { }

    public abstract class Vehicle {}
    public class Car : Vehicle {}
    public class Truck : Vehicle {}

    public static class TollCalculator
    {
        //If you want to check only the type of an expression, you can use a discard _ in place of a variable's name, as the following example shows:
        public static decimal CalculateToll(this Vehicle vehicle) => vehicle switch
        {
            Car _ => 2.00m,
            Truck _ => 7.50m,
            null => throw new ArgumentNullException(nameof(vehicle)),
            _ => throw new ArgumentException("Unknown type of a vehicle", nameof(vehicle)),
        };

        //For that purpose you can use a type pattern
        public static decimal CalculateToll1(this Vehicle vehicle) => vehicle switch
        {
            Car => 2.00m,
            Truck => 7.50m,
            null => throw new ArgumentNullException(nameof(vehicle)),
            _ => throw new ArgumentException("Unknown type of a vehicle", nameof(vehicle)),
        };
    }

    
    class PatternClass{

        //A property pattern is a recursive pattern. You can use any pattern as a nested pattern. Use a property pattern to match parts of data against nested patterns, as the following example shows:
        public readonly struct Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) => (X, Y) = (x, y);

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        }

        public record Segment(Point Start, Point End);

        static bool IsAnyEndOnXAxis(Segment segment) =>
            segment is { Start: { Y: 0 } } or { End: { Y: 0 } };

        //You can reference nested properties or fields within a property pattern. This capability is known as an extended property pattern. 
        static bool IsAnyEndOnXAxis1(Segment segment) =>
            segment is { Start.Y: 0 } or { End.Y: 0 };

        public static void Main(){
            Console.WriteLine("Pattern :");

            //Declaration Pattern
            object message = "Hello World!";
            if(message is string str){
                Console.WriteLine(str);
            }

            //Runtime Type Expression Derives from type T
            IAnimal animal = new Dog();
            if (animal is Dog d)
            {
                Console.WriteLine("It's a dog!"); // Output: It's a dog!
            }

            //The Run-Time Type of an Expression Result is a Nullable Value Type with the Underlying Type T
            int? nullableInt = 5;
            if (nullableInt is int value)
            {
                Console.WriteLine(value); // Output: 5
            }

            int? xNullable = 7;
            int y = 23;
            object yBoxed = y;
            if (xNullable is int a && yBoxed is int b)
            {
                Console.WriteLine(a + b);  // output: 30
            }

            // Relational patterns
            // You use a relational pattern to compare an expression result with a constant, as the following example shows:
            Console.WriteLine("Relational Pattern :");
            Console.WriteLine(Classify(13));  // output: Too high
            Console.WriteLine(Classify(double.NaN));  // output: Unknown
            Console.WriteLine(Classify(2.4));  // output: Acceptable

            static string Classify(double measurement) => measurement switch
            {
                < -4.0 => "Too low",
                > 10.0 => "Too high",
                double.NaN => "Unknown",
                _ => "Acceptable",
            };

            //In a relational pattern, you can use any of the relational operators <, >, <=, or >=. The right-hand part of a relational pattern must be a constant expression. The constant expression can be of an integer, floating-point, char, or enum type.
            //To check if an expression result is in a certain range, match it against a conjunctive and pattern, as the following example shows:
            Console.WriteLine(GetCalendarSeason(new DateTime(2021, 3, 14)));  // output: spring
            Console.WriteLine(GetCalendarSeason(new DateTime(2021, 7, 19)));  // output: summer
            Console.WriteLine(GetCalendarSeason(new DateTime(2021, 2, 17)));  // output: winter

            static string GetCalendarSeason(DateTime date) => date.Month switch
            {
                >= 3 and < 6 => "spring",
                >= 6 and < 9 => "summer",
                >= 9 and < 12 => "autumn",
                12 or (>= 1 and < 3) => "winter",
                _ => throw new ArgumentOutOfRangeException(nameof(date), $"Date with unexpected month: {date.Month}."),
            };

            //Precedence and Order of Checking
            // Incorrect pattern. `not` binds before `and`
            static bool IsNotLowerCaseLetter(char c) => c is not >= 'a' and <= 'z';

            // Incorrect pattern. `not` binds before `and`
            static bool IsNotLowerCaseLetter1(char c) => c is not >= 'a' and <= 'z';

            //To fix it, you must specify that you want the not to bind to the >= 'a' and <= 'z' expression:
            // Correct pattern. Force `and` before `not`
            static bool IsNotLowerCaseLetterParentheses(char c) => c is not (>= 'a' and <= 'z');

            //Adding parentheses becomes more important as your patterns become more complicated. In general, use parentheses to clarify your patterns for other developers, as the following example shows:
            static bool IsLetter(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');

            //Property pattern
            //You use a property pattern to match an expression's properties or fields against nested patterns, as the following example shows:
            static bool IsConferenceDay(DateTime date) => date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };
            Console.WriteLine("Is Conference Today :"+ IsConferenceDay(DateTime.Now));

            //You can also add a run-time type check and a variable declaration to a property pattern, as the following example shows:
            Console.WriteLine(TakeFive("Hello, world!"));  // output: Hello
            Console.WriteLine(TakeFive("Hi!"));  // output: Hi!
            Console.WriteLine(TakeFive(new[] { '1', '2', '3', '4', '5', '6', '7' }));  // output: 12345
            Console.WriteLine(TakeFive(new[] { 'a', 'b', 'c' }));  // output: abc

            static string TakeFive(object input) => input switch
            {
                string { Length: >= 5 } s => s.Substring(0, 5),
                string s => s,

                ICollection<char> { Count: >= 5 } symbols => new string(symbols.ToString()),
                ICollection<char> symbols => new string(symbols.ToString()),

                null => throw new ArgumentNullException(nameof(input)),
                _ => throw new ArgumentException("Not supported input type."),
            };

            //Positional pattern
            //You use a positional pattern to deconstruct an expression result and match the resulting values against the corresponding nested patterns, as the following example shows:
            Console.WriteLine("Positional Pattern :"+Classify1(new Point(0,0)));
            static string Classify1(Point point) => point switch
            {
                (0, 0) => "Origin",
                (1, 0) => "positive X basis end",
                (0, 1) => "positive Y basis end",
                _ => "Just a point",
            };

            //You can also match expressions of tuple types against positional patterns. In that way, you can match multiple inputs against various patterns, as the following example shows:
            static decimal GetGroupTicketPriceDiscount(int groupSize, DateTime visitDate) => (groupSize, visitDate.DayOfWeek) switch
            {
                (<= 0, _) => throw new ArgumentException("Group size must be positive."),
                (_, DayOfWeek.Saturday or DayOfWeek.Sunday) => 0.0m,
                (>= 5 and < 10, DayOfWeek.Monday) => 20.0m,
                (>= 10, DayOfWeek.Monday) => 30.0m,
                (>= 5 and < 10, _) => 12.0m,
                (>= 10, _) => 15.0m,
                _ => 0.0m,
            };

            //You can use the names of tuple elements and Deconstruct parameters in a positional pattern,
            var numbers = new List<int> { 1, 2, 3 };
            if (SumAndCount(numbers) is (Sum: var sum, Count: > 0))
            {
                Console.WriteLine($"Sum of [{string.Join(" ", numbers)}] is {sum}");  // output: Sum of [1 2 3] is 6
            }

            static (double Sum, int Count) SumAndCount(IEnumerable<int> numbers)
            {
                int sum = 0;
                int count = 0;
                foreach (int number in numbers)
                {
                    sum += number;
                    count++;
                }
                return (sum, count);
            }

            //Var Pattern
            object obj = 42;
            if (obj is var value1)
            {
                Console.WriteLine("Var Pattern :"+value1); // Output: 42
                if(value1 is int num){
                    Console.WriteLine("It is Integer");
                }
            }

            //A var pattern is useful when you need a temporary variable within a Boolean expression to hold the result of intermediate calculations. 
            // You can also use a var pattern when you need to perform more checks in when case guards of a switch expression or statement, as the following example shows:
            static Point Transform(Point point) => point switch
            {
                var (x, y) when x < y => new Point(-x, y),
                var (x, y) when x > y => new Point(x, -y),
                var (x, y) => new Point(x, y),
            };

            Console.WriteLine(Transform(new Point(1, 2)));  // output: Point { X = -1, Y = 2 }
            Console.WriteLine(Transform(new Point(5, 2)));  // output: Point { X = 5, Y = -2 }

            //Discard Pattern
            //You use a discard pattern _ to match any expression, including null, as the following example shows:
            Console.WriteLine(GetDiscountInPercent(DayOfWeek.Friday));  // output: 5.0
            Console.WriteLine(GetDiscountInPercent(null));  // output: 0.0
            Console.WriteLine(GetDiscountInPercent((DayOfWeek)10));  // output: 0.0

            static decimal GetDiscountInPercent(DayOfWeek? dayOfWeek) => dayOfWeek switch
            {
                DayOfWeek.Monday => 0.5m,
                DayOfWeek.Tuesday => 12.5m,
                DayOfWeek.Wednesday => 7.5m,
                DayOfWeek.Thursday => 12.5m,
                DayOfWeek.Friday => 5.0m,
                DayOfWeek.Saturday => 2.5m,
                DayOfWeek.Sunday => 2.0m,
                _ => 0.0m,
            };


            //Parenthesized pattern
            //You can put parentheses around any pattern. Typically, you do that to emphasize or change the precedence in logical patterns, as the following example shows:
            object input = "cat";
            if (input is not (float or double))
            {
                Console.WriteLine("Input is not float or double :" + input);
            }

            //List patterns
            //Beginning with C# 11, you can match an array or a list against a sequence of patterns, as the following example shows:
            int[] numberss = { 1, 2, 3 };

            Console.WriteLine(numberss is [1, 2, 3]);  // True
            Console.WriteLine(numberss is [1, 2, 4]);  // False
            Console.WriteLine(numberss is [1, 2, 3, 4]);  // False
            Console.WriteLine(numberss is [0 or 1, <= 2, >= 3]);  // True
            Console.WriteLine("Using Discard and Range Operator in Pattern :"+(numberss is [..,2,_]));

            //As the preceding example shows, a list pattern is matched when each nested pattern matches the corresponding element of an input sequence. You can use any pattern within a list pattern. 
            // To match any element, use the discard pattern or, if you also want to capture the element, the var pattern, as the following example shows:
            //List<int> numbers = new() { 1, 2, 3 };

            if (numberss is [var first, _, _])
            {
                Console.WriteLine($"The first element of a three-item list is {first}.");
            }
            // Output:
            // The first element of a three-item list is 1.

            //The preceding examples match a whole input sequence against a list pattern. 
            // To match elements only at the start or/and the end of an input sequence, use the slice pattern .., as the following example shows:\
            Console.WriteLine(new[] { 1, 2, 3, 4, 5 } is [> 0, > 0, ..]);  // True
            Console.WriteLine(new[] { 1, 1 } is [_, _, ..]);  // True
            Console.WriteLine(new[] { 0, 1, 2, 3, 4 } is [> 0, > 0, ..]);  // False
            Console.WriteLine(new[] { 1 } is [1, 2, ..]);  // False

            Console.WriteLine(new[] { 1, 2, 3, 4 } is [.., > 0, > 0]);  // True
            Console.WriteLine(new[] { 2, 4 } is [.., > 0, 2, 4]);  // False
            Console.WriteLine(new[] { 2, 4 } is [.., 2, 4]);  // True

            Console.WriteLine(new[] { 1, 2, 3, 4 } is [>= 0, .., 2 or 4]);  // True
            Console.WriteLine(new[] { 1, 0, 0, 1 } is [1, 0, .., 0, 1]);  // True
            Console.WriteLine(new[] { 1, 0, 1 } is [1, 0, .., 0, 1]);  // False

            //A slice pattern matches zero or more elements. You can use at most one slice pattern in a list pattern. The slice pattern can only appear in a list pattern.
            //You can also nest a subpattern within a slice pattern, as the following example shows:
            void MatchMessage(string message)
            {
                var result = message is ['a' or 'A', .. var s, 'a' or 'A']
                    ? $"Message {message} matches; inner part is {s}."
                    : $"Message {message} doesn't match.";
                Console.WriteLine(result);
            }

            MatchMessage("aBBA");  // output: Message aBBA matches; inner part is BB.
            MatchMessage("apron");  // output: Message apron doesn't match.

            void Validate(int[] numbers)
            {
                var result = numbers is [< 0, .. { Length: 2 or 4 }, > 0] ? "valid" : "not valid";
                Console.WriteLine(result);
            }

            Validate(new[] { -1, 0, 1 });  // output: not valid
            Validate(new[] { -1, 0, 0, 1 });  // output: valid
        }

        
    }
}