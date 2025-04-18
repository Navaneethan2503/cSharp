using System;
/**
The checked and unchecked statements specify the overflow-checking context for integral-type arithmetic operations and conversions. The default statement is unchecked. When integer arithmetic overflow occurs, the overflow-checking context defines what happens. In a checked context, a System.OverflowException is thrown; if overflow happens in a constant expression, a compile-time error occurs. In an unchecked context, the operation result is truncated by discarding any high-order bits that don't fit in the destination type. 

Checked Statements
A checked statement ensures that arithmetic operations are monitored for overflow. If an overflow occurs, a System.OverflowException is thrown. This is useful for ensuring data integrity and preventing unexpected behavior due to overflow.

UnChecked Statement
An unchecked statement disables overflow checking for arithmetic operations. If an overflow occurs, it wraps around the value without throwing an exception. This can be useful for performance optimization or when overflow behavior is intentionally desired.


use checked() or unchecked() for single expression.
use checked{} or unchecked{} for one or more expression or statement;

The overflow behavior of user-defined operators and conversions can differ from the one described in the preceding paragraph. In particular, user-defined checked operators might not throw an exception in a checked context.

the checked and unchecked statements and operators only affect the overflow-checking context for those operations that are textually inside the statement block or operator's parentheses

Numeric types and overflow-checking context:
-------------------------------------------
The checked and unchecked keywords primarily apply to integral types where there's a sensible overflow behavior. The wraparound behavior where T.MaxValue + 1 becomes T.MinValue is sensible in a two's complement value. The represented value isn't correct since it can't fit in the storage for the type. Therefore, the bits are representative of the lower n-bits of the full result.

For types like decimal, float, double, and Half that represent a more complex value or a one's complement value, wraparound isn't sensible. It can't be used to compute larger or more accurate results, so unchecked isn't beneficial.

float, double, and Half have sensible saturating values for PositiveInfinity and NegativeInfinity, so you can detect overflow in an unchecked context. For decimal, no such limits exist, and saturating at MaxValue can lead to errors or confusion. Operations that use decimal throw in both a checked and unchecked context.

Operations affected by the overflow-checking context:
----------------------------------------------------
The overflow-checking context affects the following operations:
    The following built-in arithmetic operators: unary ++, --, - and binary +, -, *, and / operators, when their operands are of an integral type (that is, either integral numeric or char type) or an enum type.
    Explicit numeric conversions between integral types or from float or double to an integral type
    Beginning with C# 11, user-defined checked operators and conversions. For more information,

When you convert a decimal value to an integral type and the result is outside the range of the destination type, an OverflowException is always thrown, regardless of the overflow-checking context.

Default overflow-checking context:
-----------------------------------
If you don't specify the overflow-checking context, the value of the CheckForOverflowUnderflow compiler option defines the default context for nonconstant expressions. By default the value of that option is unset and integral-type arithmetic operations and conversions are executed in an unchecked context.

Constant expressions are evaluated by default in a checked context and overflow causes a compile-time error. You can explicitly specify an unchecked context for a constant expression with the unchecked statement or operator.

**/
namespace CheckedUnCheckedStatement{

    public record struct Point(int X, int Y)
    {
        public static Point operator checked +(Point left, Point right)
        {
            checked
            {
                return new Point(left.X + right.X, left.Y + right.Y);
            }
        }
        
        public static Point operator +(Point left, Point right)
        {
            return new Point(left.X + right.X, left.Y + right.Y);
        }
    }

    class CheckedUnCheckedClass{
        public static void Main(){
            Console.WriteLine("Checked and UnChecked Statement");
            
            //Checked Statement
            try{
                //int a = int.MaxValue + 1; //The operation overflows at compile time in checked mode
                int a = int.MaxValue;
                a = checked(a+1);
            }
            catch (OverflowException ex){
                Console.WriteLine("Overflow Exception Catched.");
            }


            //UnChecked
            unchecked{
                int b = int.MaxValue + 1;
                Console.WriteLine("unchecked :"+b);
            }

            int c = int.MaxValue;
            c = c+1;
            Console.WriteLine("Default C# arithmetic is in Unchecked Context :"+ c);
            //Unchecked Context: By default, arithmetic operations in C# are performed in an unchecked context unless explicitly specified otherwise.

            checked{
                try{
                    Point a = new Point(int.MaxValue, int.MaxValue);
                    Point b = new Point(int.MaxValue, int.MaxValue);
                    Point d = a + b;
                }
                catch(OverflowException ex){
                    Console.WriteLine("Overflow exceptions for user defined .");
                }
            }

            Point au = new Point(int.MaxValue, int.MaxValue);
            Point bu = new Point(int.MaxValue, int.MaxValue);
            Point du = au + bu;//wraps; becz unchecked is default.
            Console.WriteLine(du);

            //by default unchacked operations for arthimetic 
            int Multiply(int a, int b) => a * b;

            int factor = 2;

            try
            {
                checked
                {
                    //here we dont have arithmetic operations directly so it wont wraps 
                    Console.WriteLine(Multiply(factor, int.MaxValue));  // output: -2
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                checked
                {
                    //here arithmetic operations is enforced to check overflow and throws error.
                    Console.WriteLine(Multiply(factor, factor * int.MaxValue));
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
            }

            int z = 10;
            //Console.WriteLine(z/0);
        }
    }
}