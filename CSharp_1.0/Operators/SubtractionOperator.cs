using System;
/**
Delegate removal
For operands of the same delegate type, the - operator returns a delegate instance that is calculated as follows:

1.If both operands are non-null and the invocation list of the right-hand operand is a proper contiguous sublist of the invocation list of the left-hand operand, the result of the operation is a new invocation list that is obtained by removing the right-hand operand's entries from the invocation list of the left-hand operand. If the right-hand operand's list matches multiple contiguous sublists in the left-hand operand's list, only the right-most matching sublist is removed. If removal results in an empty list, the result is null.
2.If the invocation list of the right-hand operand isn't a proper contiguous sublist of the invocation list of the left-hand operand, the result of the operation is the left-hand operand. For example, removing a delegate that isn't part of the multicast delegate does nothing and results in the unchanged multicast delegate.
3.If the left-hand operand is null, the result of the operation is null. If the right-hand operand is null, the result of the operation is the left-hand operand.

Subtraction assignment operator -= 
An expression using the -= operator, such as
x -= y
is equivalent to
x = x - y
except that x is only evaluated once.

Operator overloadability
A user-defined type can overload the - operator. When a binary - operator is overloaded, the -= operator is also implicitly overloaded. A user-defined type can't explicitly overload the -= operator.


 
**/
namespace SubtractionOperator{
    class SubtractionOperator{
        public static void Main(){
            Console.WriteLine("Subtraction operator :");

            //Delegate Removal
            Action a = () => Console.Write("a");
            Action b = () => Console.Write("b");

            var abbaab = a + b + b + a + a + b;
            var aba = a + b + a;
            abbaab();  // output: abbaab
            Console.WriteLine();

            var ab = a + b;
            var abba = abbaab - ab; //new instance return
            abba();  // output: abba
            Console.WriteLine();
            abbaab(); //abbaab
            Console.WriteLine();

            var nihil = abbaab - abbaab;
            Console.WriteLine(nihil is null);  // output: True
            abbaab(); //abbaab
            Console.WriteLine();

            var first = abbaab - aba;
            first();  // output: abbaab
            Console.WriteLine();
            Console.WriteLine(object.ReferenceEquals(abbaab, first));  // output: True

            Action a2 = () => Console.Write("a");
            var changed = aba - a;
            changed();  // output: ab
            Console.WriteLine();
            var unchanged = aba - a2;
            unchanged();  // output: aba
            Console.WriteLine();
            Console.WriteLine(object.ReferenceEquals(aba, unchanged));  // output: True

            var nothing = null - a;
            Console.WriteLine(nothing is null);  // output: True

            var first1 = a - null;
            a();  // output: a
            Console.WriteLine();
            Console.WriteLine(object.ReferenceEquals(first1, a));  // output: True

            int i = 5;
            i -= 9;
            Console.WriteLine(i);
            // Output: -4

            var printer = a + b + a;
            printer();  // output: aba

            Console.WriteLine();
            printer -= a;
            printer();  // output: ab


        }
    }
}