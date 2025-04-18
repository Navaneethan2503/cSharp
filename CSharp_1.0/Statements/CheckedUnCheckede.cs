using System;
/**
The checked and unchecked statements and operators only affect the overflow-checking context for those operations that are textually inside the statement block or operator's parentheses.
In C#, the checked and unchecked statements are used to control the overflow-checking context for arithmetic operations and conversions. Here's a detailed look at both:

checked Statement
The checked statement ensures that arithmetic operations and conversions are checked for overflow. If an overflow occurs, a System.OverflowException is thrown.

Example:

int max = int.MaxValue;
try
{
    int result = checked(max + 1);
}
catch (OverflowException ex)
{
    Console.WriteLine("Overflow occurred: " + ex.Message);
}
In this example, the addition operation max + 1 is checked for overflow. Since max is the maximum value an int can hold, adding 1 causes an overflow, and an OverflowException is thrown.

unchecked Statement
The unchecked statement disables overflow checking for arithmetic operations and conversions. If an overflow occurs, it is ignored, and the result wraps around.

Example:

int max = int.MaxValue;
int result = unchecked(max + 1);
Console.WriteLine(result); // Output: -2147483648
In this example, the addition operation max + 1 is unchecked. The overflow is ignored, and the result wraps around to the minimum value an int can hold.

Usage Scenarios
checked: Use when you want to ensure that overflow is detected and handled, especially in critical calculations where overflow could lead to incorrect results or security vulnerabilities.
unchecked: Use when performance is critical, and you are certain that overflow will not cause issues, or when you intentionally want to allow overflow behavior (e.g., in certain low-level programming scenarios).
Checked and Unchecked Contexts
You can also specify checked and unchecked contexts for blocks of code or entire methods using the checked and unchecked keywords.

Checked Context:

checked
{
    int result = max + 1; // Overflow will be checked
}
Unchecked Context:

unchecked
{
    int result = max + 1; // Overflow will be ignored
}
Compiler Options
You can control the default overflow-checking behavior for your entire project using compiler options:

/checked+: Enables overflow checking by default.
/checked-: Disables overflow checking by default.
Summary
checked: Ensures overflow is detected and throws an exception.
unchecked: Ignores overflow and allows wrap-around behavior.
Contexts: Can be applied to individual expressions, blocks of code, or entire methods.

User-Defined Operators
When you define custom operators for a class or struct, you can specify how they handle overflow. The behavior of these operators is determined by the implementation you provide.

Example:

public struct CustomNumber
{
    public int Value;

    public static CustomNumber operator +(CustomNumber a, CustomNumber b)
    {
        // Custom overflow handling
        int result = a.Value + b.Value;
        if (result < a.Value) // Simple overflow check
        {
            throw new OverflowException("Overflow occurred in CustomNumber addition");
        }
        return new CustomNumber { Value = result };
    }
}
In this example, the + operator for CustomNumber includes a custom overflow check. If an overflow is detected, it throws an OverflowException. However, this behavior is entirely up to the implementation, and a different implementation might not throw an exception even in a checked context.

User-Defined Conversions
Similarly, user-defined conversions can have custom overflow behavior.

Example:

public struct CustomNumber
{
    public int Value;

    public static explicit operator int(CustomNumber cn)
    {
        // Custom overflow handling
        if (cn.Value > int.MaxValue)
        {
            throw new OverflowException("Overflow occurred in CustomNumber to int conversion");
        }
        return cn.Value;
    }
}
In this example, the explicit conversion from CustomNumber to int includes a custom overflow check. Again, this behavior is determined by the implementation.

Checked Context and User-Defined Operators
When you use user-defined operators or conversions in a checked context, the checked context does not automatically enforce overflow checking for these operations. Instead, the behavior depends on the implementation of the user-defined operator or conversion.

Example:

CustomNumber a = new CustomNumber { Value = int.MaxValue };
CustomNumber b = new CustomNumber { Value = 1 };

try
{
    CustomNumber result = checked(a + b); // Custom overflow handling applies
}
catch (OverflowException ex)
{
    Console.WriteLine("Overflow occurred: " + ex.Message);
}
In this example, the checked context does not enforce overflow checking for the + operator. Instead, the custom overflow handling in the + operator implementation determines whether an exception is thrown.

Summary
User-Defined Operators: Custom behavior for overflow can be implemented, and it is not automatically enforced by the checked context.
User-Defined Conversions: Similar to operators, custom overflow handling can be specified.
Checked Context: Does not automatically enforce overflow checking for user-defined operators and conversions; the behavior depends on the implementation.

In C#, the checked and unchecked statements and operators control the overflow-checking context for arithmetic operations and conversions. They only affect the operations that are textually within their scope. Here's a detailed explanation:

checked and unchecked Statements
The checked and unchecked statements define a block of code where overflow checking is either enforced (checked) or ignored (unchecked). The effect of these statements is limited to the operations within their block.

Example:

int max = int.MaxValue;

checked
{
    int result = max + 1; // Overflow checking is enforced here
}

unchecked
{
    int result = max + 1; // Overflow checking is ignored here
}
In this example:

The addition operation max + 1 inside the checked block will throw an OverflowException if an overflow occurs.
The addition operation max + 1 inside the unchecked block will ignore the overflow and wrap around.
checked and unchecked Operators
The checked and unchecked operators can be used to control overflow checking for specific expressions. The effect of these operators is limited to the expression within their parentheses.

Example:

int max = int.MaxValue;

int result1 = checked(max + 1); // Overflow checking is enforced for this expression
int result2 = unchecked(max + 1); // Overflow checking is ignored for this expression
In this example:

The checked operator ensures that overflow checking is enforced for the expression max + 1, and an OverflowException will be thrown if an overflow occurs.
The unchecked operator ensures that overflow checking is ignored for the expression max + 1, and the result will wrap around.
Scope of checked and unchecked
The scope of checked and unchecked is limited to the operations textually inside the statement block or operator's parentheses. Operations outside this scope are not affected.

Example:

int max = int.MaxValue;

checked
{
    int result1 = max + 1; // Overflow checking is enforced here
}
int result2 = max + 1; // Overflow checking is not enforced here

int result3 = checked(max + 1); // Overflow checking is enforced for this expression
int result4 = unchecked(max + 1); // Overflow checking is ignored for this expression
In this example:
The checked block affects only the addition operation inside it.
The checked and unchecked operators affect only the expressions within their parentheses.
The addition operation outside the checked block and without the checked operator is not affected by overflow checking.

Summary:
checked Statement: Enforces overflow checking for all operations within its block.
unchecked Statement: Ignores overflow checking for all operations within its block.
checked Operator: Enforces overflow checking for the specific expression within its parentheses.
unchecked Operator: Ignores overflow checking for the specific expression within its parentheses.
Scope: The effect is limited to the operations textually inside the statement block or operator's parentheses.

Numeric types and overflow-checking context
The checked and unchecked keywords primarily apply to integral types where there's a sensible overflow behavior. The wraparound behavior where T.MaxValue + 1 becomes T.MinValue is sensible in a two's complement value. The represented value isn't correct since it can't fit in the storage for the type. Therefore, the bits are representative of the lower n-bits of the full result.

For types like decimal, float, double, and Half that represent a more complex value or a one's complement value, wraparound isn't sensible. It can't be used to compute larger or more accurate results, so unchecked isn't beneficial.

float, double, and Half have sensible saturating values for PositiveInfinity and NegativeInfinity, so you can detect overflow in an unchecked context. For decimal, no such limits exist, and saturating at MaxValue can lead to errors or confusion. Operations that use decimal throw in both a checked and unchecked context.

Operations affected by the overflow-checking context
The overflow-checking context affects the following operations:

The following built-in arithmetic operators: unary ++, --, - and binary +, -, *, and / operators, when their operands are of an integral type (that is, either integral numeric or char type) or an enum type.

Explicit numeric conversions between integral types or from float or double to an integral type.

When you convert a decimal value to an integral type and the result is outside the range of the destination type, an OverflowException is always thrown, regardless of the overflow-checking context.

Beginning with C# 11, user-defined checked operators and conversions. For more information, see the User-defined checked operators section of the Arithmetic operators article.

Default overflow-checking context
If you don't specify the overflow-checking context, the value of the CheckForOverflowUnderflow compiler option defines the default context for nonconstant expressions. By default the value of that option is unset and integral-type arithmetic operations and conversions are executed in an unchecked context.

Constant expressions are evaluated by default in a checked context and overflow causes a compile-time error. You can explicitly specify an unchecked context for a constant expression with the unchecked statement or operator.

**/
namespace YieldStatement{
    class YieldStatementClass{
        public static void Main(){
            Console.WriteLine("YeildStatement");
            int max = int.MaxValue;
            int num = max + 3;

            Console.WriteLine(num + 2);//overflow exception ignored.

            try{
                checked{
                    //within the scope of checked context only the overflow will checked .
                    //variable declaration and initialization also need to within context to enfore overflow;
                    int result ;
                    //result = max + 2;
                    num += 2;//this will be ignored becz declaration is in out of context.
                    Console.WriteLine("inside the checked context :"+num);
                }

                unchecked{
                    int result ;
                    result = max + 2;
                    Console.WriteLine("inside uncheced context:"+ result);
                }

                int b = unchecked(max+2);//ignored;
                Console.WriteLine(b);
                int a = checked(max+2);//error will occurs here.
                
            }
            catch(OverflowException e){
                Console.WriteLine("Overflow execption Occurs.");
            }
        }
    }
}