using System;
using System.Collections.Generic;
/**
. (member access): to access a member of a namespace or a type
[] (array element or indexer access): to access an array element or a type indexer
?. and ?[] (null-conditional operators): to perform a member or element access operation only if an operand is non-null
() (invocation): to call an accessed method or invoke a delegate
^ (index from end): to indicate that the element position is from the end of a sequence
.. (range): to specify a range of indices that you can use to obtain a range of sequence elements

-------------------------------------------
Member access expression . :
You use the . token to access a member of a namespace or a type, as the following examples demonstrate:

Use . to access a nested namespace within a namespace, as the following example of a using directive shows:

using System.Collections.Generic;
Use . to form a qualified name to access a type within a namespace, as the following code shows:

System.Collections.Generic.IEnumerable<int> numbers = [1, 2, 3];
Use a using directive to make the use of qualified names optional.

Use . to access type members, static and nonstatic, as the following code shows.
You can also use . to access an extension method.

-----------------------------------------------------------------
Indexer operator []
Square brackets, [], are typically used for array, indexer, or pointer element access. 
Beginning with C# 12, [] encloses a collection expression.

Other usages of []
For information about pointer element access, see the Pointer element access operator [] section of the Pointer related operators article. For information about collection expressions, see the collection expressions article.

You also use square brackets to specify attributes:

[System.Diagnostics.Conditional("DEBUG")]
void TraceMethod() {}
Additionally, square brackets can be used to designate list patterns for use in pattern matching or testing.

arr is ([1, 2, ..])
//Specifies that an array starts with (1, 2)
-----------------------------------------------------------------------
Null-conditional operators ?. and ?[] :

The null-conditional operator in C# is a convenient way to handle null values and avoid null reference exceptions. It allows you to safely access members and elements only if the operand is not null. 
There are two null-conditional operators: ?. and ?[].

A null-conditional operator applies a member access (?.) or element access (?[]) operation to its operand only if that operand evaluates to non-null; otherwise, it returns null. In other words:

1. If a evaluates to null, the result of a?.x or a?[x] is null.
2. If a evaluates to non-null, the result of a?.x or a?[x] is the same as the result of a.x or a[x], respectively.

The null-conditional operators are short-circuiting. That is, if one operation in a chain of conditional member or element access operations returns null, the rest of the chain doesn't execute. In the following example, B isn't evaluated if A evaluates to null and C isn't evaluated if A or B evaluates to null:
A?.B?.Do(C);
A?.B?[C];

If A might be null but B and C wouldn't be null if A isn't null, you only need to apply the null-conditional operator to A:
A?.B.C();

In the preceding example, B isn't evaluated and C() isn't called if A is null. However, if the chained member access is interrupted, for example by parentheses as in (A?.B).C(), short-circuiting doesn't happen.
The null-conditional member access operator ?. is also known as the Elvis operator.


---------------------------------------------------------
Invocation Operator (())
The invocation operator is used to call methods or delegate instances. It is represented by parentheses ().

Use parentheses, (), to call a method or invoke a delegate.

The following example demonstrates how to call a method, with or without arguments, and invoke a delegate.
You also use parentheses when you invoke a constructor with the new operator.

Other usages of ()
You also use parentheses to adjust the order in which to evaluate operations in an expression. For more information, see C# operators.

Cast expressions, which perform explicit type conversions, also use parentheses.

-------------------------------------------------------------------------

Index from end operator ^ :

The ^ operator indicates the element position from the end of a sequence. 
For a sequence of length length, ^n points to the element with offset length - n from the start of a sequence. 
For example, ^1 points to the last element of a sequence and ^length points to the first element of a sequence.

As the preceding example shows, expression ^e is of the System.Index type. In expression ^e, the result of e must be implicitly convertible to int.

You can also use the ^ operator with the range operator to create a range of indices. For more information, see Indices and ranges.

Beginning with C# 13, the Index from the end operator can be used in an object initializer.

----------------------------------------------
Range operator ..
-----------------

The .. operator specifies the start and end of a range of indices as its operands. 
The left-hand operand is an inclusive start of a range. 
The right-hand operand is an exclusive end of a range. Either of the operands can be an index from the start or from the end of a sequence.

You can omit any of the operands of the .. operator to obtain an open-ended range:

a.. is equivalent to a..^0
..b is equivalent to 0..b
.. is equivalent to 0..^0

Range operator expression	Description
..	All values in the collection.
..end	Values from the start to the end exclusively.
start..	Values from the start inclusively to the end.
start..end	Values from the start inclusively to the end exclusively.
^start..	Values from the start inclusively to the end counting from the end.
..^end	Values from the start to the end exclusively counting from the end.
start..^end	Values from start inclusively to end exclusively counting from the end.
^start..^end	Values from start inclusively to end exclusively both counting from the end.

The .. token is also used for the spread element in a collection expression.

Not only arrays support indices and ranges. You can also use indices and ranges with string, Span<T>, or ReadOnlySpan<T>.

The performance of code using the range operator depends on the type of the sequence operand.

The time complexity of the range operator depends on the sequence type. For example, if the sequence is a string or an array, then the result is a copy of the specified section of the input, so the time complexity is O(N) (where N is the length of the range). On the other hand, if it's a System.Span<T> or a System.Memory<T>, the result references the same backing store, which means there is no copy and the operation is O(1).

In addition to the time complexity, this causes extra allocations and copies, impacting performance. In performance sensitive code, consider using Span<T> or Memory<T> as the sequence type, since the range operator does not allocate for them.

For example, the following .NET types support both indices and ranges: String, Span<T>, and ReadOnlySpan<T>. The List<T> supports indices but doesn't support ranges.

A Note on Range Indices and Arrays
When taking a range from an array, the result is an array that is copied from the initial array, rather than referenced. Modifying values in the resulting array will not change values in the initial array.

--------------------------------------------------------------------------------------------
Operator overloadability
The ., (), ^, and .. operators can't be overloaded. The [] operator is also considered a non-overloadable operator. Use indexers to support indexing with user-defined types.
**/
#nullable enable
namespace MemberAccessNullCondition{

