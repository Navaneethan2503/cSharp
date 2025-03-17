using System;
using System.Collections.Generic;

/**
The assignment operator = assigns the value of its right-hand operand to a variable, a property, or an indexer element given by its left-hand operand. The result of an assignment expression is the value assigned to the left-hand operand. The type of the right-hand operand must be the same as the type of the left-hand operand or implicitly convertible to it.

The assignment operator = is right-associative, that is, an expression of the form
a = b = c
a = (b = c)

The left-hand operand of an assignment receives the value of the right-hand operand. 
When the operands are of value types, assignment copies the contents of the right-hand operand. 
When the operands are of reference types, assignment copies the reference to the object.

This operation is called value assignment: the value is assigned.

ref assignment
Ref assignment = ref makes its left-hand operand an alias to the right-hand operand,

Compound Assignment Operators
C# also provides compound assignment operators that combine an arithmetic operation with assignment. These operators help to write more concise code.

Operator Precedence
Assignment operators have lower precedence than most other operators. This means that in expressions, other operations are performed first before assignment.


**/
namespace AssignmentOperator{
    class AssignmentOperator{
        public static void Main(){
            Console.WriteLine("Assignment Operator :");
            List<double> numbers = [1.0, 2.0, 3.0];

            Console.WriteLine(numbers.Capacity);
            numbers.Capacity = 100;
            Console.WriteLine(numbers.Capacity);
            // Output:
            // 4
            // 100

            int newFirstElement;
            double originalFirstElement = numbers[0];
            newFirstElement = 5;
            numbers[0] = newFirstElement;
            Console.WriteLine(originalFirstElement);
            Console.WriteLine(numbers[0]);
            // Output:
            // 1
            // 5

            void Display(double[] s) => Console.WriteLine(string.Join(" ", s));

            double[] arr = { 0.0, 0.0, 0.0 };
            Display(arr);

            ref double arrayElement = ref arr[0];
            arrayElement = 3.0;
            Display(arr);

            arrayElement = ref arr[arr.Length - 1];
            arrayElement = 5.0;
            Display(arr);
            // Output:
            // 0 0 0
            // 3 0 0
            // 3 0 5



        }
    }
}