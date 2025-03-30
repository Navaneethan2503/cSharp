using System;
/**
A user-defined type can overload a predefined C# operator. That is, a type can provide the custom implementation of an operation in case one or both of the operands are of that type.

Use the operator keyword to declare an operator. An operator declaration must satisfy the following rules:

It includes both a public and a static modifier.
A unary operator has one input parameter. A binary operator has two input parameters. In each case, at least one parameter must have type T or T? where T is the type that contains the operator declaration.

Unary Operators
Unary operators operate on a single operand. The predefined unary operators in C# include:

+: Unary plus, which returns the value of the operand.
-: Unary minus, which negates the value of the operand.
!: Logical negation, which inverts the Boolean value of the operand.
~: Bitwise complement, which inverts each bit of the operand.
++: Increment, which increases the value of the operand by one.
--: Decrement, which decreases the value of the operand by one.

Arithmetic Operators
Arithmetic operators perform mathematical operations on operands. The predefined arithmetic operators in C# include:

+: Addition.
-: Subtraction.
*: Multiplication.
/: Division.
%: Modulus (remainder).

Equality Operators
Equality operators compare two operands to determine if they are equal or not. The predefined equality operators in C# include:

==: Equality.
!=: Inequality.

Comparison Operators
Comparison operators compare two operands to determine their relative order. The predefined comparison operators in C# include:

>: Greater than.
<: Less than.
>=: Greater than or equal to.
<=: Less than or equal to.

Overloadable operators
The following table shows the operators that can be overloaded:

Operators	Notes
+x, -x, !x, ~x, ++, --, true, false	The true and false operators must be overloaded together.
x + y, x - y, x * y, x / y, x % y,
x & y, x | y, x ^ y,
x << y, x >> y, x >>> y	
x == y, x != y, x < y, x > y, x <= y, x >= y	Must be overloaded in pairs as follows: == and !=, < and >, <= and >=.


Non overloadable operators
The following table shows the operators that can't be overloaded:

Operators	Alternatives
x && y, x || y	Overload both the true and false operators and the & or | operators. For more information, see User-defined conditional logical operators.
a[i], a?[i]	Define an indexer.
(T)x	Define custom type conversions that can be performed by a cast expression. For more information, see User-defined conversion operators.
+=, -=, *=, /=, %=, &=, |=, ^=, <<=, >>=, >>>=	Overload the corresponding binary operator. For example, when you overload the binary + operator, += is implicitly overloaded.
^x, x = y, x.y, x?.y, c ? t : f, x ?? y, ??= y,
x..y, x->y, =>, f(x), as, await, checked, unchecked, default, delegate, is, nameof, new,
sizeof, stackalloc, switch, typeof, with	None.


**/
namespace OperatorOverloading{

    public struct MyNumber
    {
        public int Value;

        //Unary Operator
        public static MyNumber operator +(MyNumber num) => num;
        public static MyNumber operator -(MyNumber num) => new MyNumber { Value = -num.Value };
        public static MyNumber operator ++(MyNumber num){
            Console.WriteLine("++ Overload MEthod Invoked");
            return new MyNumber { Value = num.Value + 1 };
        }
        public static MyNumber operator --(MyNumber num) => new MyNumber { Value = num.Value - 1 };

        //Arithmetic Operator
        public static MyNumber operator +(MyNumber a, MyNumber b) => new MyNumber { Value = a.Value + b.Value };
        public static MyNumber operator -(MyNumber a, MyNumber b) => new MyNumber { Value = a.Value - b.Value };
        public static MyNumber operator *(MyNumber a, MyNumber b) => new MyNumber { Value = a.Value * b.Value };
        public static MyNumber operator /(MyNumber a, MyNumber b) => new MyNumber { Value = a.Value / b.Value };
        public static MyNumber operator %(MyNumber a, MyNumber b) => new MyNumber { Value = a.Value % b.Value };

        //Equality Operator
        public static bool operator ==(MyNumber a, MyNumber b) => a.Value == b.Value;
        public static bool operator !=(MyNumber a, MyNumber b) => a.Value != b.Value;

        public override bool Equals(object obj) => obj is MyNumber number && Value == number.Value;
        public override int GetHashCode() => Value.GetHashCode();

        //Comparison Operator
        public static bool operator >(MyNumber a, MyNumber b) => a.Value > b.Value;
        public static bool operator <(MyNumber a, MyNumber b) => a.Value < b.Value;
        public static bool operator >=(MyNumber a, MyNumber b) => a.Value >= b.Value;
        public static bool operator <=(MyNumber a, MyNumber b) => a.Value <= b.Value;
    }

    class OperatorOverloadingClass{
        public static void Main(){
            Console.WriteLine("Operator Overloading ...");

            //Unary Operator
            MyNumber numObj = new MyNumber(){ Value = 10};
            numObj++;
            numObj.Value++;
            Console.WriteLine(numObj.Value);
            Console.WriteLine("Plus :"+ (+numObj).Value);
            
            Console.WriteLine("minus :"+ (-numObj).Value);

            //Arithmetic Operator
            MyNumber numObj2 = new MyNumber(){ Value = 20 };
            MyNumber addObj = numObj + numObj2;
            Console.WriteLine("After Addition :"+addObj.Value);
            addObj = addObj - numObj;
            Console.WriteLine("After Substraction :"+addObj.Value);

            //Equality Operator
            Console.WriteLine("Equality Operator :"+ (numObj2 == addObj));

            //Comparison Operator
            Console.WriteLine("Comparison Operator :"+ (numObj > numObj2));
        }
    }
}