    public class Person
    {
        public required FullName Name { get; set; }
    }

    public class FullName
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public void Write() => Console.WriteLine($"{FirstName} {LastName}");
    }

    class MemberAccessNullCondition{
        public int? number = null;
        public static void Main(){
            Console.WriteLine("Member Access Null Condition Expression.");

            //Member Access using dot (.) operator.
            System.Collections.Generic.List<string> numArray = new System.Collections.Generic.List<string>();
            numArray.Add("5");
            Console.WriteLine(string.Join(" ", numArray));

            List<double> constants =
            [
                Math.PI,
                Math.E
            ];
            Console.WriteLine($"{constants.Count} values to show:");
            Console.WriteLine(string.Join(", ", constants));
            // Output:
            // 2 values to show:
            // 3.14159265358979, 2.71828182845905

            //Array access
            int[] fib = new int[10];
            fib[0] = fib[1] = 1;
            for (int i = 2; i < fib.Length; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }
            Console.WriteLine(fib[fib.Length - 1]);  // output: 55

            double[,] matrix = new double[2,2];
            matrix[0,0] = 1.0;
            matrix[0,1] = 2.0;
            matrix[1,0] = matrix[1,1] = 3.0;
            var determinant = matrix[0,0] * matrix[1,1] - matrix[1,0] * matrix[0,1];
            Console.WriteLine(determinant);  // output: -3

            //If an array index is outside the bounds of the corresponding dimension of an array, an IndexOutOfRangeException is thrown.

            //As the preceding example shows, you also use square brackets when you declare an array type or instantiate an array instance.

            //Indexer Access
            var dict = new Dictionary<string, double>();
            dict["one"] = 1;
            dict["pi"] = Math.PI;
            Console.WriteLine(dict["one"] + dict["pi"]);  // output: 4.14159265358979
            //Indexers allow you to index instances of a user-defined type in the similar way as array indexing. Unlike array indices, which must be integer, the indexer parameters can be declared to be of any type.


            //Null-conditional operators ?. and ?[]
            MemberAccessNullCondition memObj = new MemberAccessNullCondition();
            Console.WriteLine("Accessing Nullable Member :"+(memObj?.number ?? 0));
            Console.WriteLine("Accessing Member :"+(memObj.number));
            //Console.WriteLine("Accessing Not a Member :"+(memObj?.numbers));

            int[]? nullA = null;
            Console.WriteLine("Null Array :"+nullA?[0]);//use null condition only for nullable types and for non nullable types it behaves sames as member access and index access.

            //Chain - Short Circuit - Null Conditional Operator ?. and ?[]
            List<double?[]?> numberSets =
            [
                [1.0, 2.0, 3.0, null],
                null
            ];
            Console.WriteLine(numberSets?[0]?[0]);//All three Evaluated
            Console.WriteLine(numberSets?[1]?[0]);//only numberset evaluated and breaked since it is null and following all not evaluated.

            Person? person = null;
            person?.Name.Write(); // no output: Write() is not called due to short-circuit.
            try
            {
                (person?.Name).Write();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("NullReferenceException");
            }; // output: NullReferenceException

            //If a.x or a[x] is of a non-nullable value type T, a?.x or a?[x] is of the corresponding nullable value type T?. If you need an expression of type T, apply the null-coalescing operator ?? to a null-conditional expression,
            int GetSumOfFirstTwoOrDefault(int[]? numbers)
            {
                if ((numbers?.Length ?? 0) < 2)
                {
                    return 0;
                }
                return numbers[0] + numbers[1];
            }

            Console.WriteLine(GetSumOfFirstTwoOrDefault(null));  // output: 0
            Console.WriteLine(GetSumOfFirstTwoOrDefault([]));  // output: 0
            Console.WriteLine(GetSumOfFirstTwoOrDefault([3, 4, 5]));  // output: 7
            //In the preceding example, if you don't use the ?? operator, numbers?.Length < 2 evaluates to false when numbers is null.
            //The ?. operator evaluates its left-hand operand no more than once, guaranteeing that it cannot be changed to null after being verified as non-null.

            //Invocation Expression
            Console.Clear();
            Console.WriteLine("Invocation Expression");
            Action<int> display = s => Console.WriteLine(s);

            List<int> numbers =
            [
                10,
                17
            ];
            display(numbers.Count);   // output: 2

            numbers.Clear();
            display(numbers.Count);   // output: 0
            
            //Index from End Operator ^:
            Console.Clear();
            Console.WriteLine("Index from End Operator ^");
            int[] xs = [0, 10, 20, 30, 40];
            int last = xs[^1];
            Console.WriteLine(last);  // output: 40

            List<string> lines = ["one", "two", "three", "four"];
            string prelast = lines[^2];
            Console.WriteLine(prelast);  // output: three

            string word = "Twenty";
            Index toFirst = ^word.Length;
            char first = word[toFirst];
            Console.WriteLine(first);  // output: T
            //Console.WriteLine("Access more than length :"+word[^-1]); -- IndexOutOfRangeException: Index was outside the bounds of the array.



            //Range Operator
            Console.WriteLine("Range Operator :");
            int[] numbers1 = [0, 10, 20, 30, 40, 50];
            var res = numbers1[..];
            res[0] = 1000;
            Console.WriteLine("numbers1 :"+string.Join(",",numbers1));

            Console.WriteLine("res :"+string.Join(",",res));
            Console.WriteLine("Check Reference Equal :"+ object.ReferenceEquals(numbers1,res));

            int start = 1;
            int amountToTake = 3;
            int[] subset = numbers1[start..(start + amountToTake)];
            Display(subset);  // output: 10 20 30

            void Display<T>(IEnumerable<T> xs) => Console.WriteLine(string.Join(" ", xs));
            int margin = 1;
            int[] inner = numbers1[margin..^margin];
            Display(inner);  // output: 10 20 30 40

            string line = "one two three";
            int amountToTakeFromEnd = 5;
            Range endIndices = ^amountToTakeFromEnd..^0;
            string end = line[endIndices];
            Console.WriteLine(end);  // output: three
            //As the preceding example shows, expression a..b is of the System.Range type. In expression a..b, the results of a and b must be implicitly convertible to Int32 or Index.
            //Implicit conversions from int to Index throw an ArgumentOutOfRangeException when the value is negative.

            int amountToDrop = numbers1.Length / 2;

            int[] rightHalf = numbers1[amountToDrop..];
            Display(rightHalf);  // output: 30 40 50

            int[] leftHalf = numbers1[..^amountToDrop];
            Display(leftHalf);  // output: 0 10 20

            int[] all = numbers1[..];
            Display(all);  // output: 0 10 20 30 40 50

            int[] oneThroughTen =
            [
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            ];

            Write(oneThroughTen, ..);
            Write(oneThroughTen, ..3);
            Write(oneThroughTen, 2..);
            Write(oneThroughTen, 3..5);
            Write(oneThroughTen, ^2..);
            Write(oneThroughTen, ..^3);
            Write(oneThroughTen, 3..^4);
            Write(oneThroughTen, ^4..^2);

            static void Write(int[] values, Range range) =>
                Console.WriteLine($"{range}:\t{string.Join(", ", values[range])}");
            // Sample output:
            //      0..^0:      1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            //      0..3:       1, 2, 3
            //      2..^0:      3, 4, 5, 6, 7, 8, 9, 10
            //      3..5:       4, 5
            //      ^2..^0:     9, 10
            //      0..^3:      1, 2, 3, 4, 5, 6, 7
            //      3..^4:      4, 5, 6
            //      ^4..^2:     7, 8

            //System.Index and System.Range
            int[] collections = new int[] { 12,23,4,5,678,8876,54};
            Index s = new Index(0);
            s = 1;
            Index e = collections.Length;
            e = ^1;
            Range r = new Range(s,e);
            int[] subSet = collections[r];
            subSet = collections[s..^3];
            Display(subSet);

            
        
        }
    }
}