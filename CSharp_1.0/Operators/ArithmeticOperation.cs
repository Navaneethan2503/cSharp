using System;
/**
+,-,*,/,%,++,-- - Operators
numerical numbers are Operands
5+5 - operation;

The following operators perform arithmetic operations with operands of numeric types:

Unary ++ (increment), -- (decrement), + (plus), and - (minus) operators
Binary * (multiplication), / (division), % (remainder), + (addition), and - (subtraction) operators
Those operators are supported by all integral and floating-point numeric types.

In the case of integral types, those operators (except the ++ and -- operators) are defined for the int, uint, long, and ulong types. 
When operands are of other integral types (sbyte, byte, short, ushort, or char), their values are converted to the int type, which is also the result type of an operation. 
When operands are of different integral or floating-point types, their values are converted to the closest containing type, if such a type exists. For more information, see the Numeric promotions section of the C# language specification. 
The ++ and -- operators are defined for all integral and floating-point numeric types and the char type. 
The result type of a compound assignment expression is the type of the left-hand operand.

Increment operator ++
The unary increment operator ++ increments its operand by 1. The operand must be a variable, a property access, or an indexer access.
The increment operator is supported in two forms: the postfix increment operator, x++, and the prefix increment operator, ++x.

Decrement operator --
The unary decrement operator -- decrements its operand by 1. The operand must be a variable, a property access, or an indexer access.
The decrement operator is supported in two forms: the postfix decrement operator, x--, and the prefix decrement operator, --x.

Unary plus and minus operators
The unary + operator returns the value of its operand. The unary - operator computes the numeric negation of its operand.

Remainder operator %
The remainder operator % computes the remainder after dividing its left-hand operand by its right-hand operand.

Integer remainder
For the operands of integer types, the result of a % b is the value produced by a - (a / b) * b. The sign of the non-zero remainder is the same as the sign of the left-hand operand,

Floating-point remainder
For the float and double operands, the result of x % y for the finite x and y is the value z such that

The sign of z, if non-zero, is the same as the sign of x.
The absolute value of z is the value produced by |x| - n * |y| where n is the largest possible integer that is less than or equal to |x| / |y| and |x| and |y| are the absolute values of x and y, respectively.

Compound assignment
For a binary operator op, a compound assignment expression of the form

x op= y
is equivalent to

x = x op y
except that x is only evaluated once.

Operator precedence and associativity
The following list orders arithmetic operators starting from the highest precedence to the lowest:

Postfix increment x++ and decrement x-- operators
Prefix increment ++x and decrement --x and unary + and - operators
Multiplicative *, /, and % operators
Additive + and - operators
Binary arithmetic operators are left-associative. That is, operators with the same precedence level are evaluated from left to right.

Use parentheses, (), to change the order of evaluation imposed by operator precedence and associativity.


These operators are used for mathematical calculations.

Highest Precedence: () (Parentheses)
Next: *, /, % (Multiplication, Division, Modulus)
Lowest: +, - (Addition, Subtraction)


**/

