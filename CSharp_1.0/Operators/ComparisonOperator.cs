using System;
/**
The < (less than), > (greater than), <= (less than or equal), and >= (greater than or equal) comparison, also known as relational, operators compare their operands. 
Those operators are supported by all integral and floating-point numeric types.

For the ==, <, >, <=, and >= operators, if any of the operands is not a number (Double.NaN or Single.NaN), the result of operation is false. 
That means that the NaN value is neither greater than, less than, nor equal to any other double (or float) value, including NaN.

The char type also supports comparison operators. In the case of char operands, the corresponding character codes are compared.

Enumeration types also support comparison operators. For operands of the same enum type

The == and != operators check if their operands are equal or not.

---------------------
Less than operator < :
The < operator returns true if its left-hand operand is less than its right-hand operand, false otherwise.

----------------------------
Greater than operator >
The > operator returns true if its left-hand operand is greater than its right-hand operand, false otherwise.

----------------------------
Less than or equal operator <=
The <= operator returns true if its left-hand operand is less than or equal to its right-hand operand, false otherwise.

--------------------------------
Greter than or Equal to >= :
The >= operator returns true if its left-hand operand is greater than or equal to its right-hand operand, false otherwise:

Operator Precedence
Comparison operators have lower precedence than arithmetic and bitwise operators but higher precedence than logical operators (&&, ||).

Important Considerations:
Type Compatibility: Ensure that the types of the operands are compatible for comparison. For example, comparing an integer with a string directly will result in a type error.
Floating-Point Comparisons: Be cautious when comparing floating-point numbers due to potential precision issues. It's often better to check if the difference between the numbers is within a small tolerance.
String Comparisons: When comparing strings, consider case sensitivity and locale-specific rules. In many languages, you can use methods like equalsIgnoreCase or compareTo for more control.

Practical Use Cases
Decision Making: Used in if, else if, and else statements to control the flow of the program based on conditions.
Loop Control: Used in for, while, and do-while loops to determine the number of iterations.
Sorting and Searching: Essential in algorithms for sorting data and searching through collections.


**/
namespace ComparisonOperator{
    public class ComparisonOperator{
        public static void Main(){
            Console.WriteLine("Comparison Operator :");

            //Less than Operator
            Console.WriteLine(7.0 < 5.1);   // output: False
            Console.WriteLine(5.1 < 5.1);   // output: False
            Console.WriteLine(0.0 < 5.1);   // output: True

            Console.WriteLine(double.NaN < 5.1);   // output: False
            Console.WriteLine(double.NaN >= 5.1);  // output: False

            //Greater than Operator
            Console.WriteLine("Greater Than operator :");
            Console.WriteLine(7.0 > 5.1);   // output: True
            Console.WriteLine(5.1 > 5.1);   // output: False
            Console.WriteLine(0.0 > 5.1);   // output: False

            Console.WriteLine(double.NaN > 5.1);   // output: False
            Console.WriteLine(double.NaN <= 5.1);  // output: False

            //Less than or Equal to operator:
            Console.WriteLine("Less than or Equal to Operator.");
            Console.WriteLine(7.0 <= 5.1);   // output: False
            Console.WriteLine(5.1 <= 5.1);   // output: True
            Console.WriteLine(0.0 <= 5.1);   // output: True

            Console.WriteLine(double.NaN > 5.1);   // output: False
            Console.WriteLine(double.NaN <= 5.1);  // output: False

            //Greater than or equal operator >=
            Console.WriteLine("Greater than or Equal to Operator :");
            Console.WriteLine(7.0 >= 5.1);   // output: True
            Console.WriteLine(5.1 >= 5.1);   // output: True
            Console.WriteLine(0.0 >= 5.1);   // output: False

            Console.WriteLine(double.NaN < 5.1);   // output: False
            Console.WriteLine(double.NaN >= 5.1);  // output: False

            Console.WriteLine("Mix Comparison :");
            Console.WriteLine(9.0 > 6);//true
            Console.WriteLine(9.0 > '6');// False
            Console.WriteLine(9.000323233 > 9.00094343); //False


        }
    }
}