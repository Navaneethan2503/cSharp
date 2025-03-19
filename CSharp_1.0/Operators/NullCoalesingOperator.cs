using System;
using System.Collections.Generic;
using System.Collections;
/**
The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null; otherwise, it evaluates the right-hand operand and returns its result. 
The ?? operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null. 

The null-coalescing assignment operator ??= assigns the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to null. 
The ??= operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.

The left-hand operand of the ??= operator must be a variable, a property, or an indexer element.

In particular, you can use the null-coalescing operators with unconstrained type parameters:

private static void Display<T>(T a, T backup)
{
    Console.WriteLine(a ?? backup);
}

The null-coalescing operators are right-associative. That is, expressions of the form

a ?? b ?? c
d ??= e ??= f
are evaluated as

a ?? (b ?? c)
d ??= (e ??= f)

Practical Use Cases
Default Values: Providing default values for nullable variables.
Simplifying Code: Reducing the need for explicit if statements to check for null.
Initialization: Ensuring that variables are initialized with non-null values.

Important Considerations
Readability: The null-coalescing operators make the code more concise and readable, especially when dealing with default values and initialization.
Type Compatibility: Ensure that the types of the operands are compatible. The right-hand operand must be of a type that can be assigned to the left-hand operand.

Comparison with if Statements
Using the null-coalescing operators can simplify code that would otherwise require if statements to check for null.

Using if Statement:
string? name = null;
string displayName;
if (name != null) {
    displayName = name;
} else {
    displayName = "Default Name";
}
Using ?? Operator:
string? name = null;
string displayName = name ?? "Default Name";

Operator overloadability :
The operators ?? and ??= can't be overloaded.


**/
namespace NullCoalesingOperator{
    #nullable enable
    class NullCoalesingOperator{
        public static void Main(){
            Console.WriteLine("Null Coalesing Operator . (?? , ?=)");
            List<int>? numbers = null;
            int? a = null;

            Console.WriteLine((numbers is null)); // expected: true
            // if numbers is null, initialize it. Then, add 5 to numbers
            (numbers ??= new List<int>()).Add(5);
            Console.WriteLine(string.Join(" ", numbers));  // output: 5
            Console.WriteLine((numbers is null)); // expected: false        


            Console.WriteLine((a is null)); // expected: true
            Console.WriteLine((a ?? 3)); // expected: 3 since a is still null 
            // if a is null then assign 0 to a and add a to the list
            numbers.Add(a ??= 0);
            Console.WriteLine((a is null)); // expected: false        
            Console.WriteLine(string.Join(" ", numbers));  // output: 5 0
            Console.WriteLine(a);  // output: 0

            string nonCoalsingVar = null;
            int nonCoalsingVarInt = 10;
            Console.WriteLine(nonCoalsingVar ?? "nickil");
            //Console.WriteLine(nonCoalsingVarInt ?? 100);//The type of the left-hand operand of the ?? and ??= operators can't be a non-nullable value type.

            //In expressions with the null-conditional operators ?. and ?[], you can use the ?? operator to provide an alternative expression to evaluate in case the result of the expression with null-conditional operations is null:
            // double SumNumbers(List<List<double>> setsOfNumbers, int indexOfSetToSum)
            // {
            //     return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
            // }

            // var sum = SumNumbers(null, 0);
            // Console.WriteLine(sum);  // output: NaN

            //When you work with nullable value types and need to provide a value of an underlying value type, use the ?? operator to specify the value to provide in case a nullable type value is null:
            a = null;
            int b = a ?? -1;
            Console.WriteLine("Nullable access :"+ (a.GetValueOrDefault()));//Use the Nullable<T>.GetValueOrDefault() method if the value to be used when a nullable type value is null should be the default value of the underlying value type.
            Console.WriteLine(b);  // output: -1

            //You can use a throw expression as the right-hand operand of the ?? operator to make the argument-checking code more concise:
            string nameAuto = null;
            try{
                Console.WriteLine(nameAuto ?? throw new ArgumentNullException("Value cannot be Null."));
            }
            catch(ArgumentNullException ex){
                Console.WriteLine("Exception Catched.");
            }

            //You can use the ??= operator to replace the code of the form
            Console.WriteLine(nameAuto ??= "Value is Null");
            double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
            {
                return setsOfNumbers?[indexOfSetToSum]?[0] ?? double.NaN;
            }

            var sum1 = SumNumbers(null, 0);
            Console.WriteLine(sum1);  // output: NaN

            List<double[]?> numberSets =
            [
                [1.0, 2.0, 3.0],
                null
            ];

            var sum2 = SumNumbers(numberSets, 0);
            Console.WriteLine(""+sum2);  // output: 6

            var sum3 = SumNumbers(numberSets, 1);
            Console.WriteLine(sum3);  // output: NaN

            int[]? example1 = null;
            int[] res = example1 ?? new int[]{1,2,3,4};
            res = example1 ??= new int[]{10,20,30,40};
            Display(res);
            Display(example1);
            void Display<T>(IEnumerable<T> xs) => Console.WriteLine(string.Join(" ", xs));
        }
    }
}