namespace ArithmeticOperation{
    class ArithmeticOperationClass{
        public static void Main(){
            Console.WriteLine("Arithmetic Operation :");
            var res = 5 + 5.9;
            int min = 0;
            res = res / min;
            Console.WriteLine(res);

            //Increment Operator

            //Postfix
            int ii = 3;
            Console.WriteLine(ii);   // output: 3
            Console.WriteLine(ii++); // output: 3
            Console.WriteLine(ii);   // output: 4

            //Prefix
            double ai = 1.5;
            Console.WriteLine(ai);   // output: 1.5
            Console.WriteLine(++ai); // output: 2.5
            Console.WriteLine(ai);   // output: 2.5

            //Decrement operator

            //Postfix
            int iD = 3;
            Console.WriteLine(iD);   // output: 3
            Console.WriteLine(iD--); // output: 3
            Console.WriteLine(iD);   // output: 2

            //Prefix
            double ad = 1.5;
            Console.WriteLine(ad);   // output: 1.5
            Console.WriteLine(--ad); // output: 0.5
            Console.WriteLine(ad);   // output: 0.5

            //Unary operator
            uint uniOp = +5;
            int unMinus = -5;
            Console.WriteLine(uniOp+" "+ unMinus);

            //The ulong type doesn't support the unary - operator.
            //Multiplication operators - computes the product of its operands
            Console.WriteLine(5 * 2);         // output: 10
            Console.WriteLine(0.5 * 2.5);     // output: 1.25
            Console.WriteLine(0.1m * 23.4m);  // output: 2.34

            //division operator - divides its left-hand operand by its right-hand operand.
            //For the operands of integer types, the result of the / operator is of an integer type and equals the quotient of the two operands rounded towards zero:
            Console.WriteLine(13 / 5);    // output: 2
            Console.WriteLine(-13 / 5);   // output: -2
            Console.WriteLine(13 / -5);   // output: -2
            Console.WriteLine(-13 / -5);  // output: 2

            //Floating point Division operators
            Console.WriteLine(13 / 5.0);       // output: 2.6

            int aa = 13;
            int b = 5;
            Console.WriteLine((double)aa / b);  // output: 2.6

            //floating point division
            Console.WriteLine(16.8f / 4.1f);   // output: 4.097561
            Console.WriteLine(16.8d / 4.1d);   // output: 4.09756097560976
            Console.WriteLine(16.8m / 4.1m);   // output: 4.0975609756097560975609756098
            //If one of the operands is decimal, another operand can be neither float nor double, because neither float nor double is implicitly convertible to decimal. 
            //You must explicitly convert the float or double operand to the decimal type. 

            //Remainder Operators
            Console.WriteLine(5 % 4);   // output: 1
            Console.WriteLine(5 % -4);  // output: 1
            Console.WriteLine(-5 % 4);  // output: -1
            Console.WriteLine(-5 % -4); // output: -1

            //Floating point remainder operator
            Console.WriteLine(-5.2f % 2.0f); // output: -1.2
            Console.WriteLine(5.9 % 3.1);    // output: 2.8
            Console.WriteLine(5.9m % 3.1m);  // output: 2.8

            //addition Operator - computes the sum of its operands
            Console.WriteLine(5 + 4);       // output: 9
            Console.WriteLine(5 + 4.3);     // output: 9.3
            Console.WriteLine(5.1m + 4.2m); // output: 9.3

            //substarct operator - subtracts its right-hand operand from its left-hand operand:
            Console.WriteLine(47 - 3);      // output: 44
            Console.WriteLine(5 - 4.3);     // output: 0.7
            Console.WriteLine(7.5m - 2.3m); // output: 5.2

            int a = 5;
            a += 9;
            Console.WriteLine(a);  // output: 14

            a -= 4;
            Console.WriteLine(a);  // output: 10

            a *= 2;
            Console.WriteLine(a);  // output: 20

            a /= 4;
            Console.WriteLine(a);  // output: 5

            a %= 3;
            Console.WriteLine(a);  // output: 2

            //Because of numeric promotions, the result of the op operation might be not implicitly convertible to the type T of x. 
            //In such a case, if op is a predefined operator and the result of the operation is explicitly convertible to the type T of x, a compound assignment expression of the form x op= y is equivalent to x = (T)(x op y), except that x is only evaluated once.

            byte aC = 200;
            byte bC = 100;

            var c = aC + bC;
            Console.WriteLine(c.GetType());  // output: System.Int32
            Console.WriteLine(c);  // output: 300

            aC += bC;
            Console.WriteLine(aC);  // output: 44

            Console.WriteLine(2 + 2 * 2);   // output: 6
            Console.WriteLine((2 + 2) * 2); // output: 8

            Console.WriteLine(9 / 5 / 2);   // output: 0
            Console.WriteLine(9 / (5 / 2)); // output: 4
        }
    }
}