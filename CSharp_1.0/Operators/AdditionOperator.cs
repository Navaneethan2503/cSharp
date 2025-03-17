using System;
/**
String concatenation
When one or both operands are of type string, the + operator concatenates the string representations of its operands (the string representation of null is an empty string):

You can use string interpolation to initialize a constant string when all the expressions used for placeholders are also constant strings.

Beginning with C# 11, the + operator performs string concatenation for UTF-8 literal strings. This operator concatenates two ReadOnlySpan<byte> objects.

----------------------------
Delegate combination
For operands of the same delegate type, the + operator returns a new delegate instance that, when invoked, invokes the left-hand operand and then invokes the right-hand operand. 
If any of the operands is null, the + operator returns the value of another operand (which also might be null).


Operator overloadability
A user-defined type can overload the + operator. When a binary + operator is overloaded, the += operator is also implicitly overloaded. A user-defined type can't explicitly overload the += operator.


**/
namespace AdditionOperator{
    class AdditionOperator{
        public static void Main(){
            Console.WriteLine("Addition Operator .");
            Console.WriteLine("Forgot" + "white space");
            Console.WriteLine("Probably the oldest constant: " + 3.14159265358979);
            Console.WriteLine(null + "Nothing to add.");
            // Output:
            // Forgotwhite space
            // Probably the oldest constant: 3.14159265358979
            // Nothing to add.

            //String interpolation provides a more convenient way to format strings:
            Console.WriteLine($"Probably the oldest constant: {Math.PI:F2}");
            // Output:
            // Probably the oldest constant: 3.14

            //Delegate Combination
            Action a = () => Console.WriteLine("Delegate a");
            Action b = () => Console.WriteLine("Delegate b");
            Action ab = a+b;
            ab();

            //+= operator
            int i = 5;
            i += 9;
            Console.WriteLine(i);
            // Output: 14

            string story = "Start. ";
            story += "End.";
            Console.WriteLine(story);
            // Output: Start. End.

            Action printer = () => Console.Write("a");
            printer();  // output: a

            Console.WriteLine();
            printer += () => Console.Write("b");
            printer();  // output: ab


        }
    }
}