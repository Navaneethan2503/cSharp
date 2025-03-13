using System;
/**
The logical Boolean operators perform logical operations with bool operands. The operators include the unary logical negation (!), binary logical AND (&), OR (|), and exclusive OR (^), and the binary conditional logical AND (&&) and OR (||).
1.Unary ! (logical negation) operator.
2.Binary & (logical AND), | (logical OR), and ^ (logical exclusive OR) operators. Those operators always evaluate both operands.
3.Binary && (conditional logical AND) and || (conditional logical OR) operators. Those operators evaluate the right-hand operand only if it's necessary.

For operands of the integral numeric types, the &, |, and ^ operators perform bitwise logical operations.

Logical negation operator !
The unary prefix ! operator computes logical negation of its operand. That is, it produces true, if the operand evaluates to false, and false, if the operand evaluates to true

Logical exclusive OR operator ^
The ^ operator computes the logical exclusive OR, also known as the logical XOR, of its operands. 
The result of x ^ y is true if x evaluates to true and y evaluates to false, or x evaluates to false and y evaluates to true. 
Otherwise, the result is false. That is, for the bool operands, the ^ operator computes the same result as the inequality operator !=.

Nullable Boolean logical operators
For bool? operands, the & (logical AND) and | (logical OR) operators support the three-valued logic as follows:

The & operator produces true only if both its operands evaluate to true. If either x or y evaluates to false, x & y produces false (even if another operand evaluates to null). Otherwise, the result of x & y is null.

The | operator produces false only if both its operands evaluate to false. If either x or y evaluates to true, x | y produces true (even if another operand evaluates to null). Otherwise, the result of x | y is null.

The following table presents that semantics:

x	y	x&y	x|y
true	true	true	true
true	false	false	true
true	null	null	true
false	true	false	true
false	false	false	false
false	null	false	null
null	true	null	true
null	false	false	null
null	null	null	null

The behavior of those operators differs from the typical operator behavior with nullable value types. 
Typically, an operator that is defined for operands of a value type can be also used with operands of the corresponding nullable value type. 
Such an operator produces null if any of its operands evaluates to null. However, the & and | operators can produce non-null even if one of the operands evaluates to null.


Compound assignment:
For a binary operator op, a compound assignment expression of the form

x op= y
is equivalent to

x = x op y
except that x is only evaluated once.

The &, |, and ^ operators support compound assignment,


Operator precedence
The following list orders logical operators starting from the highest precedence to the lowest:

Logical negation operator !
Logical AND operator &
Logical exclusive OR operator ^
Logical OR operator |
Conditional logical AND operator &&
Conditional logical OR operator ||
Use parentheses, (), to change the order of evaluation imposed by operator precedence:


Operator overloadability
A user-defined type can overload the !, &, |, and ^ operators. When a binary operator is overloaded, the corresponding compound assignment operator is also implicitly overloaded. A user-defined type can't explicitly overload a compound assignment operator.

A user-defined type can't overload the conditional logical operators && and ||. However, if a user-defined type overloads the true and false operators and the & or | operator in a certain way, the && or || operation, respectively, can be evaluated for the operands of that type.

**/
namespace BooleanLogicalOperators{
    class BooleanLogicalOperatorsClass{

        public static bool SecondOperand(){
            Console.WriteLine("Second Operand Evaluated");
            return true;
        }
        public static void Main(){
            Console.WriteLine("Boolean Logical Operators");
            bool passed = false;
            Console.WriteLine(!passed);  // output: True
            Console.WriteLine(!true);    // output: False

            //logical operator - Evaluates both Operands.
            bool logicalOperator = false & BooleanLogicalOperatorsClass.SecondOperand();
            Console.WriteLine("logicalOperator :"+ logicalOperator);
            bool logicalOperator2 = true & BooleanLogicalOperatorsClass.SecondOperand();
            Console.WriteLine("logicalOperator2 :  "+ logicalOperator2);
            

            //Condition opearator - evaluate the right-hand operand only if it's necessary
            //also know as short-circuiting
            bool conditionalOp = false && BooleanLogicalOperatorsClass.SecondOperand();
            Console.WriteLine("Condition Op : "+ conditionalOp);
            bool conditionalOp2 = true && BooleanLogicalOperatorsClass.SecondOperand();
            Console.WriteLine("Condition Op2 : "+ conditionalOp2);

            //XOR Operators - Logical Exlusive ^ OR Operators 
            Console.WriteLine(true ^ true);    // output: False
            Console.WriteLine(true ^ false);   // output: True
            Console.WriteLine(false ^ true);   // output: True
            Console.WriteLine(false ^ false);  // output: False

            //Null Operand;
            bool? test = null;
            Display(!test);         // output: null
            Display(test ^ false);  // output: null
            Display(test ^ null);   // output: null
            Display(true ^ null);   // output: null

            void Display(bool? b) => Console.WriteLine(b is null ? "null" : b.Value.ToString());
            //The conditional logical operators && and || don't support bool? operands.


            //Component Assignment
            Console.WriteLine("Component Assignment");
            bool test1 = true;
            test1 &= false;
            Console.WriteLine(test1);  // output: False

            test1 |= true;
            Console.WriteLine(test1);  // output: True

            test1 ^= false;
            Console.WriteLine(test1);  // output: True
            //The conditional logical operators && and || don't support compound assignment.

            //Operator precedence
            Console.WriteLine(true | true & false);   // output: True
            Console.WriteLine((true | true) & false); // output: False

            bool Operand(string name, bool value)
            {
                Console.WriteLine($"Operand {name} is evaluated.");
                return value;
            }

            var byDefaultPrecedence = Operand("A", true) || Operand("B", true) && Operand("C", false);
            Console.WriteLine(byDefaultPrecedence);
            // Output:
            // Operand A is evaluated.
            // True

            var changedOrder = (Operand("A", true) || Operand("B", true)) && Operand("C", false);
            Console.WriteLine(changedOrder);
            // Output:
            // Operand A is evaluated.
            // Operand C is evaluated.
            // False 


            

        }
    }
}