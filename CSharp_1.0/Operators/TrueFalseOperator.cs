using System;
/**
In C#, you can define custom true and false operators for your classes or structs to allow instances of those types to be treated as Boolean values. This can be useful in scenarios where you want to provide a meaningful way to evaluate the truthiness or falsiness of an object.

Defining true and false Operators
To define these operators, you need to implement the true and false operators in your class or struct.

Explanation
true Operator: This operator should return true if the object meets the criteria for being considered true. In this example, the object is considered true if it is not null and its IsValid property is true.
false Operator: This operator should return true if the object meets the criteria for being considered false. In this example, the object is considered false if it is null or its IsValid property is false.

The true operator returns the bool value true to indicate that its operand is definitely true, while the false operator returns the bool value true to indicate that its operand is definitely false.

the true and false operators are not required to complement each other perfectly. This means that both operators can return false for the same operand. However, if a type defines one of these operators, it must also define the other to ensure that the type can be evaluated in Boolean contexts.

Explanation
Non-Complementary Behavior: The true and false operators can both return false for the same operand. This allows for more nuanced control over how an object is evaluated in Boolean contexts. For example, an object might not meet the criteria for being considered true, but it also might not meet the criteria for being considered false.

Requirement to Define Both Operators: If a type defines the true operator, it must also define the false operator, and vice versa. This requirement ensures that the type can be used in Boolean expressions, such as if statements, without causing ambiguity.

Boolean expressions
A type with the defined true operator can be the type of a result of a controlling conditional expression in the if, do, while, and for statements and in the conditional operator ?:.

User-defined conditional logical operators
If a type with the defined true and false operators overloads the logical OR operator | or the logical AND operator & in a certain way, the conditional logical OR operator || or conditional logical AND operator &&, respectively, can be evaluated for the operands of that type.

Note that a type implementing both true and false operators has to follow these semantics:
"Is this object true?" resolves to operator true. Operator true returns true if the object is true. The answer is "Yes, this object is true".
"Is this object false?" resolves to operator false. Operator false returns true if the object is false. The answer is "Yes, this object is false"


**/
namespace TrueFalseOperator{

    public class MyClass
    {
        public bool IsValid { get; set; }

        public static bool operator true(MyClass obj)
        {
            return obj != null && obj.IsValid;
        }

        public static bool operator false(MyClass obj)
        {
            return obj == null || !obj.IsValid;
        }
    }

    public struct LaunchStatus
    {
        public static readonly LaunchStatus Green = new LaunchStatus(0);
        public static readonly LaunchStatus Yellow = new LaunchStatus(1);
        public static readonly LaunchStatus Red = new LaunchStatus(2);

        private int status;

        private LaunchStatus(int status)
        {
            this.status = status;
        }

        public static bool operator true(LaunchStatus x) => x == Green || x == Yellow;
        public static bool operator false(LaunchStatus x) => x == Red;

        public static LaunchStatus operator &(LaunchStatus x, LaunchStatus y)
        {
            if (x == Red || y == Red || (x == Yellow && y == Yellow))
            {
                return Red;
            }

            if (x == Yellow || y == Yellow)
            {
                return Yellow;
            }

            return Green;
        }

        public static bool operator ==(LaunchStatus x, LaunchStatus y) => x.status == y.status;
        public static bool operator !=(LaunchStatus x, LaunchStatus y) => !(x == y);

        public override bool Equals(object obj) => obj is LaunchStatus other && this == other;
        public override int GetHashCode() => status;
    }

    class TrueFalseOperatorClass{
        public static void Main(){
            Console.WriteLine("True False operator .");

            MyClass myObject = new MyClass { IsValid = true };

            if (myObject)
            {
                Console.WriteLine("Object is valid.");
            }

            do
            {
                Console.WriteLine("In do-while loop.");
                myObject.IsValid = false; // Change condition to exit loop
            } while (myObject);

            myObject.IsValid = true; // Reset condition

            while (myObject)
            {
                Console.WriteLine("In while loop.");
                myObject.IsValid = false; // Change condition to exit loop
            }

            for (MyClass obj = new MyClass { IsValid = true }; obj; obj.IsValid = false)
            {
                Console.WriteLine("In for loop.");
            }

            var result = myObject ? "Object is true" : "Object is false";
            Console.WriteLine(result);

            LaunchStatus okToLaunch = GetFuelLaunchStatus() && GetNavigationLaunchStatus();
            Console.WriteLine(okToLaunch ? "Ready to go!" : "Wait!");

        }

        static LaunchStatus GetFuelLaunchStatus()
        {
            Console.WriteLine("Getting fuel launch status...");
            return LaunchStatus.Red;
        }

        static LaunchStatus GetNavigationLaunchStatus()
        {
            Console.WriteLine("Getting navigation launch status...");
            return LaunchStatus.Yellow;
        }

    }
}